using Aspnet_Core_Movie.Models;
using Microsoft.EntityFrameworkCore;

namespace Aspnet_Core_Movie.Model

{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options)
            : base(options)
        {
        }
        public DbSet<MovieList> MovieList { get; set; }
    }
}
