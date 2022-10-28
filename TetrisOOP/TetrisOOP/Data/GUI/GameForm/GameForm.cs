using System;
using Engine;
using GameTetris;
using System.Drawing;
using Engine.Commands;
using System.Windows.Forms;
using TetrisOOP.Data.GUI.GameResultForm;
using TetrisOOP.Data.Modules.Users;
using System.Media;

namespace TetrisOOP
{
	public partial class GameForm : Form
	{
		private readonly PlayField _playField;

		private readonly GameBoard _nextShape;

		private readonly Invoker shapeControl = new Invoker();

		private Game _game;

		private int _countRemoveRows;

		private DateTime ElapsedTime = new DateTime(0, 0);

		public GameForm()
		{
			_game = new Game();

			_playField = new PlayField(20, 10);
			_nextShape = new GameBoard(2, 4);
			_game.StateChanged += Game_StateChanged;

			_game.StateChanged += Game_StateChanged;

			InitializeComponent();

			NewGame();
		}

		private void NewGame()
		{
			_game = new Game
			{
				Score = Properties.Game.Default.CountScore,
				Lines = 0
			};
			_game.StateChanged += Game_StateChanged;
			_game.NextShape = GameShape.RandomFigure();

			GameTimer.Enabled = false;
			GameTimer.Enabled = true;
			RealTimer.Enabled = true;

			_playField.Clear();
		}

		private void SetTime()
		{
			GameTimer.Interval = _game.Time;
		}

		private void SetLines()
		{
			_game.Lines += _countRemoveRows;
		}

		private void SetScore(int nowScore)
		{
			_game.Score = nowScore;
		}

		private int GetNowScore()
		{
			int scoreForLines;
			_countRemoveRows = _playField.RemoveFullRows() / 10;
			switch (_countRemoveRows)
			{
				case 1: scoreForLines = 100; break;
				case 2: scoreForLines = 300; break;
				case 3: scoreForLines = 500; break;
				case 4: scoreForLines = 800; break;
				default: scoreForLines = 1; break;
			}
			return _game.Score + scoreForLines * _game.Level;
		}
		private void OnGameOver()
		{
			_game.Over();
			GameTimer.Enabled = false;
			RealTimer.Enabled = false;

			// складывание очков за игру в общее количество
			Properties.Settings.Default.UserScore = (int.Parse(Properties.Settings.Default.UserScore) + _game.Score).ToString();

			// слкадывание общего времени в игре
			DateTime AllTime = Properties.Settings.Default.TimeInGame;

			AllTime = AllTime.AddHours(ElapsedTime.Hour);
			AllTime = AllTime.AddMinutes(ElapsedTime.Minute);
			AllTime = AllTime.AddSeconds(ElapsedTime.Second);

			Properties.Settings.Default.TimeInGame = AllTime;

			lbElapsedTime.Text = ElapsedTime.ToString("mm:ss");
			
			// проверка и установка результата на рекорд
			int record = int.Parse(Properties.Settings.Default.UserRecord);
			if (record < _game.Score) Properties.Settings.Default.UserRecord = _game.Score.ToString();

			// увеличение количество сыгранных игр
			Properties.Settings.Default.NumberOfGames++;

			// сохранение результата
			Properties.Game.Default.CountScore = _game.Score;
			Properties.Game.Default.GameTime = ElapsedTime;
			Properties.Game.Default.GameLevel = _game.Level;


			// результат игры
			var gameResultForm = new GameResultForm();
			DialogResult dialogResult = gameResultForm.ShowDialog();
			switch (dialogResult)
			{
				case DialogResult.OK: NewGame(); break;
				case DialogResult.Cancel: Close(); break;
			}
		}


		#region События
		/// <summary>Событие при изменение состояния игры.</summary>
		private void Game_StateChanged(object sender, EventArgs e)
		{
			lbScore.Text = _game.Score.ToString();
			lbLinesDestroy.Text = _game.Lines.ToString();
			lbLevel.Text = _game.Level.ToString();

			if (_game.Paused) // если активирована пауза
			{
				GameTimer.Enabled = false;
				RealTimer.Enabled = false;
				pbPauseOff.Visible = false;
				pbPauseOn.Visible = true;
			}
			else
			{
				GameTimer.Enabled = true;
				RealTimer.Enabled = true;
				pbPauseOff.Visible = true;
				pbPauseOn.Visible = false;
			}
		}


		#region Таймеры
		/// <summary>Игровой цикл.</summary>
		private void GameTimer_Tick(object sender, EventArgs e)
		{
			if (_game.Paused) return;

			SetScore(GetNowScore());
			SetLines();
			SetTime();

			_playField.DoStep();

			if (!_playField.IsFigureFalling)
			{
				if (!_playField.PlaceShape(_game.NextShape)) OnGameOver();
				else
				{
					_game.NextShape = GameShape.RandomFigure();
					_game.ShapeDropped++;
					_nextShape.Clear();
					if (Properties.Settings.Default.NextShape) _nextShape.SetFigure(_game.NextShape.MoveTo(0, 1), false);

					if (_game.FigureChanged && _game.ShapeDropped % 5 == 0) _game.FigureChanged = false;
				}
			}
			Refresh();
		}

		/// <summary>Таймер для отображения реального времени.</summary>
		private void RealTimer_Tick(object sender, EventArgs e)
		{
			// сколько прошло с начала игры
			ElapsedTime = ElapsedTime.AddSeconds(1);
			lbElapsedTime.Text = ElapsedTime.ToString("mm:ss");
			// текущее системное время
			lbNowTime.Text = DateTime.Now.ToString(@"HH:mm");
		}
		#endregion /таймеры

		/// <summary>Управление фигурой.</summary>
		private void GameForm_KeyDown(object sender, KeyEventArgs e)
		{
			e.SuppressKeyPress = true;

			// бонус - удалить линию !!!
			if (e.KeyData == Keys.W) _playField.RemoveOneRows();


			if (_game.GameOver) return;

			if (e.KeyData == Keys.Escape) shapeControl.Command = new MovePause(_game);

			if (!_game.Paused)
			{
				if (e.KeyData == Properties.Controls.Default.KeyLeft)   shapeControl.Command = new MoveLeft(_playField);
				if (e.KeyData == Properties.Controls.Default.KeyRight)  shapeControl.Command = new MoveRight(_playField);
				if (e.KeyData == Properties.Controls.Default.KeyDown)   shapeControl.Command = new MoveDown(_playField);
				if (e.KeyData == Properties.Controls.Default.KeyUp)     shapeControl.Command = new MoveDrop(_playField);
				if (e.KeyData == Properties.Controls.Default.KeyRotate) shapeControl.Command = new MoveRotate(_playField);
			}

			shapeControl.Run();
			Refresh();
		}

		private void GameForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			UserManager.CheckOnLevel();
		}
		#endregion /события


		#region Рисование
		/// <summary>Рисование игрового поля.</summary>
		private void PbGameField_Paint(object sender, PaintEventArgs e)
		{
			_playField.Paint(e.Graphics);
		}

		/// <summary>Рисование следующей фигуры.</summary>
		private void PbNextFigure_Paint(object sender, PaintEventArgs e)
		{
			Properties.Game.Default.BorderColor = _game.FigureChanged ? Color.FromArgb(160, 128, 128) : TetrisOOP.Properties.Game.Default.BackColor;
			_nextShape.Paint(e.Graphics);
		}
		#endregion /рисование

		private void GameForm_Load(object sender, EventArgs e)
		{
			SoundPlayer player = new SoundPlayer(Properties.Resources.IngameMusic);
			player.Play();
		}
	}
}
