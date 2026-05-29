using System;
using System.Windows.Forms;
using grafica_volumen.Logic;

namespace grafica_volumen
{
    public partial class Form1 : Form
    {
        private readonly Random _rnd = new Random();

        public Form1()
        {
            InitializeComponent();
            CrearGrid(4, 4);
            cmbMetodo_SelectedIndexChanged(null, null);
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

            int    filas = dgvTerreno.Rows.Count;
            int    cols  = dgvTerreno.Columns.Count;
            double h     = (double)nudH.Value;

            for (int i = 0; i < filas; i++)
                for (int j = 0; j < cols; j++)
                {
                    // Aleatorio en [h×0.5 , h×2.0] → mezcla natural de celdas sobre y bajo h
                    double valor = h * 0.5 + _rnd.NextDouble() * h * 1.5;
                    dgvTerreno.Rows[i].Cells[j].Value = valor.ToString("F2",
                        System.Globalization.CultureInfo.InvariantCulture);
                    dgvTerreno.Rows[i].Cells[j].Style.BackColor = System.Drawing.Color.White;
                }

            lblResultado.Text = "Volumen: —";
            lblResultado.ForeColor = System.Drawing.SystemColors.ControlText;
        }

        private void BtnMontana_Click(object sender, EventArgs e)
        {
            nudH.Value  = 10;
            nudDx.Value = 5;
            nudDy.Value = 5;

            int filas = dgvTerreno.Rows.Count;
            int cols  = dgvTerreno.Columns.Count;

            // Gaussiana 2D: simula un pico de montaña
            //   base  = 4.5 m  (zona de valle, bajo h=10)
            //   pico  = 4.5+17 = 21.5 m  (cima, 11.5 m sobre h)
            //   centro ligeramente descentrado para mayor realismo
            const double baseZ = 4.5;
            const double ampl  = 17.0;
            const double cx    = 0.45, cy = 0.40;
            const double sx    = 0.28, sy = 0.22;

            for (int i = 0; i < filas; i++)
                for (int j = 0; j < cols; j++)
                {
                    double u = cols  > 1 ? (double)j / (cols  - 1) : 0.5;
                    double v = filas > 1 ? (double)i / (filas - 1) : 0.5;
                    double g = ampl * Math.Exp(
                        -((u - cx) * (u - cx) / (2 * sx * sx)
                        + (v - cy) * (v - cy) / (2 * sy * sy)));
                    double valor = baseZ + g;
                    dgvTerreno.Rows[i].Cells[j].Value = valor.ToString("F2",
                        System.Globalization.CultureInfo.InvariantCulture);
                    dgvTerreno.Rows[i].Cells[j].Style.BackColor = System.Drawing.Color.White;
                }

            lblResultado.Text = "Volumen: —";
            lblResultado.ForeColor = System.Drawing.SystemColors.ControlText;
        }

        private void BtnCresta_Click(object sender, EventArgs e)
        {
            nudH.Value  = 10;
            nudDx.Value = 5;
            nudDy.Value = 5;

            int filas = dgvTerreno.Rows.Count;
            int cols  = dgvTerreno.Columns.Count;

            // Gaussiana muy ancha en X y estrecha en Y → cordillera horizontal
            //   base = 5 m, pico = 5+14 = 19 m (9 m sobre h)
            //   la cresta cruza el grid de izquierda a derecha por el centro
            //   los bordes norte/sur caen por debajo de h=10
            const double baseZ = 5.0;
            const double ampl  = 14.0;
            const double cx    = 0.50, cy = 0.42;
            const double sx    = 0.50, sy = 0.13;

            for (int i = 0; i < filas; i++)
                for (int j = 0; j < cols; j++)
                {
                    double u = cols  > 1 ? (double)j / (cols  - 1) : 0.5;
                    double v = filas > 1 ? (double)i / (filas - 1) : 0.5;
                    double g = ampl * Math.Exp(
                        -((u - cx) * (u - cx) / (2 * sx * sx)
                        + (v - cy) * (v - cy) / (2 * sy * sy)));
                    double valor = baseZ + g;
                    dgvTerreno.Rows[i].Cells[j].Value = valor.ToString("F2",
                        System.Globalization.CultureInfo.InvariantCulture);
                    dgvTerreno.Rows[i].Cells[j].Style.BackColor = System.Drawing.Color.White;
                }

            lblResultado.Text = "Volumen: —";
            lblResultado.ForeColor = System.Drawing.SystemColors.ControlText;
        }

        private void BtnDosPicos_Click(object sender, EventArgs e)
        {
            nudH.Value  = 10;
            nudDx.Value = 5;
            nudDy.Value = 5;

            int filas = dgvTerreno.Rows.Count;
            int cols  = dgvTerreno.Columns.Count;

            // Suma de dos gaussianas: pico noroeste (mayor) + pico sureste (menor)
            //   El valle entre ellos cae a ~9 m → justo bajo h=10
            //   pico1 = 4.5+13 = 17.5 m,  pico2 = 4.5+11 = 15.5 m
            const double baseZ = 4.5;
            const double a1 = 13.0, cx1 = 0.28, cy1 = 0.30, sx1 = 0.18, sy1 = 0.17;
            const double a2 = 11.0, cx2 = 0.70, cy2 = 0.66, sx2 = 0.17, sy2 = 0.19;

            for (int i = 0; i < filas; i++)
                for (int j = 0; j < cols; j++)
                {
                    double u = cols  > 1 ? (double)j / (cols  - 1) : 0.5;
                    double v = filas > 1 ? (double)i / (filas - 1) : 0.5;
                    double g1 = a1 * Math.Exp(
                        -((u-cx1)*(u-cx1)/(2*sx1*sx1) + (v-cy1)*(v-cy1)/(2*sy1*sy1)));
                    double g2 = a2 * Math.Exp(
                        -((u-cx2)*(u-cx2)/(2*sx2*sx2) + (v-cy2)*(v-cy2)/(2*sy2*sy2)));
                    double valor = baseZ + g1 + g2;
                    dgvTerreno.Rows[i].Cells[j].Value = valor.ToString("F2",
                        System.Globalization.CultureInfo.InvariantCulture);
                    dgvTerreno.Rows[i].Cells[j].Style.BackColor = System.Drawing.Color.White;
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

        private void cmbMetodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbMetodo.SelectedIndex)
            {
                case 0:
                    txtEjemplo.Text =
                        "MÉTODO DE CUADRÍCULA\r\n" +
                        "════════════════════════════════════════\r\n\r\n" +
                        "Aproximación tipo Suma de Riemann.\r\n" +
                        "Divide el terreno en (m−1)×(n−1) celdas\r\n" +
                        "y usa el valor del nodo superior-izquierdo\r\n" +
                        "de cada celda como altura representativa.\r\n\r\n" +
                        "  Fórmula:\r\n" +
                        "  V = Σ max(z[i,j] − h, 0) × dx × dy\r\n\r\n" +
                        "  Suma sobre las (m−1)×(n−1) celdas.\r\n" +
                        "  Solo se usa z[i,j] (esquina sup-izq).\r\n\r\n" +
                        "────────────────────────────────────────\r\n" +
                        "COMPORTAMIENTO\r\n\r\n" +
                        "  Al usar un solo punto por celda, puede\r\n" +
                        "  sobreestimar o subestimar según el\r\n" +
                        "  terreno (no tiene sesgo fijo).\r\n\r\n" +
                        "  Para terrenos suaves sus resultados\r\n" +
                        "  convergen a los otros métodos al\r\n" +
                        "  aumentar la resolución de la malla.\r\n\r\n" +
                        "────────────────────────────────────────\r\n" +
                        "CUÁNDO USARLO\r\n\r\n" +
                        "  Primera aproximación rápida; base de\r\n" +
                        "  comparación frente a métodos más\r\n" +
                        "  precisos como Prismas o Trapecio.\r\n";
                    break;

                case 1:
                    txtEjemplo.Text =
                        "MÉTODO DE PRISMAS\r\n" +
                        "════════════════════════════════════════\r\n\r\n" +
                        "Divide el terreno en (m−1)×(n−1) prismas\r\n" +
                        "rectangulares. El corte h se aplica a\r\n" +
                        "cada esquina individualmente y luego se\r\n" +
                        "promedia la contribución de las 4.\r\n\r\n" +
                        "  Fórmula por celda:\r\n" +
                        "  V_cel = (max(d₀₀,0) + max(d₁₀,0)\r\n" +
                        "         + max(d₀₁,0) + max(d₁₁,0))\r\n" +
                        "         / 4 × dx × dy\r\n\r\n" +
                        "  donde dᵢⱼ = z[i,j] − h\r\n\r\n" +
                        "────────────────────────────────────────\r\n" +
                        "EQUIVALENCIA CON REGLA DEL TRAPECIO 2D\r\n\r\n" +
                        "  Esta fórmula es matemáticamente\r\n" +
                        "  idéntica a la Regla del Trapecio 2D:\r\n" +
                        "  ambas asignan a cada nodo un peso\r\n" +
                        "  proporcional al número de celdas que\r\n" +
                        "  comparte (¼ esquina, ½ borde, 1\r\n" +
                        "  interior). Los resultados coinciden.\r\n\r\n" +
                        "────────────────────────────────────────\r\n" +
                        "CUÁNDO USARLO\r\n\r\n" +
                        "  Estándar en topografía e ingeniería\r\n" +
                        "  civil para movimiento de tierras.\r\n";
                    break;

                case 2:
                    txtEjemplo.Text =
                        "REGLA DEL TRAPECIO 2D\r\n" +
                        "════════════════════════════════════════\r\n\r\n" +
                        "Extensión 2D de la regla del trapecio.\r\n" +
                        "Asigna un peso fraccional a cada nodo\r\n" +
                        "según su posición en la malla.\r\n\r\n" +
                        "  Pesos por posición:\r\n" +
                        "    Esquinas   → w = 1/4\r\n" +
                        "    Bordes     → w = 1/2\r\n" +
                        "    Interiores → w = 1\r\n\r\n" +
                        "  Fórmula:\r\n" +
                        "  V = Σ w(i,j)×max(f(i,j)−h,0)×dx×dy\r\n\r\n" +
                        "────────────────────────────────────────\r\n" +
                        "VENTAJA FRENTE AL MÉTODO DE PRISMAS\r\n\r\n" +
                        "  Cuando h cruza una celda parcialmente,\r\n" +
                        "  cada esquina que supera h contribuye\r\n" +
                        "  de forma individual con su peso w.\r\n\r\n" +
                        "  El Método de Prismas puede dar 0 para\r\n" +
                        "  esa celda; el Trapecio no la pierde.\r\n\r\n" +
                        "  Por eso: Trapecio ≥ Prismas siempre\r\n" +
                        "  que h corte celdas a la mitad.\r\n\r\n" +
                        "────────────────────────────────────────\r\n" +
                        "CUÁNDO USARLO\r\n\r\n" +
                        "  Mayor precisión en terrenos con\r\n" +
                        "  variaciones abruptas cerca de h.\r\n";
                    break;

                case 3:
                    txtEjemplo.Text =
                        "REGLA DE SIMPSON 2D\r\n" +
                        "════════════════════════════════════════\r\n\r\n" +
                        "Aproxima la integral doble:\r\n" +
                        "  V = ∬ max(z(x,y) − h, 0) dx dy\r\n\r\n" +
                        "Cuadratura compuesta de orden 4 en cada\r\n" +
                        "dirección. Los pesos 1D siguen el patrón:\r\n" +
                        "  1, 4, 2, 4, 2, ..., 4, 1\r\n\r\n" +
                        "  Fórmula:\r\n" +
                        "  V ≈ (dx·dy/9) × Σᵢ Σⱼ wᵢ·wⱼ·max(f−h,0)\r\n\r\n" +
                        "  Pesos por posición del nodo:\r\n" +
                        "    Extremos (k=0 ó k=n-1) → w = 1\r\n" +
                        "    Índice impar            → w = 4\r\n" +
                        "    Índice par interior      → w = 2\r\n\r\n" +
                        "────────────────────────────────────────\r\n" +
                        "REQUISITO DE LA MALLA\r\n\r\n" +
                        "  Necesita número IMPAR de nodos en cada\r\n" +
                        "  dirección (número PAR de intervalos):\r\n" +
                        "    3, 5, 7, 9, 11, ... nodos\r\n\r\n" +
                        "  Si el grid tiene número par de nodos,\r\n" +
                        "  se descarta la última fila/columna\r\n" +
                        "  automáticamente.\r\n\r\n" +
                        "────────────────────────────────────────\r\n" +
                        "VENTAJA FRENTE AL TRAPECIO\r\n\r\n" +
                        "  El error del Trapecio es O(h²);\r\n" +
                        "  el de Simpson es O(h⁴): converge\r\n" +
                        "  mucho más rápido al refinar la malla.\r\n\r\n" +
                        "  Para terrenos suaves con pocos nodos\r\n" +
                        "  Simpson supera claramente al Trapecio.\r\n";
                    break;
            }
        }

        private void BtnCalcular_Click(object sender, EventArgs e)
        {
            dgvTerreno.CurrentCell = null;
            int filas = dgvTerreno.Rows.Count;
            int cols  = dgvTerreno.Columns.Count;
            var alturas = new double[filas, cols];
            bool hayError = false;

            for (int i = 0; i < filas; i++)
                for (int j = 0; j < cols; j++)
                {
                    string celda = dgvTerreno.Rows[i].Cells[j].Value?.ToString() ?? "";
                    if (!double.TryParse(celda, System.Globalization.NumberStyles.Any,
                            System.Globalization.CultureInfo.InvariantCulture, out double fij))
                    {
                        dgvTerreno.Rows[i].Cells[j].Style.BackColor = System.Drawing.Color.LightCoral;
                        hayError = true;
                    }
                    else
                    {
                        dgvTerreno.Rows[i].Cells[j].Style.BackColor = System.Drawing.Color.White;
                        alturas[i, j] = fij;
                    }
                }

            if (hayError)
            {
                lblResultado.Text = "Error: celdas inválidas marcadas en rojo.";
                lblResultado.ForeColor = System.Drawing.Color.Crimson;
                return;
            }

            if (cmbMetodo.SelectedIndex < 0)
            {
                MessageBox.Show("Selecciona un método de cálculo antes de continuar.",
                    "Sin método", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var metodo = (MetodoCalculo)cmbMetodo.SelectedIndex;
            double volumen;
            try
            {
                volumen = CalculoVolumen.Calcular(
                    alturas, (double)nudH.Value, (double)nudDx.Value, (double)nudDy.Value, metodo);
            }
            catch (ArgumentException ex)
            {
                lblResultado.Text = "Error: " + ex.Message;
                lblResultado.ForeColor = System.Drawing.Color.Crimson;
                return;
            }
            lblResultado.Text = $"V = {volumen:F2} m³   [{cmbMetodo.SelectedItem}]";
            lblResultado.ForeColor = System.Drawing.Color.DarkGreen;
        }
    }
}
