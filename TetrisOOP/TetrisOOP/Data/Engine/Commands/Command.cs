using GameTetris;
using TetrisOOP.Data.GUI;

namespace Engine.Commands
{

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

	public class Invoker
	{
		private Command _command;

		public Command Command
		{
			set => _command = value;
		}

		public void Run()
		{
			_command?.Execute();
			_command = null;
		}
	}

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
			_game.Paused = !_game.Paused;

			MenuPauseForm menu = new MenuPauseForm();
			menu.ShowDialog();

			_game.Paused = !_game.Paused;
		}
	}
}