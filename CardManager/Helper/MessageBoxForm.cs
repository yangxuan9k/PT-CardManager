using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Bouwa.Helper
{
    public class MessageBoxForm
    {
        public static DialogResult Show(SystemMessageInfo theSystemMessageInfo, MessageBoxButtons theMessageBoxButtons)
        {
           return MessageBox.Show(theSystemMessageInfo.Content + "\n" + theSystemMessageInfo.Exception, "提示信息", theMessageBoxButtons, MessageBoxIcon.Information);
        }

        public static DialogResult Show(string theSystemMessageInfo, MessageBoxButtons theMessageBoxButtons)
        {
            return MessageBox.Show(theSystemMessageInfo + "\n" , "提示信息", theMessageBoxButtons, MessageBoxIcon.Information);
        }

    }
}
