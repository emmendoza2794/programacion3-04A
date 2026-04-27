using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Graficas
{
    public partial class GraficasForm : Form
    {
        private readonly Random _rng = new Random(42);

        public GraficasForm()
        {
            InitializeComponent();
            this.Text = "Gráficas — MS Chart";
            this.Size = new Size(950, 700);

            cmbGrafica.Items.AddRange(new string[]
            {
                "Ventas mensuales",
                "Señal senoidal",
                "Dispersión de datos",
                "Comparativa de series",
                "Distribución por área"
            });
            cmbGrafica.SelectedIndex = 0;

            cmbTipo.Items.AddRange(new string[]
            {
                "Línea",
                "Barras",
                "Área",
                "Puntos",
                "Spline"
            });
            cmbTipo.SelectedIndex = 0;

            cmbGrafica.SelectedIndexChanged += (s, e) => ActualizarGrafica();
            cmbTipo.SelectedIndexChanged += (s, e) => ActualizarGrafica();

            ActualizarGrafica();
        }

        private void ActualizarGrafica()
        {
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
            chart1.Legends.Clear();
            chart1.Titles.Clear();

            // Área principal
            var area = new ChartArea("principal");
            area.BackColor = Color.FromArgb(30, 30, 30);
            area.AxisX.LineColor = Color.Gray;
            area.AxisY.LineColor = Color.Gray;
            area.AxisX.LabelStyle.ForeColor = Color.White;
            area.AxisY.LabelStyle.ForeColor = Color.White;
            area.AxisX.TitleForeColor = Color.White;
            area.AxisY.TitleForeColor = Color.White;
            area.AxisX.MajorGrid.LineColor = Color.FromArgb(60, 60, 60);
            area.AxisY.MajorGrid.LineColor = Color.FromArgb(60, 60, 60);
            chart1.ChartAreas.Add(area);

            // Fondo del chart
            chart1.BackColor = Color.FromArgb(20, 20, 20);
            chart1.ForeColor = Color.White;

            // Leyenda
            var leyenda = new Legend();
            leyenda.BackColor = Color.FromArgb(40, 40, 40);
            leyenda.ForeColor = Color.White;
            chart1.Legends.Add(leyenda);

            switch (cmbGrafica.SelectedIndex)
            {
                case 0: GraficaVentas(); break;
                case 1: GraficaSenoidal(); break;
                case 2: GraficaDispersion(); break;
                case 3: GraficaComparativa(); break;
                case 4: GraficaArea(); break;
            }
        }

        // -------------------------------------------------------
        // Tipo de serie según el ComboBox
        // -------------------------------------------------------
        private SeriesChartType ObtenerTipo()
        {
            switch (cmbTipo.SelectedIndex)
            {
                case 0: return SeriesChartType.Line;
                case 1: return SeriesChartType.Bar;
                case 2: return SeriesChartType.Area;
                case 3: return SeriesChartType.Point;
                case 4: return SeriesChartType.Spline;
                default: return SeriesChartType.Line;
            }
        }

        // -------------------------------------------------------
        // 1. Ventas mensuales
        // -------------------------------------------------------
        private void GraficaVentas()
        {
            chart1.Titles.Add(new Title("Ventas Mensuales 2024")
            { ForeColor = Color.White, Font = new Font("Arial", 13, FontStyle.Bold) });

            string[] meses = { "Ene","Feb","Mar","Abr","May","Jun",
                                 "Jul","Ago","Sep","Oct","Nov","Dic" };
            double[] ventas = { 42, 58, 55, 70, 88, 95,
                                 102, 98, 85, 76, 90, 115 };

            var serie = new Series("Ventas (millones $)");
            serie.ChartType = ObtenerTipo();
            serie.Color = Color.DeepSkyBlue;
            serie.BorderWidth = 3;
            serie.MarkerStyle = MarkerStyle.Circle;
            serie.MarkerSize = 8;
            serie.MarkerColor = Color.OrangeRed;

            for (int i = 0; i < meses.Length; i++)
                serie.Points.AddXY(meses[i], ventas[i]);

            chart1.Series.Add(serie);
            chart1.ChartAreas["principal"].AxisX.Title = "Mes";
            chart1.ChartAreas["principal"].AxisY.Title = "Millones ($)";
        }

        // -------------------------------------------------------
        // 2. Señal senoidal
        // -------------------------------------------------------
        private void GraficaSenoidal()
        {
            chart1.Titles.Add(new Title("Señal Senoidal Compuesta")
            { ForeColor = Color.White, Font = new Font("Arial", 13, FontStyle.Bold) });

            var s1 = new Series("sin(x)");
            s1.ChartType = SeriesChartType.Spline;
            s1.Color = Color.DeepSkyBlue;
            s1.BorderWidth = 2;

            var s2 = new Series("sin(2x) * 0.5");
            s2.ChartType = SeriesChartType.Spline;
            s2.Color = Color.OrangeRed;
            s2.BorderWidth = 2;

            var s3 = new Series("Suma");
            s3.ChartType = SeriesChartType.Spline;
            s3.Color = Color.LimeGreen;
            s3.BorderWidth = 3;

            for (int i = 0; i <= 200; i++)
            {
                double x = i * 0.1;
                double y1 = Math.Sin(x);
                double y2 = Math.Sin(2 * x) * 0.5;
                s1.Points.AddXY(x, y1);
                s2.Points.AddXY(x, y2);
                s3.Points.AddXY(x, y1 + y2);
            }

            chart1.Series.Add(s1);
            chart1.Series.Add(s2);
            chart1.Series.Add(s3);
            chart1.ChartAreas["principal"].AxisX.Title = "Tiempo";
            chart1.ChartAreas["principal"].AxisY.Title = "Amplitud";
        }

        // -------------------------------------------------------
        // 3. Dispersión de datos
        // -------------------------------------------------------
        private void GraficaDispersion()
        {
            chart1.Titles.Add(new Title("Dispersión — Dos Grupos")
            { ForeColor = Color.White, Font = new Font("Arial", 13, FontStyle.Bold) });

            var gA = new Series("Grupo A");
            gA.ChartType = SeriesChartType.Point;
            gA.Color = Color.DeepSkyBlue;
            gA.MarkerStyle = MarkerStyle.Circle;
            gA.MarkerSize = 8;

            var gB = new Series("Grupo B");
            gB.ChartType = SeriesChartType.Point;
            gB.Color = Color.OrangeRed;
            gB.MarkerStyle = MarkerStyle.Square;
            gB.MarkerSize = 8;

            for (int i = 0; i < 100; i++)
            {
                gA.Points.AddXY(
                    2 + (_rng.NextDouble() - 0.5) * 4,
                    3 + (_rng.NextDouble() - 0.5) * 4);
                gB.Points.AddXY(
                    7 + (_rng.NextDouble() - 0.5) * 4,
                    8 + (_rng.NextDouble() - 0.5) * 4);
            }

            chart1.Series.Add(gA);
            chart1.Series.Add(gB);
            chart1.ChartAreas["principal"].AxisX.Title = "Variable X";
            chart1.ChartAreas["principal"].AxisY.Title = "Variable Y";
        }

        // -------------------------------------------------------
        // 4. Comparativa de series
        // -------------------------------------------------------
        private void GraficaComparativa()
        {
            chart1.Titles.Add(new Title("Temperatura — Tres Ciudades")
            { ForeColor = Color.White, Font = new Font("Arial", 13, FontStyle.Bold) });

            string[] meses = { "Ene","Feb","Mar","Abr","May","Jun",
                                "Jul","Ago","Sep","Oct","Nov","Dic" };

            double[] bogota = { 14, 15, 15, 15, 14, 14, 13, 14, 14, 15, 15, 14 };
            double[] cartagena = { 28, 29, 30, 31, 32, 32, 32, 32, 31, 30, 29, 28 };
            double[] medellin = { 22, 22, 23, 23, 23, 22, 22, 22, 22, 23, 22, 22 };

            Color[] colores = { Color.DeepSkyBlue, Color.OrangeRed, Color.LimeGreen };
            string[] nombres = { "Bogotá", "Cartagena", "Medellín" };
            double[][] datos = { bogota, cartagena, medellin };

            for (int s = 0; s < 3; s++)
            {
                var serie = new Series(nombres[s]);
                serie.ChartType = ObtenerTipo();
                serie.Color = colores[s];
                serie.BorderWidth = 2;
                serie.MarkerStyle = MarkerStyle.Circle;
                serie.MarkerSize = 6;

                for (int i = 0; i < meses.Length; i++)
                    serie.Points.AddXY(meses[i], datos[s][i]);

                chart1.Series.Add(serie);
            }

            chart1.ChartAreas["principal"].AxisX.Title = "Mes";
            chart1.ChartAreas["principal"].AxisY.Title = "°C";
        }

        // -------------------------------------------------------
        // 5. Distribución por área
        // -------------------------------------------------------
        private void GraficaArea()
        {
            chart1.Titles.Add(new Title("Distribución de Energía")
            { ForeColor = Color.White, Font = new Font("Arial", 13, FontStyle.Bold) });

            string[] fuentes = { "Solar", "Eólica", "Hidro", "Gas", "Carbón" };
            double[] valores = { 25, 30, 20, 15, 10 };
            Color[] colores = {
                Color.Gold,
                Color.DeepSkyBlue,
                Color.MediumSeaGreen,
                Color.OrangeRed,
                Color.Gray
            };

            var serie = new Series("Energía");
            serie.ChartType = SeriesChartType.Pie;
            serie["PieLabelStyle"] = "Outside";
            serie["PieLineColor"] = "White";
            serie["PieDrawingStyle"] = "SoftEdge";

            for (int i = 0; i < fuentes.Length; i++)
            {
                var punto = serie.Points.Add(valores[i]);
                punto.LegendText = fuentes[i];
                punto.Label = $"{fuentes[i]}\n{valores[i]}%";
                punto.Color = colores[i];
            }

            chart1.Series.Add(serie);
        }
    }
}