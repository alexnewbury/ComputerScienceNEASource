namespace NEAProject
{
	partial class InstructionDisplay
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InstructionDisplay));
			this.LineInfoBox = new System.Windows.Forms.Label();
			this.InstructionProgressBar = new System.Windows.Forms.ProgressBar();
			this.PartialImageDisplay = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.PartialImageDisplay)).BeginInit();
			this.SuspendLayout();
			// 
			// LineInfoBox
			// 
			this.LineInfoBox.AutoSize = true;
			this.LineInfoBox.Location = new System.Drawing.Point(279, 13);
			this.LineInfoBox.Name = "LineInfoBox";
			this.LineInfoBox.Size = new System.Drawing.Size(67, 13);
			this.LineInfoBox.TabIndex = 5;
			this.LineInfoBox.Text = "Current Line:";
			// 
			// InstructionProgressBar
			// 
			this.InstructionProgressBar.Location = new System.Drawing.Point(12, 278);
			this.InstructionProgressBar.Name = "InstructionProgressBar";
			this.InstructionProgressBar.Size = new System.Drawing.Size(260, 23);
			this.InstructionProgressBar.TabIndex = 4;
			// 
			// PartialImageDisplay
			// 
			this.PartialImageDisplay.BackColor = System.Drawing.Color.White;
			this.PartialImageDisplay.Location = new System.Drawing.Point(12, 12);
			this.PartialImageDisplay.Name = "PartialImageDisplay";
			this.PartialImageDisplay.Size = new System.Drawing.Size(260, 260);
			this.PartialImageDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.PartialImageDisplay.TabIndex = 3;
			this.PartialImageDisplay.TabStop = false;
			this.PartialImageDisplay.WaitOnLoad = true;
			// 
			// InstructionDisplay
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(429, 309);
			this.Controls.Add(this.LineInfoBox);
			this.Controls.Add(this.InstructionProgressBar);
			this.Controls.Add(this.PartialImageDisplay);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "InstructionDisplay";
			this.Text = "MACK2 - InstructionDisplay";
			((System.ComponentModel.ISupportInitialize)(this.PartialImageDisplay)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label LineInfoBox;
		private System.Windows.Forms.ProgressBar InstructionProgressBar;
		private System.Windows.Forms.PictureBox PartialImageDisplay;
	}
}