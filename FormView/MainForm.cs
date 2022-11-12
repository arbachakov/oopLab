using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace FormView
{
    //TODO: XML (+)
    /// <summary>
    /// Класс главной формы
    /// </summary>
    public partial class MainForm : Form
    {
        //TODO: XML (+)
        /// <summary>
        /// Инициализация формы
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            //TODO: перенести комментарий (+)
            // Выделение строки в dataGridView1
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // Позволяет переносить строки в dataGridView1
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            // Авторазмер строк в dataGridView1
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            // Авторазмер столбцов в dataGridView1
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; 

            dataGridView1.DataSource = _createChequeForm.cheques;
            maskedTextBox1.Text = Convert.ToString(DateTime.Now);
            maskedTextBox2.Text = Convert.ToString(DateTime.Now);

            dataGridView1.Columns[0].Width = 65;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 50;
            dataGridView1.Columns[3].Width = 90;
            dataGridView1.Columns[4].Width = 70;
            
            openFileDialog1.Filter = "JSON (*.json)|*.json";
            saveFileDialog1.Filter = "JSON (*.json)|*.json";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        //TODO: RSDN (+)
        /// <summary>
        /// Форма создания продуктов
        /// </summary>
        private CreateChequeForm _createChequeForm =
            new CreateChequeForm();

        //TODO: RSDN (+)
        /// <summary>
        /// Список для фильтрации
        /// </summary>
        private BindingList<Cheque> _findedCheques =
            new BindingList<Cheque>();

        /// <summary>
        /// Открывает окно создания покупки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAddCheque_Click(object sender, EventArgs e)
        {
            _createChequeForm.Show();
            if (_createChequeForm.DialogResult == DialogResult.OK)
            {
                dataGridView1.DataSource = _createChequeForm.cheques;
            }
        }


        /// <summary>
        /// Выполяет фильтрацию по диапазону, указанному в maskedTextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSearchByDate_Click(object sender, EventArgs e)
        {
            _findedCheques.Clear();
            try
            {
                for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
                {
                    if (Convert.ToDateTime(maskedTextBox1.Text) <=
                        Convert.ToDateTime(dataGridView1.Rows[i].Cells[0].Value)
                        && Convert.ToDateTime(dataGridView1.Rows[i].Cells[0].Value) <=
                        Convert.ToDateTime(maskedTextBox2.Text))
                    {
                        _findedCheques.Add(_createChequeForm.cheques[i]);
                    }
                }
                dataGridView1.DataSource = _findedCheques;
            }
            catch 
            {
                MessageBox.Show("Дата введена некорректно");
            }
            
        }

        /// <summary>
        /// Сбросить поиск
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonReset_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _createChequeForm.cheques;
            _findedCheques.Clear();
        }

        /// <summary>
        /// Генерирует случайный чек
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonGetRandomCheque_Click(object sender, EventArgs e)
        {
            Cheque cheque = Cheque.GetRandomCheque();
            _createChequeForm.cheques.Add(cheque);
            dataGridView1.DataSource = _createChequeForm.cheques;
            
        }

        /// <summary>
        /// Сохраняет чеки в формате JSON
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (_createChequeForm.cheques.Any() == false)
            {
                MessageBox.Show("the list of receipts is empty(");
                return;
            }
            string json = JsonConvert.SerializeObject
                (_createChequeForm.cheques, Formatting.Indented);
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            string filename = saveFileDialog1.FileName;
            System.IO.File.WriteAllText(filename, json);
            MessageBox.Show("File saved");
        }

        /// <summary>
        /// Загружает json
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonLoad_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                string filename = openFileDialog1.FileName;
                string fileText = System.IO.File.ReadAllText(filename);
                var cheqes = JsonConvert.DeserializeObject<List<Cheque>>(fileText);
                dataGridView1.DataSource = cheqes;
                MessageBox.Show("File opened");
            }
            catch 
            {
                MessageBox.Show("Файл поврежден");
            }
            
        }

        /// <summary>
        /// Удаляет чек из dataGridView и списка чеков
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (CheckChequesList() == false)
            {
                return;
            }

            int deleteIndex = dataGridView1.SelectedCells[0].RowIndex;
            _createChequeForm.cheques.RemoveAt(deleteIndex);
            dataGridView1.DataSource = _createChequeForm.cheques;
        }

        /// <summary>
        /// Проверка, пустой ли чек
        /// </summary>
        /// <returns></returns>
        private bool CheckChequesList()
        {
            if (_createChequeForm.cheques.Any() == false)
            {
                MessageBox.Show("The list of cheques is empty");
                return false;
            }

            return true;
        }
        
}
}
