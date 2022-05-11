using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.dbFirst
{
    public partial class Registration
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int? VehicleId { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        public virtual Vehicle Vehicle { get; set; }
    }
}
