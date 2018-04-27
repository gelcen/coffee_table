using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TablePlugin
{
    /// <summary>
    /// Класс MainForm
    /// </summary>
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

        /// <summary>
        /// Конструктор MainForm
        /// </summary>
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

            uint tabletopLength = Convert.ToUInt32(txtBoxTabletopLength.Text);
            uint tabletopThickness = Convert.ToUInt32(tableTopThicknessTextBox.Text);
            uint legHeight = Convert.ToUInt32(legHeightTextBox.Text);
            uint legLength = Convert.ToUInt32(legLengthTextBox.Text);
            uint septumLength = 0;
            uint septumOffset = 0;
            bool withSeptums = chkBoxBuildSeptums.Checked;
            if (withSeptums)
            {
                septumLength = Convert.ToUInt32(txtBoxSeptumLength.Text);
                septumOffset = Convert.ToUInt32(txtBoxSeptumOffset.Text);
            }
            else
            {
                septumLength = 0;
                septumOffset = 0;
            }
            bool roundedEdges = chkBoxRoundedEdgesTabletop.Checked;

            try
            {
                _tableSettings = new TableSettings(tabletopLength, tabletopThickness, 
                    legHeight, legLength, 
                    withSeptums, septumLength, septumOffset, roundedEdges);
            }
            catch (ArgumentException ex)
            {
                _errorList.Add(ex.Message);
                ShowErrors();
                return;
            }
            if (BuildClick != null)
            {
                BuildClick(this, EventArgs.Empty);
            }          
        }

        /// <summary>
        /// Проверка на пустые поля и поля с отрицательными значениями
        /// </summary>
        /// <returns></returns>
        private bool ValidateForEmptiness()
        {
            _errorList.Clear();

            ValidateTextBox(txtBoxTabletopLength.Text, "Введите, пожалуйста, длину стороны столешницы!");
            ValidateTextBox(tableTopThicknessTextBox.Text, "Введите, пожалуйста, толщину столешницы!");
            ValidateTextBox(legHeightTextBox.Text, "Введите, пожалуйста, высоту ножки!");
            ValidateTextBox(legLengthTextBox.Text, "Введите, пожалуйста, длину стороны ножки!");
            if (chkBoxBuildSeptums.Checked == true)
            {
                ValidateTextBox(txtBoxSeptumLength.Text, "Введите, пожалуйста, высоту разделителей!");
                ValidateTextBox(txtBoxSeptumOffset.Text, "Введите, пожалуйста, отступ разделителей от столешницы!");
            }

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
        /// <param name="txtBoxText">Текст поля на проверку</param>
        /// <param name="errorMessage">Сообщение ошибки для поля</param>
        private void ValidateTextBox(string txtBoxText, string errorMessage)
        {
            if (string.IsNullOrEmpty(txtBoxText) || int.Parse(txtBoxText) <= 0)
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

        /// <summary>
        /// Загрузка окна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            txtBoxSeptumLength.Enabled = false;
            txtBoxSeptumOffset.Enabled = false;
        }

        private void chkBoxBuildSeptums_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxBuildSeptums.Checked == true)
            {
                txtBoxSeptumLength.Enabled = true;
                txtBoxSeptumOffset.Enabled = true;
            }
            else
            {
                txtBoxSeptumLength.Enabled = false;
                txtBoxSeptumOffset.Enabled = false;
            }
        }
    }
}
