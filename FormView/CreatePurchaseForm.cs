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
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Product product1 = new Product("Pen", 14, 2);
            Product product2 = new Product("Copybook", 4, 4);
            products.Add(product1);
            products.Add(product2);
            dataGridView1.DataSource = products;
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

        }

        private BindingList<Product> products =
            new BindingList<Product>();

        public BindingList<Cheque> cheques =
            new BindingList<Cheque>();

        /// <summary>
        /// Изменяет текст label при нажатии radioButton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioButtonIntCoup_CheckedChanged(object sender, EventArgs e)
        {
            label2.Text = "%";
        }

        /// <summary>
        /// Изменяет текст label при нажатии radioButton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioButtonCert_CheckedChanged(object sender, EventArgs e)
        {
            label2.Text = "$";
        }

        /// <summary>
        /// Добавляет товар в DatagridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAddGood_Click(object sender, EventArgs e)
        {
            Product product = new Product(TextBoxProductName.Text,
                int.Parse(TextBoxQuantity.Text),
                double.Parse(TextBoxPrice.Text));
            products.Add(product);
            dataGridView1.DataSource = products;
            TextBoxProductName.Clear();
            TextBoxQuantity.Clear();
            TextBoxPrice.Clear();
        }
        
        /// <summary>
        /// Запрещает ввод символов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 46) 
                //цифры, клавиша BackSpace и запятая а ASCII
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Запрещает ввод символов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (e.KeyChar <= 47 || e.KeyChar >= 58) //цифры
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Запрещает ввод символов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) 
                && number != 8 && number != 46) 
                //цифры, клавиша BackSpace и запятая а ASCII
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Скрывает форму при нажатии
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        /// <summary>
        /// Добавляет информации о покупке в dataGridView в MainForm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonOk_Click(object sender, EventArgs e)
        {
            // TODO: Исправить этот ужас / добавить проверки
            if (RadioButtonIntCoup.Checked == true)
            {
                InterestCoupon coupon = new InterestCoupon(double.Parse(TextBoxDiscount.Text));

                double cost = GetProductsCost();
                double discountedCost = coupon.GetResultPrice(GetProductsCost());
                double benefit = GetBenefit(cost, discountedCost);

                Cheque cheque = new Cheque(
                    $"{DateTime.Now}" + "\n" + GetProductsInfo(),
                    cost, discountedCost, benefit);
                cheques.Add(cheque);
                DialogResult = DialogResult.OK;
                this.Hide();
            }

            if (RadioButtonCert.Checked == true)
            {
                Сertificate cert = new Сertificate(double.Parse(TextBoxDiscount.Text));
                double cost = GetProductsCost();
                double discountedCost = cert.GetResultPrice(GetProductsCost());
                double benefit = GetBenefit(cost, discountedCost);

                Cheque cheque = new Cheque(
                    $"{DateTime.Now}" + "\n" + GetProductsInfo(),
                    cost, discountedCost, benefit);
                cheques.Add(cheque);
                DialogResult = DialogResult.OK;
                this.Hide();
            }
        }

        /// <summary>
        /// Удаляет товар из products и dataGridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDeleteGood_Click(object sender, EventArgs e)
        {
            int deleteIndex = dataGridView1.SelectedCells[0].RowIndex;
            products.RemoveAt(deleteIndex);
            dataGridView1.DataSource = products;
        }

        /// <summary>
        /// Возвращает информацию обо всех продуктах
        /// </summary>
        /// <returns></returns>
        private string GetProductsInfo()
        {
            string result = "";
            foreach (var product in products)
            {
                result += product.InfoProduct() + "\n";
            }

            return result;
        }

        /// <summary>
        /// Возвращает стоимость всей покупки
        /// </summary>
        /// <returns></returns>
        private double GetProductsCost()
        {
            double sum = 0;
            foreach (var product in products)
            {
                sum += product.GetCost();
            }

            return sum;
        }

        private double GetBenefit(double cost, double discountedCost)
        {
            if (cost - discountedCost <= 0)
            {
                return cost;
            }

            return cost - discountedCost;
        }
    }
}
