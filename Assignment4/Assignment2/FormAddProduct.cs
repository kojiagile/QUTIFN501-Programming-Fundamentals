using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment2
{
    public partial class FormAddProduct : Form
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
        public FormAddProduct()
        {
            InitializeComponent();
        }

        /// <summary>
        /// BtnOK_Click event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (!this.IsValidInputDataForAddingProduct())
            {
                MessageBox.Show(AppResources.MSG_FILL_OUT_FORM, AppResources.MSG_CAP_ERROR,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.productName = TboxProductName.Text;
            this.retailPrice = double.Parse(TboxRetailPrice.Text);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// BtnCancel_Click event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// Check if new product data is valid to add.
        /// </summary>
        /// <returns></returns>
        private bool IsValidInputDataForAddingProduct()
        {
            if (string.IsNullOrEmpty(TboxProductName.Text))
            {
                return false;
            }
            double ret = 0;
            if (string.IsNullOrEmpty(TboxRetailPrice.Text) || !double.TryParse(TboxRetailPrice.Text, out ret))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// TboxRetailPrice_KeyPress event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TboxRetailPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!InputHelper.IsNumericWithDotAndEraseKey(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
