namespace grafica_volumen
{
    partial class Form2
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
            this.host = new System.Windows.Forms.Integration.ElementHost();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnReset = new System.Windows.Forms.Button();
            this.pnlColorTerreno = new System.Windows.Forms.Panel();
            this.lblColorTerreno = new System.Windows.Forms.Label();
            this.pnlColorCorte = new System.Windows.Forms.Panel();
            this.lblColorCorte = new System.Windows.Forms.Label();
            this.pnlColorBase = new System.Windows.Forms.Panel();
            this.lblColorBase = new System.Windows.Forms.Label();

            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();

            // host (ElementHost para WPF)
            this.host.Dock = System.Windows.Forms.DockStyle.Fill;
            this.host.Name = "host";
            this.host.TabIndex = 0;
            this.host.Text = "host";

            // pnlBottom
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(50, 50, 50);
            this.pnlBottom.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.btnReset,
                this.pnlColorTerreno,
                this.lblColorTerreno,
                this.pnlColorCorte,
                this.lblColorCorte,
                this.pnlColorBase,
                this.lblColorBase
            });
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Height = 40;
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.TabIndex = 1;

            // btnReset
            this.btnReset.BackColor = System.Drawing.Color.SteelBlue;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(8, 7);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(110, 26);
            this.btnReset.TabIndex = 0;
            this.btnReset.Text = "Reset cámara";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);

            // pnlColorTerreno  (naranja-rojo — gradiente cálido sobre h)
            this.pnlColorTerreno.BackColor = System.Drawing.Color.FromArgb(210, 60, 5);
            this.pnlColorTerreno.Location = new System.Drawing.Point(135, 12);
            this.pnlColorTerreno.Name = "pnlColorTerreno";
            this.pnlColorTerreno.Size = new System.Drawing.Size(16, 16);
            this.pnlColorTerreno.TabIndex = 1;

            // lblColorTerreno
            this.lblColorTerreno.AutoSize = true;
            this.lblColorTerreno.ForeColor = System.Drawing.Color.White;
            this.lblColorTerreno.Location = new System.Drawing.Point(155, 10);
            this.lblColorTerreno.Name = "lblColorTerreno";
            this.lblColorTerreno.TabIndex = 2;
            this.lblColorTerreno.Text = "Sobre h — volumen a excavar";

            // pnlColorCorte  (amarillo — color del plano de corte)
            this.pnlColorCorte.BackColor = System.Drawing.Color.FromArgb(240, 220, 80);
            this.pnlColorCorte.Location = new System.Drawing.Point(310, 12);
            this.pnlColorCorte.Name = "pnlColorCorte";
            this.pnlColorCorte.Size = new System.Drawing.Size(16, 16);
            this.pnlColorCorte.TabIndex = 3;

            // lblColorCorte
            this.lblColorCorte.AutoSize = true;
            this.lblColorCorte.ForeColor = System.Drawing.Color.White;
            this.lblColorCorte.Location = new System.Drawing.Point(330, 10);
            this.lblColorCorte.Name = "lblColorCorte";
            this.lblColorCorte.TabIndex = 4;
            this.lblColorCorte.Text = "Plano de corte h";

            // pnlColorBase  (verde — gradiente frío bajo h)
            this.pnlColorBase.BackColor = System.Drawing.Color.FromArgb(60, 135, 50);
            this.pnlColorBase.Location = new System.Drawing.Point(480, 12);
            this.pnlColorBase.Name = "pnlColorBase";
            this.pnlColorBase.Size = new System.Drawing.Size(16, 16);
            this.pnlColorBase.TabIndex = 5;

            // lblColorBase
            this.lblColorBase.AutoSize = true;
            this.lblColorBase.ForeColor = System.Drawing.Color.White;
            this.lblColorBase.Location = new System.Drawing.Point(500, 10);
            this.lblColorBase.Name = "lblColorBase";
            this.lblColorBase.TabIndex = 6;
            this.lblColorBase.Text = "Bajo h — sin excavar";

            // Form2
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 680);
            this.Controls.Add(this.host);
            this.Controls.Add(this.pnlBottom);
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "Form2";
            this.Text = "Gráfica 3D — Volumen de Excavación";

            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Integration.ElementHost host;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Panel pnlColorTerreno;
        private System.Windows.Forms.Label lblColorTerreno;
        private System.Windows.Forms.Panel pnlColorCorte;
        private System.Windows.Forms.Label lblColorCorte;
        private System.Windows.Forms.Panel pnlColorBase;
        private System.Windows.Forms.Label lblColorBase;
    }
}
