using ConsoleVersion.Services;
using ConsoleVersion.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleVersion.Controllers
{
    public class UserBookController
    {
        private IUserBookServices userBookServices;

        public UserBookController(IUserBookServices userBookServices)
        {
            this.userBookServices = userBookServices;
        }
    }
}
