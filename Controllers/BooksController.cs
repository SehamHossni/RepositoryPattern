using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.core.Consts;
using RepositoryPattern.core.Interfaces;
using RepositoryPattern.core.Models;
using RepositoryPattern.DTOs;
using System.Collections;

namespace RepositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
       // private readonly IGenericRepository<Book> bookRepository;
        private readonly IUnitOfWork unitOfWork;

        public BooksController(/*IGenericRepository<Book> bookRepository*/ IUnitOfWork unitOfWork)
        {
            //this.bookRepository = bookRepository;
            this.unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult GetById(int id)
        { 
          return Ok(unitOfWork.Books.GetById(id));
        }
        [HttpGet("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return Ok(await unitOfWork.Books.GetByIdAsync(id));
        }

        [HttpGet("GetAllBooks")]
        public IActionResult GetAllBooks()
        {
            return Ok(unitOfWork.Books.GetAll());
        }
        [HttpGet("GetByTitle")]
        public IActionResult GetByName(string Title)
        {
            return Ok(unitOfWork.Books.Find(A => A.Title == Title , new[] { "Author" }));
        }
        [HttpGet("GetAllByTitleWithAuthors")]
        public IActionResult GetAllByTitleWithAuthors(string Title)
        {
            return Ok(unitOfWork.Books.FindAll(A => A.Title.Contains(Title), new[] { "Author" }));
        }

        [HttpGet("GetOrdered")]
        public IActionResult GetOrdered(string Title)
        {
            return Ok(unitOfWork.Books.FindAll(A => A.Title.Contains(Title), null, null, b => b.Id, OrderBy.Descending));
        }

        [HttpPost("AddBook")]
        public IActionResult AddBook(BookDTO bookDTO)
        { 
            Book book= new Book();
            book.Title = bookDTO.Title;
            book.AuthorId = bookDTO.AuthorId;
            unitOfWork.Books.Add(book);
            return Ok(book);
        }

    }
    
}

