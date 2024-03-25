using GamersParadise.Models.Models;
namespace GamersParadise.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class ApplicationDbContext : DbContext
{
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Game> Games { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>().HasData(
            new Genre { Id = 1, DisplayOrder = 1, Name = "Action" },
            new Genre { Id = 2, DisplayOrder = 2, Name = "Adventure" },
            new Genre { Id = 3, DisplayOrder = 3, Name = "Role-Playing" },
            new Genre { Id = 4, DisplayOrder = 2, Name = "Strategy" },
            new Genre { Id = 5, DisplayOrder = 2, Name = "Horror" }
        );

        modelBuilder.Entity<Game>().HasData(
            new Game
            {
                Id = 1, Description = "Nova igrica", GenreId = 1, AgeRating = "A", ImageUrl = "string", Price = 50.50,
                Platform = "PC", Publisher = "EA Sports", Title = "NewGame"
            }
        );
    }
}