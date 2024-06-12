using Microsoft.AspNetCore.Mvc;
using WebApi.Core.Entities;
using WebApi.Core.Interfaces;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibraryController : ControllerBase
    {
        private readonly ILibraryService _libraryRepository;

        public LibraryController(ILibraryService libraryRepository)
        {
            _libraryRepository = libraryRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Library>> GetLibraries()
        {
            return await _libraryRepository.GetAllLibrariesAsync();
        }

        [HttpGet("{id}")]
        public async Task<Library> GetLibrary(int id)
        {
            return await _libraryRepository.GetLibraryByIdAsync(id);
        }

        [HttpPost]
        public async Task AddLibrary([FromBody] Library library)
        {
            await _libraryRepository.AddLibraryAsync(library);
        }

        [HttpPut("{id}")]
        public async Task UpdateLibrary(int id, [FromBody] Library library)
        {
            library.Id = id;
            await _libraryRepository.UpdateLibraryAsync(library);
        }

        [HttpDelete("{id}")]
        public async Task DeleteLibrary(int id)
        {
            await _libraryRepository.DeleteLibraryAsync(id);
        }
    }
}