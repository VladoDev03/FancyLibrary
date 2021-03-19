using System.Collections.Generic;

namespace Data.ViewModels
{
    public class FullUserView
    {
        public FullUserView()
        {
            Books = new List<BookView>();
        }

        public int Id { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public int BooksCount { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public List<BookView> Books { get; set; }
    }
}
