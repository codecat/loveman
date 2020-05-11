using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Nimble.Extensions;

namespace Nimble.Controls.FlatControls
{
  [DefaultEvent("SelectedItemClicked")]
  public class FlatList : ScrollableControl
  {
    private bool _DrawSuspended = false;

    public void SuspendDraw()
    {
      _DrawSuspended = true;
      this.SuspendDrawing();
    }

    public void ResumeDraw()
    {
      _DrawSuspended = false;
      this.ResumeDrawing();
      UpdateScrollbars();
    }

    private Color _BorderColor = Color.Black;
    [Description("Color of the border")]
    [Category("Appearance")]
    public Color BorderColor
    {
      get { return _BorderColor; }
      set { _BorderColor = value; Invalidate(); }
    }

    private Color _ForeColorSub = Color.Gray;
    [Description("Foreground color of item subtexts")]
    [Category("Appearance")]
    public Color ForeColorSub
    {
      get { return _ForeColorSub; }
      set { _ForeColorSub = value; Invalidate(); }
    }

    private Font _FontSub = SystemFonts.DefaultFont;
    [Description("Font of item subtexts")]
    [Category("Appearance")]
    public Font FontSub
    {
      get { return _FontSub; }
      set { _FontSub = value; Invalidate(); }
    }

    private int _ItemHeight = 16;
    [Description("Height of an individual item")]
    [Category("Appearance")]
    public int ItemHeight
    {
      get { return _ItemHeight; }
      set { _ItemHeight = value; Invalidate(); }
    }

    private int _PaddingX = 4;
    [Description("Item X padding")]
    [Category("Appearance")]
    public int ItemPaddingX
    {
      get { return _PaddingX; }
      set { _PaddingX = value; Invalidate(); }
    }

    private int _PaddingY = 2;
    [Description("Item Y padding")]
    [Category("Appearance")]
    public int ItemPaddingY
    {
      get { return _PaddingY; }
      set { _PaddingY = value; Invalidate(); }
    }

    private int _ItemImageSize = 16;
    [Description("The size of the image in list items")]
    [Category("Appearance")]
    public int ItemImageSize
    {
      get { return _ItemImageSize; }
      set { _ItemImageSize = value; Invalidate(); }
    }

    private bool _ShowHover = true;
    [Description("Highlight items when mouse hovers over them")]
    [Category("Appearance")]
    public bool HoverVisible
    {
      get { return _ShowHover; }
      set { _ShowHover = value; }
    }

    private Color _HoverColor = Color.LightGray;
    [Description("Hover color")]
    [Category("Appearance")]
    public Color HoverColor
    {
      get { return _HoverColor; }
      set { _HoverColor = value; Invalidate(); }
    }

    private Color _SelectionColor = Color.LightBlue;
    [Description("Selection color")]
    [Category("Appearance")]
    public Color SelectionColor
    {
      get { return _SelectionColor; }
      set { _SelectionColor = value; Invalidate(); }
    }

    private Color _SelectionTextColor = Color.Black;
    [Description("Selection text color")]
    [Category("Appearance")]
    public Color SelectionTextColor
    {
      get { return _SelectionTextColor; }
      set { _SelectionTextColor = value; Invalidate(); }
    }

    private bool _CheckboxStyle = false;
    [Description("Whether to use a checked-style list (multiple items, click toggles selection)")]
    [Category("Behavior")]
    public bool CheckboxStyle
    {
      get { return _CheckboxStyle; }
      set { _CheckboxStyle = value; }
    }

    private bool _ClickDeselects = true;
    [Description("Whether clicking an empty area deselects the currently selected item")]
    [Category("Behavior")]
    public bool ClickDeselects
    {
      get { return _ClickDeselects; }
      set { _ClickDeselects = value; }
    }

    private bool _MultiSelect = false;
    [Description("Whether to allow selecting multiple items")]
    [Category("Behavior")]
    public bool MultiSelect
    {
      get { return _MultiSelect; }
      set { _MultiSelect = value; Invalidate(); }
    }

    private BorderStyle _BorderStyle = BorderStyle.FixedSingle;
    [Description("Border around the control")]
    [Category("Appearance")]
    public BorderStyle BorderStyle
    {
      get { return _BorderStyle; }
      set { _BorderStyle = value; Invalidate(); }
    }

    private bool _SubItemIndicator = true;
    [Description("Show the sub item indicator on items that have subitems")]
    [Category("Appearance")]
    public bool SubItemIndicator
    {
      get { return _SubItemIndicator; }
      set { _SubItemIndicator = value; Invalidate(); }
    }

    public FlatListItemList Items;

    private Label InItemLabel = new Label();

    public List<int> InItemStack = new List<int>();
    public FlatListItem InItem()
    {
      FlatListItem ret = null;
      for (int i = 0; i < InItemStack.Count; i++) {
        if (ret == null) {
          ret = Items[InItemStack[i]];
        } else {
          ret = ret.SubItems[InItemStack[i]];
        }
      }
      return ret;
    }

    public FlatListItemList InItemList()
    {
      FlatListItem fli = InItem();
      if (fli == null) {
        return Items;
      }
      return fli.SubItems;
    }

    public void PushInItemStack(int iItem)
    {
      if (iItem < 0) {
        throw new IndexOutOfRangeException();
      }
      FlatListItemList flil = InItemList();
      if (iItem >= flil.Count) {
        throw new IndexOutOfRangeException();
      }
      InItemStack.Add(iItem);
      Invalidate();
      UpdateScrollbars();
      SelectedIndices = new int[] { };
    }

    public int PopInItemStack()
    {
      if (InItemStack.Count == 0) {
        return -1;
      }
      int i = InItemStack.Last();
      InItemStack.RemoveAt(InItemStack.Count - 1);
      Invalidate();
      UpdateScrollbars();
      return i;
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public FlatListItem[] SelectedItems
    {
      get {
        var list = InItemList();
        var ret = new List<FlatListItem>();
        for (int i = 0; i < SelectedIndices.Length; i++) {
          ret.Add(list[SelectedIndices[i]]);
        }
        return ret.ToArray();
      }
      set {
        // Eh.. compatibility
        if (value == null) {
          return;
        }

        var list = InItemList();
        var indices = new List<int>();
        for (int i = 0; i < value.Length; i++) {
          indices.Add(list.IndexOf(value[i]));
        }
        SelectedIndices = indices.ToArray();
      }
    }

    internal int[] _SelectedIndices = { };
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int[] SelectedIndices
    {
      get { return _SelectedIndices; }
      set {
        bool diff = (_SelectedIndices.Length != value.Length);
        if (!diff) {
          for (int i = 0; i < _SelectedIndices.Length; i++) {
            if (_SelectedIndices[i] != value[i]) {
              diff = true;
              break;
            }
          }
        }

        if (diff) {
          _SelectedIndices = value.OrderBy(n => n).ToArray();
          Invalidate();
          if (SelectedIndicesChanged != null) {
            SelectedIndicesChanged(this, new EventArgs());
          }
        }
      }
    }

    private int _HoverIndex = -1;
    public int HoverIndex
    {
      get { return _HoverIndex; }
      set {
        if (_HoverIndex != value) {
          _HoverIndex = value;
          Invalidate();
        }
      }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int TopActual
    {
      get {
        if (InItemLabel.Visible) {
          return InItemLabel.Top;
        } else {
          return this.Top;
        }
      }
      set {
        if (InItemLabel.Visible) {
          InItemLabel.Top = value;
          this.Top = value + InItemLabel.Height;
        } else {
          this.Top = value;
        }
      }
    }

    public event EventHandler SelectedIndicesChanged;
    public event FlatListItemClickedEventHandler SelectedItemClicked;

    public FlatList()
    {
      Items = new FlatListItemList(this);

      SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
      SetStyle(ControlStyles.AllPaintingInWmPaint, true);
    }

    protected override void OnParentChanged(EventArgs e)
    {
      base.OnParentChanged(e);

      if (DesignMode) {
        return;
      }

      InItemLabel.Visible = false;
      InItemLabel.Width = this.Width;
      InItemLabel.TextAlign = ContentAlignment.MiddleLeft;
      InItemLabel.Click += new EventHandler(InItemLabel_Click);
      InItemLabel.DoubleClick += new EventHandler(InItemLabel_Click);
      Parent.Controls.Add(InItemLabel);
      InItemLabel.BringToFront();
    }

    void InItemLabel_Click(object sender, EventArgs e)
    {
      SelectedIndices = new[] { PopInItemStack() };
    }

    internal void UpdateScrollbars()
    {
      if (_DrawSuspended) {
        return;
      }
      FlatListItemList flil = InItemList();
      AutoScrollMinSize = new Size(1, flil.Count * GetItemSize().Height);
    }

    public void Select(int index, bool add = false)
    {
      if (add) {
        if (!SelectedIndices.Contains(index)) {
          var l = SelectedIndices.ToList();
          l.Add(index);
          SelectedIndices = l.ToArray();
        }
        return;
      }

      if (index == -1) {
        Deselect();
      }

      SelectedIndices = new[] { index };
    }

    public void Deselect(int index = -1)
    {
      if (index == -1) {
        SelectedIndices = new int[] { };
        return;
      }

      var l = SelectedIndices.ToList();
      l.Remove(index);
      SelectedIndices = l.ToArray();
    }

    public void Clear()
    {
      InItemStack.Clear();
      Items.Clear();
      Invalidate();
    }

    public FlatListItem GetItem(int index)
    {
      return Items[index];
    }

    public FlatListItem GetVisibleItem(int index)
    {
      return InItemList()[index];
    }

    public int GetItemCount()
    {
      return Items.Count;
    }

    public int GetVisibleItemCount()
    {
      return InItemList().Count;
    }

    public Size GetItemSize()
    {
      return new Size(Size.Width, _ItemHeight + _PaddingY * 2);
    }

    public Point PointForItem(int index)
    {
      Size itemSize = GetItemSize();
      return new Point(AutoScrollPosition.X, AutoScrollPosition.Y + index * itemSize.Height);
    }

    public Rectangle RectangleForItem(int index)
    {
      Point pt = PointForItem(index);
      Rectangle ret = new Rectangle();
      ret.X = pt.X;
      ret.Y = pt.Y;
      ret.Width = ClientSize.Width;
      ret.Height = _ItemHeight + _PaddingY * 2;
      return ret;
    }

    public int ItemAtPoint(Point pt)
    {
      for (int i = 0; i < InItemList().Count; i++) {
        Rectangle rect = RectangleForItem(i);
        if (rect.Contains(pt)) {
          return i;
        }
      }
      return -1;
    }

    protected override CreateParams CreateParams
    {
      get {
        if (DesignMode) {
          return base.CreateParams;
        }
        CreateParams cp = base.CreateParams;
        cp.ExStyle &= (~0x00000200); // WS_EX_CLIENTEDGE
        cp.Style |= 0x00800000; // WS_BORDER
        return cp;
      }
    }

    protected override void OnResize(EventArgs e)
    {
      UpdateScrollbars();
      base.OnResize(e);
      if (DesignMode) {
        return;
      }
      if (InItemLabel.Visible) {
        InItemLabel.Width = this.Width;
      }
      NativeMethods.RedrawWindow(this.Handle, IntPtr.Zero, IntPtr.Zero, NativeMethods.RedrawWindowFlags.Frame | NativeMethods.RedrawWindowFlags.UpdateNow | NativeMethods.RedrawWindowFlags.Invalidate);
    }

    private void DrawItem(int index, FlatListItem item, PaintEventArgs e)
    {
      Rectangle rect = RectangleForItem(index);

      if (!e.ClipRectangle.IntersectsWith(rect)) {
        return;
      }

      rect.X -= AutoScrollPosition.X;
      rect.Y -= AutoScrollPosition.Y;

      int itemImageSize = _ItemImageSize;
      int itemImagePadding = itemImageSize + 2;

      Color foreColor = ForeColor;
      if (item.ForeColor != Color.Empty) {
        foreColor = item.ForeColor;
      }
      Color foreColorSub = _ForeColorSub;
      if (item.ForeColorSub != Color.Empty) {
        foreColorSub = item.ForeColorSub;
      }
      Color backColor = item.BackColor;
      if (index == HoverIndex) {
        backColor = _HoverColor;
      }
      if ((!_CheckboxStyle && SelectedIndices.Contains(index)) || (_CheckboxStyle && item.Checked)) {
        backColor = _SelectionColor;
        foreColor = _SelectionTextColor;
      }
      if (backColor != Color.Empty) {
        using (SolidBrush brush = new SolidBrush(backColor)) {
          e.Graphics.FillRectangle(brush, rect);
        }
      }

      if (item.Image != null) {
        e.Graphics.DrawImage(item.Image, new Rectangle(_PaddingX + rect.X, rect.Y + rect.Height / 2 - itemImageSize / 2, itemImageSize, itemImageSize));
      }

      Font font = Font;
      if (item.Font != null) {
        font = item.Font;
      }
      Font fontSub = _FontSub;
      if (item.FontSub != null) {
        fontSub = item.FontSub;
      }

      PointF ptOffsetText = new PointF(0, 0);
      SizeF sizeText = e.Graphics.MeasureString(item.Text, font);
      SizeF sizeSubText = e.Graphics.MeasureString(item.SubText, fontSub);

      if (item.ShowProgress) {
        ptOffsetText.Y -= 4;
      }

      SolidBrush brushForeColor = new SolidBrush(foreColor);
      SolidBrush brushForeColorSub = new SolidBrush(foreColorSub);

      e.Graphics.DrawString(item.Text, font, brushForeColor, new PointF(
        ptOffsetText.X + _PaddingX + rect.X + itemImagePadding,
        ptOffsetText.Y + rect.Y + rect.Height / 2 - sizeText.Height / 2 - sizeSubText.Height / 2
      ));

      if (!sizeSubText.IsEmpty) {
        e.Graphics.DrawString(item.SubText, fontSub, brushForeColorSub, new PointF(
          ptOffsetText.X + _PaddingX + rect.X + itemImagePadding,
          ptOffsetText.Y + rect.Y + rect.Height / 2 - sizeText.Height / 2 + sizeSubText.Height / 2
        ));
      }

      if (_SubItemIndicator && item.SubItems != null && item.SubItems.Count > 0) {
        e.Graphics.DrawString(">", font, brushForeColor, new PointF(
          rect.Width - 16,
          ptOffsetText.Y + rect.Y + rect.Height / 2 - sizeText.Height / 2
        ));
      }

      if (item.ShowProgress) {
        int iOffsetRight = _PaddingX * 2;
        if (VerticalScroll.Visible) {
          iOffsetRight += 16;
        }
        Point ptProgress = new Point(
          (int)(ptOffsetText.X + _PaddingX + rect.X + itemImagePadding + 2),
          (int)(ptOffsetText.Y + rect.Y + rect.Height / 2 - sizeText.Height / 2 + sizeSubText.Height + 8)
        );
        Size sizeProgress = new Size(rect.Width - ptProgress.X - iOffsetRight, 8);
        Size sizeProgressFill = new Size((int)(sizeProgress.Width * item.Progress), 8);
        using (SolidBrush brush = new SolidBrush(foreColorSub.Lerp(this.BackColor, 0.6))) {
          e.Graphics.FillRectangle(brush, new Rectangle(ptProgress, sizeProgress));
        }
        e.Graphics.FillRectangle(brushForeColor, new Rectangle(ptProgress, sizeProgressFill));
      }

      brushForeColor.Dispose();
      brushForeColorSub.Dispose();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      if (Parent is FlatArrowContainer) {
        // we only have to draw the background manually here if we're in a FlatArrowContainer
        e.Graphics.Clear(BackColor);
      }

      FlatListItemList flil = Items;

      if (!DesignMode) {
        FlatListItem fliInItem = InItem();
        if (fliInItem != null) {
          flil = fliInItem.SubItems;

          if (!InItemLabel.Visible) {
            InItemLabel.Visible = true;
            InItemLabel.BackColor = _BorderColor;
            InItemLabel.ForeColor = ForeColor;
            InItemLabel.Height = _ItemHeight;
            InItemLabel.Left = this.Left;
            InItemLabel.Top = this.Top;
            this.Top = InItemLabel.Top + InItemLabel.Height;
            this.Height -= InItemLabel.Height;
          }
          InItemLabel.Text = "  <  " + fliInItem.Text;
        } else {
          if (InItemLabel.Visible) {
            InItemLabel.Visible = false;
            this.Top = InItemLabel.Top;
            this.Height += InItemLabel.Height;
          }
        }
      }

      e.Graphics.TranslateTransform(AutoScrollPosition.X, AutoScrollPosition.Y);

      for (int i = 0; i < flil.Count; i++) {
        DrawItem(i, flil[i], e);
      }

      base.OnPaint(e);
    }

    protected override void WndProc(ref Message m)
    {
      if (m.Msg == NativeMethods.WM_NCPAINT) {
        WmNcPaint(ref m);
        return;
      }
      base.WndProc(ref m);
    }

    private void WmNcPaint(ref Message m)
    {
      if (BorderStyle == BorderStyle.None) {
        return;
      }

      IntPtr hDC = NativeMethods.GetWindowDC(m.HWnd);
      using (Graphics g = Graphics.FromHdc(hDC)) {
        using (Pen pen = new Pen(_BorderColor)) {
          g.DrawRectangle(pen, new Rectangle(0, 0, this.Width - 1, this.Height - 1));
        }
      }
      NativeMethods.ReleaseDC(m.HWnd, hDC);
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
      if (DesignMode) {
        return;
      }

      if (_ShowHover) {
        HoverIndex = ItemAtPoint(e.Location);
      }

      base.OnMouseMove(e);
    }

    protected override void OnMouseLeave(EventArgs e)
    {
      if (DesignMode) {
        return;
      }

      if (_ShowHover) {
        HoverIndex = -1;
      }

      base.OnMouseLeave(e);
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
      if (DesignMode) {
        return;
      }

      int iItem = ItemAtPoint(e.Location);

      if (_CheckboxStyle) {
        if (iItem == -1) {
          return;
        }
        FlatListItem i = InItemList()[iItem];
        i.Checked = !i.Checked;
        Invalidate();
        return;
      }

      if (iItem == -1 && !_ClickDeselects) {
        return;
      }

      if (e.Button == MouseButtons.Left) {
        Select(iItem, _MultiSelect && (ModifierKeys & Keys.Control) != 0);
      }

      FlatListItem item = null;
      if (iItem != -1) {
        item = InItemList()[iItem];
        item.CallOnSelected(this, e);
      }

      if (SelectedItemClicked != null) {
        SelectedItemClicked(this, new FlatListItemClickedEventArgs() {
          Item = item,
          MouseButton = e.Button,
          MouseLocation = e.Location
        });
      }

      base.OnMouseDown(e);
    }

    protected override void OnMouseDoubleClick(MouseEventArgs e)
    {
      if (DesignMode) {
        return;
      }

      if (_CheckboxStyle) {
        return;
      }

      if (_SelectedIndices.Length == 1) {
        var item = SelectedItems[0];
        if (item.SubItems != null && item.SubItems.Count > 0) {
          PushInItemStack(_SelectedIndices[0]);
        }
      }

      base.OnMouseDoubleClick(e);
    }

    protected override void OnScroll(ScrollEventArgs se)
    {
      HoverIndex = -1;

      base.OnScroll(se);
    }
  }
}
