using ConsoleVersion.Models;
using ConsoleVersion.Services;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tests.ServicesTests.UserBookTests
{
    public class GetUserBooksCountTests
    {
        private DbContextOptions<FancyLibraryContext> options;
        private FancyLibraryContext db;
        private UserBookServices services;

        [Test]
        public void IsFindingCorrectCountWhenUserHasMoreThanZeroBook()
        {
            options = new DbContextOptionsBuilder<FancyLibraryContext>()
                         .UseInMemoryDatabase(databaseName: "fancy_library_books_count_four")
                         .Options;

            db = new FancyLibraryContext(options);

            services = new UserBookServices(db);

            db.Books.AddRange(FillBooks());
            db.UsersBooks.AddRange(FillUsersBooks());
            db.Users.AddRange(FillUsers());

            db.SaveChanges();

            User user = db.Users.First();

            Assert.That(4, Is.EqualTo(services.GetUserBooksCount(user)));
        }

        [Test]
        public void DoesMethodReturnZeroWhenUserHasZeroBooks()
        {
            options = new DbContextOptionsBuilder<FancyLibraryContext>()
                         .UseInMemoryDatabase(databaseName: "fancy_library_books_count_zero")
                         .Options;

            db = new FancyLibraryContext(options);

            services = new UserBookServices(db);

            db.Books.AddRange(FillBooks());
            db.UsersBooks.AddRange(FillUsersBooks());
            db.Users.AddRange(FillUsers());

            db.SaveChanges();

            User user = db.Users.Last();

            Assert.That(0, Is.EqualTo(services.GetUserBooksCount(user)));
        }

        private List<UserBook> FillUsersBooks()
        {
            List<UserBook> userBooks = new List<UserBook>
            {
                new UserBook
                {
                    UserId = 1,
                    BookId = 1
                },
                new UserBook
                {
                    UserId = 1,
                    BookId = 2
                },
                new UserBook
                {
                    UserId = 1,
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
