using Data.Entities;
using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Contracts
{
    public interface ICsvServices
    {
        void MakeCsvFileBook(string content, string path);

        string BookListToCsv(List<BookView> books);
    }
}
