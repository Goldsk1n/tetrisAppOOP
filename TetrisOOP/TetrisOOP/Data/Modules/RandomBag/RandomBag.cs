using System;
using System.Collections.Generic;

namespace Engine
{
	public class RandomBag
	{
		public Queue<int> ShapeHistory { get; }

		public int MaxNum { get; set; }
		public int MinNum { get; set; }

		public int BagSize { get; set; }

		public int RandomTries { get; set; }

		private static readonly Random rand = new Random();

		public RandomBag(int minNum, int maxNum, int bagSize = 7, int randomTries = 4)
		{
			MinNum = minNum;
			MaxNum = maxNum;
			BagSize = bagSize;
			RandomTries = randomTries;
			ShapeHistory = new Queue<int>();
		}

		public int Next()
		{
			var randomShape = 0;

			var i = 0;
			while (i < RandomTries)
			{
				randomShape = rand.Next(MinNum, MaxNum);

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

			AddShapeToHistory(randomShape);

			return randomShape;
		}

		public void AddShapeToHistory(int shapeType)
		{
			ShapeHistory.Enqueue(shapeType);

			while (ShapeHistory.Count > BagSize) ShapeHistory.Dequeue();
		}

	}
}