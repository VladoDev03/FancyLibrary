using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleVersion.Models
{
    public class LocalDatabase : IDatabase
    {
        public LocalDatabase()
        {
            Authors = new List<Author>();
            Books = new List<Book>();
            Contacts = new List<Contact>();
            Users = new List<User>();
            FillAuthors();
            FillBooks();
            FillContacts();
            FillUsers();
        }

        public List<Author> Authors { get; set; }

        public List<Book> Books { get; set; }

        public List<Contact> Contacts { get; set; }

        public List<User> Users { get; set; }

        public void FillAuthors()
        {
            Authors.Add(new Author(1, "Roald", null, "Dahl", DateTime.Parse("1916-07-13")));
            Authors.Add(new Author(2, "Frances", "Hodgson", "Burnett", DateTime.Parse("1849-11-24")));
            Authors.Add(new Author(3, "Jules", "Gabriel", "Verne", DateTime.Parse("1828-02-08")));
        }

        public void FillBooks()
        {
            Books.Add(new Book(1, "Matilda", "Children's literature Fantasy", 1988, null));
            Books.Add(new Book(1, "The Secret Garden", "Children's novel", 1911, "NOT"));
            Books.Add(new Book(1, "The witches", "Children's fantasy Dark fantasy", 1983, null));
            Books.Add(new Book(1, "The Twits", "Children's novel", 1980, "NOT"));
            Books.Add(new Book(1, "Around the World in Eighty Days", "Adventure novel", 1972, null));
            Books.Add(new Book(1, "George's Marvellous Medicine", "Children's novel", 1981, null));
            Books.Add(new Book(1, "Charlie and the Chocolate Factory", "Children's fantasy novel", 1964, null));
        }

        public void FillContacts()
        {
            Contacts.Add(new Contact(1, "vladsto101@gmail.com", "0887865650"));
            Contacts.Add(new Contact(2, "ansto@abv.bg", null));
            Contacts.Add(new Contact(3, "dansto@mail.bg", "0887856560"));
            Contacts.Add(new Contact(4, "rumsto@abv.bg", null));
            Contacts.Add(new Contact(5, "nadesto@gmail.com", null));
        }

        public void FillUsers()
        {
            Users.Add(new User("vladsto", "42)snncmfT", "Vladimir", "Rumenov", "Stoyanov", 17, DateTime.Parse("2003-05-20"), DateTime.Parse("2021-01-01"), false));
            Users.Add(new User("ansto", "42)snncmfT", "Anna", "Rumenova", "Stoyanova", 15, DateTime.Parse("2005-09-06"), DateTime.Parse("2021-01-01"), false));
            Users.Add(new User("dansto", "42)snncmfT", "Yordan", "Emilov", "Stoyanov", 10, DateTime.Parse("2010-05-05"), DateTime.Parse("2021-01-01"), false));
            Users.Add(new User("rumsto", "42)snncmfT", "Rumen", "Yordanov", "Stoyanov", 50, DateTime.Parse("1970-03-22"), DateTime.Parse("2021-01-01"), false));
            Users.Add(new User("nadesto", "42)snncmfT", "Nadejda", "Ignatova", "Stoyanova", 41, DateTime.Parse("1979-03-15"), DateTime.Parse("2021-01-01"), false));
        }

        public void PrintAll()
        {
            Console.WriteLine("-----------Authors-----------");
            Console.WriteLine();

            foreach (Author author in Authors)
            {
                Console.WriteLine(author.ToString());
            }

            Console.WriteLine();
            Console.WriteLine("-----------Books-----------");
            Console.WriteLine();

            foreach (Book book in Books)
            {
                Console.WriteLine(book.ToString());
            }

            Console.WriteLine();
            Console.WriteLine("-----------Contacts-----------");
            Console.WriteLine();


            foreach (Contact contact in Contacts)
            {
                Console.WriteLine(contact.ToString());
            }

            Console.WriteLine();
            Console.WriteLine("-----------Users-----------");
            Console.WriteLine();

            foreach (User user in Users)
            {
                Console.WriteLine(user.ToString());
            }

            Console.WriteLine();
        }
    }
}
