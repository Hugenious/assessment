using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Services
{
    public class LibraryService
    {
        List<Book> bookList = new List<Book>();

        //LibraryService constructor to add books to the collection
        public LibraryService()
        {
            bookList = new List<Book>
            {
                new Book
                {
                    Title = "C# 13 and .NET 9",
                    Author = "Mark J. Price",
                    ISBN = "978-1835881231",
                    PublishYear = 2024
                },
                new Book
                {
                    Title = "Cross-Platform Modern Apps with VS Code",
                    Author = "Ockert J. du Preez",
                    ISBN = "935551042X",
                    PublishYear = 2022
                },
                new Book
                {
                    Title = "Programming Arduino: Getting Started with Sketches",
                    Author = "MONK",
                    ISBN = "1264676980",
                    PublishYear = 2022
                },
                new Book
                {
                    Title = "C# 11 and .NET 7",
                    Author = "Mark J. Price",
                    ISBN = "1803237805",
                    PublishYear = 2022
                }
            };
        }

        // Add book method
        public void AddBook(Book book)
        {
            bookList.Add(book);
            Console.WriteLine("");
            Console.WriteLine("Book has been added");
        }

        // Remove book method
        public void RemoveBook(string isbn)
        {
            var book = bookList.FirstOrDefault(b => b.ISBN == isbn); //Find the book matching the ISBN.
            if (book != null)
            {
                bookList.Remove(book); //Remove book if found
                Console.WriteLine("");
                Console.WriteLine("Book removed successfully.");
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Book not found."); //Book not found, cannot remove.
            }
        }

        // Search book method.
        public List<Book> SearchBook(string keyword)
        {
            return bookList.Where(b =>
                b.Title.ToLower().Contains(keyword) ||
                b.Author.ToLower().ToLower().Contains(keyword) ||
                b.ISBN.ToLower().Contains(keyword)
            ).ToList();
        }

        //List all books in the library collection.
        public List<Book> GetAllBooks() => bookList;
    }
}
