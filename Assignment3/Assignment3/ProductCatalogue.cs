using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentEx3
{
    class ProductCatalogue
    {
        /// <summary>
        /// Maximum number of products in catalog
        /// </summary>
        public const int MAX_NUM_PRODUCTS = 100;

        private string catalogueName;
        private ProductData[] products;
        private int numberOfProducts;

        public ProductCatalogue(string catalogueName)
        {
            this.catalogueName = catalogueName;
            this.numberOfProducts = 0;
            this.products = new ProductData[MAX_NUM_PRODUCTS];
        }

        public void PrintCatalogue()
        {
            Console.WriteLine("-------------- Catalogue: {0} --------------", this.catalogueName);
            for (int i = 0; i < numberOfProducts; i++)
            {
                Console.Write("\t");
                products[i].PrintProduct();
            }
            if (numberOfProducts == 0)
            {
                Console.Write("\t");
                Console.WriteLine("(No products exist)");
            }
            Console.WriteLine("----------------------------------------------");
        }

        public void InsertProduct(ProductData data)
        {
            if (numberOfProducts >= MAX_NUM_PRODUCTS)
            {
                Console.WriteLine("Insert failed. The catalogue is full.");
            }
            this.products[numberOfProducts] = data;
            this.numberOfProducts++;
        }

        public int NumberOfProducts
        {
            set { this.numberOfProducts = value; }
            get { return this.numberOfProducts; }
        }

        public string CatalogueName
        {
            set { this.catalogueName = value; }
            get { return this.catalogueName; }
        }

        public ProductData GetProduct(int index)
        {
            if (index < 0)
            {
                return null;
            }
            return this.products[index];
        }

        /// <summary>
        /// Get average price of the catalogue.
        /// </summary>
        /// <returns></returns>
        public double GetAvgPrice()
        {
            if (this.numberOfProducts == 0)
            {
                return 0;
            }
            return this.GetSumPrice() / this.numberOfProducts;
        }

        /// <summary>
        /// Get summary of retail price.
        /// </summary>
        /// <returns>Summary of retail price.</returns>
        public double GetSumPrice()
        {
            double ret = 0;
            for (int i = 0; i < this.numberOfProducts; i++)
            {
                ret += this.products[i].RetailPrice;
            }
            return ret;
        }
    }
}
