namespace NEAProject
{
	partial class Menu
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
			if (disposing && (components != null))
			{
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
			this.ListAvailableButton = new System.Windows.Forms.Button();
			this.SQLNameInput = new System.Windows.Forms.TextBox();
			this.menuTabs = new System.Windows.Forms.TabControl();
			this.printTab = new System.Windows.Forms.TabPage();
			this.AvailableInSQLList = new System.Windows.Forms.Label();
			this.StartPaintButton = new System.Windows.Forms.Button();
			this.OutputTextLabelPrintTab = new System.Windows.Forms.Label();
			this.PaintingProgressBar = new System.Windows.Forms.ProgressBar();
			this.loadTab = new System.Windows.Forms.TabPage();
			this.OutputTextLabelLoadTab = new System.Windows.Forms.Label();
			this.SavingProgressBar = new System.Windows.Forms.ProgressBar();
			this.PreviewImageBox = new System.Windows.Forms.PictureBox();
			this.SaveNameInput = new System.Windows.Forms.TextBox();
			this.PreviewButton = new System.Windows.Forms.Button();
			this.StartSaveButton = new System.Windows.Forms.Button();
			this.FileSourceInput = new System.Windows.Forms.TextBox();
			this.dbTab = new System.Windows.Forms.TabPage();
			this.checkDBButton = new System.Windows.Forms.Button();
			this.OutputTextLabelDBTab = new System.Windows.Forms.Label();
			this.clearDBButton = new System.Windows.Forms.Button();
			this.resetDBButton = new System.Windows.Forms.Button();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuTabs.SuspendLayout();
			this.printTab.SuspendLayout();
			this.loadTab.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.PreviewImageBox)).BeginInit();
			this.dbTab.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// ListAvailableButton
			// 
			this.ListAvailableButton.Location = new System.Drawing.Point(41, 74);
			this.ListAvailableButton.Name = "ListAvailableButton";
			this.ListAvailableButton.Size = new System.Drawing.Size(112, 23);
			this.ListAvailableButton.TabIndex = 5;
			this.ListAvailableButton.Text = "List Available";
			this.ListAvailableButton.UseVisualStyleBackColor = true;
			this.ListAvailableButton.Click += new System.EventHandler(this.ListAvilableButton_Click);
			// 
			// SQLNameInput
			// 
			this.SQLNameInput.Location = new System.Drawing.Point(6, 6);
			this.SQLNameInput.Name = "SQLNameInput";
			this.SQLNameInput.Size = new System.Drawing.Size(185, 20);
			this.SQLNameInput.TabIndex = 4;
			this.SQLNameInput.Text = "SQL Save Name";
			// 
			// menuTabs
			// 
			this.menuTabs.Controls.Add(this.printTab);
			this.menuTabs.Controls.Add(this.loadTab);
			this.menuTabs.Controls.Add(this.dbTab);
			this.menuTabs.Location = new System.Drawing.Point(12, 27);
			this.menuTabs.Name = "menuTabs";
			this.menuTabs.SelectedIndex = 0;
			this.menuTabs.Size = new System.Drawing.Size(418, 206);
			this.menuTabs.TabIndex = 7;
			// 
			// printTab
			// 
			this.printTab.Controls.Add(this.AvailableInSQLList);
			this.printTab.Controls.Add(this.StartPaintButton);
			this.printTab.Controls.Add(this.OutputTextLabelPrintTab);
			this.printTab.Controls.Add(this.PaintingProgressBar);
			this.printTab.Controls.Add(this.SQLNameInput);
			this.printTab.Controls.Add(this.ListAvailableButton);
			this.printTab.Location = new System.Drawing.Point(4, 22);
			this.printTab.Name = "printTab";
			this.printTab.Padding = new System.Windows.Forms.Padding(3);
			this.printTab.Size = new System.Drawing.Size(410, 180);
			this.printTab.TabIndex = 0;
			this.printTab.Text = "Print From Database";
			this.printTab.UseVisualStyleBackColor = true;
			// 
			// AvailableInSQLList
			// 
			this.AvailableInSQLList.AutoSize = true;
			this.AvailableInSQLList.Location = new System.Drawing.Point(197, 6);
			this.AvailableInSQLList.Name = "AvailableInSQLList";
			this.AvailableInSQLList.Size = new System.Drawing.Size(53, 13);
			this.AvailableInSQLList.TabIndex = 15;
			this.AvailableInSQLList.Text = "Available:";
			this.AvailableInSQLList.Visible = false;
			// 
			// StartPaintButton
			// 
			this.StartPaintButton.Location = new System.Drawing.Point(41, 103);
			this.StartPaintButton.Name = "StartPaintButton";
			this.StartPaintButton.Size = new System.Drawing.Size(112, 23);
			this.StartPaintButton.TabIndex = 14;
			this.StartPaintButton.Text = "Start Process";
			this.StartPaintButton.UseVisualStyleBackColor = true;
			this.StartPaintButton.Click += new System.EventHandler(this.StartPaintButton_Click);
			// 
			// OutputTextLabelPrintTab
			// 
			this.OutputTextLabelPrintTab.AutoSize = true;
			this.OutputTextLabelPrintTab.Location = new System.Drawing.Point(6, 151);
			this.OutputTextLabelPrintTab.Name = "OutputTextLabelPrintTab";
			this.OutputTextLabelPrintTab.Size = new System.Drawing.Size(81, 13);
			this.OutputTextLabelPrintTab.TabIndex = 13;
			this.OutputTextLabelPrintTab.Text = "output text here";
			this.OutputTextLabelPrintTab.Visible = false;
			// 
			// PaintingProgressBar
			// 
			this.PaintingProgressBar.Location = new System.Drawing.Point(6, 151);
			this.PaintingProgressBar.Name = "PaintingProgressBar";
			this.PaintingProgressBar.Size = new System.Drawing.Size(185, 23);
			this.PaintingProgressBar.TabIndex = 12;
			this.PaintingProgressBar.Visible = false;
			// 
			// loadTab
			// 
			this.loadTab.Controls.Add(this.OutputTextLabelLoadTab);
			this.loadTab.Controls.Add(this.SavingProgressBar);
			this.loadTab.Controls.Add(this.PreviewImageBox);
			this.loadTab.Controls.Add(this.SaveNameInput);
			this.loadTab.Controls.Add(this.PreviewButton);
			this.loadTab.Controls.Add(this.StartSaveButton);
			this.loadTab.Controls.Add(this.FileSourceInput);
			this.loadTab.Location = new System.Drawing.Point(4, 22);
			this.loadTab.Name = "loadTab";
			this.loadTab.Padding = new System.Windows.Forms.Padding(3);
			this.loadTab.Size = new System.Drawing.Size(410, 180);
			this.loadTab.TabIndex = 1;
			this.loadTab.Text = "Load from File";
			this.loadTab.UseVisualStyleBackColor = true;
			// 
			// OutputTextLabelLoadTab
			// 
			this.OutputTextLabelLoadTab.AutoSize = true;
			this.OutputTextLabelLoadTab.Location = new System.Drawing.Point(6, 151);
			this.OutputTextLabelLoadTab.Name = "OutputTextLabelLoadTab";
			this.OutputTextLabelLoadTab.Size = new System.Drawing.Size(81, 13);
			this.OutputTextLabelLoadTab.TabIndex = 11;
			this.OutputTextLabelLoadTab.Text = "output text here";
			this.OutputTextLabelLoadTab.Visible = false;
			// 
			// SavingProgressBar
			// 
			this.SavingProgressBar.Location = new System.Drawing.Point(6, 151);
			this.SavingProgressBar.Name = "SavingProgressBar";
			this.SavingProgressBar.Size = new System.Drawing.Size(185, 23);
			this.SavingProgressBar.TabIndex = 10;
			this.SavingProgressBar.Visible = false;
			// 
			// PreviewImageBox
			// 
			this.PreviewImageBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.PreviewImageBox.Location = new System.Drawing.Point(197, 6);
			this.PreviewImageBox.Name = "PreviewImageBox";
			this.PreviewImageBox.Size = new System.Drawing.Size(168, 168);
			this.PreviewImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.PreviewImageBox.TabIndex = 9;
			this.PreviewImageBox.TabStop = false;
			// 
			// SaveNameInput
			// 
			this.SaveNameInput.Location = new System.Drawing.Point(6, 32);
			this.SaveNameInput.Name = "SaveNameInput";
			this.SaveNameInput.Size = new System.Drawing.Size(185, 20);
			this.SaveNameInput.TabIndex = 8;
			this.SaveNameInput.Text = "Save Name";
			this.SaveNameInput.TextChanged += new System.EventHandler(this.SaveNameInput_TextChanged);
			// 
			// PreviewButton
			// 
			this.PreviewButton.Location = new System.Drawing.Point(41, 74);
			this.PreviewButton.Name = "PreviewButton";
			this.PreviewButton.Size = new System.Drawing.Size(112, 23);
			this.PreviewButton.TabIndex = 7;
			this.PreviewButton.Text = "Preview Image";
			this.PreviewButton.UseVisualStyleBackColor = true;
			this.PreviewButton.Click += new System.EventHandler(this.PreviewButton_Click);
			// 
			// StartSaveButton
			// 
			this.StartSaveButton.Location = new System.Drawing.Point(41, 103);
			this.StartSaveButton.Name = "StartSaveButton";
			this.StartSaveButton.Size = new System.Drawing.Size(112, 23);
			this.StartSaveButton.TabIndex = 6;
			this.StartSaveButton.Text = "Start Process";
			this.StartSaveButton.UseVisualStyleBackColor = true;
			this.StartSaveButton.Click += new System.EventHandler(this.StartSaveButton_Click);
			// 
			// FileSourceInput
			// 
			this.FileSourceInput.Location = new System.Drawing.Point(6, 6);
			this.FileSourceInput.Name = "FileSourceInput";
			this.FileSourceInput.Size = new System.Drawing.Size(185, 20);
			this.FileSourceInput.TabIndex = 5;
			this.FileSourceInput.Text = "File Source";
			this.FileSourceInput.TextChanged += new System.EventHandler(this.FileSourceInput_TextChanged);
			// 
			// dbTab
			// 
			this.dbTab.Controls.Add(this.checkDBButton);
			this.dbTab.Controls.Add(this.OutputTextLabelDBTab);
			this.dbTab.Controls.Add(this.clearDBButton);
			this.dbTab.Controls.Add(this.resetDBButton);
			this.dbTab.Location = new System.Drawing.Point(4, 22);
			this.dbTab.Name = "dbTab";
			this.dbTab.Size = new System.Drawing.Size(410, 180);
			this.dbTab.TabIndex = 2;
			this.dbTab.Text = "Database Control";
			this.dbTab.UseVisualStyleBackColor = true;
			// 
			// checkDBButton
			// 
			this.checkDBButton.Location = new System.Drawing.Point(6, 64);
			this.checkDBButton.Name = "checkDBButton";
			this.checkDBButton.Size = new System.Drawing.Size(201, 23);
			this.checkDBButton.TabIndex = 13;
			this.checkDBButton.Text = "Check Database Content";
			this.checkDBButton.UseVisualStyleBackColor = true;
			this.checkDBButton.Click += new System.EventHandler(this.checkDBButton_Click);
			// 
			// OutputTextLabelDBTab
			// 
			this.OutputTextLabelDBTab.AutoSize = true;
			this.OutputTextLabelDBTab.Location = new System.Drawing.Point(3, 151);
			this.OutputTextLabelDBTab.Name = "OutputTextLabelDBTab";
			this.OutputTextLabelDBTab.Size = new System.Drawing.Size(81, 13);
			this.OutputTextLabelDBTab.TabIndex = 12;
			this.OutputTextLabelDBTab.Text = "output text here";
			this.OutputTextLabelDBTab.Visible = false;
			// 
			// clearDBButton
			// 
			this.clearDBButton.Location = new System.Drawing.Point(6, 35);
			this.clearDBButton.Name = "clearDBButton";
			this.clearDBButton.Size = new System.Drawing.Size(201, 23);
			this.clearDBButton.TabIndex = 1;
			this.clearDBButton.Text = "Clear All from Database";
			this.clearDBButton.UseVisualStyleBackColor = true;
			this.clearDBButton.Click += new System.EventHandler(this.clearDBButton_Click);
			// 
			// resetDBButton
			// 
			this.resetDBButton.Location = new System.Drawing.Point(6, 6);
			this.resetDBButton.Name = "resetDBButton";
			this.resetDBButton.Size = new System.Drawing.Size(201, 23);
			this.resetDBButton.TabIndex = 0;
			this.resetDBButton.Text = "Delete and Recreate Database";
			this.resetDBButton.UseVisualStyleBackColor = true;
			this.resetDBButton.Click += new System.EventHandler(this.resetDBButton_Click);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(442, 24);
			this.menuStrip1.TabIndex = 8;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// optionsToolStripMenuItem
			// 
			this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
			this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
			this.optionsToolStripMenuItem.Text = "Options";
			this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.helpToolStripMenuItem.Text = "Help";
			this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
			// 
			// Menu
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(442, 245);
			this.Controls.Add(this.menuTabs);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Menu";
			this.Text = "MACK2 - Menu";
			this.menuTabs.ResumeLayout(false);
			this.printTab.ResumeLayout(false);
			this.printTab.PerformLayout();
			this.loadTab.ResumeLayout(false);
			this.loadTab.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.PreviewImageBox)).EndInit();
			this.dbTab.ResumeLayout(false);
			this.dbTab.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button ListAvailableButton;
		private System.Windows.Forms.TextBox SQLNameInput;
		private System.Windows.Forms.TabControl menuTabs;
		private System.Windows.Forms.TabPage printTab;
		private System.Windows.Forms.TabPage loadTab;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.PictureBox PreviewImageBox;
		private System.Windows.Forms.TextBox SaveNameInput;
		private System.Windows.Forms.Button PreviewButton;
		private System.Windows.Forms.Button StartSaveButton;
		private System.Windows.Forms.TextBox FileSourceInput;
		private System.Windows.Forms.ProgressBar SavingProgressBar;
		private System.Windows.Forms.Label OutputTextLabelLoadTab;
		private System.Windows.Forms.TabPage dbTab;
		private System.Windows.Forms.Button clearDBButton;
		private System.Windows.Forms.Button resetDBButton;
		private System.Windows.Forms.Label OutputTextLabelDBTab;
		private System.Windows.Forms.Button checkDBButton;
		private System.Windows.Forms.Label AvailableInSQLList;
		private System.Windows.Forms.Button StartPaintButton;
		private System.Windows.Forms.Label OutputTextLabelPrintTab;
		private System.Windows.Forms.ProgressBar PaintingProgressBar;
	}
}