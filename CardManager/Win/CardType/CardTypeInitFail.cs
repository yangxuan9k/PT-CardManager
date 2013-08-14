using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bouwa.Helper;
using Bouwa.ITSP2V31.BLL;
using Bouwa.ITSP2V31.Model;
using Bouwa.ITSP2V31.Win.CardInfo;
using System.Collections;
using Bouwa.Helper.Class;

namespace Bouwa.ITSP2V31.Win.CardType
{
    public partial class CardTypeInitFail : Bouwa.Helper.BaseForm
    {
        SystemMessage _objSystemMessage = new SystemMessage();
        SystemMessageInfo _objSystemMessageInfo = new SystemMessageInfo();

        CardTypeBLL _objCardTypeBLL = new CardTypeBLL();
        CardTypeInfo _objCardTypeInfo;
        ActionType _eumActionType;
        Guid _objId = SystemConstant.GuidEmpty;
        CardInfoBLL _objCardInfoBLL = new CardInfoBLL();
          
        string _objCardId = SystemConstant.StringEmpty;

        string _objCardCode = SystemConstant.StringEmpty;

        public CardTypeInitFail()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 关闭窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 初始化失败界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CardTypeInitFail_Load(object sender, EventArgs e)
        {
            _eumActionType = (ActionType)int.Parse(this.Parameter["ActionType"].ToString());
            if (this.Parameter["Id"] != null)
            {
                _objId = new Guid(this.Parameter["Id"].ToString());
            }
            if (this.Parameter["cardNum"] != null)
            {
                _objCardId = this.Parameter["cardNum"].ToString();
            }
            if (this.Parameter["cardCode"] != null)
            {
                _objCardCode = this.Parameter["cardCode"].ToString();
            }
            InitForm();
            SetControlVisible();
            SetFormFromInfo(_objId);
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        private void InitForm()
        {
            if (_eumActionType == ActionType.Init)
            {
                this.Text = CardTypeInfo.InfoName + "[初始化失败]";
            }
            this.ddlStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            Helper.FormControlHelper.BindEnumToComboBox(ddlStatus, typeof(CardTypeInfo.CardTypeInfoDefaultCardStatus), false, CardTypeInfo.CardTypeInfoDefaultCardStatus.已初始化.ToString("D"));//""代表所有状态
            Helper.FormControlHelper.BindEnumToComboBox(ddlCostType, typeof(CardTypeInfo.CardTypeInfoCostType), false);
            Helper.FormControlHelper.BindEnumToComboBox(ddlPurpose, typeof(CardTypeInfo.CardTypeInfoPurpose), false);
            Helper.FormControlHelper.BindEnumToComboBox(ddlSubmitType, typeof(CardTypeInfo.CardTypeInfoSubmitType), false);
            //Helper.FormControlHelper.BindEnumToComboBox(ddlDefault_Status, typeof(CardTypeInfo.CardTypeInfoDefaultCardStatus), false);
        }

        /// <summary>
        /// 设置控件是否可见
        /// </summary>
        private void SetControlVisible()
        {
            if (_eumActionType == ActionType.Init)
            {
                this.tbxNum.Enabled= this.tbxCardType.Enabled = this.tbxLotNo.Enabled =  this.tbxPlusOver.Enabled = this.tbxMax.Enabled = this.ddlCostType.Enabled = false;
                this.ddlPurpose.Enabled = this.ddlStatus.Enabled = this.ddlSubmitType.Enabled  = false;
                this.dtpEffectDate.Enabled = this.dtpOutDate.Enabled = false;
            }
        }

        /// <summary>
        /// 为控件赋值
        /// </summary>
        /// <param name="theId"></param>
        private void SetFormFromInfo(Guid theId)
        {
                //_objCardTypeInfo = _objCardTypeBLL.GetById(theId, null, ref _objSystemMessageInfo);
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
                Hashtable objHashtable = new Hashtable();
                objHashtable.Add("no", (mary1[1] == null || string.IsNullOrEmpty(mary1[1])) ? "" : mary1[1].Substring(9));
                objHashtable.Add("cost_type", (mary1[2] == null || string.IsNullOrEmpty(mary1[2])) ? "0" : mary1[2].Substring(12,1)); //扣费类型
                objHashtable.Add("card_id", mary1[0]); //卡内编号
                this.tbxNum.Text =objHashtable["no"].ToString();
                string overPlus = (mary1[1] == null || string.IsNullOrEmpty(mary1[1])) ? "0" : mary1[1].Substring(4,5); //剩余金额/剩余次数/剩余分钟
                string overDate = (mary1[2] == null || string.IsNullOrEmpty(mary1[2])) ? "0" : mary1[2].Substring(6, 6); //最晚日期
            
                this.ddlStatus.SelectedValue = (mary1[2] == null || string.IsNullOrEmpty(mary1[2])) ? "0" : mary1[2].Substring(13,1);
                string costType = objHashtable["cost_type"].ToString();
                
                IList<Bouwa.ITSP2V31.Model.CardInfo> cardInfo = _objCardInfoBLL.SearchByCondition(objHashtable, null, 1, 1, "[status] DESC", ref _objSystemMessageInfo);
                Bouwa.ITSP2V31.Model.CardInfo cardMessage = null;
                if (cardInfo != null && cardInfo.Count > 0)
                {
                    cardMessage = cardInfo[0];
                    this.tbxCardType.Text = cardMessage.CardType;
                    this.tbxLotNo.Text=cardMessage.batch;
                    this.ddlCostType.SelectedValue = cardMessage.cost_type;
                    this.ddlSubmitType.SelectedValue = cardMessage.submit_type;
                    this.ddlPurpose.SelectedValue = cardMessage.purpose;
                    this.dtpEffectDate.Text = cardMessage.efffect_date.ToString("yyyy-MM-dd");
                    this.dtpOutDate.Text = cardMessage.end_date.ToString("yyyy-MM-dd");
                }
                //if (_objCardTypeInfo != null)
                //{
                //    this.tbxNum.Text = _objCardId;
                //    this.tbxLotNo.Text = _objCardTypeInfo.Batch;
                //    this.tbxCardType.Text = _objCardTypeInfo.Name;
                //    this.ddlStatus.SelectedValue = _objCardTypeInfo.Status;
                //    //this.lblSaasId.Text = _objCardTypeInfo.SaasId.ToString();
                //    //this.lblCardTypeId.Text = _objCardTypeInfo.Id.ToString();
                //    this.ddlCostType.SelectedValue = _objCardTypeInfo.CostType.ToString("D");
                //    this.ddlPurpose.SelectedValue = _objCardTypeInfo.Purpose;
                //    this.ddlSubmitType.SelectedValue = _objCardTypeInfo.SubmitType;
                //    this.dtpEffectDate.Text = _objCardTypeInfo.EffectDate.ToString();
                //    this.dtpOutDate.Text = _objCardTypeInfo.OutDate.ToString();
                //    //判断剩余金额字段是否可更改
                //    if (_objCardTypeInfo.DefaultChange == CardTypeInfo.CardTypeInfoDefaultChange.可变)
                //    {
                //        this.tbxPlusOver.ReadOnly = false;
                //    }
                //    else
                //    {
                //        this.tbxPlusOver.ReadOnly = true;
                //    }
                    
                //}
                if (cardMessage != null)
                {
                    if (costType.Equals(CardTypeInfo.CardTypeInfoCostType.限时卡.ToString("D")))
                    {
                        this.lblPlusOver.Text = "剩余时间：";
                        this.lblPlusOverUnit.Text = this.lblMaxUnit.Text = "分钟";
                        this.tbxMax.Text = "上限时间：";
                        this.tbxPlusOver.Text = Convert.ToString(60*Convert.ToInt32(overPlus.Substring(0,4))+Convert.ToInt32(overPlus.Substring(5))*10);
                        this.tbxMax.Text =cardMessage.MaxChargesDate.ToString();
                    }
                    else if (costType.Equals(CardTypeInfo.CardTypeInfoCostType.限次卡.ToString("D")))
                    {
                        this.lblPlusOver.Text = "剩余次数：";
                        this.lblPlusOverUnit.Text = this.lblMaxUnit.Text = "次";
                        this.lblMax.Text = "上限次数：";
                        this.tbxPlusOver.Text = overPlus.ToString();
                        this.tbxMax.Text = cardMessage.MaxTimes.ToString();
                    }
                    else if (costType.Equals(CardTypeInfo.CardTypeInfoCostType.限期卡.ToString("D")))
                    {
                        this.lblPlusOver.Text = "到期日期：";
                        this.tbxPlusOver.Text = cardMessage.end_date.ToString("yyyy-MM-dd"); 
                            this.lblPlusOverUnit.Visible = this.lblMax.Visible =
                        this.tbxMax.Visible = this.lblMaxUnit.Visible = false;
                    }
                    else
                    {
                        this.tbxPlusOver.Text = Convert.ToDecimal(float.Parse(overPlus)/10).ToString("0.00");
                        this.tbxMax.Text = cardMessage.MaxMoney.ToString();
                    }
                }
        }

        /// <summary>
        /// 重新读取卡信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReload_Click(object sender, EventArgs e)
        {
            SetFormFromInfo(_objId);
        }
        /// <summary>
        /// 读取卡信息历史
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHistory_Click(object sender, EventArgs e)
        {
            History frmCardInfoHistory = new History();

            ToolStripButton button = (ToolStripButton)sender;

            if (button.Tag.Equals("History"))
            {
                frmCardInfoHistory.Parameter.Add("ActionType", ActionType.History.ToString("D"));
            }
            frmCardInfoHistory.Parameter.Add("Card_No",_objCardCode);
            frmCardInfoHistory.Parameter.Add("Id", Guid.Empty.ToString());
            frmCardInfoHistory.StartPosition = FormStartPosition.CenterScreen;
            frmCardInfoHistory.ShowDialog(this);
        }

        /// <summary>
        /// 查看卡信息 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCardInfo_Click(object sender, EventArgs e)
        {
            ReadCard();
        }

       
        /// <summary>
        /// 进行读卡操作
        /// </summary>
        private void ReadCard()
        {
            //先读取卡内信息
            CardInfoBLL _cardBll = new CardInfoBLL();
            int status = -1; //保存读取后返回的一个状态
            Bouwa.ITSP2V31.Model.CardInfo _cardInfo = _cardBll.GetCardInfoByCard(Bouwa.Helper.CurrentUser.Current.PassWordKey, out status);
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

                if (string.IsNullOrEmpty(_cardInfo.card_id))
                {
                    MessageBoxForm.Show("未读取到卡信息，请将卡放到读卡器上！", MessageBoxButtons.OK);
                    return;
                }
                //执行查询
                BindingSource bs = new BindingSource();
                Hashtable objHashtable = new Hashtable();
                objHashtable.Add("no", _cardInfo.no);
                objHashtable.Add("cost_type", (int)_cardInfo.cost_type); //扣费类型
                objHashtable.Add("card_id", _cardInfo.card_id); //卡内编号
                //objHashtable.Add("saas_id", CurrentUser.Current.SAASID);

                IList<Bouwa.ITSP2V31.Model.CardInfo> CardInfo = _objCardInfoBLL.SearchByCondition(objHashtable, null, 1, 1, "[status] DESC", ref _objSystemMessageInfo);

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

                    MessageBoxForm.Show("停车卡未在后台注册，请联系管理员！", MessageBoxButtons.OK);

                }
            }
            catch (Exception ex)
            {
                Bouwa.Helper.Class.Log.WriterLine(Bouwa.Helper.Class.ELevel.error, "读卡出现异常", ex.Message);
                MessageBoxForm.Show(_cardBll.ConvertMeassByStatus(status), MessageBoxButtons.OK);
            }


        }

    }
}
