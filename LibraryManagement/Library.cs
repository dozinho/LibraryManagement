using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    public class Library
    {
        private List<Book> _books;

        public Library()
        {
            _books = new List<Book>();
            // Add some pre-saved books
            _books.Add(new Book("The Lord of the Rings", "J.R.R. Tolkien", "978-0618053267"));
            _books.Add(new Book("Pride and Prejudice", "Jane Austen", "978-0141439518"));
            _books.Add(new Book("To Kill a Mockingbird", "Harper Lee", "978-0061120084"));
            _books.Add(new Book("1984", "George Orwell", "978-0451524935"));
            _books.Add(new Book("The Hitchhiker's Guide to the Galaxy", "Douglas Adams", "978-0345391803"));

        }

        public void AddBook(Book book)
        {
            _books.Add(book);
        }

        public void RemoveBook(Book book)
        {
            _books.Remove(book);
        }

        public List<Book> GetBooks()
        {
            return _books;
        }

        public List<Book> SearchByTitle(string title)
        {
            return _books.Where(b => b.Title.ToLower().Contains(title.ToLower())).ToList();
        }

        public List<Book> SearchByAuthor(string author)
        {
            return _books.Where(b => b.Author.ToLower().Contains(author.ToLower())).ToList();
        }

        public void BorrowBook(Book book)
        {
            book.IsBorrowed = true;
        }

        public void ReturnBook(Book book)
        {
            book.IsBorrowed = false;
        }
    }
}
