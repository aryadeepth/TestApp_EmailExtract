using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAPIToExtractXML.Model
{
    public class ExtraxtedData
    {
        public string CostCentre { get; set; }
        public Int32? Total { get; set; }
        private Double _salestaxRate = 0.0625; // using default sales tax percentage as 6.25%, so rate will be 0.0625
        public Double SalesTaxRate { 
            get
            {
                return _salestaxRate;
            }
            set {
                _salestaxRate = value;
            }
        }
        public Double? SalesTaxAmount { get; set; }
        public Double? TotalExcludingTax { get; set; }

    }
}
