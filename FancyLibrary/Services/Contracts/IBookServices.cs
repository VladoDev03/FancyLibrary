using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Contracts
{
    public interface IBookServices
    {
        List<Book> GetAllBooks();

        void AddBook(Book book);

        int GetBookSavedTimes(Book book);

        Book FindBook(string title);

        Book FindBook(int id);

        Author GetBookAuthor(Book book);

        int GetAuthorIdFromFullName(Book book, string authorFullName);
    }
}
