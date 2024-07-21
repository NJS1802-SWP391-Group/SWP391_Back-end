﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Data.DiavanModels
{
    public partial class OrderDetail
    {
        public OrderDetail()
        {
            AssigningOrderDetails = new HashSet<AssigningOrderDetail>();
        }

        public int OrderDetailId { get; set; }
        public string Code { get; set; }
        public double EstimateLength { get; set; }
        public int ServiceDetailId { get; set; }
        public double Price { get; set; }
        public string Status { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public virtual ServiceDetail ServiceDetail { get; set; }
        public virtual ICollection<AssigningOrderDetail> AssigningOrderDetails { get; set; }
    }
}