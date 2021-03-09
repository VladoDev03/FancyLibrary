using Data.Entities;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests.ServicesTests.UserBookServicesTests
{
    public class RemoveBookFromUserTests
    {
        private DbContextOptions<FancyLibraryContext> options;
        private FancyLibraryContext db;
        private UserBookServices userBookServices;

        [SetUp]
        public void Setup()
        {
            options = new DbContextOptionsBuilder<FancyLibraryContext>()
                   .UseInMemoryDatabase(databaseName: "fancy_library_book_to_user_remove")
                   .Options;

            db = new FancyLibraryContext(options);

            userBookServices = new UserBookServices(db);

            db.Users.AddRange(FillUsers());
            db.SaveChanges();
            db.Books.AddRange(FillBooks());
            db.SaveChanges();
            db.UsersBooks.AddRange(FillUsersBooks());
            db.SaveChanges();
        }

        [Test]
        public void IsRemovingBookFromUser()
        {
            User user = db.Users.FirstOrDefault(u => u.Id == 2);
            Book book = db.Books.FirstOrDefault(b => b.Id == 3);

            userBookServices.RemoveBookFromUser(user, book);

            bool doesExist = userBookServices
                .GetAllUsersBooks()
                .Exists(ub => ub.UserId == user.Id && ub.BookId == book.Id);

            Assert.IsFalse(doesExist);
        }

        private List<UserBook> FillUsersBooks()
        {
            List<UserBook> userBooks = new List<UserBook>
            {
                new UserBook
                {
                    UserId = 4,
                    BookId = 1
                },
                new UserBook
                {
                    UserId = 3,
                    BookId = 2
                },
                new UserBook
                {
                    UserId = 2,
                    BookId = 3
                },
                new UserBook
                {
                    UserId = 1,
                    BookId = 4
                }
            };

            return userBooks;
        }

        private List<Book> FillBooks()
        {
            List<Book> books = new List<Book>()
            {
                new Book
                {
                    Title = "title1",
                    Genre = "genre1",
                    AuthorId = 1
                },
                new Book
                {
                    Title = "title2",
                    Genre = "genre2",
                    AuthorId = 1
                },
                new Book
                {
                    Title = "title3",
                    Genre = "genre3",
                    AuthorId = 1
                },
                new Book
                {
                    Title = "title4",
                    Genre = "genre4",
                    AuthorId = 1
                }
            };

            return books;
        }

        private List<User> FillUsers()
        {
            List<User> users = new List<User>
            {
                new User
                {
                    Id = 1,
                    Username = "username1",
                    Password = "Password!2",
                    FirstName = "FirstName1",
                    LastName = "LastName1",
                    Birthday = DateTime.Parse("2000-01-01")
                },
                new User
                {
                    Id = 2,
                    Username = "username2",
                    Password = "Password!2",
                    FirstName = "FirstName2",
                    LastName = "LastName2",
                    Birthday = DateTime.Parse("2000-01-01")
                }
            };

            return users;
        }
    }
}
