using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.dbFirst
{
    public partial class Engine
    {
        public Engine()
        {
            Vehicles = new HashSet<Vehicle>();
        }

        public int Id { get; set; }
        public int Power { get; set; }
        public DateTime Updated { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
