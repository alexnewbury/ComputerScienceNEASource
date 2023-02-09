using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NEAProject
{
	public partial class InstructionDisplay : Form
	{
		public InstructionDisplay()
		{
			InitializeComponent();
		}


		public void SetImageSource(Bitmap newImage)
		{
			//Set the partial image display source
			PartialImageDisplay.Image = newImage;
		}

		public void SetProgressBar(int Percentage)
		{
			//Set the value of the instruction progress bar
			InstructionProgressBar.Value = Percentage;
		}

		public void SetInstructionDisplay(string Text)
		{
			//Set debugging/output information
			LineInfoBox.Text = Text;
		}
	}
}
