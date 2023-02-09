namespace NEAProject
{
	partial class Help
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Help));
			this.menuTabs = new System.Windows.Forms.TabControl();
			this.printTab = new System.Windows.Forms.TabPage();
			this.label1 = new System.Windows.Forms.Label();
			this.loadTab = new System.Windows.Forms.TabPage();
			this.label2 = new System.Windows.Forms.Label();
			this.dbTab = new System.Windows.Forms.TabPage();
			this.label3 = new System.Windows.Forms.Label();
			this.menuTabs.SuspendLayout();
			this.printTab.SuspendLayout();
			this.loadTab.SuspendLayout();
			this.dbTab.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuTabs
			// 
			this.menuTabs.Controls.Add(this.printTab);
			this.menuTabs.Controls.Add(this.loadTab);
			this.menuTabs.Controls.Add(this.dbTab);
			this.menuTabs.Location = new System.Drawing.Point(12, 12);
			this.menuTabs.Name = "menuTabs";
			this.menuTabs.SelectedIndex = 0;
			this.menuTabs.Size = new System.Drawing.Size(452, 296);
			this.menuTabs.TabIndex = 8;
			// 
			// printTab
			// 
			this.printTab.Controls.Add(this.label1);
			this.printTab.Location = new System.Drawing.Point(4, 22);
			this.printTab.Name = "printTab";
			this.printTab.Padding = new System.Windows.Forms.Padding(3);
			this.printTab.Size = new System.Drawing.Size(444, 270);
			this.printTab.TabIndex = 0;
			this.printTab.Text = "Print From Database";
			this.printTab.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 3);
			this.label1.MaximumSize = new System.Drawing.Size(430, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(429, 208);
			this.label1.TabIndex = 0;
			this.label1.Text = resources.GetString("label1.Text");
			// 
			// loadTab
			// 
			this.loadTab.Controls.Add(this.label2);
			this.loadTab.Location = new System.Drawing.Point(4, 22);
			this.loadTab.Name = "loadTab";
			this.loadTab.Padding = new System.Windows.Forms.Padding(3);
			this.loadTab.Size = new System.Drawing.Size(444, 270);
			this.loadTab.TabIndex = 1;
			this.loadTab.Text = "Load Into Database";
			this.loadTab.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 3);
			this.label2.MaximumSize = new System.Drawing.Size(430, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(430, 234);
			this.label2.TabIndex = 1;
			this.label2.Text = resources.GetString("label2.Text");
			// 
			// dbTab
			// 
			this.dbTab.Controls.Add(this.label3);
			this.dbTab.Location = new System.Drawing.Point(4, 22);
			this.dbTab.Name = "dbTab";
			this.dbTab.Size = new System.Drawing.Size(444, 270);
			this.dbTab.TabIndex = 2;
			this.dbTab.Text = "Database Control";
			this.dbTab.UseVisualStyleBackColor = true;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 3);
			this.label3.MaximumSize = new System.Drawing.Size(430, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(430, 130);
			this.label3.TabIndex = 2;
			this.label3.Text = resources.GetString("label3.Text");
			// 
			// Help
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(476, 320);
			this.Controls.Add(this.menuTabs);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Help";
			this.Text = "MACK2 - Help";
			this.menuTabs.ResumeLayout(false);
			this.printTab.ResumeLayout(false);
			this.printTab.PerformLayout();
			this.loadTab.ResumeLayout(false);
			this.loadTab.PerformLayout();
			this.dbTab.ResumeLayout(false);
			this.dbTab.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl menuTabs;
		private System.Windows.Forms.TabPage printTab;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TabPage loadTab;
		private System.Windows.Forms.TabPage dbTab;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
	}
}