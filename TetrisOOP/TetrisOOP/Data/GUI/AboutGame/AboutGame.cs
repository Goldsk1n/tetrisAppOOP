using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TetrisOOP.Data.GUI.AboutGame
{
	public partial class AboutGame : Form
	{
		public AboutGame()
		{
			InitializeComponent();
		}

		private void AboutGame_Load(object sender, EventArgs e)
		{

		}

		private void AboutGame_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
