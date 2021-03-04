using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ConsoleVersion.Models
{
    public partial class Country
    {
        public Country()
        {
            Authors = new HashSet<Author>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Author> Authors { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
