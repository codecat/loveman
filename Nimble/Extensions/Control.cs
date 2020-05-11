using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Nimble.Extensions
{
  public static class ControlExtensions
  {
    public static void SuspendDrawing(this Control obj)
    {
      if (!obj.IsHandleCreated) {
        return;
      }
      NativeMethods.SendMessage(obj.Handle, NativeMethods.WM_SETREDRAW, false, 0);
    }

    public static void ResumeDrawing(this Control obj)
    {
      if (!obj.IsHandleCreated) {
        return;
      }
      NativeMethods.SendMessage(obj.Handle, NativeMethods.WM_SETREDRAW, true, 0);
      obj.Refresh();
    }
  }
}
