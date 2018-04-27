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
            this.txtBoxSeptumOffset = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBoxSeptumLength = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkBoxRoundedEdgesTabletop = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.legLengthTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.legHeightTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tableTopThicknessTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxTabletopLength = new System.Windows.Forms.TextBox();
            this.buttonBuildTable = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.chkBoxBuildSeptums = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.chkBoxBuildSeptums);
            this.groupBox1.Controls.Add(this.txtBoxSeptumOffset);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtBoxSeptumLength);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.chkBoxRoundedEdgesTabletop);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.legLengthTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.legHeightTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tableTopThicknessTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtBoxTabletopLength);
            this.groupBox1.Location = new System.Drawing.Point(17, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(581, 500);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Параметры столика";
            // 
            // txtBoxSeptumOffset
            // 
            this.txtBoxSeptumOffset.Location = new System.Drawing.Point(441, 384);
            this.txtBoxSeptumOffset.Name = "txtBoxSeptumOffset";
            this.txtBoxSeptumOffset.Size = new System.Drawing.Size(96, 26);
            this.txtBoxSeptumOffset.TabIndex = 12;
            this.txtBoxSeptumOffset.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HandleKeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 387);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(401, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Отступ разделителей от столешницы, мм (50..100) ";
            // 
            // txtBoxSeptumLength
            // 
            this.txtBoxSeptumLength.Location = new System.Drawing.Point(441, 331);
            this.txtBoxSeptumLength.Name = "txtBoxSeptumLength";
            this.txtBoxSeptumLength.Size = new System.Drawing.Size(96, 26);
            this.txtBoxSeptumLength.TabIndex = 10;
            this.txtBoxSeptumLength.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HandleKeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 337);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(310, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Высота разделителя ножек, мм (20..50)";
            // 
            // chkBoxRoundedEdgesTabletop
            // 
            this.chkBoxRoundedEdgesTabletop.AutoSize = true;
            this.chkBoxRoundedEdgesTabletop.Location = new System.Drawing.Point(27, 433);
            this.chkBoxRoundedEdgesTabletop.Name = "chkBoxRoundedEdgesTabletop";
            this.chkBoxRoundedEdgesTabletop.Size = new System.Drawing.Size(258, 24);
            this.chkBoxRoundedEdgesTabletop.TabIndex = 8;
            this.chkBoxRoundedEdgesTabletop.Text = "Закруглить края столешницы";
            this.chkBoxRoundedEdgesTabletop.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 230);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(264, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Длина стороны ножки, мм (30..60)";
            // 
            // legLengthTextBox
            // 
            this.legLengthTextBox.Location = new System.Drawing.Point(441, 230);
            this.legLengthTextBox.Name = "legLengthTextBox";
            this.legLengthTextBox.Size = new System.Drawing.Size(96, 26);
            this.legLengthTextBox.TabIndex = 6;
            this.legLengthTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HandleKeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(222, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Высота ножек, мм (150..450)";
            // 
            // legHeightTextBox
            // 
            this.legHeightTextBox.Location = new System.Drawing.Point(441, 171);
            this.legHeightTextBox.Name = "legHeightTextBox";
            this.legHeightTextBox.Size = new System.Drawing.Size(96, 26);
            this.legHeightTextBox.TabIndex = 4;
            this.legHeightTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HandleKeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(274, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Толщина столешницы, мм (30..100)";
            // 
            // tableTopThicknessTextBox
            // 
            this.tableTopThicknessTextBox.Location = new System.Drawing.Point(441, 113);
            this.tableTopThicknessTextBox.Name = "tableTopThicknessTextBox";
            this.tableTopThicknessTextBox.Size = new System.Drawing.Size(96, 26);
            this.tableTopThicknessTextBox.TabIndex = 2;
            this.tableTopThicknessTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HandleKeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(332, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Длина стороны столешницы, мм (500..900)";
            // 
            // txtBoxTabletopLength
            // 
            this.txtBoxTabletopLength.Location = new System.Drawing.Point(441, 59);
            this.txtBoxTabletopLength.Name = "txtBoxTabletopLength";
            this.txtBoxTabletopLength.Size = new System.Drawing.Size(96, 26);
            this.txtBoxTabletopLength.TabIndex = 0;
            this.txtBoxTabletopLength.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HandleKeyPress);
            // 
            // buttonBuildTable
            // 
            this.buttonBuildTable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBuildTable.Location = new System.Drawing.Point(127, 545);
            this.buttonBuildTable.Name = "buttonBuildTable";
            this.buttonBuildTable.Size = new System.Drawing.Size(335, 55);
            this.buttonBuildTable.TabIndex = 1;
            this.buttonBuildTable.Text = "Построить столик";
            this.buttonBuildTable.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // chkBoxBuildSeptums
            // 
            this.chkBoxBuildSeptums.AutoSize = true;
            this.chkBoxBuildSeptums.Location = new System.Drawing.Point(27, 286);
            this.chkBoxBuildSeptums.Name = "chkBoxBuildSeptums";
            this.chkBoxBuildSeptums.Size = new System.Drawing.Size(224, 24);
            this.chkBoxBuildSeptums.TabIndex = 13;
            this.chkBoxBuildSeptums.Text = "Построить разделители ";
            this.chkBoxBuildSeptums.UseVisualStyleBackColor = true;
            this.chkBoxBuildSeptums.CheckedChanged += new System.EventHandler(this.chkBoxBuildSeptums_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 622);
            this.Controls.Add(this.buttonBuildTable);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.Text = "Журнальный столик ";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

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
    }
}

