using Data.Entities;
using Data.ViewModels;
using System.Collections.Generic;

namespace Services.Contracts
{
    public interface IUserBookServices
    {
        List<UserBook> GetAllUsersBooks();

        UserBook FindUserBook(int? userId, int? bookId);

        void AddBookToUser(User user, Book book);

        int GetUserBooksCount(User user);

        void RemoveBookFromUser(User user, Book book);

        List<Book> GetBooksOfUser(User user);

        void DeleteAllBooks(User user);

        List<BookView> GetBooksOfUserViews(List<Book> books);
    }
}
