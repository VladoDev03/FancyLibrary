using ConsoleVersion.Models;
using ConsoleVersion.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleVersion.Services
{
    public class BookServices : IBookServices
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

        // TODO
        public Book FindBook(string title)
        {
            throw new NotImplementedException();
        }

        // TODO
        public Book FindBook(int id)
        {
            throw new NotImplementedException();
        }

        // TODO
        public Author GetBookAuthor(Book book)
        {
            throw new NotImplementedException();
        }

        // TODO
        public int MapAuthorWithBook(string authorFullName)
        {
            throw new NotImplementedException();
        }
    }
}
