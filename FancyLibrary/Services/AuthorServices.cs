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

        public int GetAuthorBooksCount(Author author)
        {
            return GetAuthorBooks(author).Count;
        }

        public int GetAuthorIdFromFullName(string authorFullName)
        {
            Author author = GetAllAuthors().FirstOrDefault(
                a => NameRefactorer.GetFullName(
                    a.FirstName, a.MiddleName, a.LastName) == authorFullName);

            return author.Id;
        }

        public Author FindAuthor(string fullName)
        {
            Author author = GetAllAuthors().FirstOrDefault(
                a => NameRefactorer.GetFullName(
                    a.FirstName, a.MiddleName, a.LastName) == fullName);

            return author;
        }

        public Author FindAuthor(int id)
        {
            Author author = db.Authors
                .FirstOrDefault(a => a.Id == id);

            return author;
        }

        public Author FindAuthor(int? id)
        {
            Author author = db.Authors
                   .FirstOrDefault(a => a.Id == id);

            return author;
        }

        public string GetAuthorCountry(Author author)
        {
            Country country = db.Countries.FirstOrDefault(c => c.Id == author.CountryId);

            if (country != null)
            {
                return country.Name;
            }

            return "Unknown";
        }

        public void UpdateAuthor(EditAuthorDTO newData)
        {
            Author author = FindAuthor(newData.Id);

            author.Id = newData.Id;

            if (newData.FirstName != null && newData.FirstName != author.FirstName)
            {
                author.FirstName = newData.FirstName;
            }
            if (newData.MiddleName != null && newData.MiddleName != author.MiddleName)
            {
                author.MiddleName = newData.MiddleName;
            }
            if (newData.LastName != null && newData.LastName != author.LastName)
            {
                author.LastName = newData.LastName;
            }
            if (newData.Nickname != null && newData.Nickname != author.Nickname)
            {
                author.Nickname = newData.Nickname;
            }
            if (newData.Birthday != null && newData.Birthday != author.Birthday)
            {
                author.Birthday = newData.Birthday;
            }
            if (newData.Country != null)
            {
                Country country = db.Countries
                    .FirstOrDefault(c => c.Name == newData.Country);

                if (country == null)
                {
                    country = new Country
                    {
                        Name = newData.Country
                    };

                    db.Countries.Add(country);
                    db.SaveChanges();
                }

                author.CountryId = country.Id;
            }

            db.SaveChanges();
        }
    }
}
