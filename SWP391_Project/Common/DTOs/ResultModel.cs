﻿using SWP391_Project.Domain.DiavanEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs
{
    public class ResultModel
    {
        public int ResultId { get; set; }
        public bool IsDiamond { get; set; }
        public string? Code { get; set; }
        public string? Origin { get; set; }
        public string? Shape { get; set; }
        public string? Carat { get; set; }
        public string? Color { get; set; }
        public string? Clarity { get; set; }
        public string? Fluorescence { get; set; }
        public string? Symmetry { get; set; }
        public string? Polish { get; set; }
        public string? CutGrade { get; set; }
        public string ValueStatus { get; set; }
        public string? Description { get; set; }
        public double? DiamondValue { get; set; }
        public string Status { get; set; }
        public int OrderDetailId { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? ExpireDate { get; set; }
        public string? CertificateStatus { get; set; }
    }
}