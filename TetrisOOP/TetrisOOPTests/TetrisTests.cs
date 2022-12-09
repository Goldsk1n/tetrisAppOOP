using System;
using System.Collections.Generic;
using System.Text;
using TetrisOOP;
using Xunit;
using Engine;
using GameTetris;
using static Engine.EngineClass;
using TetrisOOP.Data.Modules.Users;
using System.Threading.Tasks;
using System.Net;

namespace TetrisOOP.Tests
{

    public class TetrisTests
    {
        [Fact]
        public void RandomFigure()
        {
            // Arrange
            RandomBag r = new RandomBag(1, 8);
            // Act
            int randomFigureId = r.Next();
            // Assert
            Assert.InRange(randomFigureId, 1, 8);
        }

        [Fact]
        public void CreateBoard()
        {
            // Arrange
            GameBoard gb = new GameBoard(5, 5);
            // Act
            CellType a = gb._cells[3, 3];
            // Assert
            Assert.Equal(CellType.Empty, a);
        }

        [Fact]
        public void PlaceShape()
        {
            // Arrange
            PlayField pf = new PlayField(5, 5);
            // Act
            GameShape figure = GameShape.RandomFigure();
            bool placed = pf.PlaceShape(figure);
            // Assert
            Assert.True(placed);
        }

        [Fact]
        public void RemoveRows()
        {
            // Arrange
            GameBoard gb = new GameBoard(4, 3);
            gb._cells = new CellType[,] { { CellType.Empty, CellType.Empty, CellType.Empty },
                                          { CellType.Green, CellType.Empty, CellType.Blue },
                                          { CellType.Green, CellType.Green, CellType.Blue },
                                          { CellType.Green, CellType.Blue, CellType.Blue } };
            // Act
            int removedCells = gb.RemoveFullRows();
            // Assert
            Assert.Equal(6, removedCells);
        }

        [Fact]
        public async void Authentificate()
        {
            // Arrange
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            // Act
            bool authentificated = await UserManager.Auth("bruh", "4444");
            // Assert
            Assert.True(authentificated);
        }

        [Fact]
        public async void GameTimeSync()
        {
            // Arrange
            Game g = new Game();
            // Act
            DateTime pauseTime = g.GameStarted;
            g.Paused = true;
            await Task.Delay(3000);
            g.Paused = false;
            // Assert
            Assert.Equal(g.GamePaused.AddSeconds(3), g.GameStarted, new TimeSpan(0,0,1));
        }

        [Fact]
        public void LineScore()
        {
            // Arrange
            GameForm gf = new GameForm();
            // Act
            gf._playField._cells = new CellType[,] {
                { CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty },
                { CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty },
                { CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty },
                { CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty },
                { CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty },
                { CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty },
                { CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty },
                { CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty },
                { CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty },
                { CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty },
                { CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty },
                { CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty },
                { CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty },
                { CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty },
                { CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty },
                { CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty },
                { CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty },
                { CellType.Empty, CellType.Empty, CellType.Empty, CellType.Empty, CellType.Blue, CellType.Blue, CellType.Green, CellType.Blue, CellType.Blue, CellType.Green },
                { CellType.Green, CellType.Blue, CellType.Blue, CellType.Green, CellType.Blue, CellType.Blue, CellType.Green, CellType.Blue, CellType.Blue, CellType.Green },
                { CellType.Green, CellType.Blue, CellType.Blue, CellType.Green, CellType.Blue, CellType.Blue, CellType.Green, CellType.Blue, CellType.Blue, CellType.Green } 
            };
            int score = gf.GetNowScore();
            // Assert
            Assert.Equal(300, score);
        }

        [Fact]
        public void ManipulateFigure()
        {
            // Arrange
            GameShape figI = new GameShape(CellType.LightBlue);
            // Act
            figI.MoveDown();
            figI.MoveLeft();
            figI.Rotate();
            // Assert
            Assert.Equal(( CellType.LightBlue, 0, -1, 1, 2, 0, 0, 0, 0), 
                (figI.Type, figI.X0, figI.X1, figI.X2, figI.X3, figI.Y0, figI.Y1, figI.Y2, figI.Y3));
        }

        [Fact]
        public async void LoadUsers()
        {
            // Arrange
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            // Act
            List<User> userNum = await UserManager.LoadUsers();
            // Assert
            Assert.Equal(5, userNum.Count);
        }

        [Fact]
        public void GameScore()
        {
            // Arrange
            GameForm gf = new GameForm();
            // Act
            int gameScore = gf._game.Score;
            int defaultScore = Properties.Game.Default.CountScore;
            // Assert
            Assert.Equal(gameScore, defaultScore);
        }
    }
}
