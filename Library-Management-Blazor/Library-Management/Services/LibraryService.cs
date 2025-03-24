using Library_Management.Models;

namespace LibraryManagement.Services
{
    public class LibraryService
    {
        private List<Book> bookList = new List<Book>();

        //Add a few books when new instance of Library Service has been created
        public LibraryService()
        {
            bookList = new List<Book>
            {
                new Book
                {
                    Title = "C# 13 and .NET 9",
                    Author = " Mark J. Price",
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
                }
            };
        }


        //Adding a new book
        public void AddBook(Book book) { bookList.Add(book); }

        //Removing a book using ISBN
        public void RemoveBook(string isbn) { bookList.RemoveAll(b => b.ISBN == isbn); }

        //Search books using Title, Author and ISBN
        public List<Book> SearchBook(string keyword)
        {
            return bookList.Where(b =>
                b.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                b.Author.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                b.ISBN.Contains(keyword, StringComparison.OrdinalIgnoreCase)
            ).ToList();
        }

        //List all books in the library
        public List<Book> GetAllBooks() => bookList;
    }
}
