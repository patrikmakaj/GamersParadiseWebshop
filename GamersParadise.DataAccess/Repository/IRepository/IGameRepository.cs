using GamersParadise.Models.Models;

namespace GamersParadise.DataAccess.Repository.IRepository;

public interface IGameRepository : IRepository<Game>
{
    void Update(Game game);
}