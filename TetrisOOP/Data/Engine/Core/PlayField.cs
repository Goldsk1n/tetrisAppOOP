using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using static Engine.EngineClass;

namespace Engine
{
	/// <summary>Являє собою ігрове поле.</summary> 
	public class PlayField : GameBoard
	{
		#region Переменные
		/// <summary>Поточна фігура на ігровому полі.</summary>
		private GameShape Current;
		/// <summary>Стан поточної фігури.</summary>
		public bool IsFigureFalling { get; private set; }

		/// <summary>Стан підказки падаючої фігури</summary>
		private readonly bool ShowTips;
		#endregion

		/// <summary>Ініціалізує ігрове поле./summary>
		public PlayField(int height, int width) : base(height, width)
		{
			IsFigureFalling = false;
			ShowTips = true;
			Current = GameShape.Zero;
		}

		#region Дії з фігурою
		/// <summary>Розміщує нову фігуру зверху поля.</summary>
		/// <param name="shape">Нова фигура.</param>
		/// <returns>Стан розміщеної фігури.</returns>
		public bool PlaceShape(GameShape shape)
		{
			shape = shape.MoveTo(0, BoardWidth / 2 - 1);
			int scs = SetFigure(shape, false);
			Current = shape;
			if (scs != 4) return false; //кінець гри
			IsFigureFalling = true;
			return true;
		}

		/// <summary>Замінює поточну фігуру на нову.</summary>
		/// <param name="newShape">Нова фигура.</param>
		/// <returns>Попередню фігуру або порожню фігуру, якщо не вдалося розмістити</returns>
		public GameShape ChangeFigure(GameShape newShape)
		{
			if (Current == GameShape.Zero) return Current;
			GameShape old = Current;
			EraseFigure(old);
			if (!PlaceShape(newShape))
				return GameShape.Zero;
			return old;
		}

		/// <summary>Повертає поточну фігуру за годинниковою стрілкою.</summary>
		/// <returns>Булевий результат виконання</returns>
		public bool RotateFigure()
		{
			if (Current == GameShape.Zero) return false;
			GameShape t = RotateFigure(Current);
			if (t == GameShape.Zero) return false;
			Current = t;
			return true;
		}

		/// <summary>Зміщує фігуру униз до границі.</summary>
		/// <returns>Булевий результат виконання</returns>
		public bool Drop()
		{
			if (Current == GameShape.Zero) return false;
			while (Current != GameShape.Zero)
				DoStep();
			return true;
		}

		/// <summary>Рухає фігуру.</summary>
		public void DoStep()
		{
			if (Current != GameShape.Zero)
			{
				IsFigureFalling = MoveDown(Current);
				Current = IsFigureFalling ? Current.MoveDown() : GameShape.Zero;
				// якщо фігура впала, то змінюємо ціль
			}
			else IsFigureFalling = false;
		}

		#endregion

		#region Поворот фігури
		/// <summary>Зміщує фигуру вліво.</summary>
		/// <returns>Булевий результат виконання</returns>
		public bool MoveLeft()
		{
			if (Current == GameShape.Zero) return false;
			if (!MoveLeft(Current)) return false;
			Current = Current.MoveLeft();
			return true;
		}

		/// <summary>Зміщує фигуру вправо.</summary>
		/// <returns>Булевий результат виконання.</returns>
		public bool MoveRight()
		{
			if (Current == GameShape.Zero) return false;
			if (!MoveRight(Current)) return false;
			Current = Current.MoveRight();
			return true;
		}

		/// <summary>Зміщує фигуру вниз.</summary>
		/// <returns>Булевий результат виконання.</returns>
		public bool MoveDown()
		{
			if (Current == GameShape.Zero) return false;
			if (!MoveDown(Current)) return false;
			Current = Current.MoveDown();
			return true;
		}
		#endregion

		#region Дії з полем
		/// <summary>Очищує ігрове поле.</summary>
		public override void Clear()
		{
			base.Clear();
			Current = GameShape.Zero;
			IsFigureFalling = false;
		}

		/// <summary>Очищает найнижчу лінію та зміщує усе інше вниз.</summary>
		public void RemoveOneRows()
		{
			for (int i = 0; i < 10; i++)
			{
				_cells[BoardHeight - 1, i] = CellType.Empty;
			}

			// зміщуємо вниз
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
		#endregion

		#region Малювання
		/// <summary>Малювання тіні (підказки)</summary>
		public override void Paint(Graphics g)
		{
			base.Paint(g);

			if (!ShowTips
				|| !IsFigureFalling
				|| !TetrisOOP.Properties.Settings.Default.ShadowShape) return;

			GameShape tip = Current;
			// тимчасово видаляємо поточну фігуру
			EraseFigure(Current);

			while (IsEmpty(tip)) // зміщуємо нижче, поки не наткнемося на перешкоду
			{
				tip = tip.MoveDown();
			}

			tip = tip.MoveUp(); // дійшли до перешкоди

			SetFigure(Current, false); // повертаємо

			Point[] cells =
			{
				new Point(tip.X0, tip.Y0), new Point(tip.X1, tip.Y1),
				new Point(tip.X2, tip.Y2), new Point(tip.X3, tip.Y3)
			};

			// підсказка прозорим квадратом
			Brush colorShadowPen = new SolidBrush(Color.FromArgb(70, 255, 255, 255));

			foreach (Point cell in cells)
			{
				if (!IsEmpty(cell.Y, cell.X)) continue;

				g.FillRectangle(colorShadowPen, 8 + cell.X * CellSize, 8 + cell.Y * CellSize, CellSize, CellSize);
			}
		}

		#endregion
	}
}