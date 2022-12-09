using System;
using Engine;

namespace GameTetris
{
	/// <summary>Представляє ігрову логіку.</summary> 
	public class Game
	{
		#region Переменные
		/// <summary>Наступна фігура.</summary>
		public GameShape NextShape;

		/// <summary>Час початку гри.</summary>
		public DateTime GameStarted;

		/// <summary>Час гри у стані паузи.</summary>
		public DateTime GamePaused;

		private bool _gameOver;
		/// <summary>Змінна стану гри</summary>
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
		/// <summary>Змінна стану паузи</summary>
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
		/// <summary>Змінна стану фігури</summary>
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
		/// <summary>Ігровий рахунок</summary>
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
		/// <summary>Швидкість фігури в залежності від складності</summary>
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
		/// <summary>Рівень складності гри</summary>
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
		/// <summary>Кількість усіх знищених ліній</summary>
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
		/// <summary>Кількість фігур, які впали</summary>
		public int ShapeDropped
		{
			get => _shapeDropped;
			set
			{
				_shapeDropped = value;
				OnStateChanged();
			}
		}
		#endregion

		#region Ініціалізація
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
		#endregion /ініціалізація

		#region Методи
		/// <summary>Завершує гру.</summary>
		public void Over()
		{
			GameOver = true;
		}

		/// <summary>Подія зміни стану.</summary>
		public event EventHandler StateChanged;
		/// <summary>Якщо стан змінився, то додаємо нову подію.</summary>
		private void OnStateChanged()
		{
			StateChanged?.Invoke(this, new EventArgs());
		}
		#endregion
	}
}
