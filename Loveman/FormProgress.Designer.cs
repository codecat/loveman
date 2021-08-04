
namespace Loveman
{
	partial class FormProgress
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProgress));
			this.progress = new System.Windows.Forms.ProgressBar();
			this.labelText = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// progress
			// 
			this.progress.Location = new System.Drawing.Point(12, 52);
			this.progress.Name = "progress";
			this.progress.Size = new System.Drawing.Size(354, 23);
			this.progress.TabIndex = 0;
			// 
			// labelText
			// 
			this.labelText.AutoSize = true;
			this.labelText.Location = new System.Drawing.Point(12, 18);
			this.labelText.Name = "labelText";
			this.labelText.Size = new System.Drawing.Size(16, 13);
			this.labelText.TabIndex = 1;
			this.labelText.Text = "...";
			// 
			// FormProgress
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(378, 87);
			this.ControlBox = false;
			this.Controls.Add(this.labelText);
			this.Controls.Add(this.progress);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormProgress";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Progress";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ProgressBar progress;
		private System.Windows.Forms.Label labelText;
	}
}