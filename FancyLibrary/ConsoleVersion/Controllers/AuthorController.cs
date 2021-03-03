using ConsoleVersion.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleVersion.Controllers
{
    public class AuthorController
    {
        private AuthorServices authorServices;

        public AuthorController(AuthorServices authorServices)
        {
            this.authorServices = authorServices;
        }

        // TODO
        public void AddNewAuthor(List<string> input)
        {
            throw new NotImplementedException();
        }
    }
}
