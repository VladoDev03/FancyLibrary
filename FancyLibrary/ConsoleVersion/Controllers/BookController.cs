using ConsoleVersion.Enums;
using ConsoleVersion.Models;
using ConsoleVersion.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleVersion.Controllers
{
    public class BookController
    {
        private BookServices bookServices;

        public BookController(BookServices bookServices)
        {
            this.bookServices = bookServices;
        }

        // TODO
        public void AddNewBook(List<string> input)
        {
            throw new NotImplementedException();
        }

        public List<Book> OrderByCriteria(BookSortingEnum criteria)
        {
            List<Book> books = bookServices.GetAllBooks();

            switch (criteria)
            {
                case BookSortingEnum.Title:
                    books = books.OrderBy(b => b.Title).ToList();
                    break;
                case BookSortingEnum.Author:
                    books = books
                        .OrderBy(b => b.Author.FirstName)
                        .ThenBy(b => b.Author.LastName)
                        .ToList();
                    break;
                case BookSortingEnum.Year:
                    books = books.OrderBy(b => b.Year).ToList();
                    break;
                case BookSortingEnum.Saved:
                    books = books
                        .OrderBy(b => bookServices.GetBookSavedTimes(b))
                        .ToList();
                    break;
            }

            return books;
        }
    }
}
