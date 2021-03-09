using Data;
using Data.Entities;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class UserBookServices : IUserBookServices
    {
        private FancyLibraryContext db;

        public UserBookServices(FancyLibraryContext db)
        {
            this.db = db;
        }

        public List<UserBook> GetAllUsersBooks()
        {
            List<UserBook> usersBooks = db.UsersBooks.ToList();
            return usersBooks;
        }

        public void AddBookToUser(User user, Book book)
        {
            db.UsersBooks.Add(new UserBook
            {
                UserId = user.Id,
                BookId = book.Id
            });

            db.SaveChanges();
        }

        public int GetUserBooksCount(User user)
        {
            int userId = user.Id;

            int count = db.UsersBooks
                .Where(ub => ub.UserId == userId)
                .Count();

            return count;
        }

        public void RemoveBookFromUser(User user, Book book)
        {
            UserBook userBook = db.UsersBooks
                .FirstOrDefault(ub => ub.BookId == book.Id && ub.UserId == user.Id);

            db.UsersBooks.Remove(userBook);
            db.SaveChanges();

            db.SaveChanges();
        }

        public List<Book> GetBooksOfUser(User user)
        {
            List<int> booksId = db.UsersBooks
                .Where(u => u.UserId == user.Id)
                .Select(b => b.BookId)
                .ToList();

            List<Book> books = new List<Book>();

            foreach (int item in booksId)
            {
                Book book = db.Books
                    .FirstOrDefault(b => b.Id == item);

                books.Add(book);
            }

            return books;
        }
    }
}
