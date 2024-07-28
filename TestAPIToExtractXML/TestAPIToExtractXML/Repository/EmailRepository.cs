using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using TestAPIToExtractXML.Model;

namespace TestAPIToExtractXML.Repository
{
    public class EmailRepository
    {
        public Boolean ValidateMessage(string message)
        {
            try
            {
                XmlDocument xdoc = new XmlDocument();
                xdoc.LoadXml(message);
                return true;
            }
            catch (XmlException xe)
            {
                return false;
            }
        }
        public ExtraxtedData ExtractEmailContent(string data)
        {
            ExtraxtedData exData = new ExtraxtedData();
            var rootElement = XElement.Parse(data);
            var total = rootElement.Element("total").Value;
            var costCentre = rootElement.Element("cost_centre").Value;
            if (costCentre != null)
            {
                var salesTaxRate = exData.SalesTaxRate;
                //using reverse sales tax calculation formula, list price = total ÷ (1 + tax rate)
                var listPrice = Convert.ToDouble(total) / (1 + Convert.ToDouble(salesTaxRate));
                var salesTaxAmount = Convert.ToDouble(listPrice) * Convert.ToDouble(salesTaxRate);
                exData.TotalExcludingTax = listPrice;
                exData.SalesTaxAmount = salesTaxAmount;
                exData.CostCentre = costCentre;
            }
            else
            {
                exData.CostCentre = "UNKNOWN";
            }
            return exData;
        }
    }
}
