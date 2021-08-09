using Data.Entities;
using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Contracts
{
    public interface IQrCodeServices
    {
        string MakeQrCode(string content/*, string path*/);

        string BookListToQrCode(List<BookView> books);
    }
}
