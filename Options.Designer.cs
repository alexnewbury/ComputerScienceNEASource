namespace NEAProject
{
	partial class Options
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Options));
			this.Arm1LengthValue = new System.Windows.Forms.NumericUpDown();
			this.Arm2LengthValue = new System.Windows.Forms.NumericUpDown();
			this.Arm2OffsetValue = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.BasePositionYValue = new System.Windows.Forms.NumericUpDown();
			this.BasePositionXValue = new System.Windows.Forms.NumericUpDown();
			this.PaperSizeXValue = new System.Windows.Forms.NumericUpDown();
			this.PaperSizeYValue = new System.Windows.Forms.NumericUpDown();
			this.PermittedColourDifferenceValue = new System.Windows.Forms.NumericUpDown();
			this.label6 = new System.Windows.Forms.Label();
			this.BlackMultiplierValue = new System.Windows.Forms.NumericUpDown();
			this.label7 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.Arm1LengthValue)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Arm2LengthValue)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Arm2OffsetValue)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.BasePositionYValue)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.BasePositionXValue)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PaperSizeXValue)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PaperSizeYValue)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PermittedColourDifferenceValue)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.BlackMultiplierValue)).BeginInit();
			this.SuspendLayout();
			// 
			// Arm1LengthValue
			// 
			this.Arm1LengthValue.Location = new System.Drawing.Point(13, 13);
			this.Arm1LengthValue.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
			this.Arm1LengthValue.Name = "Arm1LengthValue";
			this.Arm1LengthValue.Size = new System.Drawing.Size(120, 20);
			this.Arm1LengthValue.TabIndex = 0;
			this.Arm1LengthValue.Value = new decimal(new int[] {
            167,
            0,
            0,
            0});
			this.Arm1LengthValue.ValueChanged += new System.EventHandler(this.Arm1LengthValue_ValueChanged);
			// 
			// Arm2LengthValue
			// 
			this.Arm2LengthValue.Location = new System.Drawing.Point(13, 40);
			this.Arm2LengthValue.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
			this.Arm2LengthValue.Name = "Arm2LengthValue";
			this.Arm2LengthValue.Size = new System.Drawing.Size(120, 20);
			this.Arm2LengthValue.TabIndex = 1;
			this.Arm2LengthValue.Value = new decimal(new int[] {
            176,
            0,
            0,
            0});
			this.Arm2LengthValue.ValueChanged += new System.EventHandler(this.Arm2LengthValue_ValueChanged);
			// 
			// Arm2OffsetValue
			// 
			this.Arm2OffsetValue.DecimalPlaces = 2;
			this.Arm2OffsetValue.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.Arm2OffsetValue.Location = new System.Drawing.Point(13, 67);
			this.Arm2OffsetValue.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
			this.Arm2OffsetValue.Name = "Arm2OffsetValue";
			this.Arm2OffsetValue.Size = new System.Drawing.Size(120, 20);
			this.Arm2OffsetValue.TabIndex = 2;
			this.Arm2OffsetValue.Value = new decimal(new int[] {
            1492,
            0,
            0,
            131072});
			this.Arm2OffsetValue.ValueChanged += new System.EventHandler(this.Arm2OffsetValue_ValueChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(140, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(89, 13);
			this.label1.TabIndex = 7;
			this.label1.Text = "Arm1Length (mm)";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(140, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(89, 13);
			this.label2.TabIndex = 8;
			this.label2.Text = "Arm2Length (mm)";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(140, 67);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(106, 13);
			this.label3.TabIndex = 9;
			this.label3.Text = "Arm2Offset (degrees)";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(140, 93);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(93, 13);
			this.label4.TabIndex = 10;
			this.label4.Text = "BasePosition (mm)";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(140, 120);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(80, 13);
			this.label5.TabIndex = 11;
			this.label5.Text = "PaperSize (mm)";
			// 
			// BasePositionYValue
			// 
			this.BasePositionYValue.Location = new System.Drawing.Point(80, 93);
			this.BasePositionYValue.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
			this.BasePositionYValue.Name = "BasePositionYValue";
			this.BasePositionYValue.Size = new System.Drawing.Size(53, 20);
			this.BasePositionYValue.TabIndex = 4;
			this.BasePositionYValue.Value = new decimal(new int[] {
            20,
            0,
            0,
            -2147483648});
			this.BasePositionYValue.ValueChanged += new System.EventHandler(this.BasePositionYValue_ValueChanged);
			// 
			// BasePositionXValue
			// 
			this.BasePositionXValue.Location = new System.Drawing.Point(13, 94);
			this.BasePositionXValue.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
			this.BasePositionXValue.Name = "BasePositionXValue";
			this.BasePositionXValue.Size = new System.Drawing.Size(53, 20);
			this.BasePositionXValue.TabIndex = 3;
			this.BasePositionXValue.Value = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
			this.BasePositionXValue.ValueChanged += new System.EventHandler(this.BasePositionXValue_ValueChanged);
			// 
			// PaperSizeXValue
			// 
			this.PaperSizeXValue.Location = new System.Drawing.Point(13, 120);
			this.PaperSizeXValue.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
			this.PaperSizeXValue.Name = "PaperSizeXValue";
			this.PaperSizeXValue.Size = new System.Drawing.Size(53, 20);
			this.PaperSizeXValue.TabIndex = 5;
			this.PaperSizeXValue.Value = new decimal(new int[] {
            210,
            0,
            0,
            0});
			this.PaperSizeXValue.ValueChanged += new System.EventHandler(this.PaperSizeXValue_ValueChanged);
			// 
			// PaperSizeYValue
			// 
			this.PaperSizeYValue.Location = new System.Drawing.Point(80, 119);
			this.PaperSizeYValue.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
			this.PaperSizeYValue.Name = "PaperSizeYValue";
			this.PaperSizeYValue.Size = new System.Drawing.Size(53, 20);
			this.PaperSizeYValue.TabIndex = 6;
			this.PaperSizeYValue.Value = new decimal(new int[] {
            210,
            0,
            0,
            0});
			this.PaperSizeYValue.ValueChanged += new System.EventHandler(this.PaperSizeYValue_ValueChanged);
			// 
			// PermittedColourDifferenceValue
			// 
			this.PermittedColourDifferenceValue.Location = new System.Drawing.Point(13, 146);
			this.PermittedColourDifferenceValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.PermittedColourDifferenceValue.Name = "PermittedColourDifferenceValue";
			this.PermittedColourDifferenceValue.Size = new System.Drawing.Size(120, 20);
			this.PermittedColourDifferenceValue.TabIndex = 7;
			this.PermittedColourDifferenceValue.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.PermittedColourDifferenceValue.ValueChanged += new System.EventHandler(this.PermittedColourDifferenceValue_ValueChanged);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(140, 146);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(162, 13);
			this.label6.TabIndex = 17;
			this.label6.Text = "PermittedColourDifference (RGB)";
			// 
			// BlackMultiplierValue
			// 
			this.BlackMultiplierValue.DecimalPlaces = 2;
			this.BlackMultiplierValue.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.BlackMultiplierValue.Location = new System.Drawing.Point(13, 172);
			this.BlackMultiplierValue.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.BlackMultiplierValue.Name = "BlackMultiplierValue";
			this.BlackMultiplierValue.Size = new System.Drawing.Size(120, 20);
			this.BlackMultiplierValue.TabIndex = 18;
			this.BlackMultiplierValue.Value = new decimal(new int[] {
            2,
            0,
            0,
            65536});
			this.BlackMultiplierValue.ValueChanged += new System.EventHandler(this.BlackMultiplierValue_ValueChanged);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(140, 172);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(75, 13);
			this.label7.TabIndex = 19;
			this.label7.Text = "BlackMultiplier";
			// 
			// Options
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(308, 171);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.BlackMultiplierValue);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.PermittedColourDifferenceValue);
			this.Controls.Add(this.PaperSizeXValue);
			this.Controls.Add(this.PaperSizeYValue);
			this.Controls.Add(this.BasePositionXValue);
			this.Controls.Add(this.BasePositionYValue);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.Arm2OffsetValue);
			this.Controls.Add(this.Arm2LengthValue);
			this.Controls.Add(this.Arm1LengthValue);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Options";
			this.Text = "MACK2 - Options";
			((System.ComponentModel.ISupportInitialize)(this.Arm1LengthValue)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Arm2LengthValue)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Arm2OffsetValue)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.BasePositionYValue)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.BasePositionXValue)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PaperSizeXValue)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PaperSizeYValue)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PermittedColourDifferenceValue)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.BlackMultiplierValue)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.NumericUpDown Arm1LengthValue;
		private System.Windows.Forms.NumericUpDown Arm2LengthValue;
		private System.Windows.Forms.NumericUpDown Arm2OffsetValue;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.NumericUpDown BasePositionYValue;
		private System.Windows.Forms.NumericUpDown BasePositionXValue;
		private System.Windows.Forms.NumericUpDown PaperSizeXValue;
		private System.Windows.Forms.NumericUpDown PaperSizeYValue;
		private System.Windows.Forms.NumericUpDown PermittedColourDifferenceValue;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.NumericUpDown BlackMultiplierValue;
		private System.Windows.Forms.Label label7;
	}
}