
namespace FormView
{
    partial class CreatePurchaseForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TextBoxProductName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TextBoxQuantity = new System.Windows.Forms.TextBox();
            this.TextBoxPrice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(340, 203);
            this.dataGridView1.TabIndex = 0;
            // 
            // RadioButtonIntCoup
            // 
            this.RadioButtonIntCoup.AutoSize = true;
            this.RadioButtonIntCoup.Location = new System.Drawing.Point(6, 19);
            this.RadioButtonIntCoup.Name = "RadioButtonIntCoup";
            this.RadioButtonIntCoup.Size = new System.Drawing.Size(120, 17);
            this.RadioButtonIntCoup.TabIndex = 1;
            this.RadioButtonIntCoup.TabStop = true;
            this.RadioButtonIntCoup.Text = "Процентный купон";
            this.RadioButtonIntCoup.UseVisualStyleBackColor = true;
            this.RadioButtonIntCoup.CheckedChanged += new System.EventHandler(this.RadioButtonIntCoup_CheckedChanged);
            // 
            // RadioButtonCert
            // 
            this.RadioButtonCert.AutoSize = true;
            this.RadioButtonCert.Location = new System.Drawing.Point(6, 42);
            this.RadioButtonCert.Name = "RadioButtonCert";
            this.RadioButtonCert.Size = new System.Drawing.Size(86, 17);
            this.RadioButtonCert.TabIndex = 2;
            this.RadioButtonCert.TabStop = true;
            this.RadioButtonCert.Text = "Сертификат";
            this.RadioButtonCert.UseVisualStyleBackColor = true;
            this.RadioButtonCert.CheckedChanged += new System.EventHandler(this.RadioButtonCert_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RadioButtonIntCoup);
            this.groupBox1.Controls.Add(this.RadioButtonCert);
            this.groupBox1.Location = new System.Drawing.Point(358, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(136, 75);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Выберите тип скидки";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(364, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Скидка:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(417, 93);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(46, 20);
            this.textBox1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(469, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "%";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(63, 411);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Ок";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(144, 411);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Отмена";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.TextBoxPrice);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.TextBoxQuantity);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.TextBoxProductName);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 230);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(265, 145);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Укажите товар";
            // 
            // TextBoxProductName
            // 
            this.TextBoxProductName.Location = new System.Drawing.Point(107, 19);
            this.TextBoxProductName.Name = "TextBoxProductName";
            this.TextBoxProductName.Size = new System.Drawing.Size(150, 20);
            this.TextBoxProductName.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Название товара";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Количество";
            // 
            // TextBoxQuantity
            // 
            this.TextBoxQuantity.Location = new System.Drawing.Point(78, 45);
            this.TextBoxQuantity.Name = "TextBoxQuantity";
            this.TextBoxQuantity.Size = new System.Drawing.Size(179, 20);
            this.TextBoxQuantity.TabIndex = 12;
            // 
            // TextBoxPrice
            // 
            this.TextBoxPrice.Location = new System.Drawing.Point(45, 71);
            this.TextBoxPrice.Name = "TextBoxPrice";
            this.TextBoxPrice.Size = new System.Drawing.Size(212, 20);
            this.TextBoxPrice.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Цена";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(45, 97);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 38);
            this.button3.TabIndex = 9;
            this.button3.Text = "Добавить товар";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(141, 97);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 38);
            this.button4.TabIndex = 15;
            this.button4.Text = "Удалить товар";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // CreatePurchaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 445);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "CreatePurchaseForm";
            this.Text = "Информация о покупке";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.RadioButton RadioButtonIntCoup;
        private System.Windows.Forms.RadioButton RadioButtonCert;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox TextBoxPrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TextBoxQuantity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TextBoxProductName;
        private System.Windows.Forms.Label label3;
    }
}