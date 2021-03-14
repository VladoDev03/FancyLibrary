using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels
{
    public class BookView
    {
        public int? Id { get; set; }

        public string Title { get; set; }

        public string Genre { get; set; }

        public string AuthorName { get; set; }

        public int? Year { get; set; }

        public int SavedTimes { get; set; }
    }
}
