using System;
using System.Drawing;
using Engine;
using System.Windows.Forms;
using TetrisOOP.Data.Modules.Audio;

namespace TetrisOOP.Data.GUI.SettingsForm
{
	public partial class SettingsForm : Form
	{
		public SettingsForm()
		{
			InitializeComponent();
		}

		private readonly Settings _settings = new Settings();

		private void SettingsForm_Load(object sender, EventArgs e)
		{
			cbGraphics.SelectedIndex = Properties.Settings.Default.Quality;
			trackBar1.Value = Properties.Settings.Default.AudioVolume;
			volumeLabel.Text = Properties.Settings.Default.AudioVolume.ToString();
		}

		private void BtSave_Click(object sender, EventArgs e)
		{
			_settings.Read();
			_settings.Apply();
			Properties.Settings.Default.Save();
		}

		private void BtReset_Click(object sender, EventArgs e)
		{
			Settings.Reset();
			cbGraphics.SelectedIndex = Properties.Settings.Default.Quality;
			trackBar1.Value = Properties.Settings.Default.AudioVolume;
			volumeLabel.Text = Properties.Settings.Default.AudioVolume.ToString();
		}

		private void BtBack_Click(object sender, EventArgs e)
		{
			Close();
		}


		private void CbFullScreen_CheckedChanged(object sender, EventArgs e)
		{
			_settings.Read();
		}

		private void PbColorBackground_Click(object sender, EventArgs e)
		{
			ColorDialog clrDlg = new ColorDialog();
			if (clrDlg.ShowDialog() == DialogResult.OK) Properties.Settings.Default.Background = clrDlg.Color;
		}

		private void PbColorField_Click(object sender, EventArgs e)
		{
			ColorDialog clrDlg = new ColorDialog();
			if (clrDlg.ShowDialog() == DialogResult.OK) Properties.Settings.Default.BackColor = clrDlg.Color;
		}

		private void CbGraphics_SelectedIndexChanged(object sender, EventArgs e)
		{
			Properties.Settings.Default.Quality = cbGraphics.SelectedIndex;

			pGraphicsMedium.Visible = cbGraphics.SelectedIndex == 1;
		}

		private void BtInputKeyRotate_Click(object sender, EventArgs e)
		{
			Keys k = Properties.Controls.Default.KeyRotate;

			using (Form formInputKey = new Form())
			{
				formInputKey.Text = @"Вибір клавіші оберту";
				formInputKey.StartPosition = FormStartPosition.CenterScreen;
				formInputKey.Size = new Size(170, 130);
				formInputKey.Font = new Font("Arial", 14, FontStyle.Bold);
				formInputKey.KeyPreview = true;
				formInputKey.FormBorderStyle = FormBorderStyle.None;
				formInputKey.BackColor = Color.DarkGray;

				Panel pnButtons = new Panel
				{
					BackColor = Color.DarkGray,
					Size = new Size(80, 60),
					Location = new Point(45, 50)
				};

				Label lbInputKey = new Label
				{
					Text = Convert.ToString(Properties.Controls.Default.KeyRotate),
					Location = new Point(30, 20),
					TextAlign = ContentAlignment.MiddleCenter
				};

				Button btOk = new Button
				{
					Text = @"Обрати",
					Font = new Font("Arial", 10, FontStyle.Regular),
					Size = new Size(80, 28),
					TabStop = false
				};

				Button btCancel = new Button()
				{
					Text = @"Відмінити",
					Font = new Font("Arial", 10, FontStyle.Regular),
					Size = new Size(80, 28),
					Location = new Point(0, 32),
					TabStop = false
				};

				formInputKey.Controls.Add(pnButtons);
				formInputKey.Controls.Add(lbInputKey);
				pnButtons.Controls.Add(btOk);
				pnButtons.Controls.Add(btCancel);

				btCancel.Click += delegate
				{
					formInputKey.Close();
				};

				btOk.Click += delegate
				{
					Properties.Controls.Default.KeyRotate = k;
					formInputKey.Close();
				};

				formInputKey.KeyDown += delegate(object o, KeyEventArgs args)
				{
					k = args.KeyData;
					lbInputKey.Text = args.KeyData.ToString();
				};

				formInputKey.ShowDialog();
			}
		}

		private void trackBar1_Scroll(object sender, EventArgs e)
		{
			Properties.Settings.Default.AudioVolume = trackBar1.Value;
			volumeLabel.Text = Properties.Settings.Default.AudioVolume.ToString();
			Sound.sfx.Volume = (float)Properties.Settings.Default.AudioVolume / 100;
		}
	}
}
