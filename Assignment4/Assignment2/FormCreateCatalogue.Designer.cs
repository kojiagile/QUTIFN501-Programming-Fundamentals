namespace Assignment2
{
    partial class FormCreateCatalogue
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
            this.BtnOK = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.TboxName = new System.Windows.Forms.TextBox();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.LblCategory = new System.Windows.Forms.Label();
            this.CboxCategory = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnOK
            // 
            this.BtnOK.Location = new System.Drawing.Point(498, 67);
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
            this.lblTitle.Location = new System.Drawing.Point(12, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(270, 12);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Please select category and enter a catalogue name.";
            // 
            // TboxName
            // 
            this.TboxName.Location = new System.Drawing.Point(357, 42);
            this.TboxName.Name = "TboxName";
            this.TboxName.Size = new System.Drawing.Size(216, 19);
            this.TboxName.TabIndex = 2;
            this.TboxName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TboxName_KeyPress);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(417, 67);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 4;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // LblCategory
            // 
            this.LblCategory.AutoSize = true;
            this.LblCategory.Location = new System.Drawing.Point(12, 44);
            this.LblCategory.Name = "LblCategory";
            this.LblCategory.Size = new System.Drawing.Size(53, 12);
            this.LblCategory.TabIndex = 31;
            this.LblCategory.Text = "Category:";
            // 
            // CboxCategory
            // 
            this.CboxCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboxCategory.FormattingEnabled = true;
            this.CboxCategory.Location = new System.Drawing.Point(71, 41);
            this.CboxCategory.Name = "CboxCategory";
            this.CboxCategory.Size = new System.Drawing.Size(183, 20);
            this.CboxCategory.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(260, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 12);
            this.label1.TabIndex = 32;
            this.label1.Text = "Catelogue Name:";
            // 
            // FormCreateCatalogue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 97);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LblCategory);
            this.Controls.Add(this.CboxCategory);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.TboxName);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.BtnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCreateCatalogue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create new catalogue";
            this.Load += new System.EventHandler(this.FormCreateCatalogue_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnOK;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox TboxName;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Label LblCategory;
        private System.Windows.Forms.ComboBox CboxCategory;
        private System.Windows.Forms.Label label1;
    }
}