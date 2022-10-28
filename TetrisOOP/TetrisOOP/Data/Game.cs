using System;
using Engine;

namespace GameTetris
{
	public class Game
	{
		public GameShape NextShape;

		public DateTime GameStarted;

		public DateTime GamePaused;

		private bool _gameOver;

		public bool GameOver
		{
			get => _gameOver;
			set
			{
				_gameOver = value;
				OnStateChanged();
			}
		}

		private bool _paused;

		public bool Paused
		{
			get => _paused;
			set
			{
				if (!_paused && value)
				{
					GamePaused = DateTime.Now;
					_paused = value;
					OnStateChanged();
				}

				if (!_paused || value) return;

				GameStarted = GameStarted + (DateTime.Now - GamePaused);
				_paused = value;
				OnStateChanged();
			}
		}

		private bool _figChanged;

		public bool FigureChanged
		{
			get => _figChanged;
			set
			{
				_figChanged = value;
				OnStateChanged();
			}
		}

		private int _score;
		public int Score
		{
			get => _score;
			set
			{
				_score = value;
				OnStateChanged();
			}
		}

		private int _time;

		public int Time
		{
			get => (int)(Math.Pow(0.8 - ((_level - 1) * 0.007), _level - 1) * 1000);
			set
			{
				_time = value;
				OnStateChanged();
			}
		}

		private int _level;

		public int Level
		{
			get
			{
				const int MAX_LEVEL = 10;
				_level = (_lines + 10) / 10; 
				if (_level > MAX_LEVEL) _level = MAX_LEVEL; 
				return _level;
			}
			set
			{
				_level = value;
				OnStateChanged();
			}
		}

		private int _lines;

		public int Lines
		{
			get => _lines;
			set
			{
				_lines = value;
				OnStateChanged();
			}
		}

		private int _shapeDropped;
		public int ShapeDropped
		{
			get => _shapeDropped;
			set
			{
				_shapeDropped = value;
				OnStateChanged();
			}
		}

		public Game()
		{
			Score = 0;
			Lines = 0;
			Level = 1;
			Paused = false;
			GameOver = false;
			FigureChanged = false;
			GameStarted = DateTime.Now;
			NextShape = GameShape.RandomFigure();
		}

		public void Over()
		{
			GameOver = true;
		}

		public event EventHandler StateChanged;

		private void OnStateChanged()
		{
			StateChanged?.Invoke(this, new EventArgs());
		}
	}
}
