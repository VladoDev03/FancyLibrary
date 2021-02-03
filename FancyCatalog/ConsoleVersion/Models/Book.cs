using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleVersion.Models
{
    public class Book
    {
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

        public string Title { get; set; }

        public string Genre { get; set; }

        public int Year { get; set; }

        public string LinkToInternet { get; set; }

        public Author Author { get; set; }

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
