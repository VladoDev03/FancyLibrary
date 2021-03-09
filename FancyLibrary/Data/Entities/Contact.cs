using Data.Utils;
using System;
using System.Collections.Generic;
using System.Text;

#nullable disable

namespace Data.Entities
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

        public virtual User User { get; set; }

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
