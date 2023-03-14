using RepositoryPattern.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.core.Interfaces
{
    public interface IBooksRepository:IGenericRepository<Book>
    {
        IEnumerable<Book> GetBooks();
    }
}
