using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels
{
    public class FullAuthorView
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public int BookCount { get; set; }

        public string Birthday { get; set; }

        public string Nickname { get; set; }

        public string Country { get; set; }
    }
}
