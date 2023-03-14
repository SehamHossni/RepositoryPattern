using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.core.Interfaces;
using RepositoryPattern.core.Models;

namespace RepositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        //private readonly IGenericRepository<Author> _authorsRepository;

        public AuthorsController(/*IGenericRepository<Author> authorsRepository*/ IUnitOfWork unitOfWork)
        {
            //_authorsRepository = authorsRepository;
            this.unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult GetById(int id) 
        {
          return Ok( unitOfWork.Books.GetById(id));    
        }
        [HttpGet("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return Ok(await unitOfWork.Authors.GetByIdAsync(id));
        }
        [HttpGet("GetAllAuthors")]
        public IActionResult GetAllAuthors()
        {
            return Ok(unitOfWork.Authors.GetAll());
        }
        [HttpGet("GetByName")]
        public IActionResult GetByName(string name)
        {
            return Ok(unitOfWork.Authors.Find(A =>A.Name == name ) );
        }

    }
}
