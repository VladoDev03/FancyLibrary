using ConsoleVersion.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleVersion.Models
{
    public class Book
    {
        //private static readonly int LatestYear = DateTime.Now.Year;
        private const int MinYear = 0;
        private const int MinLengthForTitle = 3;
        private const int MinLengthForGenre = 3;

        private string title;
        private string genre;
        private int year;
        //private Author author;

        public Book()
        {

        }

        public Book(int id, string title, string genre, int year, string linkToInternet)
        {
            Id = id;
            Title = title;
            Genre = genre;
            Year = year;
            LinkToInternet = linkToInternet;
        }

        public int Id { get; set; }

        public string Title
        {
            get
            {
                return title;
            }
            private set
            {
                if (value.Length < MinLengthForTitle || string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionsTexts.TitleException, MinLengthForTitle));
                }

                title = value;
            }
        }

        public string Genre
        {
            get
            {
                return genre;
            }
            private set
            {
                if (value.Length < MinLengthForGenre || string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionsTexts.GenreException, MinLengthForGenre));
                }

                genre = value;
            }
        }

        public int Year
        {
            get
            {
                return year;
            }
            private set
            {
                if (value < MinYear)
                {
                    throw new ArgumentException(string.Format(ExceptionsTexts.TooOldYear, MinYear));
                }
                else if (value > DateTime.Now.Year)
                {
                    throw new ArgumentException(string.Format(ExceptionsTexts.FutureYear, DateTime.Now.Year));
                }

                year = value;
            }
        }

        //TODO: add exception message.
        //public Author Author
        //{
        //    get
        //    {
        //        return author;
        //    }
        //    private set
        //    {
        //        if (value == null)
        //        {
        //            throw new ArgumentException();
        //        }

        //        author = value;
        //    }
        //}

        public string LinkToInternet { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Id - {Id}");
            sb.AppendLine($"Title - {Title}");
            sb.AppendLine($"Genre - {Genre}");
            sb.AppendLine($"Year - {Year}");
            sb.AppendLine($"Link to internet - {LinkToInternet}");

            return sb.ToString().Trim();
        }
    }
}
