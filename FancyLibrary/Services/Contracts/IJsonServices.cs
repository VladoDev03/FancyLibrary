using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Contracts
{
    public interface IJsonServices
    {
        void MakeJsonFileBook(string content, string path);

        string BookListToJson(List<Book> books);
    }
}
