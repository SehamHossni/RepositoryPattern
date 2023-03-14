using RepositoryPattern.core.Interfaces;
using RepositoryPattern.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.EF.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IGenericRepository<Author> Authors { get; private set; }

        public IBooksRepository Books { get; private set; }
        public UnitOfWork(ApplicationDbContext context)
        {
            _context= context;
            Authors = new GenericRepository<Author>(_context);
            Books = new BookRepository(_context);
        }
       

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
           _context.Dispose();
        }
    }
}
