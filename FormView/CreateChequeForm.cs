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
            
            dataGridView1.DefaultCellStyle.WrapMode = 
                DataGridViewTriState.True;
            TextBoxDiscount.Text = "5";
            MaximizeBox = false;
            _products = new BindingList<Product>();

            dataGridView1.DataSource = _products;
            dataGridView1.Columns[0].Width = 200;
            dataGridView1.Columns[1].Width = 50;
            dataGridView1.Columns[2].Width = 60;
            dataGridView1.MultiSelect = false;
            MinimizeBox = false;
            ControlBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            
            TextBoxPrice.KeyPress += CheckTextBoxForDouble;
            TextBoxDiscount.KeyPress += CheckTextBoxForInt;
            TextBoxQuantity.KeyPress += CheckTextBoxForInt;
        }

        /// <summary>
        /// Обработчик события
        /// </summary>
        internal event EventHandler ChequeAdded;

        /// <summary>
        /// Список продуктов
        /// </summary>
        private readonly BindingList<Product> _products;

        //TODO: Нарушение инкапсуляции, убрать в MainForm (+)
        /// <summary>
        /// Чек
        /// </summary>
        private Cheque _cheque;

        /// <summary>
        /// Свойство чека
        /// </summary>
        public Cheque Cheque
        {
            get => _cheque;
            private set
            {
                _cheque = value;
            }
        }

        /// <summary>
        /// Изменяет текст label при нажатии radioButton
        /// </summary>
        /// <param name="sender">Ссылка на объект</param>
        /// <param name="e">Объект, относящийся к обрабатываемому событию</param>
        private void RadioButtonIntCoup_CheckedChanged(object sender, 
            EventArgs e)
        {
            label2.Text = "%";
        }

        /// <summary>
        /// Изменяет текст label при нажатии radioButton
        /// </summary>
        /// <param name="sender">Ссылка на объект</param>
        /// <param name="e">Объект, относящийся к обрабатываемому событию</param>
        private void RadioButtonCert_CheckedChanged(object sender, 
            EventArgs e)
        {
            label2.Text = "$";
        }
        
        /// <summary>
        /// Добавляет товар в DatagridView
        /// </summary>
        /// <param name="sender">Ссылка на объект//</param> 
        /// <param name="e">Объект, относящийся к обрабатываемому событию</param>
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
        /// Скрывает форму при нажатии
        /// </summary>
        /// <param name="sender">Ссылка на объект</param>
        /// <param name="e">Объект, относящийся к обрабатываемому событию</param>
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Hide();
            _products.Clear();
        }

        /// <summary>
        /// Добавляет информации о покупке в dataGridView в MainForm
        /// </summary>
        /// <param name="sender">Ссылка на объект</param>
        /// <param name="e">Объект, относящийся к обрабатываемому событию</param>
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
            double discountedCost = list[0].GetResultPrice(cost);
            Cheque cheque = new Cheque(Cheque.GetProductsInfo(_products), 
                cost, discountedCost); 
            Cheque = cheque;
            ChequeAdded?.Invoke(sender, e);
            Hide();
            _products.Clear();
        }

        /// <summary>
        /// Удаляет товар из _products и dataGridView
        /// </summary>
        /// <param name="sender">Ссылка на объект</param>
        /// <param name="e">Объект, относящийся к обрабатываемому событию</param>
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

#if DEBUG
        /// <summary>
        /// Добавляет рандомный товар в список и на DataGridView
        /// </summary>
        /// <param name="sender">Ссылка на объект</param>
        /// <param name="e">Объект, относящийся к обрабатываемому событию</param>
        private void ButtonAddRandomProduct_Click(object sender, EventArgs e)
        {
            Product product = Product.GetRandomProduct();
            _products.Add(product);
            dataGridView1.DataSource = _products;
        }
#endif

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

            return true;
        }

        /// <summary>
        /// Проверка списка продуктов
        /// </summary>
        /// <returns></returns>
        private bool CheckProductList()
        {
            return _products.Any();
        }

        /// <summary>
        /// Проверяет на правильность значения скидки
        /// </summary>
        /// <returns></returns>
        private bool CheckDiscountTextBox()
        {
            if (RadioButtonIntCoup.Checked &&
                (double.Parse(TextBoxDiscount.Text) > InterestCoupon.MaxDiscount ||
                 double.Parse(TextBoxDiscount.Text) <= DiscountBase.MinDiscount))
            {
                MessageBox.Show($"The discount cannot be " +
                                $"less than or equal to {DiscountBase.MinDiscount} " +
                                $"or more than {InterestCoupon.MaxDiscount}");
                return false;
            }

            if (RadioButtonCert.Checked &&
                double.Parse(TextBoxDiscount.Text) <= DiscountBase.MinDiscount)
            {
                MessageBox.Show($"The discount cannot be less than " +
                                $"or equal to {DiscountBase.MinDiscount}");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Разрешает определенные символы 
        /// </summary>
        /// <param name="sender">Ссылка на объект</param>
        /// <param name="e">Объект, относящийся к обрабатываемому событию</param>
        private static void CheckTextBoxForDouble(
            object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) 
                                        && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            if (e.KeyChar == ',' && ((TextBox)sender).Text.IndexOf(',') > -1)
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Разрешает определенные символы
        /// </summary>
        /// <param name="sender">Ссылка на объект</param>
        /// <param name="e">Объект, относящийся к обрабатываемому событию</param>
        private static void CheckTextBoxForInt(
            object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
