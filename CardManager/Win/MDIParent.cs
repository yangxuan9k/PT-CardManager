using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bouwa.ITSP2V31.WIN;
using Bouwa.Helper;
using System.Reflection;
using Bouwa.ITSP2V31.Win;

using Bouwa.Helper;
using Bouwa.ITSP2V31.BLL;
using Bouwa.ITSP2V31.Model;

namespace Bouwa.ITSP2V31.WIN
{
    public partial class MDIParent : Bouwa.Helper.BaseForm
    {
        private int childFormNumber = 0;
        LoginBLL _objLoginBLL = new LoginBLL();

        public MDIParent()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "窗口 " + childFormNumber++;
            childForm.Show();
        }

        //private void OpenFile(object sender, EventArgs e)
        //{
        //    OpenFileDialog openFileDialog = new OpenFileDialog();
        //    openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        //    openFileDialog.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
        //    if (openFileDialog.ShowDialog(this) == DialogResult.OK)
        //    {
        //        string FileName = openFileDialog.FileName;
        //    }
        //}

        //private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    SaveFileDialog saveFileDialog = new SaveFileDialog();
        //    saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        //    saveFileDialog.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
        //    if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
        //    {
        //        string FileName = saveFileDialog.FileName;
        //    }
        //}

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

       

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void ShowCardTypeForm(object sender, EventArgs e)
        {
            Bouwa.ITSP2V31.WIN.CardType.CardTypeList childForm = new Bouwa.ITSP2V31.WIN.CardType.CardTypeList();
            
            childForm.MdiParent = this;
            childForm.Text = "窗口 " + childFormNumber++;
            //childForm.MaximizeBox = false;
            childForm.WindowState = FormWindowState.Maximized;
            childForm.StartPosition = FormStartPosition.CenterScreen;           
         
            childForm.Show();
           
        }

        private void toolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void MDIParent_Load(object sender, EventArgs e)
        {
            SystemMessageInfo objSystemMessageInfo = null;
            this.tsmlCardInfo.Visible = _objLoginBLL.IsRightByUserIdRightInfoListRightCode("Winform.Card.Info", null, ref objSystemMessageInfo);
            this.tsmlCardType.Visible = _objLoginBLL.IsRightByUserIdRightInfoListRightCode("Winform.Card.Type", null, ref objSystemMessageInfo);
        }

        /// <summary>
        /// 注销
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmlExit_Click(object sender, EventArgs e)
        {
            if (MessageBoxForm.Show("确认注销？", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Close();
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// 窗体关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MDIParent_FormClosing(object sender, FormClosingEventArgs e)
        {
            CurrentUser.Current.LoginForm.Show();
            CurrentUser.Current.LoginForm = null;
            CurrentUser.Current.UserCode = CurrentUser.Current.UserName = CurrentUser.Current.PassWord = string.Empty;
            CurrentUser.Current.UserId = Guid.Empty;            
        }

        /// <summary>
        /// 卡信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmlCardInfo_Click(object sender, EventArgs e)
        {
            Bouwa.ITSP2V31.WIN.CardInfo.List childForm = new Bouwa.ITSP2V31.WIN.CardInfo.List();
            
            childForm.MdiParent = this;
            childForm.Text = "窗口 " + childFormNumber++;
            //childForm.MaximizeBox = false;
            childForm.WindowState = FormWindowState.Maximized;
            childForm.StartPosition = FormStartPosition.CenterScreen;

            childForm.Show();
        }
        /// <summary>
        /// 关于
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
          string a=  Assembly.GetExecutingAssembly().GetName().Version.ToString();
           AboutITSP2 about = new AboutITSP2();
           about.ShowDialog();
        }

        private void tsmlTest_Click(object sender, EventArgs e)
        {
            //Bouwa.ITSP2V31.Win.Test childForm = new Bouwa.ITSP2V31.Win.Test();

            //childForm.MdiParent = this;
            //childForm.Text = "窗口 " + childFormNumber++;
            ////childForm.MaximizeBox = false;
            //childForm.WindowState = FormWindowState.Maximized;
            //childForm.StartPosition = FormStartPosition.CenterScreen;

            //childForm.Show();
        }

    }
}
