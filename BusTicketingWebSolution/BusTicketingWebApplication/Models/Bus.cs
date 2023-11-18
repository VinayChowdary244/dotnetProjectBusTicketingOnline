﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusModelLibrary
{
    public class Bus
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public float Cost { get; set; }
        public int Capacity { get; set; }
        public string Start { get; set; }
        public string End { get; set; }

    }
}