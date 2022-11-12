using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Model;

namespace FormView
{
    /// <summary>
    /// Форма создания чека, наполнения чека, выбора скидки
    /// </summary>
    public partial class CreateChequeForm : Form
    {
        /// <summary>
        /// Инициализация формы
        /// </summary>
        public CreateChequeForm()
        {
            InitializeComponent();
            RadioButtonIntCoup.Checked = true;
            dataGridView1.SelectionMode = 
                DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.DataSource = _products;
            dataGridView1.DefaultCellStyle.WrapMode = 
                DataGridViewTriState.True;
            TextBoxDiscount.Text = "5";

            dataGridView1.Columns[0].Width = 200;
            dataGridView1.Columns[1].Width = 50;
            dataGridView1.Columns[2].Width = 60;

            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        /// <summary>
        /// Список продуктов
        /// </summary>
        private BindingList<Product> _products =
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
        private void RadioButtonIntCoup_CheckedChanged(object sender, 
            EventArgs e)
        {
            label2.Text = "%";
        }

        /// <summary>
        /// Изменяет текст label при нажатии radioButton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioButtonCert_CheckedChanged(object sender, 
            EventArgs e)
        {
            label2.Text = "$";
        }

        /// <summary>
        /// Добавляет товар в DatagridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAddProduct_Click(object sender, EventArgs e)
        {
            if (CheckProductTextBoxes() == false)
            {
                return;
            }

            Product product = new Product(TextBoxProductName.Text,
                int.Parse(TextBoxQuantity.Text),
                double.Parse(TextBoxPrice.Text));
            _products.Add(product);
            dataGridView1.DataSource = _products;
            TextBoxProductName.Clear();
            TextBoxQuantity.Clear();
            TextBoxPrice.Clear();
        }
        
        /// <summary>
        /// Запрещает ввод символов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxPrice_KeyPress(object sender, 
            KeyPressEventArgs e)
        {
            char symbol = e.KeyChar;
            //TODO: переписать (+)
            CheckTextBoxForDouble(symbol,sender, e);
            
        }

        /// <summary>
        /// Запрещает ввод символов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxQuantity_KeyPress(object sender, 
            KeyPressEventArgs e)
        {
            char symbol = e.KeyChar;
            //TODO: переписать (+)
            CheckTextBoxForInt(symbol, sender, e);
        }

        /// <summary>
        /// Запрещает ввод символов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxDiscount_KeyPress(object sender, 
            KeyPressEventArgs e)
        {
            char symbol = e.KeyChar;
            //TODO: переписать (+)
            CheckTextBoxForInt(symbol, sender, e);
        }

        /// <summary>
        /// Скрывает форму при нажатии
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            _products.Clear();
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

            if (CheckProductList() == false)
            {
                return;
            }

            if (CheckDiscountTextBox() == false)
            {
                return;
            }

            List<DiscountBase> list = new List<DiscountBase>();
            
            if (RadioButtonIntCoup.Checked)
            {
                InterestCoupon coupon = new InterestCoupon
                    (int.Parse(TextBoxDiscount.Text));
                list.Add(coupon);
            }

            if (RadioButtonCert.Checked)
            {
                DiscountСertificate cert = new DiscountСertificate
                    (int.Parse(TextBoxDiscount.Text));
                list.Add(cert);
            }

            double cost = Cheque.GetProductsCost(_products);
            double discountedCost = list[0].GetResultPrice(Cheque.GetProductsCost(_products));
            Cheque cheque = new Cheque(Cheque.GetProductsInfo(_products), 
                cost, discountedCost); 
            cheques.Add(cheque);
            DialogResult = DialogResult.OK;
            this.Hide();
            _products.Clear();
        }

        /// <summary>
        /// Удаляет товар из _products и dataGridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDeleteProduct_Click(object sender, EventArgs e)
        {
            if (CheckProductList() == false)
            {
                return;
            }

            int deleteIndex = dataGridView1.SelectedCells[0].RowIndex;
            _products.RemoveAt(deleteIndex);
            dataGridView1.DataSource = _products;
        }

        /// <summary>
        /// Добавляет рандомный товар в список и на DataGridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAddRandomProduct_Click(object sender, EventArgs e)
        {
            Product product = Product.GetRandomProduct();
            _products.Add(product);
            dataGridView1.DataSource = _products;
        }

        /// <summary>
        /// Проверка входных параметров товара
        /// </summary>
        /// <returns></returns>
        private bool CheckProductTextBoxes()
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
        private bool CheckProductList()
        {
            if (_products.Any() == false)
            {
                MessageBox.Show("The list of products is empty");
                return false;
            }
            else return true;
        }

        /// <summary>
        /// Проверяет на правильность значения скидки
        /// </summary>
        /// <returns></returns>
        private bool CheckDiscountTextBox()
        {
            if (RadioButtonIntCoup.Checked == true &&
                //TODO: эти ограничения - знание предметной области (+)
                (double.Parse(TextBoxDiscount.Text) > InterestCoupon.maxDiscount ||
                 double.Parse(TextBoxDiscount.Text) <= InterestCoupon.minDiscount))
            {
                MessageBox.Show($"The discount cannot be " +
                                $"less than or equal to {InterestCoupon.minDiscount} " +
                                $"or more than {InterestCoupon.maxDiscount}");
                return false;
            }
            else if (RadioButtonCert.Checked &&
                     double.Parse(TextBoxDiscount.Text) <= DiscountСertificate.minDiscount)
            {
                MessageBox.Show($"The discount cannot be less than " +
                                $"or equal to {DiscountСertificate.minDiscount}");
                return false;
            }
            else return true;
        }

        /// <summary>
        /// Разрешает определенные символы 
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void CheckTextBoxForDouble(char symbol, 
            object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(symbol) && !char.IsDigit(symbol) 
                                        && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            if (symbol == ',' && (sender as TextBox).Text.IndexOf(',') > -1)
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Разрешает определенные символы
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void CheckTextBoxForInt(char symbol, 
            object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(symbol) && !char.IsDigit(symbol))
            {
                e.Handled = true;
            }
        }
    }
}
