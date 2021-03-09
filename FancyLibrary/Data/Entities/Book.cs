using Data.Utils;
using System;
using System.Collections.Generic;
using System.Text;

#nullable disable

namespace Data.Entities
{
    public partial class Book
    {
        private const int MinYear = 0;
        private const int MinLengthForTitle = 3;
        private const int MinLengthForGenre = 3;

        private string title;
        private string genre;
        private int year;

        public Book()
        {
            InverseInspiredBy = new HashSet<Book>();
            UsersBooks = new HashSet<UserBook>();
        }

        public int Id { get; set; }

        public string Title
        {
            get
            {
                return title;
            }
            set
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
            set
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
            set
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

        public int? Pages { get; set; }

        public int AuthorId { get; set; }

        public int? InspiredById { get; set; }

        public virtual Author Author { get; set; }

        public virtual Book InspiredBy { get; set; }

        public virtual ICollection<Book> InverseInspiredBy { get; set; }

        public virtual ICollection<UserBook> UsersBooks { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Id - {Id}");
            sb.AppendLine($"Title - {Title}");
            sb.AppendLine($"Genre - {Genre}");
            sb.AppendLine($"Year - {Year}");

            return sb.ToString().Trim();
        }
    }
}
