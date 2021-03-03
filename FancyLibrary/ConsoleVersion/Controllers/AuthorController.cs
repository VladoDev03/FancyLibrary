using ConsoleVersion.Models;
using ConsoleVersion.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleVersion.Controllers
{
    public class AuthorController
    {
        private AuthorServices authorServices;
        private BookServices bookServices;

        public AuthorController(AuthorServices authorServices, BookServices bookServices)
        {
            this.authorServices = authorServices;
            this.bookServices = bookServices;
        }

        // TODO
        public void AddNewAuthor(List<string> input)
        {
            throw new NotImplementedException();
        }

        public int GetAuthorBookCount(Author author)
        {
            int count = GetAllAuthorBooks(author).Count;

            return count;
        }

        public List<Book> GetAllAuthorBooks(Author author)
        {
            List<Book> books = bookServices
                .GetAllBooks()
                .Where(b => b.AuthorId == author.Id)
                .ToList();

            return books;
        }
    }
}
