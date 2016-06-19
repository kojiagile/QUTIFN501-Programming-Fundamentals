using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment2
{
    /// <summary>
    /// ProductCatalogue class
    /// </summary>
    public class ProductCatalogue
    {
        /// <summary>
        /// Catalogue name.
        /// </summary>
        private string catalogueName;

        /// <summary>
        /// Category.
        /// </summary>
        private Categories category;

        /// <summary>
        /// List of products.
        /// </summary>
        private List<ProductData> productList = new List<ProductData>();

        /// <summary>
        /// Get/Set a catalogue name.
        /// </summary>
        [System.Xml.Serialization.XmlElement("Name")]
        public string CatalogueName
        {
            get { return this.catalogueName; }
            set { this.catalogueName = value; }
        }

        /// <summary>
        /// Get/Set a product list.
        /// </summary>
        [System.Xml.Serialization.XmlElement("Product")]
        public List<ProductData> ProductList
        {
            get
            {
                return this.productList;
            }
        }

        /// <summary>
        /// Get/Set category
        /// </summary>
        [System.Xml.Serialization.XmlAttribute("Category")]
        public Categories Category
        {
            get { return this.category; }
            set { this.category = value; }
        }

        /// <summary>
        /// Get the number of products added.
        /// </summary>
        public int NumberOfProducts
        {
            get
            {
                return this.productList.Count;
            }
        }


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="catalogueName">Catalogue name.</param>
        public ProductCatalogue(string catalogueName, Categories category)
        {
            this.catalogueName = catalogueName;
            this.category = category;
        }

        /// <summary>
        /// Constructor.
        /// This is for exporting .xml file. (XmlSerializer needs non-argument constructor.)
        /// </summary>
        public ProductCatalogue()
        {

        }

        /// <summary>
        /// Insert product to the product list.
        /// </summary>
        /// <param name="data"></param>
        public void InsertProduct(ProductData data)
        {
            //if (this.productList.Count >= MAX_NUM_PRODUCTS)
            //{
            //    Console.WriteLine("Insert failed. The catalogue is full.");
            //}
            this.productList.Add(data);
        }

        /// <summary>
        /// Get product by index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public ProductData GetProduct(int index)
        {
            if (index < 0)
            {
                return null;
            }
            return this.productList[index];
        }
        /// <summary>
        /// Get median price 
        /// </summary>
        /// <returns></returns>
        public double GetMedianPrice()
        {
            //The product list always needs to be sorted by price in asc order before the calculation
            
            if(this.NumberOfProducts == 0)
            {
                return 0;
            }
            else if (this.NumberOfProducts == 1)
            {
                return this.productList[0].RetailPrice;
            }

            //To calculate median price, create a copy of the list and sort by price in asc order before the calculation.
            ProductCatalogue cata = new ProductCatalogue(string.Empty, Categories.Unknown);
            List<ProductData> medianList = new List<ProductData>();
            medianList.AddRange(this.productList);
            cata.productList = medianList;
            cata.Sort(SortType.RetailPrice, SortOrder.Ascending);

            int middle = medianList.Count / 2;
            if (medianList.Count % 2 == 0)
            {
                //When the number of product is even.
                double median1 = medianList[middle - 1].RetailPrice;
                double median2 = medianList[middle].RetailPrice;
                return (median1 + median2) / 2;
            }
            else
            {
                return medianList[middle].RetailPrice;
            }
        }

        /// <summary>
        /// Sort the product list.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="order"></param>
        public void Sort(SortType type, SortOrder order)
        {
            if (this.productList.Count < 2)
            {
                return;
            }

            this.productList.Sort(delegate(ProductData data1, ProductData data2)
                {
                    ProductData temp;
                    //when the order is desc, swap the object.
                    if (order == SortOrder.Descending)
                    {
                        temp = data1;
                        data1 = data2;
                        data2 = temp;
                    }
                    return this.CompareTo(data1, data2, type);
                });
        }

        /// <summary>
        /// Compare product data.
        /// </summary>
        /// <param name="data1"></param>
        /// <param name="data2"></param>
        /// <param name="type"></param>
        /// <returns>Int that represent the order of the ProductData object.</returns>
        private int CompareTo(ProductData data1, ProductData data2, SortType type)
        {
            if (type == SortType.ProductName)
            {
                //sort by product name
                return data1.ProductName.CompareTo(data2.ProductName);
            }
            else if (type == SortType.RetailPrice)
            {
                //sort by retail price
                if (data1.RetailPrice < data2.RetailPrice)
                {
                    return -1;
                }
                else if (data1.RetailPrice == data2.RetailPrice)
                {
                    return 0;
                }
                //anything else above conditions
                return 1;
            }
            else
            {
                //if the type is unknown
                return data1.ProductName.CompareTo(data2.ProductName);
            }
        }

    }
}
