using ConsoleVersion.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleVersion.Models
{
    public class Contact
    {
        private const int PhoneLength = 10;

        private string email;
        private string phone;

        public Contact()
        {

        }

        public Contact(int id, string email, string phone)
            : this(email, phone)
        {
            Id = id;
        }

        public Contact(string email, string phone)
        {
            Email = email;
            Phone = phone;
        }

        public int Id { get; set; }

        public string Email
        {
            get
            {
                return email;
            }
            private set
            {
                if (!value.Contains("@") && value != null)
                {
                    throw new ArgumentException(string.Format(ExceptionsTexts.NotValidEmail));
                }

                email = value;
            }
        }

        public string Phone
        {
            get
            {
                return phone;
            }
            private set
            {
                if (value != null && value.Length != PhoneLength)
                {
                    throw new ArgumentException(string.Format(ExceptionsTexts.NotValidPhone));
                }

                phone = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Id - {Id}");
            sb.AppendLine($"Email - {Email}");
            sb.AppendLine($"Phone - {Phone}");

            return sb.ToString().Trim();
        }
    }
}
