using System;
using System.Windows.Forms;

namespace TetrisOOP.Data.GUI
{
	public partial class MenuPauseForm : Form
	{
		public MenuPauseForm()
		{
			InitializeComponent();
		}

		private void BtContinue_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void MenuPauseForm_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape) Close();
		}

		private void BtSettings_Click(object sender, EventArgs e)
		{
			SettingsForm.SettingsForm settings = new SettingsForm.SettingsForm();
			settings.ShowDialog();
		}

		private void BtConcede_Click(object sender, EventArgs e)
		{
			DialogResult dialogResult = MessageBox.Show("Вы впевнені, що хочете завершити гру?\nРезультат не буде збережений.", "Завершення гри", MessageBoxButtons.YesNo);
			switch (dialogResult)
			{
				case DialogResult.Yes:
					Form gameForm = Application.OpenForms[2];
					gameForm.Close();
					Close();
					break;
				case DialogResult.No: break;
			}
		}
	}
}
