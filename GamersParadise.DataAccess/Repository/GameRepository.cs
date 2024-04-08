using GamersParadise.DataAccess.Data;
using GamersParadise.DataAccess.Repository.IRepository;
using GamersParadise.Models.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace GamersParadise.DataAccess.Repository;

public class GameRepository : Repository<Game>, IGameRepository
{
    private ApplicationDbContext _context;

    public GameRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public void Update(Game game)
    {
        var gameInDb = _context.Games.FirstOrDefault(g => g.Id == game.Id);
        if (gameInDb != null)
        {
            gameInDb.Title = game.Title;
            gameInDb.Description = game.Description;
            gameInDb.Platform = game.Platform;
            gameInDb.Price = game.Price;
            gameInDb.Description = game.Description;
            gameInDb.AgeRating = game.AgeRating;
            gameInDb.Publisher = game.Publisher;
            gameInDb.GenreId = game.GenreId;
            if (gameInDb.ImageUrl != null)
            {
                gameInDb.ImageUrl = game.ImageUrl;
            }
        }
    }
}