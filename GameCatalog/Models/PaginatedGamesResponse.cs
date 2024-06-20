namespace GameCatalog.Models
{
    public class PaginatedGamesResponse
    {
        public List<Game> GamesPerPage{ get; set; }
        public int Pages { get; set; }

    }
}
