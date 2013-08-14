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

namespace Bouwa.ITSP2V31.WIN.CardInfo
{
    public partial class List : Bouwa.Helper.BaseForm
    {
        public List()
        {
            InitializeComponent();
        }

        SystemMessage _objSystemMessage = new SystemMessage();
        SystemMessageInfo _objSystemMessageInfo = new SystemMessageInfo();
        CardInfoBLL _objCardInfoBLL = new CardInfoBLL();
        LoginBLL _objLoginBLL = new LoginBLL();

        //设置需要显示的列
        string[] aryVisibleColumns = { "colRowNumber", "colNo", "colCardType", "colBatch", "colPurpose", "colCostType", "colSubmitType", "colEndDate", "cloMoney", "colChargesDate", "colTimes", "colStatus" };


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

            this.Text = Bouwa.ITSP2V31.Model.CardInfo.InfoName + "";

            btnSearch.Width = btnReset.Width = 50;
            btnSearch.Height = btnReset.Height = 20;

            //this.ddlStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            Helper.FormControlHelper.BindEnumToComboBox(ddlCostType, typeof(CardTypeInfo.CardTypeInfoCostTypeQianJiang), false, CardTypeInfo.CardTypeInfoCostTypeQianJiang.金额卡.ToString("D"));
            Helper.FormControlHelper.BindEnumToComboBox(ddlPurpose, typeof(CardTypeInfo.CardTypeInfoPurpose), true, "");
            Helper.FormControlHelper.BindEnumToComboBox(ddlStatus, typeof(CardTypeInfo.CardTypeInfoDefaultCardStatus), true, "");

            Hashtable table = new Hashtable();
            string RegisterType = string.Empty;    //注册类型
            table.Add("tcit_system", (int)CurrentUser.Current.PARKING_SYSTEM);
            table.Add("tcit_type", (int)CurrentUser.Current.PARK_BACKSTAGE);
            table.Add("tcit_code", CurrentUser.Current.RegisterType);

            CardTypeBLL _objCardTypeBLL = new CardTypeBLL();
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

            this.ddlOrderName.Items.Insert(0, "批次");
            this.ddlOrderName.Items.Add("停车卡类型");
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


            if (this.ddlCostType.SelectedValue.ToString() == CardTypeInfo.CardTypeInfoCostType.金额卡.ToString("D"))
            {
                for (int i = 0; i < dgvMain.Columns.Count; i++)
                {
                    if (dgvMain.Columns[i].Name == "colEndDate" || dgvMain.Columns[i].Name == "colChargesDate" || dgvMain.Columns[i].Name == "colTimes")
                    {
                        dgvMain.Columns[i].Visible = false;
                    }
                }
            }
            else if (this.ddlCostType.SelectedValue.ToString() == CardTypeInfo.CardTypeInfoCostType.限次卡.ToString("D"))
            {
                for (int i = 0; i < dgvMain.Columns.Count; i++)
                {
                    if (dgvMain.Columns[i].Name == "colEndDate" || dgvMain.Columns[i].Name == "colChargesDate" || dgvMain.Columns[i].Name == "cloMoney")
                    {
                        dgvMain.Columns[i].Visible = false;
                    }
                }
            }
            else if (this.ddlCostType.SelectedValue.ToString() == CardTypeInfo.CardTypeInfoCostType.限期卡.ToString("D"))
            {
                for (int i = 0; i < dgvMain.Columns.Count; i++)
                {
                    if (dgvMain.Columns[i].Name == "colTimes" || dgvMain.Columns[i].Name == "colChargesDate" || dgvMain.Columns[i].Name == "cloMoney")
                    {
                        dgvMain.Columns[i].Visible = false;
                    }
                }
            }
            else if (this.ddlCostType.SelectedValue.ToString() == CardTypeInfo.CardTypeInfoCostType.限时卡.ToString("D"))
            {
                for (int i = 0; i < dgvMain.Columns.Count; i++)
                {
                    if (dgvMain.Columns[i].Name == "colEndDate" || dgvMain.Columns[i].Name == "colTimes" || dgvMain.Columns[i].Name == "cloMoney")
                    {
                        dgvMain.Columns[i].Visible = false;
                    }
                }
            }

        }


        /// <summary>
        /// 绑定DataGirdView
        /// </summary>
        private int RefreshDataGridView()
        {
            BindingSource bs = new BindingSource();
            Hashtable objHashtable = new Hashtable();
            objHashtable.Add("no", this.tbxCardNo.Text.Trim());
            objHashtable.Add("batch", this.tbxBatch.Text.Trim());
            objHashtable.Add("card_type", this.tbtCardType.Text.Trim());

            if (this.ddlPurpose.SelectedValue != null && int.Parse(this.ddlPurpose.SelectedValue.ToString()) != -1)
            {
                objHashtable.Add("purpose", this.ddlPurpose.SelectedValue);
            }
            if (this.ddlRegistType.SelectedValue != null && int.Parse(this.ddlRegistType.SelectedValue.ToString()) != -1)
            {
                objHashtable.Add("submit_type", this.ddlRegistType.SelectedValue);
            }
            if (this.ddlCostType.SelectedValue != null && int.Parse(this.ddlCostType.SelectedValue.ToString()) != -1)
            {
                objHashtable.Add("cost_type", this.ddlCostType.SelectedValue);
            }
            if (int.Parse(this.ddlStatus.SelectedValue.ToString()) != -1)
            {
                objHashtable.Add("status", this.ddlStatus.SelectedValue);
            }
            objHashtable.Add("saas_id", CurrentUser.Current.SAASID);

            string OrderByName = string.Empty;
            string OrderBy = string.Empty;
            string OrderName = string.Empty;

            if (this.ddlOrderName.Text == "批次")
            {
                OrderName = "batch";
            }
            else
            {
                OrderName = "card_type";
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

            IList<Bouwa.ITSP2V31.Model.CardInfo> CardInfo = _objCardInfoBLL.SearchByCondition(objHashtable, null, CurrentUser.Current.PageSize, CurrentUser.Current.PageIndex, OrderByName, ref _objSystemMessageInfo);
            bs.DataSource = CardInfo;
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
        private void List_Load(object sender, EventArgs e)
        {
            InitForm();
            this.pager1.PageCurrent = 1;
            this.pager1.Bind();
            RefreshDataGridView();
            SetControlVisible();

            //读卡权限
            this.btnReadCard.Visible = _objLoginBLL.IsRightByUserIdRightInfoListRightCode("Winform.Read.Card", null, ref _objSystemMessageInfo);
        }

        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.pager1.Bind();
            RefreshDataGridView();
            SetControlVisible();
        }

        /// <summary>
        /// 重置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            this.tbtCardType.Text = this.tbxBatch.Text = this.tbxCardNo.Text = string.Empty;
            this.ddlCostType.SelectedValue = CardTypeInfo.CardTypeInfoCostType.金额卡.ToString("D");
            this.ddlPurpose.SelectedValue =  this.ddlStatus.SelectedValue = -1;
            this.ddlRegistType.SelectedValue =0;
            this.ddlOrderBy.SelectedItem = "升序";
            this.ddlOrderName.SelectedItem = "批次";
            this.pager1.Bind();
            RefreshDataGridView();
            SetControlVisible();
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

            Bouwa.ITSP2V31.Win.CardInfo.View frmCardInfoEdit = new Bouwa.ITSP2V31.Win.CardInfo.View();

            string strId = dgvMain.SelectedRows[0].Cells["Id"].Value.ToString();

            frmCardInfoEdit.Parameter.Add("ActionType", ActionType.View.ToString("D"));
            frmCardInfoEdit.Parameter.Add("Id", strId);
            frmCardInfoEdit.StartPosition = FormStartPosition.CenterScreen;
            frmCardInfoEdit.ShowDialog(this);       
        }

        private int pager1_EventPaging(WindowsApp.MyControl.EventPagingArg e)
        {
            return RefreshDataGridView();
        }

        /// <summary>
        /// 进行读卡操作
        /// </summary>
        private void ReadCard() {
            //先读取卡内信息
            CardInfoBLL _cardBll = new CardInfoBLL();
            int status = -1; //保存读取后返回的一个状态
            Bouwa.ITSP2V31.Model.CardInfo _cardInfo = _cardBll.GetCardInfoByCard(Bouwa.Helper.CurrentUser.Current.PassWordKey, out status);
            try
            {
                //string[] mary1 = StringUtil.readBlock(RFIDClass.ReadCardAndReturnStatus(CurrentUser.Current.PassWordKey, Convert.ToInt32(1)));
                //if (mary1[4] != "0")
                //{
                //    //MessageBoxForm.Show(RFIDClass.ConvertMeassByStatus(Convert.ToInt32(mary1[4])));
                //    throw new Exception(RFIDClass.ConvertMeassByStatus(Convert.ToInt32(mary1[4])));
                //}
                ////string[] mary6 = StringUtil.readBlock(RFIDClass.ReadCardAndReturnStatus(CurrentUser.Current.PassWordKey, Convert.ToInt32(6)));
                ////判断当前读的卡是否能初始化的条件; 1: 卡状态为空卡255 ；2：卡状态为已充值，但最后操作时间为空
                //string cardStatus = mary1[2].ToString();
                //if (cardStatus.Length >= 16)
                //{
                //    cardStatus = HelperClass.getCardStatus(cardStatus.Substring(13, 1));
                //}
                //else
                //{
                //    cardStatus = Bouwa.ITSP2V31.Model.CardTypeInfo.CardTypeInfoDefaultCardStatus.空白卡.ToString("D");
                //}

                //if (cardStatus.Equals(CardTypeInfo.CardTypeInfoDefaultCardStatus.空白卡.ToString("D"))
                //    || (cardStatus.Equals(CardTypeInfo.CardTypeInfoDefaultCardStatus.已充值.ToString("D")) && string.IsNullOrEmpty(HelperClass.DecryptByString(mary1[3])))
                //    ||  _cardInfo ==null
                //    )
                //{
                //    Bouwa.ITSP2V31.WIN.CardType.CardTypeList frmCardType = new Bouwa.ITSP2V31.WIN.CardType.CardTypeList();
                //    MessageBoxForm.Show("停车卡还未初始化，需先初始化停车卡！", MessageBoxButtons.OK);

                //    frmCardType.StartPosition = FormStartPosition.CenterScreen;

                //    frmCardType.ShowDialog(this);
                //    return;
                //}
                //再去读取一次
                if(status == 11||status ==12){
                    _cardInfo = _cardBll.GetCardInfoByCard(string.Empty, out status);
                }
                if (status != 0)
                {
                    MessageBoxForm.Show(RFIDClass.ConvertMeassByStatus(status), MessageBoxButtons.OK);
                    return;
                }
                else if (_cardInfo==null)
                {
                    MessageBoxForm.Show("此卡为空卡，请先进行初始化！", MessageBoxButtons.OK);
                    return;
                }
                //执行查询
                BindingSource bs = new BindingSource();
                Hashtable objHashtable = new Hashtable();
                objHashtable.Add("no", _cardInfo.no);
                objHashtable.Add("cost_type",(int) _cardInfo.cost_type); //扣费类型
                objHashtable.Add("card_id", _cardInfo.card_id); //卡内编号
                //objHashtable.Add("saas_id", CurrentUser.Current.SAASID);

                IList<Bouwa.ITSP2V31.Model.CardInfo> CardInfo = _objCardInfoBLL.SearchByCondition(objHashtable, null, 1, 1,"[status] DESC", ref _objSystemMessageInfo);

                //说明注册过了
                if (CardInfo != null && CardInfo.Count > 0)
                {

                    Bouwa.ITSP2V31.Win.CardInfo.View frmCardInfoEdit = new Bouwa.ITSP2V31.Win.CardInfo.View();

                    frmCardInfoEdit.Parameter.Add("ActionType", ActionType.View.ToString("D"));
                    frmCardInfoEdit.Parameter.Add("Id", CardInfo[0].id.ToString());
                    frmCardInfoEdit.StartPosition = FormStartPosition.CenterScreen;
                    frmCardInfoEdit.ShowDialog(this);
                }//说明未注册
                else
                {
                    //Bouwa.ITSP2V31.WIN.CardType.CardTypeList frmCardType = new Bouwa.ITSP2V31.WIN.CardType.CardTypeList();
                    //MessageBoxForm.Show("停车卡还未初始化，需先初始化停车卡！", MessageBoxButtons.OK);
                    MessageBoxForm.Show("后台未找到停车卡信息，请联系管理员！", MessageBoxButtons.OK);
                    //frmCardType.StartPosition = FormStartPosition.CenterScreen;
                    //frmCardType.ShowDialog(this);
                    return;
                }
            }
            catch (Exception ex)
            {
                Bouwa.Helper.Class.Log.WriterLine(Bouwa.Helper.Class.ELevel.error, "读卡出现异常", ex.Message);
                MessageBoxForm.Show(_cardBll.ConvertMeassByStatus(status), MessageBoxButtons.OK);
            }
            

       }
        /// <summary>
        /// 执行读卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadCard_Click(object sender, EventArgs e)
        {
            ReadCard();
        }

        private void dgvMain_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            tbnView_Click(sender, e);
        }

        /// <summary>
        /// 历史
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbHistory_Click(object sender, EventArgs e)
        {
            if (dgvMain.SelectedRows.Count == 0)
            {
                MessageBoxForm.Show(new SystemMessage().GetInfoByCode("PleaseSelectData"), MessageBoxButtons.OK);
                return;
            }

            Bouwa.ITSP2V31.Win.CardInfo.History frmHistory = new Bouwa.ITSP2V31.Win.CardInfo.History();

            string strId = dgvMain.SelectedRows[0].Cells["Id"].Value.ToString();
            string cardNo = dgvMain.SelectedRows[0].Cells["colNo"].Value.ToString();
            frmHistory.Parameter.Add("ActionType", ActionType.History.ToString("D"));
            frmHistory.Parameter.Add("Id", strId);
            frmHistory.Parameter.Add("Card_No", cardNo);
            frmHistory.StartPosition = FormStartPosition.CenterScreen;
            frmHistory.ShowDialog(this);   

        }




    }
}
