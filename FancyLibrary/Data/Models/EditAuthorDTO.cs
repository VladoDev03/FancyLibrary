using System;

namespace Data.Models
{
    public class EditAuthorDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public DateTime? Birthday { get; set; }

        public string Nickname { get; set; }

        public string Country { get; set; }
    }
}
