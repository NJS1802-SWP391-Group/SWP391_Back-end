﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Data.DiamondModels
{
    public partial class DiamondCheckValue
    {
        public int DiamondCheckValueId { get; set; }
        public DateTime UpdateDay { get; set; }
        public double Price { get; set; }
        public int DiamondCheckId { get; set; }

        public virtual DiamondCheck DiamondCheck { get; set; }
    }
}