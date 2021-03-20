﻿using System.Text;

namespace Data.ViewModels
{
    public class FullBookView
    {
        public int? Id { get; set; }

        public string Title { get; set; }

        public string Genre { get; set; }

        public string AuthorName { get; set; }

        public int? Year { get; set; }

        public int? Pages { get; set; }

        public int SavedTimes { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Title - {Title}");
            sb.AppendLine($"Genre - {Genre}");
            sb.AppendLine($"Author - {AuthorName}");
            sb.AppendLine($"Year - {Year}");
            sb.AppendLine($"Pages - {Pages}");

            return sb.ToString().Trim();
        }
    }
}
