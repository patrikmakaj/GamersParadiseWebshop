using GamersParadise.DataAccess.Data;
using GamersParadise.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GamersParadise.DataAccess.Repository;

public class UnitOfWork : IUnitOfWork
{
    private ApplicationDbContext _context;
    public IGenreRepository Genre { get; private set; }
    
    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        Genre = new GenreRepository(_context);
    }
    public void Save()
    {
        _context.SaveChanges();
    }
}