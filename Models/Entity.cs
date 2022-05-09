using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public DateTime Updated { get; set; }
    }
}
