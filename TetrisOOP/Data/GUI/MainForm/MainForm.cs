using System;
using Engine;
using System.Drawing;
using System.Windows.Forms;
using TetrisOOP.Data.GUI.AboutGame;
using TetrisOOP.Data.Modules.Users;
using TetrisOOP.Data.GUI.UserControl;
using TetrisOOP.Data.GUI.SettingsForm;
using TetrisOOP.Data.GUI.UserStatistics;
using Octokit;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;
using System.IO;
using TetrisOOP.Data.Modules.Audio;
using System.Linq;

namespace TetrisOOP
{
	public partial class MainForm : Form
	{
		private Sound menuSound = new Sound(Properties.Resources.MenuMusic);
		public MainForm()
		{
			InitializeComponent();
			SetSprite();
			menuSound.PlayLoop();
		}

		private static void SetSprite()
		{
			try
			{
				GameBoard.BackField = new Bitmap(Properties.Resources.spriteBG);
				GameBoard.BackBox   = new Bitmap(Properties.Resources.BackBox);

				Bitmap sprites      = new Bitmap(Properties.Resources.allShapes);
				GameBoard.LightBlue = sprites.Clone(new RectangleF(0, 0, 20, 20), sprites.PixelFormat);
				GameBoard.Green     = sprites.Clone(new RectangleF(20, 0, 20, 20), sprites.PixelFormat);
				GameBoard.Purple    = sprites.Clone(new RectangleF(40, 0, 20, 20), sprites.PixelFormat);
				GameBoard.Blue      = sprites.Clone(new RectangleF(60, 0, 20, 20), sprites.PixelFormat);
				GameBoard.Orange    = sprites.Clone(new RectangleF(80, 0, 20, 20), sprites.PixelFormat);
				GameBoard.Red       = sprites.Clone(new RectangleF(100, 0, 20, 20), sprites.PixelFormat);
				GameBoard.Yellow    = sprites.Clone(new RectangleF(120, 0, 20, 20), sprites.PixelFormat);
			}
			catch (Exception ex)
			{
				MessageBox.Show(@"Не вдалося завантажити: " + ex.Message, @"Помилка при завнтаженні зображень!");
			}
		}

		private void BtPlay_Click(object sender, EventArgs e)
		{
			Hide();
			menuSound.Stop();
			GameForm game = new GameForm();
			game.ShowDialog();
			Show();
			menuSound.PlayLoop();
		}

		private void BtSettings_Click(object sender, EventArgs e)
		{
			SettingsForm settings = new SettingsForm();
			settings.ShowDialog();
		}

		private async void BtExit_Click(object sender, EventArgs e)
		{
			UserManager.SaveUserData();
			await Task.Delay(5000);
			System.Windows.Forms.Application.Exit();
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			Properties.Settings.Default.Save();
			UserManager.SaveUserData();
		}

		private void BtAbout_Click(object sender, EventArgs e)
		{
			AboutGame about = new AboutGame();
			about.ShowDialog();
		}

		private void BtChangeUser_Click(object sender, EventArgs e)
		{
			var userControl = new FUserControl();
			userControl.ShowDialog();
		}

		private void BtUserStatistic_Click(object sender, EventArgs e)
		{
			var userStat = new UserStatistic();
			userStat.ShowDialog();
		}

		private async void MainForm_Load(object sender, EventArgs e)
		{
			new UserManager();
			var data = await UserManager.GetTopUsers();
			topList.DataSource = data.Keys.ToList();
			scoresList.DataSource = data.Values.ToList();
		}

		private void MainForm_Activated(object sender, EventArgs e)
		{
			UserManager.CheckOnLevel();
		}
	}
}

// TODO таблиця лідерів
// TODO гостьовий режим (Done!)
// TODO виправлення багів

// TODO рефакторинг: DateTime -> TimeSpan (Done!)
// TODO рефакторинг: додати звукові ефекти та виділити аудіо в окремий клас (Done!)
// TODO рефакторинг: try catch
// TODO рефакторинг: додати коментарі (Done!)