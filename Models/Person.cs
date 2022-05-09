using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    //[Table("People", Schema = "efc")]
    public class Person : Entity
    {
        //[Column("Name")]
        //[MaxLength(15)]
        public string FirstName { get; set; }
        //[Required]
        public string LastName { get; set; }
        public DateTime? BithDate { get; set; }
        //[Column(TypeName = "decimal(11, 0)")] //określenie typu kolumny
        //[Precision(11, 0)] //EF Core 6!
        public ulong PESEL { get; set; }

        public string FullName { get; }

        //[NotMapped] // brak lokalnego mapowania
        public Address Address { get; set; }
        public int? AddressId { get; set; }
    }
}
