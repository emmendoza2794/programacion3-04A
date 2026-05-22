using System;
using System.Windows.Forms;

namespace grafica_volumen
{
    public partial class Form1 : Form
    {
        private readonly Random _rnd = new Random();

        public Form1()
        {
            InitializeComponent();
            CrearGrid(4, 4);
        }

        private void btnCrearGrid_Click(object sender, EventArgs e)
        {
            CrearGrid((int)nudFilas.Value, (int)nudColumnas.Value);
        }

        private void CrearGrid(int filas, int columnas)
        {
            dgvTerreno.Rows.Clear();
            dgvTerreno.Columns.Clear();

            for (int j = 0; j < columnas; j++)
            {
                var col = new DataGridViewTextBoxColumn
                {
                    HeaderText = $"X{j + 1}",
                    Width = 80,
                    DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
                };
                dgvTerreno.Columns.Add(col);
            }

            for (int i = 0; i < filas; i++)
            {
                int row = dgvTerreno.Rows.Add();
                dgvTerreno.Rows[row].HeaderCell.Value = $"Y{i + 1}";
                for (int j = 0; j < columnas; j++)
                    dgvTerreno.Rows[row].Cells[j].Value = "0";
            }

            lblResultado.Text = "Volumen: —";
            lblResultado.ForeColor = System.Drawing.SystemColors.ControlText;
        }

        private void BtnEjemplo_Click(object sender, EventArgs e)
        {
            nudH.Value  = 10;
            nudDx.Value = 5;
            nudDy.Value = 5;

            int filas = dgvTerreno.Rows.Count;
            int cols  = dgvTerreno.Columns.Count;
            double h  = (double)nudH.Value;
            double A  = 3.0;

            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    double xi = (cols  > 1) ? (double)j / (cols  - 1) * Math.PI * 3 : 0;
                    double yi = (filas > 1) ? (double)i / (filas - 1) * Math.PI * 3 : 0;
                    double onda  = A * Math.Sin(xi) * Math.Cos(yi)
                                 + A * 0.4 * Math.Sin(xi * 0.7 + 1) * Math.Cos(yi * 0.5 + 1);
                    double ruido = (_rnd.NextDouble() - 0.5) * A * 0.3;
                    double valor = h + onda + ruido;
                    dgvTerreno.Rows[i].Cells[j].Value = valor.ToString("F2",
                        System.Globalization.CultureInfo.InvariantCulture);
                    dgvTerreno.Rows[i].Cells[j].Style.BackColor = System.Drawing.Color.White;
                }
            }

            lblResultado.Text = "Volumen: —";
            lblResultado.ForeColor = System.Drawing.SystemColors.ControlText;
        }

        private void BtnGrafica_Click(object sender, EventArgs e)
        {
            dgvTerreno.CurrentCell = null;
            int filas = dgvTerreno.Rows.Count;
            int cols  = dgvTerreno.Columns.Count;
            var alturas = new double[filas, cols];

            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    string celda = dgvTerreno.Rows[i].Cells[j].Value?.ToString() ?? "";
                    if (!double.TryParse(celda, System.Globalization.NumberStyles.Any,
                            System.Globalization.CultureInfo.InvariantCulture, out double fij))
                    {
                        MessageBox.Show("Hay celdas con valores inválidos. Corrígelas antes de graficar.",
                            "Datos inválidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    alturas[i, j] = fij;
                }
            }

            var form2 = new Form2(alturas, (double)nudH.Value, (double)nudDx.Value, (double)nudDy.Value);
            form2.Show();
        }

        private void BtnCalcular_Click(object sender, EventArgs e)
        {
            dgvTerreno.CurrentCell = null;
            double h = (double)nudH.Value;
            double dx = (double)nudDx.Value;
            double dy = (double)nudDy.Value;
            double volumen = 0;
            bool hayError = false;

            for (int i = 0; i < dgvTerreno.Rows.Count; i++)
            {
                for (int j = 0; j < dgvTerreno.Columns.Count; j++)
                {
                    string celda = dgvTerreno.Rows[i].Cells[j].Value?.ToString() ?? "";
                    if (!double.TryParse(celda, System.Globalization.NumberStyles.Any,
                            System.Globalization.CultureInfo.InvariantCulture, out double fij))
                    {
                        dgvTerreno.Rows[i].Cells[j].Style.BackColor = System.Drawing.Color.LightCoral;
                        hayError = true;
                        continue;
                    }
                    dgvTerreno.Rows[i].Cells[j].Style.BackColor = System.Drawing.Color.White;

                    double diff = fij - h;
                    if (diff > 0)
                        volumen += diff * dx * dy;
                }
            }

            if (hayError)
            {
                lblResultado.Text = "Error: celdas inválidas marcadas en rojo.";
                lblResultado.ForeColor = System.Drawing.Color.Crimson;
            }
            else
            {
                lblResultado.Text = $"Volumen de excavación:  V = {volumen:F4} m³";
                lblResultado.ForeColor = System.Drawing.Color.DarkGreen;
            }
        }
    }
}
