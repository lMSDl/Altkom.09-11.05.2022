using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    //[NotMapped] //brak globalnego mapowania
    //[Index(nameof(ZipCode), Name = "Index_Address_Zip")]
    //[Index(nameof(Street), nameof(City), IsUnique = true)]
    public class Address : Entity
    {
        //public int Ident { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
    }
}
