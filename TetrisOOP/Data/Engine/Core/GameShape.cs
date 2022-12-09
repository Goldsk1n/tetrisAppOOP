using static Engine.EngineClass;

namespace Engine
{
	public struct GameShape
	{
		#region Комірки фігури
		public int X0 { get; private set; }
		public int Y0 { get; private set; }

		public int X1 { get; private set; }
		public int Y1 { get; private set; }

		public int X2 { get; private set; }
		public int Y2 { get; private set; }

		public int X3 { get; private set; }
		public int Y3 { get; private set; }
		#endregion

		#region Змінні
		/// <summary>Тип клітинеи.</summary> 
		public CellType Type { get; set; }

		/// <summary>Створення нової порожньої фігури.</summary> 
		public static readonly GameShape Zero = new GameShape(CellType.Empty);

		/// <summary>Генерує випадкове число для фігури</summary>
		private static readonly RandomBag _random = new RandomBag(1, 8);

		#endregion

		/// <summary>Ініціалізує форму фігури за кольором.</summary> 
		public GameShape(CellType type) : this()
		{
			Type = type;
			// Початкові координати
			X0 = Y0 = 0;

			// Створюємо форму за кольором
			CreateTetromino(type);
		}

		#region Дії з фігурою
		/// <summary>Створює форму фігури за кольором.</summary> 
		private void CreateTetromino(CellType type)
		{
			switch (type)
			{
				case CellType.Red:
					{
						X1 = X0 - 1;
						X2 = X0;
						X3 = X0 + 1;
						Y1 = Y0;
						Y2 = Y3 = Y0 + 1;
						break;
					}
				case CellType.Green:
					{
						X1 = X0 - 1;
						X2 = X0;
						X3 = Y1 = Y2 = Y0 + 1;
						Y3 = Y0;
						break;
					}
				case CellType.Blue:
					{
						X1 = X0 - 1;
						X2 = X3 = X0 + 1;
						Y1 = Y2 = Y0;
						Y3 = Y0 + 1;
						break;
					}
				case CellType.Yellow:
					{
						X1 = X0 + 1;
						X2 = X0;
						X3 = X0 + 1;
						Y1 = Y0;
						Y2 = Y3 = Y0 + 1;
						break;
					}
				case CellType.Orange:
					{
						X1 = X2 = X0 - 1;
						X3 = X0 + 1;
						Y1 = Y0 + 1;
						Y2 = Y3 = Y0;
						break;
					}
				case CellType.Purple:
					{
						X1 = X0 - 1;
						X2 = X0;
						X3 = X0 + 1;
						Y1 = Y0;
						Y2 = Y0 + 1;
						Y3 = Y0;
						break;
					}
				case CellType.LightBlue:
					{
						X1 = X0 - 1;
						X2 = X0 + 1;
						X3 = X0 + 2;
						Y1 = Y2 = Y3 = Y0;
						break;
					}
				default:
					{
						X3 = X2 = X1 = X0 = 0;
						Y3 = Y2 = Y1 = Y0 = 0;
						break;
					}
			}
		}

		/// <summary>Генерується випадкова фігура з сумки, виходячи з історії.</summary> 
		/// <returns>Повертяється фігура випадкового типу</returns>
		public static GameShape RandomFigure()
		{
			int rnd = _random.Next();
			_random.AddShapeToHistory(rnd);
			return new GameShape((CellType)rnd);
		}

		/// <summary>Перевірка двох фігур на рівність за типом та координатами.</summary>
		/// <param name="s1">Перша фігура.</param>
		/// <param name="s2">Друга фігура.</param>
		/// <returns>Чи однакові фігури</returns>
		public static bool operator ==(GameShape s1, GameShape s2)
		{
			if (s1.Type != s2.Type) return false;
			return s1.X0 == s2.X0 &&
				   s1.Y0 == s2.Y0 &&
				   s1.X1 == s2.X1 &&
				   s1.X2 == s2.X2 &&
				   s1.X3 == s2.X3 &&
				   s1.Y1 == s2.Y1 &&
				   s1.Y2 == s2.Y2 &&
				   s1.Y3 == s2.Y3;
		}

		/// <summary>Перевірка двох фігур на НЕрівність за типом та координатами.</summary>
		/// <param name="s1">Перша фігура.</param>
		/// <param name="s2">Друга фігура.</param>
		/// <returns>Чи не однакові фігури</returns>
		public static bool operator !=(GameShape s1, GameShape s2)
		{
			return !(s1 == s2);
		}

		/// <summary>Створює копію фігури.</summary>
		/// <returns>Повертається копія фігури.</returns>
		private GameShape Clone()
		{
			GameShape clonedShape = new GameShape(Type)
			{
				X0 = X0,
				Y0 = Y0,
				X1 = X1,
				Y1 = Y1,
				X2 = X2,
				Y2 = Y2,
				X3 = X3,
				Y3 = Y3
			};
			return clonedShape;
		}
		#endregion

		#region Переміщення фігури
		/// <summary>Переміщує фігуру у положення y = row, x = col.</summary>
		/// <returns>Повертається переміщенна фігура.</returns>
		public GameShape MoveTo(int row, int col)
		{
			int dx = col - X0;
			int dy = row - Y0;

			GameShape movedShape = new GameShape(Type)
			{
				X0 = col,
				Y0 = row,
				X1 = X1 + dx,
				Y1 = Y1 + dy,
				X2 = X2 + dx,
				Y2 = Y2 + dy,
				X3 = X3 + dx,
				Y3 = Y3 + dy
			};

			return movedShape;
		}

		/// <summary>Зміщує фигуру униз.</summary>
		/// <returns>Повертається зміщена униз фігура.</returns>
		public GameShape MoveDown()
		{
			return MoveTo(Y0 + 1, X0);
		}

		/// <summary>Зміщує фигуру вгору.</summary>
		/// <returns>Повертається зміщена вгору фігура.</returns>
		public GameShape MoveUp()
		{
			return MoveTo(Y0 - 1, X0);
		}

		/// <summary>Зміщує фигуру вправо.</summary>
		/// <returns>Повертається зміщена вправо фігура.</returns>
		public GameShape MoveRight()
		{
			return MoveTo(Y0, X0 + 1);
		}

		/// <summary>Зміщує фигуру вліво.</summary>
		/// <returns>Повертається зміщена вліво фігура.</returns>
		public GameShape MoveLeft()
		{
			return MoveTo(Y0, X0 - 1);
		}

		#endregion


		#region Поворот фігури
		/// <summary>Горизонтальний поворот клітинки відносно центра фігури на 90 градусів.</summary>
		/// <param name="col">Координата по вертикалі.</param>
		/// <returns>Повертається  координата клітинки.</returns>
		private int RotateCol(int col)
		{
			return Y0 - X0 + col;
		}

		/// <summary>Вертикальний поворот клітинки відносно центра фігури на 90 градусів.</summary>
		/// <param name="col">Координата по горизонталі.</param>
		/// <returns>Повертається координата клітинки.</returns>
		private int RotateRow(int row)
		{
			return X0 - row + Y0;
		}

		/// <summary>Повертає цілу фігуру на чверть оберта за годинником.</summary>
		/// <returns>Повернута фігура.</returns>
		public GameShape Rotate()
		{
			GameShape res = Clone();
			res.X1 = RotateRow(Y1);
			res.Y1 = RotateCol(X1);
			res.X2 = RotateRow(Y2);
			res.Y2 = RotateCol(X2);
			res.X3 = RotateRow(Y3);
			res.Y3 = RotateCol(X3);
			return res;
		}
		#endregion
	}
}