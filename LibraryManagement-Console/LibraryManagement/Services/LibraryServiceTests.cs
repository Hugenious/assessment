using LibraryManagement.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Services
{
    [TestClass]
    public class LibraryServiceTests
    {
        [TestMethod]

        // Add book function testing.
        public void AddBook_ShouldIncreaseBookCount()
        {
            // Arrange
            var service = new LibraryService();
            var book = new Book { Title = "Test Book", Author = "Author", ISBN = "12345", PublishYear = 2025 };

            // Act
            service.AddBook(book);
            var books = service.GetAllBooks();

            // Assert
            Assert.Contains(book, books);
            Assert.HasCount(5, books);
        }

        [TestMethod]

        //Remove book testing
        public void RemoveBook_ShouldDecreaseBookCount()
        {
            // Arrange
            var service = new LibraryService();
            var book = new Book
            {
                Title = "Programming Arduino: Getting Started with Sketches",
                Author = "MONK",
                ISBN = "1264676980",
                PublishYear = 2022
            };

            // Act
            service.RemoveBook(book.ISBN);
            var books = service.GetAllBooks();

            // Assert
            Assert.HasCount(3, books);
        }
    }
}
