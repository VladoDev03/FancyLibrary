using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleVersion.Models
{
    public class RemoteDatabase : IDatabase
    {
        private const string connectionString = "Server=.;Database=MyFancyCatalog;Integrated Security=true;";

        public RemoteDatabase()
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
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            using SqlCommand command = new SqlCommand("SELECT Id, FirstName, MiddleName, LastName, BirthdayDate FROM Authors", connection);

            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int id = (int)reader["Id"];
                string firstName = (string)reader["FirstName"];
                string middleName = (string)reader["MiddleName"];
                string lastName = (string)reader["LastName"];
                DateTime birthdayDate = (DateTime)reader["BirthdayDate"];

                Author author = new Author(id, firstName, middleName, lastName, birthdayDate);
                Authors.Add(author);
            }
        }

        public void FillBooks()
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            using SqlCommand command = new SqlCommand("SELECT Id, Title, Genre, [Year], LinkToInternet FROM Books", connection);

            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int id = (int)reader["Id"];
                string title = (string)reader["Title"];
                string genre = (string)reader["Genre"];
                int year = (int)reader["Year"];
                string linkToInternet = (string)reader["LinkToInternet"];

                Book book = new Book(id, title, genre, year, linkToInternet);
                Books.Add(book);
            }
        }

        public void FillContacts()
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            using SqlCommand command = new SqlCommand("SELECT Id, Email, Phone FROM Contacts", connection);

            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int id = (int)reader["Id"];
                string firstName = (string)reader["Email"];
                string middleName = (string)reader["Phone"];

                Contact contact = new Contact(id, firstName, middleName);
                Contacts.Add(contact);
            }
        }

        public void FillUsers()
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"SELECT Id, Username, Password,");
            sb.AppendLine($"FirstName, MiddleName, LastName,");
            sb.AppendLine($"Age, BirthdayDate, LastTimeLoggedIn,");
            sb.Append($"IsOnline, ContactId FROM Users;");

            using SqlCommand command = new SqlCommand(sb.ToString(), connection);

            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int id = (int)reader["Id"];
                string username = (string)reader["Username"];
                string password = (string)reader["Password"];
                string firstName = (string)reader["FirstName"];
                string middleName = (string)reader["MiddleName"];
                string lastName = (string)reader["LastName"];
                int age = (int)reader["age"];
                DateTime birthdayDate = (DateTime)reader["BirthdayDate"];
                DateTime lastTimeLoggedIn = (DateTime)reader["LastTimeLoggedIn"];
                bool isOnline = (bool)reader["IsOnline"];

                User user = new User(id, username, password, firstName, middleName, lastName, age, birthdayDate, lastTimeLoggedIn, isOnline);
                Users.Add(user);
            }
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
