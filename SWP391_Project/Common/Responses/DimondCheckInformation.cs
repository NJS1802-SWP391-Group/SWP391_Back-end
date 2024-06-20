using Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Responses
{
    public class DimondCheckInformation
    {
        public int DiamondCheckId { get; set; }
        public double FairPrice {  get; set; }
        public double MinPrice {  get; set; }
        public double MaxPrice { get; set; }
        public DateTime UpdateDay { get; set; }
        public double Ratio {  get; set; }
        public string? CertificateId { get; set; }
        public string? Origin { get; set; }
        public string? Shape { get; set; }
        public string? LinkImageShape { get; set; }
        public double? Carat { get; set; }
        public string? Color { get; set; }
        public string? Clarity { get; set; }
        public string? Fluorescence { get; set; }
        public string? Symmetry { get; set; }
        public string? Polish { get; set; }
        public string? CutGrade { get; set; }
        public string? CutScore { get; set; }
        public DateTime? CertDate { get; set; }
        public string? Measurement { get; set; }
        public string? ClarityCharacteristic { get; set; }
        public string? Comment { get; set; }
        public string Status { get; set; }
        public List<DiamondCheckValueDto> DiamondCheckValues { get; set; }
        private static readonly Dictionary<string, string> ShapeImageLinks = new Dictionary<string, string>
    {
        { "Round", DiamondShapeEnum.Round },
        { "Oval", DiamondShapeEnum.Oval },
        { "Princess", DiamondShapeEnum.Princess },
        { "Emerald", DiamondShapeEnum.Emerald },
        { "Cushion", DiamondShapeEnum.Cushion },
        { "Radiant", DiamondShapeEnum.Radiant },
        { "Pear", DiamondShapeEnum.Pear },
        { "Heart", DiamondShapeEnum.Heart },
        { "Marquise", DiamondShapeEnum.Marquise },
        { "Asscher", DiamondShapeEnum.Asscher }
    };
        public void SetLinkImageShape()
        {
            if (Shape != null && ShapeImageLinks.TryGetValue(Shape, out var link))
            {
                LinkImageShape = link;
            }
            else
            {
                LinkImageShape = null;
            }
        }
    }
    public class DiamondCheckValueDto
    {
        public int DiamondCheckValueId { get; set; }
        public DateTime UpdateDay { get; set; }
        public double Price { get; set; }
    }
}
