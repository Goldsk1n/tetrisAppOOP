using System;
using System.Drawing;
using System.Windows.Forms;

namespace TetrisOOP.Data.GUI.StartScreen
{
	public partial class StartScreen : Form
	{
		private Timer _timer;

		public StartScreen()
		{
			InitializeComponent();
			SetSettingsThisForm();
		}

		private void SetSettingsThisForm()
		{
			Color bgColor = Color.Red;
			BackColor = bgColor;
			TransparencyKey = bgColor;

			FormBorderStyle = FormBorderStyle.None;

			BackgroundImage = Properties.Resources.logo;
			BackgroundImageLayout = ImageLayout.Stretch;
		}

		private void ShowMainForm()
		{
			_timer.Stop();
			Hide();
			new MainForm().ShowDialog();
			Application.Exit();
		}

		private void StartScreen_Shown(object sender, EventArgs e)
		{
			_timer = new Timer
			{
				Interval = 3000
			};
			_timer.Start();
			_timer.Tick += Timer_Tick;
		}

		private void Timer_Tick(object sender, EventArgs e)
		{
			ShowMainForm();
		}

		private void StartScreen_Click(object sender, EventArgs e)
		{
			ShowMainForm();
		}
	}
}
