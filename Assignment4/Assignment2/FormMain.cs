using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Assignment2
{
    /// <summary>
    /// FormMain class.
    /// </summary>
    public partial class FormMain : Form
    {
        /// <summary>
        /// Catalogue list.
        /// </summary>
        private List<ProductCatalogue> catalogueList = new List<ProductCatalogue>();
        

        /// <summary>
        /// Product grid view.
        /// </summary>
        private DataGridDblBuffView DgProductGrid = new DataGridDblBuffView();

        /// <summary>
        /// Constructor.
        /// </summary>
        public FormMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// FormMain load event handler.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event args</param>
        private void FormMain_Load(object sender, EventArgs e)
        {
            this.InitializeGrid();
            //this.InitializeCategoryCombo();
            this.InitializeCatalogueListBox();
        }

        /// <summary>
        /// Create catalogue button click event handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCreateCatalogue_Click(object sender, EventArgs e)
        {
            FormCreateCatalogue frmCata = new FormCreateCatalogue();
            if (frmCata.ShowDialog() != DialogResult.OK)
            {
                //if user cancels
                return;
            }

            //create new catalogue
            ProductCatalogue newCata = new ProductCatalogue(frmCata.CatalogueName, frmCata.Category);
            catalogueList.Add(newCata);
            // sort the catalogue list after added
            catalogueList.Sort(delegate(ProductCatalogue cata1, ProductCatalogue cata2)
                {
                    //compare with the names
                    return cata1.CatalogueName.CompareTo(cata2.CatalogueName);
                });

            this.InitializeCatalogueListBox();

            //Find the index to get newly added item selected in the list box.
            int index = catalogueList.FindIndex(delegate(ProductCatalogue cata)
                {
                    //Since multiple catalogues that have the same names can be added,
                    //Equals() method needs to be used to find newly added object.
                    return cata.Equals(newCata);
                });   
        }

        /// <summary>
        /// Product grid view data error event handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgProductGrid_DataError(object sender, DataGridViewCellCancelEventArgs e)
        {
            double ret = 0;
            if (DgProductGrid.Columns[e.ColumnIndex].Name == AppResources.NAME_GRID_HEADER_NAME_RET_PRICE)
            {
                //The data might be impossible to convert into double (e.g. "0..3")
                if (DgProductGrid[e.ColumnIndex, e.RowIndex].EditedFormattedValue == null
                    || !double.TryParse(DgProductGrid[e.ColumnIndex, e.RowIndex].EditedFormattedValue.ToString(), out ret))
                {
                    MessageBox.Show(AppResources.MSG_FILL_OUT_FORM, AppResources.MSG_CAP_ERROR,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
            }
        }

        /// <summary>
        /// Remove catalogue button click event handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRemoveCatalogue_Click(object sender, EventArgs e)
        {
            //catalogue existance check
            if (!this.ExistCatalogue())
            {
                MessageBox.Show(AppResources.MSG_NO_CATALOGUES, AppResources.MSG_CAP_ERROR,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (LboxCatalogList.SelectedIndex < 0)
            {
                MessageBox.Show(AppResources.MSG_CATE_SELECTED_TO_DELETE, AppResources.MSG_CAP_ERROR,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //ProductCatalogue cata = catalogueList[LboxCatalogList.SelectedIndex];
            ProductCatalogue cata = this.GetSelectedCatalogue();

            //confirmation message
            if (MessageBox.Show(AppResources.MSG_ASK_DELETE_CATA, AppResources.MSG_CAP_CONF,
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
            {
                //if user cancels.
                return;
            }

            //remove the catalogue and clear the data grid
            catalogueList.RemoveAt(LboxCatalogList.SelectedIndex);
            this.InitializeCatalogueListBox();

            if (LboxCatalogList.Items.Count != 0)
            {
                LboxCatalogList.SelectedIndex = 0;
            }
        }


        /// <summary>
        /// BindingSource DataSourceChanged event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BsGridSource_DataSourceChanged(object sender, EventArgs e)
        {
            this.BsGridSource.ResetBindings(false);
        }

        /// <summary>
        /// Product list grid view CellValidating event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgProductGrid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.FormattedValue == null || string.IsNullOrEmpty(e.FormattedValue.ToString()))
            {
                MessageBox.Show(AppResources.MSG_CANNOT_BE_EMPTY, AppResources.MSG_CAP_ERROR,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Catalogue list box SelectedValueChanged event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LboxCatalogList_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.LboxCatalogList.SelectedIndex < 0)
            {
                return;
            }
            //ProductCatalogue cata = catalogueList[LboxCatalogList.SelectedIndex];
            ProductCatalogue cata = this.GetSelectedCatalogue();

            //sort product by selected sort type and order
            cata.Sort(this.GetSortType(), this.GetSortOrder());

            //Show all products in the data grid
            // When datasource is changed, the (BindingSource) event will be occured, 
            // then the event shows all products in the catalogue.
            this.BsGridSource.DataSource = cata.ProductList;

            //show catalogue name and median price
            this.TboxCategory.Text = cata.Category.ToString();
            this.TboxCatalogueName.Text = cata.CatalogueName;
            this.ShowMedianPrice(cata);
        }

        /// <summary>
        /// Product grid view Editing control showing event handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgProductGrid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewTextBoxEditingControl)
            {
                DataGridView dg = (DataGridView)sender;

                //get control from the event args
                DataGridViewTextBoxEditingControl tb = (DataGridViewTextBoxEditingControl)e.Control;
                //delete event handler
                tb.KeyPress -= new KeyPressEventHandler(DgProductGrid_KeyPress);

                //only when specific column is currently editing
                if (dg.CurrentCell.OwningColumn.Name == AppResources.NAME_GRID_HEADER_NAME_RET_PRICE)
                {
                    tb.KeyPress += new KeyPressEventHandler(DgProductGrid_KeyPress);
                }
            }
        }

        /// <summary>
        /// Product grid view key press event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgProductGrid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!InputHelper.IsNumericWithDotAndEraseKey(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Add product button click event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddProduct_Click(object sender, EventArgs e)
        {
            if (!this.ExistCatalogue())
            {
                MessageBox.Show(AppResources.MSG_NO_CATALOGUES, AppResources.MSG_CAP_ERROR, 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (LboxCatalogList.SelectedIndex < 0)
            {
                MessageBox.Show(AppResources.MSG_SELECT_CATALOGUE, AppResources.MSG_CAP_ERROR,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FormAddProduct frmAdd = new FormAddProduct();
            if (frmAdd.ShowDialog() != DialogResult.OK)
            {
                //if user cancels
                return;
            }

            ProductCatalogue cata = this.GetSelectedCatalogue();
            ProductData data = new ProductData(frmAdd.ProductName, frmAdd.RetailPrice);
            cata.InsertProduct(data);
            //sort product by selected sort type and order
            cata.Sort(this.GetSortType(), this.GetSortOrder());
            this.BsGridSource_DataSourceChanged(null, null);
            this.ShowMedianPrice(cata);
            //this.ClearNewProductInputPanel();
        }

        /// <summary>
        /// Retail price text box key press event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TboxRetailPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!InputHelper.IsNumericWithDotAndEraseKey(e.KeyChar))
            {
                //if the key typed is not number, period, back space or delete key, the event will be cancelled.
                e.Handled = true;
            }
        }

        /// <summary>
        /// Product grid view UserDeleteRow event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgProductGrid_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            //re-calculate median price
            this.ShowMedianPrice(this.GetSelectedCatalogue());
        }

        /// <summary>
        /// Product grid view UserDeletingRow event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgProductGrid_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show(AppResources.MSG_ASK_DELETE_PRD, AppResources.MSG_CAP_CONF,
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
            {
                e.Cancel = true;
                return;
            }
        }

        /// <summary>
        /// importToolStripMenuItem click event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OfdOpenCata.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }

            try
            {
                FileController fc = new FileController();
                ProductCatalogueList cataList = fc.ImportCatalogues(OfdOpenCata.FileName);

                //Import xml data into ProductCatalogue list object.
                this.catalogueList.Clear();
                this.catalogueList.AddRange(cataList.CatalogueList);
                this.InitializeCatalogueListBox();
                this.LboxCatalogList.SelectedIndex = 0;

                //confirmation message
                MessageBox.Show(AppResources.MSG_INFO_FILE_IMPORTED, AppResources.MSG_CAP_INFO,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (IOException ioe)
            {
                MessageBox.Show(AppResources.EXP_MSG_IO_EXP, AppResources.MSG_CAP_ERROR,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exp)
            {
                MessageBox.Show(AppResources.EXP_MSG_EXP, AppResources.MSG_CAP_ERROR,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// exportToolStripMenuItem_Click click event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.ExistCatalogue())
            {
                MessageBox.Show(AppResources.MSG_NO_CATALOGUES, AppResources.MSG_CAP_ERROR,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (SfdSaveCata.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
            FileController fc = new FileController();
            bool ret = fc.ExportCatalogues(SfdSaveCata.FileName, this.catalogueList);

            if (ret)
            {
                //confirmation message
                MessageBox.Show(AppResources.MSG_INFO_FILE_EXPORTED, AppResources.MSG_CAP_INFO,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Sort_CheckedChanged event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Sort_CheckedChanged(object sender, EventArgs e)
        {
            ProductCatalogue cata = GetSelectedCatalogue();
            if (cata == null)
            {
                return;
            }
            cata.Sort(this.GetSortType(), this.GetSortOrder());
            //To show sorted result, call the event.
            this.BsGridSource_DataSourceChanged(null, null);
        }

        /// <summary>
        /// Initialize catalogue list box.
        /// </summary>
        private void InitializeCatalogueListBox()
        {
            LboxCatalogList.DataSource = null;
            LboxCatalogList.DisplayMember = AppResources.DISP_MEMBER_CATA_LIST_BOX;
            LboxCatalogList.DataSource = catalogueList;
            LboxCatalogList.Refresh();
        }

        /// <summary>
        /// Initialize Product grid view.
        /// </summary>
        private void InitializeGrid()
        {
            //Grid view initializetion 
            DgProductGrid.AllowUserToAddRows = false;
            DgProductGrid.AllowUserToDeleteRows = true;
            DgProductGrid.AllowUserToResizeRows = false;
            DgProductGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgProductGrid.AutoGenerateColumns = false;
            DgProductGrid.ImeMode = ImeMode.NoControl;
            DgProductGrid.Dock = DockStyle.Fill;
            DgProductGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgProductGrid.EditingControlShowing += this.DgProductGrid_EditingControlShowing;
            DgProductGrid.CellValidating += this.DgProductGrid_CellValidating;
            DgProductGrid.DataError += this.DgProductGrid_DataError;

            DgProductGrid.TabStop = true;
            DgProductGrid.TabIndex = 8;
            //event handler settings
            DgProductGrid.UserDeletingRow += this.DgProductGrid_UserDeletingRow;
            DgProductGrid.UserDeletedRow += this.DgProductGrid_UserDeletedRow;
            //Set it in the panel
            PnlProductList.Controls.Add(DgProductGrid);

            //Product name
            DataGridViewTextBoxColumn tbGridPrdName = new DataGridViewTextBoxColumn();
            tbGridPrdName.HeaderText = AppResources.NAME_GRID_HEADER_TEXT_PRD_NAME;
            tbGridPrdName.Name = AppResources.NAME_GRID_HEADER_NAME_PRD_NAME;
            tbGridPrdName.DataPropertyName = AppResources.NAME_GRID_HEADER_NAME_PRD_NAME;
            tbGridPrdName.SortMode = DataGridViewColumnSortMode.NotSortable;

            //Retail Price
            DataGridViewTextBoxColumn tbGridRetailPrice = new DataGridViewTextBoxColumn();
            tbGridRetailPrice.HeaderText = AppResources.NAME_GRID_HEADER_TEXT_RET_PRICE;
            tbGridRetailPrice.Name = AppResources.NAME_GRID_HEADER_NAME_RET_PRICE;
            tbGridRetailPrice.DataPropertyName = AppResources.NAME_GRID_HEADER_NAME_RET_PRICE;
            tbGridRetailPrice.SortMode = DataGridViewColumnSortMode.NotSortable;

            //DgProductGrid.Columns.Add(cbGridCategory);
            //DgProductGrid.Columns.Add(tbGridCategory);
            DgProductGrid.Columns.Add(tbGridPrdName);
            DgProductGrid.Columns.Add(tbGridRetailPrice);
            //Set bindingSource into datasource field of the data grid
            DgProductGrid.DataSource = this.BsGridSource;
        }


        /// <summary>
        /// Create category combo box data source.
        /// </summary>
        /// <returns></returns>
        private DataTable CreateCategoryComboDataSource()
        {
            DataTable dt = new DataTable(AppResources.NAME_DT_CATE_COMBO_DATA_SRC);
            dt.Columns.Add(AppResources.DISP_MEMBER_CATE_COMBO, typeof(string));
            dt.Columns.Add(AppResources.VAL_MEMBER_CATE_COMBO, typeof(string));

            dt.Rows.Add(Categories.Apparel, Categories.Apparel);
            dt.Rows.Add(Categories.Beverage, Categories.Beverage);
            dt.Rows.Add(Categories.Books, Categories.Books);
            dt.Rows.Add(Categories.Car, Categories.Car);
            dt.Rows.Add(Categories.Cosmetic, Categories.Cosmetic);
            dt.Rows.Add(Categories.Electronics, Categories.Electronics);
            dt.Rows.Add(Categories.Food, Categories.Food);
            dt.Rows.Add(Categories.Furniture, Categories.Furniture);
            dt.Rows.Add(Categories.Game, Categories.Game);

            return dt;
        }


        /// <summary>
        /// Show median price on the window.
        /// </summary>
        /// <param name="cata"></param>
        private void ShowMedianPrice(ProductCatalogue cata)
        {
            if (cata == null)
            {
                return;
            }
            string medPerCata = cata.GetMedianPrice().ToString();
            string medAcrossCata = this.GetMedianPriceAcrossCatalogues().ToString();
            TboxCatalogueMedian.Text = medPerCata;
            TboxAllMedian.Text = medAcrossCata;

        }

        /// <summary>
        /// Get median price across all catalogues.
        /// </summary>
        /// <returns></returns>
        private double GetMedianPriceAcrossCatalogues()
        {
            if (catalogueList == null || catalogueList.Count == 0)
            {
                return 0;
            }

            ProductCatalogue cataAll = new ProductCatalogue(AppResources.NAME_CALC_MEDIAN_CATA_LIST_NAME, Categories.Unknown);
            foreach (ProductCatalogue cata in catalogueList)
            {
                cataAll.ProductList.AddRange(cata.ProductList);
            }
            return cataAll.GetMedianPrice();
        }

        /// <summary>
        /// Add product to product grid view.
        /// </summary>
        /// <param name="data"></param>
        private void AddProductToGrid(ProductData data)
        {
            if (data == null)
            {
                return;
            }
            
            DgProductGrid.Rows.Add(data.ProductName, data.RetailPrice);
            DgProductGrid.Refresh();
        }


        /// <summary>
        /// Check if any catalogues exist.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private bool ExistCatalogue()
        {
            if (LboxCatalogList.Items.Count == 0)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Get selected catalogue.
        /// </summary>
        /// <returns></returns>
        private ProductCatalogue GetSelectedCatalogue()
        {
            if (LboxCatalogList.SelectedIndex < 0)
            {
                return null;
            }
            return this.catalogueList[LboxCatalogList.SelectedIndex];
        }

        /// <summary>
        /// Get sort type
        /// </summary>
        /// <returns></returns>
        private SortType GetSortType()
        {
            return RbtnSortPrdName.Checked ? SortType.ProductName : SortType.RetailPrice;
        }

        /// <summary>
        /// Get sort order
        /// </summary>
        /// <returns></returns>
        private SortOrder GetSortOrder()
        {
            return RbtnAsc.Checked ? SortOrder.Ascending : SortOrder.Descending;
        }

    }
}
