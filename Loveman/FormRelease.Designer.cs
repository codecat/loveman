namespace Loveman
{
	partial class FormRelease
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRelease));
			this.checkWin32 = new System.Windows.Forms.CheckBox();
			this.checkMacOS = new System.Windows.Forms.CheckBox();
			this.labelStatus = new System.Windows.Forms.Label();
			this.checkWin64 = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.labelBuildStatus = new System.Windows.Forms.Label();
			this.progress = new System.Windows.Forms.ProgressBar();
			this.buttonCancel = new Nimble.Controls.FlatControls.FlatButton();
			this.buttonBuild = new Nimble.Controls.FlatControls.FlatButton();
			this.SuspendLayout();
			// 
			// checkWin32
			// 
			this.checkWin32.AutoSize = true;
			this.checkWin32.Location = new System.Drawing.Point(35, 39);
			this.checkWin32.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.checkWin32.Name = "checkWin32";
			this.checkWin32.Size = new System.Drawing.Size(124, 20);
			this.checkWin32.TabIndex = 0;
			this.checkWin32.Text = "Windows (32 bit)";
			this.checkWin32.UseVisualStyleBackColor = true;
			// 
			// checkMacOS
			// 
			this.checkMacOS.AutoSize = true;
			this.checkMacOS.Location = new System.Drawing.Point(35, 96);
			this.checkMacOS.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.checkMacOS.Name = "checkMacOS";
			this.checkMacOS.Size = new System.Drawing.Size(72, 20);
			this.checkMacOS.TabIndex = 2;
			this.checkMacOS.Text = "MacOS";
			this.checkMacOS.UseVisualStyleBackColor = true;
			// 
			// labelStatus
			// 
			this.labelStatus.AutoSize = true;
			this.labelStatus.Location = new System.Drawing.Point(13, 9);
			this.labelStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelStatus.Name = "labelStatus";
			this.labelStatus.Size = new System.Drawing.Size(67, 16);
			this.labelStatus.TabIndex = 3;
			this.labelStatus.Text = "Platforms:";
			// 
			// checkWin64
			// 
			this.checkWin64.AutoSize = true;
			this.checkWin64.Location = new System.Drawing.Point(35, 68);
			this.checkWin64.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.checkWin64.Name = "checkWin64";
			this.checkWin64.Size = new System.Drawing.Size(124, 20);
			this.checkWin64.TabIndex = 1;
			this.checkWin64.Text = "Windows (64 bit)";
			this.checkWin64.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Location = new System.Drawing.Point(13, 149);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(537, 47);
			this.label1.TabIndex = 5;
			this.label1.Text = "Any platforms that are not downloaded yet will automatically be downloaded. If yo" +
    "u don\'t select any platform above, only a .love file will be compiled.";
			// 
			// labelBuildStatus
			// 
			this.labelBuildStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.labelBuildStatus.AutoSize = true;
			this.labelBuildStatus.Location = new System.Drawing.Point(13, 196);
			this.labelBuildStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelBuildStatus.Name = "labelBuildStatus";
			this.labelBuildStatus.Size = new System.Drawing.Size(105, 16);
			this.labelBuildStatus.TabIndex = 7;
			this.labelBuildStatus.Text = "labelBuildStatus";
			this.labelBuildStatus.Visible = false;
			// 
			// progress
			// 
			this.progress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.progress.Location = new System.Drawing.Point(13, 215);
			this.progress.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.progress.Name = "progress";
			this.progress.Size = new System.Drawing.Size(537, 28);
			this.progress.TabIndex = 8;
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
			this.buttonCancel.Image = global::Loveman.Properties.Resources.cancel;
			this.buttonCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonCancel.ImagePadding = 3;
			this.buttonCancel.Location = new System.Drawing.Point(434, 269);
			this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(116, 28);
			this.buttonCancel.TabIndex = 6;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.buttonCancel.TextImageRelation = Nimble.Controls.FlatControls.FlatTextImageRelation.Normal;
			this.buttonCancel.TextPadding = 3;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// buttonBuild
			// 
			this.buttonBuild.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonBuild.BackColorDown = System.Drawing.Color.White;
			this.buttonBuild.BackColorOver = System.Drawing.Color.DarkGray;
			this.buttonBuild.BackShadeColor = System.Drawing.SystemColors.Control;
			this.buttonBuild.BackShadeRatio = 0D;
			this.buttonBuild.BorderColor = System.Drawing.Color.Black;
			this.buttonBuild.HasBorder = true;
			this.buttonBuild.Image = global::Loveman.Properties.Resources.accept;
			this.buttonBuild.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonBuild.ImagePadding = 3;
			this.buttonBuild.Location = new System.Drawing.Point(310, 269);
			this.buttonBuild.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.buttonBuild.Name = "buttonBuild";
			this.buttonBuild.Size = new System.Drawing.Size(116, 28);
			this.buttonBuild.TabIndex = 5;
			this.buttonBuild.Text = "Build";
			this.buttonBuild.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.buttonBuild.TextImageRelation = Nimble.Controls.FlatControls.FlatTextImageRelation.Normal;
			this.buttonBuild.TextPadding = 3;
			this.buttonBuild.Click += new System.EventHandler(this.buttonBuild_Click);
			// 
			// FormRelease
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(563, 310);
			this.Controls.Add(this.progress);
			this.Controls.Add(this.labelBuildStatus);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonBuild);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.labelStatus);
			this.Controls.Add(this.checkMacOS);
			this.Controls.Add(this.checkWin64);
			this.Controls.Add(this.checkWin32);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.MaximizeBox = false;
			this.Name = "FormRelease";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Build release";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox checkWin32;
		private System.Windows.Forms.CheckBox checkMacOS;
		private System.Windows.Forms.Label labelStatus;
		private System.Windows.Forms.CheckBox checkWin64;
		private System.Windows.Forms.Label label1;
		private Nimble.Controls.FlatControls.FlatButton buttonBuild;
		private Nimble.Controls.FlatControls.FlatButton buttonCancel;
		private System.Windows.Forms.Label labelBuildStatus;
		private System.Windows.Forms.ProgressBar progress;
	}
}