using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab3;

namespace FormView
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Выделение строки
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True; // Авторазмер
            dataGridView1.DataSource = formCreatePurchaseForm.cheques;
            
        }

        /// <summary>
        /// Форма создания продуктов
        /// </summary>
        CreatePurchaseForm formCreatePurchaseForm =
            new CreatePurchaseForm();

        /// <summary>
        /// Открывает окно создания покупки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAddPurchooseInfo_Click(object sender, EventArgs e)
        {
            
            formCreatePurchaseForm.Show();

            if (formCreatePurchaseForm.DialogResult == DialogResult.OK)
            {
                dataGridView1.DataSource = formCreatePurchaseForm.cheques;
            }
        }

        
    }
}
