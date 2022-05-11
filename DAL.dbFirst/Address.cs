using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.dbFirst
{
    public partial class Address
    {
        public Address()
        {
            People = new HashSet<Person>();
        }

        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        public virtual ICollection<Person> People { get; set; }
    }
}
