﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Data.DiavanModels
{
    public partial class Result
    {
        public Result()
        {
            AssigningOrderDetails = new HashSet<AssigningOrderDetail>();
            ResultImages = new HashSet<ResultImage>();
        }

        public int ResultId { get; set; }
        public bool IsDiamond { get; set; }
        public string Code { get; set; }
        public string Origin { get; set; }
        public string Shape { get; set; }
        public double? Carat { get; set; }
        public string Color { get; set; }
        public string Clarity { get; set; }
        public string Fluorescence { get; set; }
        public string Symmetry { get; set; }
        public string Polish { get; set; }
        public string CutGrade { get; set; }
        public string Description { get; set; }
        public double? DiamondValue { get; set; }
        public string Status { get; set; }

        public virtual ICollection<AssigningOrderDetail> AssigningOrderDetails { get; set; }
        public virtual ICollection<ResultImage> ResultImages { get; set; }
    }
}