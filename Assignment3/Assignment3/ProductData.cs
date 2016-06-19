using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentEx3
{
    class ProductData
    {
        private string productName;
        private double retailPrice;

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

        public void PrintProduct()
        {
            Console.WriteLine("{0}: {1:c2}.", productName, retailPrice);
        }

        public string ProductName
        {
            set { this.ProductName = value; }
            get { return this.productName; }
        }

        public double RetailPrice
        {
            set { this.retailPrice = value; }
            get { return this.retailPrice; }
        }
    }
}
