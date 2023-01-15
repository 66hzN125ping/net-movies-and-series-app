using Aspnet_Core_Movie.Models;
using Microsoft.EntityFrameworkCore;

namespace Aspnet_Core_Movie.Infrastructure

{
    public class SerieContext : DbContext
    {
        public SerieContext(DbContextOptions<SerieContext> options)
            : base(options)
        {
        }
        public DbSet<SerieList> SerieList { get; set; }
    }
}
