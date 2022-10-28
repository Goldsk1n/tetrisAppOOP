using static Engine.EngineClass;

namespace Engine
{
	public struct GameShape
	{
		public int X0 { get; private set; }
		public int Y0 { get; private set; }

		public int X1 { get; private set; }
		public int Y1 { get; private set; }

		public int X2 { get; private set; }
		public int Y2 { get; private set; }

		public int X3 { get; private set; }
		public int Y3 { get; private set; }

		public CellType Type { get; set; }

		public static readonly GameShape Zero = new GameShape(CellType.Empty);

		private static readonly RandomBag _random = new RandomBag(1, 8);


		private GameShape(CellType type) : this()
		{
			Type = type;
			X0 = Y0 = 0;

			CreateTetromino(type);
		}


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

		public static GameShape RandomFigure()
		{
			int rnd = _random.Next();
			_random.AddShapeToHistory(rnd);
			return new GameShape((CellType)rnd);
		}

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

		public static bool operator !=(GameShape s1, GameShape s2)
		{
			return !(s1 == s2);
		}

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

		public GameShape MoveDown()
		{
			return MoveTo(Y0 + 1, X0);
		}

		public GameShape MoveUp()
		{
			return MoveTo(Y0 - 1, X0);
		}

		public GameShape MoveRight()
		{
			return MoveTo(Y0, X0 + 1);
		}

		public GameShape MoveLeft()
		{
			return MoveTo(Y0, X0 - 1);
		}


		private int RotateCol(int col)
		{
			return Y0 - X0 + col;
		}

		private int RotateRow(int row)
		{
			return X0 - row + Y0;
		}

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
	}
}