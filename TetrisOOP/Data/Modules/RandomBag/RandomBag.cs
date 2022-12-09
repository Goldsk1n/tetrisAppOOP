using System;
using System.Collections.Generic;

namespace Engine
{
	public class RandomBag
	{
		#region Властивості

		public Queue<int> ShapeHistory { get; }

		public int MaxNum { get; set; }
		public int MinNum { get; set; }

		public int BagSize { get; set; }

		public int RandomTries { get; set; }

		/// <summary>
		///     Генератор випадкових чисел.
		/// </summary>
		private static readonly Random rand = new Random();
		#endregion //Властивості

		#region Ініціалізація

		/// <summary>Конструктор</summary>
		/// <param name="maxNum">Максимальне число</param>
		/// <param name="minNum">Мінімальне число</param>
		/// <param name="bagSize">Розмір сумки з фігурами (кількість фігур)</param>
		/// <param name="randomTries">Кількість спроб генерації нової фігури, при випаденні однакових</param>
		public RandomBag(int minNum, int maxNum, int bagSize = 7, int randomTries = 4)
		{
			MinNum = minNum;
			MaxNum = maxNum;
			BagSize = bagSize;
			RandomTries = randomTries;
			ShapeHistory = new Queue<int>();
		}
		#endregion //Инициализация

		#region Методи

		/// <summary>
		///     Створити випадкову фігуру.
		/// </summary>
		/// <returns>Тетрад: псевдо-випадковий тетрад, згенерований з використанням алгоритму TGM</returns>
		public int Next()
		{
			var randomShape = 0;

			var i = 0;
			while (i < RandomTries)
			{
				// отримати випадкову фігуру
				randomShape = rand.Next(MinNum, MaxNum);

				// Чи не повторюється фігура у найближчому часі
				var bFound = false;
				foreach (int num in ShapeHistory)
					if (num == randomShape)
					{
						bFound = true;
						break;
					}
				if (bFound)
					i++;
				else
					break;
			}

			// Отриману нову фігуру додаємо до черги
			AddShapeToHistory(randomShape);

			// Повернення нової фігури
			return randomShape;
		}

		/// <summary>Додає фігуру до черги.</summary>
		/// <param name="shapeType">Тип фігури доданої до черги</param>
		public void AddShapeToHistory(int shapeType)
		{
			ShapeHistory.Enqueue(shapeType);

			//перевірка розміру черги фігур
			while (ShapeHistory.Count > BagSize) ShapeHistory.Dequeue();
		}
		#endregion //Методи
	}
}