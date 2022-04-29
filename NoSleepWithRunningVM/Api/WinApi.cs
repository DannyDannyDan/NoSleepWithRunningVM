using System;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Win32;

namespace NoSleepWithRunningVM.Api
{
    public static class WinApi
    {
        [DllImport("kernel32")]
        internal static extern void Sleep(int dwMilliseconds);

        public const short SW_SHOWMINIMIZED = 2;
        public const short SW_SHOWNORMAL = 1;

        public struct POINTAPI
        {
            public int x;
            public int y;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern bool IsWindow(IntPtr hWnd);
        [DllImport("user32", EntryPoint = "FindWindowA")]
        public static extern int FindWindow(string lpClassName, string lpWindowName);

        // UPGRADE_WARNING: Structure WINDOWPLACEMENT may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
        [DllImport("user32")]
        public static extern int SetWindowPlacement(int hwnd, ref WINDOWPLACEMENT lpwndpl);
        [DllImport("user32")]
        public static extern int SetForegroundWindow(int hwnd);

        // UPGRADE_WARNING: Structure WINDOWPLACEMENT may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
        [DllImport("user32")]
        public static extern int GetWindowPlacement(int hwnd, ref WINDOWPLACEMENT lpwndpl);
        [DllImport("user32")]
        private static extern int SetWindowPos(int hwnd, int hWndInsertAfter, int X, int Y, int cx, int cy, int wFlags);

        private const short SWP_NOMOVE = 2;
        private const short SWP_NOSIZE = 1;
        private const bool SWP_WNDFLAGS = true;
        private const short HWND_TOPMOST = -1;
        private const short HWND_NOTOPMOST = -2;

        [DllImport("user32", EntryPoint = "SendMessageA")]
        public static extern int SendMessage(int hwnd, int wMsg, int wParam, ref int lParam);
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, [MarshalAs(UnmanagedType.I4)] ShowWindowCommands nCmdShow);

        public static bool SetWindowState(int hWnd, ShowWindowCommands showCommand)
        {
            return ShowWindow(new IntPtr(hWnd), showCommand);
        }

        public const short INVALID_HANDLE_VALUE = -1;
        public const short MAX_PATH = 260;

        public struct FILETIME
        {
            public int dwLowDateTime;
            public int dwHighDateTime;
        }

        public struct WIN32_FIND_DATA
        {
            public int dwFileAttributes;
            public FILETIME ftCreationTime;
            public FILETIME ftLastAccessTime;
            public FILETIME ftLastWriteTime;
            public int nFileSizeHigh;
            public int nFileSizeLow;
            public int dwReserved0;
            public int dwReserved1;
            // UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
            [VBFixedString(MAX_PATH)]
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_PATH)]
            public char[] cFileName;
            // UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
            [VBFixedString(14)]
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 14)]
            public char[] cAlternate;
        }

        // UPGRADE_WARNING: Structure WIN32_FIND_DATA may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
        [DllImport("Kernel32", EntryPoint = "FindFirstFileA")]
        static extern int FindFirstFile(string lpFileName, ref WIN32_FIND_DATA lpFindFileData);
        [DllImport("Kernel32")]
        static extern int FindClose(int hFindFile);
        [DllImport("Kernel32", EntryPoint = "CopyFileA")]
        static extern int CopyFile(string lpExistingFileName, string lpNewFileName, int bFailIfExists);

        // Public Const SWP_NOMOVE As Short = 2
        // Public Const SWP_NOSIZE As Short = 1
        public const bool flags = true;

        public struct RECT
        {
            // UPGRADE_NOTE: Left was upgraded to Left_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
            public int Left_Renamed;
            public int Top;
            // UPGRADE_NOTE: Right was upgraded to Right_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
            public int Right_Renamed;
            public int Bottom;
        }

        public struct WINDOWPLACEMENT
        {
            public int Length;
            public int flags;
            public int ShowCmd;
            public POINTAPI ptMinPosition;
            public POINTAPI ptMaxPosition;
            public RECT rcNormalPosition;
        }

        public enum ShowWindowCommands
        {
            SW_HIDE = 0,
            SW_SHOWNORMAL = 1,
            SW_NORMAL = 1,
            SW_SHOWMINIMIZED = 2,
            SW_SHOWMAXIMIZED = 3,
            SW_MAXIMIZE = 3,
            SW_SHOWNOACTIVATE = 4,
            SW_SHOW = 5,
            SW_MINIMIZE = 6,
            SW_SHOWMINNOACTIVE = 7,
            SW_SHOWNA = 8,
            SW_RESTORE = 9,
            SW_SHOWDEFAULT = 10,
            SW_FORCEMINIMIZE = 11,
            SW_MAX = 11
        }

        public struct VS_FIXEDFILEINFO
        {
            public short dwProductVersionMSl; // e.g. = &h0003 = 3
            public short dwProductVersionMSh; // e.g. = &h0010 = .1
            public short dwProductVersionLSl; // e.g. = &h0000 = 0
        }

        public static int SetTopMostWindow(ref int hwnd, ref bool Topmost)
        {
            if (Topmost == true) // Make the window topmost
            {
                return SetWindowPos(hwnd, HWND_TOPMOST, 0, 0, 0, 0, Conversions.ToInteger(flags));
            }
            else
            {
                return SetWindowPos(hwnd, HWND_NOTOPMOST, 0, 0, 0, 0, Conversions.ToInteger(flags));
            }
        }


    }
}