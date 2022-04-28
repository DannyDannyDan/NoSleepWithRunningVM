using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuestKeyHooker.Helpers
{
    internal static class SystemTrayHelper
    {
        internal static ContextMenuStrip GetContextMenu()
        {
            ContextMenuStrip contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add("&Exit", null, Exit_Click);
            return contextMenu;
        }

        private static void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
