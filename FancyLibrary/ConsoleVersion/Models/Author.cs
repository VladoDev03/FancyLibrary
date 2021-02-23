using ConsoleVersion.Utils;
using System;
using System.Collections.Generic;
using System.Text;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ConsoleVersion.Models
{
    public partial class Author
    {
        private const int MinNameLength = 3;

        private string firstName;
        private string middleName;
        private string lastName;

        public Author()
        {
            Books = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                if (value.Length < MinNameLength || string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionsTexts.FirstNameException, MinNameLength));
                }

                firstName = value;
            }
        }

        public string MiddleName
        {
            get
            {
                return middleName;
            }
            set
            {
                if ((value != null && value.Length < MinNameLength))
                {
                    throw new ArgumentException(string.Format(ExceptionsTexts.MiddleNameException, MinNameLength));
                }

                middleName = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                if (value.Length < MinNameLength || string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionsTexts.LastNameException, MinNameLength));
                }

                lastName = value;
            }
        }
        public DateTime? Birthday { get; set; }
        public string Nickname { get; set; }
        public int? CountryId { get; set; }

        public virtual Countrie Country { get; set; }
        public virtual ICollection<Book> Books { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Id - {Id}");
            sb.AppendLine($"First name - {FirstName}");
            sb.AppendLine($"Middle name - {MiddleName}");
            sb.AppendLine($"Last name - {LastName}");

            return sb.ToString().Trim();
        }
    }
}
