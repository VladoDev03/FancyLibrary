using ConsoleVersion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleVersion.Services
{
    public class BookServices
    {
        private FancyLibraryContext db;

        public BookServices(FancyLibraryContext db)
        {
            this.db = db;
        }

        public List<Book> GetAllBooks()
        {
            List<Book> books = db.Books.ToList();
            return books;
        }

        public void AddBook(Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();
        }

        public int GetBookSavedTimes(Book book)
        {
            int result = db.UsersBooks.Where(ub => ub.BookId == book.Id).Count();
            return result;
        }
    }
}
