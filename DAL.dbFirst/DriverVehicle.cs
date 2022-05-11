using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.dbFirst
{
    public partial class DriverVehicle
    {
        public int DriversId { get; set; }
        public int VehiclesId { get; set; }

        public virtual Driver Drivers { get; set; }
        public virtual Vehicle Vehicles { get; set; }
    }
}
