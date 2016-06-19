namespace Assignment2
{
    partial class FormAddProduct
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
            this.TboxRetailPrice = new System.Windows.Forms.TextBox();
            this.LblProductName = new System.Windows.Forms.Label();
            this.LblRetailPrice = new System.Windows.Forms.Label();
            this.TboxProductName = new System.Windows.Forms.TextBox();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnOK = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TboxRetailPrice
            // 
            this.TboxRetailPrice.Location = new System.Drawing.Point(97, 60);
            this.TboxRetailPrice.Name = "TboxRetailPrice";
            this.TboxRetailPrice.Size = new System.Drawing.Size(186, 19);
            this.TboxRetailPrice.TabIndex = 2;
            this.TboxRetailPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TboxRetailPrice_KeyPress);
            // 
            // LblProductName
            // 
            this.LblProductName.AutoSize = true;
            this.LblProductName.Location = new System.Drawing.Point(12, 38);
            this.LblProductName.Name = "LblProductName";
            this.LblProductName.Size = new System.Drawing.Size(79, 12);
            this.LblProductName.TabIndex = 37;
            this.LblProductName.Text = "Product Name:";
            // 
            // LblRetailPrice
            // 
            this.LblRetailPrice.AutoSize = true;
            this.LblRetailPrice.Location = new System.Drawing.Point(24, 63);
            this.LblRetailPrice.Name = "LblRetailPrice";
            this.LblRetailPrice.Size = new System.Drawing.Size(67, 12);
            this.LblRetailPrice.TabIndex = 36;
            this.LblRetailPrice.Text = "Retail Price:";
            // 
            // TboxProductName
            // 
            this.TboxProductName.Location = new System.Drawing.Point(97, 35);
            this.TboxProductName.Name = "TboxProductName";
            this.TboxProductName.Size = new System.Drawing.Size(186, 19);
            this.TboxProductName.TabIndex = 1;
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(127, 88);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 4;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnOK
            // 
            this.BtnOK.Location = new System.Drawing.Point(208, 88);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(75, 23);
            this.BtnOK.TabIndex = 3;
            this.BtnOK.Text = "OK";
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(198, 12);
            this.lblTitle.TabIndex = 40;
            this.lblTitle.Text = "Please enter new product information.";
            // 
            // FormAddProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 123);
            this.ControlBox = false;
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnOK);
            this.Controls.Add(this.TboxRetailPrice);
            this.Controls.Add(this.LblProductName);
            this.Controls.Add(this.LblRetailPrice);
            this.Controls.Add(this.TboxProductName);
            this.Name = "FormAddProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormAddProduct";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TboxRetailPrice;
        private System.Windows.Forms.Label LblProductName;
        private System.Windows.Forms.Label LblRetailPrice;
        private System.Windows.Forms.TextBox TboxProductName;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnOK;
        private System.Windows.Forms.Label lblTitle;
    }
}