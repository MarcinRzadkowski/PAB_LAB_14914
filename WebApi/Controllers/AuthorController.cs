using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Core.Entities;
using WebApi.Core.Interfaces;
using WebApi.Core.Repositories;
using WebApi.Core.Services;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<IEnumerable<Author>> GetAuthors()
        {
            return await _authorService.GetAllAuthorsAsync();
        }

        [HttpGet("{id}")]
        public async Task<Author> GetAuthor(int id)
        {
            return await _authorService.GetAuthorByIdAsync(id);
        }

        [HttpPost]
        public async Task AddAuthor([FromBody] Author author)
        {
            await _authorService.AddAuthorAsync(author);
        }

        [HttpPut("{id}")]
        public async Task UpdateAuthor(int id, [FromBody] Author author)
        {
            author.Id = id;
            await _authorService.UpdateAuthorAsync(author);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAuthor(int id)
        {
            await _authorService.DeleteAuthorAsync(id);
        }
    }
}