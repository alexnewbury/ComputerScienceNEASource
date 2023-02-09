using Classes;
using System;
using System.Collections.Generic;

namespace Functions
{
	class Data
	{
		private static int permittedColourDifference = Classes.ColourConstants.PermittedColourDifference;
		public static bool colourMatch(RGBColour _colour1, RGBColour _colour2)
		{
			//Only return true if there is a difference between the two colours of more than PermittedColourDifference, in R, G, and B.
			if (_colour1.R < _colour2.R - permittedColourDifference || _colour1.R > _colour2.R + permittedColourDifference)
			{
				return false;
			}
			if (_colour1.G < _colour2.G - permittedColourDifference || _colour1.G > _colour2.G + permittedColourDifference)
			{
				return false;
			}
			if (_colour1.B < _colour2.B - permittedColourDifference || _colour1.B > _colour2.B + permittedColourDifference)
			{
				return false;
			}
			return true;
		}
	}
	class MathsFunctions
	{
		public static List<int> FindServoPosition(Classes.Coordinate PaintingPosition)
		{
			//Find angles (degrees) of servo positions
			List<int> angleList = FindAngle(PaintingPosition);
			List<int> servoList = new List<int>();
			//Servo1Value = 143 + (11/15 * angle), Servo2Value = 67 + (11/15 * angle) + offset
			//Offset is needed because the brush does not sit perfectly parallel to the arm, 
			servoList.Add(Convert.ToInt16(143 + ((11.0 / 15) * Convert.ToDouble(angleList[0]))));
			servoList.Add(Convert.ToInt16(67 + ((11.0 / 15) * (Convert.ToDouble(angleList[1]) + ArmConstants.Arm2Offset))));
			return servoList;
		}
		public static List<int> FindAngle(Classes.Coordinate PaintingPosition)
		{
			//Find intersection point of two circles
			DoubleCoordinate IntersectionPoint = FindIntersection(PaintingPosition);
			List<int> angleList = new List<int>();
			//Use trig identities to find the angle relative to vertical
			double cosArm1 = (ConvertRadiansToDegrees(Math.Acos((ArmConstants.BasePosition.X - IntersectionPoint.X) / Math.Sqrt(Math.Pow(ArmConstants.BasePosition.X - IntersectionPoint.X, 2) + Math.Pow(ArmConstants.BasePosition.Y - IntersectionPoint.Y, 2)))) - 90);
			angleList.Add(Convert.ToInt16(cosArm1));
			double sinArm2 = (ConvertRadiansToDegrees(Math.Asin((PaintingPosition.Y - IntersectionPoint.Y) / Math.Sqrt(Math.Pow(PaintingPosition.X - IntersectionPoint.X, 2) + Math.Pow(PaintingPosition.Y - IntersectionPoint.Y, 2)))));
			double cosArm2 = (ConvertRadiansToDegrees(Math.Acos((IntersectionPoint.X - PaintingPosition.X) / Math.Sqrt(Math.Pow(PaintingPosition.X - IntersectionPoint.X, 2) + Math.Pow(PaintingPosition.Y - IntersectionPoint.Y, 2)))) - 90);
			angleList.Add(Convert.ToInt16(sinArm2 > 0 ? cosArm2 : (180 - cosArm2)) - angleList[0]);
			return angleList;
		}
		public static Classes.DoubleCoordinate FindIntersection(Classes.Coordinate PaintingPosition)
		{
			double xDiff = Classes.ArmConstants.BasePosition.X - PaintingPosition.X;
			double yDiff = Classes.ArmConstants.BasePosition.Y - PaintingPosition.Y;
			double sqrPosSum = xDiff * xDiff + yDiff * yDiff;
			double sqrArmDiff = ArmConstants.Arm1Length * ArmConstants.Arm1Length - ArmConstants.Arm2Length * ArmConstants.Arm2Length;
			double offsetConst = (((sqrPosSum + sqrArmDiff) * (sqrPosSum)) / (2 * xDiff * yDiff * Math.Sqrt(sqrPosSum * (1 + (yDiff / xDiff) * (yDiff / xDiff))))) + ((ArmConstants.BasePosition.X * xDiff + ArmConstants.BasePosition.Y * yDiff) / yDiff);
			double aValue = ((xDiff * xDiff) / (yDiff * yDiff)) + 1;
			double bValue = -2 * offsetConst * (xDiff / yDiff) + 2 * ArmConstants.BasePosition.Y * (xDiff / yDiff) - 2 * ArmConstants.BasePosition.X;
			double cValue = offsetConst * (offsetConst - 2 * ArmConstants.BasePosition.Y) + ArmConstants.BasePosition.X * ArmConstants.BasePosition.X + ArmConstants.BasePosition.Y * ArmConstants.BasePosition.Y - ArmConstants.Arm1Length * ArmConstants.Arm1Length;
			return new DoubleCoordinate((((-bValue - Math.Sqrt((bValue * bValue) - 4 * (aValue * cValue))) / (2 * aValue))), (((-bValue - Math.Sqrt((bValue * bValue) - 4 * (aValue * cValue))) / (2 * aValue)) * (-xDiff / yDiff)) + offsetConst);
		}
		public static double ConvertRadiansToDegrees(double Radians)
		{
			//Convert radians into degrees
			double Degrees = (180 / Math.PI) * Radians;
			return Degrees;
		}
		public static double ConvertDegreesToRadians(double Degrees)
		{
			//Convert degrees into radians
			double Radians = (Math.PI / 180) * Degrees;
			return (Radians);
		}
	}
	class DataFunctions
	{
		//Most recently recieved piece of data
		public static int RecievedData = 0;
		//ALl data sent/recieved via serial port
		public static string sentData = "";
		public static string recievedData = "";

		public static void DataReceivedHandler(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
		{
			//Triggered whenever serial data is recieved from PICAXE microcontroller
			System.IO.Ports.SerialPort sp = (System.IO.Ports.SerialPort)sender;
			//Translate via ASCII to get actually transmitted value
			RecievedData = Convert.ToInt16(System.Text.Encoding.ASCII.GetBytes(sp.ReadExisting())[0]);
			//Append to recievedData
			recievedData += RecievedData + " : ";
		}
		public static bool RecieveStatus(System.IO.Ports.SerialPort sp)
		{
			//Hold until data is recieved
			while (Functions.DataFunctions.RecievedData == 0) { System.Threading.Thread.Sleep(50); }
			
			//Check data recieved is an OK code
			if (Functions.DataFunctions.RecievedData != 30)
			{
				//If not OK, reset recieved data and send error code back
				Functions.DataFunctions.ResetRecievedData();
				Functions.DataFunctions.SendInt(sp, 35);
				//Return false as status is not OK
				return false;
			}
			Functions.DataFunctions.ResetRecievedData();
			//Return true as status is OK
			return true;
		}
		public static void SendInt(object sender, int data)
		{
			//Space out transmissions to ensure that 
			System.Threading.Thread.Sleep(250);
			System.IO.Ports.SerialPort sp = (System.IO.Ports.SerialPort)sender;
			//Correctly encode to allow for reliable decoding at other end
			sp.Write(BitConverter.GetBytes(Convert.ToByte(data)), 0, 1);
			sentData += data.ToString() + " : ";
		}
		public static void ResetRecievedData()
		{
			RecievedData = 0;
		}
	}
	class ImageFunctions
	{
		public static List<Line> ConvertImageToLineList(System.Drawing.Bitmap SelectedImage)
		{
			List<Line> lineList = new List<Line>();
			//Iterate through every pixel in image
			for (int xCounter = 0; xCounter < SelectedImage.Width; xCounter++)
			{
				for (int yCounter = 0; yCounter < SelectedImage.Height; yCounter++)
				{
					Classes.RGBColour currentPixel = (new RGBColour(SelectedImage.GetPixel(xCounter, yCounter).R, SelectedImage.GetPixel(xCounter, yCounter).G, SelectedImage.GetPixel(xCounter, yCounter).B));
					//Ignore any pixels that match with white (paper), they will not be painted
					if (!Data.colourMatch(currentPixel, new RGBColour(255, 255, 255)))
					{
						bool colourMatch = false;
						//Check against every line currently generated to see if pixel fits in any of them
						for (int lineListIndex = 0; lineListIndex < lineList.Count; lineListIndex++)
						{
							//If current Line colour matches pixel colour
							if (Data.colourMatch(lineList[lineListIndex].colour, currentPixel) && !colourMatch && lineList[lineListIndex].coordinates.Count < 100)
							{
								//Colour from pixel and current line object match, check if any coordinate in object neighbours current pixel
								for (int coordinateListIndex = 0; coordinateListIndex < lineList[lineListIndex].coordinates.Count; coordinateListIndex++)
								{
									//Check if top or left pixel are in the line
									if ((lineList[lineListIndex].coordinates[coordinateListIndex].X == xCounter - 1 && lineList[lineListIndex].coordinates[coordinateListIndex].Y == yCounter) || (lineList[lineListIndex].coordinates[coordinateListIndex].X == xCounter && lineList[lineListIndex].coordinates[coordinateListIndex].Y + 1 == yCounter))
									{
										//Add pixel to current list
										lineList[lineListIndex].coordinates.Add(new Coordinate(xCounter, yCounter));
										colourMatch = true;
										break;
									}
								}
							}
						}
						if (!colourMatch)
						{
							//If pixel doesn't match any lines neighbouring it, add it to a new line
							lineList.Add(new Line(currentPixel, new Coordinate(xCounter, yCounter)));
						}
					}
				}
			}
			for (int lineListIndex = 0; lineListIndex < lineList.Count; lineListIndex++)
			{
				//Remove any lines with only one pixel, and add that pixel to a neighbouring line
				if (lineList[lineListIndex].coordinates.Count == 1)
				{
					Coordinate coordinateToFind = new Coordinate(lineList[lineListIndex].coordinates[0].X + (lineList[lineListIndex].coordinates[0].X == 0 ? 1 : (-1)), lineList[lineListIndex].coordinates[0].Y);
					Coordinate coordinateToReplace = lineList[lineListIndex].coordinates[0];
					lineList.RemoveAt(lineListIndex);
					lineListIndex -= (lineListIndex == 0 ? 0 : 1);
					//Find neighbouring coordinate and add
					for (int line2ListIndex = 0; line2ListIndex < lineList.Count; line2ListIndex++)
					{
						for (int coordinateListIndex = 0; coordinateListIndex < lineList[line2ListIndex].coordinates.Count; coordinateListIndex++)
						{
							if (lineList[line2ListIndex].coordinates[coordinateListIndex].X == coordinateToFind.X && lineList[line2ListIndex].coordinates[coordinateListIndex].Y == coordinateToFind.Y)
							{
								lineList[line2ListIndex].coordinates.Add(coordinateToReplace);
								line2ListIndex = lineList.Count - 1;
								coordinateListIndex = lineList[line2ListIndex].coordinates.Count - 1;
							}
						}
					}
				}
			}
			return lineList;
		}

		public static System.Drawing.Bitmap CompilePartialImage(List<Line> SelectedLines, int XSize, int YSize)
		{
			System.Drawing.Bitmap NewImage = new System.Drawing.Bitmap(XSize, YSize);
			for (int LineIndex = 0; LineIndex < SelectedLines.Count; LineIndex++)
			{
				//For each pixel in provided lines, correctly colour to colour given by line
				Line CurrentLine = SelectedLines[LineIndex];
				System.Drawing.Color Colour = new System.Drawing.Color();
				Colour = System.Drawing.Color.FromArgb(CurrentLine.colour.R, CurrentLine.colour.G, CurrentLine.colour.B);
				for (int coordinateListIndex = 0; coordinateListIndex < CurrentLine.coordinates.Count; coordinateListIndex++)
				{
					NewImage.SetPixel(CurrentLine.coordinates[coordinateListIndex].X, CurrentLine.coordinates[coordinateListIndex].Y, Colour);
				}
			}
			return NewImage;
		}
	}
	class SQLFunctions
	{
		public static List<Line> GetImageFromDB(int PaintingID)
		{
			List<Line> lineList = new List<Line>();
			try
			{
				SQL SQLControl = new SQL();
				//Get all lines in specified painting
				System.Data.DataTable LineData = SQLControl.ExecuteQuery("SELECT * FROM " + SQL.LinesTB + " WHERE (PaintingID = " + PaintingID + ")");
				//For each line in painting
				for (int LineDataIndex = 0; LineDataIndex < LineData.Rows.Count; LineDataIndex++)
				{
					System.Data.DataRow CurrentLine = LineData.Rows[LineDataIndex];
					//SELECT all coordinates in current line
					System.Data.DataTable CoordData = SQLControl.ExecuteQuery("SELECT * FROM " + SQL.CoordinatesTB + " WHERE (PaintingID = " + PaintingID + " AND LineID = " + CurrentLine["LineID"] + ")");
					for (int CoordDataIndex = 0; CoordDataIndex < CoordData.Rows.Count; CoordDataIndex++)
					{
						//Add each pixel to the specified line object
						System.Data.DataRow CurrentCoord = CoordData.Rows[CoordDataIndex];
						if (CoordDataIndex == 0)
						{
							lineList.Add(new Line(new RGBColour(Convert.ToInt32(CurrentLine["ColourR"]), Convert.ToInt32(CurrentLine["ColourG"]), Convert.ToInt32(CurrentLine["ColourB"])), new Coordinate(Convert.ToInt32(CurrentCoord["X"]), Convert.ToInt32(CurrentCoord["Y"]))));
						}
						else
						{
							lineList[lineList.Count - 1].coordinates.Add(new Coordinate(Convert.ToInt32(CurrentCoord["X"]), Convert.ToInt32(CurrentCoord["Y"])));
						}
					}
				}
			}
			catch (Exception _E)
			{
				//Error handling in the case of SQL errors occuring
				throw new Exception("Error occured whilst getting image from DB", _E);
			}
			return lineList;
		}
	}
}