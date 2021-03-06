﻿using Data.Entities;
using Data.ViewModels;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests.ServicesTests.UserBookServicesTests
{
    public class GetBooksOfUserTests
    {
        private DbContextOptions<FancyLibraryContext> options;
        private FancyLibraryContext db;
        private UserBookServices userBookServices;

        [SetUp]
        public void Setup()
        {
            options = new DbContextOptionsBuilder<FancyLibraryContext>()
                   .UseInMemoryDatabase(databaseName: "fancy_library_add_book_to_user_all_books")
                   .Options;

            db = new FancyLibraryContext(options);

            userBookServices = new UserBookServices(db);

            db.Authors.AddRange(FillAuthors());
            db.Users.AddRange(FillUsers());
            db.Books.AddRange(FillBooks());
            db.UsersBooks.AddRange(FillUsersBooks());

            db.SaveChanges();
        }

        [TearDown]
        public void TearDown()
        {
            this.db.Database.EnsureDeleted();
        }

        [Test]
        public void IsFindingAllBooksOfGivenUser()
        {
            User user = db.Users
                .FirstOrDefault(u => u.Id == 1);

            List<Book> actual = userBookServices.GetBooksOfUser(user);
            List<Book> expected = new List<Book>
            {
                new Book
                {
                    Id = 1,
                    Title = "title1",
                    Genre = "genre1",
                    AuthorId = 1
                },
                new Book
                {
                    Id = 2,
                    Title = "title2",
                    Genre = "genre2",
                    AuthorId = 1
                }
            };

            Assert.AreEqual(expected.Count, actual.Count);
        }

        [Test]
        public void IsFindingAllBooksViewsOfGivenUser()
        {
            List<BookView> actual = userBookServices.GetBooksOfUserViews(FillBooks());
            List<BookView> expected = new List<BookView>
            {
                new BookView
                {
                    Id = 1,
                    Title = "title1",
                    Genre = "genre1",
                    AuthorName = "first middle last"
                },
                new BookView
                {
                    Id = 2,
                    Title = "title2",
                    Genre = "genre2",
                    AuthorName = "first middle last"
                },
                new BookView
                {
                    Id = 3,
                    Title = "title3",
                    Genre = "genre3",
                    AuthorName = "first middle last"
                },
                new BookView
                {
                    Id = 4,
                    Title = "title4",
                    Genre = "genre4",
                    AuthorName = "first middle last"
                }
            };

            Assert.AreEqual(expected.Count, actual.Count);
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
                    UserId = 2,
                    BookId = 2
                },
                new UserBook
                {
                    UserId = 1,
                    BookId = 2
                },
                new UserBook
                {
                    UserId = 2,
                    BookId = 1
                },
                new UserBook
                {
                    UserId = 2,
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
                    Id = 1,
                    Title = "title1",
                    Genre = "genre1",
                    AuthorId = 1
                },
                new Book
                {
                    Id = 2,
                    Title = "title2",
                    Genre = "genre2",
                    AuthorId = 1
                },
                new Book
                {
                    Id = 3,
                    Title = "title3",
                    Genre = "genre3",
                    AuthorId = 1
                },
                new Book
                {
                    Id = 4,
                    Title = "title4",
                    Genre = "genre4",
                    AuthorId = 1
                }
            };

            return books;
        }

        private List<Author> FillAuthors()
        {
            List<Author> authors = new List<Author>()
            {
                new Author
                {
                    Id = 1,
                    FirstName = "first",
                    MiddleName = "middle",
                    LastName = "last"
                }
            };

            return authors;
        }

        private List<User> FillUsers()
        {
            List<User> users = new List<User>
            {
                new User
                {
                    Id = 1,
                    UserName = "UserName1",
                    Password = "Password!2",
                    FirstName = "FirstName1",
                    LastName = "LastName1",
                    Birthday = DateTime.Parse("2000-01-01")
                },
                new User
                {
                    Id = 2,
                    UserName = "UserName2",
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
