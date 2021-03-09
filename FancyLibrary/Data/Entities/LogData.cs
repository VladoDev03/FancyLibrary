using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Entities
{
    public partial class LogData
    {
        public int Id { get; set; }

        public DateTime LastTimeLoggedIn { get; set; }

        public bool IsOnline { get; set; }

        public DateTime RegisterDate { get; set; }

        public int TimesLoggedIn { get; set; }

        public virtual User User { get; set; }
    }
}
