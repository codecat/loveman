using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;

namespace Nimble
{
  public static class NativeMethods
  {
    [DllImport("kernel32.dll")]
    public static extern uint GetLastError();

    [DllImport("user32.dll")]
    public static extern IntPtr WindowFromPoint(Point pt);

    [DllImport("user32.dll")]
    public static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
    [DllImport("user32.dll")]
    public static extern IntPtr SendMessage(IntPtr hWnd, int msg, bool wParam, int lp);

    [DllImport("user32.dll")]
    public static extern short GetAsyncKeyState(System.Windows.Forms.Keys vKey);

    [DllImport("user32.dll")]
    public static extern IntPtr GetWindowDC(IntPtr hWnd);

    [DllImport("user32.dll")]
    public static extern IntPtr GetDCEx(IntPtr hWnd, IntPtr hrgnClip, DeviceContextValues flags);

    [DllImport("user32.dll")]
    public static extern bool ReleaseDC(IntPtr hWnd, IntPtr hDC);

    [DllImport("user32.dll")]
    public static extern bool RedrawWindow(IntPtr hWnd, IntPtr lprcUpdate, IntPtr hrgnUpdate, RedrawWindowFlags flags);

    [Flags()]
    public enum DeviceContextValues : uint
    {
      Window = 0x00000001,
      Cache = 0x00000002,
      NoResetAttrs = 0x00000004,
      ClipChildren = 0x00000008,
      ClipSiblings = 0x00000010,
      ParentClip = 0x00000020,
      ExcludeRgn = 0x00000040,
      IntersectRgn = 0x00000080,
      ExcludeUpdate = 0x00000100,
      IntersectUpdate = 0x00000200,
      LockWindowUpdate = 0x00000400,
      UseStyle = 0x00010000,
      Validate = 0x00200000,
    }

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

    [DllImport("wininet.dll", SetLastError = true)]
    public static extern bool InternetGetCookieEx(
      string url,
      string cookieName,
      StringBuilder cookieData,
      ref int size,
      Int32 dwFlags,
      IntPtr lpReserved);

    public const Int32 InternetCookieHttponly = 0x2000;
  }
}
