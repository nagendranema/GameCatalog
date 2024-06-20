using GameCatalog.Models;
using GameCatalog.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace GameCatalog.Controllers
{
    /// <summary>
    /// Game Catalog Controller
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class GameCatalogController : ControllerBase
    {
       private readonly  IGameRepository _gameRepository;
        /// <summary>
        /// Constructor for GameCatalogController
        /// </summary>
        /// <param name="gameRepository">Game Repository</param>
        public GameCatalogController(IGameRepository gameRepository)
        {
            _gameRepository =  gameRepository;
        }

        /// <summary>
        /// Get All Games
        /// </summary>
        /// <returns>List of all games</returns>
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllGames()
        {
            var allGames = _gameRepository.GetAllGames();
            return Ok(allGames);
        }


        /// <summary>
        /// Get Game by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Game</returns>
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetGameById(int id)
        {
            try
            {
                return Ok(_gameRepository.GetGameById(id));
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get Games Per Page
        /// </summary>
        /// <param name="page">Page Number</param>
        /// <param name="pageSize">Records count per page</param>
        /// <returns>List of Games Per Page</returns>
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetGamesPerPage(int page, int pageSize)
        {
            try
            {
                return Ok(_gameRepository.GetGamesPerPage(page, pageSize));
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Add the Game
        /// </summary>
        /// <param name="game"></param>
        /// <returns>Updated List of Games</returns>
        [HttpPost]
        [Route("[action]")]
        public IActionResult AddGame(Game game)
        {
            if (game.Id == 0) 
            {
                return BadRequest("Id is required for Game");
            }
           return Ok(_gameRepository.AddGame(game));            
        }

        /// <summary>
        /// Delete the Game
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Updated List of Games</returns>

        [HttpDelete]
        [Route("[action]")]
        public IActionResult DeleteGame(int id)
        {
            try
            {
                return Ok(_gameRepository.DeleteGame(id));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Update the Game
        /// </summary>
        /// <param name="gameChanges"></param>
        /// <returns>Updated Game</returns>
        [HttpPut]
        [Route("[action]")]
        public IActionResult UpdateGame(Game gameChanges)
        {
            try
            {
                return Ok(_gameRepository.UpdateGame(gameChanges));
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }

        }
      
    }
}
