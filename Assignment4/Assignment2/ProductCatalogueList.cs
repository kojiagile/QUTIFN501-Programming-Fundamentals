using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    /// <summary>
    /// ProductCatalogueList class.
    /// </summary>
    [System.Xml.Serialization.XmlRoot("Root")]
    public class ProductCatalogueList
    {
        /// <summary>
        /// Catalogue list.
        /// </summary>
        private List<ProductCatalogue> catalogueList;

        /// <summary>
        /// Get/Set catalogue list.
        /// </summary>
        [System.Xml.Serialization.XmlElement("Catalogue")]
        public List<ProductCatalogue> CatalogueList
        {
            get { return this.catalogueList; }
            set { this.catalogueList = value; }
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="cataList"></param>
        public ProductCatalogueList(List<ProductCatalogue> cataList)
        {
            this.catalogueList = cataList;
        }

        /// <summary>
        /// Constructor.
        /// This is for exporting .xml file. (XmlSerializer needs non-argument constructor.)
        /// </summary>
        public ProductCatalogueList()
        {
        }

    }
}
