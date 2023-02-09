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
	public partial class Options : Form
	{
		public Options()
		{
			InitializeComponent();
		}

		//Functions for changing options values
		private void Arm1LengthValue_ValueChanged(object sender, EventArgs e)
		{
			//Length of lower arm segment
			Classes.ArmConstants.Arm1Length = Convert.ToDouble(Arm1LengthValue.Value);
		}

		private void Arm2LengthValue_ValueChanged(object sender, EventArgs e)
		{
			//Length of upper arm segment
			Classes.ArmConstants.Arm2Length = Convert.ToDouble(Arm2LengthValue.Value);
		}

		private void Arm2OffsetValue_ValueChanged(object sender, EventArgs e)
		{
			//Offset (due to brush not being in line with arm)
			Classes.ArmConstants.Arm2Offset = Convert.ToDouble(Arm2OffsetValue.Value);
		}

		private void BasePositionXValue_ValueChanged(object sender, EventArgs e)
		{
			//Turning point of lower servo (mm)
			Classes.ArmConstants.BasePosition = new Classes.Coordinate(Convert.ToInt32(BasePositionXValue.Value), Convert.ToInt32(BasePositionYValue.Value));
		}

		private void BasePositionYValue_ValueChanged(object sender, EventArgs e)
		{
			//Turning point of lower servo (mm)
			Classes.ArmConstants.BasePosition = new Classes.Coordinate(Convert.ToInt32(BasePositionXValue.Value), Convert.ToInt32(BasePositionYValue.Value));
		}

		private void PaperSizeXValue_ValueChanged(object sender, EventArgs e)
		{
			//Paper dimensions (area to paint on)
			Classes.ArmConstants.PaperXSize = Convert.ToInt32(PaperSizeXValue.Value);
		}

		private void PaperSizeYValue_ValueChanged(object sender, EventArgs e)
		{
			//Paper dimensions (area to paint on)
			Classes.ArmConstants.PaperYSize = Convert.ToInt32(PaperSizeYValue.Value);
		}

		private void PermittedColourDifferenceValue_ValueChanged(object sender, EventArgs e)
		{
			//Difference allowed between RGB values
			Classes.ColourConstants.PermittedColourDifference = Convert.ToInt32(PermittedColourDifferenceValue.Value);
		}

		private void BlackMultiplierValue_ValueChanged(object sender, EventArgs e)
		{
			//Multiplier to cancel out all black distortion
			Classes.ColourConstants.BlackMultiplier = Convert.ToDouble(BlackMultiplierValue.Value);
		}
	}
}