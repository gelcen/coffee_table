using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TablePlugin
{
    public partial class MainForm : Form, IView
    {
        /// <summary>
        /// Приватное поле для TableSettings
        /// </summary>
        private TableSettings _tableSettings;

        /// <summary>
        /// Список ошибок
        /// </summary>
        private List<string> _errorList;

        public MainForm()
        {
            InitializeComponent();
            _errorList = new List<string>();
            buttonBuildTable.Click += ButtonBuildTable_Click;
        }

        /// <summary>
        /// Обработчик нажатия на кнопку построения столика
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonBuildTable_Click(object sender, EventArgs e)
        {
            if (!ValidateForEmptiness())
            {
                return;
            }

            int tabletopLength = Convert.ToInt32(txtBoxTabletopLength.Text);
            int tabletopThickness = Convert.ToInt32(tableTopThicknessTextBox.Text);
            int legHeight = Convert.ToInt32(legHeightTextBox.Text);
            int legLength = Convert.ToInt32(legLengthTextBox.Text);
            bool roundedEdges = chkBoxRoundedEdgesTabletop.Checked;

            try
            {
                _tableSettings = new TableSettings(tabletopLength, tabletopThickness, legHeight, legLength, roundedEdges);
            }
            catch (ArgumentException ex)
            {
                _errorList.Add(ex.Message);
                ShowErrors();
                return;
            }
            if (BuildClick != null) BuildClick(this, EventArgs.Empty);           
        }

        /// <summary>
        /// Проверка на пустые поля и поля с отрицательными значениями
        /// </summary>
        /// <returns></returns>
        private bool ValidateForEmptiness()
        {
            _errorList.Clear();

            ValidateTextBox(txtBoxTabletopLength, "Введите, пожалуйста, длину стороны столешницы!");
            ValidateTextBox(tableTopThicknessTextBox, "Введите, пожалуйста, толщину столешницы!");
            ValidateTextBox(legHeightTextBox, "Введите, пожалуйста, высоту ножки!");
            ValidateTextBox(legLengthTextBox, "Введите, пожалуйста, длину стороны ножки!");

            if (_errorList.Count != 0)
            {
                ShowErrors();
                return false;
            }
            return true;
        }

        /// <summary>
        /// Валидация отдельного поля
        /// </summary>
        /// <param name="textBox"></param>
        /// <param name="errorMessage"></param>
        private void ValidateTextBox(TextBox textBox, string errorMessage)
        {
            if (string.IsNullOrEmpty(textBox.Text) || int.Parse(textBox.Text) <= 0)
            {
                _errorList.Add(errorMessage);
            }    
        }

        /// <summary>
        /// Показ ошибок
        /// </summary>
        private void ShowErrors()
        {
            if (_errorList.Count != 0)
            {
                string errors = "";

                for (int i = 0; i < _errorList.Count; i++)
                {
                    errors += _errorList[i] + "\n";
                }

                MessageBox.Show(errors, "Ошибочный ввод данных", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Свойство для передачи класса столика в Presenter
        /// </summary>
        public TableSettings TableSettings
        {
            get
            {
                return _tableSettings;
            }
            set
            {
                _tableSettings = value;
            }            
        }

        /// <summary>
        /// Событие нажатия на кнопку "Построить столик"
        /// </summary>
        public event EventHandler BuildClick;

        /// <summary>
        /// Обработчик для ввода в поля только чисел
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleKeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
