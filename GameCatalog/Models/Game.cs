using System.ComponentModel.DataAnnotations;

namespace GameCatalog.Models
{
    /// <summary>
    /// Game Class
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Game ID
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Game Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Game Genre
        /// </summary>
        public string Genre { get; set; }
        /// <summary>
        /// Game Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Game Price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Game Release Date
        /// </summary>
        public DateTime ReleaseDate { get; set; }

        /// <summary>
        /// Game Stock Quantity 
        /// </summary>
        public int StockQuantity { get; set; }

    }
}
