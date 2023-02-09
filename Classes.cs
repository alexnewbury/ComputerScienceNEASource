using Functions;
using System;

namespace Classes
{
	public class ArmConstants
	{
		//Constants relating to the robotic arm, used in inverse kinematics
		public static double Arm1Length = 167;
		public static double Arm2Length = 176;
		public static double Arm2Offset = 14.92;
		public static Coordinate BasePosition = new Coordinate(-10, -20);
		//Size of paper being used (area to paint on)
		public static double PaperXSize = 210;
		public static double PaperYSize = 210;
	}
	public class ColourConstants
	{
		//Maximum colour difference (0-255) before the system differentiates as two separate colours 
		public static int PermittedColourDifference = 100;
		//Multiplier to decrease amount of black paint used in process
		public static double BlackMultiplier = 0.2;
	}
	public class Line
	{
		public Line(RGBColour _colour, Coordinate _coordinate)
		{
			//Create a new Line object with the specified colour and a single coordinate
			colour = _colour;
			coordinates.Add(_coordinate);
		}
		public Classes.RGBColour colour;
		public System.Collections.Generic.List<Classes.Coordinate> coordinates = new System.Collections.Generic.List<Classes.Coordinate>();
	}

	public class CMYKColour
	{
		public CMYKColour(int R, int G, int B)
		{
			//CMYK colours are only ever used for transmission to arm, so convert from RGB values to CMYK rather than passing the values directly
			double _R = R / 255d;
			double _G = G / 255d;
			double _B = B / 255d;
			double _K = 1 - Math.Max(Math.Max(_R, _G), _B);
			K = Convert.ToInt32(_K * 100);
			C = Convert.ToInt32(((1 - _R - _K) / (1.01 - _K)) * 100);
			M = Convert.ToInt32(((1 - _G - _K) / (1.01 - _K)) * 100);
			Y = Convert.ToInt32(((1 - _B - _K) / (1.01 - _K)) * 100);
		}
		private int c;
		private int m;
		private int y;
		private int k;
		//Ensure colours are in range 0-100 for CMYK
		public int C
		{
			get
			{
				return c;
			}
			set
			{
				if (value <= 100 && value >= 0)
				{
					c = value;
				}
				else
				{
					throw new Exception("Value specified is outside the permissible range for a CYMK value.");
				}
			}
		}
		public int M
		{
			get
			{
				return m;
			}
			set
			{
				if (value <= 100 && value >= 0)
				{
					m = value;
				}
				else
				{
					throw new Exception("Value specified is outside the permissible range for a CYMK value.");
				}
			}
		}
		public int Y
		{
			get
			{
				return y;
			}
			set
			{
				if (value <= 100 && value >= 0)
				{
					y = value;
				}
				else
				{
					throw new Exception("Value specified is outside the permissible range for a CYMK value.");
				}
			}
		}
		public int K
		{
			get
			{
				return k;
			}
			set
			{
				if (value <= 100 && value >= 0)
				{
					k = value;
				}
				else
				{
					throw new Exception("Value specified is outside the permissible range for a CYMK value.");
				}
			}
		}
	}

	public class RGBColour
	{
		public RGBColour(int _R, int _G, int _B)
		{
			R = _R;
			G = _G;
			B = _B;
		}
		public CMYKColour ToCMYKColour()
		{
			return new CMYKColour(R, G, B);
		}
		public override string ToString()
		{
			return R.ToString() + ", " + G.ToString() + ", " + B.ToString();
		}
		private int r;
		private int g;
		private int b;
		//Ensure colours are in range 0-255 for RGB
		public int R
		{
			get
			{
				return r;
			}
			set
			{
				if (value <= 255 && value >= 0)
				{
					r = value;
				}
				else
				{
					throw new Exception("Value specified is outside the permissible range for an RGB value.");
				}
			}
		}
		public int G
		{
			get
			{
				return g;
			}
			set
			{
				if (value <= 255 && value >= 0)
				{
					g = value;
				}
				else
				{
					throw new Exception("Value specified is outside the permissible range for an RGB value.");
				}
			}
		}
		public int B
		{
			get
			{
				return b;
			}
			set
			{
				if (value <= 255 && value >= 0)
				{
					b = value;
				}
				else
				{
					throw new Exception("Value specified is outside the permissible range for an RGB value.");
				}
			}
		}
	}

	public class Coordinate
	{
		public Coordinate(int _X, int _Y)
		{
			X = _X;
			Y = _Y;
		}
		public override string ToString()
		{
			return "(" + X.ToString() + ", " + Y.ToString() + ")";
		}
		public int X;
		public int Y;
	}

	public class DoubleCoordinate
	{
		//Same structure as Coordinate, but with higher accuracy to allow for more precision when working with small values
		public DoubleCoordinate(double _X, double _Y)
		{
			X = _X;
			Y = _Y;
		}
		public override string ToString()
		{
			return "(" + X.ToString() + ", " + Y.ToString() + ")";
		}
		public double X;
		public double Y;
	}
}