using LibraryManagement.Models;
using LibraryManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Instantiate new LibraryService class
            LibraryService service = new LibraryService();

            while (true)
            {
                //List options available to user to action.
                Console.WriteLine("\nLibrary Management System: Choose an option and press enter.");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Remove Book");
                Console.WriteLine("3. Search Book");
                Console.WriteLine($"4. List Books ({service.GetAllBooks().Count} Books Available)");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");

                //Based on option selected, ask the relevant questions.
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": // List options to add a new book.
                        Console.Write("Enter title: ");
                        string title = Console.ReadLine();
                        Console.Write("Enter author: ");
                        string author = Console.ReadLine();
                        Console.Write("Enter ISBN: ");
                        string isbn = Console.ReadLine();
                        Console.Write("Enter publication year: ");
                        int year = int.Parse(Console.ReadLine());
                        service.AddBook(new Book { Title = title, Author = author, ISBN = isbn, PublishYear = year });
                        break;

                    case "2": // Enter ISBN to remove book.
                        Console.Write("Enter ISBN to remove: ");
                        string removeIsbn = Console.ReadLine();
                        service.RemoveBook(removeIsbn);
                        break;

                    case "3": //Search book(s) within library and list books found.
                        Console.Write("Enter search keyword: ");
                        List<Book> searchResult = service.SearchBook(Console.ReadLine().ToLower());

                        // Check if any books available to list.
                        if (searchResult.Count > 0 && searchResult != null)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Search Results: ");
                            foreach (Book book in searchResult)
                            {
                                Console.WriteLine(book.ToString());
                            }
                        }
                        else //No books found
                        {
                            Console.WriteLine();
                            Console.WriteLine("No books found.");
                        }
                        break;

                    case "4": //List all books currently in library collection.
                        Console.WriteLine();
                        foreach(Book book in service.GetAllBooks())
                        {
                            Console.WriteLine(book.ToString());
                        }
                        break;
                    case "5": // Exit the application.
                        Console.WriteLine();
                        Console.WriteLine("Library Manager shutting down..");
                        return;
                    default: // Valid option not chosen.
                        Console.WriteLine();
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
