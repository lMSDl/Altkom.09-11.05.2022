﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class SubComponent
    {
        public int Id { get; set; }
        public Status Status { get; set; }
        public Component Component { get; set; }
    }
}
