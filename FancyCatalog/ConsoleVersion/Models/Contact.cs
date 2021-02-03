using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleVersion.Models
{
    public class Contact
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

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
