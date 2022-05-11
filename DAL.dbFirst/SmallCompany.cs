using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.dbFirst
{
    public partial class SmallCompany
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public string Name { get; set; }

        public virtual LargeCompany LargeCompany { get; set; }
    }
}
