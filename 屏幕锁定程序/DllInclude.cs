using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace 屏幕锁定程序
{
    public class DllInclude
    {
        [DllImport("KeyboardHookDLL.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DeleteHook();

        [DllImport("KeyboardHookDLL.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetHook(long dwThreadID);
    }
}
