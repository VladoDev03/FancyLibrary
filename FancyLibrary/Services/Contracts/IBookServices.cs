using Data.Entities;
using Data.Models;
using Data.ViewModels;
using System.Collections.Generic;

namespace Services.Contracts
{
    public interface IBookServices
    {
        List<Book> GetAllBooks();

        void AddBook(Book book);

        int GetBookSavedTimes(Book book);

        Book FindBook(string title);

        Book FindBook(int id);

        Book FindBook(int? id);

        Author GetBookAuthor(Book book);

        void UpdateBook(EditBookDTO book);

        List<BookView> GetBookList(List<Book> books);
    }
}
