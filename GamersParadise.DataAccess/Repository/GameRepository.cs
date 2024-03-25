using GamersParadise.DataAccess.Data;
using GamersParadise.DataAccess.Repository.IRepository;
using GamersParadise.Models.Models;

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
        _context.Update(game);
    }
}