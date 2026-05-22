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
            // 
            // host
            // 
            this.host.Dock = System.Windows.Forms.DockStyle.Fill;
            this.host.Location = new System.Drawing.Point(0, 0);
            this.host.Name = "host";
            this.host.Size = new System.Drawing.Size(950, 598);
            this.host.TabIndex = 0;
            this.host.Text = "host";
            this.host.Child = null;
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.pnlBottom.Controls.Add(this.btnReset);
            this.pnlBottom.Controls.Add(this.pnlColorTerreno);
            this.pnlBottom.Controls.Add(this.lblColorTerreno);
            this.pnlBottom.Controls.Add(this.pnlColorCorte);
            this.pnlBottom.Controls.Add(this.lblColorCorte);
            this.pnlBottom.Controls.Add(this.pnlColorBase);
            this.pnlBottom.Controls.Add(this.lblColorBase);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 598);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(950, 82);
            this.pnlBottom.TabIndex = 1;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.SteelBlue;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(12, 27);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(110, 26);
            this.btnReset.TabIndex = 0;
            this.btnReset.Text = "Reset cámara";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // pnlColorTerreno
            // 
            this.pnlColorTerreno.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(60)))), ((int)(((byte)(5)))));
            this.pnlColorTerreno.Location = new System.Drawing.Point(139, 32);
            this.pnlColorTerreno.Name = "pnlColorTerreno";
            this.pnlColorTerreno.Size = new System.Drawing.Size(16, 16);
            this.pnlColorTerreno.TabIndex = 1;
            // 
            // lblColorTerreno
            // 
            this.lblColorTerreno.AutoSize = true;
            this.lblColorTerreno.ForeColor = System.Drawing.Color.White;
            this.lblColorTerreno.Location = new System.Drawing.Point(159, 30);
            this.lblColorTerreno.Name = "lblColorTerreno";
            this.lblColorTerreno.Size = new System.Drawing.Size(182, 16);
            this.lblColorTerreno.TabIndex = 2;
            this.lblColorTerreno.Text = "Sobre h — volumen a excavar";
            // 
            // pnlColorCorte
            // 
            this.pnlColorCorte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(220)))), ((int)(((byte)(80)))));
            this.pnlColorCorte.Location = new System.Drawing.Point(314, 32);
            this.pnlColorCorte.Name = "pnlColorCorte";
            this.pnlColorCorte.Size = new System.Drawing.Size(16, 16);
            this.pnlColorCorte.TabIndex = 3;
            // 
            // lblColorCorte
            // 
            this.lblColorCorte.AutoSize = true;
            this.lblColorCorte.ForeColor = System.Drawing.Color.White;
            this.lblColorCorte.Location = new System.Drawing.Point(347, 32);
            this.lblColorCorte.Name = "lblColorCorte";
            this.lblColorCorte.Size = new System.Drawing.Size(104, 16);
            this.lblColorCorte.TabIndex = 4;
            this.lblColorCorte.Text = "Plano de corte h";
            // 
            // pnlColorBase
            // 
            this.pnlColorBase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(135)))), ((int)(((byte)(50)))));
            this.pnlColorBase.Location = new System.Drawing.Point(484, 32);
            this.pnlColorBase.Name = "pnlColorBase";
            this.pnlColorBase.Size = new System.Drawing.Size(16, 16);
            this.pnlColorBase.TabIndex = 5;
            // 
            // lblColorBase
            // 
            this.lblColorBase.AutoSize = true;
            this.lblColorBase.ForeColor = System.Drawing.Color.White;
            this.lblColorBase.Location = new System.Drawing.Point(524, 32);
            this.lblColorBase.Name = "lblColorBase";
            this.lblColorBase.Size = new System.Drawing.Size(128, 16);
            this.lblColorBase.TabIndex = 6;
            this.lblColorBase.Text = "Bajo h — sin excavar";
            // 
            // Form2
            // 
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
