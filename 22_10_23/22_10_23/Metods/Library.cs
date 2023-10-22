using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22_10_23.Metods
{
    //Task 3
    internal class Library : Base
    {
        private List<Book> _books = new List<Book>();

        public Library(string name) : base(name)
        {
        }

        public void AddBook(Book book)
        {
            if (!_books.Contains(book))
            {
                _books.Add(book);
                Console.WriteLine("Book added to the library.");
            }
            else
            {
                Console.WriteLine("Book already exists in the library.");
            }
        }

        public void ListAllBooks()
        {
            Console.WriteLine($"Books in {Name} library:");
            foreach (var book in _books)
            {
                Console.WriteLine($"{book.Name} by {book.Author} (Category: {book.Category.Name})");
            }
        }
    }
}
