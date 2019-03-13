using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapWinGis_Demo_zhw.Manager
{
    /// <summary>
    /// 消息弹出
    /// </summary>
    public static class MessageHelper
    {
        public static string APP_NAME = "MapWinGis";

        public static void Info(string msg)
        {
            MessageBox.Show(msg, APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult Ask(string msg)
        {
            return MessageBox.Show(msg, APP_NAME, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public static DialogResult AskWarning(string msg)
        {
            return MessageBox.Show(msg, APP_NAME, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }

        public static DialogResult AskCritical(string msg)
        {
            return MessageBox.Show(msg, APP_NAME, MessageBoxButtons.YesNo, MessageBoxIcon.Error);
        }

        public static DialogResult AskYesNoCancel(string msg)
        {
            return MessageBox.Show(msg, APP_NAME, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        }

        public static void Warn(string msg)
        {
            MessageBox.Show(msg, APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
