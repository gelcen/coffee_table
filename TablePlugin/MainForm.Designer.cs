namespace TablePlugin
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.legLengthTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.legHeightTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tableTopThicknessTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxTabletopLength = new System.Windows.Forms.TextBox();
            this.chkBoxBuildSeptums = new System.Windows.Forms.CheckBox();
            this.txtBoxSeptumOffset = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBoxSeptumLength = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkBoxRoundedEdgesTabletop = new System.Windows.Forms.CheckBox();
            this.buttonBuildTable = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.legLengthTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.legHeightTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tableTopThicknessTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtBoxTabletopLength);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(463, 173);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Габариты столика";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(264, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Длина стороны ножки, мм (30..60)";
            // 
            // legLengthTextBox
            // 
            this.legLengthTextBox.Location = new System.Drawing.Point(344, 128);
            this.legLengthTextBox.Name = "legLengthTextBox";
            this.legLengthTextBox.Size = new System.Drawing.Size(96, 26);
            this.legLengthTextBox.TabIndex = 6;
            this.legLengthTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HandleKeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(222, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Высота ножек, мм (150..450)";
            // 
            // legHeightTextBox
            // 
            this.legHeightTextBox.Location = new System.Drawing.Point(344, 96);
            this.legHeightTextBox.Name = "legHeightTextBox";
            this.legHeightTextBox.Size = new System.Drawing.Size(96, 26);
            this.legHeightTextBox.TabIndex = 4;
            this.legHeightTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HandleKeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(274, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Толщина столешницы, мм (30..100)";
            // 
            // tableTopThicknessTextBox
            // 
            this.tableTopThicknessTextBox.Location = new System.Drawing.Point(344, 64);
            this.tableTopThicknessTextBox.Name = "tableTopThicknessTextBox";
            this.tableTopThicknessTextBox.Size = new System.Drawing.Size(96, 26);
            this.tableTopThicknessTextBox.TabIndex = 2;
            this.tableTopThicknessTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HandleKeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(332, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Длина стороны столешницы, мм (500..900)";
            // 
            // txtBoxTabletopLength
            // 
            this.txtBoxTabletopLength.Location = new System.Drawing.Point(344, 32);
            this.txtBoxTabletopLength.Name = "txtBoxTabletopLength";
            this.txtBoxTabletopLength.Size = new System.Drawing.Size(96, 26);
            this.txtBoxTabletopLength.TabIndex = 0;
            this.txtBoxTabletopLength.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HandleKeyPress);
            // 
            // chkBoxBuildSeptums
            // 
            this.chkBoxBuildSeptums.AutoSize = true;
            this.chkBoxBuildSeptums.Location = new System.Drawing.Point(6, 38);
            this.chkBoxBuildSeptums.Name = "chkBoxBuildSeptums";
            this.chkBoxBuildSeptums.Size = new System.Drawing.Size(224, 24);
            this.chkBoxBuildSeptums.TabIndex = 13;
            this.chkBoxBuildSeptums.Text = "Построить разделители ";
            this.chkBoxBuildSeptums.UseVisualStyleBackColor = true;
            this.chkBoxBuildSeptums.CheckedChanged += new System.EventHandler(this.chkBoxBuildSeptums_CheckedChanged);
            // 
            // txtBoxSeptumOffset
            // 
            this.txtBoxSeptumOffset.Location = new System.Drawing.Point(344, 102);
            this.txtBoxSeptumOffset.Name = "txtBoxSeptumOffset";
            this.txtBoxSeptumOffset.Size = new System.Drawing.Size(96, 26);
            this.txtBoxSeptumOffset.TabIndex = 12;
            this.txtBoxSeptumOffset.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HandleKeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(279, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Отступ разделителей, мм (50..100) ";
            // 
            // txtBoxSeptumLength
            // 
            this.txtBoxSeptumLength.Location = new System.Drawing.Point(344, 70);
            this.txtBoxSeptumLength.Name = "txtBoxSeptumLength";
            this.txtBoxSeptumLength.Size = new System.Drawing.Size(96, 26);
            this.txtBoxSeptumLength.TabIndex = 10;
            this.txtBoxSeptumLength.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HandleKeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(310, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Высота разделителя ножек, мм (20..50)";
            // 
            // chkBoxRoundedEdgesTabletop
            // 
            this.chkBoxRoundedEdgesTabletop.AutoSize = true;
            this.chkBoxRoundedEdgesTabletop.Location = new System.Drawing.Point(18, 342);
            this.chkBoxRoundedEdgesTabletop.Name = "chkBoxRoundedEdgesTabletop";
            this.chkBoxRoundedEdgesTabletop.Size = new System.Drawing.Size(258, 24);
            this.chkBoxRoundedEdgesTabletop.TabIndex = 8;
            this.chkBoxRoundedEdgesTabletop.Text = "Закруглить края столешницы";
            this.chkBoxRoundedEdgesTabletop.UseVisualStyleBackColor = true;
            // 
            // buttonBuildTable
            // 
            this.buttonBuildTable.Location = new System.Drawing.Point(12, 372);
            this.buttonBuildTable.Name = "buttonBuildTable";
            this.buttonBuildTable.Size = new System.Drawing.Size(463, 55);
            this.buttonBuildTable.TabIndex = 1;
            this.buttonBuildTable.Text = "Построить столик";
            this.buttonBuildTable.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkBoxBuildSeptums);
            this.groupBox2.Controls.Add(this.txtBoxSeptumLength);
            this.groupBox2.Controls.Add(this.txtBoxSeptumOffset);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(12, 191);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(463, 145);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Параметры разделителей";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 443);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.buttonBuildTable);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkBoxRoundedEdgesTabletop);
            this.Name = "MainForm";
            this.Text = "Журнальный столик ";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonBuildTable;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox legLengthTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox legHeightTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tableTopThicknessTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoxTabletopLength;
        private System.Windows.Forms.CheckBox chkBoxRoundedEdgesTabletop;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox txtBoxSeptumOffset;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBoxSeptumLength;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkBoxBuildSeptums;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

