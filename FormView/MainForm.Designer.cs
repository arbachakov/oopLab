
namespace FormView
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ButtonAddPurchooseInfo = new System.Windows.Forms.Button();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.ButtonLoad = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ButtonReset = new System.Windows.Forms.Button();
            this.maskedTextBox2 = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.ButtonSearchByDate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ButtonGetRandomCheque = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 65);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(494, 373);
            this.dataGridView1.TabIndex = 0;
            // 
            // ButtonAddPurchooseInfo
            // 
            this.ButtonAddPurchooseInfo.Location = new System.Drawing.Point(12, 12);
            this.ButtonAddPurchooseInfo.Name = "ButtonAddPurchooseInfo";
            this.ButtonAddPurchooseInfo.Size = new System.Drawing.Size(75, 47);
            this.ButtonAddPurchooseInfo.TabIndex = 1;
            this.ButtonAddPurchooseInfo.Text = "Add purchase";
            this.ButtonAddPurchooseInfo.UseVisualStyleBackColor = true;
            this.ButtonAddPurchooseInfo.Click += new System.EventHandler(this.ButtonAddPurchooseInfo_Click);
            // 
            // ButtonSave
            // 
            this.ButtonSave.Location = new System.Drawing.Point(93, 12);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(75, 47);
            this.ButtonSave.TabIndex = 2;
            this.ButtonSave.Text = "Save purchase";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // ButtonLoad
            // 
            this.ButtonLoad.Location = new System.Drawing.Point(174, 12);
            this.ButtonLoad.Name = "ButtonLoad";
            this.ButtonLoad.Size = new System.Drawing.Size(75, 47);
            this.ButtonLoad.TabIndex = 3;
            this.ButtonLoad.Text = "Load purchase";
            this.ButtonLoad.UseVisualStyleBackColor = true;
            this.ButtonLoad.Click += new System.EventHandler(this.ButtonLoad_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ButtonReset);
            this.groupBox1.Controls.Add(this.maskedTextBox2);
            this.groupBox1.Controls.Add(this.maskedTextBox1);
            this.groupBox1.Controls.Add(this.ButtonSearchByDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(512, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(136, 161);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Date search";
            // 
            // ButtonReset
            // 
            this.ButtonReset.Location = new System.Drawing.Point(23, 130);
            this.ButtonReset.Name = "ButtonReset";
            this.ButtonReset.Size = new System.Drawing.Size(75, 23);
            this.ButtonReset.TabIndex = 7;
            this.ButtonReset.Text = "Reset";
            this.ButtonReset.UseVisualStyleBackColor = true;
            this.ButtonReset.Click += new System.EventHandler(this.ButtonReset_Click);
            // 
            // maskedTextBox2
            // 
            this.maskedTextBox2.Location = new System.Drawing.Point(17, 75);
            this.maskedTextBox2.Mask = "00/00/0000 90:00";
            this.maskedTextBox2.Name = "maskedTextBox2";
            this.maskedTextBox2.Size = new System.Drawing.Size(100, 20);
            this.maskedTextBox2.TabIndex = 6;
            this.maskedTextBox2.ValidatingType = typeof(System.DateTime);
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(17, 36);
            this.maskedTextBox1.Mask = "00/00/0000 90:00";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(100, 20);
            this.maskedTextBox1.TabIndex = 5;
            this.maskedTextBox1.ValidatingType = typeof(System.DateTime);
            // 
            // ButtonSearchByDate
            // 
            this.ButtonSearchByDate.Location = new System.Drawing.Point(23, 101);
            this.ButtonSearchByDate.Name = "ButtonSearchByDate";
            this.ButtonSearchByDate.Size = new System.Drawing.Size(75, 23);
            this.ButtonSearchByDate.TabIndex = 4;
            this.ButtonSearchByDate.Text = "Find";
            this.ButtonSearchByDate.UseVisualStyleBackColor = true;
            this.ButtonSearchByDate.Click += new System.EventHandler(this.ButtonSearchByDate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "To:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "From:";
            // 
            // ButtonGetRandomCheque
            // 
            this.ButtonGetRandomCheque.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ButtonGetRandomCheque.Location = new System.Drawing.Point(512, 232);
            this.ButtonGetRandomCheque.Name = "ButtonGetRandomCheque";
            this.ButtonGetRandomCheque.Size = new System.Drawing.Size(136, 206);
            this.ButtonGetRandomCheque.TabIndex = 6;
            this.ButtonGetRandomCheque.Text = "Get random cheque";
            this.ButtonGetRandomCheque.UseVisualStyleBackColor = false;
            this.ButtonGetRandomCheque.Click += new System.EventHandler(this.ButtonGetRandomCheque_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 450);
            this.Controls.Add(this.ButtonGetRandomCheque);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ButtonLoad);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.ButtonAddPurchooseInfo);
            this.Controls.Add(this.dataGridView1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button ButtonAddPurchooseInfo;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.Button ButtonLoad;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ButtonSearchByDate;
        private System.Windows.Forms.MaskedTextBox maskedTextBox2;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Button ButtonReset;
        private System.Windows.Forms.Button ButtonGetRandomCheque;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

