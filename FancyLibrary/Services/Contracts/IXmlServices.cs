using Data.Entities;
using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Contracts
{
    public interface IXmlServices
    {
        void MakeXmlFileBook(string content, string path);

        string BookListToXml(List<BookView> books);
    }
}
