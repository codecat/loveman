using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Nimble.Controls.FlatControls
{
  public class FlatListItem
  {
    public string Text = "";
    public string SubText = "";
    public Image Image = null;

    public bool ShowProgress = false;
    public float Progress = 0;

    public Font Font = null;
    public Font FontSub = null;

    public Color BackColor = Color.Empty;
    public Color ForeColor = Color.Empty;
    public Color ForeColorSub = Color.Empty;

    public event EventHandler OnSelected;

    public object Tag = null;

    public bool Checked = false;

    public FlatListItemList SubItems;

    internal void CallOnSelected(object sender, EventArgs e)
    {
      if (OnSelected != null) {
        OnSelected(sender, e);
      }
    }
  }

  public delegate void FlatListItemClickedEventHandler(object sender, FlatListItemClickedEventArgs e);

  public class FlatListItemClickedEventArgs : EventArgs
  {
    public FlatListItem Item = null;

    public MouseButtons MouseButton = MouseButtons.None;
    public Point MouseLocation = Point.Empty;
  }
}
