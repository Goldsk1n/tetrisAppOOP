using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using static Engine.EngineClass;

namespace Engine
{
	public class PlayField : GameBoard
	{
		private GameShape Current;
		public bool IsFigureFalling { get; private set; }

		private readonly bool ShowTips;

		public PlayField(int height, int width) : base(height, width)
		{
			IsFigureFalling = false;
			ShowTips = true;
			Current = GameShape.Zero;
		}

		public bool PlaceShape(GameShape shape)
		{
			shape = shape.MoveTo(0, BoardWidth / 2 - 1);
			int scs = SetFigure(shape, false);
			Current = shape;
			if (scs != 4) return false;
			IsFigureFalling = true;
			return true;
		}

		public GameShape ChangeFigure(GameShape newShape)
		{
			if (Current == GameShape.Zero) return Current;
			GameShape old = Current;
			EraseFigure(old);
			if (!PlaceShape(newShape))
				return GameShape.Zero;
			return old;
		}

		public bool RotateFigure()
		{
			if (Current == GameShape.Zero) return false;
			GameShape t = RotateFigure(Current);
			if (t == GameShape.Zero) return false;
			Current = t;
			return true;
		}

		public bool Drop()
		{
			if (Current == GameShape.Zero) return false;
			while (Current != GameShape.Zero)
				DoStep();
			return true;
		}

		public void DoStep()
		{
			if (Current != GameShape.Zero)
			{
				IsFigureFalling = MoveDown(Current);
				Current = IsFigureFalling ? Current.MoveDown() : GameShape.Zero;
			}
			else IsFigureFalling = false;
		}

		public bool MoveLeft()
		{
			if (Current == GameShape.Zero) return false;
			if (!MoveLeft(Current)) return false;
			Current = Current.MoveLeft();
			return true;
		}

		public bool MoveRight()
		{
			if (Current == GameShape.Zero) return false;
			if (!MoveRight(Current)) return false;
			Current = Current.MoveRight();
			return true;
		}

		public bool MoveDown()
		{
			if (Current == GameShape.Zero) return false;
			if (!MoveDown(Current)) return false;
			Current = Current.MoveDown();
			return true;
		}

		public override void Clear()
		{
			base.Clear();
			Current = GameShape.Zero;
			IsFigureFalling = false;
		}

		public void RemoveOneRows()
		{
			for (int i = 0; i < 10; i++)
			{
				_cells[BoardHeight - 1, i] = CellType.Empty;
			}

			for (int row = BoardHeight - 2; row > 0; row--)
			{
				for (int col = 0; col < BoardWidth; col++)
				{
					if (IsRowEmpty(row))
					{
						for (int i = 0; i < BoardWidth; i++)
						{
							_cells[row + 1, i] = CellType.Empty;
						}
						goto LoopEnd;
					}
					_cells[row + 1, col] = _cells[row, col];
				}
			}
		LoopEnd:;
		}

		public override void Paint(Graphics g)
		{
			base.Paint(g);

			if (!ShowTips
				|| !IsFigureFalling
				|| !TetrisOOP.Properties.Settings.Default.ShadowShape) return;

			GameShape tip = Current;

			EraseFigure(Current);

			while (IsEmpty(tip))
			{
				tip = tip.MoveDown();
			}

			tip = tip.MoveUp();

			SetFigure(Current, false);

			Point[] cells =
			{
				new Point(tip.X0, tip.Y0), new Point(tip.X1, tip.Y1),
				new Point(tip.X2, tip.Y2), new Point(tip.X3, tip.Y3)
			};

			Brush colorShadowPen = new SolidBrush(Color.FromArgb(70, 255, 255, 255));

			foreach (Point cell in cells)
			{
				if (!IsEmpty(cell.Y, cell.X)) continue;

				g.FillRectangle(colorShadowPen, 8 + cell.X * CellSize, 8 + cell.Y * CellSize, CellSize, CellSize);
			}
		}

	}
}