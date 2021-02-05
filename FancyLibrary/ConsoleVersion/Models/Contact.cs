using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleVersion.Models
{
    public class Contact
    {
        //private const int PhoneLength = 10;

        private string email;
        private string phone;

        public Contact()
        {

        }

        public Contact(int id, string email, string phone)
        {
            Id = id;
            Email = email;
            Phone = phone;
        }

        public int Id { get; set; }

        //TODO: add exception message.
        public string Email
        {
            get
            {
                return email;
            }
            private set
            {
                if (!value.Contains("@") || string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException();
                }

                email = value;
            }
        }

        //TODO: add exception message.
        public string Phone
        {
            get
            {
                return phone;
            }
            private set
            {
                //if (value != null && value.Length != PhoneLength)
                //{
                //    throw new ArgumentException();
                //}

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
