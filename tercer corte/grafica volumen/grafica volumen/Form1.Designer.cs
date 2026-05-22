namespace grafica_volumen
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

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.nudFilas = new System.Windows.Forms.NumericUpDown();
            this.nudColumnas = new System.Windows.Forms.NumericUpDown();
            this.nudH = new System.Windows.Forms.NumericUpDown();
            this.nudDx = new System.Windows.Forms.NumericUpDown();
            this.nudDy = new System.Windows.Forms.NumericUpDown();
            this.dgvTerreno = new System.Windows.Forms.DataGridView();
            this.btnCrearGrid = new System.Windows.Forms.Button();
            this.btnEjemplo = new System.Windows.Forms.Button();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.btnGrafica = new System.Windows.Forms.Button();
            this.lblResultado = new System.Windows.Forms.Label();
            this.lblFilas = new System.Windows.Forms.Label();
            this.lblColumnas = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblEjemploTitulo = new System.Windows.Forms.Label();
            this.lblH = new System.Windows.Forms.Label();
            this.lblDx = new System.Windows.Forms.Label();
            this.lblDy = new System.Windows.Forms.Label();
            this.txtEjemplo = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudFilas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudColumnas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTerreno)).BeginInit();
            this.SuspendLayout();
            // 
            // nudFilas
            // 
            this.nudFilas.Location = new System.Drawing.Point(58, 13);
            this.nudFilas.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudFilas.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudFilas.Name = "nudFilas";
            this.nudFilas.Size = new System.Drawing.Size(50, 22);
            this.nudFilas.TabIndex = 1;
            this.nudFilas.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // nudColumnas
            // 
            this.nudColumnas.Location = new System.Drawing.Point(185, 13);
            this.nudColumnas.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudColumnas.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudColumnas.Name = "nudColumnas";
            this.nudColumnas.Size = new System.Drawing.Size(50, 22);
            this.nudColumnas.TabIndex = 3;
            this.nudColumnas.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // nudH
            // 
            this.nudH.DecimalPlaces = 2;
            this.nudH.Location = new System.Drawing.Point(118, 489);
            this.nudH.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudH.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.nudH.Name = "nudH";
            this.nudH.Size = new System.Drawing.Size(70, 22);
            this.nudH.TabIndex = 11;
            // 
            // nudDx
            // 
            this.nudDx.DecimalPlaces = 2;
            this.nudDx.Location = new System.Drawing.Point(248, 489);
            this.nudDx.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudDx.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDx.Name = "nudDx";
            this.nudDx.Size = new System.Drawing.Size(65, 22);
            this.nudDx.TabIndex = 13;
            this.nudDx.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudDy
            // 
            this.nudDy.DecimalPlaces = 2;
            this.nudDy.Location = new System.Drawing.Point(373, 489);
            this.nudDy.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudDy.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDy.Name = "nudDy";
            this.nudDy.Size = new System.Drawing.Size(65, 22);
            this.nudDy.TabIndex = 15;
            this.nudDy.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // dgvTerreno
            // 
            this.dgvTerreno.AllowUserToAddRows = false;
            this.dgvTerreno.AllowUserToDeleteRows = false;
            this.dgvTerreno.ColumnHeadersHeight = 29;
            this.dgvTerreno.Location = new System.Drawing.Point(12, 68);
            this.dgvTerreno.Name = "dgvTerreno";
            this.dgvTerreno.RowHeadersWidth = 55;
            this.dgvTerreno.Size = new System.Drawing.Size(527, 390);
            this.dgvTerreno.TabIndex = 7;
            // 
            // btnCrearGrid
            // 
            this.btnCrearGrid.Location = new System.Drawing.Point(248, 11);
            this.btnCrearGrid.Name = "btnCrearGrid";
            this.btnCrearGrid.Size = new System.Drawing.Size(130, 28);
            this.btnCrearGrid.TabIndex = 4;
            this.btnCrearGrid.Text = "Crear cuadrícula";
            this.btnCrearGrid.Click += new System.EventHandler(this.btnCrearGrid_Click);
            // 
            // btnEjemplo
            // 
            this.btnEjemplo.BackColor = System.Drawing.Color.DarkOrange;
            this.btnEjemplo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEjemplo.ForeColor = System.Drawing.Color.White;
            this.btnEjemplo.Location = new System.Drawing.Point(390, 11);
            this.btnEjemplo.Name = "btnEjemplo";
            this.btnEjemplo.Size = new System.Drawing.Size(130, 28);
            this.btnEjemplo.TabIndex = 5;
            this.btnEjemplo.Text = "Datos aleatorios";
            this.btnEjemplo.UseVisualStyleBackColor = false;
            this.btnEjemplo.Click += new System.EventHandler(this.BtnEjemplo_Click);
            // 
            // btnCalcular
            // 
            this.btnCalcular.BackColor = System.Drawing.Color.SteelBlue;
            this.btnCalcular.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalcular.ForeColor = System.Drawing.Color.White;
            this.btnCalcular.Location = new System.Drawing.Point(452, 487);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(140, 30);
            this.btnCalcular.TabIndex = 16;
            this.btnCalcular.Text = "Calcular volumen";
            this.btnCalcular.UseVisualStyleBackColor = false;
            this.btnCalcular.Click += new System.EventHandler(this.BtnCalcular_Click);
            // 
            // btnGrafica
            // 
            this.btnGrafica.BackColor = System.Drawing.Color.ForestGreen;
            this.btnGrafica.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGrafica.ForeColor = System.Drawing.Color.White;
            this.btnGrafica.Location = new System.Drawing.Point(606, 487);
            this.btnGrafica.Name = "btnGrafica";
            this.btnGrafica.Size = new System.Drawing.Size(140, 30);
            this.btnGrafica.TabIndex = 17;
            this.btnGrafica.Text = "Ver Gráfica 3D";
            this.btnGrafica.UseVisualStyleBackColor = false;
            this.btnGrafica.Click += new System.EventHandler(this.BtnGrafica_Click);
            // 
            // lblResultado
            // 
            this.lblResultado.AutoSize = true;
            this.lblResultado.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblResultado.Location = new System.Drawing.Point(12, 532);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(138, 30);
            this.lblResultado.TabIndex = 18;
            this.lblResultado.Text = "Volumen: —";
            // 
            // lblFilas
            // 
            this.lblFilas.AutoSize = true;
            this.lblFilas.Location = new System.Drawing.Point(12, 16);
            this.lblFilas.Name = "lblFilas";
            this.lblFilas.Size = new System.Drawing.Size(39, 16);
            this.lblFilas.TabIndex = 0;
            this.lblFilas.Text = "Filas:";
            // 
            // lblColumnas
            // 
            this.lblColumnas.AutoSize = true;
            this.lblColumnas.Location = new System.Drawing.Point(118, 16);
            this.lblColumnas.Name = "lblColumnas";
            this.lblColumnas.Size = new System.Drawing.Size(70, 16);
            this.lblColumnas.TabIndex = 2;
            this.lblColumnas.Text = "Columnas:";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.ForeColor = System.Drawing.Color.Gray;
            this.lblInfo.Location = new System.Drawing.Point(12, 48);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(200, 16);
            this.lblInfo.TabIndex = 6;
            this.lblInfo.Text = "Alturas f(x,y) del terreno [metros]:";
            // 
            // lblEjemploTitulo
            // 
            this.lblEjemploTitulo.AutoSize = true;
            this.lblEjemploTitulo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblEjemploTitulo.Location = new System.Drawing.Point(541, 41);
            this.lblEjemploTitulo.Name = "lblEjemploTitulo";
            this.lblEjemploTitulo.Size = new System.Drawing.Size(151, 23);
            this.lblEjemploTitulo.TabIndex = 8;
            this.lblEjemploTitulo.Text = "Datos de ejemplo";
            // 
            // lblH
            // 
            this.lblH.AutoSize = true;
            this.lblH.Location = new System.Drawing.Point(12, 492);
            this.lblH.Name = "lblH";
            this.lblH.Size = new System.Drawing.Size(100, 16);
            this.lblH.TabIndex = 10;
            this.lblH.Text = "Cota de corte h:";
            // 
            // lblDx
            // 
            this.lblDx.AutoSize = true;
            this.lblDx.Location = new System.Drawing.Point(200, 492);
            this.lblDx.Name = "lblDx";
            this.lblDx.Size = new System.Drawing.Size(47, 16);
            this.lblDx.TabIndex = 12;
            this.lblDx.Text = "Δx (m):";
            // 
            // lblDy
            // 
            this.lblDy.AutoSize = true;
            this.lblDy.Location = new System.Drawing.Point(325, 492);
            this.lblDy.Name = "lblDy";
            this.lblDy.Size = new System.Drawing.Size(48, 16);
            this.lblDy.TabIndex = 14;
            this.lblDy.Text = "Δy (m):";
            // 
            // txtEjemplo
            // 
            this.txtEjemplo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.txtEjemplo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEjemplo.Font = new System.Drawing.Font("Consolas", 9F);
            this.txtEjemplo.Location = new System.Drawing.Point(545, 68);
            this.txtEjemplo.Name = "txtEjemplo";
            this.txtEjemplo.ReadOnly = true;
            this.txtEjemplo.Size = new System.Drawing.Size(435, 392);
            this.txtEjemplo.TabIndex = 9;
            this.txtEjemplo.Text = resources.GetString("txtEjemplo.Text");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 580);
            this.Controls.Add(this.lblFilas);
            this.Controls.Add(this.nudFilas);
            this.Controls.Add(this.lblColumnas);
            this.Controls.Add(this.nudColumnas);
            this.Controls.Add(this.btnCrearGrid);
            this.Controls.Add(this.btnEjemplo);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.dgvTerreno);
            this.Controls.Add(this.lblEjemploTitulo);
            this.Controls.Add(this.txtEjemplo);
            this.Controls.Add(this.lblH);
            this.Controls.Add(this.nudH);
            this.Controls.Add(this.lblDx);
            this.Controls.Add(this.nudDx);
            this.Controls.Add(this.lblDy);
            this.Controls.Add(this.nudDy);
            this.Controls.Add(this.btnCalcular);
            this.Controls.Add(this.btnGrafica);
            this.Controls.Add(this.lblResultado);
            this.MinimumSize = new System.Drawing.Size(1000, 580);
            this.Name = "Form1";
            this.Text = "Cálculo de Volumen de Tierra — Integral Doble Discreta";
            ((System.ComponentModel.ISupportInitialize)(this.nudFilas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudColumnas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTerreno)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudFilas;
        private System.Windows.Forms.NumericUpDown nudColumnas;
        private System.Windows.Forms.NumericUpDown nudH;
        private System.Windows.Forms.NumericUpDown nudDx;
        private System.Windows.Forms.NumericUpDown nudDy;
        private System.Windows.Forms.DataGridView dgvTerreno;
        private System.Windows.Forms.Button btnCrearGrid;
        private System.Windows.Forms.Button btnEjemplo;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.Button btnGrafica;
        private System.Windows.Forms.Label lblResultado;
        private System.Windows.Forms.Label lblFilas;
        private System.Windows.Forms.Label lblColumnas;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblEjemploTitulo;
        private System.Windows.Forms.Label lblH;
        private System.Windows.Forms.Label lblDx;
        private System.Windows.Forms.Label lblDy;
        private System.Windows.Forms.RichTextBox txtEjemplo;
    }
}
