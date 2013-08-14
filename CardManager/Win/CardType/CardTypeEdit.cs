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
using System.Collections;
using Bouwa.Helper.Class;
using System.Configuration;

namespace Bouwa.ITSP2V31.WIN.CardType
{
    public partial class CardTypeEdit : Bouwa.Helper.BaseForm
    {
        SystemMessage _objSystemMessage = new SystemMessage();
        SystemMessageInfo _objSystemMessageInfo = new SystemMessageInfo();

        CardTypeBLL _objCardTypeBLL = new CardTypeBLL();
        LoginBLL _objLoginBll = new LoginBLL();

        CardTypeInfo _objCardTypeInfo;
        ActionType _eumActionType;
        Guid _objId = SystemConstant.GuidEmpty;

        /// <summary>
        /// 实例化
        /// </summary>
        public CardTypeEdit()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CardTypeEdit_Load(object sender, EventArgs e)
        {
            _eumActionType = (ActionType)int.Parse(this.Parameter["ActionType"].ToString());
            if (this.Parameter["Id"] != null)
            {
                _objId = new Guid(this.Parameter["Id"].ToString());
            }

            InitForm();
            SetControlVisible();
            SetFormFromInfo(_objId);
            //初始化
            this.tbnRead.Visible = _objLoginBll.IsRightByUserIdRightInfoListRightCode("Winform.Card.Type.IniDate", null, ref _objSystemMessageInfo);
        }   

        /// <summary>
        /// 窗体加载
        /// </summary>
        private void InitForm()
        {
            if (_eumActionType == ActionType.Insert)
            {
                this.Text = CardTypeInfo.InfoName+"[新增]";
            }

            if (_eumActionType == ActionType.Update)
            {
                this.Text = CardTypeInfo.InfoName + "[修改]";
            }

            if (_eumActionType == ActionType.View)
            {
                this.Text = CardTypeInfo.InfoName + "[查看]";
                tbnRead.Text = "初始化";
                tbnSave.Text = "关闭";
            }

            this.ddlStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            Helper.FormControlHelper.BindEnumToComboBox(ddlStatus, typeof(CardTypeInfo.CardTypeInfoStatus), false, CardTypeInfo.CardTypeInfoStatus.已启用.ToString("D"));//""代表所有状态
            Helper.FormControlHelper.BindEnumToComboBox(ddlCostType, typeof(CardTypeInfo.CardTypeInfoCostType), false);
            Helper.FormControlHelper.BindEnumToComboBox(ddlPurpoe, typeof(CardTypeInfo.CardTypeInfoPurpose), false);
            Helper.FormControlHelper.BindEnumToComboBox(ddlSubmitType, typeof(CardTypeInfo.CardTypeInfoSubmitType), false);
            Helper.FormControlHelper.BindEnumToComboBox(ddlDefault_Status, typeof(CardTypeInfo.CardTypeInfoDefaultCardStatus), false);
        }

        /// <summary>
        /// 设置控件是否可见
        /// </summary>
        private void SetControlVisible()
        {
            if (_eumActionType == ActionType.View||_eumActionType==ActionType.Init)
            {
                this.txtName.Enabled = this.txtBatch.Enabled = this.tbxDefault.Enabled = this.tbxMax.Enabled = this.ddlCostType.Enabled = false;
                this.ddlDefault_Status.Enabled=this.ddlPurpoe.Enabled=this.ddlStatus.Enabled=this.ddlSubmitType.Enabled=this.ckbIsView.Enabled=false;
                this.dtpEffectDate.Enabled = this.dtpOutDate.Enabled = false;
                this.txtMemo.ReadOnly = true;
            }
        }

       /// <summary>
       /// 为控件赋值
       /// </summary>
       /// <param name="theId"></param>
        private void SetFormFromInfo(Guid theId)
        {
            if (theId != Bouwa.Helper.SystemConstant.GuidEmpty)
            {
                _objCardTypeInfo = _objCardTypeBLL.GetById(theId, null, ref _objSystemMessageInfo);
                if (!_objSystemMessageInfo.Success)
                {
                    MessageBoxForm.Show(_objSystemMessageInfo, MessageBoxButtons.OK);
                }
                if (_objCardTypeInfo != null)
                {                   
                    this.txtBatch.Text = _objCardTypeInfo.Batch;
                    this.txtName.Text = _objCardTypeInfo.Name;
                    this.txtMemo.Text = _objCardTypeInfo.Memo;
                    this.ddlCostType.SelectedValue = _objCardTypeInfo.CostType;
                    this.ddlPurpoe.SelectedValue = _objCardTypeInfo.Purpose;
                    this.ddlSubmitType.SelectedValue = _objCardTypeInfo.SubmitType;
                    this.ddlStatus.SelectedValue = _objCardTypeInfo.Status;
                    this.dtpEffectDate.Value = _objCardTypeInfo.EffectDate;
                    this.dtpOutDate.Value = _objCardTypeInfo.OutDate;
                    this.ddlDefault_Status.SelectedValue=_objCardTypeInfo.DefaultCardStatus;
                    this.ckbIsView.Checked = _objCardTypeInfo.DefaultChange == CardTypeInfo.CardTypeInfoDefaultChange.可变 ? true : false;
                    if (_objCardTypeInfo.CostType == CardTypeInfo.CardTypeInfoCostType.限时卡)
                    {
                        this.lblDefault.Text = "预设时间：";
                        this.lblDefault_Unit.Text = this.lblMax_Unit.Text = "分钟";
                        this.lblMax.Text = "上限时间：";
                        this.tbxDefault.Text = _objCardTypeInfo.DefaultChargesDate.ToString();
                        this.tbxMax.Text = _objCardTypeInfo.MaxChargesDate.ToString();
                    }
                    else if (_objCardTypeInfo.CostType == CardTypeInfo.CardTypeInfoCostType.限次卡)
                    {
                        this.lblDefault.Text = "预设次数：";
                        this.lblDefault_Unit.Text = this.lblMax_Unit.Text = "次";
                        this.lblMax.Text = "上限次数：";
                        this.tbxDefault.Text = _objCardTypeInfo.DefaultTimes.ToString();
                        this.tbxMax.Text = _objCardTypeInfo.MaxTimes.ToString();
                    }
                    else if (_objCardTypeInfo.CostType== CardTypeInfo.CardTypeInfoCostType.限期卡)
                    {
                        this.lblDefault.Visible = this.lblDefault_Unit.Visible = this.lblMax_Unit.Visible = this.lblMax.Visible =
                        this.tbxDefault.Visible = this.tbxMax.Visible = false;
                    }
                    else
                    {
                        this.tbxDefault.Text = _objCardTypeInfo.DefaultMoney.ToString();
                        this.tbxMax.Text = _objCardTypeInfo.MaxMoney.ToString();
                    }
                }
            }
        }

        /// <summary>
        /// 获取已验证的卡类型对象
        /// </summary>
        /// <param name="CardTypeInfo">卡类型对象</param>
        /// <returns>是否验证成功</returns>
        private CardTypeInfo GetInfoFormForm()
        {
            CardTypeInfo objCardTypeInfo = new CardTypeInfo();
            if (_eumActionType == ActionType.Insert && _objId == SystemConstant.GuidEmpty)
            {
                objCardTypeInfo.Id = Guid.NewGuid();
            }
            else if (_eumActionType == ActionType.Update)
            {
                objCardTypeInfo = _objCardTypeBLL.GetById(_objId, null, ref _objSystemMessageInfo);
                if (!_objSystemMessageInfo.Success)
                {
                    MessageBoxForm.Show(_objSystemMessageInfo, MessageBoxButtons.OK);
                    return null;
                }
                objCardTypeInfo.Name = txtBatch.Text.Trim();
                objCardTypeInfo.Memo = txtMemo.Text.Trim();
                objCardTypeInfo.Status = (CardTypeInfo.CardTypeInfoStatus)int.Parse(ddlStatus.SelectedValue.ToString());
            }
         

            return objCardTypeInfo;
        }    

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbnSave_Click(object sender, EventArgs e)
        {
            CardTypeInfo objCardTypeInfo = GetInfoFormForm();
            //增加
            if (_eumActionType == ActionType.Insert)
            {
                if (objCardTypeInfo != null)
                {
                    _objSystemMessageInfo = _objCardTypeBLL.Insert(ref objCardTypeInfo, null);
                }

                if (_objSystemMessageInfo.Success)
                {
                    _objId = objCardTypeInfo.Id;
                    _eumActionType = ActionType.Update;
                    this.Text = CardTypeInfo.InfoName + "[修改]";
                }
            }
            //修改
            else if (_eumActionType == ActionType.Update)
            {
                if (objCardTypeInfo != null)
                {
                    _objSystemMessageInfo = _objCardTypeBLL.Update(objCardTypeInfo, null);
                }
            }
            else if (_eumActionType == ActionType.View||_eumActionType==ActionType.Init)
            {
                if (objCardTypeInfo != null)
                {
                    this.Close();
                }
            }
        }

        /// <summary>
        /// 读取停车卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbnRead_Click(object sender, EventArgs e)
        {
            BaseForm frmCardType = new BaseForm();

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
                    //判断如果长度是16
                    if (cardStatus.Length >= 16)
                    {
                        cardStatus = HelperClass.getCardStatus(cardStatus.Substring(13, 1));
                    }
                    else
                    {
                        cardStatus = Bouwa.ITSP2V31.Model.CardTypeInfo.CardTypeInfoDefaultCardStatus.空白卡.ToString("D");
                    }

                    if (cardStatus.Equals(CardTypeInfo.CardTypeInfoDefaultCardStatus.空白卡.ToString("D"))
                        || (cardStatus.Equals(CardTypeInfo.CardTypeInfoDefaultCardStatus.已充值.ToString("D")) && string.IsNullOrEmpty(HelperClass.DecryptByString(mary1[3] == null ? "" : mary1[3].ToString())))
                        || flag
                        )
                    {
                        frmCardType = new Bouwa.ITSP2V31.Win.CardType.CardTypeInit();
                        //把RFID卡内编号加入到Paramter参数中
                        frmCardType.Parameter.Add("cardNum", mary1[0]);
                        
                    }
                    else
                    {
                        frmCardType = new Bouwa.ITSP2V31.Win.CardType.CardTypeInitFail();
                        
                        //frmCardType = new Bouwa.ITSP2V31.Win.CardInfo.View();

                        //frmCardType.Parameter.Add("ActionType", ActionType.View.ToString("D"));
                        //把RFID卡内编号加入到Paramter参数中
                        frmCardType.Parameter.Add("cardNum", mary1[0]);
                        //把RFID卡得卡面编号加入到Parameter参数中
                        frmCardType.Parameter.Add("cardCode", mary1[1].Substring(9));
                    }
            }
            catch (Exception ep)
            {
                MessageBoxForm.Show(ep.Message, MessageBoxButtons.OK);
                return;
            }
            if (button.Tag.Equals("Init"))
                        {
                            frmCardType.Parameter.Add("ActionType", ActionType.Init.ToString("D"));
                        }
            frmCardType.Parameter.Add("Id", _objId.ToString());
            frmCardType.StartPosition = FormStartPosition.CenterScreen;
            frmCardType.ShowDialog(this);
        }


    }
}
