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
    public class BookControllerTests
    {
        private readonly BookController _controller;
        private readonly Mock<IBookService> _mockBookService;

        public BookControllerTests()
        {
            _mockBookService = new Mock<IBookService>();
            _controller = new BookController(_mockBookService.Object);
        }

        [Fact]
        public async Task GetBooks_ReturnsAllBooks()
        {
            var books = new List<Book>
            {
                new Book { Id = 1, Title = "Book 1" },
                new Book { Id = 2, Title = "Book 2" }
            };

            _mockBookService.Setup(service => service.GetAllBooksAsync()).ReturnsAsync(books);

            var result = await _controller.GetBooks();

            Assert.Equal(books, result);
        }

        [Fact]
        public async Task GetBook_ReturnsBook()
        {
            var book = new Book { Id = 1, Title = "Book 1" };

            _mockBookService.Setup(service => service.GetBookByIdAsync(1)).ReturnsAsync(book);

            var result = await _controller.GetBook(1);

            Assert.Equal(book, result);
        }

        [Fact]
        public async Task AddBook_CallsServiceWithBook()
        {
            var book = new Book { Title = "New Book" };

            _mockBookService.Setup(service => service.AddBookAsync(book)).Returns(Task.CompletedTask).Verifiable();

            await _controller.AddBook(book);

            _mockBookService.Verify(service => service.AddBookAsync(book), Times.Once);
        }

        [Fact]
        public async Task UpdateBook_CallsServiceWithUpdatedBook()
        {
            var book = new Book { Id = 1, Title = "Updated Book" };

            _mockBookService.Setup(service => service.UpdateBookAsync(book)).Returns(Task.CompletedTask).Verifiable();

            await _controller.UpdateBook(1, book);

            _mockBookService.Verify(service => service.UpdateBookAsync(book), Times.Once);
        }

        [Fact]
        public async Task DeleteBook_CallsServiceWithId()
        {
            var bookId = 1;

            _mockBookService.Setup(service => service.DeleteBookAsync(bookId)).Returns(Task.CompletedTask).Verifiable();

            await _controller.DeleteBook(bookId);

            _mockBookService.Verify(service => service.DeleteBookAsync(bookId), Times.Once);
        }
    }
}