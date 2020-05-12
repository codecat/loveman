using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Forms;

namespace Nimble
{
  public static class NativeMethods
  {
    [DllImport("user32.dll")]
    public static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
    [DllImport("user32.dll")]
    public static extern IntPtr SendMessage(IntPtr hWnd, int msg, bool wParam, int lp);

    [DllImport("user32.dll")]
    public static extern IntPtr GetWindowDC(IntPtr hWnd);

    [DllImport("user32.dll")]
    public static extern bool ReleaseDC(IntPtr hWnd, IntPtr hDC);

    [DllImport("user32.dll")]
    public static extern bool RedrawWindow(IntPtr hWnd, IntPtr lprcUpdate, IntPtr hrgnUpdate, RedrawWindowFlags flags);

    [Flags()]
    public enum RedrawWindowFlags : uint
    {
      Invalidate = 0X1,
      InternalPaint = 0X2,
      Erase = 0X4,
      Validate = 0X8,
      NoInternalPaint = 0X10,
      NoErase = 0X20,
      NoChildren = 0X40,
      AllChildren = 0X80,
      UpdateNow = 0X100,
      EraseNow = 0X200,
      Frame = 0X400,
      NoFrame = 0X800
    }

    public const int
      WM_SETREDRAW = 0x000B,
      WM_PAINT = 0x000F,
      WM_NCPAINT = 0x0085,
      WM_MOUSEWHEEL = 0x020A,
      WM_KEYDOWN = 0x0100,
      WM_KEYUP = 0x0101,
      WM_CHAR = 0x0102;

    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool FlashWindowEx(ref FLASHWINFO pwfi);

    public const UInt32 FLASHW_STOP = 0x0;
    public const UInt32 FLASHW_TRAY = 0x2;
    public const UInt32 FLASHW_TIMERNOFG = 0xC;

    [StructLayout(LayoutKind.Sequential)]
    public struct FLASHWINFO
    {
      public UInt32 cbSize;
      public IntPtr hwnd;
      public UInt32 dwFlags;
      public UInt32 uCount;
      public UInt32 dwTimeout;
    }

    public static void FlashWindow(Form form)
    {
      var info = new FLASHWINFO();
      info.cbSize = (uint)Marshal.SizeOf(info);
      info.hwnd = form.Handle;
      info.dwFlags = FLASHW_TIMERNOFG | FLASHW_TRAY;
      info.uCount = 5;
      info.dwTimeout = 0;
      FlashWindowEx(ref info);
    }

    public static void FlashWindowStop(Form form)
    {
      var info = new FLASHWINFO();
      info.cbSize = (uint)Marshal.SizeOf(info);
      info.hwnd = form.Handle;
      info.dwFlags = FLASHW_STOP;
      info.uCount = 5;
      info.dwTimeout = 0;
      FlashWindowEx(ref info);
    }
  }
}
