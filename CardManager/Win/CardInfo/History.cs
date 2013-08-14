using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Bouwa.Helper;
using Bouwa.ITSP2V31.BLL;
using Bouwa.ITSP2V31.Model;

namespace Bouwa.ITSP2V31.Win.CardInfo
{
    public partial class History : Bouwa.Helper.BaseForm
    {
        public History()
        {
            InitializeComponent();
        }
        SystemMessage _objSystemMessage = new SystemMessage();
        SystemMessageInfo _objSystemMessageInfo = new SystemMessageInfo();
        HistoryBLL _objHistoryBLL = new HistoryBLL();
        Guid _objId = SystemConstant.GuidEmpty;
        string cardNum = string.Empty;
        ActionType _eumActionType;

        //设置需要显示的列
        string[] aryVisibleColumns = { "colRowNumber", "colOperationTime", "colNetwork", "colAddressType", "colOperationType", "colOperationMemo", "colOperationUser" };
        /// <summary>
        /// 窗体加载
        /// </summary>
        private void InitForm()
        {
            if (_eumActionType == ActionType.History)
            {
                this.Text = cardNum + Bouwa.ITSP2V31.Model.HistoryInfo.InfoName + "[列表]";
            }

            dgvMain.Top = 50;
            dgvMain.Left = 0;
            dgvMain.Width = this.Width;
            dgvMain.Height = this.Height - dgvMain.Top-63;
            dgvMain.ReadOnly = true;
            dgvMain.MultiSelect = false;
            dgvMain.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            btnSearch.Width =50;
            btnSearch.Height =  20;

        }

        /// <summary>
        /// 设置控件可见
        /// </summary>
        private void SetControlVisible()
        {
            //设定要显示的表格中的列
            for (int i = 0; i < dgvMain.Columns.Count; i++)
            {
                dgvMain.Columns[i].Visible = false;
            }
            for (int i = 0; i < dgvMain.Columns.Count; i++)
            {
                for (int j = 0; j < aryVisibleColumns.Length; j++)
                {
                    if (dgvMain.Columns[i].Name == aryVisibleColumns[j])
                    {
                        dgvMain.Columns[i].Visible = true;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// 绑定DataGirdView
        /// </summary>
        private int RefreshDataGridView(Guid _objId, string cardNum)
        {
            IList<HistoryInfo> history = new List<HistoryInfo>();
            BindingSource bs = new BindingSource();
            Hashtable table = new Hashtable();

            if (this.cmbChoice.SelectedValue.ToString().Equals(HistoryInfo.Operation.小于等于.ToString("D")))
            {

                table.Add("start_date",CurrentUser.Current.EffectDateBegin.ToString("yyyy-MM-dd"));
                table.Add("end_date", this.dtpEffectDateBegin.Value.ToString("yyyy-MM-dd"));
            }
            if (this.cmbChoice.SelectedValue.ToString().Equals(HistoryInfo.Operation.大于等于.ToString("D")))
            {
                table.Add("start_date", this.dtpEffectDateBegin.Value.ToString("yyyy-MM-dd"));
                table.Add("end_date", CurrentUser.Current.EffectDateEnd.ToString("yyyy-MM-dd"));
            }
            if (this.cmbChoice.SelectedValue.ToString().Equals(HistoryInfo.Operation.等于.ToString("D")))
            {
                table.Add("start_date", this.dtpEffectDateBegin.Value.ToString("yyyy-MM-dd"));
                table.Add("end_date", this.dtpEffectDateBegin.Value.ToString("yyyy-MM-dd"));
            }
            if (this.cmbChoice.SelectedValue.ToString().Equals(HistoryInfo.Operation.介于.ToString("D")))
            {
                table.Add("start_date", this.dtpEffectDateBegin.Value.ToString("yyyy-MM-dd"));
                table.Add("end_date", this.dtpEffectDateEnd.Value.ToString("yyyy-MM-dd"));
            }

            if (!string.IsNullOrEmpty(cardNum)) {
                table.Add("card_no", cardNum);
            }

            CurrentUser.Current.PageIndex = this.pager1.PageCurrent;
            CurrentUser.Current.PageSize = this.pager1.PageSize;

            if (CurrentUser.Current.TotalCount == 0)
            {
                CurrentUser.Current.PageIndex = 0;
                CurrentUser.Current.PageCount = 0;
            }
            else
            {
                CurrentUser.Current.PageCount = CurrentUser.Current.TotalCount % CurrentUser.Current.PageSize == 0 ? CurrentUser.Current.TotalCount / CurrentUser.Current.PageSize : CurrentUser.Current.TotalCount / CurrentUser.Current.PageSize + 1;
                if (CurrentUser.Current.PageIndex > CurrentUser.Current.PageCount)
                {
                    CurrentUser.Current.PageIndex = CurrentUser.Current.PageCount;
                }
            }

            //Dictionary<string, object> arr = new Dictionary<string, object>();
            //arr["ICode"] = "ITSP2_RFID_CS_CarHistory";
            //arr["IVer"] = "1.0.0.1";
            //arr["SAASId"] = "";
            //arr["CardId"] = _objId;
            //arr["Size"] = CurrentUser.Current.PageSize;
            //arr["BeginPage"] = CurrentUser.Current.PageIndex;
           // history= _objHistoryBLL.SearchByCondition(arr, null, ref _objSystemMessageInfo);

            history = _objHistoryBLL.SearchByCondition(table, "operation_time Desc", CurrentUser.Current.PageSize, CurrentUser.Current.PageIndex, null, ref _objSystemMessageInfo);
            bs.DataSource = history;
            this.pager1.bindingSource.DataSource = bs;
            this.pager1.bindingNavigator.BindingSource = pager1.bindingSource;
            this.dgvMain.DataSource = pager1.bindingSource;
            if (!_objSystemMessageInfo.Success)
            {
                MessageBoxForm.Show(_objSystemMessageInfo, MessageBoxButtons.OK);
            }
            return CurrentUser.Current.TotalCount;
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void History_Load(object sender, EventArgs e)
        {
            Helper.FormControlHelper.BindEnumToComboBox(cmbChoice, typeof(HistoryInfo.Operation), false,HistoryInfo.Operation.等于.ToString("D"));

            _eumActionType = (ActionType)int.Parse(this.Parameter["ActionType"].ToString());
            //if (this.Parameter["Id"] != null)
            //{
            //    _objId = new Guid(this.Parameter["Id"].ToString());
            //}
            cardNum = this.Parameter["Card_No"].ToString();
            cmbChoice_SelectedIndexChanged(sender, e);
            InitForm();
            this.pager1.PageCurrent = 1;
            this.pager1.Bind();
            RefreshDataGridView(_objId, cardNum);
            SetControlVisible();
        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private int pager1_EventPaging(WindowsApp.MyControl.EventPagingArg e)
        {
            return RefreshDataGridView(_objId,cardNum);
        }

        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.pager1.Bind();
            RefreshDataGridView(_objId, cardNum);
        }
        /// <summary>
        /// 判断
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lblEffectDateEnd.Visible = this.dtpEffectDateEnd.Visible = true;
            this.dtpEffectDateBegin.Enabled = true;
            if (this.cmbChoice.SelectedValue.ToString().Equals(HistoryInfo.Operation.介于.ToString("D")))
            {
                this.lblEffectDateEnd.Visible = this.dtpEffectDateEnd.Visible = true;
            }
            else if (this.cmbChoice.SelectedValue.ToString().Equals(HistoryInfo.Operation.为空.ToString("D")))
            {
                this.dtpEffectDateBegin.Enabled = false;
                this.lblEffectDateEnd.Visible = this.dtpEffectDateEnd.Visible = false;
            }
            else
            {
                this.lblEffectDateEnd.Visible = this.dtpEffectDateEnd.Visible = false;
            }

        }
    }
}
