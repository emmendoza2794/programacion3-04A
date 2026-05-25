namespace Parte_Proyecto_MZ
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnLimpiarXYZ = new System.Windows.Forms.Button();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.TxtZ = new System.Windows.Forms.TextBox();
            this.TxtY = new System.Windows.Forms.TextBox();
            this.TxtX = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnLimpiardgv = new System.Windows.Forms.Button();
            this.dgvXYZ = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.TxtVolumen = new System.Windows.Forms.TextBox();
            this.TxtArea = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvXYZ)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(798, 50);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(61, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(648, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gestión del terreno y cálculo matemático";
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel2.Controls.Add(this.btnLimpiarXYZ);
            this.panel2.Controls.Add(this.btnCalcular);
            this.panel2.Controls.Add(this.btnAgregar);
            this.panel2.Controls.Add(this.TxtZ);
            this.panel2.Controls.Add(this.TxtY);
            this.panel2.Controls.Add(this.TxtX);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(6, 51);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(226, 249);
            this.panel2.TabIndex = 1;
            // 
            // btnLimpiarXYZ
            // 
            this.btnLimpiarXYZ.Location = new System.Drawing.Point(139, 221);
            this.btnLimpiarXYZ.Name = "btnLimpiarXYZ";
            this.btnLimpiarXYZ.Size = new System.Drawing.Size(75, 25);
            this.btnLimpiarXYZ.TabIndex = 8;
            this.btnLimpiarXYZ.Text = "Limpiar";
            this.btnLimpiarXYZ.UseVisualStyleBackColor = true;
            this.btnLimpiarXYZ.Visible = false;
            // 
            // btnCalcular
            // 
            this.btnCalcular.Location = new System.Drawing.Point(74, 190);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(75, 25);
            this.btnCalcular.TabIndex = 15;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(7, 221);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 25);
            this.btnAgregar.TabIndex = 7;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // TxtZ
            // 
            this.TxtZ.Location = new System.Drawing.Point(40, 146);
            this.TxtZ.Name = "TxtZ";
            this.TxtZ.Size = new System.Drawing.Size(66, 22);
            this.TxtZ.TabIndex = 6;
            // 
            // TxtY
            // 
            this.TxtY.Location = new System.Drawing.Point(40, 95);
            this.TxtY.Name = "TxtY";
            this.TxtY.Size = new System.Drawing.Size(66, 22);
            this.TxtY.TabIndex = 5;
            // 
            // TxtX
            // 
            this.TxtX.Location = new System.Drawing.Point(40, 46);
            this.TxtX.Name = "TxtX";
            this.TxtX.Size = new System.Drawing.Size(66, 22);
            this.TxtX.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Z :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Y :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "X :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(228, 27);
            this.label2.TabIndex = 0;
            this.label2.Text = "INGRESO DE DATOS";
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel3.Controls.Add(this.btnLimpiardgv);
            this.panel3.Controls.Add(this.dgvXYZ);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Location = new System.Drawing.Point(240, 52);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(327, 249);
            this.panel3.TabIndex = 2;
            // 
            // btnLimpiardgv
            // 
            this.btnLimpiardgv.Location = new System.Drawing.Point(119, 208);
            this.btnLimpiardgv.Name = "btnLimpiardgv";
            this.btnLimpiardgv.Size = new System.Drawing.Size(75, 25);
            this.btnLimpiardgv.TabIndex = 16;
            this.btnLimpiardgv.Text = "Limpiar";
            this.btnLimpiardgv.UseVisualStyleBackColor = true;
            this.btnLimpiardgv.Click += new System.EventHandler(this.btnLimpiardgv_Click);
            // 
            // dgvXYZ
            // 
            this.dgvXYZ.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvXYZ.Location = new System.Drawing.Point(3, 31);
            this.dgvXYZ.Name = "dgvXYZ";
            this.dgvXYZ.RowHeadersWidth = 51;
            this.dgvXYZ.Size = new System.Drawing.Size(321, 171);
            this.dgvXYZ.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(42, 1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(250, 27);
            this.label6.TabIndex = 9;
            this.label6.Text = "LISTA COORDENADAS";
            // 
            // panel4
            // 
            this.panel4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel4.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel4.Controls.Add(this.button4);
            this.panel4.Controls.Add(this.textBox6);
            this.panel4.Controls.Add(this.TxtVolumen);
            this.panel4.Controls.Add(this.TxtArea);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Location = new System.Drawing.Point(573, 51);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(226, 250);
            this.panel4.TabIndex = 3;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(140, 197);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 25);
            this.button4.TabIndex = 16;
            this.button4.Text = "Graficar";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(70, 149);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(66, 22);
            this.textBox6.TabIndex = 14;
            // 
            // TxtVolumen
            // 
            this.TxtVolumen.Location = new System.Drawing.Point(88, 101);
            this.TxtVolumen.Name = "TxtVolumen";
            this.TxtVolumen.Size = new System.Drawing.Size(66, 22);
            this.TxtVolumen.TabIndex = 9;
            // 
            // TxtArea
            // 
            this.TxtArea.Location = new System.Drawing.Point(70, 46);
            this.TxtArea.Name = "TxtArea";
            this.TxtArea.Size = new System.Drawing.Size(66, 22);
            this.TxtArea.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 152);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 16);
            this.label10.TabIndex = 13;
            this.label10.Text = "COSTO :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 101);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 16);
            this.label9.TabIndex = 12;
            this.label9.Text = "VOLUMEN :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 16);
            this.label8.TabIndex = 11;
            this.label8.Text = "AREA :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(34, 1);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(166, 27);
            this.label7.TabIndex = 10;
            this.label7.Text = "RESULTADOS ";
            // 
            // panel6
            // 
            this.panel6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel6.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.label12);
            this.panel6.Location = new System.Drawing.Point(6, 304);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(798, 50);
            this.panel6.TabIndex = 4;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(296, 8);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(170, 38);
            this.label12.TabIndex = 0;
            this.label12.Text = "GRÁFICA";
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(12, 0);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(775, 287);
            this.chart1.TabIndex = 5;
            this.chart1.Text = "chart1";
            // 
            // panel7
            // 
            this.panel7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel7.Controls.Add(this.chart1);
            this.panel7.Location = new System.Drawing.Point(6, 355);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(798, 280);
            this.panel7.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 641);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "TerrenoForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvXYZ)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLimpiarXYZ;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox TxtZ;
        private System.Windows.Forms.TextBox TxtY;
        private System.Windows.Forms.TextBox TxtX;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtArea;
        private System.Windows.Forms.TextBox TxtVolumen;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.DataGridView dgvXYZ;
        private System.Windows.Forms.Button btnLimpiardgv;
    }
}

