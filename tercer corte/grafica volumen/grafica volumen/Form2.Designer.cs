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
            this.host             = new System.Windows.Forms.Integration.ElementHost();
            this.pnlBottom        = new System.Windows.Forms.Panel();
            this.btnReset         = new System.Windows.Forms.Button();
            this.pnlColorTerreno  = new System.Windows.Forms.Panel();
            this.lblColorTerreno  = new System.Windows.Forms.Label();
            this.pnlColorCorte    = new System.Windows.Forms.Panel();
            this.lblColorCorte    = new System.Windows.Forms.Label();
            this.pnlColorBase     = new System.Windows.Forms.Panel();
            this.lblColorBase     = new System.Windows.Forms.Label();
            this.pnlRight         = new System.Windows.Forms.Panel();
            this.chkPuntos        = new System.Windows.Forms.CheckBox();
            this.chkEtiquetas     = new System.Windows.Forms.CheckBox();
            this.lblH             = new System.Windows.Forms.Label();
            this.lblHVal          = new System.Windows.Forms.Label();
            this.trkH             = new System.Windows.Forms.TrackBar();
            this.lblDx            = new System.Windows.Forms.Label();
            this.lblDxVal         = new System.Windows.Forms.Label();
            this.trkDx            = new System.Windows.Forms.TrackBar();
            this.lblDy            = new System.Windows.Forms.Label();
            this.lblDyVal         = new System.Windows.Forms.Label();
            this.trkDy            = new System.Windows.Forms.TrackBar();
            this.pnlBottom.SuspendLayout();
            this.pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkDx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkDy)).BeginInit();
            this.SuspendLayout();

            // host
            this.host.Dock     = System.Windows.Forms.DockStyle.Fill;
            this.host.Location = new System.Drawing.Point(0, 0);
            this.host.Name     = "host";
            this.host.Size     = new System.Drawing.Size(765, 598);
            this.host.TabIndex = 0;
            this.host.Text     = "host";
            this.host.Child    = null;

            // pnlBottom
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(50, 50, 50);
            this.pnlBottom.Controls.Add(this.btnReset);
            this.pnlBottom.Controls.Add(this.pnlColorTerreno);
            this.pnlBottom.Controls.Add(this.lblColorTerreno);
            this.pnlBottom.Controls.Add(this.pnlColorCorte);
            this.pnlBottom.Controls.Add(this.lblColorCorte);
            this.pnlBottom.Controls.Add(this.pnlColorBase);
            this.pnlBottom.Controls.Add(this.lblColorBase);
            this.pnlBottom.Dock     = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 598);
            this.pnlBottom.Name     = "pnlBottom";
            this.pnlBottom.Size     = new System.Drawing.Size(950, 82);
            this.pnlBottom.TabIndex = 1;

            // btnReset
            this.btnReset.BackColor = System.Drawing.Color.SteelBlue;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location  = new System.Drawing.Point(12, 27);
            this.btnReset.Name      = "btnReset";
            this.btnReset.Size      = new System.Drawing.Size(110, 26);
            this.btnReset.TabIndex  = 0;
            this.btnReset.Text      = "Reset cámara";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click    += new System.EventHandler(this.btnReset_Click);

            // pnlColorTerreno
            this.pnlColorTerreno.BackColor = System.Drawing.Color.FromArgb(210, 60, 5);
            this.pnlColorTerreno.Location  = new System.Drawing.Point(139, 32);
            this.pnlColorTerreno.Name      = "pnlColorTerreno";
            this.pnlColorTerreno.Size      = new System.Drawing.Size(16, 16);
            this.pnlColorTerreno.TabIndex  = 1;

            // lblColorTerreno
            this.lblColorTerreno.AutoSize  = true;
            this.lblColorTerreno.ForeColor = System.Drawing.Color.White;
            this.lblColorTerreno.Location  = new System.Drawing.Point(159, 30);
            this.lblColorTerreno.Name      = "lblColorTerreno";
            this.lblColorTerreno.TabIndex  = 2;
            this.lblColorTerreno.Text      = "Sobre h — volumen a excavar";

            // pnlColorCorte
            this.pnlColorCorte.BackColor = System.Drawing.Color.FromArgb(240, 220, 80);
            this.pnlColorCorte.Location  = new System.Drawing.Point(370, 32);
            this.pnlColorCorte.Name      = "pnlColorCorte";
            this.pnlColorCorte.Size      = new System.Drawing.Size(16, 16);
            this.pnlColorCorte.TabIndex  = 3;

            // lblColorCorte
            this.lblColorCorte.AutoSize  = true;
            this.lblColorCorte.ForeColor = System.Drawing.Color.White;
            this.lblColorCorte.Location  = new System.Drawing.Point(390, 30);
            this.lblColorCorte.Name      = "lblColorCorte";
            this.lblColorCorte.TabIndex  = 4;
            this.lblColorCorte.Text      = "Plano de corte h";

            // pnlColorBase — azul marino = zona bajo h
            this.pnlColorBase.BackColor = System.Drawing.Color.FromArgb(20, 80, 140);
            this.pnlColorBase.Location  = new System.Drawing.Point(530, 32);
            this.pnlColorBase.Name      = "pnlColorBase";
            this.pnlColorBase.Size      = new System.Drawing.Size(16, 16);
            this.pnlColorBase.TabIndex  = 5;

            // lblColorBase
            this.lblColorBase.AutoSize  = true;
            this.lblColorBase.ForeColor = System.Drawing.Color.White;
            this.lblColorBase.Location  = new System.Drawing.Point(550, 30);
            this.lblColorBase.Name      = "lblColorBase";
            this.lblColorBase.TabIndex  = 6;
            this.lblColorBase.Text      = "Bajo h — sin excavar";

            // pnlRight
            this.pnlRight.BackColor = System.Drawing.Color.FromArgb(45, 45, 50);
            this.pnlRight.Controls.Add(this.chkPuntos);
            this.pnlRight.Controls.Add(this.chkEtiquetas);
            this.pnlRight.Controls.Add(this.lblH);
            this.pnlRight.Controls.Add(this.lblHVal);
            this.pnlRight.Controls.Add(this.trkH);
            this.pnlRight.Controls.Add(this.lblDx);
            this.pnlRight.Controls.Add(this.lblDxVal);
            this.pnlRight.Controls.Add(this.trkDx);
            this.pnlRight.Controls.Add(this.lblDy);
            this.pnlRight.Controls.Add(this.lblDyVal);
            this.pnlRight.Controls.Add(this.trkDy);
            this.pnlRight.Dock     = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Name     = "pnlRight";
            this.pnlRight.Size     = new System.Drawing.Size(185, 598);
            this.pnlRight.TabIndex = 3;

            // chkPuntos
            this.chkPuntos.AutoSize   = true;
            this.chkPuntos.Checked    = true;
            this.chkPuntos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPuntos.ForeColor  = System.Drawing.Color.White;
            this.chkPuntos.Location   = new System.Drawing.Point(10, 12);
            this.chkPuntos.Name       = "chkPuntos";
            this.chkPuntos.TabIndex   = 0;
            this.chkPuntos.Text       = "Mostrar puntos";
            this.chkPuntos.UseVisualStyleBackColor = true;
            this.chkPuntos.CheckedChanged += new System.EventHandler(this.chkPuntos_CheckedChanged);

            // chkEtiquetas
            this.chkEtiquetas.AutoSize   = true;
            this.chkEtiquetas.Checked    = true;
            this.chkEtiquetas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEtiquetas.ForeColor  = System.Drawing.Color.White;
            this.chkEtiquetas.Location   = new System.Drawing.Point(10, 38);
            this.chkEtiquetas.Name       = "chkEtiquetas";
            this.chkEtiquetas.TabIndex   = 1;
            this.chkEtiquetas.Text       = "Mostrar etiquetas";
            this.chkEtiquetas.UseVisualStyleBackColor = true;
            this.chkEtiquetas.CheckedChanged += new System.EventHandler(this.chkEtiquetas_CheckedChanged);

            // lblH
            this.lblH.AutoSize  = true;
            this.lblH.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblH.ForeColor = System.Drawing.Color.FromArgb(255, 220, 60);
            this.lblH.Location  = new System.Drawing.Point(10, 72);
            this.lblH.Name      = "lblH";
            this.lblH.Text      = "Plano de corte h";

            // lblHVal
            this.lblHVal.AutoSize  = false;
            this.lblHVal.ForeColor = System.Drawing.Color.White;
            this.lblHVal.Location  = new System.Drawing.Point(10, 91);
            this.lblHVal.Name      = "lblHVal";
            this.lblHVal.Size      = new System.Drawing.Size(162, 18);
            this.lblHVal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblHVal.Text      = "— m";

            // trkH
            this.trkH.AutoSize  = false;
            this.trkH.Location  = new System.Drawing.Point(8, 111);
            this.trkH.Maximum   = 1000;
            this.trkH.Minimum   = 0;
            this.trkH.Name      = "trkH";
            this.trkH.Size      = new System.Drawing.Size(165, 28);
            this.trkH.TabIndex  = 2;
            this.trkH.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trkH.Scroll   += new System.EventHandler(this.trkH_Scroll);

            // lblDx
            this.lblDx.AutoSize  = true;
            this.lblDx.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDx.ForeColor = System.Drawing.Color.FromArgb(255, 160, 100);
            this.lblDx.Location  = new System.Drawing.Point(10, 150);
            this.lblDx.Name      = "lblDx";
            this.lblDx.Text      = "Espaciado Δx";

            // lblDxVal
            this.lblDxVal.AutoSize  = false;
            this.lblDxVal.ForeColor = System.Drawing.Color.White;
            this.lblDxVal.Location  = new System.Drawing.Point(10, 169);
            this.lblDxVal.Name      = "lblDxVal";
            this.lblDxVal.Size      = new System.Drawing.Size(162, 18);
            this.lblDxVal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDxVal.Text      = "— m";

            // trkDx
            this.trkDx.AutoSize  = false;
            this.trkDx.Location  = new System.Drawing.Point(8, 189);
            this.trkDx.Maximum   = 100;
            this.trkDx.Minimum   = 1;
            this.trkDx.Name      = "trkDx";
            this.trkDx.Size      = new System.Drawing.Size(165, 28);
            this.trkDx.TabIndex  = 3;
            this.trkDx.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trkDx.Scroll   += new System.EventHandler(this.trkDx_Scroll);

            // lblDy
            this.lblDy.AutoSize  = true;
            this.lblDy.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDy.ForeColor = System.Drawing.Color.FromArgb(130, 220, 130);
            this.lblDy.Location  = new System.Drawing.Point(10, 228);
            this.lblDy.Name      = "lblDy";
            this.lblDy.Text      = "Espaciado Δy";

            // lblDyVal
            this.lblDyVal.AutoSize  = false;
            this.lblDyVal.ForeColor = System.Drawing.Color.White;
            this.lblDyVal.Location  = new System.Drawing.Point(10, 247);
            this.lblDyVal.Name      = "lblDyVal";
            this.lblDyVal.Size      = new System.Drawing.Size(162, 18);
            this.lblDyVal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDyVal.Text      = "— m";

            // trkDy
            this.trkDy.AutoSize  = false;
            this.trkDy.Location  = new System.Drawing.Point(8, 267);
            this.trkDy.Maximum   = 100;
            this.trkDy.Minimum   = 1;
            this.trkDy.Name      = "trkDy";
            this.trkDy.Size      = new System.Drawing.Size(165, 28);
            this.trkDy.TabIndex  = 4;
            this.trkDy.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trkDy.Scroll   += new System.EventHandler(this.trkDy_Scroll);

            // Form2
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(950, 680);
            this.Font                = new System.Drawing.Font("Segoe UI", 10F);
            // Orden: host primero (Fill al final), pnlRight segundo, pnlBottom último (docks primero)
            this.Controls.Add(this.host);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlBottom);
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name        = "Form2";
            this.Text        = "Gráfica 3D — Volumen de Excavación";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.trkH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkDx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkDy)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Integration.ElementHost host;
        private System.Windows.Forms.Panel    pnlBottom;
        private System.Windows.Forms.Button   btnReset;
        private System.Windows.Forms.Panel    pnlColorTerreno;
        private System.Windows.Forms.Label    lblColorTerreno;
        private System.Windows.Forms.Panel    pnlColorCorte;
        private System.Windows.Forms.Label    lblColorCorte;
        private System.Windows.Forms.Panel    pnlColorBase;
        private System.Windows.Forms.Label    lblColorBase;
        private System.Windows.Forms.Panel    pnlRight;
        private System.Windows.Forms.CheckBox chkPuntos;
        private System.Windows.Forms.CheckBox chkEtiquetas;
        private System.Windows.Forms.Label    lblH;
        private System.Windows.Forms.Label    lblHVal;
        private System.Windows.Forms.TrackBar trkH;
        private System.Windows.Forms.Label    lblDx;
        private System.Windows.Forms.Label    lblDxVal;
        private System.Windows.Forms.TrackBar trkDx;
        private System.Windows.Forms.Label    lblDy;
        private System.Windows.Forms.Label    lblDyVal;
        private System.Windows.Forms.TrackBar trkDy;
    }
}
