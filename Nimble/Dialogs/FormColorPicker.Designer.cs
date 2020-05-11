namespace Nimble.Dialogs
{
  partial class FormColorPicker
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      Nimble.Drawing.ColorHSV colorHSV1 = new Nimble.Drawing.ColorHSV();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormColorPicker));
      this.colorWheel1 = new Nimble.Controls.ColorWheel();
      this.colorPickerBox1 = new Nimble.Controls.ColorPickerBox();
      this.flatGroupBox3 = new Nimble.Controls.FlatControls.FlatGroupBox();
      this.numA = new Nimble.Controls.FlatControls.FlatNumberBox();
      this.scrollA = new Nimble.Controls.FlatControls.FlatScrollbar();
      this.flatGroupBox2 = new Nimble.Controls.FlatControls.FlatGroupBox();
      this.numH = new Nimble.Controls.FlatControls.FlatNumberBox();
      this.scrollH = new Nimble.Controls.FlatControls.FlatScrollbar();
      this.numV = new Nimble.Controls.FlatControls.FlatNumberBox();
      this.scrollS = new Nimble.Controls.FlatControls.FlatScrollbar();
      this.numS = new Nimble.Controls.FlatControls.FlatNumberBox();
      this.scrollV = new Nimble.Controls.FlatControls.FlatScrollbar();
      this.label5 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.flatGroupBox1 = new Nimble.Controls.FlatControls.FlatGroupBox();
      this.numR = new Nimble.Controls.FlatControls.FlatNumberBox();
      this.textHex = new Nimble.Controls.ExtendedTextBox();
      this.scrollR = new Nimble.Controls.FlatControls.FlatScrollbar();
      this.numB = new Nimble.Controls.FlatControls.FlatNumberBox();
      this.scrollG = new Nimble.Controls.FlatControls.FlatScrollbar();
      this.numG = new Nimble.Controls.FlatControls.FlatNumberBox();
      this.scrollB = new Nimble.Controls.FlatControls.FlatScrollbar();
      this.label1 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.panelPreview = new Nimble.Controls.ExtendedPanel();
      this.buttonOK = new Nimble.Controls.FlatControls.FlatButton();
      this.buttonCancel = new Nimble.Controls.FlatControls.FlatButton();
      this.flatGroupBox3.SuspendLayout();
      this.flatGroupBox2.SuspendLayout();
      this.flatGroupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // colorWheel1
      // 
      this.colorWheel1.Color = colorHSV1;
      this.colorWheel1.HueDegrees = 0D;
      this.colorWheel1.Location = new System.Drawing.Point(37, 48);
      this.colorWheel1.Name = "colorWheel1";
      this.colorWheel1.SaturationPercent = 0D;
      this.colorWheel1.Size = new System.Drawing.Size(141, 141);
      this.colorWheel1.TabIndex = 10;
      this.colorWheel1.Text = "colorCircle1";
      this.colorWheel1.OnColorChanged += new System.EventHandler(this.colorWheel1_OnColorChanged);
      // 
      // colorPickerBox1
      // 
      this.colorPickerBox1.BoxSize = 12;
      this.colorPickerBox1.Colors = ((System.Collections.Generic.List<System.Drawing.Color>)(resources.GetObject("colorPickerBox1.Colors")));
      this.colorPickerBox1.Location = new System.Drawing.Point(12, 215);
      this.colorPickerBox1.Name = "colorPickerBox1";
      this.colorPickerBox1.Size = new System.Drawing.Size(192, 48);
      this.colorPickerBox1.TabIndex = 9;
      this.colorPickerBox1.Text = "colorPickerBox1";
      this.colorPickerBox1.Click += new Nimble.Controls.ColorPickerBoxClick(this.colorPickerBox1_Click);
      // 
      // flatGroupBox3
      // 
      this.flatGroupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.flatGroupBox3.BorderColor = System.Drawing.Color.Black;
      this.flatGroupBox3.Controls.Add(this.numA);
      this.flatGroupBox3.Controls.Add(this.scrollA);
      this.flatGroupBox3.HasBorders = true;
      this.flatGroupBox3.LeftPadding = 10;
      this.flatGroupBox3.Location = new System.Drawing.Point(215, 215);
      this.flatGroupBox3.Name = "flatGroupBox3";
      this.flatGroupBox3.Size = new System.Drawing.Size(182, 43);
      this.flatGroupBox3.TabIndex = 8;
      this.flatGroupBox3.Text = "flatGroupBox3";
      this.flatGroupBox3.TextPadding = 2;
      this.flatGroupBox3.Title = "Opacity - Alpha";
      this.flatGroupBox3.TopPadding = 10;
      // 
      // numA
      // 
      this.numA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.numA.BorderColor = System.Drawing.Color.Black;
      this.numA.ButtonBackColor = System.Drawing.Color.LightGray;
      this.numA.ButtonBackColorDown = System.Drawing.Color.White;
      this.numA.ButtonBackColorOver = System.Drawing.Color.DarkGray;
      this.numA.ButtonChange = 1;
      this.numA.ButtonsLeft = false;
      this.numA.ButtonsVertical = true;
      this.numA.ButtonWidth = 24;
      this.numA.HasBorders = true;
      this.numA.HoldInitialInterval = 500;
      this.numA.HoldInterval = 100;
      this.numA.HoldIntervalFaster = 300;
      this.numA.HoldIntervalFastest = 20;
      this.numA.Location = new System.Drawing.Point(113, 21);
      this.numA.Maximum = 100;
      this.numA.Minimum = 0;
      this.numA.Name = "numA";
      this.numA.Size = new System.Drawing.Size(63, 16);
      this.numA.TabIndex = 5;
      this.numA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.numA.TextPadding = 3;
      this.numA.Value = 100;
      // 
      // scrollA
      // 
      this.scrollA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.scrollA.BackColor = System.Drawing.Color.White;
      this.scrollA.BorderColor = System.Drawing.Color.Black;
      this.scrollA.ClickRangeCursor = System.Windows.Forms.Cursors.VSplit;
      this.scrollA.FillColor = System.Drawing.Color.Gray;
      this.scrollA.GuidelineColor = System.Drawing.Color.White;
      this.scrollA.HandleColor = System.Drawing.Color.Silver;
      this.scrollA.HandleGripColor = System.Drawing.Color.Black;
      this.scrollA.Location = new System.Drawing.Point(29, 21);
      this.scrollA.Maximum = 100;
      this.scrollA.Minimum = 0;
      this.scrollA.Name = "scrollA";
      this.scrollA.Size = new System.Drawing.Size(78, 16);
      this.scrollA.TabIndex = 3;
      this.scrollA.Value = 100;
      // 
      // flatGroupBox2
      // 
      this.flatGroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.flatGroupBox2.BorderColor = System.Drawing.Color.Black;
      this.flatGroupBox2.Controls.Add(this.numH);
      this.flatGroupBox2.Controls.Add(this.scrollH);
      this.flatGroupBox2.Controls.Add(this.numV);
      this.flatGroupBox2.Controls.Add(this.scrollS);
      this.flatGroupBox2.Controls.Add(this.numS);
      this.flatGroupBox2.Controls.Add(this.scrollV);
      this.flatGroupBox2.Controls.Add(this.label5);
      this.flatGroupBox2.Controls.Add(this.label7);
      this.flatGroupBox2.Controls.Add(this.label8);
      this.flatGroupBox2.HasBorders = true;
      this.flatGroupBox2.LeftPadding = 10;
      this.flatGroupBox2.Location = new System.Drawing.Point(215, 122);
      this.flatGroupBox2.Name = "flatGroupBox2";
      this.flatGroupBox2.Size = new System.Drawing.Size(182, 87);
      this.flatGroupBox2.TabIndex = 7;
      this.flatGroupBox2.TextPadding = 2;
      this.flatGroupBox2.Title = "HSV";
      this.flatGroupBox2.TopPadding = 10;
      // 
      // numH
      // 
      this.numH.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.numH.BorderColor = System.Drawing.Color.Black;
      this.numH.ButtonBackColor = System.Drawing.Color.LightGray;
      this.numH.ButtonBackColorDown = System.Drawing.Color.White;
      this.numH.ButtonBackColorOver = System.Drawing.Color.DarkGray;
      this.numH.ButtonChange = 1;
      this.numH.ButtonsLeft = false;
      this.numH.ButtonsVertical = true;
      this.numH.ButtonWidth = 24;
      this.numH.HasBorders = true;
      this.numH.HoldInitialInterval = 500;
      this.numH.HoldInterval = 100;
      this.numH.HoldIntervalFaster = 300;
      this.numH.HoldIntervalFastest = 20;
      this.numH.Location = new System.Drawing.Point(113, 21);
      this.numH.Maximum = 360;
      this.numH.Minimum = 0;
      this.numH.Name = "numH";
      this.numH.Size = new System.Drawing.Size(63, 16);
      this.numH.TabIndex = 5;
      this.numH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.numH.TextPadding = 3;
      this.numH.Value = 0;
      // 
      // scrollH
      // 
      this.scrollH.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.scrollH.BackColor = System.Drawing.Color.White;
      this.scrollH.BorderColor = System.Drawing.Color.Black;
      this.scrollH.ClickRangeCursor = System.Windows.Forms.Cursors.VSplit;
      this.scrollH.FillColor = System.Drawing.Color.Gray;
      this.scrollH.GuidelineColor = System.Drawing.Color.White;
      this.scrollH.HandleColor = System.Drawing.Color.Silver;
      this.scrollH.HandleGripColor = System.Drawing.Color.Black;
      this.scrollH.Location = new System.Drawing.Point(29, 21);
      this.scrollH.Maximum = 360;
      this.scrollH.Minimum = 0;
      this.scrollH.Name = "scrollH";
      this.scrollH.Size = new System.Drawing.Size(78, 16);
      this.scrollH.TabIndex = 3;
      this.scrollH.Value = 0;
      // 
      // numV
      // 
      this.numV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.numV.BorderColor = System.Drawing.Color.Black;
      this.numV.ButtonBackColor = System.Drawing.Color.LightGray;
      this.numV.ButtonBackColorDown = System.Drawing.Color.White;
      this.numV.ButtonBackColorOver = System.Drawing.Color.DarkGray;
      this.numV.ButtonChange = 1;
      this.numV.ButtonsLeft = false;
      this.numV.ButtonsVertical = true;
      this.numV.ButtonWidth = 24;
      this.numV.HasBorders = true;
      this.numV.HoldInitialInterval = 500;
      this.numV.HoldInterval = 100;
      this.numV.HoldIntervalFaster = 300;
      this.numV.HoldIntervalFastest = 20;
      this.numV.Location = new System.Drawing.Point(113, 65);
      this.numV.Maximum = 100;
      this.numV.Minimum = 0;
      this.numV.Name = "numV";
      this.numV.Size = new System.Drawing.Size(63, 16);
      this.numV.TabIndex = 5;
      this.numV.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.numV.TextPadding = 3;
      this.numV.Value = 0;
      // 
      // scrollS
      // 
      this.scrollS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.scrollS.BackColor = System.Drawing.Color.White;
      this.scrollS.BorderColor = System.Drawing.Color.Black;
      this.scrollS.ClickRangeCursor = System.Windows.Forms.Cursors.VSplit;
      this.scrollS.FillColor = System.Drawing.Color.Gray;
      this.scrollS.GuidelineColor = System.Drawing.Color.White;
      this.scrollS.HandleColor = System.Drawing.Color.Silver;
      this.scrollS.HandleGripColor = System.Drawing.Color.Black;
      this.scrollS.Location = new System.Drawing.Point(29, 43);
      this.scrollS.Maximum = 100;
      this.scrollS.Minimum = 0;
      this.scrollS.Name = "scrollS";
      this.scrollS.Size = new System.Drawing.Size(78, 16);
      this.scrollS.TabIndex = 3;
      this.scrollS.Value = 0;
      // 
      // numS
      // 
      this.numS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.numS.BorderColor = System.Drawing.Color.Black;
      this.numS.ButtonBackColor = System.Drawing.Color.LightGray;
      this.numS.ButtonBackColorDown = System.Drawing.Color.White;
      this.numS.ButtonBackColorOver = System.Drawing.Color.DarkGray;
      this.numS.ButtonChange = 1;
      this.numS.ButtonsLeft = false;
      this.numS.ButtonsVertical = true;
      this.numS.ButtonWidth = 24;
      this.numS.HasBorders = true;
      this.numS.HoldInitialInterval = 500;
      this.numS.HoldInterval = 100;
      this.numS.HoldIntervalFaster = 300;
      this.numS.HoldIntervalFastest = 20;
      this.numS.Location = new System.Drawing.Point(113, 43);
      this.numS.Maximum = 100;
      this.numS.Minimum = 0;
      this.numS.Name = "numS";
      this.numS.Size = new System.Drawing.Size(63, 16);
      this.numS.TabIndex = 5;
      this.numS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.numS.TextPadding = 3;
      this.numS.Value = 0;
      // 
      // scrollV
      // 
      this.scrollV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.scrollV.BackColor = System.Drawing.Color.White;
      this.scrollV.BorderColor = System.Drawing.Color.Black;
      this.scrollV.ClickRangeCursor = System.Windows.Forms.Cursors.VSplit;
      this.scrollV.FillColor = System.Drawing.Color.Gray;
      this.scrollV.GuidelineColor = System.Drawing.Color.White;
      this.scrollV.HandleColor = System.Drawing.Color.Silver;
      this.scrollV.HandleGripColor = System.Drawing.Color.Black;
      this.scrollV.Location = new System.Drawing.Point(29, 65);
      this.scrollV.Maximum = 100;
      this.scrollV.Minimum = 0;
      this.scrollV.Name = "scrollV";
      this.scrollV.Size = new System.Drawing.Size(78, 16);
      this.scrollV.TabIndex = 3;
      this.scrollV.Value = 0;
      // 
      // label5
      // 
      this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(5, 21);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(18, 13);
      this.label5.TabIndex = 4;
      this.label5.Text = "H:";
      // 
      // label7
      // 
      this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(5, 43);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(17, 13);
      this.label7.TabIndex = 4;
      this.label7.Text = "S:";
      // 
      // label8
      // 
      this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(5, 65);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(17, 13);
      this.label8.TabIndex = 4;
      this.label8.Text = "V:";
      // 
      // flatGroupBox1
      // 
      this.flatGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.flatGroupBox1.BorderColor = System.Drawing.Color.Black;
      this.flatGroupBox1.Controls.Add(this.numR);
      this.flatGroupBox1.Controls.Add(this.textHex);
      this.flatGroupBox1.Controls.Add(this.scrollR);
      this.flatGroupBox1.Controls.Add(this.numB);
      this.flatGroupBox1.Controls.Add(this.scrollG);
      this.flatGroupBox1.Controls.Add(this.numG);
      this.flatGroupBox1.Controls.Add(this.scrollB);
      this.flatGroupBox1.Controls.Add(this.label1);
      this.flatGroupBox1.Controls.Add(this.label4);
      this.flatGroupBox1.Controls.Add(this.label2);
      this.flatGroupBox1.Controls.Add(this.label3);
      this.flatGroupBox1.HasBorders = true;
      this.flatGroupBox1.LeftPadding = 10;
      this.flatGroupBox1.Location = new System.Drawing.Point(215, 2);
      this.flatGroupBox1.Name = "flatGroupBox1";
      this.flatGroupBox1.Size = new System.Drawing.Size(182, 114);
      this.flatGroupBox1.TabIndex = 7;
      this.flatGroupBox1.TextPadding = 2;
      this.flatGroupBox1.Title = "RGB";
      this.flatGroupBox1.TopPadding = 10;
      // 
      // numR
      // 
      this.numR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.numR.BorderColor = System.Drawing.Color.Black;
      this.numR.ButtonBackColor = System.Drawing.Color.LightGray;
      this.numR.ButtonBackColorDown = System.Drawing.Color.White;
      this.numR.ButtonBackColorOver = System.Drawing.Color.DarkGray;
      this.numR.ButtonChange = 1;
      this.numR.ButtonsLeft = false;
      this.numR.ButtonsVertical = true;
      this.numR.ButtonWidth = 24;
      this.numR.HasBorders = true;
      this.numR.HoldInitialInterval = 500;
      this.numR.HoldInterval = 100;
      this.numR.HoldIntervalFaster = 300;
      this.numR.HoldIntervalFastest = 20;
      this.numR.Location = new System.Drawing.Point(113, 21);
      this.numR.Maximum = 255;
      this.numR.Minimum = 0;
      this.numR.Name = "numR";
      this.numR.Size = new System.Drawing.Size(63, 16);
      this.numR.TabIndex = 5;
      this.numR.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.numR.TextPadding = 3;
      this.numR.Value = 0;
      // 
      // textHex
      // 
      this.textHex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.textHex.BorderColor = System.Drawing.SystemColors.WindowFrame;
      this.textHex.HasBorders = true;
      this.textHex.Location = new System.Drawing.Point(113, 87);
      this.textHex.MaxLength = 6;
      this.textHex.Name = "textHex";
      this.textHex.Size = new System.Drawing.Size(63, 20);
      this.textHex.TabIndex = 6;
      this.textHex.Text = "000000";
      this.textHex.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.textHex.TextChanged += new System.EventHandler(this.textHex_TextChanged);
      // 
      // scrollR
      // 
      this.scrollR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.scrollR.BackColor = System.Drawing.Color.White;
      this.scrollR.BorderColor = System.Drawing.Color.Black;
      this.scrollR.ClickRangeCursor = System.Windows.Forms.Cursors.VSplit;
      this.scrollR.FillColor = System.Drawing.Color.Gray;
      this.scrollR.GuidelineColor = System.Drawing.Color.White;
      this.scrollR.HandleColor = System.Drawing.Color.Silver;
      this.scrollR.HandleGripColor = System.Drawing.Color.Black;
      this.scrollR.Location = new System.Drawing.Point(29, 21);
      this.scrollR.Maximum = 255;
      this.scrollR.Minimum = 0;
      this.scrollR.Name = "scrollR";
      this.scrollR.Size = new System.Drawing.Size(78, 16);
      this.scrollR.TabIndex = 3;
      this.scrollR.Value = 0;
      // 
      // numB
      // 
      this.numB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.numB.BorderColor = System.Drawing.Color.Black;
      this.numB.ButtonBackColor = System.Drawing.Color.LightGray;
      this.numB.ButtonBackColorDown = System.Drawing.Color.White;
      this.numB.ButtonBackColorOver = System.Drawing.Color.DarkGray;
      this.numB.ButtonChange = 1;
      this.numB.ButtonsLeft = false;
      this.numB.ButtonsVertical = true;
      this.numB.ButtonWidth = 24;
      this.numB.HasBorders = true;
      this.numB.HoldInitialInterval = 500;
      this.numB.HoldInterval = 100;
      this.numB.HoldIntervalFaster = 300;
      this.numB.HoldIntervalFastest = 20;
      this.numB.Location = new System.Drawing.Point(113, 65);
      this.numB.Maximum = 255;
      this.numB.Minimum = 0;
      this.numB.Name = "numB";
      this.numB.Size = new System.Drawing.Size(63, 16);
      this.numB.TabIndex = 5;
      this.numB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.numB.TextPadding = 3;
      this.numB.Value = 0;
      // 
      // scrollG
      // 
      this.scrollG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.scrollG.BackColor = System.Drawing.Color.White;
      this.scrollG.BorderColor = System.Drawing.Color.Black;
      this.scrollG.ClickRangeCursor = System.Windows.Forms.Cursors.VSplit;
      this.scrollG.FillColor = System.Drawing.Color.Gray;
      this.scrollG.GuidelineColor = System.Drawing.Color.White;
      this.scrollG.HandleColor = System.Drawing.Color.Silver;
      this.scrollG.HandleGripColor = System.Drawing.Color.Black;
      this.scrollG.Location = new System.Drawing.Point(29, 43);
      this.scrollG.Maximum = 255;
      this.scrollG.Minimum = 0;
      this.scrollG.Name = "scrollG";
      this.scrollG.Size = new System.Drawing.Size(78, 16);
      this.scrollG.TabIndex = 3;
      this.scrollG.Value = 0;
      // 
      // numG
      // 
      this.numG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.numG.BorderColor = System.Drawing.Color.Black;
      this.numG.ButtonBackColor = System.Drawing.Color.LightGray;
      this.numG.ButtonBackColorDown = System.Drawing.Color.White;
      this.numG.ButtonBackColorOver = System.Drawing.Color.DarkGray;
      this.numG.ButtonChange = 1;
      this.numG.ButtonsLeft = false;
      this.numG.ButtonsVertical = true;
      this.numG.ButtonWidth = 24;
      this.numG.HasBorders = true;
      this.numG.HoldInitialInterval = 500;
      this.numG.HoldInterval = 100;
      this.numG.HoldIntervalFaster = 300;
      this.numG.HoldIntervalFastest = 20;
      this.numG.Location = new System.Drawing.Point(113, 43);
      this.numG.Maximum = 255;
      this.numG.Minimum = 0;
      this.numG.Name = "numG";
      this.numG.Size = new System.Drawing.Size(63, 16);
      this.numG.TabIndex = 5;
      this.numG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.numG.TextPadding = 3;
      this.numG.Value = 0;
      // 
      // scrollB
      // 
      this.scrollB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.scrollB.BackColor = System.Drawing.Color.White;
      this.scrollB.BorderColor = System.Drawing.Color.Black;
      this.scrollB.ClickRangeCursor = System.Windows.Forms.Cursors.VSplit;
      this.scrollB.FillColor = System.Drawing.Color.Gray;
      this.scrollB.GuidelineColor = System.Drawing.Color.White;
      this.scrollB.HandleColor = System.Drawing.Color.Silver;
      this.scrollB.HandleGripColor = System.Drawing.Color.Black;
      this.scrollB.Location = new System.Drawing.Point(29, 65);
      this.scrollB.Maximum = 255;
      this.scrollB.Minimum = 0;
      this.scrollB.Name = "scrollB";
      this.scrollB.Size = new System.Drawing.Size(78, 16);
      this.scrollB.TabIndex = 3;
      this.scrollB.Value = 0;
      // 
      // label1
      // 
      this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(5, 21);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(18, 13);
      this.label1.TabIndex = 4;
      this.label1.Text = "R:";
      // 
      // label4
      // 
      this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(5, 87);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(29, 13);
      this.label4.TabIndex = 4;
      this.label4.Text = "Hex:";
      // 
      // label2
      // 
      this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(5, 43);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(18, 13);
      this.label2.TabIndex = 4;
      this.label2.Text = "G:";
      // 
      // label3
      // 
      this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(5, 65);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(17, 13);
      this.label3.TabIndex = 4;
      this.label3.Text = "B:";
      // 
      // panelPreview
      // 
      this.panelPreview.BorderColor = System.Drawing.SystemColors.WindowFrame;
      this.panelPreview.ClickFocusesSelf = true;
      this.panelPreview.EnableScrollToControl = true;
      this.panelPreview.HasBorders = true;
      this.panelPreview.Location = new System.Drawing.Point(12, 12);
      this.panelPreview.Name = "panelPreview";
      this.panelPreview.Size = new System.Drawing.Size(192, 30);
      this.panelPreview.TabIndex = 2;
      // 
      // buttonOK
      // 
      this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonOK.BackColorDown = System.Drawing.Color.White;
      this.buttonOK.BackColorOver = System.Drawing.Color.DarkGray;
      this.buttonOK.BackShadeColor = System.Drawing.SystemColors.Control;
      this.buttonOK.BackShadeRatio = 0D;
      this.buttonOK.BorderColor = System.Drawing.Color.Black;
      this.buttonOK.HasBorder = true;
      this.buttonOK.Image = null;
      this.buttonOK.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.buttonOK.ImagePadding = 3;
      this.buttonOK.Location = new System.Drawing.Point(241, 267);
      this.buttonOK.Name = "buttonOK";
      this.buttonOK.Size = new System.Drawing.Size(75, 23);
      this.buttonOK.TabIndex = 1;
      this.buttonOK.Text = "OK";
      this.buttonOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.buttonOK.TextImageRelation = Nimble.Controls.FlatControls.FlatTextImageRelation.Normal;
      this.buttonOK.TextPadding = 3;
      this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
      // 
      // buttonCancel
      // 
      this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonCancel.BackColorDown = System.Drawing.Color.White;
      this.buttonCancel.BackColorOver = System.Drawing.Color.DarkGray;
      this.buttonCancel.BackShadeColor = System.Drawing.SystemColors.Control;
      this.buttonCancel.BackShadeRatio = 0D;
      this.buttonCancel.BorderColor = System.Drawing.Color.Black;
      this.buttonCancel.HasBorder = true;
      this.buttonCancel.Image = null;
      this.buttonCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.buttonCancel.ImagePadding = 3;
      this.buttonCancel.Location = new System.Drawing.Point(322, 267);
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.Size = new System.Drawing.Size(75, 23);
      this.buttonCancel.TabIndex = 0;
      this.buttonCancel.Text = "Cancel";
      this.buttonCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.buttonCancel.TextImageRelation = Nimble.Controls.FlatControls.FlatTextImageRelation.Normal;
      this.buttonCancel.TextPadding = 3;
      this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
      // 
      // FormColorPicker
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(409, 302);
      this.Controls.Add(this.colorWheel1);
      this.Controls.Add(this.colorPickerBox1);
      this.Controls.Add(this.flatGroupBox3);
      this.Controls.Add(this.flatGroupBox2);
      this.Controls.Add(this.flatGroupBox1);
      this.Controls.Add(this.panelPreview);
      this.Controls.Add(this.buttonOK);
      this.Controls.Add(this.buttonCancel);
      this.DoubleBuffered = true;
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "FormColorPicker";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Pick color";
      this.flatGroupBox3.ResumeLayout(false);
      this.flatGroupBox2.ResumeLayout(false);
      this.flatGroupBox2.PerformLayout();
      this.flatGroupBox1.ResumeLayout(false);
      this.flatGroupBox1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private Controls.FlatControls.FlatButton buttonCancel;
    private Controls.FlatControls.FlatButton buttonOK;
    private Controls.ExtendedPanel panelPreview;
    private Controls.FlatControls.FlatScrollbar scrollR;
    private Controls.FlatControls.FlatScrollbar scrollG;
    private Controls.FlatControls.FlatScrollbar scrollB;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private Controls.FlatControls.FlatNumberBox numR;
    private Controls.FlatControls.FlatNumberBox numG;
    private Controls.FlatControls.FlatNumberBox numB;
    private Controls.ExtendedTextBox textHex;
    private System.Windows.Forms.Label label4;
    private Controls.FlatControls.FlatGroupBox flatGroupBox1;
    private Controls.FlatControls.FlatGroupBox flatGroupBox2;
    private Controls.FlatControls.FlatNumberBox numH;
    private Controls.FlatControls.FlatScrollbar scrollH;
    private Controls.FlatControls.FlatNumberBox numV;
    private Controls.FlatControls.FlatScrollbar scrollS;
    private Controls.FlatControls.FlatNumberBox numS;
    private Controls.FlatControls.FlatScrollbar scrollV;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label8;
    private Controls.FlatControls.FlatGroupBox flatGroupBox3;
    private Controls.FlatControls.FlatNumberBox numA;
    private Controls.FlatControls.FlatScrollbar scrollA;
    private Controls.ColorPickerBox colorPickerBox1;
    private Controls.ColorWheel colorWheel1;
  }
}