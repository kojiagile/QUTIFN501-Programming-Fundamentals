using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    /// <summary>
    /// ProductData class.
    /// </summary>
    public class ProductData
    {
        /// <summary>
        /// Product name.
        /// </summary>
        private string productName;
        
        /// <summary>
        /// Retail Price.
        /// </summary>
        private double retailPrice;

        /// <summary>
        /// Get/Set product name
        /// </summary>
        [System.Xml.Serialization.XmlElement("Name")]
        public string ProductName
        {
            set { this.productName = value; }
            get { return this.productName; }
        }

        /// <summary>
        /// Get/Set retail price 
        /// </summary>
        [System.Xml.Serialization.XmlElement("Price")]
        public double RetailPrice
        {
            set { this.retailPrice = value; }
            get { return this.retailPrice; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="productName"></param>
        /// <param name="retailPrice"></param>
        public ProductData(string productName, double retailPrice)
        {
            this.productName = productName;
            this.retailPrice = retailPrice;
        }

        /// <summary>
        /// Constructor.
        /// This is for exporting .xml file. (XmlSerializer needs non-argument constructor.)
        /// </summary>
        public ProductData()
        {
        }
    }
}
