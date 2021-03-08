using ConsoleVersion.Models;
using ConsoleVersion.Services.Contracts;
using ConsoleVersion.Utils;
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

        public Book FindBook(string title)
        {
            Book book = db.Books.FirstOrDefault(b => b.Title == title);
            return book;
        }

        public Book FindBook(int id)
        {
            Book book = db.Books.FirstOrDefault(b => b.Id == id);
            return book;
        }

        public Author GetBookAuthor(Book book)
        {
            Author author = db.Authors
                .FirstOrDefault(a => a.Id == book.AuthorId);
            return author;
        }

        public int GetAuthorIdFromFullName(Book book, string authorFullName)
        {
            Author author = db.Authors
                .FirstOrDefault(a =>
                NameRefactorer.GetFullName(a.FirstName, a.MiddleName, a.LastName) == authorFullName);

            return author.Id;
        }
    }
}
