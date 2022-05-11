using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.dbFirst
{
    public partial class Component
    {
        public Component()
        {
            SubComponents = new HashSet<SubComponent>();
        }

        public int Id { get; set; }

        public virtual ICollection<SubComponent> SubComponents { get; set; }
    }
}
