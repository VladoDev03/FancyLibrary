using ConsoleVersion.Models;
using ConsoleVersion.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleVersion.Services
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

        // TODO
        public List<Book> GetAuthorBooks(Author author)
        {
            throw new NotImplementedException();
        }

        // TODO
        public int GetAuthorBookCount(Author author)
        {
            throw new NotImplementedException();
        }
    }
}
