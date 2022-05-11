using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.dbFirst
{
    public partial class SubComponent
    {
        public int Id { get; set; }
        public string StatusId { get; set; }
        public int? ComponentId { get; set; }

        public virtual Component Component { get; set; }
        public virtual Status Status { get; set; }
    }
}
