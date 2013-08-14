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
using Bouwa.Helper.Class;
using System.Configuration;

namespace Bouwa.ITSP2V31.WIN.CardType
{
    public partial class CardTypeList : Bouwa.Helper.BaseForm
    {
        public CardTypeList()
        {
            InitializeComponent();
        }

        SystemMessage _objSystemMessage = new SystemMessage();
        SystemMessageInfo _objSystemMessageInfo = new SystemMessageInfo();
        CardTypeBLL _objCardTypeBLL = new CardTypeBLL();
        LoginBLL _loginBLL = new LoginBLL();

        //设置需要显示的列
        string[] aryVisibleColumns = { "colRowNumber","colName", "colBatch",  "colPurpose", "colCostType", "colSubmitType", "colEffectDate", "colOutDate" };

        /// <summary>
        /// 窗体加载
        /// </summary>
        private void InitForm()
        {
            dgvMain.Top = 70;
            dgvMain.Left = 0;
            dgvMain.Width = this.Width;
            dgvMain.Height = this.Height - dgvMain.Top - 63;
            dgvMain.ReadOnly = true;
            dgvMain.MultiSelect = false;
            dgvMain.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            this.Text = CardTypeInfo.InfoName + "";

            //程序员如果保证相关搜索控件在界面上已标识Text，就不用写如下：
            //lblEffectDateBegin.Text = "时间";
            //lblEffectDateEnd.Text = "~";
            //lblName.Text = "名称";
            //lblStatus.Text = "状态";
            //btnSearch.Text = "搜索";
            //btnReset.Text = "重置";

            //程序员如果保证相关搜索控件在界面上能对齐，就不用写如下：
            dtpEffectDateBegin.Width = dtpEffectDateEnd.Width = txtName.Width  = 120;
            dtpEffectDateBegin.Height = dtpEffectDateEnd.Height = txtName.Height = 20;
            btnSearch.Width = btnReset.Width = 50;
            btnSearch.Height = btnReset.Height = 20;


            //this.ddlStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            Helper.FormControlHelper.BindEnumToComboBox(ddlCostType, typeof(CardTypeInfo.CardTypeInfoCostTypeQianJiang), true, "");
            Helper.FormControlHelper.BindEnumToComboBox(ddlPurpose, typeof(CardTypeInfo.CardTypeInfoPurpose), true, "");


            Hashtable table = new Hashtable();
            string RegisterType = string.Empty;    //注册类型
            table.Add("tcit_system", (int)CurrentUser.Current.PARKING_SYSTEM);
            table.Add("tcit_type", (int)CurrentUser.Current.PARK_BACKSTAGE);
            table.Add("tcit_code", CurrentUser.Current.RegisterType);

            RegisterType = _objCardTypeBLL.GetRegisterType(table, null);

            if (RegisterType == "实名")
            {
                Helper.FormControlHelper.BindEnumToComboBox(ddlRegistType, typeof(CardTypeInfo.CardTypeInfoSubmitType_Name), false, CardTypeInfo.CardTypeInfoSubmitType_Name.实名.ToString("D"));                
            }
            else if (RegisterType == "不记名")
            {
                Helper.FormControlHelper.BindEnumToComboBox(ddlRegistType, typeof(CardTypeInfo.CardTypeInfoSubmitType_UnName), false, CardTypeInfo.CardTypeInfoSubmitType_UnName.不记名.ToString("D"));
            }
            else
            {
                Helper.FormControlHelper.BindEnumToComboBox(ddlRegistType, typeof(CardTypeInfo.CardTypeInfoSubmitType), true, "");
            }
               
            this.ddlOrderName.Items.Insert(0, "生效日期");
            this.ddlOrderName.Items.Add("最晚到期");
            this.ddlOrderName.Items.Add("扣费类型");
            this.ddlOrderName.Text = this.ddlOrderName.Items[0].ToString();

            this.ddlOrderBy.Items.Insert(0, "升序");
            this.ddlOrderBy.Items.Add("降序");
            this.ddlOrderBy.Text = this.ddlOrderBy.Items[0].ToString();
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

            //获得配置文件中的初始化标志位,Test
            //声明HashTable
            Hashtable table = new Hashtable();
            table.Add("tcit_system", (int)CurrentUser.Current.PARKING_SYSTEM);
            table.Add("tcit_type", (int)CurrentUser.Current.CS_CLIENT);
            table.Add("tcit_code", SystemConstant.InitAgain);
            string initFlag = _objCardTypeBLL.GetRegisterType(table, null);
            if ("true".Equals(initFlag))
            {
                this.btnInitAgain.Visible = true;
            }
            else
            {
                this.btnInitAgain.Visible = false;
            }
        }

        /// <summary>
        /// 绑定DataGirdView
        /// </summary>
        private int RefreshDataGridView()
        {
            BindingSource bs = new BindingSource();           

            Hashtable objHashtable = new Hashtable();
            if (txtName.Text.Trim() != "")
            {
                objHashtable.Add("name", txtName.Text.Trim());
            }
            objHashtable.Add("status", "1");
            if (!this.cbkEffectTime.Checked)
            {
                objHashtable.Add("effect_start_date", this.dtpEffectDateBegin.Value.ToString("yyyy-MM-dd"));
                objHashtable.Add("effect_end_date", this.dtpEffectDateEnd.Value.ToString("yyyy-MM-dd"));
            }
            if (!cbkEndTime.Checked)
            {
                objHashtable.Add("out_start_date", this.dtpOutDateBegion.Value.ToString("yyyy-MM-dd"));
                objHashtable.Add("out_end_date", this.dtpOutDateEnd.Value.ToString("yyyy-MM-dd"));
            }
            if(this.tbxBatch.Text !="")
            {
                objHashtable.Add("batch",this.tbxBatch.Text);
            }
            if (this.ddlPurpose.SelectedValue != null && int.Parse(this.ddlPurpose.SelectedValue.ToString()) != -1)
            {
                objHashtable.Add("purpose", this.ddlPurpose.SelectedValue);
            }
            if (this.ddlRegistType.SelectedValue != null && int.Parse(this.ddlRegistType.SelectedValue.ToString()) != -1)
            {
                objHashtable.Add("submit_type", this.ddlRegistType.SelectedValue);
            }
            if (this.ddlCostType.SelectedValue!=null && int.Parse(this.ddlCostType.SelectedValue.ToString()) != -1)
            {
                objHashtable.Add("cost_type", this.ddlCostType.SelectedValue);
            }
            objHashtable.Add("saas_id", CurrentUser.Current.SAASID);

            string OrderByName = string.Empty;
            string OrderBy = string.Empty;
            string OrderName = string.Empty;

            if (this.ddlOrderName.Text == "生效日期")
            {
                OrderName = "effect_date";
            }
            else if (this.ddlOrderName.Text == "最晚到期")
            {
                OrderName = "out_date";
            }
            else
            {
                OrderName = "cost_type";
            }

            if (this.ddlOrderBy.Text == "降序")
            {
                OrderBy = "DESC";
            }
            else
            {
                OrderBy = "ASC";
            }
            OrderByName = OrderName + " " + OrderBy;

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

            IList<CardTypeInfo> cardType = _objCardTypeBLL.SearchByCondition(objHashtable, OrderByName, null, CurrentUser.Current.PageSize, CurrentUser.Current.PageIndex, ref _objSystemMessageInfo);
            bs.DataSource = cardType;
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
        private void CardTypeList_Load(object sender, EventArgs e)
        {
            InitForm();
            cbkEffectTime_CheckedChanged(sender, e);
            this.pager1.PageCurrent = 1;
            this.pager1.Bind();
            RefreshDataGridView();
            SetControlVisible();

            //初始化
            tbnInit.Visible = _loginBLL.IsRightByUserIdRightInfoListRightCode("Winform.Card.Type.IniDate", null, ref _objSystemMessageInfo);
        }

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbnInsert_Click(object sender, EventArgs e)
        {
            Bouwa.ITSP2V31.WIN.CardType.CardTypeEdit frmCardTypeEdit = new Bouwa.ITSP2V31.WIN.CardType.CardTypeEdit();
            frmCardTypeEdit.Parameter.Add("ActionType", ActionType.Insert.ToString("D"));
            frmCardTypeEdit.StartPosition = FormStartPosition.CenterScreen;
            frmCardTypeEdit.ShowDialog(this);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvMain.SelectedRows.Count == 0)
            {
                MessageBoxForm.Show(new SystemMessage().GetInfoByCode("PleaseSelectData"), MessageBoxButtons.OK);
                return;
            }

            Bouwa.ITSP2V31.WIN.CardType.CardTypeEdit frmCardTypeEdit = new Bouwa.ITSP2V31.WIN.CardType.CardTypeEdit();

            string strId = dgvMain.SelectedRows[0].Cells["Id"].Value.ToString();

            frmCardTypeEdit.Parameter.Add("ActionType", ActionType.Update.ToString("D"));
            frmCardTypeEdit.Parameter.Add("Id", strId);
            frmCardTypeEdit.StartPosition = FormStartPosition.CenterScreen;
            frmCardTypeEdit.ShowDialog(this);
        }

        /// <summary>
        /// 查看
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbnView_Click(object sender, EventArgs e)
        {
            if (dgvMain.SelectedRows.Count == 0)
            {
                MessageBoxForm.Show(new SystemMessage().GetInfoByCode("PleaseSelectData"), MessageBoxButtons.OK);
                return;
            }

            Bouwa.ITSP2V31.WIN.CardType.CardTypeEdit frmCardTypeEdit = new Bouwa.ITSP2V31.WIN.CardType.CardTypeEdit();

            string strId = dgvMain.SelectedRows[0].Cells["Id"].Value.ToString();

            //ToolStripButton button = (ToolStripButton)sender;
            //if (button.Tag.Equals("View"))
            //{
                frmCardTypeEdit.Parameter.Add("ActionType", ActionType.View.ToString("D"));
            //}
            
            frmCardTypeEdit.Parameter.Add("Id", strId);
            frmCardTypeEdit.StartPosition = FormStartPosition.CenterScreen;
            frmCardTypeEdit.ShowDialog(this);
        }

        /// <summary>
        /// 查找
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.pager1.Bind();
            RefreshDataGridView();
        }

        /// <summary>
        /// 重置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            this.txtName.Text = this.tbxBatch.Text=string.Empty;
            this.ddlCostType.SelectedValue = this.ddlPurpose.SelectedValue =  -1;
            this.ddlRegistType.SelectedValue = 0;
            this.dtpEffectDateBegin.Value = this.dtpEffectDateEnd.Value = this.dtpOutDateBegion.Value=this.dtpOutDateEnd.Value = System.DateTime.Now;
            this.cbkEffectTime.Checked = this.cbkEndTime.Checked = true;
            this.ddlOrderBy.SelectedItem = "升序";
            this.ddlOrderName.SelectedItem = "生效日期";
            cbkEffectTime_CheckedChanged(sender, e);
            this.pager1.Bind();
            RefreshDataGridView();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbnDelete_Click(object sender, EventArgs e)
        {
            if (dgvMain.SelectedRows.Count == 0)
            {
                MessageBoxForm.Show(new SystemMessage().GetInfoByCode("PleaseSelectData"), MessageBoxButtons.OK);
                return;
            }

            string strId = dgvMain.SelectedRows[0].Cells["Id"].Value.ToString();

            DialogResult objDialogResult = MessageBoxForm.Show(new SystemMessage().GetInfoByCode("ConfirmToDelete"), MessageBoxButtons.OKCancel);
            if (objDialogResult == DialogResult.OK)
            {
                _objSystemMessageInfo = _objCardTypeBLL.Delete(new Guid(strId), null);
            }
            else
            {
                return;
            }

            if (_objSystemMessageInfo.Success)
            {
                RefreshDataGridView();
            }
            MessageBoxForm.Show(_objSystemMessageInfo, MessageBoxButtons.OK);
        }

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbnRefresh_Click(object sender, EventArgs e)
        {
            btnSearch_Click(sender, e);
        }

        /// <summary>
        /// 对停车卡充值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbnInit_Click(object sender, EventArgs e)
        {
            Bouwa.Helper.BaseForm frmCardType = new BaseForm();
            ToolStripButton button = (ToolStripButton)sender;
            //读取卡内编号
            try
            {
                string password = CurrentUser.Current.PassWordKey;
                bool flag = false;
                string[] mary1 = StringUtil.readBlock(RFIDClass.ReadCardAndReturnStatus(password, Convert.ToInt32(1)));
                if (mary1[4] == "11" || mary1[4] == "12")
                {
                    flag = true;
                    password = SystemConstant.StringEmpty;
                    mary1 = StringUtil.readBlock(RFIDClass.ReadCardAndReturnStatus(password, Convert.ToInt32(1)));
                    
                }
                if (mary1[4] != "0")
                {
                    throw new Exception(RFIDClass.ConvertMeassByStatus(Convert.ToInt32(mary1[4])));
                }
                //string[] mary6 = StringUtil.readBlock(RFIDClass.ReadCardAndReturnStatus(CurrentUser.Current.PassWordKey, Convert.ToInt32(6)));
                //判断当前读的卡是否能初始化的条件; 1: 卡状态为空卡255 ；2：卡状态为已充值，但最后操作时间为空
                string cardStatus = string.IsNullOrEmpty(mary1[2]) ? "" : mary1[2].ToString();
                if (cardStatus.Length >= 16)
                {
                    cardStatus = HelperClass.getCardStatus(cardStatus.Substring(13, 1));
                }
                else
                {
                    cardStatus = Bouwa.ITSP2V31.Model.CardTypeInfo.CardTypeInfoDefaultCardStatus.空白卡.ToString("D");
                }
                if (cardStatus.Equals(CardTypeInfo.CardTypeInfoDefaultCardStatus.空白卡.ToString("D"))
                    || (cardStatus.Equals(CardTypeInfo.CardTypeInfoDefaultCardStatus.已充值.ToString("D")) && string.IsNullOrEmpty(HelperClass.DecryptByString(mary1[3])))
                    || flag ||"InitAgain".Equals(button.Tag)
                    )
                {
                    frmCardType = new Bouwa.ITSP2V31.Win.CardType.CardTypeInit();
                    //把RFID卡内编号加入到Paramter参数中
                    frmCardType.Parameter.Add("cardNum", mary1[0]);
                }
                else
                {
                    frmCardType = new Bouwa.ITSP2V31.Win.CardType.CardTypeInitFail();
                    //把RFID卡内编号加入到Paramter参数中
                    frmCardType.Parameter.Add("cardNum", mary1[0]);
                    //把RFID卡得卡面编号加入到Parameter参数中
                    frmCardType.Parameter.Add("cardCode",mary1[1]==null?"":mary1[1].Substring(9));
                }
            }
            catch (Exception ep)
            {
                MessageBoxForm.Show(ep.Message, MessageBoxButtons.OK);
                return;
            }
            if (button.Tag.Equals("Init")||button.Tag.Equals("InitAgain"))
            {
                frmCardType.Parameter.Add("ActionType", ActionType.Init.ToString("D"));
                frmCardType.Parameter.Add("ButtonType",button.Tag.ToString());
            }
            frmCardType.Parameter.Add("Id", dgvMain.SelectedRows[0].Cells["Id"].Value.ToString());
            frmCardType.StartPosition = FormStartPosition.CenterScreen;
            frmCardType.ShowDialog(this);
        }

        /// <summary>
        /// 是否包含时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbkEffectTime_CheckedChanged(object sender, EventArgs e)
        {
            this.dtpEffectDateBegin.Enabled = this.dtpEffectDateEnd.Enabled = true;
            this.dtpOutDateBegion.Enabled = this.dtpOutDateEnd.Enabled = true;
            if (this.cbkEffectTime.Checked)
            {
                this.dtpEffectDateBegin.Enabled = this.dtpEffectDateEnd.Enabled = false;
            }
            if (this.cbkEndTime.Checked)
            {
                this.dtpOutDateBegion.Enabled = this.dtpOutDateEnd.Enabled = false;
            }
        }

        private int pager1_EventPaging(WindowsApp.MyControl.EventPagingArg e)
        {
            return RefreshDataGridView(); ;
        }

        /// <summary>
        /// 双击单元格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvMain_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            tbnView_Click(sender, e);
        }
        /// <summary>
        /// 重新初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInitAgain_Click(object sender, EventArgs e)
        {
            tbnInit_Click(sender,e);
        }
    }
}
