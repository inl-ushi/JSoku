using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JSoku
{
    class Msg
    {
        public static void Alert(string message)
        {
            MessageBox.Show(message, Properties.Settings.Default.SYS_AppName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        public static void ShowError(string message)
        {
            MessageBox.Show("内部エラーが発生しました。" + Environment.NewLine + message, Properties.Settings.Default.SYS_AppName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        public static void Info(string message)
        {
            MessageBox.Show(message, Properties.Settings.Default.SYS_AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
