using ConsoleVersion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleVersion.Services
{
    public class AuthorServices
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
    }
}
