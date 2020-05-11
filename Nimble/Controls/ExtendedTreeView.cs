using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Nimble.Controls
{
  public partial class ExtendedTreeView : TreeView
  {
    private bool _horizontalScrollbar = true;
    [Category("Appearance")]
    [Description("Whether to enable a horizontal scrollbar")]
    public bool HorizontalScrollbar
    {
      get { return _horizontalScrollbar; }
      set
      {
        _horizontalScrollbar = value;
        if (DesignMode) {
          RecreateHandle();
        } else {
          Invalidate();
        }
      }
    }

    protected override CreateParams CreateParams
    {
      get
      {
        CreateParams ret = base.CreateParams;
        if (!_horizontalScrollbar) {
          ret.Style |= 0x8000; // TVS_NOHSCROLL
        }
        return ret;
      }
    }
  }
}
