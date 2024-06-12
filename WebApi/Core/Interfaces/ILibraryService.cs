using WebApi.Core.Entities;

namespace WebApi.Core.Interfaces
{
    public interface ILibraryService
    {
        Task<Library> GetLibraryByIdAsync(int id);
        Task<IEnumerable<Library>> GetAllLibrariesAsync();
        Task AddLibraryAsync(Library library);
        Task UpdateLibraryAsync(Library library);
        Task DeleteLibraryAsync(int id);
    }
}

