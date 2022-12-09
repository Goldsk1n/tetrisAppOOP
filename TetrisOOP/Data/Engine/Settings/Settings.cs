using System.Drawing;
using System.Windows.Forms;
using TetrisOOP.Data.Modules.Audio;

namespace Engine
{
	/// <summary>Являє налаштування додатку.</summary> 
	class Settings
    {
		#region Змінні

		/// <summary>Якість графіки: 0 - низька, 1 - середня, 2 - висока.</summary>
		private int _quality;

		/// <summary>Поточний стан екрану.</summary>
		private FormWindowState _sizeScreen;

		/// <summary>Режим екрану (рамка або повноекранний)</summary>
		private bool _borderScreen;

        private FormBorderStyle _borderStyle;

		/// <summary>Показ наступної фігури</summary>
		private bool _nextShape;

		/// <summary>Тінь фігури</summary>
		private bool _shadowShape;

		/// <summary>Гучність звуку гри</summary>
		private int _volume;

		#endregion

		public Settings()
        {
            Read();
        }

		#region Методы
		/// <summary>Отримує параметри з файлу з налаштуваннями</summary>
		public void Read()
		{
			#region Гра
			_nextShape = TetrisOOP.Properties.Settings.Default.NextShape;
			_shadowShape = TetrisOOP.Properties.Settings.Default.ShadowShape;
			#endregion

			#region Графіка
			_quality = TetrisOOP.Properties.Settings.Default.Quality;
			_sizeScreen = TetrisOOP.Properties.Settings.Default.SizeScreen;
			_borderScreen = TetrisOOP.Properties.Settings.Default.BorderScreen;
			_borderStyle = TetrisOOP.Properties.Settings.Default.BorderStyle;

			_borderStyle = _borderScreen ? FormBorderStyle.None : FormBorderStyle.Sizable;
			_borderStyle = TetrisOOP.Properties.Settings.Default.BorderStyle;

			_sizeScreen = _borderScreen ? FormWindowState.Maximized : FormWindowState.Normal;
			_sizeScreen = TetrisOOP.Properties.Settings.Default.SizeScreen;
			#endregion

			_volume = TetrisOOP.Properties.Settings.Default.AudioVolume;
		}

		/// <summary>Задає параметри із файлу з налаштуваннями</summary>
		public void Apply()
		{
			#region Гра
			TetrisOOP.Properties.Settings.Default.NextShape = _nextShape;
			TetrisOOP.Properties.Settings.Default.ShadowShape = _shadowShape;
			#endregion

			#region Графіка
			TetrisOOP.Properties.Settings.Default.Quality = _quality;
			TetrisOOP.Properties.Settings.Default.BorderScreen = _borderScreen;

			_borderStyle = _borderScreen ? FormBorderStyle.None : FormBorderStyle.Sizable;
			TetrisOOP.Properties.Settings.Default.BorderStyle = _borderStyle;

			_sizeScreen = _borderScreen ? FormWindowState.Maximized : FormWindowState.Normal;
			TetrisOOP.Properties.Settings.Default.SizeScreen = _sizeScreen;
			#endregion

			TetrisOOP.Properties.Settings.Default.AudioVolume = _volume;

			Graphic();
			ControlsGame();
		}

		/// <summary>Встановлює налаштування за замовчуванням.</summary>
		public static void Reset()
		{
			TetrisOOP.Properties.Settings.Default.Reset();
			Sound.sfx.Volume = (float)TetrisOOP.Properties.Settings.Default.AudioVolume / 100;
		}

		/// <summary>Встановлює керування в залежності від налаштувань</summary>
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

		/// <summary>Встановлює графіку</summary>
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
		#endregion
	}
}
