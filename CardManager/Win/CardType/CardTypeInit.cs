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
using System.Threading;
using Bouwa.Helper.Class;
using System.Collections;
using System.Configuration;
using System.Text.RegularExpressions;


namespace Bouwa.ITSP2V31.Win.CardType
{
    public partial class CardTypeInit : Bouwa.Helper.BaseForm
    {

        SystemMessage _objSystemMessage = new SystemMessage();
        SystemMessageInfo _objSystemMessageInfo = new SystemMessageInfo();

        CardTypeBLL _objCardTypeBLL = new CardTypeBLL();
        CardInfoBLL _objCardInfoBLL = new CardInfoBLL();
        LoginBLL _objLoginBll = new LoginBLL();

        CardTypeInfo _objCardTypeInfo;
        ActionType _eumActionType;
        Guid _objId = SystemConstant.GuidEmpty;

        string _objCardId = SystemConstant.StringEmpty;

        bool readCardFlag = false;

        //传入按钮的Tag名
        string buttonTag = SystemConstant.StringEmpty;

        public CardTypeInit()
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
        /// 初始化界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CardTypeInit_Load(object sender, EventArgs e)
        {


            panel2.Visible = false;

            _eumActionType = (ActionType)int.Parse(this.Parameter["ActionType"].ToString());
            if (this.Parameter["Id"] != null)
            {
                _objId = new Guid(this.Parameter["Id"].ToString());
            }
            if (this.Parameter["cardNum"] != null)
            {
                _objCardId = this.Parameter["cardNum"].ToString();
            }
            if (this.Parameter["buttonType"] != null)
            {
                buttonTag = this.Parameter["buttonType"].ToString();
            }


            InitForm();
            SetControlVisible();
            SetFormFromInfo(_objId);

            //初始化
            tbnInit.Visible = _objLoginBll.IsRightByUserIdRightInfoListRightCode("Winform.Card.Type.IniDate", null, ref _objSystemMessageInfo);
        }

        /// <summary>
        /// 读取块数据
        /// </summary>
        /// <param name="mary"></param>
        /// <returns></returns>
        private string[] readBlock(string[] mary)
        {
            string[] arr = new string[mary.Length];
            arr[0] = mary[0];
            arr[4] = mary[4];
            for (int i = 1; i < mary.Length - 1; i++)
            {
                if (!string.IsNullOrEmpty(mary[i]))
                {
                    arr[i] = HelperClass.DecryptByString(mary[i]);
                }
            }
            return arr;
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        private void InitForm()
        {
            if (_eumActionType == ActionType.Init)
            {
                this.Text = CardTypeInfo.InfoName + "[初始化]";
            }
            this.ddlStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            //Helper.FormControlHelper.BindEnumToComboBox(ddlStatus, typeof(CardTypeInfo.CardTypeInfoDefaultCardStatus), false, CardTypeInfo.CardTypeInfoDefaultCardStatus.空白卡.ToString("D"));//""代表所有状态
            Helper.FormControlHelper.BindEnumToComboBox(ddlStatus, typeof(CardTypeInfo.CardTypeInfoDefaultCardStatus), false);
        }

        /// <summary>
        /// 设置控件是否可见
        /// </summary>
        private void SetControlVisible()
        {
            if (_eumActionType == ActionType.Init)
            {
                this.tbxLotNum.ReadOnly = this.tbxCardType.ReadOnly = this.tbxMax.ReadOnly = true;
                //this.ddlStatus.Enabled = false;
                //this.lblMessage.Text = "";
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
                    

                    this.lblNum.Text = _objCardId;
                    this.tbxLotNum.Text = _objCardTypeInfo.Batch;
                    this.tbxCardType.Text = _objCardTypeInfo.Name;



                    this.ddlStatus.SelectedValue = _objCardTypeInfo.DefaultCardStatus;
                    this.lblSaasId.Text = _objCardTypeInfo.SaasId.ToString();
                    this.lblCardTypeId.Text = _objCardTypeInfo.Id.ToString("N");
                    this.lblCostType.Text = _objCardTypeInfo.CostType.ToString("D");

             

                    this.lblEffectDate.Text = _objCardTypeInfo.EffectDate.ToString();
                    this.lblOutDate.Text = _objCardTypeInfo.OutDate.ToString();

                    this.lblPurpose.Text = _objCardTypeInfo.Purpose.ToString("D");
                    this.lblSubmitType.Text = _objCardTypeInfo.SubmitType.ToString("D");

                    this.lblExtSaasId.Text = Convert.ToString(_objCardTypeInfo.extSaasId);

                    this.lblExtCardTypeId.Text = Convert.ToString(_objCardTypeInfo.extCardTypeId);
                    //判断上限金额字段是否可更改
                    if (_objCardTypeInfo.DefaultChange.Equals( CardTypeInfo.CardTypeInfoDefaultChange.可变))
                    {
                        this.tbxOverPlus.ReadOnly = false;
                    }
                    else
                    {
                        this.tbxOverPlus.ReadOnly = true;
                    }

                    if ((int)_objCardTypeInfo.CostType==(int)CardTypeInfo.CardTypeInfoCostType.限时卡)
                    {
                        this.lblOverPlus.Text = "剩余时间：";
                        this.lblOverPlusUnit.Text = this.lblMaxUnit.Text = "分钟";
                        this.lblMax.Text = "上限时间：";
                        this.tbxOverPlus.Text = _objCardTypeInfo.DefaultChargesDate.ToString();
                        this.tbxMax.Text = _objCardTypeInfo.MaxChargesDate.ToString();
                    }
                    else if ((int)_objCardTypeInfo.CostType == (int)CardTypeInfo.CardTypeInfoCostType.限次卡)
                    {
                        this.lblOverPlus.Text = "剩余次数：";
                        this.lblOverPlusUnit.Text = this.lblMaxUnit.Text = "次";
                        this.lblMax.Text = "上限次数：";
                        this.tbxOverPlus.Text = _objCardTypeInfo.DefaultTimes.ToString();
                        this.tbxMax.Text = _objCardTypeInfo.MaxTimes.ToString();
                    }
                    else if ((int)_objCardTypeInfo.CostType ==(int)CardTypeInfo.CardTypeInfoCostType.限期卡)
                    {
                        this.lblOverPlus.Text = "到期日期：";
                        this.lblOverPlusUnit.Text = "";
                        this.tbxOverPlus.Text = _objCardTypeInfo.OutDate.ToString("yyyy-MM-dd");
                        this.lblMax.Visible = this.tbxMax.Visible = this.lblMaxUnit.Visible = false;
                        panel2.Visible = true;

                    }
                    else
                    {
                        this.tbxOverPlus.Text = _objCardTypeInfo.DefaultMoney.ToString();
                        this.tbxMax.Text = _objCardTypeInfo.MaxMoney.ToString();
                    }
                }
            }
        }

        /// <summary>
        /// 读取卡信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbnReadCard_Click(object sender, EventArgs e)
        {
            try
            {
                if (!readCardFlag)
                {
                    string[] mary1 = readBlock(RFIDClass.ReadCardAndReturnStatus(CurrentUser.Current.PassWordKey, Convert.ToInt32(1)));
                    if (mary1[4] != "0")
                    {
                        throw new Exception(RFIDClass.ConvertMeassByStatus(Convert.ToInt32(mary1[4])));
                    }
                    readCardFlag = true;
                    string[] mary2 = readBlock(RFIDClass.ReadCardAndReturnStatus(CurrentUser.Current.PassWordKey, Convert.ToInt32(2)));
                    string[] mary3 = readBlock(RFIDClass.ReadCardAndReturnStatus(CurrentUser.Current.PassWordKey, Convert.ToInt32(3)));
                    string[] mary4 = readBlock(RFIDClass.ReadCardAndReturnStatus(CurrentUser.Current.PassWordKey, Convert.ToInt32(4)));
                    string[] mary5 = readBlock(RFIDClass.ReadCardAndReturnStatus(CurrentUser.Current.PassWordKey, Convert.ToInt32(5)));
                    string[] mary6 = readBlock(RFIDClass.ReadCardAndReturnStatus(CurrentUser.Current.PassWordKey, Convert.ToInt32(6)));
                    lblNum.Text = mary1[0];//卡内编号;
                    this.tbxCardNum.Text = mary4[1]; //卡面编号
                    this.lblMessage.Visible = true;

                    //读卡成功
                    readCardFlag = false;
                }
            }
            catch (Exception ep)
            {

               // SystemMessageInfo info = new SystemMessageInfo();
               // info.Content = string.Format(_objSystemMessage.GetInfoByCode("readCardFail").ToString(), ep.Message);
               // MessageBoxForm.Show(info, MessageBoxButtons.OK);
                readCardFlag = false;
                MessageBoxForm.Show(ep.Message, MessageBoxButtons.OK);
            }
        }

        private void writeBlock(int cbShanQu, int kuai, string value)
        {
            int p = RFIDClass.WriterCardAndReturnStatus(this.lblNum.Text, CurrentUser.Current.PassWordKey, cbShanQu, kuai, HelperClass.EncryptByString(value));
        }

        /// <summary>
        /// 初始化写卡数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbnWriteCard_Click(object sender, EventArgs e)
        {
            string d = Guid.NewGuid().ToString("N");
         
            string password = CurrentUser.Current.PassWordKey;
            try
            {
                
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
                
                string cardStatus = string.IsNullOrEmpty(mary1[2])?"":mary1[2];
                //判断如果长度是16
                if (cardStatus.Length >= 16)
                {
                    cardStatus = HelperClass.getCardStatus(cardStatus.Substring(13, 1));
                }
                else
                {
                    cardStatus = Bouwa.ITSP2V31.Model.CardTypeInfo.CardTypeInfoDefaultCardStatus.空白卡.ToString("D");
                }
                //如果是从重新初始化的按钮进入，则跳过下面判断
                if (!"InitAgain".Equals(buttonTag))
                {
                    if (!(Bouwa.ITSP2V31.Model.CardTypeInfo.CardTypeInfoDefaultCardStatus.空白卡.ToString("D").Equals(cardStatus)
                        || (cardStatus.Equals(CardTypeInfo.CardTypeInfoDefaultCardStatus.已充值.ToString("D")) && string.IsNullOrEmpty(HelperClass.DecryptByString(mary1[3] == null ? "" : mary1[3].ToString())))
                        || flag))
                    {
                        MessageBoxForm.Show("该卡已被初始化或已有消费，无法再次初始化！", MessageBoxButtons.OK);
                        return;
                    }
                }
                if (!mary1[0].Equals(this.lblNum.Text))
                {
                    //MessageBoxForm.Show(_objSystemMessage.GetInfoByCode("ReadNoSameCard"), MessageBoxButtons.OK);
                    MessageBoxForm.Show("读取停车卡和待写入卡不是同一张卡，不能被写入！", MessageBoxButtons.OK);
                    return;
                }
                if (string.IsNullOrEmpty(this.lblNum.Text))
                {
                    MessageBoxForm.Show("未读取到卡内编号，请重试！", MessageBoxButtons.OK);
                    return;
                }
                if (string.IsNullOrEmpty(this.tbxCardNum.Text))
                {
                    MessageBoxForm.Show("卡面编号不能为空，请重新输入！", MessageBoxButtons.OK);
                    return;
                }
                

                //判断卡面编号输入是否合法
                Regex rx = new Regex("^[\u4E00-\u9FA5]+$");
                if (rx.IsMatch(this.tbxCardNum.Text.Trim()))
                {
                    MessageBoxForm.Show("卡面编号必须是数字或者字母，请重新输入！", MessageBoxButtons.OK);
                    return;
                }
                //将该卡信息写入后台数据库
                Hashtable cardInfo = new Hashtable();
                //插入初始化记录
                Hashtable htCardInfo = new Hashtable();
                //主键
                cardInfo.Add("id", Guid.NewGuid());
                htCardInfo.Add("id", Guid.NewGuid().ToString());
                //saasId
                if (!string.IsNullOrEmpty(this.lblSaasId.Text))
                {
                    cardInfo.Add("saas_id", new Guid(this.lblSaasId.Text));
                    htCardInfo.Add("saas_id", this.lblSaasId.Text);
                }
                //卡内编号
                if (!string.IsNullOrEmpty(this.lblNum.Text))
                {
                    cardInfo.Add("card_id", this.lblNum.Text);
                    htCardInfo.Add("card_id", Guid.Empty.ToString());
                }
                else
                {
                    MessageBoxForm.Show("未读取到卡内编号，请重试！", MessageBoxButtons.OK);
                    return;
                }
                //卡面编号
                if (!string.IsNullOrEmpty(this.tbxCardNum.Text.Trim()))
                {
                    cardInfo.Add("no", StringUtil.formatDataString(this.tbxCardNum.Text, 7));
                    htCardInfo.Add("no", StringUtil.formatDataString(this.tbxCardNum.Text, 7));
                }
                else
                {
                    MessageBoxForm.Show("卡面编号不能为空，请重新输入！", MessageBoxButtons.OK);
                    return;
                }

             

                //判断输入的值是否超过预定的最大值
                string maxValue ="0";
                Hashtable table = new Hashtable();
                CardTypeBLL _objCardTypeBLL = new CardTypeBLL();
                table.Add("tcit_system", (int)CurrentUser.Current.PARKING_SYSTEM);
                table.Add("tcit_type", (int)CurrentUser.Current.PARK_BACKSTAGE);
                //判断上限分钟是否大于预设值
                if (this.lblCostType.Text.Equals(Bouwa.ITSP2V31.Model.CardInfo.CardTypeInfoCostType.限时卡.ToString("D")))
                {
                    table.Add("tcit_code", CurrentUser.Current.MaxTime);

                    maxValue = _objCardTypeBLL.GetRegisterType(table, null);
                    int max = 0;
                    Regex regex = new Regex("[^0-9]");
                    if (string.IsNullOrEmpty(this.tbxOverPlus.Text))
                    {
                        MessageBoxForm.Show("剩余时间不能为空！", MessageBoxButtons.OK);
                        return;
                    }
                    if(regex.IsMatch(maxValue))
                    {
                        MessageBoxForm.Show("限时预设值格式不正确，无法继续充值，请联系管理员！", MessageBoxButtons.OK);
                        return;
                    }
                    if(regex.IsMatch(this.tbxOverPlus.Text))
                    {
                        MessageBoxForm.Show("剩余时间必须为数字，请重新输入！", MessageBoxButtons.OK);
                        return;
                    }
                    max = Convert.ToInt32(this.tbxOverPlus.Text);
                    if (Convert.ToInt32(this.tbxOverPlus.Text) > Convert.ToInt32(this.tbxMax.Text))
                    {
                        MessageBoxForm.Show("剩余时间不能大于上限时间！", MessageBoxButtons.OK);
                        return;
                    }
                    if (Convert.ToInt32(this.tbxOverPlus.Text) > max)
                    {
                        MessageBoxForm.Show("剩余时间不能大于预设最大" + maxValue + "分！", MessageBoxButtons.OK);
                        return;
                    }
                }
                //判断剩余次数是否大于预设值
                else if (this.lblCostType.Text.Equals(Bouwa.ITSP2V31.Model.CardInfo.CardTypeInfoCostType.限次卡.ToString("D")))
                {
                    table.Add("tcit_code", CurrentUser.Current.MaxDegree);

                    maxValue = _objCardTypeBLL.GetRegisterType(table, null);
                    int max = 0;
                    Regex regex = new Regex("[^0-9]");
                    if (string.IsNullOrEmpty(this.tbxOverPlus.Text))
                    {
                        MessageBoxForm.Show("剩余次数不能为空！", MessageBoxButtons.OK);
                        return;
                    }
                    if(regex.IsMatch(maxValue))
                    {
                        MessageBoxForm.Show("次数预设值格式不正确，无法继续初始化，请联系管理员！", MessageBoxButtons.OK);
                        return;
                    }
                    if (regex.IsMatch(this.tbxOverPlus.Text))
                    {
                        MessageBoxForm.Show("剩余次数必须为数字，请重新输入！", MessageBoxButtons.OK);
                        return;
                    }
                    max = Int32.Parse(this.tbxOverPlus.Text);
                    if (Convert.ToInt32(this.tbxOverPlus.Text) > Convert.ToInt32(this.tbxMax.Text))
                    {
                        MessageBoxForm.Show("剩余次数不能大于上限次数！", MessageBoxButtons.OK);
                        return;
                    }
                    if (Convert.ToInt32(this.tbxOverPlus.Text) > Convert.ToInt32(maxValue))
                    {
                        MessageBoxForm.Show("剩余次数不能大于预设最大" + maxValue + "次！", MessageBoxButtons.OK);
                        return;
                    }
                }
                //判断剩余金额是否大于预设值
                else if (this.lblCostType.Text.Equals(Bouwa.ITSP2V31.Model.CardInfo.CardTypeInfoCostType.金额卡.ToString("D")))
                {
                    table.Add("tcit_code", CurrentUser.Current.MaxMoney);

                    maxValue = _objCardTypeBLL.GetRegisterType(table, null);
                    decimal max = new Decimal(0.00);
                    Regex RegDecimalSign = new Regex("^[+-]?[0-9]+[.]?[0-9]+$");
                    if (string.IsNullOrEmpty(this.tbxOverPlus.Text))
                    {
                        MessageBoxForm.Show("剩余次数不能为空！", MessageBoxButtons.OK);
                        return;
                    }
                    if(!RegDecimalSign.IsMatch(maxValue))
                    {
                        MessageBoxForm.Show("次数预设值格式不正确，无法继续初始化，请联系管理员！", MessageBoxButtons.OK);
                        return;
                    }
                    if (!RegDecimalSign.IsMatch(this.tbxOverPlus.Text))
                    {
                        MessageBoxForm.Show("剩余次数必须为数字，请重新输入！", MessageBoxButtons.OK);
                        return;
                    }
                    max = Convert.ToDecimal(this.tbxOverPlus.Text);
                    if (Convert.ToDecimal(this.tbxOverPlus.Text) > Convert.ToDecimal(this.tbxMax.Text))
                    {
                        MessageBoxForm.Show("剩余金额不能大于上限金额！", MessageBoxButtons.OK);
                        return;
                    }
                    if (Convert.ToDecimal(this.tbxOverPlus.Text) > max)
                    {
                        MessageBoxForm.Show("剩余金额不能大于上限金额" + maxValue + "元！", MessageBoxButtons.OK);
                        return;
                    }
                }
                StringBuilder sb = new StringBuilder();
                //初始化写入密码
                RFIDClass.UpdateCardPassWordAndReturnStatus(this.lblNum.Text, 1, SystemConstant.StringEmpty, CurrentUser.Current.PassWordKey);
                
                //写入扩展的SAASID
                if (!"0".Equals(SystemConstant.saas_type.SAAS_TYPE.ToString("D")))
                {
                    sb.Append(StringUtil.formatDataString(Convert.ToInt32(lblExtSaasId.Text),3));

                }
                //写入系统编号
                sb.Append(SystemConstant.system_type.CS_SYSTEM.ToString("D"));
                //写入剩余金额及剩余次数及剩余时间，限期卡为5个0，限时卡前面是小时数，最后一位是分钟数数
                if (this.lblCostType.Text.Equals(Bouwa.ITSP2V31.Model.CardInfo.CardTypeInfoCostType.限期卡.ToString("D")))
                {
                    sb.Append(StringUtil.formatDataString(0,5));
                    lblOutDate.Text = tbxOverPlus.Text;
                }
                else if (this.lblCostType.Text.Equals(Bouwa.ITSP2V31.Model.CardInfo.CardTypeInfoCostType.限时卡.ToString("D")))
                {
                    string hours = Convert.ToString(Convert.ToInt32(this.tbxOverPlus.Text) / 60);  //根据输入分钟数，输入数字除60取余计算出小时数
                    string minutes = Convert.ToString(Convert.ToInt32(this.tbxOverPlus.Text)%60/10);  //根据输入数字除60取模，然后再除以10，得到分钟数，1代表10分钟，2代表20分钟，依次类推

                    sb.Append(StringUtil.formatDataString(Convert.ToInt32(hours+minutes),5));
                }
                else if (this.lblCostType.Text.Equals(Bouwa.ITSP2V31.Model.CardInfo.CardTypeInfoCostType.金额卡.ToString("D")))
                {
                    //格式化金额的存储,前4位保存整数，后1位保存小数点后面第一位
                    string money = Convert.ToDecimal(this.tbxOverPlus.Text).ToString("0.0");
                    sb.Append(StringUtil.formatDataString(Convert.ToInt32(money.Replace(".", "")), 5));
                }
                else
                {
                    sb.Append(StringUtil.formatDataString(Convert.ToInt32(this.tbxOverPlus.Text),5));
                }
                //写入卡面编号
                sb.Append(StringUtil.formatDataString(this.tbxCardNum.Text,7));
                //写入第一扇区的第零块
                writeBlock(1, 0, sb.ToString());
                sb = new StringBuilder();
                //写入生效日期
                sb.Append(DateTime.Parse(this.lblEffectDate.Text).ToString("yyMMdd"));
                //写入最晚日期
                sb.Append(DateTime.Parse(this.lblOutDate.Text).ToString("yyMMdd"));
                //写入扣费类型
                sb.Append(this.lblCostType.Text.ToString());
                //写入停车卡状态
                sb.Append(this.ddlStatus.SelectedValue == null ? Bouwa.ITSP2V31.Model.CardTypeInfo.CardTypeInfoDefaultCardStatus.已初始化.ToString("D") : this.ddlStatus.SelectedValue.ToString());
                //写入卡类型
                sb.Append(StringUtil.formatDataString(this.lblExtCardTypeId.Text.ToString(),2));
                //写入第一扇区的第一块
                writeBlock(1,1,sb.ToString());
                //把最后操作时间写入第一扇区的第二块
                sb = new StringBuilder();
                sb.Append(DateTime.Now.ToString("yyyyMMddHHmmss"));
                writeBlock(1, 2, sb.ToString());

                RFIDClass.IssueSound(50); //发出声音代表完成
                
                //批次
                if (!string.IsNullOrEmpty(this.tbxLotNum.Text))
                {
                    cardInfo.Add("batch",this.tbxLotNum.Text);
                }
                //停车卡类型
                if (!string.IsNullOrEmpty(this.lblCardTypeId.Text))
                {
                    cardInfo.Add("card_type", _objId.ToString());
                }
                cardInfo.Add("status",this.ddlStatus.SelectedValue==null?Bouwa.ITSP2V31.Model.CardTypeInfo.CardTypeInfoDefaultCardStatus.已初始化.ToString("D"):this.ddlStatus.SelectedValue.ToString());
                //生效日期
                if (!string.IsNullOrEmpty(this.lblEffectDate.Text))
                {
                    cardInfo.Add("efffect_date", Convert.ToDateTime(this.lblEffectDate.Text));
                }
                //最晚到期
                if (!string.IsNullOrEmpty(this.lblOutDate.Text))
                {
                    cardInfo.Add("end_date",Convert.ToDateTime(this.lblOutDate.Text));
                }

                //停车卡用途
                if (!string.IsNullOrEmpty(this.lblPurpose.Text))
                {
                    cardInfo.Add("purpose",Convert.ToInt32(this.lblPurpose.Text));
                    //cardInfo.purpose = 0;
                }
                //注册类型
                if (!string.IsNullOrEmpty(this.lblSubmitType.Text))
                {
                    cardInfo.Add("submit_type",Convert.ToInt32(this.lblSubmitType.Text));
                }
                //扣费类型
                if (!string.IsNullOrEmpty(this.lblCostType.Text))
                {
                    cardInfo.Add("cost_type",Convert.ToInt32(this.lblCostType.Text));
                    htCardInfo.Add("cost_type", Convert.ToInt32(this.lblCostType.Text));
                }
                //初始化操作日志,仅对非空白卡进行写数据
                if (!this.ddlStatus.SelectedValue.Equals(CardTypeInfo.CardTypeInfoDefaultCardStatus.空白卡.ToString("D")))
                {
                    string message = SystemConstant.StringEmpty;
                    //剩余操作次数
                    if (this.lblCostType.Text.Equals(CardTypeInfo.CardTypeInfoCostType.限次卡.ToString("D")))
                    {
                        cardInfo.Add("times", Convert.ToInt32(this.tbxOverPlus.Text));
                        //备注信息
                        cardInfo.Add("memo", this.tbxCardNum.Text + "初始化成功！");
                        htCardInfo.Add("volume", Convert.ToInt32(this.tbxOverPlus.Text));
                        //htCardInfo.Add("operation_memo", String.Format(_objSystemMessage.GetInfoByCode("InitMemo").Content, this.tbxCardNum.Text, String.Format(_objSystemMessage.GetInfoByCode("InitTime").Content, this.tbxOverPlus.Text)));
                        message = "InitTime";
                    }
                    else
                    {
                        cardInfo.Add("times", 0);
                    }
                    //剩余操作金额
                    if (this.lblCostType.Text.Equals(CardTypeInfo.CardTypeInfoCostType.金额卡.ToString("D")))
                    {
                        cardInfo.Add("money", Convert.ToDecimal(this.tbxOverPlus.Text));
                        //备注信息
                        cardInfo.Add("memo", this.tbxCardNum.Text + "初始化成功！");
                        htCardInfo.Add("volume", Convert.ToDecimal(this.tbxOverPlus.Text));
                       // htCardInfo.Add("operation_memo", String.Format(_objSystemMessage.GetInfoByCode("InitMemo").Content, this.tbxCardNum.Text, String.Format(_objSystemMessage.GetInfoByCode("InitMoney").Content, this.tbxOverPlus.Text)));
                        message = "InitMoney";
                    }
                    else
                    {
                        if (this.lblCostType.Text.Equals(Bouwa.ITSP2V31.Model.CardInfo.CardTypeInfoCostType.限期卡.ToString("D")))
                        {
                            cardInfo.Add("money", Convert.ToDecimal(this.txtMonthMoney.Text));   //加上月卡或年卡多少钱
                        }
                        else
                        {
                            cardInfo.Add("money", 0);
                        }
                     
                      
                    }
                    //剩余计费时间
                    if (this.lblCostType.Text.Equals(CardTypeInfo.CardTypeInfoCostType.限时卡.ToString("D")))
                    {
                        cardInfo.Add("charges_date", Convert.ToInt32(this.tbxOverPlus.Text));
                        //备注信息
                        cardInfo.Add("memo", this.tbxCardNum.Text + "初始化成功！");
                        htCardInfo.Add("volume", Convert.ToInt32(this.tbxOverPlus.Text));
                        //htCardInfo.Add("operation_memo", String.Format(_objSystemMessage.GetInfoByCode("InitMemo").Content, this.tbxCardNum.Text, String.Format(_objSystemMessage.GetInfoByCode("InitDegree").Content, this.tbxOverPlus.Text)));
                        message="InitDegree";
                    }
                    else
                    {
                        cardInfo.Add("charges_date", 0);
                    }
                    //剩余计费时间
                    if (this.lblCostType.Text.Equals(CardTypeInfo.CardTypeInfoCostType.限期卡.ToString("D")))
                    {
                        //备注信息
                      
                        cardInfo.Add("memo", this.tbxCardNum.Text + "初始化成功！");
                        htCardInfo.Add("volume", Convert.ToDateTime(this.lblOutDate.Text).ToString("yyyyMMdd"));
                        //htCardInfo.Add("operation_memo", "初始化成功！");
                        message = "InitDate";
                    }
                    htCardInfo.Add("operation_memo_init",_objSystemMessage.GetInfoByCode("InitMemo").Content);
                    htCardInfo.Add("operation_type_init", 1);
                    //if (this.ddlStatus.SelectedValue.Equals(CardTypeInfo.CardTypeInfoDefaultCardStatus.已挂失.ToString("D")))
                    //{
                    //    htCardInfo.Add("operation_type", 2);
                    //    htCardInfo.Add("operation_memo_payment", string.Format(_objSystemMessage.GetInfoByCode(message).Content, this.tbxOverPlus.Text));
                    //}
                    if (this.ddlStatus.SelectedValue.ToString().Equals(CardTypeInfo.CardTypeInfoDefaultCardStatus.已充值.ToString("D")))
                    {
                        htCardInfo.Add("operation_type_payment", 5);
                        htCardInfo.Add("operation_memo_payment", string.Format(_objSystemMessage.GetInfoByCode(message).Content, this.tbxOverPlus.Text));
                    }
                }
                //初始化人员ID
                cardInfo.Add("create_user",CurrentUser.Current.UserId);
                htCardInfo.Add("operation_user",CurrentUser.Current.UserId);
                //初始化时间
                cardInfo.Add("create_time",DateTime.Now); 
                htCardInfo.Add("operation_time",DateTime.Now.ToString());
                htCardInfo.Add("modity_user", CurrentUser.Current.UserId);
                htCardInfo.Add("modity_time", DateTime.Now.ToString());
               // htCardInfo.Add("operation_type","1");
                htCardInfo.Add("address_type","1");
                htCardInfo.Add("network_id", CurrentUser.Current.NetWorkID);

                if (this.lblCostType.Text.Equals(Bouwa.ITSP2V31.Model.CardInfo.CardTypeInfoCostType.限期卡.ToString("D")))
                {
                    cardInfo.Add("CarNo", txtCarNo.Text.Trim().ToString());
                    cardInfo.Add("CarColor", txtCarColor.Text.Trim().ToString());
                    cardInfo.Add("CarName", txtCarName.Text.Trim().ToString());
                 
                }
                else
                {
                    cardInfo.Add("CarNo", "");
                    cardInfo.Add("CarColor", "");
                    cardInfo.Add("CarName", "");
                }



                string mes = _objCardInfoBLL.InsertCardInfo(cardInfo,htCardInfo, null, ref _objSystemMessageInfo);

                if ("卡面编号已存在！".Equals(mes))
                {
                    this.tbxCardNum.Focus();
                    this.tbxCardNum.Select();
                    //写入停车卡状态
                    RFIDClass.UpdateCardPassWordAndReturnStatus(this.lblNum.Text, 1, password, SystemConstant.StringEmpty);
                    writeBlock(1, 0, "");
                    writeBlock(1, 1, "");
                    writeBlock(1, 2, "");
                    MessageBoxForm.Show("卡面编号为[" + this.tbxCardNum.Text + "]的停车卡已存在！", MessageBoxButtons.OK);
                }
                else if ("停车卡初始化成功！".Equals(mes))
                {
                    MessageBoxForm.Show("停车卡[" + this.tbxCardNum.Text + "]初始化成功！", MessageBoxButtons.OK);
                    this.tbxCardNum.Text = string.Empty;
                }
                else if ("停车卡初始化失败！".Equals(mes))
                {
                    //写入停车卡状态
                    RFIDClass.UpdateCardPassWordAndReturnStatus(this.lblNum.Text, 1, password, SystemConstant.StringEmpty);
                    writeBlock(1, 0, "");
                    writeBlock(1, 1, "");
                    writeBlock(1, 2, "");
                    MessageBoxForm.Show("停车卡[" + this.tbxCardNum.Text + "]初始化失败！", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                //写入停车卡状态
                RFIDClass.UpdateCardPassWordAndReturnStatus(this.lblNum.Text, 1, password, SystemConstant.StringEmpty);
                writeBlock(1, 0, "");
                writeBlock(1, 1, "");
                writeBlock(1, 2, "");
                MessageBoxForm.Show(ex.Message, MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// 重新读取卡信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReload_Click(object sender, EventArgs e)
        {
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
                    || flag || "InitAgain".Equals(buttonTag)
                    )
                {
                    //把RFID卡内编号赋值给卡内编号控件
                     _objCardId = mary1[0];
                     this.tbxCardNum.Text = string.Empty;
                }
                else
                {
                    this.Close();
                    Bouwa.ITSP2V31.Win.CardType.CardTypeInitFail frmCardType = new Bouwa.ITSP2V31.Win.CardType.CardTypeInitFail();
                    //把RFID卡内编号加入到Paramter参数中
                    frmCardType.Parameter.Add("cardNum", mary1[0]);
                    frmCardType.Parameter.Add("ActionType", ActionType.Init.ToString("D"));
                    frmCardType.Parameter.Add("Id", _objId.ToString());
                    frmCardType.StartPosition = FormStartPosition.CenterScreen;
                    frmCardType.ShowDialog(this);
                }
            }
            catch (Exception ep)
            {
                MessageBoxForm.Show(ep.Message, MessageBoxButtons.OK);
                return;
            }
            SetFormFromInfo(_objId);
        }
    }
}
