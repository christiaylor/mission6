using Microsoft.EntityFrameworkCore;

namespace mission6.Models
{
    public class MoviesContext : DbContext
    {
        public MoviesContext(DbContextOptions<MoviesContext> options) : base (options)
        { 
        }

        public DbSet<Movie> Movies { get; set; }
    }
}
