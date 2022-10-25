using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormView
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        /// <summary>
        /// Открывает окно создания покупки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAddPurchooseInfo_Click(object sender, EventArgs e)
        {
            CreatePurchaseForm formCreatePurchaseForm = 
                new CreatePurchaseForm();
            formCreatePurchaseForm.Show();
        }
    }
}
