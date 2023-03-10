using System.ComponentModel.DataAnnotations;

namespace Aspnet_Core_Movie.Models
{
    public class SerieList
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string ImgUrl { get; set; }
        [Required]
        public float Rating { get; set; }
        [Required]
        public float DurationPerEpisode { get; set; }
        [Required]
        public int Episodes { get; set; }
        [Required]
        public int Seasons { get; set; }
        [Required]
        public string Plot { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public string VideoUrl { get; set; }
        [Required]
        public string Director { get; set; }

    }
}
