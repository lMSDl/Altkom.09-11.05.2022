using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.dbFirst
{
    public partial class Status
    {
        public Status()
        {
            SubComponents = new HashSet<SubComponent>();
        }

        public string Id { get; set; }

        public virtual ICollection<SubComponent> SubComponents { get; set; }
    }
}
