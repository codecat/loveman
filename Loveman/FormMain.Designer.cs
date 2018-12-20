namespace Loveman
{
	partial class FormMain
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
			this.listProjects = new Nimble.Controls.FlatControls.FlatList();
			this.buttonNewProject = new Nimble.Controls.FlatControls.FlatButton();
			this.buttonSettings = new Nimble.Controls.FlatControls.FlatButton();
			this.SuspendLayout();
			// 
			// listProjects
			// 
			this.listProjects.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listProjects.AutoScroll = true;
			this.listProjects.AutoScrollMinSize = new System.Drawing.Size(1, 0);
			this.listProjects.BorderColor = System.Drawing.Color.Black;
			this.listProjects.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.listProjects.CheckboxStyle = false;
			this.listProjects.ClickDeselects = true;
			this.listProjects.FontSub = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.listProjects.ForeColorSub = System.Drawing.Color.Gray;
			this.listProjects.HoverColor = System.Drawing.Color.LightGray;
			this.listProjects.HoverIndex = -1;
			this.listProjects.HoverVisible = true;
			this.listProjects.ItemHeight = 32;
			this.listProjects.ItemImageSize = 16;
			this.listProjects.ItemPaddingX = 4;
			this.listProjects.ItemPaddingY = 2;
			this.listProjects.Location = new System.Drawing.Point(12, 12);
			this.listProjects.Name = "listProjects";
			this.listProjects.SelectedIndex = -1;
			this.listProjects.SelectedItem = null;
			this.listProjects.SelectionColor = System.Drawing.Color.LightBlue;
			this.listProjects.SelectionTextColor = System.Drawing.Color.Black;
			this.listProjects.Size = new System.Drawing.Size(266, 246);
			this.listProjects.SubItemIndicator = true;
			this.listProjects.TabIndex = 0;
			this.listProjects.Text = "flatList1";
			this.listProjects.DoubleClick += new System.EventHandler(this.listProjects_DoubleClick);
			// 
			// buttonNewProject
			// 
			this.buttonNewProject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonNewProject.BackColorDown = System.Drawing.Color.White;
			this.buttonNewProject.BackColorOver = System.Drawing.Color.DarkGray;
			this.buttonNewProject.BackShadeColor = System.Drawing.SystemColors.Control;
			this.buttonNewProject.BackShadeRatio = 0D;
			this.buttonNewProject.BorderColor = System.Drawing.Color.Black;
			this.buttonNewProject.HasBorder = true;
			this.buttonNewProject.Image = global::Loveman.Properties.Resources.love16;
			this.buttonNewProject.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonNewProject.ImagePadding = 3;
			this.buttonNewProject.Location = new System.Drawing.Point(12, 264);
			this.buttonNewProject.Name = "buttonNewProject";
			this.buttonNewProject.Size = new System.Drawing.Size(110, 23);
			this.buttonNewProject.TabIndex = 1;
			this.buttonNewProject.Text = "New project";
			this.buttonNewProject.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.buttonNewProject.TextImageRelation = Nimble.Controls.FlatControls.FlatTextImageRelation.Normal;
			this.buttonNewProject.TextPadding = 3;
			this.buttonNewProject.Click += new System.EventHandler(this.buttonNewProject_Click);
			// 
			// buttonSettings
			// 
			this.buttonSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSettings.BackColorDown = System.Drawing.Color.White;
			this.buttonSettings.BackColorOver = System.Drawing.Color.DarkGray;
			this.buttonSettings.BackShadeColor = System.Drawing.SystemColors.Control;
			this.buttonSettings.BackShadeRatio = 0D;
			this.buttonSettings.BorderColor = System.Drawing.Color.Black;
			this.buttonSettings.HasBorder = true;
			this.buttonSettings.Image = global::Loveman.Properties.Resources.cog;
			this.buttonSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.buttonSettings.ImagePadding = 3;
			this.buttonSettings.Location = new System.Drawing.Point(168, 264);
			this.buttonSettings.Name = "buttonSettings";
			this.buttonSettings.Size = new System.Drawing.Size(110, 23);
			this.buttonSettings.TabIndex = 2;
			this.buttonSettings.Text = "Settings";
			this.buttonSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonSettings.TextImageRelation = Nimble.Controls.FlatControls.FlatTextImageRelation.Normal;
			this.buttonSettings.TextPadding = 3;
			this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(290, 299);
			this.Controls.Add(this.listProjects);
			this.Controls.Add(this.buttonNewProject);
			this.Controls.Add(this.buttonSettings);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FormMain";
			this.Text = "LOVE Manager";
			this.ResumeLayout(false);

		}

		#endregion

		private Nimble.Controls.FlatControls.FlatButton buttonSettings;
		private Nimble.Controls.FlatControls.FlatList listProjects;
		private Nimble.Controls.FlatControls.FlatButton buttonNewProject;
	}
}

