using System;
using System.Drawing;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using static Engine.EngineClass;

namespace Engine
{
	public class GameBoard
	{
		protected int BoardWidth { get; }

		protected int BoardHeight { get; }

		protected int CellSize { get; } = 20;

		protected readonly CellType[,] _cells;

		private CellType this[int row, int col]
		{
			get
			{
				try
				{
					return _cells[row, col];
				}
				catch (IndexOutOfRangeException)
				{
					return CellType.Wall;
				}
			}
		}

		public GameBoard(int height, int width)
		{
			BoardWidth = width;
			BoardHeight = height;
			_cells = new CellType[height, width];

			for (int row = 0; row < BoardHeight; row++)
			{
				for (int col = 0; col < BoardWidth; col++)
				{
					_cells[row, col] = CellType.Empty;
				}
			}
		}

		public int SetFigure(GameShape shape, bool rewrite)
		{
			int countCellsOfShape = 4;

			if (_cells[shape.Y0, shape.X0] == CellType.Empty || rewrite) _cells[shape.Y0, shape.X0] = shape.Type;
			else --countCellsOfShape;
			if (_cells[shape.Y1, shape.X1] == CellType.Empty || rewrite) _cells[shape.Y1, shape.X1] = shape.Type;
			else --countCellsOfShape;
			if (_cells[shape.Y2, shape.X2] == CellType.Empty || rewrite) _cells[shape.Y2, shape.X2] = shape.Type;
			else --countCellsOfShape;
			if (_cells[shape.Y3, shape.X3] == CellType.Empty || rewrite) _cells[shape.Y3, shape.X3] = shape.Type;
			else --countCellsOfShape;

			return countCellsOfShape;
		}

		private bool SetCell(int row, int col, CellType type)
		{
			try
			{
				_cells[row, col] = type;
				return true;
			}
			catch (IndexOutOfRangeException)
			{
				return false;
			}
		}

		protected GameShape RotateFigure(GameShape shape)
		{
			GameShape rotated = shape.Rotate();
			shape.Type = CellType.Empty;
			SetFigure(shape, true);
			shape.Type = rotated.Type;

			if (IsEmpty(rotated))
			{
				SetFigure(rotated, false);
				return rotated;
			}

			GameShape rotated2 = rotated.MoveDown();
			if (IsEmpty(rotated2))
			{
				SetFigure(rotated2, false);
				return rotated2;
			}

			rotated2 = rotated.MoveRight();
			if (IsEmpty(rotated2))
			{
				SetFigure(rotated2, false);
				return rotated2;
			}

			rotated2 = rotated.MoveLeft();
			if (IsEmpty(rotated2))
			{
				SetFigure(rotated2, false);
				return rotated2;
			}

			SetFigure(shape, false);
			return GameShape.Zero;
		}

		protected bool IsEmpty(GameShape shape)
		{
			return this[shape.Y0, shape.X0] == CellType.Empty &&
				   this[shape.Y1, shape.X1] == CellType.Empty &&
				   this[shape.Y2, shape.X2] == CellType.Empty &&
				   this[shape.Y3, shape.X3] == CellType.Empty;
		}

		protected bool IsEmpty(int row, int col)
		{
			return this[row, col] == CellType.Empty;
		}

		protected void EraseFigure(GameShape shape)
		{
			shape.Type = CellType.Empty;
			SetFigure(shape, true);
		}

		protected bool MoveDown(int row, int col)
		{
			if (_cells[row, col] != CellType.Empty)
			{
				CellType below = _cells[row + 1, col];
				if (below == CellType.Empty)
				{
					_cells[row + 1, col] = _cells[row, col];
					_cells[row, col] = CellType.Empty;
				}
				return _cells[row + 2, col] == CellType.Empty;
			}
			return false;
		}

		protected bool MoveDown(GameShape shape)
		{
			GameShape moved = shape.MoveDown();

			shape.Type = CellType.Empty;
			SetFigure(shape, true);

			if (IsEmpty(moved))
			{
				SetFigure(moved, false);
				return true;
			}

			shape.Type = moved.Type;
			SetFigure(shape, false);
			return false;
		}

		protected bool MoveRight(int row, int col)
		{
			if (_cells[row, col] != CellType.Empty)
			{
				CellType below = _cells[row, col + 1];
				if (below == CellType.Empty)
				{
					_cells[row, col + 1] = _cells[row, col];
					_cells[row, col] = CellType.Empty;
				}
				return _cells[row, col + 1] == CellType.Empty;
			}
			return false;
		}

		protected bool MoveRight(GameShape shape)
		{
			GameShape moved = shape.MoveRight();

			shape.Type = CellType.Empty;
			SetFigure(shape, true);

			if (IsEmpty(moved))
			{
				SetFigure(moved, false);
				return true;
			}
			shape.Type = moved.Type;
			SetFigure(shape, false);
			return false;
		}

		protected bool MoveLeft(int row, int col)
		{
			if (_cells[row, col] != CellType.Empty)
			{
				CellType below = _cells[row, col - 1];
				if (below == CellType.Empty)
				{
					_cells[row, col - 1] = _cells[row, col];
					_cells[row, col] = CellType.Empty;
				}
				return _cells[row, col - 1] == CellType.Empty; 
			}
			return false;
		}

		protected bool MoveLeft(GameShape shape)
		{
			GameShape moved = shape.MoveLeft();
			shape.Type = CellType.Empty;
			SetFigure(shape, true);
			if (IsEmpty(moved))
			{
				SetFigure(moved, false);
				return true;
			}
			shape.Type = moved.Type;
			SetFigure(shape, false);
			return false;
		}

		public int RemoveFullRows()
		{
			List<int> fullRows = new List<int>();

			for (int row = 0; row < BoardHeight; row++)
			{
				bool fullrow = true;
				for (int col = 0; col < BoardWidth; col++)
				{
					if (_cells[row, col] == CellType.Empty)
					{
						fullrow = false;
						break;
					}
				}
				if (fullrow) fullRows.Add(row);
			}

			foreach (int frow in fullRows)
			{
				for (int row = frow - 1; row > 0; row--)
				{
					for (int col = 0; col < BoardWidth; col++)
					{
						_cells[row + 1, col] = _cells[row, col];
						if (IsRowEmpty(row + 1)) break;
					}
				}
			}

			return BoardWidth * fullRows.Count;
		}

		protected bool IsRowEmpty(int row)
		{
			for (int col = 0; col < BoardWidth; col++)
			{
				if (_cells[row, col] != CellType.Empty) return false;
			}
			return true;
		}

		public virtual void Clear()
		{
			for (int row = 0; row < BoardHeight; row++)
			{
				for (int col = 0; col < BoardWidth; col++)
				{
					SetCell(row, col, CellType.Empty);
				}
			}
		}


		public virtual void Paint(Graphics g)
		{
			Brush sbWall = new SolidBrush(Color.FromArgb(35, 0, 0, 0));

			switch (TetrisOOP.Properties.Settings.Default.Quality)
			{
				case 0: PaintBlackShape(g); break;
				case 2: PaintSpriteShape(g, sbWall); break;
				default:
					{
						for (int row = 0; row < BoardHeight; row++)
						{
							for (int col = 0; col < BoardWidth; col++)
							{
								Rectangle tileDraw = new Rectangle(7 + col * CellSize, 7 + row * CellSize, CellSize - 2, CellSize - 2);

								Rectangle tileSmall = new Rectangle(10 + col * CellSize, 10 + row * CellSize, CellSize - 8, CellSize - 8);
								Pen p = new Pen(TetrisOOP.Properties.Settings.Default.BackColor, 2);

								switch (_cells[row, col])
								{
									case CellType.Blue:
										g.FillRectangle(Brushes.Blue, tileDraw);
										g.DrawRectangle(p, tileSmall);
										break;
									case CellType.Green:
										g.FillRectangle(Brushes.Green, tileDraw);
										g.DrawRectangle(p, tileSmall);
										break;
									case CellType.Yellow:
										g.FillRectangle(Brushes.Gold, tileDraw);
										g.DrawRectangle(p, tileSmall);
										break;
									case CellType.Purple:
										g.FillRectangle(Brushes.Purple, tileDraw);
										g.DrawRectangle(p, tileSmall);
										break;
									case CellType.Orange:
										g.FillRectangle(Brushes.Orange, tileDraw);
										g.DrawRectangle(p, tileSmall);
										break;
									case CellType.Red:
										g.FillRectangle(Brushes.Red, tileDraw);
										g.DrawRectangle(p, tileSmall);
										break;
									case CellType.LightBlue:
										g.FillRectangle(Brushes.Aqua, tileDraw);
										g.DrawRectangle(p, tileSmall);
										break;
									case CellType.Empty:
									case CellType.Wall:
										g.FillRectangle(sbWall, tileDraw);
										g.DrawRectangle(p, tileSmall);
										break;
								}
							}
						}
						break;
					}
			}
		}

		private void PaintBlackShape(Graphics g)
		{
			for (int row = 0; row < BoardHeight; row++)
			{
				for (int col = 0; col < BoardWidth; col++)
				{
					if (_cells[row, col] == CellType.Wall) continue;

					Rectangle tileDraw = new Rectangle(7 + col * CellSize, 7 + row * CellSize, CellSize - 2, CellSize - 2);
					Rectangle tileSmall = new Rectangle(10 + col * CellSize, 10 + row * CellSize, CellSize - 8, CellSize - 8);

					Pen p = new Pen(TetrisOOP.Properties.Settings.Default.BackColor, 2);
					SolidBrush b = new SolidBrush(Color.FromArgb(35, 0, 0, 0)); 

					if (_cells[row, col] == CellType.Empty)
					{
						g.FillRectangle(b, tileDraw);
						g.DrawRectangle(p, tileSmall);
					}
					else 
					{
						g.FillRectangle(Brushes.Black, tileDraw);
						g.DrawRectangle(p, tileSmall);
					}
				}
			}
		}

		private void PaintSpriteShape(Graphics g, Brush sbWall)
		{
			for (int row = 0; row < BoardHeight; row++)
			{
				for (int col = 0; col < BoardWidth; col++)
				{
					if (_cells[row, col] == CellType.Wall) continue;

					Rectangle tileSprite = new Rectangle(7 + col * CellSize, 7 + row * CellSize, CellSize, CellSize);

					switch (_cells[row, col])
					{
						case CellType.Blue: g.DrawImage(Blue, tileSprite); break;
						case CellType.Green: g.DrawImage(Green, tileSprite); break;
						case CellType.Yellow: g.DrawImage(Yellow, tileSprite); break;
						case CellType.Purple: g.DrawImage(Purple, tileSprite); break;
						case CellType.Orange: g.DrawImage(Orange, tileSprite); break;
						case CellType.Red: g.DrawImage(Red, tileSprite); break;
						case CellType.LightBlue: g.DrawImage(LightBlue, tileSprite); break;
						case CellType.Empty:
						case CellType.Wall:
							g.DrawImage(BackField, tileSprite);
							break;
					}
				}
			}
		}

		public static Bitmap LightBlue, Green, Purple, Blue, Orange, Red, Yellow, BackField, BackBox;

	}
}
