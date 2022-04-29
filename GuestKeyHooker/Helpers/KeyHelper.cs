using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GuestKeyHooker.Helpers
{
    internal static class KeyHelper
    {
        public const int KEYEVENTF_EXTENTEDKEY = 1;
        public const int KEYEVENTF_KEYUP = 2;
        public const int VK_MEDIA_NEXT_TRACK = 0xB0;
        public const int VK_MEDIA_PLAY_PAUSE = 0xB3;
        public const int VK_MEDIA_PREV_TRACK = 0xB1;
        public const int VK_CONTROL = 0x11;
        public const int VK_SEPARATOR = 0x6C;
        public const int VK_MENU = 0x12;


        [DllImport("user32.dll")]
        public static extern void keybd_event(byte virtualKey, byte scanCode, uint flags, IntPtr extraInfo);

        public static void RelaseVmwareControl()
        {
            // Simulating a Ctrl+Alt keystrokes
            keybd_event(VK_CONTROL, 0x9d, 0, IntPtr.Zero); //Alt Press
            keybd_event(VK_MENU, 0xb8, 0, IntPtr.Zero); // Tab Press
            keybd_event(VK_MENU, 0xb8, KEYEVENTF_KEYUP, IntPtr.Zero); // Tab Release
            keybd_event(VK_CONTROL, 0x9d, KEYEVENTF_KEYUP, IntPtr.Zero); // Alt Release
        }
    }
}
