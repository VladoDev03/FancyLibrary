using ConsoleVersion.Models;
using ConsoleVersion.Services;
using ConsoleVersion.Services.Contracts;
using ConsoleVersion.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleVersion.Controllers
{
    public class AuthorController
    {
        private IAuthorServices authorServices;
        private IBookServices bookServices;

        public AuthorController(IAuthorServices authorServices, IBookServices bookServices)
        {
            this.authorServices = authorServices;
            this.bookServices = bookServices;
        }

        // TODO
        public void AddNewAuthor(List<string> input)
        {
            Author author = new Author
            {
                FirstName = input[0],
                MiddleName = input[1],
                LastName = input[2]
            };

            string fullName = NameRefactorer
                .GetFullName(author.FirstName, author.MiddleName, author.LastName);

            List<string> names = authorServices.GetAllAuthors()
                .Select(x => NameRefactorer.GetFullName(x.FirstName, x.MiddleName, x.LastName))
                .ToList();

            if (names.Contains(fullName))
            {
                throw new ArgumentException();
            }

            authorServices.AddAuthor(author);
        }

        public int GetAuthorBookCount(Author author)
        {
            if (author == null)
            {
                throw new ArgumentException();
            }

            int count = GetAllAuthorBooks(author).Count;

            return count;
        }

        public List<Book> GetAllAuthorBooks(Author author)
        {
            if (author == null)
            {
                throw new ArgumentException();
            }

            List<Book> books = bookServices
                .GetAllBooks()
                .Where(b => b.AuthorId == author.Id)
                .ToList();

            return books;
        }
    }
}
