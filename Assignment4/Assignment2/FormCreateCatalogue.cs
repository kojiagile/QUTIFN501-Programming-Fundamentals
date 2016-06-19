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
    public partial class FormCreateCatalogue : Form
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
        /// Get/Set catalogue name
        /// </summary>
        public string CatalogueName
        {
            set { this.catalogueName = value; }
            get { return this.catalogueName; }
        }

        /// <summary>
        /// Get/Set category
        /// </summary>
        public Categories Category
        {
            get { return this.category; }
            set { this.category = value; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public FormCreateCatalogue()
        {
            InitializeComponent();
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
        /// BtnOK_Click event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOK_Click(object sender, EventArgs e)
        {
            this.catalogueName = TboxName.Text;
            this.category = (Categories)Enum.Parse(typeof(Categories), CboxCategory.SelectedValue.ToString());
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        /// <summary>
        /// TboxName_KeyPress event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TboxName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (string.IsNullOrEmpty(TboxName.Text))
            {
                BtnOK.Enabled = false;
            }
            else
            {
                BtnOK.Enabled = true;
                if (e.KeyChar == '\r')
                {
                    this.BtnOK_Click(sender, e);
                }
            }
        }

        /// <summary>
        /// FormCreateCatalogue_Load event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCreateCatalogue_Load(object sender, EventArgs e)
        {
            BtnOK.Enabled = false;
            AppResources.InitializeCategoryCombo(this.CboxCategory);
        }
    }
}
