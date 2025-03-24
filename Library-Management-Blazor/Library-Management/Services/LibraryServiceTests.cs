using Library_Management.Models;
using LibraryManagement.Services;
using Xunit;

namespace Library_Management.Services
{
    public class LibraryServiceTests
    {
        [Fact]
        public void AddBook_ShouldAddBookToLibrary()
        {
            // Arrange
            var service = new LibraryService();
            var newBook = new Book { Title = "Test Book", Author = "Test Author", ISBN = "123456", PublishYear = 2025 };

            // Act
            service.AddBook(newBook);
            var books = service.GetAllBooks();

            // Assert
            Assert.Contains(books, b => b.Title == "Test Book" && b.ISBN == "123456");
        }

        [Fact]
        public void RemoveBook_ShouldRemoveBookFromLibrary()
        {
            // Arrange
            var service = new LibraryService();
            var bookToRemove = new Book { Title = "To Remove", Author = "Author", ISBN = "REMOVE123", PublishYear = 2024 };
            service.AddBook(bookToRemove);

            // Act
            service.RemoveBook("REMOVE123");
            var books = service.GetAllBooks();

            // Assert
            Assert.DoesNotContain(books, b => b.ISBN == "REMOVE123");
        }

        [Fact]
        public void SearchBook_ShouldReturnAllBooksMatchingSearch()
        {
            // Arrange
            var service = new LibraryService();
            service.AddBook(new Book { Title = "Find Me", Author = "Searcher", ISBN = "SEARCH123", PublishYear = 2023 });

            // Act
            var result = service.SearchBook("Find Me");

            // Assert
            Assert.NotNull(result);
            Assert.Equal("SEARCH123", result[0].ISBN);
        }
    }
}
