using Microsoft.AspNetCore.Mvc;
using WebApi.Core.Entities;
using WebApi.Core.Interfaces;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookRepository;

        public BookController(IBookService bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _bookRepository.GetAllBooksAsync();
        }

        [HttpGet("{id}")]
        public async Task<Book> GetBook(int id)
        {
            return await _bookRepository.GetBookByIdAsync(id);
        }

        [HttpPost]
        public async Task AddBook([FromBody] Book book)
        {
            await _bookRepository.AddBookAsync(book);
        }

        [HttpPut("{id}")]
        public async Task UpdateBook(int id, [FromBody] Book book)
        {
            book.Id = id;
            await _bookRepository.UpdateBookAsync(book);
        }

        [HttpDelete("{id}")]
        public async Task DeleteBook(int id)
        {
            await _bookRepository.DeleteBookAsync(id);
        }
    }
}