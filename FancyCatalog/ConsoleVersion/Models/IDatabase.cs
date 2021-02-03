using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleVersion.Models
{
    public interface IDatabase
    {
        public List<Author> Authors { get; set; }

        public List<Book> Books { get; set; }

        public List<Contact> Contacts { get; set; }

        public List<User> Users { get; set; }

        public void FillAuthors();

        public void FillBooks();

        public void FillContacts();

        public void FillUsers();

        public void PrintAll();
    }
}
