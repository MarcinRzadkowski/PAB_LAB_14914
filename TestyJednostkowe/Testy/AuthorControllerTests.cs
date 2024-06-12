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
    public class AuthorControllerTests
    {
        private readonly AuthorController _controller;
        private readonly Mock<IAuthorService> _mockAuthorService;

        public AuthorControllerTests()
        {
            _mockAuthorService = new Mock<IAuthorService>();
            _controller = new AuthorController(_mockAuthorService.Object);
        }

        [Fact]
        public async Task GetAuthors_ReturnsAllAuthors()
        {
            var authors = new List<Author>
            {
                new Author { Id = 1, Name = "Author 1" },
                new Author { Id = 2, Name = "Author 2" }
            };

            _mockAuthorService.Setup(service => service.GetAllAuthorsAsync()).ReturnsAsync(authors);
            var result = await _controller.GetAuthors();

            Assert.Equal(authors, result);
        }

        [Fact]
        public async Task GetAuthor_ReturnsAuthor()
        {
            var author = new Author { Id = 1, Name = "Author 1" };

            _mockAuthorService.Setup(service => service.GetAuthorByIdAsync(1)).ReturnsAsync(author);

            var result = await _controller.GetAuthor(1);

            Assert.Equal(author, result);
        }

        [Fact]
        public async Task AddAuthor_CallsServiceWithAuthor()
        {
            var author = new Author { Name = "New Author" };

            _mockAuthorService.Setup(service => service.AddAuthorAsync(author)).Returns(Task.CompletedTask).Verifiable();

            await _controller.AddAuthor(author);

            _mockAuthorService.Verify(service => service.AddAuthorAsync(author), Times.Once);
        }

        [Fact]
        public async Task UpdateAuthor_CallsServiceWithUpdatedAuthor()
        {
            var author = new Author { Id = 1, Name = "Updated Author" };

            _mockAuthorService.Setup(service => service.UpdateAuthorAsync(author)).Returns(Task.CompletedTask).Verifiable();

            await _controller.UpdateAuthor(1, author);

            _mockAuthorService.Verify(service => service.UpdateAuthorAsync(author), Times.Once);
        }

        [Fact]
        public async Task DeleteAuthor_CallsServiceWithId()
        {
            var authorId = 1;

            _mockAuthorService.Setup(service => service.DeleteAuthorAsync(authorId)).Returns(Task.CompletedTask).Verifiable();

            await _controller.DeleteAuthor(authorId);

            _mockAuthorService.Verify(service => service.DeleteAuthorAsync(authorId), Times.Once);
        }
    }
}