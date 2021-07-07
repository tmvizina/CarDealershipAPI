﻿using System;
using System.Collections.Generic;

#nullable disable

namespace CarDealership.Models
{
    public partial class Car
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int? Year { get; set; }
        public string Color { get; set; }
        public string Picture { get; set; }
    }
}
