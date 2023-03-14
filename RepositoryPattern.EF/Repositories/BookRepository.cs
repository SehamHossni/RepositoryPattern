using RepositoryPattern.core.Interfaces;
using RepositoryPattern.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.EF.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBooksRepository
    {
        private readonly ApplicationDbContext context;

        public BookRepository(ApplicationDbContext context):base(context) 
        {
        }
     
        public IEnumerable<Book> GetBooks()
        {
            throw new NotImplementedException();
        }
    }
}
