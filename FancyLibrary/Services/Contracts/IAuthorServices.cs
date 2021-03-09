using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Contracts
{
    public interface IAuthorServices
    {
        List<Author> GetAllAuthors();

        void AddAuthor(Author author);

        List<Book> GetAuthorBooks(Author author);

        int GetAuthorBookCount(Author author);
    }
}
