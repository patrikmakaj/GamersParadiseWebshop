using GamersParadise.DataAccess.Data;
using GamersParadise.DataAccess.Repository.IRepository;
using GamersParadise.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamersParadise.DataAccess.Repository;

public class GenreRepository : Repository<Genre>, IGenreRepository
{
    private ApplicationDbContext _context;

    public GenreRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public void Update(Genre genre)
    {
        _context.Update(genre);
    }
}