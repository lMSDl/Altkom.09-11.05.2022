using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.dbFirst
{
    public partial class LargeCompany
    {
        public int Id { get; set; }
        public int NumberOfEmployees { get; set; }

        public virtual SmallCompany IdNavigation { get; set; }
    }
}
