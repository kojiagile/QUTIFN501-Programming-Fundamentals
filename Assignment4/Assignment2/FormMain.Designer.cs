namespace Assignment2
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.LblAllMedian = new System.Windows.Forms.Label();
            this.BtnRemoveCatalogue = new System.Windows.Forms.Button();
            this.BtnCreateCatalogue = new System.Windows.Forms.Button();
            this.TboxAllMedian = new System.Windows.Forms.TextBox();
            this.PnlProductList = new System.Windows.Forms.Panel();
            this.LblCatalogueList = new System.Windows.Forms.Label();
            this.LboxCatalogList = new System.Windows.Forms.ListBox();
            this.BtnAddProduct = new System.Windows.Forms.Button();
            this.MnsMenu = new System.Windows.Forms.MenuStrip();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SfdSaveCata = new System.Windows.Forms.SaveFileDialog();
            this.OfdOpenCata = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.RbtnSortPrdName = new System.Windows.Forms.RadioButton();
            this.RbtnSortPrice = new System.Windows.Forms.RadioButton();
            this.LblSort = new System.Windows.Forms.Label();
            this.PnlSort = new System.Windows.Forms.Panel();
            this.PnlSortOrder = new System.Windows.Forms.Panel();
            this.RbtnDesc = new System.Windows.Forms.RadioButton();
            this.LblOrder = new System.Windows.Forms.Label();
            this.RbtnAsc = new System.Windows.Forms.RadioButton();
            this.BsGridSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.TboxCategory = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TboxCatalogueName = new System.Windows.Forms.TextBox();
            this.TboxCatalogueMedian = new System.Windows.Forms.TextBox();
            this.LblCatalogueMedian = new System.Windows.Forms.Label();
            this.MnsMenu.SuspendLayout();
            this.PnlSort.SuspendLayout();
            this.PnlSortOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BsGridSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblAllMedian
            // 
            this.LblAllMedian.AutoSize = true;
            this.LblAllMedian.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.LblAllMedian.ForeColor = System.Drawing.Color.DarkBlue;
            this.LblAllMedian.Location = new System.Drawing.Point(392, 40);
            this.LblAllMedian.Name = "LblAllMedian";
            this.LblAllMedian.Size = new System.Drawing.Size(77, 16);
            this.LblAllMedian.TabIndex = 8;
            this.LblAllMedian.Text = "Median all:";
            // 
            // BtnRemoveCatalogue
            // 
            this.BtnRemoveCatalogue.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            this.BtnRemoveCatalogue.ForeColor = System.Drawing.Color.Black;
            this.BtnRemoveCatalogue.Location = new System.Drawing.Point(317, 113);
            this.BtnRemoveCatalogue.Name = "BtnRemoveCatalogue";
            this.BtnRemoveCatalogue.Size = new System.Drawing.Size(102, 23);
            this.BtnRemoveCatalogue.TabIndex = 3;
            this.BtnRemoveCatalogue.Text = "Delete";
            this.BtnRemoveCatalogue.UseVisualStyleBackColor = true;
            this.BtnRemoveCatalogue.Click += new System.EventHandler(this.BtnRemoveCatalogue_Click);
            // 
            // BtnCreateCatalogue
            // 
            this.BtnCreateCatalogue.Location = new System.Drawing.Point(100, 42);
            this.BtnCreateCatalogue.Name = "BtnCreateCatalogue";
            this.BtnCreateCatalogue.Size = new System.Drawing.Size(102, 23);
            this.BtnCreateCatalogue.TabIndex = 1;
            this.BtnCreateCatalogue.Text = "Create";
            this.BtnCreateCatalogue.UseVisualStyleBackColor = true;
            this.BtnCreateCatalogue.Click += new System.EventHandler(this.BtnCreateCatalogue_Click);
            // 
            // TboxAllMedian
            // 
            this.TboxAllMedian.Location = new System.Drawing.Point(472, 41);
            this.TboxAllMedian.Name = "TboxAllMedian";
            this.TboxAllMedian.ReadOnly = true;
            this.TboxAllMedian.Size = new System.Drawing.Size(158, 19);
            this.TboxAllMedian.TabIndex = 14;
            this.TboxAllMedian.TabStop = false;
            // 
            // PnlProductList
            // 
            this.PnlProductList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PnlProductList.Location = new System.Drawing.Point(15, 249);
            this.PnlProductList.Name = "PnlProductList";
            this.PnlProductList.Size = new System.Drawing.Size(624, 272);
            this.PnlProductList.TabIndex = 16;
            // 
            // LblCatalogueList
            // 
            this.LblCatalogueList.AutoSize = true;
            this.LblCatalogueList.Location = new System.Drawing.Point(13, 47);
            this.LblCatalogueList.Name = "LblCatalogueList";
            this.LblCatalogueList.Size = new System.Drawing.Size(81, 12);
            this.LblCatalogueList.TabIndex = 14;
            this.LblCatalogueList.Text = "Catalogue List:";
            // 
            // LboxCatalogList
            // 
            this.LboxCatalogList.ColumnWidth = 100;
            this.LboxCatalogList.FormattingEnabled = true;
            this.LboxCatalogList.ItemHeight = 12;
            this.LboxCatalogList.Location = new System.Drawing.Point(15, 71);
            this.LboxCatalogList.Name = "LboxCatalogList";
            this.LboxCatalogList.Size = new System.Drawing.Size(187, 148);
            this.LboxCatalogList.TabIndex = 2;
            this.LboxCatalogList.SelectedValueChanged += new System.EventHandler(this.LboxCatalogList_SelectedValueChanged);
            // 
            // BtnAddProduct
            // 
            this.BtnAddProduct.Location = new System.Drawing.Point(232, 218);
            this.BtnAddProduct.Name = "BtnAddProduct";
            this.BtnAddProduct.Size = new System.Drawing.Size(102, 23);
            this.BtnAddProduct.TabIndex = 7;
            this.BtnAddProduct.Text = "Add Product";
            this.BtnAddProduct.UseVisualStyleBackColor = true;
            this.BtnAddProduct.Click += new System.EventHandler(this.BtnAddProduct_Click);
            // 
            // MnsMenu
            // 
            this.MnsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem});
            this.MnsMenu.Location = new System.Drawing.Point(0, 0);
            this.MnsMenu.Name = "MnsMenu";
            this.MnsMenu.Size = new System.Drawing.Size(650, 26);
            this.MnsMenu.TabIndex = 29;
            this.MnsMenu.Text = "menuStrip1";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(61, 22);
            this.importToolStripMenuItem.Text = "Import";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.ImportToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(58, 22);
            this.exportToolStripMenuItem.Text = "Export";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.ExportToolStripMenuItem_Click);
            // 
            // SfdSaveCata
            // 
            this.SfdSaveCata.FileName = "catalogue.xml";
            this.SfdSaveCata.Filter = "xml files|*.xml";
            // 
            // OfdOpenCata
            // 
            this.OfdOpenCata.DefaultExt = "xml";
            this.OfdOpenCata.Filter = "xml files|*.xml";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 529);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(481, 12);
            this.label1.TabIndex = 30;
            this.label1.Text = "How to delete a product: Click a product that you would like to delete, then pres" +
    "s delete key.";
            // 
            // RbtnSortPrdName
            // 
            this.RbtnSortPrdName.AutoSize = true;
            this.RbtnSortPrdName.Checked = true;
            this.RbtnSortPrdName.Location = new System.Drawing.Point(37, 1);
            this.RbtnSortPrdName.Name = "RbtnSortPrdName";
            this.RbtnSortPrdName.Size = new System.Drawing.Size(52, 16);
            this.RbtnSortPrdName.TabIndex = 9;
            this.RbtnSortPrdName.TabStop = true;
            this.RbtnSortPrdName.Text = "Name";
            this.RbtnSortPrdName.UseVisualStyleBackColor = true;
            this.RbtnSortPrdName.CheckedChanged += new System.EventHandler(this.Sort_CheckedChanged);
            // 
            // RbtnSortPrice
            // 
            this.RbtnSortPrice.AutoSize = true;
            this.RbtnSortPrice.Location = new System.Drawing.Point(89, 1);
            this.RbtnSortPrice.Name = "RbtnSortPrice";
            this.RbtnSortPrice.Size = new System.Drawing.Size(49, 16);
            this.RbtnSortPrice.TabIndex = 10;
            this.RbtnSortPrice.Text = "Price";
            this.RbtnSortPrice.UseVisualStyleBackColor = true;
            // 
            // LblSort
            // 
            this.LblSort.AutoSize = true;
            this.LblSort.Location = new System.Drawing.Point(3, 3);
            this.LblSort.Name = "LblSort";
            this.LblSort.Size = new System.Drawing.Size(28, 12);
            this.LblSort.TabIndex = 33;
            this.LblSort.Text = "Sort:";
            // 
            // PnlSort
            // 
            this.PnlSort.Controls.Add(this.RbtnSortPrice);
            this.PnlSort.Controls.Add(this.LblSort);
            this.PnlSort.Controls.Add(this.RbtnSortPrdName);
            this.PnlSort.Location = new System.Drawing.Point(345, 220);
            this.PnlSort.Name = "PnlSort";
            this.PnlSort.Size = new System.Drawing.Size(144, 19);
            this.PnlSort.TabIndex = 34;
            // 
            // PnlSortOrder
            // 
            this.PnlSortOrder.Controls.Add(this.RbtnDesc);
            this.PnlSortOrder.Controls.Add(this.LblOrder);
            this.PnlSortOrder.Controls.Add(this.RbtnAsc);
            this.PnlSortOrder.Location = new System.Drawing.Point(495, 220);
            this.PnlSortOrder.Name = "PnlSortOrder";
            this.PnlSortOrder.Size = new System.Drawing.Size(144, 19);
            this.PnlSortOrder.TabIndex = 35;
            // 
            // RbtnDesc
            // 
            this.RbtnDesc.AutoSize = true;
            this.RbtnDesc.Location = new System.Drawing.Point(89, 1);
            this.RbtnDesc.Name = "RbtnDesc";
            this.RbtnDesc.Size = new System.Drawing.Size(49, 16);
            this.RbtnDesc.TabIndex = 10;
            this.RbtnDesc.Text = "Desc";
            this.RbtnDesc.UseVisualStyleBackColor = true;
            // 
            // LblOrder
            // 
            this.LblOrder.AutoSize = true;
            this.LblOrder.Location = new System.Drawing.Point(3, 3);
            this.LblOrder.Name = "LblOrder";
            this.LblOrder.Size = new System.Drawing.Size(35, 12);
            this.LblOrder.TabIndex = 33;
            this.LblOrder.Text = "Order:";
            // 
            // RbtnAsc
            // 
            this.RbtnAsc.AutoSize = true;
            this.RbtnAsc.Checked = true;
            this.RbtnAsc.Location = new System.Drawing.Point(40, 1);
            this.RbtnAsc.Name = "RbtnAsc";
            this.RbtnAsc.Size = new System.Drawing.Size(43, 16);
            this.RbtnAsc.TabIndex = 9;
            this.RbtnAsc.TabStop = true;
            this.RbtnAsc.Text = "Asc";
            this.RbtnAsc.UseVisualStyleBackColor = true;
            this.RbtnAsc.CheckedChanged += new System.EventHandler(this.Sort_CheckedChanged);
            // 
            // BsGridSource
            // 
            this.BsGridSource.DataSourceChanged += new System.EventHandler(this.BsGridSource_DataSourceChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblCategory);
            this.groupBox1.Controls.Add(this.TboxCategory);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.TboxCatalogueName);
            this.groupBox1.Controls.Add(this.TboxCatalogueMedian);
            this.groupBox1.Controls.Add(this.BtnRemoveCatalogue);
            this.groupBox1.Controls.Add(this.LblCatalogueMedian);
            this.groupBox1.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.groupBox1.ForeColor = System.Drawing.Color.DarkBlue;
            this.groupBox1.Location = new System.Drawing.Point(211, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(428, 143);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selected Catalogue:";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            this.lblCategory.ForeColor = System.Drawing.Color.Black;
            this.lblCategory.Location = new System.Drawing.Point(29, 30);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(53, 12);
            this.lblCategory.TabIndex = 27;
            this.lblCategory.Text = "Category:";
            // 
            // TboxCategory
            // 
            this.TboxCategory.Location = new System.Drawing.Point(88, 27);
            this.TboxCategory.Name = "TboxCategory";
            this.TboxCategory.ReadOnly = true;
            this.TboxCategory.Size = new System.Drawing.Size(331, 23);
            this.TboxCategory.TabIndex = 26;
            this.TboxCategory.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(46, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 12);
            this.label4.TabIndex = 25;
            this.label4.Text = "Name:";
            // 
            // TboxCatalogueName
            // 
            this.TboxCatalogueName.Location = new System.Drawing.Point(88, 55);
            this.TboxCatalogueName.Name = "TboxCatalogueName";
            this.TboxCatalogueName.ReadOnly = true;
            this.TboxCatalogueName.Size = new System.Drawing.Size(331, 23);
            this.TboxCatalogueName.TabIndex = 24;
            this.TboxCatalogueName.TabStop = false;
            // 
            // TboxCatalogueMedian
            // 
            this.TboxCatalogueMedian.Location = new System.Drawing.Point(88, 84);
            this.TboxCatalogueMedian.Name = "TboxCatalogueMedian";
            this.TboxCatalogueMedian.ReadOnly = true;
            this.TboxCatalogueMedian.Size = new System.Drawing.Size(331, 23);
            this.TboxCatalogueMedian.TabIndex = 23;
            this.TboxCatalogueMedian.TabStop = false;
            // 
            // LblCatalogueMedian
            // 
            this.LblCatalogueMedian.AutoSize = true;
            this.LblCatalogueMedian.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            this.LblCatalogueMedian.ForeColor = System.Drawing.Color.Black;
            this.LblCatalogueMedian.Location = new System.Drawing.Point(9, 87);
            this.LblCatalogueMedian.Name = "LblCatalogueMedian";
            this.LblCatalogueMedian.Size = new System.Drawing.Size(73, 12);
            this.LblCatalogueMedian.TabIndex = 22;
            this.LblCatalogueMedian.Text = "Median Price:";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 552);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BtnAddProduct);
            this.Controls.Add(this.TboxAllMedian);
            this.Controls.Add(this.LblAllMedian);
            this.Controls.Add(this.PnlSortOrder);
            this.Controls.Add(this.PnlSort);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LboxCatalogList);
            this.Controls.Add(this.LblCatalogueList);
            this.Controls.Add(this.BtnCreateCatalogue);
            this.Controls.Add(this.PnlProductList);
            this.Controls.Add(this.MnsMenu);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Inventory";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.MnsMenu.ResumeLayout(false);
            this.MnsMenu.PerformLayout();
            this.PnlSort.ResumeLayout(false);
            this.PnlSort.PerformLayout();
            this.PnlSortOrder.ResumeLayout(false);
            this.PnlSortOrder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BsGridSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblAllMedian;
        private System.Windows.Forms.Button BtnCreateCatalogue;
        private System.Windows.Forms.Button BtnRemoveCatalogue;
        private System.Windows.Forms.TextBox TboxAllMedian;
        private System.Windows.Forms.Panel PnlProductList;
        private System.Windows.Forms.Label LblCatalogueList;
        private System.Windows.Forms.ListBox LboxCatalogList;
        private System.Windows.Forms.Button BtnAddProduct;
        private System.Windows.Forms.MenuStrip MnsMenu;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog SfdSaveCata;
        private System.Windows.Forms.OpenFileDialog OfdOpenCata;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton RbtnSortPrdName;
        private System.Windows.Forms.RadioButton RbtnSortPrice;
        private System.Windows.Forms.Label LblSort;
        private System.Windows.Forms.Panel PnlSort;
        private System.Windows.Forms.Panel PnlSortOrder;
        private System.Windows.Forms.RadioButton RbtnDesc;
        private System.Windows.Forms.Label LblOrder;
        private System.Windows.Forms.RadioButton RbtnAsc;
        private System.Windows.Forms.BindingSource BsGridSource;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.TextBox TboxCategory;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TboxCatalogueName;
        private System.Windows.Forms.TextBox TboxCatalogueMedian;
        private System.Windows.Forms.Label LblCatalogueMedian;

    }
}

