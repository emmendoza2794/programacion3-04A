namespace Graficas
{
    partial class HelixToolTikForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblEscalaZ = new System.Windows.Forms.Label();
            this.lblResolucion = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.trackEscalaZ = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.trackResolucion = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.cmbGrafica = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackEscalaZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackResolucion)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.cmbGrafica);
            this.splitContainer1.Panel1.Controls.Add(this.lblEscalaZ);
            this.splitContainer1.Panel1.Controls.Add(this.lblResolucion);
            this.splitContainer1.Panel1.Controls.Add(this.btnReset);
            this.splitContainer1.Panel1.Controls.Add(this.trackEscalaZ);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.trackResolucion);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.elementHost1);
            this.splitContainer1.Size = new System.Drawing.Size(1029, 587);
            this.splitContainer1.SplitterDistance = 343;
            this.splitContainer1.TabIndex = 0;
            // 
            // lblEscalaZ
            // 
            this.lblEscalaZ.AutoSize = true;
            this.lblEscalaZ.Location = new System.Drawing.Point(177, 437);
            this.lblEscalaZ.Name = "lblEscalaZ";
            this.lblEscalaZ.Size = new System.Drawing.Size(73, 16);
            this.lblEscalaZ.TabIndex = 7;
            this.lblEscalaZ.Text = "Escala Z: 4";
            // 
            // lblResolucion
            // 
            this.lblResolucion.AutoSize = true;
            this.lblResolucion.Location = new System.Drawing.Point(22, 437);
            this.lblResolucion.Name = "lblResolucion";
            this.lblResolucion.Size = new System.Drawing.Size(95, 16);
            this.lblResolucion.TabIndex = 6;
            this.lblResolucion.Text = "Resolución: 60";
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(25, 354);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(204, 45);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "Reset Cámara";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // trackEscalaZ
            // 
            this.trackEscalaZ.Location = new System.Drawing.Point(35, 255);
            this.trackEscalaZ.Minimum = 1;
            this.trackEscalaZ.Name = "trackEscalaZ";
            this.trackEscalaZ.Size = new System.Drawing.Size(249, 56);
            this.trackEscalaZ.TabIndex = 3;
            this.trackEscalaZ.Value = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 213);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "Escala Z";
            // 
            // trackResolucion
            // 
            this.trackResolucion.Location = new System.Drawing.Point(25, 154);
            this.trackResolucion.Maximum = 100;
            this.trackResolucion.Minimum = 20;
            this.trackResolucion.Name = "trackResolucion";
            this.trackResolucion.Size = new System.Drawing.Size(259, 56);
            this.trackResolucion.TabIndex = 1;
            this.trackResolucion.Value = 60;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Resolución";
            // 
            // elementHost1
            // 
            this.elementHost1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementHost1.Location = new System.Drawing.Point(0, 0);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(682, 587);
            this.elementHost1.TabIndex = 0;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = null;
            // 
            // cmbGrafica
            // 
            this.cmbGrafica.FormattingEnabled = true;
            this.cmbGrafica.Location = new System.Drawing.Point(35, 71);
            this.cmbGrafica.Name = "cmbGrafica";
            this.cmbGrafica.Size = new System.Drawing.Size(215, 24);
            this.cmbGrafica.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(30, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(197, 29);
            this.label3.TabIndex = 9;
            this.label3.Text = "Tipo de gráfica:";
            // 
            // HelixToolTikForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1029, 587);
            this.Controls.Add(this.splitContainer1);
            this.Name = "HelixToolTikForm";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackEscalaZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackResolucion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TrackBar trackResolucion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackEscalaZ;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private System.Windows.Forms.Label lblEscalaZ;
        private System.Windows.Forms.Label lblResolucion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbGrafica;
    }
}

