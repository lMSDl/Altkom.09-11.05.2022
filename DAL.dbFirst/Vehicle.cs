using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.dbFirst
{
    public partial class Vehicle
    {
        public Vehicle()
        {
            DriverVehicles = new HashSet<DriverVehicle>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public int? EngineId { get; set; }

        public virtual Engine Engine { get; set; }
        public virtual Registration Registration { get; set; }
        public virtual ICollection<DriverVehicle> DriverVehicles { get; set; }
    }
}
