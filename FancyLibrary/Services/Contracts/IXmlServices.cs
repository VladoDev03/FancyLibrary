using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Contracts
{
    public interface IXmlServices
    {
        void MakeXmlFileBook(string content, string path);

        string BookListToXml(List<Book> books);
    }
}
