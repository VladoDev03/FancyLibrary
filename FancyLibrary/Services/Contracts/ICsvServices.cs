using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Contracts
{
    public interface ICsvServices
    {
        void MakeCsvFileBook(string content, string path);

        string BookListToCsv(List<Book> books);
    }
}
