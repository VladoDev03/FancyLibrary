using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleVersion.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Genre { get; set; }

        public int Year { get; set; }

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
