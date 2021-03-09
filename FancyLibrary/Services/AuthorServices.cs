using Data;
using Data.Entities;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class AuthorServices : IAuthorServices
    {
        private FancyLibraryContext db;

        public AuthorServices(FancyLibraryContext db)
        {
            this.db = db;
        }

        public List<Author> GetAllAuthors()
        {
            return db.Authors.ToList();
        }

        public void AddAuthor(Author author)
        {
            db.Authors.Add(author);
            db.SaveChanges();
        }

        public List<Book> GetAuthorBooks(Author author)
        {
            List<Book> books = db.Books
                .Where(b => b.AuthorId == author.Id)
                .ToList();

            return books;
        }

        public int GetAuthorBookCount(Author author)
        {
            return GetAuthorBooks(author).Count;
        }
    }
}
