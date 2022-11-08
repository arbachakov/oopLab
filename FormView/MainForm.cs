using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Lab3;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace FormView
{
    //TODO: XML
    public partial class MainForm : Form
    {
        //TODO: XML
        public MainForm()
        {
            InitializeComponent();
            //TODO: перенести комментарий
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Выделение строки
            
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True; // Позволяет переносить строки
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells; // Авторазмер
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; // Авторазмер
            
            dataGridView1.DataSource = formCreatePurchaseForm.cheques;
            maskedTextBox1.Text = Convert.ToString(DateTime.Now);
            maskedTextBox2.Text = Convert.ToString(DateTime.Now);

            openFileDialog1.Filter = "JSON (*.json)|*.json";
            saveFileDialog1.Filter = "JSON (*.json)|*.json";
        }

        //TODO: RSDN
        /// <summary>
        /// Форма создания продуктов
        /// </summary>
        CreatePurchaseForm formCreatePurchaseForm =
            new CreatePurchaseForm();

        //TODO: RSDN
        /// <summary>
        /// Список для фильтрации
        /// </summary>
        private BindingList<Cheque> findedCheques =
            new BindingList<Cheque>();

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


        /// <summary>
        /// Выполяет фильтрацию по диапазону, указанному в maskedTextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSearchByDate_Click(object sender, EventArgs e)
        {
            findedCheques.Clear();
            for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
            {
                if (Convert.ToDateTime(maskedTextBox1.Text) <= 
                    Convert.ToDateTime(dataGridView1.Rows[i].Cells[0].Value)
                    && Convert.ToDateTime(dataGridView1.Rows[i].Cells[0].Value) <= 
                    Convert.ToDateTime(maskedTextBox2.Text))
                {
                    findedCheques.Add(formCreatePurchaseForm.cheques[i]);
                }
                    
            }

            dataGridView1.DataSource = findedCheques;
            
        }

        /// <summary>
        /// Сбросить поиск
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonReset_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = formCreatePurchaseForm.cheques;
            findedCheques.Clear();
        }

        /// <summary>
        /// Генерирует случайный чек
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonGetRandomCheque_Click(object sender, EventArgs e)
        {
            Cheque cheque = Cheque.GetRandomCheque();
            formCreatePurchaseForm.cheques.Add(cheque);
            dataGridView1.DataSource = formCreatePurchaseForm.cheques;
            
        }

        /// <summary>
        /// Сохраняет чеки в формате JSON
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (formCreatePurchaseForm.cheques.Any() == false)
            {
                MessageBox.Show("the list of receipts is empty(");
                return;
            }
            string json = JsonConvert.SerializeObject(formCreatePurchaseForm.cheques, Formatting.Indented);
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
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
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog1.FileName;
            string fileText = System.IO.File.ReadAllText(filename);
            var cheqes = JsonConvert.DeserializeObject<List<Cheque>>(fileText);
            dataGridView1.DataSource = cheqes;
            MessageBox.Show("File opened");
        }
    }
}
