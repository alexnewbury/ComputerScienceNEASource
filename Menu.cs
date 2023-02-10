using Classes;
using Functions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace NEAProject
{
	public partial class Menu : Form
	{
		public Menu()
		{
			//Add FormClosing event so if form is closed, program execution will be terminated
			InitializeComponent();
			this.FormClosing += Menu_FormClosing;
		}

		//----- Event Handlers for Print from Database tab -----

		private void ListAvilableButton_Click(object sender, EventArgs e)
		{
			//Instanciate SQL class
			SQL SQLControl = new SQL();
			//Select all names and uploadedtimes of paintings
			System.Data.DataTable ReturnedData = SQLControl.ExecuteQuery("SELECT Name, UploadedTime FROM " + SQL.PaintingsTB + " ORDER BY Name ASC");
			OutputTextLabelDBTab.Visible = true;
			string ReturnedNames = "Available:";
			//Append all names and uploadedtimes to list of returned data
			if (ReturnedData.Rows.Count > 0)
			{
				for (int CurrentRow = 0; CurrentRow < ReturnedData.Rows.Count; CurrentRow++)
				{
					ReturnedNames += "\n\r" + ReturnedData.Rows[CurrentRow]["Name"].ToString() + " (" + ReturnedData.Rows[CurrentRow]["UploadedTime"].ToString() + ")";
				}
			}
			//Show debug information
			AvailableInSQLList.Visible = true;
			AvailableInSQLList.Text = ReturnedNames;
			OutputTextLabelPrintTab.Visible = true;
			PaintingProgressBar.Visible = false;
			OutputTextLabelPrintTab.Text = "Sucessfully returned " + ReturnedData.Rows.Count.ToString() + " items from PaintingsTB.";
		}

		private void StartPaintButton_Click(object sender, EventArgs e)
		{
			try
			{
				PaintingProgressBar.Visible = true;
				OutputTextLabelPrintTab.Visible = false;
				System.Data.DataTable ReturnedData;
				
				//Check if name is specified, and if name exists in SQL database
				if (SQLNameInput.Text == "")
				{
					throw new Exception("No Name specified.");
				}
				SQL SQLControl = new SQL();
				ReturnedData = SQLControl.ExecuteQuery("SELECT PaintingID, XSize, YSize FROM " + SQL.PaintingsTB + " WHERE Name = UPPER(@SelectedName)", new System.Data.SqlClient.SqlParameter("SelectedName", SQLNameInput.Text));
				if (ReturnedData.Rows.Count == 0)
				{
					throw new Exception("Specified name does not exist");
				}
				
				//Initialise list of lines, X and Y dimensions of painting
				List<Line> lineList = SQLFunctions.GetImageFromDB(Convert.ToInt32(ReturnedData.Rows[0]["PaintingID"]));
				int XSize = Convert.ToInt32(ReturnedData.Rows[0]["XSize"]);
				int YSize = Convert.ToInt32(ReturnedData.Rows[0]["YSize"]);
				Bitmap SimplifiedImage = ImageFunctions.CompilePartialImage(lineList, XSize, YSize);
				//Define Serial Port as COM3, with a Baud Rate of 9600 Baud, no parity bit, 8 bits per transmission, and 1 stop bit
				System.IO.Ports.SerialPort _serialPort = new System.IO.Ports.SerialPort("COM3", 9600, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One);
				//Serial port has no handshake
				_serialPort.Handshake = System.IO.Ports.Handshake.None;
				//Set a timeout of 500ms before data is declared as void
				_serialPort.ReadTimeout = 500;
				//Disable Request to Send transmissions
				_serialPort.RtsEnable = false;
				//Add the event handler for recieving data
				_serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(Functions.DataFunctions.DataReceivedHandler);
				//Open the port
				_serialPort.Open();
				
				NEAProject.InstructionDisplay InstructionDisplayForm = new InstructionDisplay();
				InstructionDisplayForm.Show();
				List<Line> LineListUntilNow = new List<Line>();

				//Start of painting
				Functions.DataFunctions.SendInt(_serialPort, 10);
				//Wait for OK code
				if (!Functions.DataFunctions.RecieveStatus(_serialPort)) { throw new Exception("Invalid data recieved from robot"); }

				//For each line in painting
				for (int lineListIndex = 0; lineListIndex < lineList.Count; lineListIndex++)
				{
					CMYKColour Colour = lineList[lineListIndex].colour.ToCMYKColour();
					//UI
					PaintingProgressBar.Value = Convert.ToInt32((1d * lineListIndex / (lineList.Count - 1)) * 100);
					InstructionDisplayForm.SetProgressBar(Convert.ToInt32((1d * lineListIndex / (lineList.Count - 1)) * 100));
					List<Line> SelectedLine = new List<Line>();
					SelectedLine.Add(lineList[lineListIndex]);
					LineListUntilNow.Add(lineList[lineListIndex]);
					Bitmap LineToDraw = ImageFunctions.CompilePartialImage(SelectedLine, XSize, YSize);
					Bitmap PictureUntilNow = ImageFunctions.CompilePartialImage(LineListUntilNow, XSize, YSize);
					InstructionDisplayForm.SetImageSource(LineToDraw);
					InstructionDisplayForm.SetInstructionDisplay("Current Line:\r\n" + (lineListIndex + 1).ToString() + "/" + lineList.Count.ToString() + "\r\n" + "Colour: \r\n\t" + Colour.C + "\r\n\t" + Colour.M + "\r\n\t" + Colour.Y + "\r\n\t" + Colour.K + "\r\n" + lineList[lineListIndex].coordinates.Count.ToString() + " pixels (0/" + lineList[lineListIndex].coordinates.Count.ToString() + ")");
					Application.DoEvents();
					//Send ready to send colour instruction
					Functions.DataFunctions.SendInt(_serialPort, 20);
					if (!Functions.DataFunctions.RecieveStatus(_serialPort)) { throw new Exception("Invalid data recieved from robot"); }
					//Send colour
					Functions.DataFunctions.SendInt(_serialPort, Colour.C / 10);
					Functions.DataFunctions.SendInt(_serialPort, Colour.M / 10);
					Functions.DataFunctions.SendInt(_serialPort, Colour.Y / 10);
					Functions.DataFunctions.SendInt(_serialPort, Convert.ToInt32((Colour.K * Classes.ColourConstants.BlackMultiplier) / 10));
					if (!Functions.DataFunctions.RecieveStatus(_serialPort)) { throw new Exception("Invalid data recieved from robot"); }
					for (int pixelListIndex = 0; pixelListIndex < lineList[lineListIndex].coordinates.Count; pixelListIndex++)
					{
						//For each pixel
						//Alternate between current line, all lines so far, full painting
						switch (pixelListIndex % 3)
						{
							case 0:
								InstructionDisplayForm.SetImageSource(SimplifiedImage);
								break;
							case 1:
								InstructionDisplayForm.SetImageSource(PictureUntilNow);
								break;
							case 2:
								InstructionDisplayForm.SetImageSource(LineToDraw);
								break;
						}
						InstructionDisplayForm.SetInstructionDisplay("Current Line:\r\n" + (lineListIndex + 1).ToString() + "/" + lineList.Count.ToString() + "\r\n" + "Colour: \r\n\t" + Colour.C + "\r\n\t" + Colour.M + "\r\n\t" + Colour.Y + "\r\n\t" + Colour.K + "\r\n" + lineList[lineListIndex].coordinates.Count.ToString() + " pixels (" + (pixelListIndex + 1).ToString() + "/" + lineList[lineListIndex].coordinates.Count.ToString() + ")");
						Application.DoEvents();
						//Start of position object
						Functions.DataFunctions.SendInt(_serialPort, 25);
						if (!Functions.DataFunctions.RecieveStatus(_serialPort)) { System.Windows.Forms.MessageBox.Show(Functions.DataFunctions.sentData); throw new Exception("Invalid data recieved from robot: " + Functions.DataFunctions.recievedData); }
						//Position object
						Coordinate AdjustedCoord = new Coordinate(Convert.ToInt16(lineList[lineListIndex].coordinates[pixelListIndex].X * (Classes.ArmConstants.PaperXSize / XSize)), Convert.ToInt16((YSize - lineList[lineListIndex].coordinates[pixelListIndex].Y) * (Classes.ArmConstants.PaperYSize / YSize)));
						List<int> ServoAngles = MathsFunctions.FindServoPosition(AdjustedCoord);
						Functions.DataFunctions.SendInt(_serialPort, ServoAngles[0]);
						Functions.DataFunctions.SendInt(_serialPort, ServoAngles[1]);
						if (!Functions.DataFunctions.RecieveStatus(_serialPort)) { throw new Exception("Invalid data recieved from robot: " + Functions.DataFunctions.recievedData); }
						//Close and reopen serial port to clean buffer values
						_serialPort.Close();
						System.Threading.Thread.Sleep(100);
						_serialPort.Open();
						System.Threading.Thread.Sleep(100);
					}
				}
				//End of painting
				Functions.DataFunctions.SendInt(_serialPort, 15);
				if (!Functions.DataFunctions.RecieveStatus(_serialPort)) { throw new Exception("Invalid data recieved from robot"); }
				_serialPort.Close();

				//Close instruction form
				InstructionDisplayForm.Close();

				//Show complete
				SavingProgressBar.Visible = false;
				OutputTextLabelLoadTab.Visible = true;
				OutputTextLabelLoadTab.Text = "Image complete.";
				Application.DoEvents();
			}
			catch (System.Exception _E)
			{
				//Error checking for SQL and serial transmission
				PaintingProgressBar.Visible = false;
				OutputTextLabelPrintTab.Visible = true;
				OutputTextLabelPrintTab.Text = "Error whilst painting image: " + _E.Message;
			}
		}

		//----- Event Handlers for Load into Database tab -----

		private void StartSaveButton_Click(object sender, EventArgs e)
		{
			try
			{
				SavingProgressBar.Visible = true;
				OutputTextLabelLoadTab.Visible = false;
				System.Data.DataTable ReturnedData;
				
				//Check file exists and save text has a value in it
				if (SaveNameInput.Text == "")
				{
					throw new Exception("No Save Name specified.");
				}
				if (!System.IO.File.Exists(FileSourceInput.Text))
				{
					throw new Exception("Selected file cannot be found.");
				}
				
				SQL SQLControl = new SQL();
				//Select all from database with selected name to check there are no duplicate names
				ReturnedData = SQLControl.ExecuteQuery("SELECT * FROM " + SQL.PaintingsTB + " WHERE Name = UPPER(@SelectedName)", new System.Data.SqlClient.SqlParameter("SelectedName", SaveNameInput.Text));
				if (ReturnedData.Rows.Count != 0)
				{
					throw new Exception("Specified save name already exists");
				}
				Bitmap selectedImage = new System.Drawing.Bitmap(FileSourceInput.Text);
				PreviewImageBox.Image = selectedImage;
				List<Line> lineList = ImageFunctions.ConvertImageToLineList(selectedImage);
				//Insert Painting object with size and time
				SQLControl.ExecuteQuery("INSERT INTO " + SQL.PaintingsTB + " VALUES (UPPER(@SelectedName), " + selectedImage.Width + ", " + selectedImage.Height + ", GETDATE())", new System.Data.SqlClient.SqlParameter("SelectedName", SaveNameInput.Text));
				Application.DoEvents();
				ReturnedData = SQLControl.ExecuteQuery("SELECT * FROM " + SQL.PaintingsTB + " WHERE Name = UPPER(@SelectedName)", new System.Data.SqlClient.SqlParameter("SelectedName", SaveNameInput.Text));
				
				if (ReturnedData.Rows.Count != 1)
				{
					throw new Exception("Invalid number of rows returned by query");
				}
				int CurrentPaintingID = Convert.ToInt32(ReturnedData.Rows[0]["PaintingID"]);

				//Iterate through each line and add it to SQL database
				for (int lineListIndex = 0; lineListIndex < lineList.Count; lineListIndex++)
				{
					SavingProgressBar.Value = Convert.ToInt32((1d * lineListIndex / (lineList.Count - 1)) * 100);
					ReturnedData = SQLControl.ExecuteQuery("SELECT LineID FROM " + SQL.LinesTB + " ORDER BY LineID DESC");
					int CurrentLineID = ReturnedData.Rows.Count == 0 ? 1 : (Convert.ToInt32(ReturnedData.Rows[0]["LineID"]) + 1);
					SQLControl.ExecuteQuery("INSERT INTO " + SQL.LinesTB + " VALUES (" + CurrentLineID + ", " + CurrentPaintingID + ", " + lineList[lineListIndex].colour.R + ", " + lineList[lineListIndex].colour.G + ", " + lineList[lineListIndex].colour.B + ")");
					Application.DoEvents();
					for (int coordinateListIndex = 0; coordinateListIndex < lineList[lineListIndex].coordinates.Count; coordinateListIndex++)
					{
						//Add individual coordinates to SQL
						SQLControl.ExecuteQuery("INSERT INTO " + SQL.CoordinatesTB + " VALUES (" + CurrentLineID + ", " + CurrentPaintingID + ", " + lineList[lineListIndex].coordinates[coordinateListIndex].X + ", " + lineList[lineListIndex].coordinates[coordinateListIndex].Y + ")");
					}
				}
				
				SavingProgressBar.Visible = false;
				OutputTextLabelLoadTab.Visible = true;
				OutputTextLabelLoadTab.Text = "Image \"" + SaveNameInput.Text + "\"sucessfully saved as PaintingID " + CurrentPaintingID.ToString();
			}
			catch (System.Exception _E)
			{
				SavingProgressBar.Visible = false;
				OutputTextLabelLoadTab.Visible = true;
				OutputTextLabelLoadTab.Text = "Error whilst saving image: " + _E.Message;
			}
		}

		private void PreviewButton_Click(object sender, EventArgs e)
		{
			try
			{
				//Check if image exists
				if (!System.IO.File.Exists(FileSourceInput.Text))
				{
					throw new Exception("Selected file cannot be found");
				}
				//Set image to PreviewImageBox source
				Bitmap selectedImage = new System.Drawing.Bitmap(FileSourceInput.Text);
				PreviewImageBox.Image = selectedImage;
			}
			catch (System.Exception _E)
			{
				SavingProgressBar.Visible = false;
				OutputTextLabelLoadTab.Visible = true;
				OutputTextLabelLoadTab.Text = "Error whilst previewing: " + _E.Message;
			}
		}

		private void FileSourceInput_TextChanged(object sender, EventArgs e)
		{
			OutputTextLabelLoadTab.Visible = false;
			SavingProgressBar.Visible = false;
			PreviewImageBox.Image = null;
		}

		private void SaveNameInput_TextChanged(object sender, EventArgs e)
		{
			OutputTextLabelLoadTab.Visible = false;
			SavingProgressBar.Visible = false;
		}

		//----- Event Handlers for Database Control tab -----

		private void resetDBButton_Click(object sender, EventArgs e)
		{
			SQL SQLControl = new SQL();
			//Delete all tables
			SQLControl.ExecuteQuery("DROP TABLE " + SQL.PaintingsTB);
			SQLControl.ExecuteQuery("DROP TABLE " + SQL.LinesTB);
			SQLControl.ExecuteQuery("DROP TABLE " + SQL.CoordinatesTB);
			//Add tables back
			SQLControl.ExecuteQuery("CREATE TABLE " + SQL.PaintingsTB + "(PaintingID INT IDENTITY(1,1), Name NVARCHAR(MAX), XSize INT, YSize INT, UploadedTime DATETIME, PRIMARY KEY(PaintingID))");
			SQLControl.ExecuteQuery("CREATE TABLE " + SQL.LinesTB + "(LineID INT, PaintingID INT, ColourR INT, ColourG INT, ColourB INT, PRIMARY KEY(LineID))");
			SQLControl.ExecuteQuery("CREATE TABLE " + SQL.CoordinatesTB + "(CoordinateID INT IDENTITY(1,1), LineID INT, PaintingID INT, X INT, Y INT, PRIMARY KEY(CoordinateID))");
			OutputTextLabelDBTab.Visible = true;
			OutputTextLabelDBTab.Text = "Sucessfully deleted and recreated all tables";
		}

		private void clearDBButton_Click(object sender, EventArgs e)
		{
			SQL SQLControl = new SQL();
			//Clear all values from tables
			SQLControl.ExecuteQuery("DELETE FROM " + SQL.PaintingsTB);
			SQLControl.ExecuteQuery("DELETE FROM " + SQL.LinesTB);
			SQLControl.ExecuteQuery("DELETE FROM " + SQL.CoordinatesTB);
			OutputTextLabelDBTab.Visible = true;
			OutputTextLabelDBTab.Text = "Sucessfully cleared all tables";
		}

		private void checkDBButton_Click(object sender, EventArgs e)
		{
			SQL SQLControl = new SQL();
			//Select all names from SQL database
			System.Data.DataTable ReturnedData = SQLControl.ExecuteQuery("SELECT Name FROM " + SQL.PaintingsTB + " ORDER BY Name ASC");
			OutputTextLabelDBTab.Visible = true;
			string ReturnedNames = "";
			if (ReturnedData.Rows.Count > 0)
			{
				for (int CurrentRow = 0; CurrentRow < ReturnedData.Rows.Count; CurrentRow++)
				{
					//Append all returned names to list
					ReturnedNames += "\"" + ReturnedData.Rows[CurrentRow]["Name"].ToString() + "\"" + ((ReturnedData.Rows.Count - 1 == CurrentRow) ? "" : ", ");
				}
			}
			OutputTextLabelDBTab.Text = (ReturnedData.Rows.Count == 0 ? "The table is currently empty" : "Painting" + (ReturnedData.Rows.Count == 1 ? " " : "s ") + ReturnedNames + (ReturnedData.Rows.Count == 1 ? " is" : " are") + " in the table.");
		}

		//----- Event Handlers for Options & Help Toolbars -----

		private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//Instantiate options menu
			Options OptionsMenu = new Options();
			OptionsMenu.Show();
		}

		private void helpToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//Instantiate help menu
			Help HelpMenu = new Help();
			HelpMenu.Show();
		}

		private void Menu_FormClosing(object sender, EventArgs e)
		{
			//If menu form is closed, stop running
			Application.Exit();
		}
	}
}