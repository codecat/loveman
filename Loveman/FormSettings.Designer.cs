namespace Loveman
{
	partial class FormSettings
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
			this.label1 = new System.Windows.Forms.Label();
			this.textLovePath = new Nimble.Controls.ExtendedTextBox();
			this.buttonBrowseLove = new Nimble.Controls.FlatControls.FlatButton();
			this.label2 = new System.Windows.Forms.Label();
			this.textMoonscriptPath = new Nimble.Controls.ExtendedTextBox();
			this.buttonBrowseMoon = new Nimble.Controls.FlatControls.FlatButton();
			this.buttonCancel = new Nimble.Controls.FlatControls.FlatButton();
			this.buttonOK = new Nimble.Controls.FlatControls.FlatButton();
			this.label3 = new System.Windows.Forms.Label();
			this.textProjectsPath = new Nimble.Controls.ExtendedTextBox();
			this.buttonBrowseProjects = new Nimble.Controls.FlatControls.FlatButton();
			this.label4 = new System.Windows.Forms.Label();
			this.textEditorPath = new Nimble.Controls.ExtendedTextBox();
			this.buttonBrowseEditor = new Nimble.Controls.FlatControls.FlatButton();
			this.label5 = new System.Windows.Forms.Label();
			this.textSublimeMergePath = new Nimble.Controls.ExtendedTextBox();
			this.buttonBrowseSublimeMerge = new Nimble.Controls.FlatControls.FlatButton();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(56, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(62, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "LOVE path:";
			// 
			// textLovePath
			// 
			this.textLovePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textLovePath.BorderColor = System.Drawing.SystemColors.InactiveBorder;
			this.textLovePath.BorderColorActive = System.Drawing.SystemColors.ActiveBorder;
			this.textLovePath.HasBorders = true;
			this.textLovePath.Location = new System.Drawing.Point(124, 12);
			this.textLovePath.Name = "textLovePath";
			this.textLovePath.Size = new System.Drawing.Size(247, 20);
			this.textLovePath.TabIndex = 0;
			// 
			// buttonBrowseLove
			// 
			this.buttonBrowseLove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonBrowseLove.BackColorDown = System.Drawing.Color.White;
			this.buttonBrowseLove.BackColorOver = System.Drawing.Color.DarkGray;
			this.buttonBrowseLove.BackShadeColor = System.Drawing.SystemColors.Control;
			this.buttonBrowseLove.BackShadeRatio = 0D;
			this.buttonBrowseLove.BorderColor = System.Drawing.Color.Black;
			this.buttonBrowseLove.HasBorder = true;
			this.buttonBrowseLove.Image = null;
			this.buttonBrowseLove.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonBrowseLove.ImagePadding = 3;
			this.buttonBrowseLove.Location = new System.Drawing.Point(377, 11);
			this.buttonBrowseLove.Name = "buttonBrowseLove";
			this.buttonBrowseLove.Size = new System.Drawing.Size(74, 23);
			this.buttonBrowseLove.TabIndex = 1;
			this.buttonBrowseLove.Text = "Browse...";
			this.buttonBrowseLove.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonBrowseLove.TextImageRelation = Nimble.Controls.FlatControls.FlatTextImageRelation.Normal;
			this.buttonBrowseLove.TextPadding = 3;
			this.buttonBrowseLove.Click += new System.EventHandler(this.buttonBrowseLove_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(32, 44);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(86, 13);
			this.label2.TabIndex = 0;
			this.label2.Text = "Moonscript path:";
			// 
			// textMoonscriptPath
			// 
			this.textMoonscriptPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textMoonscriptPath.BorderColor = System.Drawing.SystemColors.InactiveBorder;
			this.textMoonscriptPath.BorderColorActive = System.Drawing.SystemColors.ActiveBorder;
			this.textMoonscriptPath.HasBorders = true;
			this.textMoonscriptPath.Location = new System.Drawing.Point(124, 41);
			this.textMoonscriptPath.Name = "textMoonscriptPath";
			this.textMoonscriptPath.Size = new System.Drawing.Size(247, 20);
			this.textMoonscriptPath.TabIndex = 2;
			// 
			// buttonBrowseMoon
			// 
			this.buttonBrowseMoon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonBrowseMoon.BackColorDown = System.Drawing.Color.White;
			this.buttonBrowseMoon.BackColorOver = System.Drawing.Color.DarkGray;
			this.buttonBrowseMoon.BackShadeColor = System.Drawing.SystemColors.Control;
			this.buttonBrowseMoon.BackShadeRatio = 0D;
			this.buttonBrowseMoon.BorderColor = System.Drawing.Color.Black;
			this.buttonBrowseMoon.HasBorder = true;
			this.buttonBrowseMoon.Image = null;
			this.buttonBrowseMoon.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonBrowseMoon.ImagePadding = 3;
			this.buttonBrowseMoon.Location = new System.Drawing.Point(377, 40);
			this.buttonBrowseMoon.Name = "buttonBrowseMoon";
			this.buttonBrowseMoon.Size = new System.Drawing.Size(74, 23);
			this.buttonBrowseMoon.TabIndex = 3;
			this.buttonBrowseMoon.Text = "Browse...";
			this.buttonBrowseMoon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonBrowseMoon.TextImageRelation = Nimble.Controls.FlatControls.FlatTextImageRelation.Normal;
			this.buttonBrowseMoon.TextPadding = 3;
			this.buttonBrowseMoon.Click += new System.EventHandler(this.buttonBrowseMoon_Click);
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
			this.buttonCancel.Location = new System.Drawing.Point(365, 181);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(86, 23);
			this.buttonCancel.TabIndex = 5;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonCancel.TextImageRelation = Nimble.Controls.FlatControls.FlatTextImageRelation.Normal;
			this.buttonCancel.TextPadding = 3;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
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
			this.buttonOK.Location = new System.Drawing.Point(273, 181);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(86, 23);
			this.buttonOK.TabIndex = 4;
			this.buttonOK.Text = "OK";
			this.buttonOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonOK.TextImageRelation = Nimble.Controls.FlatControls.FlatTextImageRelation.Normal;
			this.buttonOK.TextPadding = 3;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(46, 73);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 13);
			this.label3.TabIndex = 0;
			this.label3.Text = "Projects path:";
			// 
			// textProjectsPath
			// 
			this.textProjectsPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textProjectsPath.BorderColor = System.Drawing.SystemColors.InactiveBorder;
			this.textProjectsPath.BorderColorActive = System.Drawing.SystemColors.ActiveBorder;
			this.textProjectsPath.HasBorders = true;
			this.textProjectsPath.Location = new System.Drawing.Point(124, 70);
			this.textProjectsPath.Name = "textProjectsPath";
			this.textProjectsPath.Size = new System.Drawing.Size(247, 20);
			this.textProjectsPath.TabIndex = 2;
			// 
			// buttonBrowseProjects
			// 
			this.buttonBrowseProjects.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonBrowseProjects.BackColorDown = System.Drawing.Color.White;
			this.buttonBrowseProjects.BackColorOver = System.Drawing.Color.DarkGray;
			this.buttonBrowseProjects.BackShadeColor = System.Drawing.SystemColors.Control;
			this.buttonBrowseProjects.BackShadeRatio = 0D;
			this.buttonBrowseProjects.BorderColor = System.Drawing.Color.Black;
			this.buttonBrowseProjects.HasBorder = true;
			this.buttonBrowseProjects.Image = null;
			this.buttonBrowseProjects.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonBrowseProjects.ImagePadding = 3;
			this.buttonBrowseProjects.Location = new System.Drawing.Point(377, 69);
			this.buttonBrowseProjects.Name = "buttonBrowseProjects";
			this.buttonBrowseProjects.Size = new System.Drawing.Size(74, 23);
			this.buttonBrowseProjects.TabIndex = 3;
			this.buttonBrowseProjects.Text = "Browse...";
			this.buttonBrowseProjects.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonBrowseProjects.TextImageRelation = Nimble.Controls.FlatControls.FlatTextImageRelation.Normal;
			this.buttonBrowseProjects.TextPadding = 3;
			this.buttonBrowseProjects.Click += new System.EventHandler(this.buttonBrowseProjects_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(57, 102);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(61, 13);
			this.label4.TabIndex = 0;
			this.label4.Text = "Editor path:";
			// 
			// textEditorPath
			// 
			this.textEditorPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textEditorPath.BorderColor = System.Drawing.SystemColors.InactiveBorder;
			this.textEditorPath.BorderColorActive = System.Drawing.SystemColors.ActiveBorder;
			this.textEditorPath.HasBorders = true;
			this.textEditorPath.Location = new System.Drawing.Point(124, 99);
			this.textEditorPath.Name = "textEditorPath";
			this.textEditorPath.Size = new System.Drawing.Size(247, 20);
			this.textEditorPath.TabIndex = 2;
			// 
			// buttonBrowseEditor
			// 
			this.buttonBrowseEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonBrowseEditor.BackColorDown = System.Drawing.Color.White;
			this.buttonBrowseEditor.BackColorOver = System.Drawing.Color.DarkGray;
			this.buttonBrowseEditor.BackShadeColor = System.Drawing.SystemColors.Control;
			this.buttonBrowseEditor.BackShadeRatio = 0D;
			this.buttonBrowseEditor.BorderColor = System.Drawing.Color.Black;
			this.buttonBrowseEditor.HasBorder = true;
			this.buttonBrowseEditor.Image = null;
			this.buttonBrowseEditor.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonBrowseEditor.ImagePadding = 3;
			this.buttonBrowseEditor.Location = new System.Drawing.Point(377, 98);
			this.buttonBrowseEditor.Name = "buttonBrowseEditor";
			this.buttonBrowseEditor.Size = new System.Drawing.Size(74, 23);
			this.buttonBrowseEditor.TabIndex = 3;
			this.buttonBrowseEditor.Text = "Browse...";
			this.buttonBrowseEditor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonBrowseEditor.TextImageRelation = Nimble.Controls.FlatControls.FlatTextImageRelation.Normal;
			this.buttonBrowseEditor.TextPadding = 3;
			this.buttonBrowseEditor.Click += new System.EventHandler(this.buttonBrowseEditor_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(14, 131);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(104, 13);
			this.label5.TabIndex = 6;
			this.label5.Text = "Sublime Merge path:";
			// 
			// textSublimeMergePath
			// 
			this.textSublimeMergePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textSublimeMergePath.BorderColor = System.Drawing.SystemColors.InactiveBorder;
			this.textSublimeMergePath.BorderColorActive = System.Drawing.SystemColors.ActiveBorder;
			this.textSublimeMergePath.HasBorders = true;
			this.textSublimeMergePath.Location = new System.Drawing.Point(124, 128);
			this.textSublimeMergePath.Name = "textSublimeMergePath";
			this.textSublimeMergePath.Size = new System.Drawing.Size(247, 20);
			this.textSublimeMergePath.TabIndex = 2;
			// 
			// buttonBrowseSublimeMerge
			// 
			this.buttonBrowseSublimeMerge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonBrowseSublimeMerge.BackColorDown = System.Drawing.Color.White;
			this.buttonBrowseSublimeMerge.BackColorOver = System.Drawing.Color.DarkGray;
			this.buttonBrowseSublimeMerge.BackShadeColor = System.Drawing.SystemColors.Control;
			this.buttonBrowseSublimeMerge.BackShadeRatio = 0D;
			this.buttonBrowseSublimeMerge.BorderColor = System.Drawing.Color.Black;
			this.buttonBrowseSublimeMerge.HasBorder = true;
			this.buttonBrowseSublimeMerge.Image = null;
			this.buttonBrowseSublimeMerge.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonBrowseSublimeMerge.ImagePadding = 3;
			this.buttonBrowseSublimeMerge.Location = new System.Drawing.Point(377, 127);
			this.buttonBrowseSublimeMerge.Name = "buttonBrowseSublimeMerge";
			this.buttonBrowseSublimeMerge.Size = new System.Drawing.Size(74, 23);
			this.buttonBrowseSublimeMerge.TabIndex = 3;
			this.buttonBrowseSublimeMerge.Text = "Browse...";
			this.buttonBrowseSublimeMerge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonBrowseSublimeMerge.TextImageRelation = Nimble.Controls.FlatControls.FlatTextImageRelation.Normal;
			this.buttonBrowseSublimeMerge.TextPadding = 3;
			this.buttonBrowseSublimeMerge.Click += new System.EventHandler(this.buttonBrowseSublimeMerge_Click);
			// 
			// FormSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(463, 216);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonBrowseSublimeMerge);
			this.Controls.Add(this.buttonBrowseEditor);
			this.Controls.Add(this.buttonBrowseProjects);
			this.Controls.Add(this.textSublimeMergePath);
			this.Controls.Add(this.textEditorPath);
			this.Controls.Add(this.buttonBrowseMoon);
			this.Controls.Add(this.textProjectsPath);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.buttonBrowseLove);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textMoonscriptPath);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textLovePath);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormSettings";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Settings";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private Nimble.Controls.ExtendedTextBox textLovePath;
		private Nimble.Controls.FlatControls.FlatButton buttonBrowseLove;
		private System.Windows.Forms.Label label2;
		private Nimble.Controls.ExtendedTextBox textMoonscriptPath;
		private Nimble.Controls.FlatControls.FlatButton buttonBrowseMoon;
		private Nimble.Controls.FlatControls.FlatButton buttonCancel;
		private Nimble.Controls.FlatControls.FlatButton buttonOK;
		private System.Windows.Forms.Label label3;
		private Nimble.Controls.ExtendedTextBox textProjectsPath;
		private Nimble.Controls.FlatControls.FlatButton buttonBrowseProjects;
		private System.Windows.Forms.Label label4;
		private Nimble.Controls.ExtendedTextBox textEditorPath;
		private Nimble.Controls.FlatControls.FlatButton buttonBrowseEditor;
		private System.Windows.Forms.Label label5;
		private Nimble.Controls.ExtendedTextBox textSublimeMergePath;
		private Nimble.Controls.FlatControls.FlatButton buttonBrowseSublimeMerge;
	}
}