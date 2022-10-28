using System.Drawing;
using System.Windows.Forms;

namespace Engine
{
    class Settings
    {
        private int _quality;
        private FormWindowState _sizeScreen;

        private bool _borderScreen;

        private FormBorderStyle _borderStyle;

        private bool _nextShape;

        private bool _shadowShape;

        public Settings()
        {
            Read();
        }

		public void Read()
		{
			_nextShape = TetrisOOP.Properties.Settings.Default.NextShape;
			_shadowShape = TetrisOOP.Properties.Settings.Default.ShadowShape;

			_quality = TetrisOOP.Properties.Settings.Default.Quality;
			_sizeScreen = TetrisOOP.Properties.Settings.Default.SizeScreen;
			_borderScreen = TetrisOOP.Properties.Settings.Default.BorderScreen;
			_borderStyle = TetrisOOP.Properties.Settings.Default.BorderStyle;

			_borderStyle = _borderScreen ? FormBorderStyle.None : FormBorderStyle.Sizable;
			_borderStyle = TetrisOOP.Properties.Settings.Default.BorderStyle;

			_sizeScreen = _borderScreen ? FormWindowState.Maximized : FormWindowState.Normal;
			_sizeScreen = TetrisOOP.Properties.Settings.Default.SizeScreen;
		}

		public void Apply()
		{
			TetrisOOP.Properties.Settings.Default.NextShape = _nextShape;
			TetrisOOP.Properties.Settings.Default.ShadowShape = _shadowShape;

			TetrisOOP.Properties.Settings.Default.Quality = _quality;
			TetrisOOP.Properties.Settings.Default.BorderScreen = _borderScreen;

			_borderStyle = _borderScreen ? FormBorderStyle.None : FormBorderStyle.Sizable;
			TetrisOOP.Properties.Settings.Default.BorderStyle = _borderStyle;

			_sizeScreen = _borderScreen ? FormWindowState.Maximized : FormWindowState.Normal;
			TetrisOOP.Properties.Settings.Default.SizeScreen = _sizeScreen;

			Graphic();
			ControlsGame();
		}

		public static void Reset()
		{
			TetrisOOP.Properties.Settings.Default.Reset();
		}

		private static void ControlsGame()
		{
			if (TetrisOOP.Properties.Settings.Default.Arrow)
			{
				TetrisOOP.Properties.Controls.Default.KeyDown = Keys.Down;
				TetrisOOP.Properties.Controls.Default.KeyLeft = Keys.Left;
				TetrisOOP.Properties.Controls.Default.KeyRight = Keys.Right;
				TetrisOOP.Properties.Controls.Default.KeyUp = Keys.Up;
			}
			else if (TetrisOOP.Properties.Settings.Default.WASD)
			{
				TetrisOOP.Properties.Controls.Default.KeyDown = Keys.S;
				TetrisOOP.Properties.Controls.Default.KeyLeft = Keys.A;
				TetrisOOP.Properties.Controls.Default.KeyRight = Keys.D;
				TetrisOOP.Properties.Controls.Default.KeyUp = Keys.W;
			}


		}

		private static void Graphic()
		{
			TetrisOOP.Properties.Settings.Default.ShapeBlack = TetrisOOP.Properties.Settings.Default.Quality == 0;
			TetrisOOP.Properties.Settings.Default.SpriteShape = TetrisOOP.Properties.Settings.Default.Quality == 2;
			TetrisOOP.Properties.Settings.Default.BackColor
				= TetrisOOP.Properties.Settings.Default.Quality == 2
				? Color.FromArgb(255, 25, 45, 75)
				: Color.FromArgb(255, 156, 172, 135);
			TetrisOOP.Properties.Settings.Default.Background
				= TetrisOOP.Properties.Settings.Default.Quality == 2
					? Color.FromArgb(255, 0, 0, 64)
					: Color.FromArgb(255, 10, 150, 140);
		}
	}
}
