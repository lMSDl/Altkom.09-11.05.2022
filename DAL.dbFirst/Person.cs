using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.dbFirst
{
    public partial class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime? BithDate { get; set; }
        public decimal Pesel { get; set; }
        public string FullName { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public int? AddressId { get; set; }
        public float? AverageGrade { get; set; }
        public int? IndexNumber { get; set; }
        public string Specialization { get; set; }
        public string Type { get; set; }

        public virtual Address Address { get; set; }
    }
}
