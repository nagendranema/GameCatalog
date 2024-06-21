using GameCatalog.Models;
using GameCatalog.Repository;
using System.Reflection;

namespace GameCatalogTests
{
    [TestClass]
    public class GameRepositoryTests
    {
        private IGameRepository _gameRepository;

        //public GameRepositoryTests(IGameRepository gameRepository)
        //{
        //    _gameRepository = gameRepository;
        //}

        [TestInitialize]
        public void TestInitialize()
        {
            _gameRepository = new GameRepository();
        }

        [TestMethod]
        public void GetAllGames_ReturnsCorrectGamesCount()
        {
            // Arrange 
            int expected = 10; 
            
            // Act
            int actual = _gameRepository.GetAllGames().Count();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetGamesPerPage_ReturnsCorrectGameAndPageCount()
        {
            // Arrange 
            int expectedlRecordCountPerPage = 3;
            int expectedPageCount = 4;
            int page = 2;
            int pageSize = 3;

            // Act
            var result = _gameRepository.GetGamesPerPage(page, pageSize);
            int actualRecordCountPerPage = result.GamesPerPage.Count();
            int actualPageCount = result.Pages;
            // Assert
            Assert.AreEqual(expectedPageCount, actualPageCount);
            Assert.AreEqual(expectedlRecordCountPerPage, actualRecordCountPerPage);
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void GetGamesPerPage_IfPageDoesNotExist_ThrowsNotFoundException()
        {
            // Arrange 
            int page = 10;
            int pageSize = 3;

            // Act
            var result = _gameRepository.GetGamesPerPage(page, pageSize); // should throw NotFoundException

            // Assert - handled by ExpectedException attribute
        }
        [TestMethod]
        public void GetGameById_ReturnsCorrectGame()
        {
            // Arrange
            var expectedGame = new Game { Id = 1, Description = "Embark on a quest to save Princess Zelda in the kingdom of Hyrule.", Genre = "Action-Adventure", Price = 29.99M, ReleaseDate = Convert.ToDateTime("1986-02-21"), StockQuantity =  100, Title = "The Legend of Zelda" };
            int id = 1;

            // Act
            var actualGame = _gameRepository.GetGameById(id);

            // Assert
            Assert.AreEqual(expectedGame.Id, actualGame.Id);
            Assert.AreEqual(expectedGame.Price, actualGame.Price);
            Assert.AreEqual(expectedGame.Genre, actualGame.Genre);
            Assert.AreEqual(expectedGame.ReleaseDate, actualGame.ReleaseDate);
            Assert.AreEqual(expectedGame.Description, actualGame.Description);
            Assert.AreEqual(expectedGame.Title, actualGame.Title);
            Assert.AreEqual(expectedGame.StockQuantity, actualGame.StockQuantity);
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void GetGameById_ThrowsNotFoundException()
        {
            // Arrange
            int nonExistingGameId = 100;

            // Act
            var result = _gameRepository.GetGameById(nonExistingGameId); // should throw NotFoundException

            // Assert - handled by ExpectedException attribute
        }

        [TestMethod]
        public void AddGame_SavesNewGame()
        {
            // Arrange
            int expected = 11;
            var gameToSave = new Game
            {
                Id = 11,
                Description = "Speed through levels as Sonic, the fastest hedgehog on the planet.",
                Genre = "Platform",
                Price = 20.00M,
                ReleaseDate = Convert.ToDateTime("1991-06-23"),
                StockQuantity = 10,
                Title = "Sonic the Hedgehog"
            };

            // Act
            var result = _gameRepository.AddGame(gameToSave).Count();

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateItemException))]
        public void AddGame_IfGameExists_ThrowsDuplicateItemException()
        {
            // Arrange
            var existingGame = new Game
            {
                Id = 10,
                Description = "Speed through levels as Sonic, the fastest hedgehog on the planet.",
                Genre = "Platform",
                Price = 20.00M,
                ReleaseDate = Convert.ToDateTime("1991-06-23"),
                StockQuantity = 10,
                Title = "Sonic the Hedgehog"
            };

            // Act
            _gameRepository.AddGame(existingGame);

            // Assert - handled by ExpectedException attribute
        }

        [TestMethod]
        public void UpdateGame_UpdatesExistingGame()
        {
            // Arrange            
            var updatedGame = new Game
            {
                Id = 10,
                Description = "Speed through levels as Sonic, the fastest hedgehog on the planet.",
                Genre = "Platform2",
                Price = 20.00M,
                ReleaseDate = Convert.ToDateTime("1991-06-23"),
                StockQuantity = 10,
                Title = "Sonic the Hedgehog"
            };

            // Act
            var actualUpdatedGame = _gameRepository.UpdateGame(updatedGame);

            // Assert
            Assert.AreEqual(updatedGame.Genre, actualUpdatedGame.Genre);
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void UpdateGame_IfGameDoesNotExist_ThrowsNotFoundException()
        {
            // Arrange
            var nonExistingGame = new Game
            {
                Id = 100,
                Description = "Speed through levels as Sonic, the fastest hedgehog on the planet.",
                Genre = "Platform2",
                Price = 20.00M,
                ReleaseDate = Convert.ToDateTime("1991-06-23"),
                StockQuantity = 10,
                Title = "Sonic the Hedgehog"
            };

            // Act
            _gameRepository.UpdateGame(nonExistingGame);

            // Assert - handled by ExpectedException attribute
        }

        [TestMethod]
        public void DeleteGame_DeletesExistingGame()
        {
            // Arrange
            var existingId = 1;
            int expectedRecordCount = 9;

            // Act
            int actualRecordCount = _gameRepository.DeleteGame(existingId).Count();

            // Assert
            Assert.AreEqual(expectedRecordCount, actualRecordCount);
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void DeleteGame_IfGameDoesNotExist_ThrowsNotFoundException()
        {
            // Arrange
            int nonExistingGameId = 100;

            // Act
            _gameRepository.DeleteGame(nonExistingGameId);

            // Assert - handled by ExpectedException attribute
        }
    }
}