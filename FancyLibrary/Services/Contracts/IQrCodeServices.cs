using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Contracts
{
    public interface IQrCodeServices
    {
        void MakeQrCode(string content, string path);

        string BookListToQrCode(List<Book> books);
    }
}
