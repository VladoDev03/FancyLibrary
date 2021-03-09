using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Contracts
{
    public interface IUserBookServices
    {
        public List<UserBook> GetAllUsersBooks();

        public void AddBookToUser(User user, Book book);

        public int GetUserBooksCount(User user);

        public void RemoveBookFromUser(User user, Book book);

        public List<Book> GetBooksOfUser(User user);
    }
}
