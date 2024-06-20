using GameCatalog.Models;
using Newtonsoft.Json;

namespace GameCatalog.Repository
{
    /// <summary>
    /// Game Repository
    /// </summary>
    public class GameRepository : IGameRepository
    {
        private List<Game> _games;

        public GameRepository()
        {
            _games = new List<Game>();
            _games = JsonToList();
        }
        /// <summary>
        /// Get All Games
        /// </summary>
        /// <returns>List of all Games</returns>
        public IEnumerable<Game> GetAllGames()
        {
            return _games;
        }

        /// <summary>
        /// Get Game By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Game</returns>
        /// <exception cref="NotFoundException">Not Found Exception</exception>
        public Game GetGameById(int id)
        {
            Game game = _games.Where(x => x.Id == id).FirstOrDefault();
            if (game == null)
            {
                throw new NotFoundException($"Game with ID - {id} doesn't exist");
            }
            return game;
        }

        /// <summary>
        /// Add the Game
        /// </summary>
        /// <param name="game">Game</param>
        /// <returns>Updated List of Games</returns>
        /// <exception cref="DuplicateItemException">DuplicateItemException</exception>
        public IEnumerable<Game> AddGame(Game game) 
        {
            if(_games.Exists(x  => x.Id == game.Id)) 
            {
                throw new DuplicateItemException("The Game with given Id already exists");
            }

            _games.Add(game);
            return _games;  
        }

        /// <summary>
        /// Delete the Game
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        public IEnumerable<Game> DeleteGame(int id)
        {
            Game game = _games.Where(x => x.Id == id).FirstOrDefault();
            if (game == null)
            {
                throw new NotFoundException($"ID - {id} doesn't exist");
            }
            _games.Remove(game);
            return _games;
        }


        /// <summary>
        /// Update the Game
        /// </summary>
        /// <param name="gameChanges">Game to be updated</param>
        /// <returns>Updated Game</returns>
        /// <exception cref="NotFoundException">NotFoundException</exception>
        public Game UpdateGame(Game gameChanges) 
        {
            Game game = _games.Where(x => x.Id == gameChanges.Id).FirstOrDefault();
            if (game == null)
            {
                throw new NotFoundException($"ID - {gameChanges.Id} doesn't exist");
            }
            game.ReleaseDate = gameChanges.ReleaseDate;
            game.Price = gameChanges.Price;
            game.Genre = gameChanges.Genre;
            game.Description = gameChanges.Description;
            game.Title = gameChanges.Title;
            game.StockQuantity = gameChanges.StockQuantity;

            return game;
        }

        /// <summary>
        /// Get Games Per Page
        /// </summary>
        /// <param name="page">Page</param>
        /// <param name="pageSize">Page Size</param>
        /// <returns>Paginated Games Response</returns>
        /// <exception cref="NotFoundException">NotFoundException</exception>
        public PaginatedGamesResponse GetGamesPerPage(int page, int pageSize) 
        {
             
            PaginatedGamesResponse response = new PaginatedGamesResponse();
            int totalCount = _games.Count();
            int totalPages = (int)Math.Ceiling((decimal)totalCount / pageSize);
            if (page > totalPages)
                throw new NotFoundException($"Please enter valid page. Total pages available are : {totalPages}");
            response.GamesPerPage = _games.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            response.Pages = totalPages;
            return response;
        }

        /// <summary>
        /// Json To List
        /// </summary>
        /// <returns>List of Games</returns>
        private List<Game> JsonToList() 
        {
            string json = "[\r\n  {\r\n    \"id\": 1,\r\n    \"title\": \"The Legend of Zelda\",\r\n    \"genre\": \"Action-Adventure\",\r\n    \"description\": \"Embark on a quest to save Princess Zelda in the kingdom of Hyrule.\",\r\n    \"price\": 29.99,\r\n    \"releaseDate\": \"1986-02-21\",\r\n    \"stockQuantity\": 100\r\n  },\r\n  {\r\n    \"id\": 2,\r\n    \"title\": \"Super Mario Bros.\",\r\n    \"genre\": \"Platform\",\r\n    \"description\": \"Join Mario as he ventures through the Mushroom Kingdom to rescue Princess Peach.\",\r\n    \"price\": 25.00,\r\n    \"releaseDate\": \"1985-09-13\",\r\n    \"stockQuantity\": 150\r\n  },\r\n  {\r\n    \"id\": 3,\r\n    \"title\": \"Tetris\",\r\n    \"genre\": \"Puzzle\",\r\n    \"description\": \"Rotate and arrange Tetriminos to clear lines in this timeless puzzle game.\",\r\n    \"price\": 9.99,\r\n    \"releaseDate\": \"1984-06-06\",\r\n    \"stockQuantity\": 200\r\n  },\r\n  {\r\n    \"id\": 4,\r\n    \"title\": \"Pac-Man\",\r\n    \"genre\": \"Arcade\",\r\n    \"description\": \"Navigate mazes and eat pellets while avoiding ghosts in this arcade classic.\",\r\n    \"price\": 14.99,\r\n    \"releaseDate\": \"1980-05-22\",\r\n    \"stockQuantity\": 120\r\n  },\r\n  {\r\n    \"id\": 5,\r\n    \"title\": \"Space Invaders\",\r\n    \"genre\": \"Shoot 'em up\",\r\n    \"description\": \"Defend Earth from waves of descending alien invaders.\",\r\n    \"price\": 19.99,\r\n    \"releaseDate\": \"1978-06-01\",\r\n    \"stockQuantity\": 80\r\n  },\r\n  {\r\n    \"id\": 6,\r\n    \"title\": \"Donkey Kong\",\r\n    \"genre\": \"Platform\",\r\n    \"description\": \"Help Jumpman rescue the damsel in distress from the giant ape, Donkey Kong.\",\r\n    \"price\": 15.00,\r\n    \"releaseDate\": \"1981-07-09\",\r\n    \"stockQuantity\": 100\r\n  },\r\n  {\r\n    \"id\": 7,\r\n    \"title\": \"Mega Man\",\r\n    \"genre\": \"Action\",\r\n    \"description\": \"Battle Dr. Wily and his robot masters as the blue bomber, Mega Man.\",\r\n    \"price\": 20.00,\r\n    \"releaseDate\": \"1987-12-17\",\r\n    \"stockQuantity\": 90\r\n  },\r\n  {\r\n    \"id\": 8,\r\n    \"title\": \"Final Fantasy\",\r\n    \"genre\": \"RPG\",\r\n    \"description\": \"Embark on an epic quest to save the world in this seminal role-playing game.\",\r\n    \"price\": 30.00,\r\n    \"releaseDate\": \"1987-12-18\",\r\n    \"stockQuantity\": 75\r\n  },\r\n  {\r\n    \"id\": 9,\r\n    \"title\": \"Metroid\",\r\n    \"genre\": \"Action-Adventure\",\r\n    \"description\": \"Explore an alien world as bounty hunter Samus Aran in this sci-fi classic.\",\r\n    \"price\": 25.00,\r\n    \"releaseDate\": \"1986-08-06\",\r\n    \"stockQuantity\": 85\r\n  },\r\n  {\r\n    \"id\": 10,\r\n    \"title\": \"Sonic the Hedgehog\",\r\n    \"genre\": \"Platform\",\r\n    \"description\": \"Speed through levels as Sonic, the fastest hedgehog on the planet.\",\r\n    \"price\": 20.00,\r\n    \"releaseDate\": \"1991-06-23\",\r\n    \"stockQuantity\": 120\r\n  }]";
            var result = JsonConvert.DeserializeObject<List<Game>>(json);
            return result?.ToList();
        }

       
     
    }
}


