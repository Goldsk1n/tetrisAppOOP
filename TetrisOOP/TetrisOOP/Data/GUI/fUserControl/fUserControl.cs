using System;
using System.Windows.Forms;
using TetrisOOP.Data.Modules.Users;

namespace TetrisOOP.Data.GUI.UserControl
{
	public partial class FUserControl : Form
	{
		public FUserControl()
		{
			InitializeComponent();
		}

		private async void BtnEntry_Click(object sender, EventArgs e)
		{
			string name = tbLogin.Text;
			string pass = tbPass.Text;

			if (await UserManager.Auth(name, pass)) Close();
			else MessageBox.Show("Невірний пароль або ім'я користувача.", "Хибні дані.");
		}

		private async void BtnRegistr_Click(object sender, EventArgs e)
		{
			string name = tbLoginReg.Text;
			string pass = tbPassReg.Text;

			UserManager.ChangeLastUser();
			UserManager.AddNewUser(name, UserManager._users.Count.ToString(), pass, "0","0", "1", "0", "0:00:00",0,0, "true");
			await UserManager.Auth(name, pass);
			Close();
		}
	}
}
