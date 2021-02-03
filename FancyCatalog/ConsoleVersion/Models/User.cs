using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleVersion.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public DateTime BirthdayDate { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Id - {Id}");
            sb.AppendLine($"Username - {Username}");
            sb.AppendLine($"Password - {Password}");
            sb.AppendLine($"First name - {FirstName}");
            sb.AppendLine($"Middle name - {MiddleName}");
            sb.AppendLine($"Last name - {LastName}");
            sb.AppendLine($"Age - {Age}");
            sb.AppendLine($"Birthday date - {BirthdayDate.Day}-{BirthdayDate.Month}-{BirthdayDate.Year}");

            return sb.ToString().Trim();
        }
    }
}
