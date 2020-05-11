using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Nimble.Controls
{
  public static class ControlUtils
  {
    public static string BackspaceWordsStopAt = "`~!@#$%^&*()-_=+[{]}\\|;:'\",<.>/?";

    public static void ImplementWordBackspacing(dynamic ctl)
    {
      // Implement word backspacing (Ctrl + Backspace)
      ctl.KeyDown += new KeyEventHandler((o, ee) => {
        if (ee.Modifiers == Keys.Control && ee.KeyCode == Keys.Back) {
          ee.SuppressKeyPress = true;
          if (ctl.SelectionLength > 0) {
            ctl.Text = ctl.Text.Remove(ctl.SelectionStart, ctl.SelectionLength);
            ctl.SelectionLength = 0;
          }
          bool bStartSearch = false;
          int i = ctl.SelectionStart - 1;
          for (; i >= 0; i--) {
            char c = ctl.Text[i];
            if (!bStartSearch) {
              if (char.IsWhiteSpace(c)) {
                continue;
              }
              if (BackspaceWordsStopAt.IndexOf(c) != -1) {
                break;
              }
              bStartSearch = true;
            } else {
              if (char.IsWhiteSpace(c) || BackspaceWordsStopAt.IndexOf(c) != -1) {
                break;
              }
            }
          }
          i = (i < 0 ? 0 : i);
          ctl.Text = ctl.Text.Substring(0, i);
          ctl.SelectionStart = i;
        }
      });
    }
  }
}
