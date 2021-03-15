using Data;
using Data.Entities;
using Data.Models;
using Data.Utils;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
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

        public Book FindBook(int? id)
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

        public void UpdateBook(EditBookDTO newData)
        {
            Book book = FindBook(newData.Id);

            book.Id = newData.Id;

            if (newData.Title != null)
            {
                book.Title = newData.Title;
            }
            if (newData.Genre != null)
            {
                book.Genre = newData.Genre;
            }
            if (newData.Year != null)
            {
                book.Year = newData.Year;
            }
            if (newData.Pages != null)
            {
                book.Pages = newData.Pages;
            }

            Author author = db.Authors.FirstOrDefault(a => a.FirstName == newData.FirstName
            && a.MiddleName == newData.MiddleName && a.LastName == newData.LastName);

            if (author == null)
            {
                author = new Author
                {
                    FirstName = newData.FirstName,
                    MiddleName = newData.MiddleName,
                    LastName = newData.LastName
                };

                db.Authors.Add(author);

                db.SaveChanges();
            }

            book.AuthorId = author.Id;

            db.SaveChanges();
        }
    }
}
