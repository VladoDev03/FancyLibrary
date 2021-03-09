using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Entities
{
    public partial class UserBook
    {
        public int UserId { get; set; }

        public int BookId { get; set; }

        public virtual Book Book { get; set; }

        public virtual User User { get; set; }
    }
}
