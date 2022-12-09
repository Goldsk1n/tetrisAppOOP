using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using TetrisOOP.Properties;
using System.Windows.Forms;
using System.Collections.Generic;
using Octokit;
using System.Threading.Tasks;
using System.Text;
using System.Linq;

namespace TetrisOOP.Data.Modules.Users
{
	internal class UserManager
	{
		/// <summary>Список зареєстрованих користувачів.</summary>
		public static List<User> _users = new List<User>();

		private static GitHubClient gitHubClient = new GitHubClient(new ProductHeaderValue("TetrisOOPApp"));
		private static string owner = "m1ndctrl";
		private static string repoName = "tetrisAppOOP";
		private static string filePath = "Users/users.xml";
		private static string branch = "main";

		public UserManager()
		{
			gitHubClient.Credentials = new Credentials("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");//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
			_ = LoadUsers();
		}

		/// <summary>Завантажує усіх користувачів з бази у активний список.</summary>
		public static async Task<List<User>> LoadUsers()
		{			
			try
			{
				await Task.Delay(1000);
				
				var fileDetails = await gitHubClient.Repository.Content.GetAllContentsByRef(owner, repoName, filePath, branch);
				
				XmlDocument doc = new XmlDocument();
				doc.Load(fileDetails[0].DownloadUrl);

				foreach (XmlNode node in doc.DocumentElement)
				{
					string name = node.Attributes[0].Value;
					int id = int.Parse(node["id"].InnerText);
					string password = node["pass"].InnerText;
					int score = int.Parse(node["score"].InnerText);
					int record = int.Parse(node["record"].InnerText);
					int level = int.Parse(node["level"].InnerText);
					int levelScore = int.Parse(node["levelScore"].InnerText);
					TimeSpan timeInGame = TimeSpan.Parse(node["timeInGame"].InnerText);
					int numberOfGames = int.Parse(node["numberOfGames"].InnerText);
					bool last = bool.Parse(node["last"].InnerText);

					var user = new User
					{
						Id = id,
						Name = name,
						Password = password,
						Score = score,
						Record = record,
						Level = level,
						LevelScore = levelScore,
						TimeInGame = timeInGame,
						NumberOfGames = numberOfGames,
						Last = last
					};
					_users.Add(user);
				}
				return _users;
			}
			catch (Exception e)
			{
				MessageBox.Show(@"Ошибка при загрузке пользователей. " + e);
				throw;
			}
		}

		public static async void AddNewUser(string name, string id, string pass, string score, string record, string level, string lvlScoreTxt, string timeInGame, int numberOfGames, string last)
		{
			try
			{
				await Task.Delay(1000);

				var fileDetails = await gitHubClient.Repository.Content.GetAllContentsByRef(owner, repoName, filePath, branch);

				XDocument xdoc = XDocument.Load(fileDetails[0].DownloadUrl);
				XElement root = xdoc.Element("users");

				root.Add(new XElement("user",
						new XAttribute("name", name),
						new XElement("id", id),
						new XElement("pass", pass),
						new XElement("score", score),
						new XElement("record", record),
						new XElement("level", level),
						new XElement("levelScore", lvlScoreTxt),
						new XElement("timeInGame", timeInGame),
						new XElement("numberOfGames", numberOfGames),
						new XElement("last", last)
						));

				var updateResult = await gitHubClient.Repository.Content.UpdateFile(owner, repoName, filePath,
					new UpdateFileRequest("Updated users", xdoc.ToString(), fileDetails[0].Sha));

				var user = new User
				{
					Id = int.Parse(id),
					Name = name,
					Password = pass,
					Score = int.Parse(score),
					Record = int.Parse(record),
					Level = int.Parse(level),
					LevelScore = int.Parse(lvlScoreTxt),
					TimeInGame = TimeSpan.Parse(timeInGame),
					NumberOfGames = numberOfGames,
					Last = bool.Parse(last)
				};
				_users.Add(user);
			}
			catch (Exception e)
			{
				MessageBox.Show(@"addnewuser. " + e);
				throw;
			}
			
		}

		public static async Task<bool> Auth(string name, string pass)
		{
			try
			{
				await Task.Delay(1000);

				var fileDetails = await gitHubClient.Repository.Content.GetAllContentsByRef(owner, repoName, filePath, branch);

				XDocument xdoc = XDocument.Load(fileDetails[0].DownloadUrl);

				foreach (XElement userElement in xdoc.Element("users").Elements("user"))
				{
					XAttribute nameAtr = userElement.Attribute("name");
					XElement passElem = userElement.Element("pass");
					XElement idElem = userElement.Element("id");

					if (nameAtr.Value == name)
					{
						if (passElem.Value == pass)
						{
							ChangeLastUser();
							InitUser(int.Parse(idElem.Value));
							return true;
						}
					}
				}

				return false;
			}
			catch (Exception e)
			{
				MessageBox.Show(@"auth. " + e);
				throw;
			}
			
		}

		public static async void SaveUserData()
		{
			try
			{
				var fileDetails = await gitHubClient.Repository.Content.GetAllContentsByRef(owner, repoName, filePath, branch);

				XDocument xdoc = XDocument.Load(fileDetails[0].DownloadUrl);

				foreach (XElement userElement in xdoc.Element("users").Elements("user"))
				{
					string name = Settings.Default.UserName;
					string userScore = Settings.Default.UserScore;
					string userRecord = Settings.Default.UserRecord;
					string level = Settings.Default.Level;
					string levelScore = Settings.Default.LevelScore.ToString();
					string timeInGame = Settings.Default.TimeInGame.ToString();
					string numberOfGames = Settings.Default.NumberOfGames.ToString();
				
					XAttribute nameAtr = userElement.Attribute("name");
					XElement idElem = userElement.Element("id");
					XElement scoreElem = userElement.Element("score");
					XElement recordElem = userElement.Element("record");
					XElement levelElem = userElement.Element("level");
					XElement levelScoreElem = userElement.Element("levelScore");
					XElement timeInGameElem = userElement.Element("timeInGame");
					XElement numberOfGamesElem = userElement.Element("numberOfGames");

					if (nameAtr.Value == name)
					{
						ChangeLastUser();
						scoreElem.Value = userScore;
						recordElem.Value = userRecord;
						levelElem.Value = level;
						levelScoreElem.Value = levelScore;
						timeInGameElem.Value = timeInGame;
						numberOfGamesElem.Value = numberOfGames;
					}
				}

				var updateResult = await gitHubClient.Repository.Content.UpdateFile(owner, repoName, filePath,
					new UpdateFileRequest("Updated users", xdoc.ToString(), fileDetails[0].Sha, branch));

			}
			catch (Exception e)
			{
				MessageBox.Show(@"saveuserdata. " + e);
				throw;
			}
			
		}

		/// <summary>Змінює у всіх користувачів last на false.</summary>
		public static async void ChangeLastUser()
		{
			try
			{
				await Task.Delay(1000);
				var fileDetails = await gitHubClient.Repository.Content.GetAllContentsByRef(owner, repoName, filePath, branch);

				XmlDocument xDoc = new XmlDocument();
				xDoc.Load(fileDetails[0].DownloadUrl);
				XmlElement xRoot = xDoc.DocumentElement;

				XmlNodeList childnodes = xRoot.SelectNodes("//user/last");
				foreach (XmlNode n in childnodes)
					n.InnerText = "false";

				var updateResult = await gitHubClient.Repository.Content.UpdateFile(owner, repoName, filePath,
					new UpdateFileRequest("Updated users", xDoc.InnerXml, fileDetails[0].Sha));
			}
			catch (Exception e)
			{
				MessageBox.Show(@"changelastuser. " + e);
				throw;
			}
		}


		public static void CheckOnLevel()
		{
			int score = int.Parse(Settings.Default.UserScore);

			int max_level = 50;
			double[] ranges = new double[max_level];

			for (int i = 1; i <= max_level; i++)
			{
				ranges[i - 1] = Math.Round(10000 * Math.Pow(1.15, i));
			}

			for (int i = 0; i < max_level; i++)
			{
				if (score <= ranges[i])
				{
					Settings.Default.Level = (i + 1).ToString();
					Settings.Default.ScoreForNextLevel = ranges[i].ToString();
					Settings.Default.LevelScoreMax = Convert.ToInt32(ranges[i]);
					Settings.Default.LevelScore = score;

					double perc = Math.Round(Convert.ToDouble(score) / Convert.ToDouble(Settings.Default.LevelScoreMax) * 100);
					Settings.Default.LevelScorePerc = perc + "%";

					goto end;
				}
			}

		end:;
		}

		/// <summary>Додає інформацію про користувача із вказаним номером до активної сесії.</summary>
		private static async void InitUser(int id)
		{
			await Task.Delay(1000);
			
			Settings.Default.UserName = _users[id].Name;
			Settings.Default.NumberUsers = _users.Count.ToString();
			Settings.Default.UserScore = _users[id].Score.ToString();
			Settings.Default.UserRecord = _users[id].Record.ToString();
			Settings.Default.Level = _users[id].Level.ToString();
			Settings.Default.LevelScore = _users[id].LevelScore;
			Settings.Default.LevelScorePerc = (_users[id].LevelScore / 1000) + "%";
			Settings.Default.TimeInGame = _users[id].TimeInGame;
			Settings.Default.NumberOfGames = _users[id].NumberOfGames;
		}

		public static async Task<Dictionary<string, string>> GetTopUsers()
		{
			var fileDetails = await gitHubClient.Repository.Content.GetAllContentsByRef(owner, repoName, filePath, branch);
			XDocument xdoc = XDocument.Load(fileDetails[0].DownloadUrl);
			XElement root = xdoc.Element("users");
			var playersByTopScore = root.Elements("user").OrderByDescending(user => (int)user.Element("record"));

			var names = playersByTopScore.Select(user => user.Attribute("name").Value).ToList().GetRange(0, 10);
			var scores = playersByTopScore.Select(user => user.Element("record").Value).ToList().GetRange(0, 10);
			var data = names.Zip(scores, (k, v) => new { k, v })
			  .ToDictionary(x => x.k, x => x.v);

			return data;
		}
	}
}
