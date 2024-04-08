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
    public DbSet<Company> Companies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>().HasData(
            new Genre { Id = 1, DisplayOrder = 1, Name = "Action" },
            new Genre { Id = 2, DisplayOrder = 2, Name = "Adventure" },
            new Genre { Id = 3, DisplayOrder = 3, Name = "Role-Playing" },
            new Genre { Id = 4, DisplayOrder = 2, Name = "Strategy" },
            new Genre { Id = 5, DisplayOrder = 2, Name = "Horror" },
            new Genre { Id = 6, DisplayOrder = 4, Name = "Sports" }
        );

        modelBuilder.Entity<Company>().HasData(
   new
   {
       Id = 1,
       Name = "ImeKompanije",
       StreetAddress = "UlicaKompanije",
       City = "Osijek",
       State = "Osjecko-baranjska",
       PostalCode = 31000,
       PhoneNumber = "09912312312"
   });

        modelBuilder.Entity<Game>().HasData(
            new Game
            {
                Id = 1, Description = "Nova igrica", GenreId = 1, AgeRating = "A", ImageUrl = "string", Price = 50.50,
                Platform = "PC", Publisher = "EA Sports", Title = "NewGame"
            },
            new Game
            {
                Id = 2, Description = "Description for EA FC 24", GenreId = 6, AgeRating = "E", ImageUrl = "imageUrlForEaFc24", Price = 60.00,
                Platform = "PC", Publisher = "EA Sports", Title = "EA FC 24"
            },
            new Game
            {
                Id = 3, Description = "Description for Call of Duty", GenreId = 1, AgeRating = "M", ImageUrl = "imageUrlForCod", Price = 59.99,
                Platform = "PC", Publisher = "Activision", Title = "Call of Duty"
            },
            new Game
            {
                Id = 4, Description = "Description for Minecraft", GenreId = 2, AgeRating = "E", ImageUrl = "imageUrlForMinecraft", Price = 26.95,
                Platform = "PC", Publisher = "Mojang", Title = "Minecraft"
            }
        );
    }
}