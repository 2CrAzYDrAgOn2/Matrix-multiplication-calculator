namespace WinFormsApp2
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridViewA = new DataGridView();
            comboBox = new ComboBox();
            calculateButton = new Button();
            clearButton = new Button();
            exitButton = new Button();
            dataGridViewB = new DataGridView();
            dataGridViewC = new DataGridView();
            wordButton = new Button();
            excelButton = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewA).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewB).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewC).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewA
            // 
            dataGridViewA.AllowUserToAddRows = false;
            dataGridViewA.AllowUserToDeleteRows = false;
            dataGridViewA.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewA.Location = new Point(13, 12);
            dataGridViewA.Margin = new Padding(4, 3, 4, 3);
            dataGridViewA.Name = "dataGridViewA";
            dataGridViewA.RowTemplate.Height = 25;
            dataGridViewA.Size = new Size(250, 250);
            dataGridViewA.TabIndex = 0;
            // 
            // comboBox
            // 
            comboBox.Anchor = AnchorStyles.Top;
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox.FormattingEnabled = true;
            comboBox.Items.AddRange(new object[] { "2x2", "3x3", "4x4", "5x5", "6x6", "7x7" });
            comboBox.Location = new Point(311, 12);
            comboBox.Margin = new Padding(4, 3, 4, 3);
            comboBox.Name = "comboBox";
            comboBox.Size = new Size(140, 23);
            comboBox.TabIndex = 1;
            comboBox.SelectedIndexChanged += comboBox_SelectedIndexChanged;
            // 
            // calculateButton
            // 
            calculateButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            calculateButton.Location = new Point(13, 574);
            calculateButton.Margin = new Padding(4, 3, 4, 3);
            calculateButton.Name = "calculateButton";
            calculateButton.Size = new Size(100, 50);
            calculateButton.TabIndex = 2;
            calculateButton.Text = "Рассчитать";
            calculateButton.UseVisualStyleBackColor = true;
            calculateButton.Click += calculateButton_Click;
            // 
            // clearButton
            // 
            clearButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            clearButton.Location = new Point(121, 574);
            clearButton.Margin = new Padding(4, 3, 4, 3);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(100, 50);
            clearButton.TabIndex = 3;
            clearButton.Text = "Очистить";
            clearButton.UseVisualStyleBackColor = true;
            clearButton.Click += clearButton_Click;
            // 
            // exitButton
            // 
            exitButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            exitButton.Location = new Point(663, 573);
            exitButton.Margin = new Padding(4, 3, 4, 3);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(100, 50);
            exitButton.TabIndex = 4;
            exitButton.Text = "Выйти";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += exitButton_Click;
            // 
            // dataGridViewB
            // 
            dataGridViewB.AllowUserToAddRows = false;
            dataGridViewB.AllowUserToDeleteRows = false;
            dataGridViewB.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dataGridViewB.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewB.Location = new Point(508, 12);
            dataGridViewB.Margin = new Padding(4, 3, 4, 3);
            dataGridViewB.Name = "dataGridViewB";
            dataGridViewB.RowTemplate.Height = 25;
            dataGridViewB.Size = new Size(250, 250);
            dataGridViewB.TabIndex = 5;
            // 
            // dataGridViewC
            // 
            dataGridViewC.AllowUserToAddRows = false;
            dataGridViewC.AllowUserToDeleteRows = false;
            dataGridViewC.Anchor = AnchorStyles.Top;
            dataGridViewC.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewC.Enabled = false;
            dataGridViewC.Location = new Point(13, 293);
            dataGridViewC.Margin = new Padding(4, 3, 4, 3);
            dataGridViewC.Name = "dataGridViewC";
            dataGridViewC.RowTemplate.Height = 25;
            dataGridViewC.Size = new Size(750, 250);
            dataGridViewC.TabIndex = 6;
            // 
            // wordButton
            // 
            wordButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            wordButton.Location = new Point(229, 574);
            wordButton.Margin = new Padding(4, 3, 4, 3);
            wordButton.Name = "wordButton";
            wordButton.Size = new Size(100, 50);
            wordButton.TabIndex = 7;
            wordButton.Text = "Показать в Word";
            wordButton.UseVisualStyleBackColor = true;
            wordButton.Click += wordButton_Click;
            // 
            // excelButton
            // 
            excelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            excelButton.Location = new Point(337, 574);
            excelButton.Margin = new Padding(4, 3, 4, 3);
            excelButton.Name = "excelButton";
            excelButton.Size = new Size(100, 50);
            excelButton.TabIndex = 8;
            excelButton.Text = "Показать в Excel";
            excelButton.UseVisualStyleBackColor = true;
            excelButton.Click += excelButton_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(270, 38);
            label1.Name = "label1";
            label1.Size = new Size(231, 25);
            label1.TabIndex = 9;
            label1.Text = "Инструкция к программе: ";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(64, 265);
            label2.Name = "label2";
            label2.Size = new Size(148, 25);
            label2.TabIndex = 10;
            label2.Text = "Первая матрица";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(556, 265);
            label3.Name = "label3";
            label3.Size = new Size(144, 25);
            label3.TabIndex = 11;
            label3.Text = "Вторая матрица";
            label3.TextAlign = ContentAlignment.TopCenter;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(348, 546);
            label4.Name = "label4";
            label4.Size = new Size(59, 25);
            label4.TabIndex = 12;
            label4.Text = "Ответ";
            label4.TextAlign = ContentAlignment.TopCenter;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(774, 636);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(excelButton);
            Controls.Add(wordButton);
            Controls.Add(dataGridViewC);
            Controls.Add(dataGridViewB);
            Controls.Add(exitButton);
            Controls.Add(clearButton);
            Controls.Add(calculateButton);
            Controls.Add(comboBox);
            Controls.Add(dataGridViewA);
            Margin = new Padding(4, 3, 4, 3);
            Name = "MainForm";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridViewA).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewB).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewC).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewA;
        private ComboBox comboBox;
        private Button calculateButton;
        private Button clearButton;
        private Button exitButton;
        private DataGridView dataGridViewB;
        private DataGridView dataGridViewC;
        private Button wordButton;
        private Button excelButton;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}