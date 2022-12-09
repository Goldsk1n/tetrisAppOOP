using System;

namespace TetrisOOP.Data.Modules.Users
{
	/// <summary>Клас, що представляє користувача</summary>
	internal class User
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Password { get; set; }
		public int Score { get; set; }
		public int Record { get; set; }
		public int Level { get; set; }
		public int LevelScore { get; set; }
		public TimeSpan TimeInGame { get; set; }
		public int NumberOfGames { get; set; }
		public bool Last { get; set; }
	}
}