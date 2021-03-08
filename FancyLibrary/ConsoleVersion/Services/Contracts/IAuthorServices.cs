using ConsoleVersion.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleVersion.Services.Contracts
{
    public interface IAuthorServices
    {
        List<Author> GetAllAuthors();

        void AddAuthor(Author author);

        List<Book> GetAuthorBooks(Author author);

        int GetAuthorBookCount(Author author);
    }
}
