using ConsoleVersion.Utils;
using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ConsoleVersion.Models
{
    public partial class Country
    {
        private const int MinNameLength = 3;

        private string name;

        public Country()
        {
            Authors = new HashSet<Author>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value.Length < MinNameLength || string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionsTexts.CountryNameException, MinNameLength));
                }

                name = value;
            }
        }

        public virtual ICollection<Author> Authors { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
