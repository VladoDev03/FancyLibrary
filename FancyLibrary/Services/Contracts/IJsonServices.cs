using Data.Entities;
using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Contracts
{
    public interface IJsonServices
    {
        void MakeJsonFileBook(string content, string path);

        string BookListToJson(List<BookView> books);

        string BookListToJson(List<BookView> books, bool isNull);
    }
}
