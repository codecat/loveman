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
			this.label2 = new System.Windows.Forms.Label();
			this.textLovrPath = new Nimble.Controls.ExtendedTextBox();
			this.buttonBrowseLovr = new Nimble.Controls.FlatControls.FlatButton();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(82, 18);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(75, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "LÖVE path:";
			// 
			// textLovePath
			// 
			this.textLovePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textLovePath.BorderColor = System.Drawing.SystemColors.InactiveBorder;
			this.textLovePath.BorderColorActive = System.Drawing.SystemColors.ActiveBorder;
			this.textLovePath.HasBorders = true;
			this.textLovePath.Location = new System.Drawing.Point(165, 15);
			this.textLovePath.Margin = new System.Windows.Forms.Padding(4);
			this.textLovePath.Name = "textLovePath";
			this.textLovePath.Size = new System.Drawing.Size(332, 22);
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
			this.buttonBrowseLove.Location = new System.Drawing.Point(505, 13);
			this.buttonBrowseLove.Margin = new System.Windows.Forms.Padding(4);
			this.buttonBrowseLove.Name = "buttonBrowseLove";
			this.buttonBrowseLove.Size = new System.Drawing.Size(99, 28);
			this.buttonBrowseLove.TabIndex = 1;
			this.buttonBrowseLove.Text = "Browse...";
			this.buttonBrowseLove.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonBrowseLove.TextImageRelation = Nimble.Controls.FlatControls.FlatTextImageRelation.Normal;
			this.buttonBrowseLove.TextPadding = 3;
			this.buttonBrowseLove.Click += new System.EventHandler(this.buttonBrowseLove_Click);
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
			this.buttonCancel.Location = new System.Drawing.Point(489, 252);
			this.buttonCancel.Margin = new System.Windows.Forms.Padding(4);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(115, 28);
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
			this.buttonOK.Location = new System.Drawing.Point(366, 252);
			this.buttonOK.Margin = new System.Windows.Forms.Padding(4);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(115, 28);
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
			this.label3.Location = new System.Drawing.Point(68, 112);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(89, 16);
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
			this.textProjectsPath.Location = new System.Drawing.Point(165, 109);
			this.textProjectsPath.Margin = new System.Windows.Forms.Padding(4);
			this.textProjectsPath.Name = "textProjectsPath";
			this.textProjectsPath.Size = new System.Drawing.Size(332, 22);
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
			this.buttonBrowseProjects.Location = new System.Drawing.Point(505, 109);
			this.buttonBrowseProjects.Margin = new System.Windows.Forms.Padding(4);
			this.buttonBrowseProjects.Name = "buttonBrowseProjects";
			this.buttonBrowseProjects.Size = new System.Drawing.Size(99, 28);
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
			this.label4.Location = new System.Drawing.Point(82, 149);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(75, 16);
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
			this.textEditorPath.Location = new System.Drawing.Point(165, 146);
			this.textEditorPath.Margin = new System.Windows.Forms.Padding(4);
			this.textEditorPath.Name = "textEditorPath";
			this.textEditorPath.Size = new System.Drawing.Size(332, 22);
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
			this.buttonBrowseEditor.Location = new System.Drawing.Point(505, 144);
			this.buttonBrowseEditor.Margin = new System.Windows.Forms.Padding(4);
			this.buttonBrowseEditor.Name = "buttonBrowseEditor";
			this.buttonBrowseEditor.Size = new System.Drawing.Size(99, 28);
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
			this.label5.Location = new System.Drawing.Point(26, 185);
			this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(131, 16);
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
			this.textSublimeMergePath.Location = new System.Drawing.Point(165, 182);
			this.textSublimeMergePath.Margin = new System.Windows.Forms.Padding(4);
			this.textSublimeMergePath.Name = "textSublimeMergePath";
			this.textSublimeMergePath.Size = new System.Drawing.Size(332, 22);
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
			this.buttonBrowseSublimeMerge.Location = new System.Drawing.Point(505, 180);
			this.buttonBrowseSublimeMerge.Margin = new System.Windows.Forms.Padding(4);
			this.buttonBrowseSublimeMerge.Name = "buttonBrowseSublimeMerge";
			this.buttonBrowseSublimeMerge.Size = new System.Drawing.Size(99, 28);
			this.buttonBrowseSublimeMerge.TabIndex = 3;
			this.buttonBrowseSublimeMerge.Text = "Browse...";
			this.buttonBrowseSublimeMerge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonBrowseSublimeMerge.TextImageRelation = Nimble.Controls.FlatControls.FlatTextImageRelation.Normal;
			this.buttonBrowseSublimeMerge.TextPadding = 3;
			this.buttonBrowseSublimeMerge.Click += new System.EventHandler(this.buttonBrowseSublimeMerge_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(81, 54);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(76, 16);
			this.label2.TabIndex = 0;
			this.label2.Text = "LÖVR path:";
			// 
			// textLovrPath
			// 
			this.textLovrPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textLovrPath.BorderColor = System.Drawing.SystemColors.InactiveBorder;
			this.textLovrPath.BorderColorActive = System.Drawing.SystemColors.ActiveBorder;
			this.textLovrPath.HasBorders = true;
			this.textLovrPath.Location = new System.Drawing.Point(165, 51);
			this.textLovrPath.Margin = new System.Windows.Forms.Padding(4);
			this.textLovrPath.Name = "textLovrPath";
			this.textLovrPath.Size = new System.Drawing.Size(332, 22);
			this.textLovrPath.TabIndex = 0;
			// 
			// buttonBrowseLovr
			// 
			this.buttonBrowseLovr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonBrowseLovr.BackColorDown = System.Drawing.Color.White;
			this.buttonBrowseLovr.BackColorOver = System.Drawing.Color.DarkGray;
			this.buttonBrowseLovr.BackShadeColor = System.Drawing.SystemColors.Control;
			this.buttonBrowseLovr.BackShadeRatio = 0D;
			this.buttonBrowseLovr.BorderColor = System.Drawing.Color.Black;
			this.buttonBrowseLovr.HasBorder = true;
			this.buttonBrowseLovr.Image = null;
			this.buttonBrowseLovr.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonBrowseLovr.ImagePadding = 3;
			this.buttonBrowseLovr.Location = new System.Drawing.Point(505, 50);
			this.buttonBrowseLovr.Margin = new System.Windows.Forms.Padding(5);
			this.buttonBrowseLovr.Name = "buttonBrowseLovr";
			this.buttonBrowseLovr.Size = new System.Drawing.Size(99, 28);
			this.buttonBrowseLovr.TabIndex = 1;
			this.buttonBrowseLovr.Text = "Browse...";
			this.buttonBrowseLovr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonBrowseLovr.TextImageRelation = Nimble.Controls.FlatControls.FlatTextImageRelation.Normal;
			this.buttonBrowseLovr.TextPadding = 3;
			this.buttonBrowseLovr.Click += new System.EventHandler(this.buttonBrowseLovr_Click);
			// 
			// FormSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(617, 293);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonBrowseSublimeMerge);
			this.Controls.Add(this.buttonBrowseEditor);
			this.Controls.Add(this.buttonBrowseProjects);
			this.Controls.Add(this.textSublimeMergePath);
			this.Controls.Add(this.textEditorPath);
			this.Controls.Add(this.textProjectsPath);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.buttonBrowseLovr);
			this.Controls.Add(this.buttonBrowseLove);
			this.Controls.Add(this.textLovrPath);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textLovePath);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4);
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
		private System.Windows.Forms.Label label2;
		private Nimble.Controls.ExtendedTextBox textLovrPath;
		private Nimble.Controls.FlatControls.FlatButton buttonBrowseLovr;
	}
}