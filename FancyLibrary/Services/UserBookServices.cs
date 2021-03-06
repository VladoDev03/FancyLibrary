﻿using Data.Entities;
using Data.Utils;
using Data.ViewModels;
using Services.Contracts;
using System.Collections.Generic;
using System.Linq;

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

        public UserBook FindUserBook(int? userId, int? bookId)
        {
            return db.UsersBooks.FirstOrDefault(ub => ub.UserId == userId && ub.BookId == bookId);
        }

        public void DeleteAllBooks(User user)
        {
            db.UsersBooks.RemoveRange(GetAllUsersBooks());
            db.SaveChanges();
        }

        public List<BookView> GetBooksOfUserViews(List<Book> books)
        {
            List<BookView> result = new List<BookView>();

            foreach (var item in books)
            {
                Author author = db.Authors.FirstOrDefault(a => a.Id == item.AuthorId);

                BookView bookView = new BookView
                {
                    Id = item.Id,
                    Title = item.Title,
                    Genre = item.Genre,
                    AuthorName = NameRefactorer
                        .GetFullName(author.FirstName, author.MiddleName, author.LastName)
                };

                result.Add(bookView);
            }

            return result;
        }
    }
}
