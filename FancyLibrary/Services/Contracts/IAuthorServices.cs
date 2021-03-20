using Data.Entities;
using Data.Models;
using Data.ViewModels;
using System.Collections.Generic;

namespace Services.Contracts
{
    public interface IAuthorServices
    {
        List<Author> GetAllAuthors();

        Author FindAuthor(string fullName);

        Author FindAuthor(int id);

        Author FindAuthor(int? id);

        void AddAuthor(Author author);

        List<Book> GetAuthorBooks(Author author);

        int GetAuthorBooksCount(Author author);

        int GetAuthorIdFromFullName(string authorFullName);

        string GetAuthorCountry(Author author);

        void UpdateAuthor(EditAuthorDTO book);

        List<AuthorView> GetAuthorList(List<Author> authors);
    }
}
