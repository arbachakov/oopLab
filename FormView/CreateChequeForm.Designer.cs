
namespace FormView
{
    partial class CreateChequeForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.RadioButtonIntCoup = new System.Windows.Forms.RadioButton();
            this.RadioButtonCert = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TextBoxDiscount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ButtonOk = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ButtonAddRandomProduct = new System.Windows.Forms.Button();
            this.ButtonDeleteGood = new System.Windows.Forms.Button();
            this.ButtonAddProduct = new System.Windows.Forms.Button();
            this.TextBoxPrice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TextBoxQuantity = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TextBoxProductName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(7, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(390, 203);
            this.dataGridView1.TabIndex = 0;
            // 
            // RadioButtonIntCoup
            // 
            this.RadioButtonIntCoup.AutoSize = true;
            this.RadioButtonIntCoup.Location = new System.Drawing.Point(6, 19);
            this.RadioButtonIntCoup.Name = "RadioButtonIntCoup";
            this.RadioButtonIntCoup.Size = new System.Drawing.Size(99, 17);
            this.RadioButtonIntCoup.TabIndex = 1;
            this.RadioButtonIntCoup.TabStop = true;
            this.RadioButtonIntCoup.Text = "Interest coupon";
            this.RadioButtonIntCoup.UseVisualStyleBackColor = true;
            this.RadioButtonIntCoup.CheckedChanged += new System.EventHandler(this.RadioButtonIntCoup_CheckedChanged);
            // 
            // RadioButtonCert
            // 
            this.RadioButtonCert.AutoSize = true;
            this.RadioButtonCert.Location = new System.Drawing.Point(6, 42);
            this.RadioButtonCert.Name = "RadioButtonCert";
            this.RadioButtonCert.Size = new System.Drawing.Size(72, 17);
            this.RadioButtonCert.TabIndex = 2;
            this.RadioButtonCert.TabStop = true;
            this.RadioButtonCert.Text = "Sertifikate";
            this.RadioButtonCert.UseVisualStyleBackColor = true;
            this.RadioButtonCert.CheckedChanged += new System.EventHandler(this.RadioButtonCert_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RadioButtonIntCoup);
            this.groupBox1.Controls.Add(this.RadioButtonCert);
            this.groupBox1.Controls.Add(this.TextBoxDiscount);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(266, 230);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(131, 98);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select type of discount";
            // 
            // TextBoxDiscount
            // 
            this.TextBoxDiscount.Location = new System.Drawing.Point(59, 65);
            this.TextBoxDiscount.Name = "TextBoxDiscount";
            this.TextBoxDiscount.Size = new System.Drawing.Size(46, 20);
            this.TextBoxDiscount.TabIndex = 5;
            //this.TextBoxDiscount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxDiscount_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(111, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "%";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Discount:";
            // 
            // ButtonOk
            // 
            this.ButtonOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonOk.Location = new System.Drawing.Point(118, 334);
            this.ButtonOk.Name = "ButtonOk";
            this.ButtonOk.Size = new System.Drawing.Size(75, 23);
            this.ButtonOk.TabIndex = 7;
            this.ButtonOk.Text = "Ok";
            this.ButtonOk.UseVisualStyleBackColor = true;
            this.ButtonOk.Click += new System.EventHandler(this.ButtonOk_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonCancel.Location = new System.Drawing.Point(199, 334);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 8;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ButtonAddRandomProduct);
            this.groupBox2.Controls.Add(this.ButtonDeleteGood);
            this.groupBox2.Controls.Add(this.ButtonAddProduct);
            this.groupBox2.Controls.Add(this.TextBoxPrice);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.TextBoxQuantity);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.TextBoxProductName);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(7, 230);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(253, 98);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Create product";
            // 
            // ButtonAddRandomProduct
            // 
            this.ButtonAddRandomProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonAddRandomProduct.Location = new System.Drawing.Point(168, 71);
            this.ButtonAddRandomProduct.Name = "ButtonAddRandomProduct";
            this.ButtonAddRandomProduct.Size = new System.Drawing.Size(75, 23);
            this.ButtonAddRandomProduct.TabIndex = 9;
            this.ButtonAddRandomProduct.Text = "Add random";
            this.ButtonAddRandomProduct.UseVisualStyleBackColor = true;
            this.ButtonAddRandomProduct.Click += new System.EventHandler(this.ButtonAddRandomProduct_Click);
            // 
            // ButtonDeleteGood
            // 
            this.ButtonDeleteGood.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonDeleteGood.Location = new System.Drawing.Point(87, 71);
            this.ButtonDeleteGood.Name = "ButtonDeleteGood";
            this.ButtonDeleteGood.Size = new System.Drawing.Size(75, 23);
            this.ButtonDeleteGood.TabIndex = 15;
            this.ButtonDeleteGood.Text = "Delete";
            this.ButtonDeleteGood.UseVisualStyleBackColor = true;
            this.ButtonDeleteGood.Click += new System.EventHandler(this.ButtonDeleteProduct_Click);
            // 
            // ButtonAddProduct
            // 
            this.ButtonAddProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonAddProduct.Location = new System.Drawing.Point(6, 71);
            this.ButtonAddProduct.Name = "ButtonAddProduct";
            this.ButtonAddProduct.Size = new System.Drawing.Size(75, 21);
            this.ButtonAddProduct.TabIndex = 9;
            this.ButtonAddProduct.Text = "Add";
            this.ButtonAddProduct.UseVisualStyleBackColor = true;
            this.ButtonAddProduct.Click += new System.EventHandler(this.ButtonAddProduct_Click);
            // 
            // TextBoxPrice
            // 
            this.TextBoxPrice.Location = new System.Drawing.Point(158, 43);
            this.TextBoxPrice.Name = "TextBoxPrice";
            this.TextBoxPrice.Size = new System.Drawing.Size(85, 20);
            this.TextBoxPrice.TabIndex = 14;
            //this.TextBoxPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxPrice_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(122, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Price:";
            // 
            // TextBoxQuantity
            // 
            this.TextBoxQuantity.Location = new System.Drawing.Point(61, 43);
            this.TextBoxQuantity.Name = "TextBoxQuantity";
            this.TextBoxQuantity.Size = new System.Drawing.Size(55, 20);
            this.TextBoxQuantity.TabIndex = 12;
            //this.TextBoxQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxQuantity_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Quantity:";
            // 
            // TextBoxProductName
            // 
            this.TextBoxProductName.Location = new System.Drawing.Point(101, 19);
            this.TextBoxProductName.Name = "TextBoxProductName";
            this.TextBoxProductName.Size = new System.Drawing.Size(142, 20);
            this.TextBoxProductName.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Name of product:";
            // 
            // CreateChequeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 365);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonOk);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "CreateChequeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add cheque window";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.RadioButton RadioButtonIntCoup;
        private System.Windows.Forms.RadioButton RadioButtonCert;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextBoxDiscount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ButtonOk;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button ButtonDeleteGood;
        private System.Windows.Forms.Button ButtonAddProduct;
        private System.Windows.Forms.TextBox TextBoxPrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TextBoxQuantity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TextBoxProductName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ButtonAddRandomProduct;
    }
}