namespace pdfs
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlFacturaBox = new System.Windows.Forms.Panel();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblFechaLbl = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.lblNumeroLbl = new System.Windows.Forms.Label();
            this.lblFacturaTitulo = new System.Windows.Forms.Label();
            this.lblEmpresaInfo = new System.Windows.Forms.Label();
            this.lblEmpresaNombre = new System.Windows.Forms.Label();
            this.pnlCliente = new System.Windows.Forms.Panel();
            this.txtClienteTel = new System.Windows.Forms.TextBox();
            this.txtClienteDireccion = new System.Windows.Forms.TextBox();
            this.txtClienteNIT = new System.Windows.Forms.TextBox();
            this.txtClienteNombre = new System.Windows.Forms.TextBox();
            this.lblCTelLbl = new System.Windows.Forms.Label();
            this.lblCDirLbl = new System.Windows.Forms.Label();
            this.lblCNITLbl = new System.Windows.Forms.Label();
            this.lblCNombreLbl = new System.Windows.Forms.Label();
            this.lblClienteTitulo = new System.Windows.Forms.Label();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.colDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecioUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlObsTotales = new System.Windows.Forms.Panel();
            this.lblTotalVal = new System.Windows.Forms.Label();
            this.lblTotalLbl = new System.Windows.Forms.Label();
            this.lblIVAVal = new System.Windows.Forms.Label();
            this.lblIVALbl = new System.Windows.Forms.Label();
            this.lblSubtotalVal = new System.Windows.Forms.Label();
            this.lblSubtotalLbl = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.lblObsLbl = new System.Windows.Forms.Label();
            this.pnlAcciones = new System.Windows.Forms.Panel();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnVistaPrevia = new System.Windows.Forms.Button();
            this.btnEjemplo = new System.Windows.Forms.Button();
            this.btnExportarPDF = new System.Windows.Forms.Button();

            this.pnlHeader.SuspendLayout();
            this.pnlFacturaBox.SuspendLayout();
            this.pnlCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.pnlObsTotales.SuspendLayout();
            this.pnlAcciones.SuspendLayout();
            this.SuspendLayout();

            // ── pnlHeader ──────────────────────────────────────────────
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(0, 70, 130);
            this.pnlHeader.Controls.Add(this.pnlFacturaBox);
            this.pnlHeader.Controls.Add(this.lblEmpresaInfo);
            this.pnlHeader.Controls.Add(this.lblEmpresaNombre);
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(984, 100);
            this.pnlHeader.TabIndex = 0;

            // ── lblEmpresaNombre ───────────────────────────────────────
            this.lblEmpresaNombre.AutoSize = true;
            this.lblEmpresaNombre.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.lblEmpresaNombre.ForeColor = System.Drawing.Color.White;
            this.lblEmpresaNombre.Location = new System.Drawing.Point(10, 10);
            this.lblEmpresaNombre.Name = "lblEmpresaNombre";
            this.lblEmpresaNombre.Text = "MI EMPRESA S.A.S";

            // ── lblEmpresaInfo ─────────────────────────────────────────
            this.lblEmpresaInfo.AutoSize = false;
            this.lblEmpresaInfo.Font = new System.Drawing.Font("Arial", 8F);
            this.lblEmpresaInfo.ForeColor = System.Drawing.Color.White;
            this.lblEmpresaInfo.Location = new System.Drawing.Point(10, 42);
            this.lblEmpresaInfo.Name = "lblEmpresaInfo";
            this.lblEmpresaInfo.Size = new System.Drawing.Size(520, 52);
            this.lblEmpresaInfo.Text = "NIT: 900.123.456-7\r\nCalle 123 #45-67, Bogotá D.C.\r\nTel: (601) 234-5678  ·  info@miempresa.com";

            // ── pnlFacturaBox ──────────────────────────────────────────
            this.pnlFacturaBox.BackColor = System.Drawing.Color.White;
            this.pnlFacturaBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFacturaBox.Controls.Add(this.dtpFecha);
            this.pnlFacturaBox.Controls.Add(this.lblFechaLbl);
            this.pnlFacturaBox.Controls.Add(this.txtNumero);
            this.pnlFacturaBox.Controls.Add(this.lblNumeroLbl);
            this.pnlFacturaBox.Controls.Add(this.lblFacturaTitulo);
            this.pnlFacturaBox.Location = new System.Drawing.Point(782, 5);
            this.pnlFacturaBox.Name = "pnlFacturaBox";
            this.pnlFacturaBox.Size = new System.Drawing.Size(194, 90);
            this.pnlFacturaBox.TabIndex = 0;

            // ── lblFacturaTitulo ───────────────────────────────────────
            this.lblFacturaTitulo.AutoSize = true;
            this.lblFacturaTitulo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lblFacturaTitulo.ForeColor = System.Drawing.Color.FromArgb(0, 70, 130);
            this.lblFacturaTitulo.Location = new System.Drawing.Point(5, 5);
            this.lblFacturaTitulo.Name = "lblFacturaTitulo";
            this.lblFacturaTitulo.Text = "FACTURA DE VENTA";

            // ── lblNumeroLbl ───────────────────────────────────────────
            this.lblNumeroLbl.AutoSize = true;
            this.lblNumeroLbl.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.lblNumeroLbl.Location = new System.Drawing.Point(5, 30);
            this.lblNumeroLbl.Name = "lblNumeroLbl";
            this.lblNumeroLbl.Text = "N°:";

            // ── txtNumero ──────────────────────────────────────────────
            this.txtNumero.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.txtNumero.ForeColor = System.Drawing.Color.DarkRed;
            this.txtNumero.Location = new System.Drawing.Point(35, 27);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(150, 21);
            this.txtNumero.TabIndex = 1;

            // ── lblFechaLbl ────────────────────────────────────────────
            this.lblFechaLbl.AutoSize = true;
            this.lblFechaLbl.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.lblFechaLbl.Location = new System.Drawing.Point(5, 57);
            this.lblFechaLbl.Name = "lblFechaLbl";
            this.lblFechaLbl.Text = "Fecha:";

            // ── dtpFecha ───────────────────────────────────────────────
            this.dtpFecha.Font = new System.Drawing.Font("Arial", 8F);
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(55, 54);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(130, 20);
            this.dtpFecha.TabIndex = 2;

            // ── pnlCliente ─────────────────────────────────────────────
            this.pnlCliente.BackColor = System.Drawing.Color.FromArgb(245, 247, 252);
            this.pnlCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCliente.Controls.Add(this.txtClienteTel);
            this.pnlCliente.Controls.Add(this.txtClienteDireccion);
            this.pnlCliente.Controls.Add(this.txtClienteNIT);
            this.pnlCliente.Controls.Add(this.txtClienteNombre);
            this.pnlCliente.Controls.Add(this.lblCTelLbl);
            this.pnlCliente.Controls.Add(this.lblCDirLbl);
            this.pnlCliente.Controls.Add(this.lblCNITLbl);
            this.pnlCliente.Controls.Add(this.lblCNombreLbl);
            this.pnlCliente.Controls.Add(this.lblClienteTitulo);
            this.pnlCliente.Location = new System.Drawing.Point(6, 106);
            this.pnlCliente.Name = "pnlCliente";
            this.pnlCliente.Size = new System.Drawing.Size(972, 75);
            this.pnlCliente.TabIndex = 1;

            // ── lblClienteTitulo ───────────────────────────────────────
            this.lblClienteTitulo.AutoSize = true;
            this.lblClienteTitulo.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.lblClienteTitulo.ForeColor = System.Drawing.Color.FromArgb(0, 70, 130);
            this.lblClienteTitulo.Location = new System.Drawing.Point(5, 4);
            this.lblClienteTitulo.Name = "lblClienteTitulo";
            this.lblClienteTitulo.Text = "DATOS DEL CLIENTE";

            // ── lblCNombreLbl ──────────────────────────────────────────
            this.lblCNombreLbl.AutoSize = true;
            this.lblCNombreLbl.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.lblCNombreLbl.Location = new System.Drawing.Point(5, 27);
            this.lblCNombreLbl.Name = "lblCNombreLbl";
            this.lblCNombreLbl.Text = "Cliente:";

            // ── txtClienteNombre ───────────────────────────────────────
            this.txtClienteNombre.Location = new System.Drawing.Point(60, 24);
            this.txtClienteNombre.Name = "txtClienteNombre";
            this.txtClienteNombre.Size = new System.Drawing.Size(350, 20);
            this.txtClienteNombre.TabIndex = 3;

            // ── lblCNITLbl ─────────────────────────────────────────────
            this.lblCNITLbl.AutoSize = true;
            this.lblCNITLbl.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.lblCNITLbl.Location = new System.Drawing.Point(425, 27);
            this.lblCNITLbl.Name = "lblCNITLbl";
            this.lblCNITLbl.Text = "NIT / CC:";

            // ── txtClienteNIT ──────────────────────────────────────────
            this.txtClienteNIT.Location = new System.Drawing.Point(490, 24);
            this.txtClienteNIT.Name = "txtClienteNIT";
            this.txtClienteNIT.Size = new System.Drawing.Size(200, 20);
            this.txtClienteNIT.TabIndex = 4;

            // ── lblCDirLbl ─────────────────────────────────────────────
            this.lblCDirLbl.AutoSize = true;
            this.lblCDirLbl.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.lblCDirLbl.Location = new System.Drawing.Point(5, 51);
            this.lblCDirLbl.Name = "lblCDirLbl";
            this.lblCDirLbl.Text = "Dirección:";

            // ── txtClienteDireccion ────────────────────────────────────
            this.txtClienteDireccion.Location = new System.Drawing.Point(72, 48);
            this.txtClienteDireccion.Name = "txtClienteDireccion";
            this.txtClienteDireccion.Size = new System.Drawing.Size(338, 20);
            this.txtClienteDireccion.TabIndex = 5;

            // ── lblCTelLbl ─────────────────────────────────────────────
            this.lblCTelLbl.AutoSize = true;
            this.lblCTelLbl.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.lblCTelLbl.Location = new System.Drawing.Point(425, 51);
            this.lblCTelLbl.Name = "lblCTelLbl";
            this.lblCTelLbl.Text = "Teléfono:";

            // ── txtClienteTel ──────────────────────────────────────────
            this.txtClienteTel.Location = new System.Drawing.Point(490, 48);
            this.txtClienteTel.Name = "txtClienteTel";
            this.txtClienteTel.Size = new System.Drawing.Size(200, 20);
            this.txtClienteTel.TabIndex = 6;

            // ── dgvItems ───────────────────────────────────────────────
            this.dgvItems.AllowUserToAddRows = true;
            this.dgvItems.AllowUserToDeleteRows = true;
            this.dgvItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colDescripcion,
                this.colCantidad,
                this.colPrecioUnit,
                this.colTotal
            });
            this.dgvItems.Location = new System.Drawing.Point(6, 187);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.RowHeadersVisible = false;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.Size = new System.Drawing.Size(972, 272);
            this.dgvItems.TabIndex = 7;
            this.dgvItems.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItems_CellEndEdit);

            // ── colDescripcion ─────────────────────────────────────────
            this.colDescripcion.HeaderText = "Descripción del Producto / Servicio";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.Width = 452;

            // ── colCantidad ────────────────────────────────────────────
            this.colCantidad.HeaderText = "Cant.";
            this.colCantidad.Name = "colCantidad";
            this.colCantidad.Width = 75;

            // ── colPrecioUnit ──────────────────────────────────────────
            this.colPrecioUnit.HeaderText = "Precio Unitario";
            this.colPrecioUnit.Name = "colPrecioUnit";
            this.colPrecioUnit.Width = 195;

            // ── colTotal ───────────────────────────────────────────────
            this.colTotal.HeaderText = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;
            this.colTotal.Width = 195;
            this.colTotal.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(235, 242, 255);
            this.colTotal.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);

            // ── pnlObsTotales ──────────────────────────────────────────
            this.pnlObsTotales.Controls.Add(this.lblTotalVal);
            this.pnlObsTotales.Controls.Add(this.lblTotalLbl);
            this.pnlObsTotales.Controls.Add(this.lblIVAVal);
            this.pnlObsTotales.Controls.Add(this.lblIVALbl);
            this.pnlObsTotales.Controls.Add(this.lblSubtotalVal);
            this.pnlObsTotales.Controls.Add(this.lblSubtotalLbl);
            this.pnlObsTotales.Controls.Add(this.txtObservaciones);
            this.pnlObsTotales.Controls.Add(this.lblObsLbl);
            this.pnlObsTotales.Location = new System.Drawing.Point(6, 464);
            this.pnlObsTotales.Name = "pnlObsTotales";
            this.pnlObsTotales.Size = new System.Drawing.Size(972, 98);
            this.pnlObsTotales.TabIndex = 8;

            // ── lblObsLbl ──────────────────────────────────────────────
            this.lblObsLbl.AutoSize = true;
            this.lblObsLbl.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.lblObsLbl.ForeColor = System.Drawing.Color.FromArgb(0, 70, 130);
            this.lblObsLbl.Location = new System.Drawing.Point(3, 2);
            this.lblObsLbl.Name = "lblObsLbl";
            this.lblObsLbl.Text = "Observaciones:";

            // ── txtObservaciones ───────────────────────────────────────
            this.txtObservaciones.Location = new System.Drawing.Point(3, 18);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservaciones.Size = new System.Drawing.Size(538, 76);
            this.txtObservaciones.TabIndex = 9;

            // ── Totals ─────────────────────────────────────────────────
            int tx = 555;

            this.lblSubtotalLbl.AutoSize = true;
            this.lblSubtotalLbl.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lblSubtotalLbl.Location = new System.Drawing.Point(tx, 10);
            this.lblSubtotalLbl.Name = "lblSubtotalLbl";
            this.lblSubtotalLbl.Text = "Subtotal:";

            this.lblSubtotalVal.Font = new System.Drawing.Font("Arial", 9F);
            this.lblSubtotalVal.Location = new System.Drawing.Point(tx + 140, 10);
            this.lblSubtotalVal.Name = "lblSubtotalVal";
            this.lblSubtotalVal.Size = new System.Drawing.Size(160, 18);
            this.lblSubtotalVal.Text = "$ 0,00";
            this.lblSubtotalVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.lblIVALbl.AutoSize = true;
            this.lblIVALbl.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lblIVALbl.Location = new System.Drawing.Point(tx, 35);
            this.lblIVALbl.Name = "lblIVALbl";
            this.lblIVALbl.Text = "IVA (19%):";

            this.lblIVAVal.Font = new System.Drawing.Font("Arial", 9F);
            this.lblIVAVal.Location = new System.Drawing.Point(tx + 140, 35);
            this.lblIVAVal.Name = "lblIVAVal";
            this.lblIVAVal.Size = new System.Drawing.Size(160, 18);
            this.lblIVAVal.Text = "$ 0,00";
            this.lblIVAVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.lblTotalLbl.AutoSize = true;
            this.lblTotalLbl.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalLbl.ForeColor = System.Drawing.Color.FromArgb(0, 70, 130);
            this.lblTotalLbl.Location = new System.Drawing.Point(tx, 60);
            this.lblTotalLbl.Name = "lblTotalLbl";
            this.lblTotalLbl.Text = "TOTAL:";

            this.lblTotalVal.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalVal.ForeColor = System.Drawing.Color.FromArgb(0, 70, 130);
            this.lblTotalVal.Location = new System.Drawing.Point(tx + 140, 58);
            this.lblTotalVal.Name = "lblTotalVal";
            this.lblTotalVal.Size = new System.Drawing.Size(160, 28);
            this.lblTotalVal.Text = "$ 0,00";
            this.lblTotalVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // ── pnlAcciones ────────────────────────────────────────────
            this.pnlAcciones.BackColor = System.Drawing.Color.FromArgb(245, 247, 252);
            this.pnlAcciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAcciones.Controls.Add(this.btnExportarPDF);
            this.pnlAcciones.Controls.Add(this.btnEjemplo);
            this.pnlAcciones.Controls.Add(this.btnLimpiar);
            this.pnlAcciones.Controls.Add(this.btnImprimir);
            this.pnlAcciones.Controls.Add(this.btnVistaPrevia);
            this.pnlAcciones.Location = new System.Drawing.Point(6, 568);
            this.pnlAcciones.Name = "pnlAcciones";
            this.pnlAcciones.Size = new System.Drawing.Size(972, 50);
            this.pnlAcciones.TabIndex = 10;

            // ── btnVistaPrevia ─────────────────────────────────────────
            this.btnVistaPrevia.BackColor = System.Drawing.Color.FromArgb(0, 70, 130);
            this.btnVistaPrevia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVistaPrevia.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnVistaPrevia.ForeColor = System.Drawing.Color.White;
            this.btnVistaPrevia.Location = new System.Drawing.Point(8, 10);
            this.btnVistaPrevia.Name = "btnVistaPrevia";
            this.btnVistaPrevia.Size = new System.Drawing.Size(160, 30);
            this.btnVistaPrevia.TabIndex = 11;
            this.btnVistaPrevia.Text = "Vista Previa";
            this.btnVistaPrevia.UseVisualStyleBackColor = false;
            this.btnVistaPrevia.Click += new System.EventHandler(this.btnVistaPrevia_Click);

            // ── btnImprimir ────────────────────────────────────────────
            this.btnImprimir.BackColor = System.Drawing.Color.FromArgb(34, 139, 34);
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnImprimir.ForeColor = System.Drawing.Color.White;
            this.btnImprimir.Location = new System.Drawing.Point(180, 10);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(215, 30);
            this.btnImprimir.TabIndex = 12;
            this.btnImprimir.Text = "Imprimir / Guardar PDF";
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);

            // ── btnExportarPDF ─────────────────────────────────────────
            this.btnExportarPDF.BackColor = System.Drawing.Color.FromArgb(0, 130, 110);
            this.btnExportarPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarPDF.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnExportarPDF.ForeColor = System.Drawing.Color.White;
            this.btnExportarPDF.Location = new System.Drawing.Point(711, 10);
            this.btnExportarPDF.Name = "btnExportarPDF";
            this.btnExportarPDF.Size = new System.Drawing.Size(150, 30);
            this.btnExportarPDF.TabIndex = 15;
            this.btnExportarPDF.Text = "Exportar PDF";
            this.btnExportarPDF.UseVisualStyleBackColor = false;
            this.btnExportarPDF.Click += new System.EventHandler(this.btnExportarPDF_Click);

            // ── btnEjemplo ─────────────────────────────────────────────
            this.btnEjemplo.BackColor = System.Drawing.Color.FromArgb(180, 100, 0);
            this.btnEjemplo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEjemplo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnEjemplo.ForeColor = System.Drawing.Color.White;
            this.btnEjemplo.Location = new System.Drawing.Point(549, 10);
            this.btnEjemplo.Name = "btnEjemplo";
            this.btnEjemplo.Size = new System.Drawing.Size(150, 30);
            this.btnEjemplo.TabIndex = 14;
            this.btnEjemplo.Text = "Datos de Ejemplo";
            this.btnEjemplo.UseVisualStyleBackColor = false;
            this.btnEjemplo.Click += new System.EventHandler(this.btnEjemplo_Click);

            // ── btnLimpiar ─────────────────────────────────────────────
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(180, 50, 50);
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Location = new System.Drawing.Point(407, 10);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(130, 30);
            this.btnLimpiar.TabIndex = 13;
            this.btnLimpiar.Text = "Nueva Factura";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);

            // ── Form1 ──────────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 630);
            this.Controls.Add(this.pnlAcciones);
            this.Controls.Add(this.pnlObsTotales);
            this.Controls.Add(this.dgvItems);
            this.Controls.Add(this.pnlCliente);
            this.Controls.Add(this.pnlHeader);
            this.MinimumSize = new System.Drawing.Size(984, 660);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Facturación";

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFacturaBox.ResumeLayout(false);
            this.pnlFacturaBox.PerformLayout();
            this.pnlCliente.ResumeLayout(false);
            this.pnlCliente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.pnlObsTotales.ResumeLayout(false);
            this.pnlObsTotales.PerformLayout();
            this.pnlAcciones.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlFacturaBox;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblFechaLbl;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label lblNumeroLbl;
        private System.Windows.Forms.Label lblFacturaTitulo;
        private System.Windows.Forms.Label lblEmpresaInfo;
        private System.Windows.Forms.Label lblEmpresaNombre;
        private System.Windows.Forms.Panel pnlCliente;
        private System.Windows.Forms.TextBox txtClienteTel;
        private System.Windows.Forms.TextBox txtClienteDireccion;
        private System.Windows.Forms.TextBox txtClienteNIT;
        private System.Windows.Forms.TextBox txtClienteNombre;
        private System.Windows.Forms.Label lblCTelLbl;
        private System.Windows.Forms.Label lblCDirLbl;
        private System.Windows.Forms.Label lblCNITLbl;
        private System.Windows.Forms.Label lblCNombreLbl;
        private System.Windows.Forms.Label lblClienteTitulo;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecioUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.Panel pnlObsTotales;
        private System.Windows.Forms.Label lblTotalVal;
        private System.Windows.Forms.Label lblTotalLbl;
        private System.Windows.Forms.Label lblIVAVal;
        private System.Windows.Forms.Label lblIVALbl;
        private System.Windows.Forms.Label lblSubtotalVal;
        private System.Windows.Forms.Label lblSubtotalLbl;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Label lblObsLbl;
        private System.Windows.Forms.Panel pnlAcciones;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnVistaPrevia;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnEjemplo;
        private System.Windows.Forms.Button btnExportarPDF;
    }
}
