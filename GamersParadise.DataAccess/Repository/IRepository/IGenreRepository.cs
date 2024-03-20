using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamersParadise.Models.Models;
namespace GamersParadise.DataAccess.Repository.IRepository;

public interface IGenreRepository : IRepository<Genre>
{
    void Update(Genre genre);
}