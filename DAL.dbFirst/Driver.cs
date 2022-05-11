using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.dbFirst
{
    public partial class Driver
    {
        public Driver()
        {
            DriverVehicles = new HashSet<DriverVehicle>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Updated { get; set; }

        public virtual ICollection<DriverVehicle> DriverVehicles { get; set; }
    }
}
