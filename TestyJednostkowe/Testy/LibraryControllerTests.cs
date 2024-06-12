using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Controllers;
using WebApi.Core.Entities;
using WebApi.Core.Interfaces;

namespace TestyJednostkowe.Testy
{
    public class LibraryControllerTests
    {
        private readonly LibraryController _controller;
        private readonly Mock<ILibraryService> _mockLibraryService;

        public LibraryControllerTests()
        {
            _mockLibraryService = new Mock<ILibraryService>();
            _controller = new LibraryController(_mockLibraryService.Object);
        }

        [Fact]
        public async Task GetLibraries_ReturnsAllLibraries()
        {
            var libraries = new List<Library>
            {
                new Library { Id = 1, Name = "Library 1" },
                new Library { Id = 2, Name = "Library 2" }
            };

            _mockLibraryService.Setup(service => service.GetAllLibrariesAsync()).ReturnsAsync(libraries);

            var result = await _controller.GetLibraries();

            Assert.Equal(libraries, result);
        }

        [Fact]
        public async Task GetLibrary_ReturnsLibrary()
        {
            var library = new Library { Id = 1, Name = "Library 1" };

            _mockLibraryService.Setup(service => service.GetLibraryByIdAsync(1)).ReturnsAsync(library);

            var result = await _controller.GetLibrary(1);

            Assert.Equal(library, result);
        }

        [Fact]
        public async Task AddLibrary_CallsServiceWithLibrary()
        {
            var library = new Library { Name = "New Library" };

            _mockLibraryService.Setup(service => service.AddLibraryAsync(library)).Returns(Task.CompletedTask).Verifiable();

            await _controller.AddLibrary(library);

            _mockLibraryService.Verify(service => service.AddLibraryAsync(library), Times.Once);
        }

        [Fact]
        public async Task UpdateLibrary_CallsServiceWithUpdatedLibrary()
        {
            var library = new Library { Id = 1, Name = "Updated Library" };

            _mockLibraryService.Setup(service => service.UpdateLibraryAsync(library)).Returns(Task.CompletedTask).Verifiable();

            await _controller.UpdateLibrary(1, library);

            _mockLibraryService.Verify(service => service.UpdateLibraryAsync(library), Times.Once);
        }

        [Fact]
        public async Task DeleteLibrary_CallsServiceWithId()
        {
            var libraryId = 1;

            _mockLibraryService.Setup(service => service.DeleteLibraryAsync(libraryId)).Returns(Task.CompletedTask).Verifiable();

            await _controller.DeleteLibrary(libraryId);

            _mockLibraryService.Verify(service => service.DeleteLibraryAsync(libraryId), Times.Once);
        }
    }
}