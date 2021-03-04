using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ConsoleVersion.Models
{
    public partial class LogData
    {
        public int Id { get; set; }

        public DateTime LastTimeLoggedIn { get; set; }

        public bool IsOnline { get; set; }

        public DateTime RegisterDate { get; set; }

        public int TimesLoggedIn { get; set; }

        public virtual User Users { get; set; }
    }
}
