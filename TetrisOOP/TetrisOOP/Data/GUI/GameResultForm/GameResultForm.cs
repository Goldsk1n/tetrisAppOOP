using System.Windows.Forms;
using TetrisOOP.Data.Modules.Users;

namespace TetrisOOP.Data.GUI.GameResultForm
{
	public partial class GameResultForm : Form
	{
		public GameResultForm()
		{
			InitializeComponent();
			btMenu.DialogResult = DialogResult.Cancel;
			btNewGame.DialogResult = DialogResult.OK;

			lbGameLevel.Text = Properties.Game.Default.GameLevel.ToString();
			lbGameTime.Text = Properties.Game.Default.GameTime.ToString("mm:ss");
			lbGameScore.Text = Properties.Game.Default.CountScore.ToString();
			UserManager.CheckOnLevel();
		}
	}
}
