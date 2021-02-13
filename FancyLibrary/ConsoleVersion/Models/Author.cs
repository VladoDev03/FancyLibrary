using ConsoleVersion.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleVersion.Models
{
    public class Author
    {
        private const int MinNameLength = 3;

        private string firstName;
        private string middleName;
        private string lastName;

        public Author()
        {

        }

        public Author(int id, string firstName, string middleName, string lastName, DateTime birthdayDate)
        {
            Id = id;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            BirthdayDate = birthdayDate;
        }

        public int Id { get; set; }

        public string FirstName
        {
            get
            {
                return firstName;
            }
            private set
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
            private set
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
            private set
            {
                if (value.Length < MinNameLength || string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionsTexts.LastNameException, MinNameLength));
                }

                lastName = value;
            }
        }

        public DateTime BirthdayDate { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Id - {Id}");
            sb.AppendLine($"First name - {FirstName}");
            sb.AppendLine($"Middle name - {MiddleName}");
            sb.AppendLine($"Last name - {LastName}");
            sb.AppendLine($"Birthday date - {BirthdayDate.Day}-{BirthdayDate.Month}-{BirthdayDate.Year}");

            return sb.ToString().Trim();
        }
    }
}
