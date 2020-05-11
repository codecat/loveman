namespace Loveman
{
	partial class FormNewProject
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNewProject));
			this.buttonOK = new Nimble.Controls.FlatControls.FlatButton();
			this.buttonCancel = new Nimble.Controls.FlatControls.FlatButton();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.textProjectBundleIdentifier = new Nimble.Controls.ExtendedTextBox();
			this.textProjectAuthor = new Nimble.Controls.ExtendedTextBox();
			this.textProjectName = new Nimble.Controls.ExtendedTextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.labelCreatedPath = new System.Windows.Forms.Label();
			this.radioLovr = new System.Windows.Forms.RadioButton();
			this.radioLove2D = new System.Windows.Forms.RadioButton();
			this.flatGroupBox1 = new Nimble.Controls.FlatControls.FlatGroupBox();
			this.flatGroupBox1.SuspendLayout();
			this.SuspendLayout();
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
			this.buttonOK.Location = new System.Drawing.Point(295, 239);
			this.buttonOK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(115, 28);
			this.buttonOK.TabIndex = 3;
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
			this.buttonCancel.Location = new System.Drawing.Point(417, 239);
			this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(115, 28);
			this.buttonCancel.TabIndex = 4;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.buttonCancel.TextImageRelation = Nimble.Controls.FlatControls.FlatTextImageRelation.Normal;
			this.buttonCancel.TextPadding = 3;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(20, 82);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(106, 16);
			this.label3.TabIndex = 11;
			this.label3.Text = "Bundle identifier:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(79, 50);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(49, 16);
			this.label2.TabIndex = 12;
			this.label2.Text = "Author:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(83, 18);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 16);
			this.label1.TabIndex = 13;
			this.label1.Text = "Name:";
			// 
			// textProjectBundleIdentifier
			// 
			this.textProjectBundleIdentifier.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textProjectBundleIdentifier.BorderColor = System.Drawing.SystemColors.InactiveBorder;
			this.textProjectBundleIdentifier.BorderColorActive = System.Drawing.SystemColors.ActiveBorder;
			this.textProjectBundleIdentifier.HasBorders = true;
			this.textProjectBundleIdentifier.Location = new System.Drawing.Point(141, 79);
			this.textProjectBundleIdentifier.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.textProjectBundleIdentifier.Name = "textProjectBundleIdentifier";
			this.textProjectBundleIdentifier.Size = new System.Drawing.Size(389, 22);
			this.textProjectBundleIdentifier.TabIndex = 2;
			this.textProjectBundleIdentifier.Text = "com.example.game";
			// 
			// textProjectAuthor
			// 
			this.textProjectAuthor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textProjectAuthor.BorderColor = System.Drawing.SystemColors.InactiveBorder;
			this.textProjectAuthor.BorderColorActive = System.Drawing.SystemColors.ActiveBorder;
			this.textProjectAuthor.HasBorders = true;
			this.textProjectAuthor.Location = new System.Drawing.Point(141, 47);
			this.textProjectAuthor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.textProjectAuthor.Name = "textProjectAuthor";
			this.textProjectAuthor.Size = new System.Drawing.Size(389, 22);
			this.textProjectAuthor.TabIndex = 1;
			this.textProjectAuthor.Text = "Unknown";
			// 
			// textProjectName
			// 
			this.textProjectName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textProjectName.BorderColor = System.Drawing.SystemColors.InactiveBorder;
			this.textProjectName.BorderColorActive = System.Drawing.SystemColors.ActiveBorder;
			this.textProjectName.HasBorders = true;
			this.textProjectName.Location = new System.Drawing.Point(141, 15);
			this.textProjectName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.textProjectName.Name = "textProjectName";
			this.textProjectName.Size = new System.Drawing.Size(389, 22);
			this.textProjectName.TabIndex = 0;
			this.textProjectName.TextChanged += new System.EventHandler(this.textProjectName_TextChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(39, 114);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(88, 16);
			this.label4.TabIndex = 14;
			this.label4.Text = "Created path:";
			// 
			// labelCreatedPath
			// 
			this.labelCreatedPath.AutoSize = true;
			this.labelCreatedPath.Location = new System.Drawing.Point(137, 114);
			this.labelCreatedPath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelCreatedPath.Name = "labelCreatedPath";
			this.labelCreatedPath.Size = new System.Drawing.Size(17, 16);
			this.labelCreatedPath.TabIndex = 15;
			this.labelCreatedPath.Text = "...";
			// 
			// radioLovr
			// 
			this.radioLovr.AutoSize = true;
			this.radioLovr.Location = new System.Drawing.Point(8, 54);
			this.radioLovr.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.radioLovr.Name = "radioLovr";
			this.radioLovr.Size = new System.Drawing.Size(118, 20);
			this.radioLovr.TabIndex = 0;
			this.radioLovr.Text = "LÖVR (lovr.org)";
			this.radioLovr.UseVisualStyleBackColor = true;
			// 
			// radioLove2D
			// 
			this.radioLove2D.AutoSize = true;
			this.radioLove2D.Checked = true;
			this.radioLove2D.Location = new System.Drawing.Point(8, 26);
			this.radioLove2D.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.radioLove2D.Name = "radioLove2D";
			this.radioLove2D.Size = new System.Drawing.Size(136, 20);
			this.radioLove2D.TabIndex = 0;
			this.radioLove2D.TabStop = true;
			this.radioLove2D.Text = "LÖVE (love2d.org)";
			this.radioLove2D.UseVisualStyleBackColor = true;
			// 
			// flatGroupBox1
			// 
			this.flatGroupBox1.BorderColor = System.Drawing.Color.Black;
			this.flatGroupBox1.Controls.Add(this.radioLovr);
			this.flatGroupBox1.Controls.Add(this.radioLove2D);
			this.flatGroupBox1.HasBorders = true;
			this.flatGroupBox1.LeftPadding = 10;
			this.flatGroupBox1.Location = new System.Drawing.Point(141, 134);
			this.flatGroupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.flatGroupBox1.Name = "flatGroupBox1";
			this.flatGroupBox1.Size = new System.Drawing.Size(391, 89);
			this.flatGroupBox1.TabIndex = 17;
			this.flatGroupBox1.Text = "Project type";
			this.flatGroupBox1.TextPadding = 2;
			this.flatGroupBox1.Title = "Project type";
			this.flatGroupBox1.TopPadding = 10;
			// 
			// FormNewProject
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(548, 282);
			this.Controls.Add(this.flatGroupBox1);
			this.Controls.Add(this.labelCreatedPath);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textProjectBundleIdentifier);
			this.Controls.Add(this.textProjectAuthor);
			this.Controls.Add(this.textProjectName);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.buttonCancel);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormNewProject";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "New project";
			this.flatGroupBox1.ResumeLayout(false);
			this.flatGroupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Nimble.Controls.FlatControls.FlatButton buttonOK;
		private Nimble.Controls.FlatControls.FlatButton buttonCancel;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private Nimble.Controls.ExtendedTextBox textProjectBundleIdentifier;
		private Nimble.Controls.ExtendedTextBox textProjectAuthor;
		private Nimble.Controls.ExtendedTextBox textProjectName;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label labelCreatedPath;
		private System.Windows.Forms.RadioButton radioLovr;
		private System.Windows.Forms.RadioButton radioLove2D;
		private Nimble.Controls.FlatControls.FlatGroupBox flatGroupBox1;
	}
}