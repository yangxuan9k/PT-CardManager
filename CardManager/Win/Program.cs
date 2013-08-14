using System;
using System.Collections.Generic;
using System.Windows.Forms;
//WinFormUI
namespace Bouwa.ITSP2V31.WIN
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());


        

            //Application.Run(new Bouwa.ITSP2V31.WIN.CardType.CardTypeList());
            //Application.Run(new Bouwa.ITSP2V31.Win.ChargeValue.MainForm());
        }
    }
}
