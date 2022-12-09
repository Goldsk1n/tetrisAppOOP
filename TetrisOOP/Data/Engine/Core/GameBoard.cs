using System;
using System.Drawing;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using static Engine.EngineClass;

namespace Engine
{
	/// <summary>Являє собою ігрову дошку.</summary> 
	public class GameBoard
	{
		#region Змінні
		/// <summary>Ширина ігрової дошки в клітинках.</summary> 
		protected int BoardWidth { get; }

		/// <summary>Висота ігрової дошки в клітинках.</summary>
		protected int BoardHeight { get; }

		/// <summary>Розмір клітинки на дошці в пікселях.</summary> 
		protected int CellSize { get; } = 20;

		/// <summary>Двовимірний масив, що зберігає усі клітинки дошки.</summary> 
		public CellType[,] _cells;

		/// <summary>Отримує тип клітинки(у випадку виходу за межі - стінка).</summary>
		/// <param name="row">Положення по горизонталі.</param> 
		/// <param name="col">Положення по вертикалі.</param> 
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

		#endregion

		/// <summary>Ініціалізує ігрову дошку.</summary>
		public GameBoard(int height, int width)
		{
			BoardWidth = width;
			BoardHeight = height;
			// Створення ігрової дошки
			_cells = new CellType[height, width];

			// Заповнюємо дошку порожніми значеннями
			for (int row = 0; row < BoardHeight; row++)
			{
				for (int col = 0; col < BoardWidth; col++)
				{
					_cells[row, col] = CellType.Empty;
				}
			}
		}

		#region Дії з фігурою на ігровій дошці
		/// <summary>Розміщує фігуру на ігрову дошку.</summary>
		/// <param name="shape">Фігура.</param>
		/// <param name="rewrite">true, якщо необхідно перезаписати клітинку.</param>
		/// <returns>Кількість клітинок фігури, що вдалося розмістити на дошці.</returns>
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

		/// <summary>Встановлює тип конкретної клітинки.</summary>
		/// <param name="row">Положення по горизонталі.</param> 
		/// <param name="col">Положення по вертикалі.</param> 
		/// <param name="type">Тип клітинки.</param>
		/// <returns>true, якщо клітинка розміщена на полі, false - якщо ні.</returns>
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

		/// <summary>Поворот фігури на 90 градусів за годинниковою стрілкою.</summary>
		/// <param name="shape">Фігура, яку потрібно повернути.</param>
		/// <returns>Повертається обернена фігура.</returns>
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
			// Якщо невдача, то потрібно змістити фігуру вниз
			GameShape rotated2 = rotated.MoveDown();
			if (IsEmpty(rotated2))
			{
				SetFigure(rotated2, false);
				return rotated2;
			}
			// Вправо
			rotated2 = rotated.MoveRight();
			if (IsEmpty(rotated2))
			{
				SetFigure(rotated2, false);
				return rotated2;
			}
			// Вліво
			rotated2 = rotated.MoveLeft();
			if (IsEmpty(rotated2))
			{
				SetFigure(rotated2, false);
				return rotated2;
			}
			// Не вдалося обернути
			SetFigure(shape, false);
			return GameShape.Zero;
		}

		/// <summary>Перевірка фігури на порожні клітинки.</summary>
		/// <param name="shape">Фігура.</param>
		/// <returns>true, якщо всі клітинки фігури порожні, false - якщо ні.</returns>
		protected bool IsEmpty(GameShape shape)
		{
			return this[shape.Y0, shape.X0] == CellType.Empty &&
				   this[shape.Y1, shape.X1] == CellType.Empty &&
				   this[shape.Y2, shape.X2] == CellType.Empty &&
				   this[shape.Y3, shape.X3] == CellType.Empty;
		}

		/// <summary>Перевірка клітинки на порожність за координатами.</summary>
		/// <param name="row">Положення по горизонталі.</param>
		/// <param name="col">Положення по вертикалі.</param>
		/// <returns>true, якщо клітинка порожня, false - якщо ні.</returns>
		protected bool IsEmpty(int row, int col)
		{
			return this[row, col] == CellType.Empty;
		}

		/// <summary>Стирає фігуру з ігрового поля.</summary>
		/// <param name="shape">Фігура.</param>
		protected void EraseFigure(GameShape shape)
		{
			shape.Type = CellType.Empty;
			SetFigure(shape, true);
		}
		#endregion

		#region Смещение клеток на игровой доске
		/// <summary>Зміщує фігуру униз, якщо можливо.</summary>
		/// <param name="row">Координата по горизонталі</param>
		/// <param name="col">Координата по вертикалі</param>
		/// <returns>Чи можливий здвиг клітинки униз</returns>
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

		/// <summary>Переміщує фігуру униз</summary>
		/// <param name="shape">Фігура - сукупність клітинок</param>
		/// <returns>Чи можливий здвиг фігури униз</returns>
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

		/// <summary>Зміщує фігуру вправо, якщо можливо.</summary>
		/// <param name="row">Координата по горизонталі</param>
		/// <param name="col">Координата по вертикалі</param>
		/// <returns>Чи можливий здвиг клітинки вправо</returns>
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

		/// <summary>Переміщує фігуру вправо</summary>
		/// <param name="shape">Фігура - сукупність клітинок</param>
		/// <returns>Чи можливий здвиг фігури вправо</returns>
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

		/// <summary>Зміщує фігуру вліво, якщо можливо.</summary>
		/// <param name="row">Координата по горизонталі</param>
		/// <param name="col">Координата по вертикалі</param>
		/// <returns>Чи можливий здвиг клітинки вліво</returns>
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

		/// <summary>Переміщує фігуру вліво</summary>
		/// <param name="shape">Фігура - сукупність клітинок</param>
		/// <returns>Чи можливий здвиг фігури вліво</returns>
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
		#endregion

		#region Действия с клетками на игровой доске
		/// <summary>Видаляє заповнені ряди зі зміщенням усіх інших.</summary>
		/// <returns>Кількість знищених клітинок.</returns>
		public int RemoveFullRows()
		{
			// Список заповнених рядів до видалення
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

			// Видаляємо зі зміщенням донизу
			foreach (int frow in fullRows)
			{
				for (int row = frow - 1; row > 0; row--)
				{
					// Зміщуємо row = row + 1
					for (int col = 0; col < BoardWidth; col++)
					{
						_cells[row + 1, col] = _cells[row, col];
						// Попередній ряд порожній, отже й вищі порожні
						if (IsRowEmpty(row + 1)) break;
					}
				}
			}

			return BoardWidth * fullRows.Count; // Повертаємо кількість видалених клітинок
		}

		/// <summary>Перевірка ряду на порожні клітинки.</summary>
		/// <param name="row">Ряд для перевірки.</param>
		/// <returns>Чи є порожні клітинки у ряді.</returns>
		protected bool IsRowEmpty(int row)
		{
			for (int col = 0; col < BoardWidth; col++)
			{
				if (_cells[row, col] != CellType.Empty) return false;
			}
			return true;
		}

		/// <summary>Очищує поле від фігур.</summary>
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
		#endregion


		#region Відрисовка
		/// <summary>Відрисовка фігури.</summary>
		/// <param name="g">Поверхня малювання для фігури.</param>
		public virtual void Paint(Graphics g)
		{
			// колір порожньої клітинки
			Brush sbWall = new SolidBrush(Color.FromArgb(35, 0, 0, 0));

			switch (TetrisOOP.Properties.Settings.Default.Quality)
			{
				case 0: PaintBlackShape(g); break;
				case 2: PaintSpriteShape(g, sbWall); break;
				default: // кольорові програмно нарисовані фігури
					{
						for (int row = 0; row < BoardHeight; row++)
						{
							for (int col = 0; col < BoardWidth; col++)
							{
								Rectangle tileDraw = new Rectangle(7 + col * CellSize, 7 + row * CellSize, CellSize - 2, CellSize - 2);

								// маленький квадратик всередині фігури
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

		/// <summary>Заповнення поля прозорими чорними фігурами и закраска самої фігури.</summary>
		/// <param name="g">Поверхня малювання для фігури.</param>
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

					// закраска фону прозорими квадратами
					if (_cells[row, col] == CellType.Empty)
					{
						g.FillRectangle(b, tileDraw);
						g.DrawRectangle(p, tileSmall);
					}
					else // заливка фігури
					{
						g.FillRectangle(Brushes.Black, tileDraw);
						g.DrawRectangle(p, tileSmall);
					}
				}
			}
		}

		/// <summary>Заповнення поля фігурами з спрайтів.</summary>
		/// <param name="g">Поверхня малювання для фігури.</param>
		/// <param name="sbWall"></param>
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
		/// <summary>Спрайти для ігрових фігур.</summary>
		public static Bitmap LightBlue, Green, Purple, Blue, Orange, Red, Yellow, BackField, BackBox;
		#endregion
	}
}
