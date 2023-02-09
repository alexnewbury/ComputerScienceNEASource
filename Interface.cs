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
	public partial class Interface : Form
	{
		public int timeLeft = 1;
		public Interface()
		{
			//Show splash screen
			InitializeComponent();
		}

		private void Interface_Load(object sender, EventArgs e)
		{
			//Start timer ticking
			timer.Start();
		}

		private void timer_Tick(object sender, EventArgs e)
		{
			//Every time the timer ticks, check if splash screen should be removed
			if (timeLeft > 0)
			{
				timeLeft -= 1;
			}
			else
			{
				//Hide splash screen and show the menu
				timer.Stop();
				NEAProject.Menu MenuForm = new Menu();
				MenuForm.Show();
				this.Hide();
			}
		}
	}
}