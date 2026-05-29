using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace pdfs
{
    public partial class Form1 : Form
    {
        private readonly PrintDocument _printDoc = new PrintDocument();
        private int _contadorFactura = 1;

        public Form1()
        {
            InitializeComponent();
            ConfigurarDGV();
            _printDoc.PrintPage += PrintDocument_PrintPage;
            txtNumero.Text = _contadorFactura.ToString("D6");
            dtpFecha.Value = DateTime.Now;
        }

        // ── Configuración inicial del DataGridView ──────────────────────
        private void ConfigurarDGV()
        {
            dgvItems.EnableHeadersVisualStyles = false;
            dgvItems.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 70, 130);
            dgvItems.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvItems.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9F, FontStyle.Bold);
            dgvItems.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 70, 130);
            dgvItems.DefaultCellStyle.Font = new Font("Arial", 9F);
            dgvItems.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 245, 255);
            dgvItems.GridColor = Color.FromArgb(200, 210, 230);
            colTotal.DefaultCellStyle.Format = "C2";
            colPrecioUnit.DefaultCellStyle.Format = "N2";
        }

        // ── Recalcular total de la fila cuando cambia cantidad o precio ─
        private void dgvItems_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            RecalcularFila(e.RowIndex);
        }

        private void RecalcularFila(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= dgvItems.Rows.Count) return;
            var row = dgvItems.Rows[rowIndex];
            if (row.IsNewRow) return;

            bool okCant  = decimal.TryParse(row.Cells["colCantidad"].Value?.ToString(),  out decimal cant);
            bool okPrec  = decimal.TryParse(row.Cells["colPrecioUnit"].Value?.ToString(), out decimal prec);

            row.Cells["colTotal"].Value = (okCant && okPrec) ? cant * prec : (decimal?)null;
            ActualizarTotales();
        }

        private void ActualizarTotales()
        {
            decimal subtotal = ObtenerSubtotal();
            decimal iva      = subtotal * 0.19m;
            decimal total    = subtotal + iva;

            lblSubtotalVal.Text = subtotal.ToString("C2");
            lblIVAVal.Text      = iva.ToString("C2");
            lblTotalVal.Text    = total.ToString("C2");
        }

        private decimal ObtenerSubtotal()
        {
            decimal subtotal = 0;
            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                if (row.IsNewRow) continue;
                if (row.Cells["colTotal"].Value is decimal t)
                    subtotal += t;
            }
            return subtotal;
        }

        // ── Botón: Exportar PDF ─────────────────────────────────────────
        private void btnExportarPDF_Click(object sender, EventArgs e)
        {
            if (!ValidarFactura()) return;

            // Verificar que la impresora virtual de Windows exista
            const string PDF_PRINTER = "Microsoft Print to PDF";
            bool impResoraDisponible = false;
            foreach (string p in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                if (p == PDF_PRINTER) { impResoraDisponible = true; break; }
            }

            if (!impResoraDisponible)
            {
                MessageBox.Show(
                    "No se encontró la impresora 'Microsoft Print to PDF'.\n" +
                    "Requiere Windows 10 o superior con esa impresora instalada.",
                    "Impresora no encontrada",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Pedir al usuario dónde guardar
            using (var sfd = new SaveFileDialog())
            {
                sfd.Title      = "Guardar Factura como PDF";
                sfd.Filter     = "Archivo PDF (*.pdf)|*.pdf";
                sfd.FileName   = $"Factura_{txtNumero.Text}_{dtpFecha.Value:yyyyMMdd}.pdf";
                sfd.DefaultExt = "pdf";

                if (sfd.ShowDialog() != DialogResult.OK) return;

                // Guardar configuración original para restaurar después
                var settingsOriginales = _printDoc.PrinterSettings;

                try
                {
                    var settings = new System.Drawing.Printing.PrinterSettings
                    {
                        PrinterName = PDF_PRINTER,
                        PrintToFile = true,
                        PrintFileName = sfd.FileName
                    };
                    _printDoc.PrinterSettings = settings;
                    _printDoc.Print();

                    MessageBox.Show(
                        "PDF generado exitosamente:\n" + sfd.FileName,
                        "PDF Exportado",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Error al generar el PDF:\n" + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    // Restaurar configuración original
                    _printDoc.PrinterSettings = settingsOriginales;
                }
            }
        }

        // ── Botón: Vista Previa ─────────────────────────────────────────
        private void btnVistaPrevia_Click(object sender, EventArgs e)
        {
            if (!ValidarFactura()) return;

            var preview = new PrintPreviewDialog
            {
                Document = _printDoc,
                Width    = 850,
                Height   = 1050,
                Text     = "Vista Previa — Factura N° " + txtNumero.Text
            };
            preview.ShowDialog();
        }

        // ── Botón: Imprimir / Guardar PDF ──────────────────────────────
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (!ValidarFactura()) return;

            using (var dlg = new PrintDialog { Document = _printDoc, UseEXDialog = true })
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                    _printDoc.Print();
            }
        }

        // ── Botón: Datos de Ejemplo ─────────────────────────────────────
        private void btnEjemplo_Click(object sender, EventArgs e)
        {
            // Datos del cliente
            txtClienteNombre.Text    = "Comercializadora El Buen Precio Ltda.";
            txtClienteNIT.Text       = "800.456.789-3";
            txtClienteDireccion.Text = "Av. El Dorado #68-11, Bogotá D.C.";
            txtClienteTel.Text       = "(601) 987-6543";
            txtObservaciones.Text    = "Pago a 30 días. Factura generada electrónicamente.";

            // Limpiar y cargar ítems de ejemplo
            dgvItems.Rows.Clear();

            var items = new (string desc, decimal cant, decimal precio)[]
            {
                ("Laptop Dell Inspiron 15 (Core i7, 16GB RAM)",   2,  3_850_000),
                ("Mouse Inalámbrico Logitech M720",               5,    189_900),
                ("Teclado Mecánico Redragon K552",                3,    245_000),
                ("Monitor LG 24\" FHD IPS 75Hz",                 2,  1_120_000),
                ("Silla Ergonómica Home Office",                  4,    680_000),
                ("Disco Duro Externo WD 1TB USB 3.0",             6,    295_500),
            };

            foreach (var (desc, cant, precio) in items)
            {
                int idx = dgvItems.Rows.Add();
                var row = dgvItems.Rows[idx];
                row.Cells["colDescripcion"].Value = desc;
                row.Cells["colCantidad"].Value    = cant;
                row.Cells["colPrecioUnit"].Value  = precio;
                row.Cells["colTotal"].Value       = cant * precio;
            }

            ActualizarTotales();
        }

        // ── Botón: Nueva Factura ────────────────────────────────────────
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            var resp = MessageBox.Show(
                "¿Desea limpiar el formulario para una nueva factura?",
                "Nueva Factura",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resp != DialogResult.Yes) return;

            _contadorFactura++;
            txtNumero.Text = _contadorFactura.ToString("D6");
            dtpFecha.Value = DateTime.Now;
            txtClienteNombre.Clear();
            txtClienteNIT.Clear();
            txtClienteDireccion.Clear();
            txtClienteTel.Clear();
            txtObservaciones.Clear();
            dgvItems.Rows.Clear();
            ActualizarTotales();
        }

        // ── Validación antes de imprimir ────────────────────────────────
        private bool ValidarFactura()
        {
            int filas = 0;
            foreach (DataGridViewRow row in dgvItems.Rows)
                if (!row.IsNewRow && row.Cells["colDescripcion"].Value != null)
                    filas++;

            if (filas == 0)
            {
                MessageBox.Show(
                    "Agregue al menos un ítem antes de imprimir.",
                    "Factura vacía",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        // ── Evento PrintPage: renderiza la factura en papel ────────────
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            DibujarFactura(e.Graphics, e.MarginBounds);
            e.HasMorePages = false;
        }

        // ── Dibuja la factura completa usando GDI+ ─────────────────────
        private void DibujarFactura(Graphics g, Rectangle bounds)
        {
            // Fuentes
            var fEmpresa = new Font("Arial", 14, FontStyle.Bold);
            var fInfo    = new Font("Arial",  8, FontStyle.Regular);
            var fLabel   = new Font("Arial",  8, FontStyle.Bold);
            var fNormal  = new Font("Arial",  8.5f, FontStyle.Regular);
            var fBold    = new Font("Arial",  8.5f, FontStyle.Bold);
            var fTotal   = new Font("Arial",  11, FontStyle.Bold);
            var fNumFac  = new Font("Arial",  11, FontStyle.Bold);

            // Colores
            var azul     = Color.FromArgb(0, 70, 130);
            var grisClaro = Color.FromArgb(240, 245, 255);

            var brAzul   = new SolidBrush(azul);
            var brGris   = new SolidBrush(grisClaro);
            var brHdrBg  = new SolidBrush(Color.FromArgb(225, 238, 255));
            var penAzul  = new Pen(azul, 1f);
            var penGris  = new Pen(Color.FromArgb(180, 200, 220), 0.5f);

            float L = bounds.Left;
            float T = bounds.Top;
            float W = bounds.Width;
            float y = T;

            // ── ENCABEZADO ─────────────────────────────────────────────
            const float HDR_H = 85;
            g.FillRectangle(brAzul, L, y, W, HDR_H);

            // Datos empresa
            g.DrawString("MI EMPRESA S.A.S", fEmpresa, Brushes.White, L + 8, y + 8);
            g.DrawString("NIT: 900.123.456-7", fInfo, Brushes.White, L + 8, y + 38);
            g.DrawString("Calle 123 #45-67, Bogotá D.C.", fInfo, Brushes.White, L + 8, y + 52);
            g.DrawString("Tel: (601) 234-5678  ·  info@miempresa.com", fInfo, Brushes.White, L + 8, y + 66);

            // Recuadro blanco de factura (derecha del header)
            const float FB_W = 190, FB_H = 76;
            float fbX = L + W - FB_W - 4, fbY = y + 4;
            g.FillRectangle(Brushes.White, fbX, fbY, FB_W, FB_H);
            g.DrawRectangle(Pens.White, fbX, fbY, FB_W, FB_H);

            g.DrawString("FACTURA DE VENTA", fLabel, brAzul, fbX + 5, fbY + 5);
            g.DrawString("N° " + txtNumero.Text, fNumFac, Brushes.DarkRed, fbX + 5, fbY + 23);
            g.DrawString("Fecha:  " + dtpFecha.Value.ToString("dd/MM/yyyy"), fInfo, Brushes.Black, fbX + 5, fbY + 48);
            g.DrawString("Vence:  " + dtpFecha.Value.AddDays(30).ToString("dd/MM/yyyy"), fInfo, Brushes.Black, fbX + 5, fbY + 62);

            y += HDR_H + 8;

            // ── DATOS DEL CLIENTE ──────────────────────────────────────
            const float CLI_LABEL_H = 18;
            g.FillRectangle(brHdrBg, L, y, W, CLI_LABEL_H);
            g.DrawString("DATOS DEL CLIENTE", fLabel, brAzul, L + 5, y + 3);
            y += CLI_LABEL_H;

            const float CLI_H = 52;
            g.DrawRectangle(penAzul, L, y, W, CLI_H);
            g.DrawLine(penGris, L + W / 2, y, L + W / 2, y + CLI_H);

            float c2 = L + W / 2 + 5;
            g.DrawString("Cliente:",   fLabel, Brushes.Black, L + 5,     y + 6);
            g.DrawString(txtClienteNombre.Text,    fNormal, Brushes.Black, L + 58,   y + 6);
            g.DrawString("NIT / CC:", fLabel, Brushes.Black, c2,         y + 6);
            g.DrawString(txtClienteNIT.Text,        fNormal, Brushes.Black, c2 + 62,  y + 6);

            g.DrawString("Dirección:", fLabel, Brushes.Black, L + 5,     y + 28);
            g.DrawString(txtClienteDireccion.Text,  fNormal, Brushes.Black, L + 72,   y + 28);
            g.DrawString("Teléfono:", fLabel, Brushes.Black, c2,         y + 28);
            g.DrawString(txtClienteTel.Text,        fNormal, Brushes.Black, c2 + 62,  y + 28);

            y += CLI_H + 8;

            // ── TABLA DE ÍTEMS ─────────────────────────────────────────
            float tableTop = y;
            float[] cw = { W * 0.45f, W * 0.10f, W * 0.22f, W * 0.23f };
            string[] headers = { "DESCRIPCIÓN", "CANT.", "PRECIO UNITARIO", "TOTAL" };

            // Cabecera de tabla
            const float COL_H = 20;
            g.FillRectangle(brAzul, L, y, W, COL_H);
            float cx = L;
            for (int i = 0; i < headers.Length; i++)
            {
                g.DrawString(headers[i], fLabel, Brushes.White, cx + 4, y + 4);
                cx += cw[i];
            }
            y += COL_H;

            // Filas de datos
            const float ROW_H = 17;
            int rowNum = 0;

            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                if (row.IsNewRow) continue;

                if (rowNum % 2 == 1) g.FillRectangle(brGris, L, y, W, ROW_H);

                cx = L;
                string desc = row.Cells["colDescripcion"].Value?.ToString() ?? "";
                g.DrawString(desc, fNormal, Brushes.Black, cx + 4, y + 2);
                cx += cw[0];

                string cant = row.Cells["colCantidad"].Value?.ToString() ?? "";
                g.DrawString(cant, fNormal, Brushes.Black, cx + 4, y + 2);
                cx += cw[1];

                if (decimal.TryParse(row.Cells["colPrecioUnit"].Value?.ToString(), out decimal precVal))
                    g.DrawString(precVal.ToString("C2"), fNormal, Brushes.Black, cx + 4, y + 2);
                cx += cw[2];

                if (row.Cells["colTotal"].Value is decimal totVal)
                    DibujarTextoAlineadoDerecha(g, totVal.ToString("C2"), fBold, Brushes.Black, cx, y, cw[3], ROW_H);

                y += ROW_H;
                rowNum++;
            }

            // Filas vacías hasta completar mínimo visual
            const int MIN_ROWS = 10;
            for (int i = rowNum; i < MIN_ROWS; i++)
            {
                if (i % 2 == 1) g.FillRectangle(brGris, L, y, W, ROW_H);
                y += ROW_H;
            }

            // Borde exterior de la tabla y líneas de columnas
            float tableH = y - tableTop;
            g.DrawRectangle(penAzul, L, tableTop, W, tableH);
            cx = L;
            for (int i = 0; i < cw.Length - 1; i++)
            {
                cx += cw[i];
                g.DrawLine(penGris, cx, tableTop, cx, y);
            }

            y += 8;

            // ── OBSERVACIONES Y TOTALES ────────────────────────────────
            float secY   = y;
            float obsW   = W * 0.55f;
            float totX   = L + obsW + 6;
            float totW   = W - obsW - 6;
            const float  SEC_H     = 68;
            const float  TOT_ROW_H = 20;

            // Caja de observaciones
            g.DrawRectangle(penAzul, L, secY, obsW, SEC_H);
            g.DrawString("Observaciones:", fLabel, brAzul, L + 3, secY + 2);
            var obsRect = new RectangleF(L + 3, secY + 14, obsW - 6, SEC_H - 16);
            g.DrawString(txtObservaciones.Text, fInfo, Brushes.Black, obsRect);

            // Filas de totales
            decimal subtotal = ObtenerSubtotal();
            decimal iva      = subtotal * 0.19m;
            decimal totalFin = subtotal + iva;

            float ty = secY;
            DibujarFilaTotales(g, fLabel, fNormal, penGris, null, totX, ty, totW, TOT_ROW_H, "Subtotal:", subtotal.ToString("C2"));
            ty += TOT_ROW_H;
            DibujarFilaTotales(g, fLabel, fNormal, penGris, null, totX, ty, totW, TOT_ROW_H, "IVA (19%):", iva.ToString("C2"));
            ty += TOT_ROW_H;

            // Fila TOTAL (resaltada)
            float totalRowH = SEC_H - TOT_ROW_H * 2;
            g.FillRectangle(brAzul, totX, ty, totW, totalRowH);
            g.DrawString("TOTAL:", fTotal, Brushes.White, totX + 5, ty + 4);
            DibujarTextoAlineadoDerecha(g, totalFin.ToString("C2"), fTotal, Brushes.White, totX, ty, totW, totalRowH);

            y = secY + SEC_H + 18;

            // ── PIE DE PÁGINA ──────────────────────────────────────────
            g.DrawLine(penAzul, L, y, L + W, y);
            y += 5;
            g.DrawString(
                "Esta factura es un documento válido para efectos contables y fiscales. " +
                "Conserve su copia. Gracias por su compra.",
                fInfo, Brushes.Gray, L, y);

            // Liberar recursos GDI
            fEmpresa.Dispose(); fInfo.Dispose();   fLabel.Dispose();
            fNormal.Dispose();  fBold.Dispose();   fTotal.Dispose(); fNumFac.Dispose();
            brAzul.Dispose();   brGris.Dispose();  brHdrBg.Dispose();
            penAzul.Dispose();  penGris.Dispose();
        }

        // ── Helpers de dibujo ───────────────────────────────────────────

        private static void DibujarFilaTotales(
            Graphics g, Font fLabel, Font fVal, Pen pen,
            Brush bgBrush, float x, float y, float w, float h,
            string label, string valor)
        {
            if (bgBrush != null) g.FillRectangle(bgBrush, x, y, w, h);
            g.DrawRectangle(pen, x, y, w, h);
            g.DrawString(label, fLabel, Brushes.Black, x + 5, y + 3);
            DibujarTextoAlineadoDerecha(g, valor, fVal, Brushes.Black, x, y, w, h);
        }

        private static void DibujarTextoAlineadoDerecha(
            Graphics g, string texto, Font font, Brush brush,
            float x, float y, float w, float h)
        {
            var fmt = new StringFormat
            {
                Alignment     = StringAlignment.Far,
                LineAlignment = StringAlignment.Center
            };
            g.DrawString(texto, font, brush, new RectangleF(x + 4, y, w - 8, h), fmt);
            fmt.Dispose();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _printDoc.Dispose();
            base.OnFormClosed(e);
        }
    }
}
