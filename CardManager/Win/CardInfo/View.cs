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
using Bouwa.ITSP2V31.Win.ChargeValue;
using Bouwa.Helper.Class;
using System.Collections;

namespace Bouwa.ITSP2V31.Win.CardInfo
{
    public partial class View : Bouwa.Helper.BaseForm
    {
        SystemMessage _objSystemMessage = new SystemMessage();
        SystemMessageInfo _objSystemMessageInfo = new SystemMessageInfo();

        CardInfoBLL _objCardInfoBLL = new CardInfoBLL();
        Bouwa.ITSP2V31.Model.CardInfo _objCardInfo;
        LoginBLL _objLoginBLL = new LoginBLL();
        ActionType _eumActionType;
        Guid _objId = SystemConstant.GuidEmpty;
        //先读取卡内信息
        CardInfoBLL _cardBll = new CardInfoBLL();

        public View()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 历史
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbnHistory_Click(object sender, EventArgs e)
        {
            Bouwa.ITSP2V31.Win.CardInfo.History frmHistory = new Bouwa.ITSP2V31.Win.CardInfo.History();

            //string strId = dgvMain.SelectedRows[0].Cells["Id"].Value.ToString();

            frmHistory.Parameter.Add("ActionType", ActionType.History.ToString("D"));
            frmHistory.Parameter.Add("Id", _objId.ToString());
            frmHistory.Parameter.Add("Card_No", _objCardInfo.no);
            frmHistory.StartPosition = FormStartPosition.CenterScreen;
            frmHistory.ShowDialog(this);    
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void View_Load(object sender, EventArgs e)
        {
            _eumActionType = (ActionType)int.Parse(this.Parameter["ActionType"].ToString());
            if (this.Parameter["Id"] != null)
            {
                _objId = new Guid(this.Parameter["Id"].ToString());
            }

            InitForm();
            SetControlVisible();
            SetFormFromInfo(_objId);

            //充值，卡重置，退卡，申请换卡权限 
            this.btnChargeValue.Visible = _objLoginBLL.IsRightByUserIdRightInfoListRightCode("Winform.Card.Info.IniMoney", null, ref _objSystemMessageInfo);
            this.btnReset.Visible = _objLoginBLL.IsRightByUserIdRightInfoListRightCode("Winform.Card.Type.ResetCard", null, ref _objSystemMessageInfo);
            this.btnBack.Visible = _objLoginBLL.IsRightByUserIdRightInfoListRightCode("Winform.Card.Info.BackCard", null, ref _objSystemMessageInfo);
            this.btnChangeCard.Visible = _objLoginBLL.IsRightByUserIdRightInfoListRightCode("Winform.Card.Info.ChangeCard", null, ref _objSystemMessageInfo);

            //根据卡状态判断是否显示其他按钮，如果为已挂失状态，则屏蔽其他的按钮
            if(_objCardInfo!=null&& _objCardInfo.status== Bouwa.ITSP2V31.Model.CardInfo.CardTypeInfoDefaultCardStatus.已挂失){
                this.btnChargeValue.Visible = false;
                this.btnReset.Visible = false;
                this.btnBack.Visible = false;
                this.btnChangeCard.Visible = false;
                this.btnChangeCard.Text = "换卡";
                this.btnChangeCard.Tag = "1";

                //获得配置文件中的初始化标志位,Test
                Hashtable table = new Hashtable();
                table.Add("tcit_system", (int)CurrentUser.Current.PARKING_SYSTEM);
                table.Add("tcit_type", (int)CurrentUser.Current.CS_CLIENT);
                table.Add("tcit_code", SystemConstant.ChangeCardIntervalTime);

                CardTypeBLL _objCardTypeBLL = new CardTypeBLL();
                //根据配置表根据间隔时间来确认是否显示换卡按钮,必须要大于今天
                string initFlag = _objCardTypeBLL.GetRegisterType(table, null);
                if(!string.IsNullOrEmpty(initFlag)&&(DateTime.Compare(DateTime.Now, _objCardInfo.modify_time.AddMinutes(Convert.ToDouble(initFlag))) >= 0)){
                    this.btnChangeCard.Visible = true;
                }
               

            }

        }
        /// <summary>
        /// 窗体加载
        /// </summary>
        private void InitForm()
        {
            if (_eumActionType == ActionType.Insert)
            {
                this.Text = Bouwa.ITSP2V31.Model.CardInfo.InfoName + "[新增]";
            }

            if (_eumActionType == ActionType.Update)
            {
                this.Text = Bouwa.ITSP2V31.Model.CardInfo.InfoName + "[修改]";
            }

            if (_eumActionType == ActionType.View)
            {
                this.Text = Bouwa.ITSP2V31.Model.CardInfo.InfoName + "[查看]";
                //tbnSave.Text = "关闭";
            }

            this.ddlDefault_Status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            //Helper.FormControlHelper.BindEnumToComboBox(ddlDefault_Status, typeof(CardTypeInfo.CardTypeInfoStatus), false, CardTypeInfo.CardTypeInfoStatus.已启用.ToString("D"));//""代表所有状态
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
            if (_eumActionType == ActionType.View)
            {
                //this.tabControl1.Enabled = false;
                this.panel3.Enabled = false;
                this.panel2.Enabled = false;
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
                _objCardInfo = _objCardInfoBLL.GetById(theId, null, ref _objSystemMessageInfo);
                if (_objCardInfo != null)
                {
                    this.txtBatch.Text = _objCardInfo.batch;
                    this.tbxCardNum.Text = _objCardInfo.no;
                    this.tbxCardType.Text = _objCardInfo.CardType;
                    this.ddlCostType.SelectedValue = _objCardInfo.cost_type;
                    this.ddlPurpoe.SelectedValue = _objCardInfo.purpose;
                    this.ddlSubmitType.SelectedValue = _objCardInfo.submit_type;
                    this.ddlDefault_Status.SelectedValue = _objCardInfo.status;
                    this.dtpEffectDate.Value = _objCardInfo.efffect_date;
                    this.dtpEndDate.Value = _objCardInfo.end_date;

                    if (_objCardInfo.cost_type == Bouwa.ITSP2V31.Model.CardInfo.CardTypeInfoCostType.限时卡)
                    {
                        this.lblDefault.Text = "剩余时间：";
                        this.tbxDefault.Text = _objCardInfo.charges_date.ToString();
                        this.lblDefault_Unit.Text = this.lblMax_Unit.Text = "分钟";
                        this.lblMax.Text = "上限时间：";
                        this.tbxMax.Text = _objCardInfo.MaxChargesDate.ToString();
                    }
                    else if (_objCardInfo.cost_type == Bouwa.ITSP2V31.Model.CardInfo.CardTypeInfoCostType.限次卡)
                    {
                        this.lblDefault.Text = "剩余次数：";
                        this.tbxDefault.Text = _objCardInfo.times.ToString();
                        this.lblDefault_Unit.Text = this.lblMax_Unit.Text = "次";
                        this.lblMax.Text = "上限次数：";
                        this.tbxMax.Text = _objCardInfo.MaxTimes.ToString();
                    }
                    else if (_objCardInfo.cost_type == Bouwa.ITSP2V31.Model.CardInfo.CardTypeInfoCostType.限期卡)
                    {
                        this.lblDefault.Text = "到期日期：";
                        this.tbxDefault.Text = _objCardInfo.end_date.ToString("yyyy-MM-dd");
                        this.lblMax.Visible = this.lblMax_Unit.Visible = this.tbxMax.Visible =this.lblDefault_Unit.Visible= false;
                    }
                    else
                    {
                        this.tbxDefault.Text = _objCardInfo.money.ToString();
                        this.tbxMax.Text = _objCardInfo.MaxMoney.ToString();
                    }
                }
            }
        }

        /// <summary>
        /// 充值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChargeValue_Click(object sender, EventArgs e)
        {
            int status = -1; //保存读取后返回的一个状态
            Bouwa.ITSP2V31.Model.CardInfo _cardInfo = _cardBll.GetCardInfoByCard(Bouwa.Helper.CurrentUser.Current.PassWordKey, out status);

            if (_cardInfo==null)
            {
                MessageBoxForm.Show(_cardBll.ConvertMeassByStatus(status), MessageBoxButtons.OK);
                return;
            }
            else if (status != 0)
            {
                MessageBoxForm.Show(_cardBll.ConvertMeassByStatus(status), MessageBoxButtons.OK);
                return;
            }
            else if (string.IsNullOrEmpty(_cardInfo.card_id))
            {
                MessageBoxForm.Show("未读取到卡信息，请将卡放到入读卡器上！", MessageBoxButtons.OK);
                return;
            }
            else if (_objCardInfo.card_id!=null&_cardInfo.card_id.ToString() != _objCardInfo.card_id.ToString())
            {
                MessageBoxForm.Show("卡信息与当前所读卡信息不一致，请更换卡！", MessageBoxButtons.OK);
                return;
            }
            else if (_objCardInfo.status == Bouwa.ITSP2V31.Model.CardInfo.CardTypeInfoDefaultCardStatus.已充值
                || _objCardInfo.status == Bouwa.ITSP2V31.Model.CardInfo.CardTypeInfoDefaultCardStatus.已初始化)
            {
                //测试数据存放
                _cardInfo.id = _objCardInfo.id;
                _cardInfo.saas_id = CurrentUser.Current.SAASID;
                //_cardInfo.no = _objCardInfo.no;
                _cardInfo.Network_id = CurrentUser.Current.NetWorkID;
                //更新人临时存放当前操作人
                _cardInfo.modify_user = CurrentUser.Current.UserId;
                //最大限额
                _cardInfo.MaxCount =string.IsNullOrEmpty(tbxMax.Text)?99999: decimal.Parse(tbxMax.Text);

                BaseForm bf = null; //保存窗口
                //根据扣费类型跳转到对应的充值界面
                if (_cardInfo.cost_type == Bouwa.ITSP2V31.Model.CardInfo.CardTypeInfoCostType.金额卡)
                {
                    bf = new MemoryCard(_cardInfo);
                }
                else if (_cardInfo.cost_type == Bouwa.ITSP2V31.Model.CardInfo.CardTypeInfoCostType.限次卡)
                {
                    bf = new LimitOfTimeCard(_cardInfo);
                }
                else if (_cardInfo.cost_type == Bouwa.ITSP2V31.Model.CardInfo.CardTypeInfoCostType.限期卡)
                {
                    bf = new DeadlineCard(_cardInfo);
                }
                else if (_cardInfo.cost_type == Bouwa.ITSP2V31.Model.CardInfo.CardTypeInfoCostType.限时卡)
                {
                    bf = new TimeCard(_cardInfo);
                }
                else
                {
                    MessageBoxForm.Show("消费类型有误，请联系管理员！", MessageBoxButtons.OK);
                    return;
                }
                //执行跳转
                bf.ShowDialog();

                //刷新窗口数据
                View_Load(sender, e);
            }
            else {
                MessageBoxForm.Show("只能对初始化或已充值状态下的卡进行充值！", MessageBoxButtons.OK);
                return;
            }
            
        }

        /// <summary>
        /// 进行卡重置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            if (MessageBoxForm.Show("您确定要进行卡重置？", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                int status = -1; //保存读取后返回的一个状态
                Bouwa.ITSP2V31.Model.CardInfo _cardInfo = _cardBll.GetCardInfoByCard(Bouwa.Helper.CurrentUser.Current.PassWordKey, out status);
                
                if (_cardInfo == null)
                {
                    MessageBoxForm.Show(_cardBll.ConvertMeassByStatus(status), MessageBoxButtons.OK);
                    return;
                }
                else if (status != 0)
                {
                    MessageBoxForm.Show(_cardBll.ConvertMeassByStatus(status), MessageBoxButtons.OK);
                    return;
                }
                else if (string.IsNullOrEmpty(_cardInfo.card_id))
                {
                    MessageBoxForm.Show("未读取到卡信息，请将卡放到入读卡器上！", MessageBoxButtons.OK);
                    return;
                }
                else if (_objCardInfo.card_id != null & _cardInfo.card_id.ToString() != _objCardInfo.card_id.ToString())
                {
                    MessageBoxForm.Show("卡信息与当前所读卡信息不一致，请更换卡！", MessageBoxButtons.OK);
                    return;
                }
                else if (_objCardInfo.status == Bouwa.ITSP2V31.Model.CardInfo.CardTypeInfoDefaultCardStatus.已充值
                || _objCardInfo.status == Bouwa.ITSP2V31.Model.CardInfo.CardTypeInfoDefaultCardStatus.已初始化
                    || _objCardInfo.status == Bouwa.ITSP2V31.Model.CardInfo.CardTypeInfoDefaultCardStatus.空白卡
                    || _objCardInfo.status == Bouwa.ITSP2V31.Model.CardInfo.CardTypeInfoDefaultCardStatus.已挂失
                    || _objCardInfo.status == Bouwa.ITSP2V31.Model.CardInfo.CardTypeInfoDefaultCardStatus.已禁用
                    || _objCardInfo.status == Bouwa.ITSP2V31.Model.CardInfo.CardTypeInfoDefaultCardStatus.已退卡
                    || _objCardInfo.status == Bouwa.ITSP2V31.Model.CardInfo.CardTypeInfoDefaultCardStatus.已重置
                    || _objCardInfo.status == Bouwa.ITSP2V31.Model.CardInfo.CardTypeInfoDefaultCardStatus.制卡审批
                    )
                {
                    _cardInfo.modify_user = CurrentUser.Current.UserId; //保存更新人
                    int resout = _cardBll.ResetCarInforAndCarHistoryByID(_cardInfo, CurrentUser.Current.PassWordKey);
                    if (resout == 0)
                    {
                        MessageBoxForm.Show("恭喜您卡重置成功！", MessageBoxButtons.OK);
                        //关闭窗口
                        this.Close();
                        return;
                    }
                    else if (resout == 1)
                    {
                        MessageBoxForm.Show("网络连接不正常，请重新进行卡重置！", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBoxForm.Show(_cardBll.ConvertMeassByStatus(resout), MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBoxForm.Show("卡不能识别！", MessageBoxButtons.OK);
                    return;
                }


            }
        }

        /// <summary>
        /// 执行退卡操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, EventArgs e)
        {
            if (MessageBoxForm.Show("您确定要进行退卡？", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                int status = -1; //保存读取后返回的一个状态
                Bouwa.ITSP2V31.Model.CardInfo _cardInfo = _cardBll.GetCardInfoByCard(Bouwa.Helper.CurrentUser.Current.PassWordKey, out status);

                if (_cardInfo == null)
                {
                    MessageBoxForm.Show(_cardBll.ConvertMeassByStatus(status), MessageBoxButtons.OK);
                    return;
                }
                else if (status != 0)
                {
                    MessageBoxForm.Show(_cardBll.ConvertMeassByStatus(status), MessageBoxButtons.OK);
                    return;
                }
                else if (string.IsNullOrEmpty(_cardInfo.card_id))
                {
                    MessageBoxForm.Show("未读取到卡信息，请将卡放到入读卡器上！", MessageBoxButtons.OK);
                    return;
                }
                else if (_objCardInfo.card_id != null & _cardInfo.card_id.ToString() != _objCardInfo.card_id.ToString())
                {
                    MessageBoxForm.Show("卡信息与当前所读卡信息不一致，请更换卡！", MessageBoxButtons.OK);
                    return;
                }
                else if (_objCardInfo.status == Bouwa.ITSP2V31.Model.CardInfo.CardTypeInfoDefaultCardStatus.已充值)
                {
                    //测试数据存放
                    _cardInfo.id = _objCardInfo.id;
                    _cardInfo.saas_id = CurrentUser.Current.SAASID;
                    _cardInfo.Network_id = CurrentUser.Current.NetWorkID;
                    //更新人临时存放当前操作人
                    _cardInfo.modify_user = CurrentUser.Current.UserId;
                    //备份当前状态
                    Bouwa.ITSP2V31.Model.CardInfo.CardTypeInfoDefaultCardStatus backStatus= _cardInfo.status;
                    //更改状态为退卡
                    _cardInfo.status= Bouwa.ITSP2V31.Model.CardInfo.CardTypeInfoDefaultCardStatus.已退卡;

                    //根据扣费类型获取对应的量
                    if (_cardInfo.cost_type == Bouwa.ITSP2V31.Model.CardInfo.CardTypeInfoCostType.金额卡
                    ||_cardInfo.cost_type == Bouwa.ITSP2V31.Model.CardInfo.CardTypeInfoCostType.限次卡
                    ||_cardInfo.cost_type == Bouwa.ITSP2V31.Model.CardInfo.CardTypeInfoCostType.限期卡
                    ||_cardInfo.cost_type == Bouwa.ITSP2V31.Model.CardInfo.CardTypeInfoCostType.限时卡)
                    {
                        //执行退卡操作
                        int resout = _cardBll.UpdateCarInfoAndBackCardHistoryRecord(_cardInfo, CurrentUser.Current.PassWordKey,true);
                        if (resout == 0)
                        {
                            MessageBoxForm.Show("恭喜您退卡成功！", MessageBoxButtons.OK);
                            //关闭窗口
                            this.Close();
                            return;
                        }
                        else if (resout == 1)
                        {
                            MessageBoxForm.Show("网络连接不正常，请重新进行退卡操作！", MessageBoxButtons.OK);
                        }
                        else
                        {
                            MessageBoxForm.Show(_cardBll.ConvertMeassByStatus(resout), MessageBoxButtons.OK);
                        }
                        //更改到之前的状态
                        _cardInfo.status = backStatus;
                        //退卡失败后进行回写
                        _cardBll.UpdateCarInfoAndBackCardHistoryRecord(_cardInfo, CurrentUser.Current.PassWordKey, false);

                    }
                    else
                    {
                        MessageBoxForm.Show("消费类型有误，请联系管理员！", MessageBoxButtons.OK);
                        return;
                    }
                }
                else if (_objCardInfo.status == Bouwa.ITSP2V31.Model.CardInfo.CardTypeInfoDefaultCardStatus.已退卡)
                {
                    MessageBoxForm.Show("已是退卡状态，不能进行退卡操作！", MessageBoxButtons.OK);
                }
                else if (_objCardInfo.status == Bouwa.ITSP2V31.Model.CardInfo.CardTypeInfoDefaultCardStatus.已初始化
                    || _objCardInfo.status == Bouwa.ITSP2V31.Model.CardInfo.CardTypeInfoDefaultCardStatus.空白卡
                    || _objCardInfo.status == Bouwa.ITSP2V31.Model.CardInfo.CardTypeInfoDefaultCardStatus.已挂失
                    || _objCardInfo.status == Bouwa.ITSP2V31.Model.CardInfo.CardTypeInfoDefaultCardStatus.已禁用
                    || _objCardInfo.status == Bouwa.ITSP2V31.Model.CardInfo.CardTypeInfoDefaultCardStatus.已重置
                    || _objCardInfo.status == Bouwa.ITSP2V31.Model.CardInfo.CardTypeInfoDefaultCardStatus.制卡审批
                    )
                {
                    MessageBoxForm.Show("已充值状态下才能进行退卡操作！", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBoxForm.Show("卡不能识别！", MessageBoxButtons.OK);
                    return;
                }


            }
        }

        /// <summary>
        /// 申请换卡 跟换卡操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChangeCard_Click(object sender, EventArgs e)
        {
            try
            {
                    //询问用户
                    if (MessageBoxForm.Show("您确定要进行" + btnChangeCard.Text + "？", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        Bouwa.ITSP2V31.Model.CardInfo _cardInfo = new Bouwa.ITSP2V31.Model.CardInfo();
                        //执行对象复制
                        ObjectMapper.CopyProperties(_objCardInfo, _cardInfo);

                        //说明是申请换卡
                        if (btnChangeCard.Tag.ToString() == "0")
                        {
                            //只有在已充值的状态下才能申请换卡
                            if (_objCardInfo.status == Bouwa.ITSP2V31.Model.CardInfo.CardTypeInfoDefaultCardStatus.已充值)
                            {
                                //测试数据存放
                                _cardInfo.saas_id = CurrentUser.Current.SAASID;
                                _cardInfo.Network_id = CurrentUser.Current.NetWorkID;
                                //更新人临时存放当前操作人
                                _cardInfo.modify_user = CurrentUser.Current.UserId;
                                //更改状态为退卡
                                _cardInfo.status= Bouwa.ITSP2V31.Model.CardInfo.CardTypeInfoDefaultCardStatus.已挂失;

                                //执行退卡操作
                                int resout = _cardBll.UpdateCarInfoAndApplyChangeCardHistoryRecord(_cardInfo, CurrentUser.Current.PassWordKey, true);
                                if (resout == 0)
                                {
                                    MessageBoxForm.Show("恭喜您" + btnChangeCard.Text + "成功！", MessageBoxButtons.OK);
                                    //关闭窗口
                                    this.Close();
                                    return;
                                }
                                else if (resout == 1)
                                {
                                    MessageBoxForm.Show("网络连接不正常，请重新进行" + btnChangeCard.Text + "操作！", MessageBoxButtons.OK);
                                }
                                else
                                {
                                    MessageBoxForm.Show(_cardBll.ConvertMeassByStatus(resout), MessageBoxButtons.OK);
                                }

                            }
                            else
                            {
                                MessageBoxForm.Show("已充值状态下才能进行" + btnChangeCard.Text + "操作！", MessageBoxButtons.OK);
                            }
                        }//说明是执行换卡操作
                        else
                        {
                            //执行换卡操作
                            Bouwa.ITSP2V31.Win.CardType.ChangeCardInit _cardInit = new Bouwa.ITSP2V31.Win.CardType.ChangeCardInit(_cardInfo);
                            this.Parameter["ActionType"] = "Init";
                            _cardInit.ShowDialog();
                            this.Close();
                            //换卡结束
                        }

                    }
                
            }
            catch (Exception ex)
            {
                Log.WriterLine(ELevel.error, "执行" + btnChangeCard.Text+"操作出现异常",ex.Message);
                MessageBoxForm.Show("执行" + btnChangeCard.Text + "操作出现异常，请稍后再试！", MessageBoxButtons.OK);
            }
        }


    }
}
