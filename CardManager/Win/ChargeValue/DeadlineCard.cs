using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bouwa.Helper;

namespace Bouwa.ITSP2V31.Win.ChargeValue
{
    public partial class DeadlineCard : BaseForm
    {
        private Bouwa.ITSP2V31.Model.CardInfo _cardInfo;//保存卡所有信息

        public DeadlineCard(Bouwa.ITSP2V31.Model.CardInfo CardInfo)
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
        private void DeadlineCard_Load(object sender, EventArgs e)
        {
            try
            {
                //执行数据加载
                lblTextValue.Text = _cardInfo.end_date.ToString("yyyy-MM-dd");
                txtValue.Text = _cardInfo.end_date.ToString("yyyy-MM-dd"); //默认是到期时间
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
                DateTime oldTime = _cardInfo.end_date;//保留一份原始数据
                //询问用户
                if (MessageBoxForm.Show("您确定要进行时间更改？", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    DateTime addValue = DateTime.Now.AddDays(-1); //默认是昨天
                    try
                    {
                        //获取值
                        addValue = DateTime.Parse(txtValue.Text);
                        if (DateTime.Compare(DateTime.Now, addValue) >= 0)
                        {
                            MessageBoxForm.Show("到期日期必须要大于当天！", MessageBoxButtons.OK);
                            return;
                        }
                        if (addValue.Year >= 2100 || addValue.Year <= 2000)
                        {
                            MessageBoxForm.Show("只能在21世纪以内，请重新选择日期！", MessageBoxButtons.OK);
                            return;
                        }
                        //执行数据更改
                        _cardInfo.end_date = addValue;
                    }
                    catch (Exception ex2)
                    {
                        MessageBoxForm.Show("选择的日期不正确，请重新输入！", MessageBoxButtons.OK);
                        Bouwa.Helper.Class.Log.WriterLine(Bouwa.Helper.Class.ELevel.error, this.Text + "时进行值转换时出现异常！", ex2.Message);
                        return;
                    }

                    Bouwa.ITSP2V31.BLL.CardInfoBLL _cardInfoBll = new Bouwa.ITSP2V31.BLL.CardInfoBLL();
                    int resout = _cardInfoBll.Update(_cardInfo, CurrentUser.Current.PassWordKey, addValue.ToString(),true);
                    if (resout == 0)
                    {
                        DeadlineCard_Load(sender, e);//刷新窗口
                        MessageBoxForm.Show("恭喜您更新时间成功！请确认卡上到期时间！", MessageBoxButtons.OK);
                        //关闭窗口
                        this.Close();
                        return;
                    }
                    //执行数据还原
                    _cardInfo.end_date = oldTime;
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
                MessageBoxForm.Show("更新时间失败！", MessageBoxButtons.OK);
                Bouwa.Helper.Class.Log.WriterLine(Bouwa.Helper.Class.ELevel.error, this.Text + "时进行充值时出现异常！", ex.Message);
            }
        }

    }
}
