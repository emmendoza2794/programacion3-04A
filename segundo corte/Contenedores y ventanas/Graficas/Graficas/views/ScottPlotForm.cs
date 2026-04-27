using System;
using System.Windows.Forms;
using ScottPlot;

namespace Graficas
{
    public partial class ScottPlotForm : Form
    {
        private readonly Random _rng = new Random(42);

        public ScottPlotForm()
        {
            InitializeComponent();
            this.Text = "Gráficas — ScottPlot";
            this.Size = new System.Drawing.Size(950, 700);

            cmbFuncion.Items.AddRange(new string[]
            {
                "Señal sísmica",
                "Temperaturas mensuales",
                "Dispersión de grupos",
                "Poblaciones por país",
                "Señal con ruido"
            });
            cmbFuncion.SelectedIndex = 0;

            cmbColormap.Items.AddRange(new string[]
            {
                "Azul",
                "Rojo",
                "Verde",
                "Naranja"
            });
            cmbColormap.SelectedIndex = 0;

            cmbFuncion.SelectedIndexChanged += (s, e) => ActualizarGrafica();
            cmbColormap.SelectedIndexChanged += (s, e) => ActualizarGrafica();

            ActualizarGrafica();
        }

        private System.Drawing.Color ObtenerColor()
        {
            switch (cmbColormap.SelectedIndex)
            {
                case 0: return System.Drawing.Color.DeepSkyBlue;
                case 1: return System.Drawing.Color.OrangeRed;
                case 2: return System.Drawing.Color.LimeGreen;
                case 3: return System.Drawing.Color.Orange;
                default: return System.Drawing.Color.DeepSkyBlue;
            }
        }

        private void ActualizarGrafica()
        {
            formsPlot1.Plot.Clear();
            formsPlot1.Plot.Style(ScottPlot.Style.Blue2);

            switch (cmbFuncion.SelectedIndex)
            {
                case 0: GraficaSismica(); break;
                case 1: GraficaTemperaturas(); break;
                case 2: GraficaDispersion(); break;
                case 3: GraficaPoblaciones(); break;
                case 4: GraficaOndaRuido(); break;
            }

            formsPlot1.Plot.Legend(true);
            formsPlot1.Refresh();
        }

        // -------------------------------------------------------
        // 1. Señal sísmica
        // -------------------------------------------------------
        private void GraficaSismica()
        {
            int ptos = 500;
            double[] tiempo = new double[ptos];
            double[] señal = new double[ptos];

            for (int i = 0; i < ptos; i++)
            {
                double t = i * 0.1;
                tiempo[i] = t;

                señal[i] = (t > 15 && t < 25)
                    ? 5.0 * Math.Sin(t * 4) * Math.Exp(-0.15 * (t - 15)) : 0;

                señal[i] += (t > 30 && t < 38)
                    ? 2.5 * Math.Sin(t * 6) * Math.Exp(-0.2 * (t - 30)) : 0;

                señal[i] += (_rng.NextDouble() - 0.5) * 0.3;
            }

            var plot = formsPlot1.Plot.AddScatter(tiempo, señal,
                ObtenerColor(), label: "Amplitud");
            plot.LineWidth = 1;
            plot.MarkerSize = 0;

            formsPlot1.Plot.AddHorizontalLine(0,
                System.Drawing.Color.White, 1, LineStyle.Dash);
            formsPlot1.Plot.Title("Señal Sísmica Simulada");
            formsPlot1.Plot.XLabel("Tiempo (s)");
            formsPlot1.Plot.YLabel("Amplitud");
        }

        // -------------------------------------------------------
        // 2. Temperaturas mensuales
        // -------------------------------------------------------
        private void GraficaTemperaturas()
        {
            string[] meses = { "Ene","Feb","Mar","Abr","May","Jun",
                                 "Jul","Ago","Sep","Oct","Nov","Dic" };
            double[] medias = { 18, 20, 22, 25, 28, 32,
                                 34, 33, 30, 26, 22, 19 };

            var barras = formsPlot1.Plot.AddBar(medias);
            barras.Label = "Temp. media (°C)";
            barras.FillColor = ObtenerColor();
            barras.BorderLineWidth = 1.5f;

            formsPlot1.Plot.XTicks(
                new double[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 },
                meses
            );
            formsPlot1.Plot.SetAxisLimits(yMin: 0, yMax: 40);
            formsPlot1.Plot.Title("Temperatura Media Mensual");
            formsPlot1.Plot.XLabel("Mes");
            formsPlot1.Plot.YLabel("°C");
        }

        // -------------------------------------------------------
        // 3. Dispersión de grupos
        // -------------------------------------------------------
        private void GraficaDispersion()
        {
            int n = 150;
            double[] x1 = new double[n], y1 = new double[n];
            double[] x2 = new double[n], y2 = new double[n];

            for (int i = 0; i < n; i++)
            {
                x1[i] = 2 + (_rng.NextDouble() - 0.5) * 4;
                y1[i] = 3 + (_rng.NextDouble() - 0.5) * 4;
                x2[i] = 7 + (_rng.NextDouble() - 0.5) * 4;
                y2[i] = 8 + (_rng.NextDouble() - 0.5) * 4;
            }

            var gA = formsPlot1.Plot.AddScatter(x1, y1,
                System.Drawing.Color.DeepSkyBlue, label: "Grupo A");
            gA.LineWidth = 0;
            gA.MarkerSize = 6;
            gA.MarkerShape = MarkerShape.filledCircle;

            var gB = formsPlot1.Plot.AddScatter(x2, y2,
                System.Drawing.Color.OrangeRed, label: "Grupo B");
            gB.LineWidth = 0;
            gB.MarkerSize = 6;
            gB.MarkerShape = MarkerShape.filledSquare;

            formsPlot1.Plot.Title("Dispersión — Dos Grupos");
            formsPlot1.Plot.XLabel("Variable X");
            formsPlot1.Plot.YLabel("Variable Y");
        }

        // -------------------------------------------------------
        // 4. Poblaciones por país
        // -------------------------------------------------------
        private void GraficaPoblaciones()
        {
            double[] colombia = { 50.0, 50.9, 51.5, 51.8, 52.2 };
            double[] venezuela = { 28.5, 28.2, 28.0, 27.8, 27.5 };
            double[] ecuador = { 17.5, 17.8, 18.0, 18.2, 18.4 };
            double[] pos1 = { 0, 1, 2, 3, 4 };
            double[] pos2 = { 0.25, 1.25, 2.25, 3.25, 4.25 };
            double[] pos3 = { 0.50, 1.50, 2.50, 3.50, 4.50 };

            var b1 = formsPlot1.Plot.AddBar(colombia, pos1);
            b1.Label = "Colombia";
            b1.FillColor = System.Drawing.Color.FromArgb(180, 255, 215, 0);
            b1.BarWidth = 0.2;

            var b2 = formsPlot1.Plot.AddBar(venezuela, pos2);
            b2.Label = "Venezuela";
            b2.FillColor = System.Drawing.Color.FromArgb(180, 100, 180, 255);
            b2.BarWidth = 0.2;

            var b3 = formsPlot1.Plot.AddBar(ecuador, pos3);
            b3.Label = "Ecuador";
            b3.FillColor = System.Drawing.Color.FromArgb(180, 100, 220, 100);
            b3.BarWidth = 0.2;

            formsPlot1.Plot.XTicks(
                new double[] { 0.25, 1.25, 2.25, 3.25, 4.25 },
                new string[] { "2019", "2020", "2021", "2022", "2023" }
            );
            formsPlot1.Plot.SetAxisLimits(yMin: 0, yMax: 60);
            formsPlot1.Plot.Title("Población por País (millones)");
            formsPlot1.Plot.XLabel("Año");
            formsPlot1.Plot.YLabel("Millones");
        }

        // -------------------------------------------------------
        // 5. Onda con ruido
        // -------------------------------------------------------
        private void GraficaOndaRuido()
        {
            int ptos = 300;
            double[] t = new double[ptos];
            double[] limpia = new double[ptos];
            double[] ruido = new double[ptos];

            for (int i = 0; i < ptos; i++)
            {
                t[i] = i * 0.05;
                limpia[i] = Math.Sin(t[i] * 2) + 0.5 * Math.Sin(t[i] * 5);
                ruido[i] = limpia[i] + (_rng.NextDouble() - 0.5) * 0.8;
            }

            var sRuido = formsPlot1.Plot.AddScatter(t, ruido,
                System.Drawing.Color.FromArgb(120, 100, 200, 255),
                label: "Con ruido");
            sRuido.LineWidth = 0;
            sRuido.MarkerSize = 3;

            var sLimpia = formsPlot1.Plot.AddScatter(t, limpia,
                ObtenerColor(), label: "Original");
            sLimpia.LineWidth = 2;
            sLimpia.MarkerSize = 0;

            formsPlot1.Plot.Title("Señal Senoidal — Original vs Con Ruido");
            formsPlot1.Plot.XLabel("Tiempo (s)");
            formsPlot1.Plot.YLabel("Amplitud");
        }

        private void ScottPlotForm_Load(object sender, EventArgs e) { }
    }
}