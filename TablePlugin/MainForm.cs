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

        public MainForm()
        {
            InitializeComponent();
            buttonBuildTable.Click += ButtonBuildTable_Click;
            _tableSettings = new TableSettings();
        }

        /// <summary>
        /// Обработчик нажатия на кнопку построения столика
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonBuildTable_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                if (BuildClick != null) BuildClick(this, EventArgs.Empty);
                MessageBox.Show("TabletopLength: {0}, TabletopThickness: {1}, LegHeigth: {2}, LegLength: {3}");
                Console.WriteLine("TabletopLength: {0}, TabletopThickness: {1}, LegHeigth: {2}, LegLength: {3}", _tableSettings.TabletopLength, _tableSettings.TabletopThickness, _tableSettings.LegHeight, _tableSettings.LegLength);
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
        /// Обработчик события валидации поля txtBoxTabletopLength
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_Validating(object sender, CancelEventArgs e, TextBox textBox, int propertyNumber, string emptyErrorMessage)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                e.Cancel = true;
                textBox.Focus();
                errorProvider1.SetError(textBox, emptyErrorMessage);
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox, null);
            }
            if (!string.IsNullOrEmpty(textBox.Text))
            {
                try
                {
                    _tableSettings = new TableSettings(Convert.ToInt32(textBox.Text), propertyNumber);
                    e.Cancel = false;
                    errorProvider1.SetError(textBox, null);
                }
                catch (ArgumentException ex)
                {
                    e.Cancel = true;
                    textBox.Focus();
                    errorProvider1.SetError(textBox, ex.Message);
                }
            }
        }

        private void txtBoxTabletopLength_Validating(object sender, CancelEventArgs e)
        {
            //if (string.IsNullOrEmpty(txtBoxTabletopLength.Text))
            //{
            //    e.Cancel = true;
            //    txtBoxTabletopLength.Focus();
            //    Console.WriteLine(sender.ToString());
            //    errorProvider1.SetError(txtBoxTabletopLength, "Введите, пожалуйста, длину стороны столешницы!");
            //}
            //else
            //{
            //    e.Cancel = false;
            //    errorProvider1.SetError(txtBoxTabletopLength, null);
            //}
            //if (!string.IsNullOrEmpty(txtBoxTabletopLength.Text))
            //{
            //    try
            //    {
            //        _tableSettings.TabletopLength = Convert.ToInt32(txtBoxTabletopLength.Text);
            //        e.Cancel = false;
            //        errorProvider1.SetError(txtBoxTabletopLength, null);
            //    }
            //    catch (ArgumentException ex)
            //    {
            //        e.Cancel = true;
            //        txtBoxTabletopLength.Focus();
            //        errorProvider1.SetError(txtBoxTabletopLength, ex.Message);
            //    }
            //}
            TextBox_Validating(sender, e, txtBoxTabletopLength, 1, "Введите, пожалуйста, длину стороны столешницы!");
        }

        /// <summary>
        /// Обработчик события валидации поля tableTopThicknessTextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tableTopThicknessTextBox_Validating(object sender, CancelEventArgs e)
        {
            //if (string.IsNullOrEmpty(tableTopThicknessTextBox.Text))
            //{
            //    e.Cancel = true;
            //    tableTopThicknessTextBox.Focus();
            //    errorProvider1.SetError(tableTopThicknessTextBox, "Введите, пожалуйста, толщину столешницы!");
            //}
            //else
            //{
            //    e.Cancel = false;
            //    errorProvider1.SetError(tableTopThicknessTextBox, null);
            //}
            //if (!string.IsNullOrEmpty(tableTopThicknessTextBox.Text))
            //{
            //    try
            //    {
            //        _tableSettings.TabletopThickness = Convert.ToInt32(tableTopThicknessTextBox.Text);
            //        e.Cancel = false;
            //        errorProvider1.SetError(tableTopThicknessTextBox, null);
            //    }
            //    catch (Exception ex)
            //    {
            //        e.Cancel = true;
            //        tableTopThicknessTextBox.Focus();
            //        errorProvider1.SetError(tableTopThicknessTextBox, ex.Message);
            //    }
            //}
            TextBox_Validating(sender, e, tableTopThicknessTextBox, 2, "Введите, пожалуйста, толщину столешницы!");
        }

        /// <summary>
        /// Обработчик события валидации поля legHeightTextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void legHeightTextBox_Validating(object sender, CancelEventArgs e)//1.Dublirovanie2.Incapsulatia3.Komment parametri funcii
        {
            if (string.IsNullOrEmpty(legHeightTextBox.Text))
            {
                e.Cancel = true;
                legHeightTextBox.Focus();
                errorProvider1.SetError(legHeightTextBox, "Введите, пожалуйста, высоту ножки!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(legHeightTextBox, null);
            }
            if (!string.IsNullOrEmpty(legHeightTextBox.Text))
            {
                try
                {
                    _tableSettings.LegHeight = Convert.ToInt32(legHeightTextBox.Text);
                    e.Cancel = false;
                    errorProvider1.SetError(legHeightTextBox, null);
                }
                catch (Exception ex)
                {
                    e.Cancel = true;
                    legHeightTextBox.Focus();
                    errorProvider1.SetError(legHeightTextBox, ex.Message);
                }
            }
            
        }

        /// <summary>
        /// Обработчик события валидации поля legLengthTextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void legLengthTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(legLengthTextBox.Text))
            {
                e.Cancel = true;
                legLengthTextBox.Focus();
                errorProvider1.SetError(legLengthTextBox, "Введите, пожалуйста, длину стороны ножки!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(legLengthTextBox, null);
            }
            if (!string.IsNullOrEmpty(legLengthTextBox.Text))
            {
                try
                {
                    _tableSettings.LegLength = Convert.ToInt32(legLengthTextBox.Text);
                    e.Cancel = false;
                    errorProvider1.SetError(legLengthTextBox, null);
                }
                catch (ArgumentException ex)
                {
                    e.Cancel = true;
                    legLengthTextBox.Focus();
                    errorProvider1.SetError(legLengthTextBox, ex.Message);
                }
            }           
        }
        /// <summary>
        /// Обработчик события смены значения чек бокса
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkBoxRoundedEdgesTabletop_CheckedChanged(object sender, EventArgs e)
        {
            _tableSettings.RoundedEdgesTabletop = chkBoxRoundedEdgesTabletop.Checked;
        }
    }
}
