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
    public partial class CreatePurchaseForm : Form
    {
        public CreatePurchaseForm()
        {
            InitializeComponent();
            RadioButtonIntCoup.Checked = true;
        }

        private void RadioButtonIntCoup_CheckedChanged(object sender, EventArgs e)
        {
            label2.Text = "%";
        }

        private void RadioButtonCert_CheckedChanged(object sender, EventArgs e)
        {
            label2.Text = "руб.";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Product product = new Product(TextBoxProductName.Text,
                int.Parse(TextBoxQuantity.Text),
                double.Parse(TextBoxPrice.Text));
            products.Add(product);
            dataGridView1.DataSource = products;
            dataGridView1.Columns[0].HeaderText = "Название";
            dataGridView1.Columns[1].HeaderText = "Количество";
            dataGridView1.Columns[2].HeaderText = "Цена";
            TextBoxProductName.Clear();
            TextBoxQuantity.Clear();
            TextBoxPrice.Clear();
        }

        private BindingList<Product> products =
            new BindingList<Product>();
    }
}
