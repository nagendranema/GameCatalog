using GameCatalog.Models;

namespace GameCatalog.Repository
{
    /// <summary>
    /// Interface for Game Repository
    /// </summary>
    public interface IGameRepository
    {
        /// <summary>
        /// Get All Games.
        /// </summary>
        /// <returns>List of games</returns>
        IEnumerable<Game> GetAllGames();

        /// <summary>
        /// Get Game By Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Game</returns>
        public Game GetGameById(int id);

        /// <summary>
        /// Get Games Per Page
        /// </summary>
        /// <param name="page">Page Number</param>
        /// <param name="pageSize">Records count per page</param>
        /// <returns>List of Games</returns>
        public PaginatedGamesResponse GetGamesPerPage(int page, int pageSize);

        /// <summary>
        /// Add a Game
        /// </summary>
        /// <param name="game"></param>
        /// <returns>List of Games</returns>
        IEnumerable<Game> AddGame(Game game);

        /// <summary>
        /// Delete the Game
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Updated Game list</returns>
        IEnumerable<Game> DeleteGame(int id);

        /// <summary>
        /// Update the Game
        /// </summary>
        /// <param name="gameChanges"></param>
        /// <returns>Updated Game record</returns>
        Game UpdateGame(Game gameChanges);
    }
}
