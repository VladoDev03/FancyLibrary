using ConsoleVersion.Utils;
using System;
using System.Collections.Generic;
using System.Text;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ConsoleVersion.Models
{
    public partial class Contact
    {
        private const int PhoneLength = 10;

        private string email;
        private string phone;

        public int Id { get; set; }

        public string Email
        {
            get
            {
                return email;
            }
            set
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
            set
            {
                if (value.Length != PhoneLength && value != null)
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

        public virtual User Users { get; set; }
    }
}
