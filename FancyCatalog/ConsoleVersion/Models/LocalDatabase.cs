using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleVersion.Models
{
    public class LocalDatabase
    {
        public LocalDatabase()
        {
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
            string path = "Authors.csv";
            using CsvReader csvReader = new CsvReader(new StreamReader(path), CultureInfo.InvariantCulture);
            Authors = csvReader.GetRecords<Author>().ToList();
        }

        public void FillBooks()
        {
            string path = "Books.csv";
            using CsvReader csvReader = new CsvReader(new StreamReader(path), CultureInfo.InvariantCulture);
            Books = csvReader.GetRecords<Book>().ToList();
        }

        public void FillContacts()
        {
            string path = "Contacts.csv";
            using CsvReader csvReader = new CsvReader(new StreamReader(path), CultureInfo.InvariantCulture);
            Contacts = csvReader.GetRecords<Contact>().ToList();
        }

        public void FillUsers()
        {
            string path = "Users.csv";
            using CsvReader csvReader = new CsvReader(new StreamReader(path), CultureInfo.InvariantCulture);
            Users = csvReader.GetRecords<User>().ToList();
        }

        public void PrintAll()
        {
            foreach (Author author in Authors)
            {
                Console.WriteLine(author.ToString());
            }

            Console.WriteLine();

            foreach (Book book in Books)
            {
                Console.WriteLine(book.ToString());
            }

            Console.WriteLine();

            foreach (Contact contact in Contacts)
            {
                Console.WriteLine(contact.ToString());
            }

            Console.WriteLine();

            foreach (User user in Users)
            {
                Console.WriteLine(user.ToString());
            }

            Console.WriteLine();
        }
    }
}
