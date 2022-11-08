using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
            dataGridView1.DataSource = products;
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            TextBoxDiscount.Text = "5";
        }

        /// <summary>
        /// Список продуктов
        /// </summary>
        private BindingList<Product> products =
            new BindingList<Product>();

        /// <summary>
        /// Список чеков
        /// </summary>
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
            if (CheckTextBox() == false)
            {
                return;
            }

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
            if (string.IsNullOrEmpty(TextBoxDiscount.Text))
            {
                MessageBox.Show("TextBox 'Discount' not filled in");
                return;
            }

            if (CheckProducts() == false)
            {
                return;
            }

            List<DiscountBase> list = new List<DiscountBase>();
            
            if (RadioButtonIntCoup.Checked == true)
            {
                InterestCoupon coupon = new InterestCoupon(double.Parse(TextBoxDiscount.Text));
                list.Add(coupon);
            }

            if (RadioButtonCert.Checked == true)
            {
                DiscountСertificate cert = new DiscountСertificate(double.Parse(TextBoxDiscount.Text));
                list.Add(cert);
            }

            double cost = GetProductsCost();
            double discountedCost = list[0].GetResultPrice(GetProductsCost());
            Cheque cheque = new Cheque(GetProductsInfo(), cost, discountedCost); 
            cheques.Add(cheque);
            DialogResult = DialogResult.OK;
            this.Hide();
        }

        /// <summary>
        /// Удаляет товар из products и dataGridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDeleteGood_Click(object sender, EventArgs e)
        {
            if (CheckProducts() == false)
            {
                return;
            }

            int deleteIndex = dataGridView1.SelectedCells[0].RowIndex;
            products.RemoveAt(deleteIndex);
            dataGridView1.DataSource = products;
        }

        // TODO В чек
        /// <summary>
        /// Возвращает информацию обо всех продуктах
        /// </summary>
        /// <returns></returns>
        private string GetProductsInfo()
        {
            string result = "";
            foreach (var product in products)
            {
                if (product != products[products.Count - 1])
                {
                    result += product.InfoProduct() + "\n";
                }
                else
                {
                    result += product.InfoProduct();
                }
            }
            return result;
        }

        // TODO: В чек
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

        /// <summary>
        /// Добавляет рандомный товар в список и на DataGridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAddRandomProduct_Click(object sender, EventArgs e)
        {
            Product product = Product.GetRandomProduct();
            products.Add(product);
            dataGridView1.DataSource = products;
        }

        /// <summary>
        /// Проверка входных параметров товара
        /// </summary>
        /// <returns></returns>
        private bool CheckTextBox()
        {
            if (string.IsNullOrEmpty(TextBoxProductName.Text) ||
                string.IsNullOrEmpty(TextBoxQuantity.Text) ||
                string.IsNullOrEmpty(TextBoxPrice.Text))
            {
                MessageBox.Show("TextBox 'Name of good', 'Quantity' or 'Price' not filled in");
                return false;
            }
            else return true;
        }

        /// <summary>
        /// Проверка списка продуктов
        /// </summary>
        /// <returns></returns>
        private bool CheckProducts()
        {
            if (products.Any() == false)
            {
                MessageBox.Show("The list of products is empty");
                return false;
            }
            else if (RadioButtonIntCoup.Checked == true &&
                     double.Parse(TextBoxDiscount.Text) > 100 || double.Parse(TextBoxDiscount.Text) <= 0)
            {
                MessageBox.Show("The discount cannot be less than or equal to 0 or more than 100");
                return false;
            }
               
            else return true;
        }
        

    }
}
