﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bouwa.Helper;

namespace Bouwa.ITSP2V31.Win.ChargeValue
{
    public partial class TimeCard : BaseForm
    {
        private Bouwa.ITSP2V31.Model.CardInfo _cardInfo;//保存卡所有信息

        public TimeCard(Bouwa.ITSP2V31.Model.CardInfo CardInfo)
        {
            InitializeComponent();
            this._cardInfo = CardInfo;
        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimeCard_Load(object sender, EventArgs e)
        {
            try
            {
                //执行数据加载
                lblTextValue.Text = _cardInfo.charges_date.ToString() + "分钟";
                txtValue.Text = "0"; //默认是0分钟
            }
            catch (Exception ex)
            {
                MessageBoxForm.Show("卡已损坏，请联系管理员！", MessageBoxButtons.OK);
                Bouwa.Helper.Class.Log.WriterLine(Bouwa.Helper.Class.ELevel.error, this.Text + "时初始化失败！", ex.Message);
            }
        }

        /// <summary>
        /// 执行充值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //询问用户
                if (MessageBoxForm.Show("您确定要进行充值？", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    int addValue = 0;
                    try
                    {
                        //获取值
                        addValue = Convert.ToInt32(txtValue.Text);
                        //if (addValue<=0)
                        //{
                        //    MessageBoxForm.Show("输入的分钟数必须要大于0！","系统提示");
                        //    return;
                        //}
                        //else 
                        if ((_cardInfo.charges_date + addValue) >= _cardInfo.MaxCount)
                        {
                            MessageBoxForm.Show("剩余时间必须小于上限时间！", MessageBoxButtons.OK);
                            return;
                        }
                        else if ((_cardInfo.charges_date + addValue) >= 599999)
                        {
                            MessageBoxForm.Show("剩余时间必须小于599999分钟！", MessageBoxButtons.OK);
                            return;
                        }
                        else if ((_cardInfo.charges_date + addValue) <= 0)
                        {
                            MessageBoxForm.Show("剩余时间必须大于0分钟！", MessageBoxButtons.OK);
                            return;
                        }
                        
                        //执行数据更改
                        _cardInfo.charges_date = _cardInfo.charges_date + addValue;
                    }
                    catch (Exception ex2)
                    {
                        MessageBoxForm.Show("输入的数值不对，请重新输入！", MessageBoxButtons.OK);
                        Bouwa.Helper.Class.Log.WriterLine(Bouwa.Helper.Class.ELevel.error, this.Text + "时进行值转换时出现异常！", ex2.Message);
                        return;
                    }

                    Bouwa.ITSP2V31.BLL.CardInfoBLL _cardInfoBll = new Bouwa.ITSP2V31.BLL.CardInfoBLL();
                    int resout = _cardInfoBll.Update(_cardInfo, CurrentUser.Current.PassWordKey, addValue.ToString(),true);
                    if (resout == 0)
                    {
                        TimeCard_Load(sender, e);//刷新窗口
                        MessageBoxForm.Show("恭喜您充值成功！请确认卡上剩余分钟数！", MessageBoxButtons.OK);
                        //关闭窗口
                        this.Close();
                        return;
                    }
                    //执行数据还原
                    _cardInfo.charges_date = _cardInfo.charges_date - addValue;
                    //执行还原操作
                    _cardInfoBll.Update(_cardInfo, CurrentUser.Current.PassWordKey, addValue.ToString(), false);
                    if (resout == 1)
                    {
                        MessageBoxForm.Show("网络连接不正常，请重新进行充值！", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBoxForm.Show(_cardInfoBll.ConvertMeassByStatus(resout), MessageBoxButtons.OK);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBoxForm.Show("充值失败！", MessageBoxButtons.OK);
                Bouwa.Helper.Class.Log.WriterLine(Bouwa.Helper.Class.ELevel.error, this.Text + "时进行充值时出现异常！", ex.Message);
            }
        }


    }
}
