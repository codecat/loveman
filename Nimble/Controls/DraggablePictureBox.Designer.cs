namespace Nimble.Controls
{
  partial class DraggablePictureBox
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.SuspendLayout();
      // 
      // DraggablePictureBox
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.DoubleBuffered = true;
      this.Name = "DraggablePictureBox";
      this.Size = new System.Drawing.Size(146, 146);
      this.Load += new System.EventHandler(this.DraggablePictureBox_Load);
      this.Paint += new System.Windows.Forms.PaintEventHandler(this.DraggablePictureBox_Paint);
      this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DraggablePictureBox_MouseDown);
      this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DraggablePictureBox_MouseMove);
      this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DraggablePictureBox_MouseUp);
      this.Resize += new System.EventHandler(this.DraggablePictureBox_Resize);
      this.ResumeLayout(false);

    }

    #endregion
  }
}
