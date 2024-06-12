using WebApi.Core.Entities;
using WebApi.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Core.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly AppDbContext _context;

        public LibraryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Library> GetLibraryByIdAsync(int id)
        {
            return await _context.Libraries.FindAsync(id);
        }

        public async Task<IEnumerable<Library>> GetAllLibrariesAsync()
        {
            return await _context.Libraries.ToListAsync();
        }

        public async Task AddLibraryAsync(Library library)
        {
            await _context.Libraries.AddAsync(library);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateLibraryAsync(Library library)
        {
            _context.Libraries.Update(library);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteLibraryAsync(int id)
        {
            var library = await _context.Libraries.FindAsync(id);
            if (library != null)
            {
                _context.Libraries.Remove(library);
                await _context.SaveChangesAsync();
            }
        }
    }
}