﻿namespace Loveman
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
			this.checkLinux32 = new System.Windows.Forms.CheckBox();
			this.labelStatus = new System.Windows.Forms.Label();
			this.checkWin64 = new System.Windows.Forms.CheckBox();
			this.checkLinux64 = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.buttonBuild = new Nimble.Controls.FlatControls.FlatButton();
			this.buttonCancel = new Nimble.Controls.FlatControls.FlatButton();
			this.labelBuildStatus = new System.Windows.Forms.Label();
			this.progress = new System.Windows.Forms.ProgressBar();
			this.SuspendLayout();
			// 
			// checkWin32
			// 
			this.checkWin32.AutoCheck = false;
			this.checkWin32.AutoSize = true;
			this.checkWin32.Location = new System.Drawing.Point(26, 32);
			this.checkWin32.Name = "checkWin32";
			this.checkWin32.Size = new System.Drawing.Size(105, 17);
			this.checkWin32.TabIndex = 0;
			this.checkWin32.Text = "Windows (32 bit)";
			this.checkWin32.UseVisualStyleBackColor = true;
			// 
			// checkMacOS
			// 
			this.checkMacOS.AutoCheck = false;
			this.checkMacOS.AutoSize = true;
			this.checkMacOS.Location = new System.Drawing.Point(26, 78);
			this.checkMacOS.Name = "checkMacOS";
			this.checkMacOS.Size = new System.Drawing.Size(62, 17);
			this.checkMacOS.TabIndex = 2;
			this.checkMacOS.Text = "MacOS";
			this.checkMacOS.UseVisualStyleBackColor = true;
			// 
			// checkLinux32
			// 
			this.checkLinux32.AutoCheck = false;
			this.checkLinux32.AutoSize = true;
			this.checkLinux32.Location = new System.Drawing.Point(26, 101);
			this.checkLinux32.Name = "checkLinux32";
			this.checkLinux32.Size = new System.Drawing.Size(86, 17);
			this.checkLinux32.TabIndex = 3;
			this.checkLinux32.Text = "Linux (32 bit)";
			this.checkLinux32.UseVisualStyleBackColor = true;
			// 
			// labelStatus
			// 
			this.labelStatus.AutoSize = true;
			this.labelStatus.Location = new System.Drawing.Point(12, 9);
			this.labelStatus.Name = "labelStatus";
			this.labelStatus.Size = new System.Drawing.Size(53, 13);
			this.labelStatus.TabIndex = 3;
			this.labelStatus.Text = "Platforms:";
			// 
			// checkWin64
			// 
			this.checkWin64.AutoCheck = false;
			this.checkWin64.AutoSize = true;
			this.checkWin64.Location = new System.Drawing.Point(26, 55);
			this.checkWin64.Name = "checkWin64";
			this.checkWin64.Size = new System.Drawing.Size(105, 17);
			this.checkWin64.TabIndex = 1;
			this.checkWin64.Text = "Windows (64 bit)";
			this.checkWin64.UseVisualStyleBackColor = true;
			// 
			// checkLinux64
			// 
			this.checkLinux64.AutoCheck = false;
			this.checkLinux64.AutoSize = true;
			this.checkLinux64.Location = new System.Drawing.Point(26, 124);
			this.checkLinux64.Name = "checkLinux64";
			this.checkLinux64.Size = new System.Drawing.Size(86, 17);
			this.checkLinux64.TabIndex = 4;
			this.checkLinux64.Text = "Linux (64 bit)";
			this.checkLinux64.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Location = new System.Drawing.Point(12, 149);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(398, 38);
			this.label1.TabIndex = 5;
			this.label1.Text = "Any platforms that are not downloaded yet will automatically be downloaded. If yo" +
    "u don\'t select any platform above, only a .love file will be compiled.";
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
			this.buttonBuild.Location = new System.Drawing.Point(230, 245);
			this.buttonBuild.Name = "buttonBuild";
			this.buttonBuild.Size = new System.Drawing.Size(87, 23);
			this.buttonBuild.TabIndex = 5;
			this.buttonBuild.Text = "Build";
			this.buttonBuild.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.buttonBuild.TextImageRelation = Nimble.Controls.FlatControls.FlatTextImageRelation.Normal;
			this.buttonBuild.TextPadding = 3;
			this.buttonBuild.Click += new System.EventHandler(this.buttonBuild_Click);
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
			this.buttonCancel.Location = new System.Drawing.Point(323, 245);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(87, 23);
			this.buttonCancel.TabIndex = 6;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.buttonCancel.TextImageRelation = Nimble.Controls.FlatControls.FlatTextImageRelation.Normal;
			this.buttonCancel.TextPadding = 3;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// labelBuildStatus
			// 
			this.labelBuildStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.labelBuildStatus.AutoSize = true;
			this.labelBuildStatus.Location = new System.Drawing.Point(12, 187);
			this.labelBuildStatus.Name = "labelBuildStatus";
			this.labelBuildStatus.Size = new System.Drawing.Size(82, 13);
			this.labelBuildStatus.TabIndex = 7;
			this.labelBuildStatus.Text = "labelBuildStatus";
			this.labelBuildStatus.Visible = false;
			// 
			// progress
			// 
			this.progress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.progress.Location = new System.Drawing.Point(12, 203);
			this.progress.Name = "progress";
			this.progress.Size = new System.Drawing.Size(398, 23);
			this.progress.TabIndex = 8;
			this.progress.Visible = false;
			// 
			// FormRelease
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(422, 280);
			this.Controls.Add(this.progress);
			this.Controls.Add(this.labelBuildStatus);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonBuild);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.labelStatus);
			this.Controls.Add(this.checkLinux64);
			this.Controls.Add(this.checkLinux32);
			this.Controls.Add(this.checkMacOS);
			this.Controls.Add(this.checkWin64);
			this.Controls.Add(this.checkWin32);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
		private System.Windows.Forms.CheckBox checkLinux32;
		private System.Windows.Forms.Label labelStatus;
		private System.Windows.Forms.CheckBox checkWin64;
		private System.Windows.Forms.CheckBox checkLinux64;
		private System.Windows.Forms.Label label1;
		private Nimble.Controls.FlatControls.FlatButton buttonBuild;
		private Nimble.Controls.FlatControls.FlatButton buttonCancel;
		private System.Windows.Forms.Label labelBuildStatus;
		private System.Windows.Forms.ProgressBar progress;
	}
}