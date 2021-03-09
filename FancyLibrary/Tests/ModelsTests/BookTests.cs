using Data.Entities;
using NUnit.Framework;
using System;
using System.Text;

namespace Tests.ModelsTests
{
    public class BookTests
    {
        [Test]
        public void ThrowExceptionWhenTitleIsShorter()
        {
            Book book = null;

            ArgumentException ae = Assert.Throws<ArgumentException>(() => book = new Book
            {
                Title = "t",
                Genre = "genre1",
                Year = 2021,
                AuthorId = 1
            });

            string expected = string.Format("Title must be at least {0} characters long!", 3);

            Assert.That(ae.Message, Is.EqualTo(expected));
        }

        [Test]
        public void ThrowExceptionWhenTitleIsNull()
        {
            Book book = null;

            ArgumentException ae = Assert.Throws<ArgumentException>(() => book = new Book
            {
                Title = "",
                Genre = "genre1",
                Year = 2021,
                AuthorId = 1
            });

            string expected = string.Format("Title must be at least {0} characters long!", 3);

            Assert.That(ae.Message, Is.EqualTo(expected));
        }

        [Test]
        public void IsTitleReturningCorrectValue()
        {
            Book book = book = new Book
            {
                Title = "title1",
                Genre = "genre1",
                Year = 2021,
                AuthorId = 1
            };

            Assert.That(book.Title, Is.EqualTo("title1"));
        }
        [Test]
        public void ThrowExceptionWhenGenreIsShorter()
        {
            Book book = null;

            ArgumentException ae = Assert.Throws<ArgumentException>(() => book = new Book
            {
                Title = "title1",
                Genre = "g",
                Year = 2021,
                AuthorId = 1
            });

            string expected = string.Format("Genre must be at least {0} characters long!", 3);

            Assert.That(ae.Message, Is.EqualTo(expected));
        }

        [Test]
        public void ThrowExceptionWhenGenreIsNull()
        {
            Book book = null;

            ArgumentException ae = Assert.Throws<ArgumentException>(() => book = new Book
            {
                Title = "title1",
                Genre = "",
                Year = 2021,
                AuthorId = 1
            });

            string expected = string.Format("Genre must be at least {0} characters long!", 3);

            Assert.That(ae.Message, Is.EqualTo(expected));
        }

        [Test]
        public void IsGenreReturningCorrectValue()
        {
            Book book = book = new Book
            {
                Title = "title1",
                Genre = "genre1",
                Year = 2021,
                AuthorId = 1
            };

            Assert.That(book.Genre, Is.EqualTo("genre1"));
        }

        [Test]
        public void IsIdReturningCorrectValue()
        {
            Book book = book = new Book
            {
                Id = 1,
                Title = "title1",
                Genre = "genre1",
                Year = 2021,
                AuthorId = 1
            };

            Assert.That(book.Id, Is.EqualTo(1));
        }

        [Test]
        public void ThrowExceptionWhenYearIsEarlierThanMinYear()
        {
            Book book = null;

            ArgumentException ae = Assert.Throws<ArgumentException>(() => book = new Book
            {
                Title = "title1",
                Genre = "genre1",
                Year = -100,
                AuthorId = 1
            });

            string expected = string.Format("Year must be after {0}!", 0);

            Assert.That(ae.Message, Is.EqualTo(expected));
        }

        [Test]
        public void ThrowExceptionWhenYearIsLaterThanMaxYear()
        {
            Book book = null;

            ArgumentException ae = Assert.Throws<ArgumentException>(() => book = new Book
            {
                Title = "title1",
                Genre = "genre1",
                Year = 10100,
                AuthorId = 1
            });

            string expected = string.Format("Year must be earlier than {0}!", DateTime.Now.Year);

            Assert.That(ae.Message, Is.EqualTo(expected));
        }

        [Test]
        public void IsToStringReturningCorrectValue()
        {
            Book book = book = new Book
            {
                Id = 1,
                Title = "title1",
                Genre = "genre1",
                Year = 2021
            };

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Id - 1");
            sb.AppendLine($"Title - title1");
            sb.AppendLine($"Genre - genre1");
            sb.AppendLine($"Year - 2021");

            string expected = sb.ToString().Trim();

            Assert.That(book.ToString(), Is.EqualTo(expected));
        }

        [Test]
        public void IsReturningCorrectAmountOfPages()
        {
            Book book = book = new Book
            {
                Id = 1,
                Title = "title1",
                Genre = "genre1",
                Year = 2021,
                Pages = 1000
            };

            Assert.That(book.Pages, Is.EqualTo(1000));
        }

        [Test]
        public void IsReturningCorrectAuthorId()
        {
            Book book = book = new Book
            {
                Id = 1,
                Title = "title1",
                Genre = "genre1",
                Year = 2021,
                AuthorId = 1
            };

            Assert.That(book.AuthorId, Is.EqualTo(1));
        }

        [Test]
        public void IsReturningCorrectInspiredById()
        {
            Book book = book = new Book
            {
                Id = 1,
                Title = "title1",
                Genre = "genre1",
                Year = 2021,
                InspiredById = 2
            };

            Assert.That(book.InspiredById, Is.EqualTo(2));
        }
    }
}
