using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Nimble.Controls.FlatControls
{
  public partial class FlatNumberBox : Control
  {
    private Color _BorderColor = Color.Black;
    [Description("Color of the border")]
    [Category("Appearance")]
    public Color BorderColor
    {
      get { return _BorderColor; }
      set { _BorderColor = value; Invalidate(); }
    }

    private Color _ButtonBackColor = Color.LightGray;
    [Description("Background color of the up and down buttons")]
    [Category("Appearance")]
    public Color ButtonBackColor
    {
      get { return _ButtonBackColor; }
      set { _ButtonBackColor = value; Invalidate(); }
    }

    private Color _ButtonBackColorOver = Color.DarkGray;
    [Description("Background color of the up and down buttons when hovering over it")]
    [Category("Appearance")]
    public Color ButtonBackColorOver
    {
      get { return _ButtonBackColorOver; }
      set { _ButtonBackColorOver = value; }
    }

    private Color _ButtonBackColorDown = Color.White;
    [Description("Background color of the up and down buttons when mouse is down")]
    [Category("Appearance")]
    public Color ButtonBackColorDown
    {
      get { return _ButtonBackColorDown; }
      set { _ButtonBackColorDown = value; }
    }

    private bool _HasBorders = true;
    [Description("Whether there should be any borders shown")]
    [Category("Appearance")]
    public bool HasBorders
    {
      get { return _HasBorders; }
      set { _HasBorders = value; Invalidate(); }
    }

    private int _ButtonWidth = 24;
    [Description("Width of the buttons")]
    [Category("Apperance")]
    public int ButtonWidth
    {
      get { return _ButtonWidth; }
      set { _ButtonWidth = value; Invalidate(); }
    }

    private bool _ButtonsVertical = true;
    [Description("Whether the buttons should be vertical")]
    [Category("Appearance")]
    public bool ButtonsVertical
    {
      get { return _ButtonsVertical; }
      set { _ButtonsVertical = value; Invalidate(); }
    }

    private bool _ButtonsLeft = false;
    [Description("Whether the buttons should be on the left instead of the right")]
    [Category("Appearance")]
    public bool ButtonsLeft
    {
      get { return _ButtonsLeft; }
      set { _ButtonsLeft = value; Invalidate(); }
    }

    private int _Minimum = 0;
    [Description("Minimum value")]
    [Category("Numberbox")]
    public int Minimum
    {
      get { return _Minimum; }
      set
      {
        _Minimum = value;
        Value = _Value;
      }
    }

    private int _Maximum = 100;
    [Description("Maximum value")]
    [Category("Numberbox")]
    public int Maximum
    {
      get { return _Maximum; }
      set
      {
        _Maximum = value;
        Value = _Value;
      }
    }

    private int _Value = 50;
    [Description("Value")]
    [Category("Numberbox")]
    public int Value
    {
      get { return _Value; }
      set
      {
        if (_Value != value) {
          _Value = value;
          if (_Value > _Maximum) {
            if (_WrapBounds) {
              _Value = _Minimum + (_Value - _Maximum - 1);
            } else {
              _Value = _Maximum;
            }
          }
          if (_Value < _Minimum) {
            if (_WrapBounds) {
              _Value = _Maximum - (_Minimum - _Value - 1);
            } else {
              _Value = _Minimum;
            }
          }
          Invalidate();
          if (ValueChanged != null) {
            ValueChanged(this, new EventArgs());
          }
        }
      }
    }

    [Description("Called when the value changes")]
    [Category("Numberbox")]
    public event EventHandler ValueChanged;

    private int _TextPadding = 3;
    [Description("Padding of the text")]
    [Category("Appearance")]
    public int TextPadding
    {
      get { return _TextPadding; }
      set { _TextPadding = value; Invalidate(); }
    }

    private int _ButtonChange = 1;
    [Description("Button change value")]
    [Category("Numberbox")]
    public int ButtonChange
    {
      get { return _ButtonChange; }
      set { _ButtonChange = value; }
    }

    private ContentAlignment _TextAlign = ContentAlignment.MiddleLeft;
    [Description("Text alignment")]
    [Category("Appearance")]
    public ContentAlignment TextAlign
    {
      get { return _TextAlign; }
      set { _TextAlign = value; Invalidate(); }
    }

    private FlatButtonState _bsUp = FlatButtonState.Normal;
    private FlatButtonState _bsDown = FlatButtonState.Normal;

    private FlatButtonState bsUp
    {
      get { return _bsUp; }
      set
      {
        if (_bsUp == FlatButtonState.Down && value != FlatButtonState.Down) {
          KillTimer();
        }
        if (_bsUp != value) {
          _bsUp = value;
          Invalidate();
        }
      }
    }
    private FlatButtonState bsDown
    {
      get { return _bsDown; }
      set
      {
        if (_bsDown == FlatButtonState.Down && value != FlatButtonState.Down) {
          KillTimer();
        }
        if (_bsDown != value) {
          _bsDown = value;
          Invalidate();
        }
      }
    }

    private bool _WrapBounds = false;
    [Description("Whether to wrap around the minimum and maximum limits when the user tries to go past them")]
    [Category("Numberbox")]
    public bool WrapBounds
    {
      get { return _WrapBounds; }
      set { _WrapBounds = value; }
    }

    private string _PreText = "";
    [Description("A text that is prepended to the actual number value")]
    [Category("Appearance")]
    public string Pretext
    {
      get { return _PreText; }
      set { _PreText = value; Invalidate(); }
    }

    private string _PostText = "";
    [Description("A text that is suffixed to the actual number value")]
    [Category("Appearance")]
    public string PostText
    {
      get { return _PostText; }
      set { _PostText = value; Invalidate(); }
    }

    public Dictionary<int, string> ValueBind = new Dictionary<int, string>();

    private int _holdInitialInterval = 500;
    [Description("Initial interval between fast add when holding down the button")]
    [Category("Numberbox")]
    public int HoldInitialInterval
    {
      get { return _holdInitialInterval; }
      set { _holdInitialInterval = value; }
    }

    private int _holdInterval = 100;
    [Description("Interval between fast add when holding down the button")]
    [Category("Numberbox")]
    public int HoldInterval
    {
      get { return _holdInterval; }
      set { _holdInterval = value; }
    }

    private int _holdIntervalFaster = 300;
    [Description("Interval at which fast add when holding down the button will go faster, or 0 to disable this")]
    [Category("Numberbox")]
    public int HoldIntervalFaster
    {
      get { return _holdIntervalFaster; }
      set { _holdIntervalFaster = value; }
    }

    private int _holdIntervalFastest = 20;
    [Description("Fastest interval at which holding the button will go at")]
    [Category("Numberbox")]
    public int HoldIntervalFastest
    {
      get { return _holdIntervalFastest; }
      set { _holdIntervalFastest = value; }
    }

    private System.Threading.Timer _timerHold = null;
    private Mutex _mutexKillTimer = new Mutex();
    private DateTime _timerHoldStart = DateTime.Now;
    private bool _timerHoldFastest = false;

    public FlatNumberBox()
    {
      this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
      this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
    }

    private int GetButtonsWidth()
    {
      if (_ButtonsVertical) {
        return _ButtonWidth * 2;
      }
      return _ButtonWidth;
    }

    protected override Size DefaultSize { get { return new Size(108, 24); } }

    private Rectangle GetButtonUpRectangle()
    {
      Rectangle ret = new Rectangle();
      ret.Width = _ButtonWidth;
      ret.Height = (_ButtonsVertical ? this.Height / 2 : this.Height);
      ret.X = (_ButtonsLeft ? 0 : this.Width - _ButtonWidth - (_ButtonsVertical ? 0 : _ButtonWidth));
      ret.Y = 0;
      return ret;
    }

    private Rectangle GetButtonDownRectangle()
    {
      Rectangle ret = new Rectangle();
      ret.Width = _ButtonWidth;
      ret.Height = (_ButtonsVertical ? this.Height / 2 : this.Height);
      ret.X = (_ButtonsLeft ? (_ButtonsVertical ? 0 : _ButtonWidth) : this.Width - _ButtonWidth);
      ret.Y = (_ButtonsVertical ? this.Height / 2 : 0);
      return ret;
    }

    private Rectangle GetTextContainerRectangle()
    {
      Rectangle ret = new Rectangle();
      ret.Width = this.Width - _ButtonWidth - (_ButtonsVertical ? 0 : _ButtonWidth);
      ret.Height = this.Height;
      ret.X = (_ButtonsLeft ? _ButtonWidth + (_ButtonsVertical ? 0 : _ButtonWidth) : 0);
      ret.Y = 0;
      return ret;
    }

    private Rectangle GetTextRectangle(Size szText)
    {
      Size sz = new Size(szText.Width + _TextPadding * 2, szText.Height + _TextPadding * 2);
      Rectangle ret = LayoutUtils.Align(sz, GetTextContainerRectangle(), _TextAlign);
      ret.X += _TextPadding;
      ret.Y += _TextPadding;
      return ret;
    }

    private void CreateTimer()
    {
      if (_timerHold != null) {
        return;
      }

      _timerHoldStart = DateTime.Now + new TimeSpan(0, 0, 0, 0, _holdInitialInterval);
      _timerHoldFastest = false;
      _timerHold = new System.Threading.Timer((o) => {
        this.Invoke(new Action(delegate
        {
          if (bsUp == FlatButtonState.Down) {
            OnButtonUpClicked();
          } else if (bsDown == FlatButtonState.Down) {
            OnButtonDownClicked();
          }

          if (!_timerHoldFastest && _holdIntervalFaster > 0 && (DateTime.Now - _timerHoldStart).TotalMilliseconds > _holdIntervalFaster) {
            _mutexKillTimer.WaitOne();

            if (_timerHold != null) {
              _timerHold.Change(0, _holdIntervalFastest);
              _timerHoldFastest = true;
            }

            _mutexKillTimer.ReleaseMutex();
          }
        }));
      }, null, _holdInitialInterval, _holdInterval);
    }

    private void KillTimer()
    {
      if (_timerHold == null) {
        return;
      }

      _mutexKillTimer.WaitOne();

      _timerHold.Dispose();
      _timerHold = null;

      _mutexKillTimer.ReleaseMutex();
    }

    protected virtual void OnButtonUpClicked()
    {
      Value += _ButtonChange;
    }

    protected virtual void OnButtonDownClicked()
    {
      Value -= _ButtonChange;
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
      if (bsUp == FlatButtonState.Over && GetButtonUpRectangle().Contains(e.Location)) {
        bsUp = FlatButtonState.Down;
        OnButtonUpClicked();
        CreateTimer();
      }

      if (bsDown == FlatButtonState.Over && GetButtonDownRectangle().Contains(e.Location)) {
        bsDown = FlatButtonState.Down;
        OnButtonDownClicked();
        CreateTimer();
      }

      base.OnMouseDown(e);
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
      if (bsUp == FlatButtonState.Down) {
        if (GetButtonUpRectangle().Contains(e.Location)) {
          bsUp = FlatButtonState.Over;
        } else {
          bsUp = FlatButtonState.Normal;
        }
      }

      if (bsDown == FlatButtonState.Down) {
        if (GetButtonDownRectangle().Contains(e.Location)) {
          bsDown = FlatButtonState.Over;
        } else {
          bsDown = FlatButtonState.Normal;
        }
      }

      base.OnMouseUp(e);
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
      if (GetButtonUpRectangle().Contains(e.Location)) {
        if (bsUp != FlatButtonState.Down) {
          bsUp = FlatButtonState.Over;
        }
      } else {
        bsUp = FlatButtonState.Normal;
      }

      if (GetButtonDownRectangle().Contains(e.Location)) {
        if (bsDown != FlatButtonState.Down) {
          bsDown = FlatButtonState.Over;
        }
      } else {
        bsDown = FlatButtonState.Normal;
      }

      base.OnMouseMove(e);
    }

    protected override void OnMouseLeave(EventArgs e)
    {
      bsUp = FlatButtonState.Normal;
      bsDown = FlatButtonState.Normal;

      base.OnMouseLeave(e);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      string strText = _Value.ToString();
      if (ValueBind.ContainsKey(_Value)) {
        strText = ValueBind[_Value];
      }

      strText = _PreText + strText + _PostText;

      Rectangle rectText = GetTextRectangle(e.Graphics.MeasureString(strText, this.Font).ToSize());

      Pen penBorderColor = new Pen(_BorderColor);

      Brush brushForeColor = new SolidBrush(this.ForeColor);
      Brush brushButtonUpBackColor = new SolidBrush(_ButtonBackColor);
      Brush brushButtonDownBackColor = new SolidBrush(_ButtonBackColor);

      if (bsUp == FlatButtonState.Over) {
        brushButtonUpBackColor.Dispose();
        brushButtonUpBackColor = new SolidBrush(_ButtonBackColorOver);
      } else if (bsUp == FlatButtonState.Down) {
        brushButtonUpBackColor.Dispose();
        brushButtonUpBackColor = new SolidBrush(_ButtonBackColorDown);
      }

      if (bsDown == FlatButtonState.Over) {
        brushButtonDownBackColor.Dispose();
        brushButtonDownBackColor = new SolidBrush(_ButtonBackColorOver);
      } else if (bsDown == FlatButtonState.Down) {
        brushButtonDownBackColor.Dispose();
        brushButtonDownBackColor = new SolidBrush(_ButtonBackColorDown);
      }

      e.Graphics.DrawString(strText, this.Font, brushForeColor, rectText.Location);

      Rectangle rectButtonUp = GetButtonUpRectangle();
      Rectangle rectButtonDown = GetButtonDownRectangle();

      Font fontWebdings = new Font("Webdings", 8.25f);

      Size szArrow = e.Graphics.MeasureString("5", fontWebdings).ToSize();

      e.Graphics.FillRectangle(brushButtonUpBackColor, rectButtonUp);
      e.Graphics.DrawString("5", fontWebdings, brushForeColor, new Point(
        rectButtonUp.X + rectButtonUp.Width / 2 - szArrow.Width / 2,
        rectButtonUp.Y + rectButtonUp.Height / 2 - szArrow.Height / 4 * 3
      ));

      e.Graphics.FillRectangle(brushButtonDownBackColor, rectButtonDown);
      e.Graphics.DrawString("6", fontWebdings, brushForeColor, new Point(
        rectButtonDown.X + rectButtonDown.Width / 2 - szArrow.Width / 2,
        rectButtonDown.Y + rectButtonDown.Height / 2 - szArrow.Height / 4 * 3 - 2
      ));

      if (_HasBorders) {
        e.Graphics.DrawRectangle(penBorderColor, rectButtonUp);
        e.Graphics.DrawRectangle(penBorderColor, rectButtonDown);
        e.Graphics.DrawRectangle(penBorderColor, new Rectangle(0, 0, Size.Width - 1, Size.Height - 1));
      }

      brushForeColor.Dispose();
      brushButtonUpBackColor.Dispose();
      brushButtonDownBackColor.Dispose();

      penBorderColor.Dispose();

      base.OnPaint(e);
    }
  }
}
