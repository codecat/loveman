namespace Loveman
{
	partial class FormProject
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProject));
			this.groupMoonscript = new Nimble.Controls.FlatControls.FlatGroupBox();
			this.listChanges = new Nimble.Controls.FlatControls.FlatList();
			this.checkWatchForChanges = new System.Windows.Forms.CheckBox();
			this.buttonBuildScripts = new Nimble.Controls.FlatControls.FlatButton();
			this.flatGroupBox1 = new Nimble.Controls.FlatControls.FlatGroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.textGameIcon = new Nimble.Controls.ExtendedTextBox();
			this.textProjectBundleIdentifier = new Nimble.Controls.ExtendedTextBox();
			this.textProjectAuthor = new Nimble.Controls.ExtendedTextBox();
			this.textProjectName = new Nimble.Controls.ExtendedTextBox();
			this.buttonCancel = new Nimble.Controls.FlatControls.FlatButton();
			this.buttonSave = new Nimble.Controls.FlatControls.FlatButton();
			this.buttonSublimeMerge = new Nimble.Controls.FlatControls.FlatButton();
			this.buttonBuildRelease = new Nimble.Controls.FlatControls.FlatButton();
			this.buttonSublime = new Nimble.Controls.FlatControls.FlatButton();
			this.buttonFolder = new Nimble.Controls.FlatControls.FlatButton();
			this.buttonStartConsole = new Nimble.Controls.FlatControls.FlatButton();
			this.buttonStart = new Nimble.Controls.FlatControls.FlatButton();
			this.flowButtons = new System.Windows.Forms.FlowLayoutPanel();
			this.groupMoonscript.SuspendLayout();
			this.flatGroupBox1.SuspendLayout();
			this.flowButtons.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupMoonscript
			// 
			this.groupMoonscript.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupMoonscript.BorderColor = System.Drawing.Color.Black;
			this.groupMoonscript.Controls.Add(this.listChanges);
			this.groupMoonscript.Controls.Add(this.checkWatchForChanges);
			this.groupMoonscript.Controls.Add(this.buttonBuildScripts);
			this.groupMoonscript.HasBorders = true;
			this.groupMoonscript.LeftPadding = 10;
			this.groupMoonscript.Location = new System.Drawing.Point(140, 174);
			this.groupMoonscript.Name = "groupMoonscript";
			this.groupMoonscript.Size = new System.Drawing.Size(326, 187);
			this.groupMoonscript.TabIndex = 4;
			this.groupMoonscript.Text = "Moonscript";
			this.groupMoonscript.TextPadding = 2;
			this.groupMoonscript.Title = "Moonscript";
			this.groupMoonscript.TopPadding = 10;
			// 
			// listChanges
			// 
			this.listChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listChanges.AutoScroll = true;
			this.listChanges.AutoScrollMinSize = new System.Drawing.Size(1, 0);
			this.listChanges.BorderColor = System.Drawing.Color.Black;
			this.listChanges.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.listChanges.CheckboxStyle = false;
			this.listChanges.ClickDeselects = true;
			this.listChanges.FontSub = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.listChanges.ForeColorSub = System.Drawing.Color.Gray;
			this.listChanges.HoverColor = System.Drawing.Color.LightGray;
			this.listChanges.HoverIndex = -1;
			this.listChanges.HoverVisible = true;
			this.listChanges.ItemHeight = 32;
			this.listChanges.ItemImageSize = 16;
			this.listChanges.ItemPaddingX = 4;
			this.listChanges.ItemPaddingY = 2;
			this.listChanges.Location = new System.Drawing.Point(6, 46);
			this.listChanges.MultiSelect = false;
			this.listChanges.Name = "listChanges";
			this.listChanges.SelectionColor = System.Drawing.Color.LightBlue;
			this.listChanges.SelectionTextColor = System.Drawing.Color.Black;
			this.listChanges.Size = new System.Drawing.Size(314, 138);
			this.listChanges.SubItemIndicator = true;
			this.listChanges.TabIndex = 1;
			this.listChanges.Text = "flatList1";
			this.listChanges.DoubleClick += new System.EventHandler(this.listChanges_DoubleClick);
			// 
			// checkWatchForChanges
			// 
			this.checkWatchForChanges.AutoSize = true;
			this.checkWatchForChanges.Checked = true;
			this.checkWatchForChanges.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkWatchForChanges.Location = new System.Drawing.Point(6, 21);
			this.checkWatchForChanges.Name = "checkWatchForChanges";
			this.checkWatchForChanges.Size = new System.Drawing.Size(117, 17);
			this.checkWatchForChanges.TabIndex = 0;
			this.checkWatchForChanges.Text = "Watch for changes";
			this.checkWatchForChanges.UseVisualStyleBackColor = true;
			this.checkWatchForChanges.CheckedChanged += new System.EventHandler(this.checkWatchForChanges_CheckedChanged);
			// 
			// buttonBuildScripts
			// 
			this.buttonBuildScripts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonBuildScripts.BackColorDown = System.Drawing.Color.White;
			this.buttonBuildScripts.BackColorOver = System.Drawing.Color.DarkGray;
			this.buttonBuildScripts.BackShadeColor = System.Drawing.SystemColors.Control;
			this.buttonBuildScripts.BackShadeRatio = 0D;
			this.buttonBuildScripts.BorderColor = System.Drawing.Color.Black;
			this.buttonBuildScripts.HasBorder = true;
			this.buttonBuildScripts.Image = global::Loveman.Properties.Resources.plugin;
			this.buttonBuildScripts.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.buttonBuildScripts.ImagePadding = 3;
			this.buttonBuildScripts.Location = new System.Drawing.Point(220, 17);
			this.buttonBuildScripts.Name = "buttonBuildScripts";
			this.buttonBuildScripts.Size = new System.Drawing.Size(100, 23);
			this.buttonBuildScripts.TabIndex = 3;
			this.buttonBuildScripts.Text = "Build scripts";
			this.buttonBuildScripts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonBuildScripts.TextImageRelation = Nimble.Controls.FlatControls.FlatTextImageRelation.Normal;
			this.buttonBuildScripts.TextPadding = 3;
			this.buttonBuildScripts.Click += new System.EventHandler(this.buttonBuildScripts_Click);
			// 
			// flatGroupBox1
			// 
			this.flatGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.flatGroupBox1.BorderColor = System.Drawing.Color.Black;
			this.flatGroupBox1.Controls.Add(this.label4);
			this.flatGroupBox1.Controls.Add(this.label3);
			this.flatGroupBox1.Controls.Add(this.label2);
			this.flatGroupBox1.Controls.Add(this.label1);
			this.flatGroupBox1.Controls.Add(this.textGameIcon);
			this.flatGroupBox1.Controls.Add(this.textProjectBundleIdentifier);
			this.flatGroupBox1.Controls.Add(this.textProjectAuthor);
			this.flatGroupBox1.Controls.Add(this.textProjectName);
			this.flatGroupBox1.Controls.Add(this.buttonCancel);
			this.flatGroupBox1.Controls.Add(this.buttonSave);
			this.flatGroupBox1.HasBorders = true;
			this.flatGroupBox1.LeftPadding = 10;
			this.flatGroupBox1.Location = new System.Drawing.Point(140, 12);
			this.flatGroupBox1.Name = "flatGroupBox1";
			this.flatGroupBox1.Size = new System.Drawing.Size(326, 156);
			this.flatGroupBox1.TabIndex = 1;
			this.flatGroupBox1.Text = "Settings";
			this.flatGroupBox1.TextPadding = 2;
			this.flatGroupBox1.Title = "Project info";
			this.flatGroupBox1.TopPadding = 10;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(31, 102);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(61, 13);
			this.label4.TabIndex = 2;
			this.label4.Text = "Game icon:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(7, 76);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(85, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "Bundle identifier:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(51, 50);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(41, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Author:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(54, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(38, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Name:";
			// 
			// textGameIcon
			// 
			this.textGameIcon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textGameIcon.BorderColor = System.Drawing.SystemColors.InactiveBorder;
			this.textGameIcon.BorderColorActive = System.Drawing.SystemColors.ActiveBorder;
			this.textGameIcon.HasBorders = true;
			this.textGameIcon.Location = new System.Drawing.Point(98, 99);
			this.textGameIcon.Name = "textGameIcon";
			this.textGameIcon.Size = new System.Drawing.Size(222, 20);
			this.textGameIcon.TabIndex = 2;
			this.textGameIcon.TextChanged += new System.EventHandler(this.textProjectInfo_TextChanged);
			// 
			// textProjectBundleIdentifier
			// 
			this.textProjectBundleIdentifier.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textProjectBundleIdentifier.BorderColor = System.Drawing.SystemColors.InactiveBorder;
			this.textProjectBundleIdentifier.BorderColorActive = System.Drawing.SystemColors.ActiveBorder;
			this.textProjectBundleIdentifier.HasBorders = true;
			this.textProjectBundleIdentifier.Location = new System.Drawing.Point(98, 73);
			this.textProjectBundleIdentifier.Name = "textProjectBundleIdentifier";
			this.textProjectBundleIdentifier.Size = new System.Drawing.Size(222, 20);
			this.textProjectBundleIdentifier.TabIndex = 2;
			this.textProjectBundleIdentifier.TextChanged += new System.EventHandler(this.textProjectInfo_TextChanged);
			// 
			// textProjectAuthor
			// 
			this.textProjectAuthor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textProjectAuthor.BorderColor = System.Drawing.SystemColors.InactiveBorder;
			this.textProjectAuthor.BorderColorActive = System.Drawing.SystemColors.ActiveBorder;
			this.textProjectAuthor.HasBorders = true;
			this.textProjectAuthor.Location = new System.Drawing.Point(98, 47);
			this.textProjectAuthor.Name = "textProjectAuthor";
			this.textProjectAuthor.Size = new System.Drawing.Size(222, 20);
			this.textProjectAuthor.TabIndex = 1;
			this.textProjectAuthor.TextChanged += new System.EventHandler(this.textProjectInfo_TextChanged);
			// 
			// textProjectName
			// 
			this.textProjectName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textProjectName.BorderColor = System.Drawing.SystemColors.InactiveBorder;
			this.textProjectName.BorderColorActive = System.Drawing.SystemColors.ActiveBorder;
			this.textProjectName.HasBorders = true;
			this.textProjectName.Location = new System.Drawing.Point(98, 21);
			this.textProjectName.Name = "textProjectName";
			this.textProjectName.Size = new System.Drawing.Size(222, 20);
			this.textProjectName.TabIndex = 0;
			this.textProjectName.TextChanged += new System.EventHandler(this.textProjectInfo_TextChanged);
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
			this.buttonCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.buttonCancel.ImagePadding = 3;
			this.buttonCancel.Location = new System.Drawing.Point(238, 130);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(82, 23);
			this.buttonCancel.TabIndex = 4;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonCancel.TextImageRelation = Nimble.Controls.FlatControls.FlatTextImageRelation.Normal;
			this.buttonCancel.TextPadding = 3;
			this.buttonCancel.Visible = false;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// buttonSave
			// 
			this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSave.BackColorDown = System.Drawing.Color.White;
			this.buttonSave.BackColorOver = System.Drawing.Color.DarkGray;
			this.buttonSave.BackShadeColor = System.Drawing.SystemColors.Control;
			this.buttonSave.BackShadeRatio = 0D;
			this.buttonSave.BorderColor = System.Drawing.Color.Black;
			this.buttonSave.HasBorder = true;
			this.buttonSave.Image = global::Loveman.Properties.Resources.disk;
			this.buttonSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.buttonSave.ImagePadding = 3;
			this.buttonSave.Location = new System.Drawing.Point(150, 130);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(82, 23);
			this.buttonSave.TabIndex = 3;
			this.buttonSave.Text = "Save";
			this.buttonSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonSave.TextImageRelation = Nimble.Controls.FlatControls.FlatTextImageRelation.Normal;
			this.buttonSave.TextPadding = 3;
			this.buttonSave.Visible = false;
			this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
			// 
			// buttonSublimeMerge
			// 
			this.buttonSublimeMerge.BackColorDown = System.Drawing.Color.White;
			this.buttonSublimeMerge.BackColorOver = System.Drawing.Color.DarkGray;
			this.buttonSublimeMerge.BackShadeColor = System.Drawing.SystemColors.Control;
			this.buttonSublimeMerge.BackShadeRatio = 0D;
			this.buttonSublimeMerge.BorderColor = System.Drawing.Color.Black;
			this.buttonSublimeMerge.HasBorder = true;
			this.buttonSublimeMerge.Image = global::Loveman.Properties.Resources.merge16;
			this.buttonSublimeMerge.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonSublimeMerge.ImagePadding = 3;
			this.buttonSublimeMerge.Location = new System.Drawing.Point(3, 119);
			this.buttonSublimeMerge.Name = "buttonSublimeMerge";
			this.buttonSublimeMerge.Size = new System.Drawing.Size(122, 23);
			this.buttonSublimeMerge.TabIndex = 5;
			this.buttonSublimeMerge.Text = "Sublime Merge";
			this.buttonSublimeMerge.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.buttonSublimeMerge.TextImageRelation = Nimble.Controls.FlatControls.FlatTextImageRelation.Normal;
			this.buttonSublimeMerge.TextPadding = 3;
			this.buttonSublimeMerge.Visible = false;
			this.buttonSublimeMerge.Click += new System.EventHandler(this.buttonSublimeMerge_Click);
			// 
			// buttonBuildRelease
			// 
			this.buttonBuildRelease.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonBuildRelease.BackColorDown = System.Drawing.Color.White;
			this.buttonBuildRelease.BackColorOver = System.Drawing.Color.DarkGray;
			this.buttonBuildRelease.BackShadeColor = System.Drawing.SystemColors.Control;
			this.buttonBuildRelease.BackShadeRatio = 0D;
			this.buttonBuildRelease.BorderColor = System.Drawing.Color.Black;
			this.buttonBuildRelease.HasBorder = true;
			this.buttonBuildRelease.Image = global::Loveman.Properties.Resources.love16;
			this.buttonBuildRelease.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonBuildRelease.ImagePadding = 3;
			this.buttonBuildRelease.Location = new System.Drawing.Point(12, 338);
			this.buttonBuildRelease.Name = "buttonBuildRelease";
			this.buttonBuildRelease.Size = new System.Drawing.Size(122, 23);
			this.buttonBuildRelease.TabIndex = 3;
			this.buttonBuildRelease.Text = "Build release";
			this.buttonBuildRelease.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.buttonBuildRelease.TextImageRelation = Nimble.Controls.FlatControls.FlatTextImageRelation.Normal;
			this.buttonBuildRelease.TextPadding = 3;
			this.buttonBuildRelease.Click += new System.EventHandler(this.buttonBuildRelease_Click);
			// 
			// buttonSublime
			// 
			this.buttonSublime.BackColorDown = System.Drawing.Color.White;
			this.buttonSublime.BackColorOver = System.Drawing.Color.DarkGray;
			this.buttonSublime.BackShadeColor = System.Drawing.SystemColors.Control;
			this.buttonSublime.BackShadeRatio = 0D;
			this.buttonSublime.BorderColor = System.Drawing.Color.Black;
			this.buttonSublime.HasBorder = true;
			this.buttonSublime.Image = global::Loveman.Properties.Resources.sublime16;
			this.buttonSublime.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonSublime.ImagePadding = 3;
			this.buttonSublime.Location = new System.Drawing.Point(3, 90);
			this.buttonSublime.Name = "buttonSublime";
			this.buttonSublime.Size = new System.Drawing.Size(122, 23);
			this.buttonSublime.TabIndex = 2;
			this.buttonSublime.Text = "Sublime Text";
			this.buttonSublime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.buttonSublime.TextImageRelation = Nimble.Controls.FlatControls.FlatTextImageRelation.Normal;
			this.buttonSublime.TextPadding = 3;
			this.buttonSublime.Visible = false;
			this.buttonSublime.Click += new System.EventHandler(this.buttonSublime_Click);
			// 
			// buttonFolder
			// 
			this.buttonFolder.BackColorDown = System.Drawing.Color.White;
			this.buttonFolder.BackColorOver = System.Drawing.Color.DarkGray;
			this.buttonFolder.BackShadeColor = System.Drawing.SystemColors.Control;
			this.buttonFolder.BackShadeRatio = 0D;
			this.buttonFolder.BorderColor = System.Drawing.Color.Black;
			this.buttonFolder.HasBorder = true;
			this.buttonFolder.Image = global::Loveman.Properties.Resources.folder;
			this.buttonFolder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonFolder.ImagePadding = 3;
			this.buttonFolder.Location = new System.Drawing.Point(3, 61);
			this.buttonFolder.Name = "buttonFolder";
			this.buttonFolder.Size = new System.Drawing.Size(122, 23);
			this.buttonFolder.TabIndex = 2;
			this.buttonFolder.Text = "Open folder";
			this.buttonFolder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.buttonFolder.TextImageRelation = Nimble.Controls.FlatControls.FlatTextImageRelation.Normal;
			this.buttonFolder.TextPadding = 3;
			this.buttonFolder.Click += new System.EventHandler(this.buttonFolder_Click);
			// 
			// buttonStartConsole
			// 
			this.buttonStartConsole.BackColorDown = System.Drawing.Color.White;
			this.buttonStartConsole.BackColorOver = System.Drawing.Color.DarkGray;
			this.buttonStartConsole.BackShadeColor = System.Drawing.SystemColors.Control;
			this.buttonStartConsole.BackShadeRatio = 0D;
			this.buttonStartConsole.BorderColor = System.Drawing.Color.Black;
			this.buttonStartConsole.HasBorder = true;
			this.buttonStartConsole.Image = global::Loveman.Properties.Resources.Console;
			this.buttonStartConsole.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonStartConsole.ImagePadding = 3;
			this.buttonStartConsole.Location = new System.Drawing.Point(3, 32);
			this.buttonStartConsole.Name = "buttonStartConsole";
			this.buttonStartConsole.Size = new System.Drawing.Size(122, 23);
			this.buttonStartConsole.TabIndex = 1;
			this.buttonStartConsole.Text = "Start with console";
			this.buttonStartConsole.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.buttonStartConsole.TextImageRelation = Nimble.Controls.FlatControls.FlatTextImageRelation.Normal;
			this.buttonStartConsole.TextPadding = 3;
			this.buttonStartConsole.Click += new System.EventHandler(this.buttonStartConsole_Click);
			// 
			// buttonStart
			// 
			this.buttonStart.BackColorDown = System.Drawing.Color.White;
			this.buttonStart.BackColorOver = System.Drawing.Color.DarkGray;
			this.buttonStart.BackShadeColor = System.Drawing.SystemColors.Control;
			this.buttonStart.BackShadeRatio = 0D;
			this.buttonStart.BorderColor = System.Drawing.Color.Black;
			this.buttonStart.HasBorder = true;
			this.buttonStart.Image = global::Loveman.Properties.Resources.startwithoutdebugging_6556;
			this.buttonStart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonStart.ImagePadding = 3;
			this.buttonStart.Location = new System.Drawing.Point(3, 3);
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.Size = new System.Drawing.Size(122, 23);
			this.buttonStart.TabIndex = 0;
			this.buttonStart.Text = "Start game";
			this.buttonStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.buttonStart.TextImageRelation = Nimble.Controls.FlatControls.FlatTextImageRelation.Normal;
			this.buttonStart.TextPadding = 3;
			this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
			// 
			// flowButtons
			// 
			this.flowButtons.AutoSize = true;
			this.flowButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flowButtons.Controls.Add(this.buttonStart);
			this.flowButtons.Controls.Add(this.buttonStartConsole);
			this.flowButtons.Controls.Add(this.buttonFolder);
			this.flowButtons.Controls.Add(this.buttonSublime);
			this.flowButtons.Controls.Add(this.buttonSublimeMerge);
			this.flowButtons.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowButtons.Location = new System.Drawing.Point(9, 19);
			this.flowButtons.Name = "flowButtons";
			this.flowButtons.Size = new System.Drawing.Size(128, 145);
			this.flowButtons.TabIndex = 6;
			// 
			// FormProject
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(478, 373);
			this.Controls.Add(this.flowButtons);
			this.Controls.Add(this.groupMoonscript);
			this.Controls.Add(this.flatGroupBox1);
			this.Controls.Add(this.buttonBuildRelease);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FormProject";
			this.Text = "Project";
			this.groupMoonscript.ResumeLayout(false);
			this.groupMoonscript.PerformLayout();
			this.flatGroupBox1.ResumeLayout(false);
			this.flatGroupBox1.PerformLayout();
			this.flowButtons.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Nimble.Controls.FlatControls.FlatButton buttonStart;
		private Nimble.Controls.FlatControls.FlatButton buttonFolder;
		private Nimble.Controls.FlatControls.FlatButton buttonStartConsole;
		private Nimble.Controls.FlatControls.FlatButton buttonBuildRelease;
		private Nimble.Controls.FlatControls.FlatGroupBox flatGroupBox1;
		private Nimble.Controls.FlatControls.FlatButton buttonSave;
		private Nimble.Controls.FlatControls.FlatButton buttonCancel;
		private System.Windows.Forms.Label label1;
		private Nimble.Controls.ExtendedTextBox textProjectName;
		private System.Windows.Forms.Label label2;
		private Nimble.Controls.ExtendedTextBox textProjectBundleIdentifier;
		private Nimble.Controls.ExtendedTextBox textProjectAuthor;
		private System.Windows.Forms.Label label3;
		private Nimble.Controls.FlatControls.FlatGroupBox groupMoonscript;
		private System.Windows.Forms.CheckBox checkWatchForChanges;
		private Nimble.Controls.FlatControls.FlatList listChanges;
		private Nimble.Controls.FlatControls.FlatButton buttonBuildScripts;
		private Nimble.Controls.FlatControls.FlatButton buttonSublime;
		private System.Windows.Forms.Label label4;
		private Nimble.Controls.ExtendedTextBox textGameIcon;
		private Nimble.Controls.FlatControls.FlatButton buttonSublimeMerge;
		private System.Windows.Forms.FlowLayoutPanel flowButtons;
	}
}