﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Data.DiavanModels
{
    public partial class ResultImage
    {
        public int ResultImageId { get; set; }
        public string ImageUrl { get; set; }
        public Guid ImageGuid { get; set; }
        public string ImageType { get; set; }
        public int? ResultId { get; set; }
        public string Status { get; set; }

        public virtual Result Result { get; set; }
    }
}