using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Data;

namespace WinFormsApp2
{
    public partial class MainForm : Form
    {
        public double[,] matrixA;
        public double[,] matrixB;
        public double[,] matrixC;
        public double[][] dataForOffice = new double[3][];

        public MainForm()
        {
            InitializeComponent();
            comboBox.SelectedIndex = 0;
        }

        /// <summary>
        /// calculateButton_Click выполняет действия при нажатии на кнопку "Рассчитать"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void calculateButton_Click(object sender, EventArgs e)
        {
            try
            {
                matrixA = GetMatrixFromDataGridView(dataGridViewA);
                matrixB = GetMatrixFromDataGridView(dataGridViewB);
                matrixC = MultiplyMatrix(matrixA, matrixB);
                ShowMatrixInDataGridView(matrixC, dataGridViewC);
                dataForOffice[0] = new double[matrixA.GetLength(0) * matrixA.GetLength(1)];
                dataForOffice[1] = new double[matrixB.GetLength(0) * matrixB.GetLength(1)];
                dataForOffice[2] = new double[matrixC.GetLength(0) * matrixC.GetLength(1)];
                int index = 0;
                for (int i = 0; i < matrixA.GetLength(0); i++)
                {
                    for (int j = 0; j < matrixA.GetLength(1); j++)
                    {
                        dataForOffice[0][index] = matrixA[i, j];
                        index++;
                    }
                }
                index = 0;
                for (int i = 0; i < matrixB.GetLength(0); i++)
                {
                    for (int j = 0; j < matrixB.GetLength(1); j++)
                    {
                        dataForOffice[1][index] = matrixB[i, j];
                        index++;
                    }
                }
                index = 0;
                for (int i = 0; i < matrixC.GetLength(0); i++)
                {
                    for (int j = 0; j < matrixC.GetLength(1); j++)
                    {
                        dataForOffice[2][index] = matrixC[i, j];
                        index++;
                    }
                }
                MessageBox.Show("Рассчёт выполнен!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        /// <summary>
        /// clearButton_Click выполняет действия по нажатию кнопки "Очистить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearButton_Click(object sender, EventArgs e)
        {
            Clear(dataGridViewA);
            Clear(dataGridViewB);
            Clear(dataGridViewC);
        }

        /// <summary>
        /// exitButton_Click выполняет действия по нажатию кнопки "Выйти"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// wordButton_Click выполняет действия по нажатию кнопки "Показать в Word"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void wordButton_Click(object sender, EventArgs e)
        {
            ShowMatrixInWord("word.docx", matrixA, matrixB, matrixC);
        }

        /// <summary>
        /// excelButton_Click выполняет действия по нажатию кнопки "Показать в Excel"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void excelButton_Click(object sender, EventArgs e)
        {
            ShowMatrixInExcel("excel.xlsx", matrixA, matrixB, matrixC);
        }

        /// <summary>
        /// GetMatrixFromDataGridView получает матрицу из dataGridView
        /// </summary>
        /// <param name="matrixDataGridView"></param>
        /// <returns></returns>
        private static double[,] GetMatrixFromDataGridView(DataGridView matrixDataGridView)
        {
            int rows = matrixDataGridView.RowCount;
            int columns = matrixDataGridView.ColumnCount;
            double[,] matrix = new double[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = EvaluateExpression(Convert.ToString(matrixDataGridView.Rows[i].Cells[j].Value));
                }
            }
            return matrix;
        }

        /// <summary>
        /// MultiplyMatrix рассчитывает умножение матриц
        /// </summary>
        /// <param name="matrixA"></param>
        /// <param name="matrixB"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        private static double[,] MultiplyMatrix(double[,] matrixA, double[,] matrixB)
        {
            int rowsA = matrixA.GetLength(0);
            int colsA = matrixA.GetLength(1);
            int rowsB = matrixB.GetLength(0);
            int colsB = matrixB.GetLength(1);
            if (colsA != rowsB)
            {
                throw new ArgumentException("Невозможно умножить матрицы: неправильные размеры");
            }
            double[,] result = new double[rowsA, colsB];
            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < colsB; j++)
                {
                    double sum = 0;
                    for (int k = 0; k < colsA; k++)
                    {
                        sum += matrixA[i, k] * matrixB[k, j];
                    }
                    result[i, j] = sum;
                }
            }
            return result;
        }

        /// <summary>
        /// EvaluateExpression преобразует выражения в числа
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        private static double EvaluateExpression(string expression)
        {
            try
            {
                expression = expression.Replace(" ", ""); // удаление пробелов из выражения
                System.Data.DataTable dt = new(); // создание объекта для вычисления математических выражений
                var result = dt.Compute(expression, ""); // вычисление математических выражений
                return Convert.ToDouble(result); // возврат результата
            }
            catch (Exception ex)
            {
                expression = "0";
                MessageBox.Show($"Ошибка в {expression}: " + ex.Message + "Все поля с ошибками были приравнены к 0"); // вывод ошибки
                return 0.0;
            }
        }

        /// <summary>
        /// ShowMatrixInDataGridView показывает матрицу в dataGridView
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="matrixDataGridView"></param>
        private static void ShowMatrixInDataGridView(double[,] matrix, DataGridView matrixDataGridView)
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            matrixDataGridView.Rows.Clear();
            matrixDataGridView.Columns.Clear();
            for (int j = 0; j < columns; j++)
            {
                matrixDataGridView.Columns.Add("Column" + (j + 1), "Column " + (j + 1));
            }
            for (int i = 0; i < rows; i++)
            {
                DataGridViewRow row = new();
                row.CreateCells(matrixDataGridView);

                for (int j = 0; j < columns; j++)
                {
                    row.Cells[j].Value = matrix[i, j].ToString();
                }
                matrixDataGridView.Rows.Add(row);
            }
        }

        /// <summary>
        /// ShowMatrixInWord показывает матрицы в Word
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="matrixA"></param>
        /// <param name="matrixB"></param>
        /// <param name="matrixC"></param>
        private static void ShowMatrixInWord(string fileName, double[,] matrixA, double[,] matrixB, double[,] matrixC)
        {
            using WordprocessingDocument wordDocument = WordprocessingDocument.Create(fileName, WordprocessingDocumentType.Document);
            MainDocumentPart mainDocumentPart = wordDocument.AddMainDocumentPart();
            mainDocumentPart.Document = new Document();
            Body body = mainDocumentPart.Document.AppendChild(new Body());
            void AddMatrix(double[,] matrix)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    Paragraph paragraph = new();
                    DocumentFormat.OpenXml.Wordprocessing.Run run = new();
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        run.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Text($"{matrix[i, j]}     "));
                    }
                    paragraph.Append(run);
                    body.Append(paragraph);
                }
                body.Append(new Paragraph(new DocumentFormat.OpenXml.Wordprocessing.Run(new DocumentFormat.OpenXml.Wordprocessing.Break())));
            }
            AddMatrix(matrixA);
            AddMatrix(matrixB);
            AddMatrix(matrixC);
            mainDocumentPart.Document.Save();
            wordDocument.Close();
        }

        /// <summary>
        /// ShowMatrixInExcel показывает матрицы в Excel
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="matrixA"></param>
        /// <param name="matrixB"></param>
        /// <param name="matrixC"></param>
        private static void ShowMatrixInExcel(string fileName, double[,] matrixA, double[,] matrixB, double[,] matrixC)
        {
            using SpreadsheetDocument excelDocument = SpreadsheetDocument.Create(fileName, SpreadsheetDocumentType.Workbook);
            WorkbookPart workbookPart = excelDocument.AddWorkbookPart();
            workbookPart.Workbook = new Workbook();
            WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
            worksheetPart.Worksheet = new Worksheet(new SheetData());
            excelDocument.WorkbookPart.Workbook.Sheets = new Sheets();
            Sheets sheets = excelDocument.WorkbookPart.Workbook.GetFirstChild<Sheets>();
            string relationshipId = excelDocument.WorkbookPart.GetIdOfPart(worksheetPart);
            uint sheetId = 1;
            sheets.Append(new Sheet() { Id = relationshipId, SheetId = sheetId, Name = "Матрицы" });
            SheetData sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();
            void AddMatrix(double[,] matrix)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    Row newRow = new();
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        Cell cell = new()
                        {
                            DataType = CellValues.Number,
                            CellValue = new CellValue(matrix[i, j].ToString())
                        };
                        newRow.Append(cell);
                    }
                    sheetData.Append(newRow);
                }
            }
            AddMatrix(matrixA);
            AddMatrix(matrixB);
            AddMatrix(matrixC);
            workbookPart.Workbook.Save();
        }

        /// <summary>
        /// Clear очищает dataGridView
        /// </summary>
        /// <param name="dataGridView"></param>
        private static void Clear(DataGridView dataGridView)
        {
            int rows = dataGridView.RowCount;
            int columns = dataGridView.ColumnCount;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    dataGridView.Rows[i].Cells[j].Value = "";
                }
            }
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedOption = comboBox.SelectedItem.ToString();
            int rows, columns;
            if (selectedOption == "2x2")
            {
                rows = 2;
                columns = 2;
            }
            else if (selectedOption == "3x3")
            {
                rows = 3;
                columns = 3;
            }
            else if (selectedOption == "4x4")
            {
                rows = 4;
                columns = 4;
            }
            else if (selectedOption == "5x5")
            {
                rows = 5;
                columns = 5;
            }
            else if (selectedOption == "6x6")
            {
                rows = 6;
                columns = 6;
            }
            else if (selectedOption == "7x7")
            {
                rows = 7;
                columns = 7;
            }
            else
            {
                return;
            }
            CreateMatrixAndDisplayInDataGridView(rows, columns, dataGridViewA);
            CreateMatrixAndDisplayInDataGridView(rows, columns, dataGridViewB);
            CreateMatrixAndDisplayInDataGridView(rows, columns, dataGridViewC);
        }

        private static void CreateMatrixAndDisplayInDataGridView(int rows, int columns, DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();
            for (int j = 0; j < columns; j++)
            {
                dataGridView.Columns.Add("col" + j, "Column " + j);
            }
            for (int i = 0; i < rows; i++)
            {
                DataGridViewRow row = new();
                row.CreateCells(dataGridView);
                for (int j = 0; j < columns; j++)
                {
                    row.Cells[j].Value = 0;
                }
                dataGridView.Rows.Add(row);
            }
        }
    }
}