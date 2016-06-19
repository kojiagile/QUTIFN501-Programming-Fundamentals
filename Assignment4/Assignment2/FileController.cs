using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Assignment2
{
    /// <summary>
    /// FileController class
    /// </summary>
    public class FileController
    {
        /// <summary>
        /// Export catalogues to a file.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="catalogueList"></param>
        public bool ExportCatalogues(string fileName, List<ProductCatalogue> catalogueList)
        {
            bool ret = false;
            try
            {
                //Create stream to output a .xml file
                FileStream stream = new FileStream(fileName, FileMode.Create);
                StreamWriter writer = new StreamWriter(stream, Encoding.UTF8);
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add(string.Empty, string.Empty);

                //Xml serializer
                XmlSerializer serializer = new XmlSerializer(typeof(ProductCatalogueList));
                //Copy the catalogue list to output
                ProductCatalogueList cataList = new ProductCatalogueList();
                cataList.CatalogueList = new List<ProductCatalogue>();
                cataList.CatalogueList.AddRange(catalogueList);

                serializer.Serialize(stream, cataList);
                stream.Flush();
                stream.Close();
                stream = null;
                ret = true;
            }
            catch (IOException ioe)
            {
                MessageBox.Show(AppResources.EXP_MSG_IO_EXP, AppResources.MSG_CAP_ERROR,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception e)
            {
                MessageBox.Show(AppResources.EXP_MSG_EXP, AppResources.MSG_CAP_ERROR,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return ret;
        }

        /// <summary>
        /// Import catalogues from a file.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public ProductCatalogueList ImportCatalogues(string fileName)
        {
            try
            {
                //Read .xml file into the stream
                FileStream stream = new FileStream(fileName, FileMode.Open);
                XmlSerializer serializer = new XmlSerializer(typeof(ProductCatalogueList));
                ProductCatalogueList cataList = (ProductCatalogueList)serializer.Deserialize(stream);
                stream.Close();
                stream = null;
                return cataList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
