using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void chart1_Click(object sender, EventArgs e)
        {
            // Создаем график
            Chart chart = new Chart();
            chart.Dock = DockStyle.Fill;

            // Добавляем график на форму
            this.Controls.Add(chart);

            // Создаем новую область для графика
            ChartArea chartArea = new ChartArea();
            chart.ChartAreas.Add(chartArea);

            // Создаем серию данных для графика
            Series series = new Series();
            series.ChartType = SeriesChartType.Line; // Тип графика - линейный

            // Добавляем серию данных на график
            chart.Series.Add(series);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                // При нажатии кнопки, пересчитываем и перерисовываем график
                chart1.Series.Clear(); // Очищаем старые серии данных
                chart1.ChartAreas.Clear(); // Очищаем старые области графика

                // Создаем новую область для графика
                ChartArea chartArea = new ChartArea();
                chart1.ChartAreas.Add(chartArea);

                // Создаем новую серию данных для графика
                Series series = new Series();
                series.ChartType = SeriesChartType.Line; // Тип графика - линейный

                // Добавляем серию данных на график
                chart1.Series.Add(series);

                double minValue = -10;
                double maxValue = 10;
                double step = 1;

                for (double x = minValue; x <= maxValue; x += step)
                {
                    double y = CalculateFunction(x); // Вычисляем значение функции
                    chart1.Series[0].Points.AddXY(x, y); // Добавляем новые точки на график
                }
            }
        }

        private double CalculateFunction(double x)
        {
            try
            {
                // Получаем формулу из TextBox1
                string formula = textBox1.Text;

                // Заменяем "x" на текущее значение x в формуле
                formula = formula.Replace("x", x.ToString());

                // Создаем DataTable и DataAdapter для выполнения вычислений
                DataTable table = new DataTable();
                table.Columns.Add("expr", typeof(string), formula);

                // Вычисляем значение формулы
                DataRow row = table.NewRow();
                table.Rows.Add(row);

                double result = double.Parse((string)row["expr"]);
                return result;
            }
            catch (Exception)
            {
                // Если произошла ошибка при вычислениях, возвращаем 0
                return 0;
            }
        }

        
    }
}
