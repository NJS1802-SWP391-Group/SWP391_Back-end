﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Data.DiavanModels
{
    public partial class Account
    {
        public Account()
        {
            AssigningOrderDetails = new HashSet<AssigningOrderDetail>();
            Orders = new HashSet<Order>();
        }

        public int AccountId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<AssigningOrderDetail> AssigningOrderDetails { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}