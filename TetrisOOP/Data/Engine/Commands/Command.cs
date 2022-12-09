using GameTetris;
using TetrisOOP.Data.GUI;

namespace Engine.Commands
{
	/// <summary>Клас Команди оголошує метод для виконання команд.</summary>
	public abstract class Command
	{
		protected readonly PlayField _playField;
		protected readonly Game _game;

		protected Command(PlayField playField)
		{
			_playField = playField;
		}

		protected Command(Game game)
		{
			_game = game;
		}

		public abstract void Execute();
	}

	/// <summary>Клас ініціалізатор команд, відправляє запит на команду.</summary>
	public class Invoker
	{
		/// <summary>Команда для виконання</summary>
		private Command _command;
		
		public Command Command
		{
			set => _command = value;
		}
		/// <summary>Запуск команди</summary>
		public void Run()
		{
			_command?.Execute(); // якщо є команда, то виконуємо
			_command = null; // після виконання очищуємо 
		}
	}
    #region Команди руху та пауза
    public class MoveLeft : Command
	{
		public MoveLeft(PlayField playField) : base(playField) { }

		public override void Execute()
		{
			_playField.MoveLeft();
		}
	}

	public class MoveRight : Command
	{
		public MoveRight(PlayField playField) : base(playField) { }

		public override void Execute()
		{
			_playField.MoveRight();
		}
	}

	public class MoveDown : Command
	{
		public MoveDown(PlayField playField) : base(playField) { }

		public override void Execute()
		{
			_playField.MoveDown();
		}
	}

	public class MoveDrop : Command
	{
		public MoveDrop(PlayField playField) : base(playField) { }

		public override void Execute()
		{
			_playField.Drop();
		}
	}

	public class MoveRotate : Command
	{
		public MoveRotate(PlayField playField) : base(playField) { }

		public override void Execute()
		{
			_playField.RotateFigure();
		}
	}

	public class MovePause : Command
	{
		public MovePause(Game game) : base(game) { }

		public override void Execute()
		{
			// змінюємо значення на протилежне
			_game.Paused = !_game.Paused;

			// відкриваємо форму паузи
			MenuPauseForm menu = new MenuPauseForm();
			menu.ShowDialog();

			// після закриття меню паузи продовжити гру
			_game.Paused = !_game.Paused;
		}
	}
    #endregion
}