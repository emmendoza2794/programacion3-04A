namespace grafica_volumen
{
    partial class Form3
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
            this.splitMain       = new System.Windows.Forms.SplitContainer();
            this.pnlHeaderOrig   = new System.Windows.Forms.Panel();
            this.lblTituloOrig   = new System.Windows.Forms.Label();
            this.hostOriginal    = new System.Windows.Forms.Integration.ElementHost();
            this.pnlHeaderFinal  = new System.Windows.Forms.Panel();
            this.lblTituloFinal  = new System.Windows.Forms.Label();
            this.hostFinal       = new System.Windows.Forms.Integration.ElementHost();
            this.pnlBottom       = new System.Windows.Forms.Panel();
            this.btnResetOriginal = new System.Windows.Forms.Button();
            this.btnResetFinal   = new System.Windows.Forms.Button();
            this.lblLeyendaExc   = new System.Windows.Forms.Label();
            this.pnlExcColor     = new System.Windows.Forms.Panel();
            this.lblLeyendaRem   = new System.Windows.Forms.Label();
            this.pnlRemColor     = new System.Windows.Forms.Panel();
            this.lblLeyendaH     = new System.Windows.Forms.Label();
            this.pnlHColor       = new System.Windows.Forms.Panel();

            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            this.pnlHeaderOrig.SuspendLayout();
            this.pnlHeaderFinal.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();

            // splitMain
            this.splitMain.Dock        = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitMain.SplitterDistance = 340;
            this.splitMain.SplitterWidth = 5;
            this.splitMain.BackColor   = System.Drawing.Color.FromArgb(30, 30, 30);
            this.splitMain.Name        = "splitMain";
            this.splitMain.TabIndex    = 0;

            // splitMain.Panel1 — Terreno Original
            this.splitMain.Panel1.Controls.Add(this.hostOriginal);
            this.splitMain.Panel1.Controls.Add(this.pnlHeaderOrig);

            // pnlHeaderOrig
            this.pnlHeaderOrig.BackColor = System.Drawing.Color.FromArgb(25, 40, 70);
            this.pnlHeaderOrig.Controls.Add(this.lblTituloOrig);
            this.pnlHeaderOrig.Dock     = System.Windows.Forms.DockStyle.Top;
            this.pnlHeaderOrig.Height   = 30;
            this.pnlHeaderOrig.Name     = "pnlHeaderOrig";

            // lblTituloOrig
            this.lblTituloOrig.AutoSize  = false;
            this.lblTituloOrig.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.lblTituloOrig.Font      = new System.Drawing.Font("Segoe UI", 10F,
                System.Drawing.FontStyle.Bold);
            this.lblTituloOrig.ForeColor = System.Drawing.Color.FromArgb(200, 220, 255);
            this.lblTituloOrig.Text      = "  ▲  Terreno Original";
            this.lblTituloOrig.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTituloOrig.Name      = "lblTituloOrig";

            // hostOriginal
            this.hostOriginal.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.hostOriginal.Name      = "hostOriginal";
            this.hostOriginal.TabIndex  = 0;
            this.hostOriginal.Text      = "hostOriginal";
            this.hostOriginal.Child     = null;

            // splitMain.Panel2 — Terreno Final
            this.splitMain.Panel2.Controls.Add(this.hostFinal);
            this.splitMain.Panel2.Controls.Add(this.pnlHeaderFinal);

            // pnlHeaderFinal
            this.pnlHeaderFinal.BackColor = System.Drawing.Color.FromArgb(50, 25, 10);
            this.pnlHeaderFinal.Controls.Add(this.lblTituloFinal);
            this.pnlHeaderFinal.Dock     = System.Windows.Forms.DockStyle.Top;
            this.pnlHeaderFinal.Height   = 30;
            this.pnlHeaderFinal.Name     = "pnlHeaderFinal";

            // lblTituloFinal
            this.lblTituloFinal.AutoSize  = false;
            this.lblTituloFinal.Dock      = System.Windows.Forms.DockStyle.Fill;
            this.lblTituloFinal.Font      = new System.Drawing.Font("Segoe UI", 10F,
                System.Drawing.FontStyle.Bold);
            this.lblTituloFinal.ForeColor = System.Drawing.Color.FromArgb(255, 210, 160);
            this.lblTituloFinal.Text      = "  ▼  Terreno Final  (Hueco de Excavación)";
            this.lblTituloFinal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTituloFinal.Name      = "lblTituloFinal";

            // hostFinal
            this.hostFinal.Dock     = System.Windows.Forms.DockStyle.Fill;
            this.hostFinal.Name     = "hostFinal";
            this.hostFinal.TabIndex = 0;
            this.hostFinal.Text     = "hostFinal";
            this.hostFinal.Child    = null;

            // pnlBottom — barra de controles
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(40, 40, 45);
            this.pnlBottom.Controls.Add(this.btnResetOriginal);
            this.pnlBottom.Controls.Add(this.btnResetFinal);
            this.pnlBottom.Controls.Add(this.pnlExcColor);
            this.pnlBottom.Controls.Add(this.lblLeyendaExc);
            this.pnlBottom.Controls.Add(this.pnlRemColor);
            this.pnlBottom.Controls.Add(this.lblLeyendaRem);
            this.pnlBottom.Controls.Add(this.pnlHColor);
            this.pnlBottom.Controls.Add(this.lblLeyendaH);
            this.pnlBottom.Dock     = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Height   = 48;
            this.pnlBottom.Name     = "pnlBottom";
            this.pnlBottom.TabIndex = 1;

            // btnResetOriginal
            this.btnResetOriginal.BackColor = System.Drawing.Color.SteelBlue;
            this.btnResetOriginal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetOriginal.ForeColor = System.Drawing.Color.White;
            this.btnResetOriginal.Location  = new System.Drawing.Point(10, 11);
            this.btnResetOriginal.Size      = new System.Drawing.Size(140, 26);
            this.btnResetOriginal.Name      = "btnResetOriginal";
            this.btnResetOriginal.TabIndex  = 0;
            this.btnResetOriginal.Text      = "Reset cámara ▲";
            this.btnResetOriginal.UseVisualStyleBackColor = false;
            this.btnResetOriginal.Click    += new System.EventHandler(this.btnResetOriginal_Click);

            // btnResetFinal
            this.btnResetFinal.BackColor = System.Drawing.Color.DarkOrange;
            this.btnResetFinal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetFinal.ForeColor = System.Drawing.Color.White;
            this.btnResetFinal.Location  = new System.Drawing.Point(162, 11);
            this.btnResetFinal.Size      = new System.Drawing.Size(140, 26);
            this.btnResetFinal.Name      = "btnResetFinal";
            this.btnResetFinal.TabIndex  = 1;
            this.btnResetFinal.Text      = "Reset cámara ▼";
            this.btnResetFinal.UseVisualStyleBackColor = false;
            this.btnResetFinal.Click    += new System.EventHandler(this.btnResetFinal_Click);

            // pnlExcColor — azul
            this.pnlExcColor.BackColor = System.Drawing.Color.FromArgb(35, 80, 210);
            this.pnlExcColor.Location  = new System.Drawing.Point(330, 16);
            this.pnlExcColor.Size      = new System.Drawing.Size(16, 16);
            this.pnlExcColor.Name      = "pnlExcColor";
            this.pnlExcColor.TabIndex  = 2;

            // lblLeyendaExc
            this.lblLeyendaExc.AutoSize  = true;
            this.lblLeyendaExc.ForeColor = System.Drawing.Color.White;
            this.lblLeyendaExc.Location  = new System.Drawing.Point(350, 14);
            this.lblLeyendaExc.Name      = "lblLeyendaExc";
            this.lblLeyendaExc.TabIndex  = 3;
            this.lblLeyendaExc.Text      = "Zona excavada (z > h)";

            // pnlRemColor — naranja
            this.pnlRemColor.BackColor = System.Drawing.Color.FromArgb(220, 80, 20);
            this.pnlRemColor.Location  = new System.Drawing.Point(530, 16);
            this.pnlRemColor.Size      = new System.Drawing.Size(16, 16);
            this.pnlRemColor.Name      = "pnlRemColor";
            this.pnlRemColor.TabIndex  = 4;

            // lblLeyendaRem
            this.lblLeyendaRem.AutoSize  = true;
            this.lblLeyendaRem.ForeColor = System.Drawing.Color.White;
            this.lblLeyendaRem.Location  = new System.Drawing.Point(550, 14);
            this.lblLeyendaRem.Name      = "lblLeyendaRem";
            this.lblLeyendaRem.TabIndex  = 5;
            this.lblLeyendaRem.Text      = "Terreno que permanece (z ≤ h)";

            // pnlHColor — amarillo
            this.pnlHColor.BackColor = System.Drawing.Color.FromArgb(240, 210, 40);
            this.pnlHColor.Location  = new System.Drawing.Point(780, 16);
            this.pnlHColor.Size      = new System.Drawing.Size(16, 16);
            this.pnlHColor.Name      = "pnlHColor";
            this.pnlHColor.TabIndex  = 6;

            // lblLeyendaH
            this.lblLeyendaH.AutoSize  = true;
            this.lblLeyendaH.ForeColor = System.Drawing.Color.White;
            this.lblLeyendaH.Location  = new System.Drawing.Point(800, 14);
            this.lblLeyendaH.Name      = "lblLeyendaH";
            this.lblLeyendaH.TabIndex  = 7;
            this.lblLeyendaH.Text      = "Plano de corte h";

            // Form3
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize    = new System.Drawing.Size(1200, 800);
            this.Font          = new System.Drawing.Font("Segoe UI", 10F);
            this.MinimumSize   = new System.Drawing.Size(800, 500);
            this.Name          = "Form3";
            this.Text          = "Excavación 3D — Terreno Original y Hueco de Excavación";
            this.WindowState   = System.Windows.Forms.FormWindowState.Maximized;

            // Agregar controles: Fill al final (después de los docked)
            this.Controls.Add(this.splitMain);
            this.Controls.Add(this.pnlBottom);

            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            this.pnlHeaderOrig.ResumeLayout(false);
            this.pnlHeaderFinal.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.SplitContainer                 splitMain;
        private System.Windows.Forms.Panel                          pnlHeaderOrig;
        private System.Windows.Forms.Label                          lblTituloOrig;
        private System.Windows.Forms.Integration.ElementHost        hostOriginal;
        private System.Windows.Forms.Panel                          pnlHeaderFinal;
        private System.Windows.Forms.Label                          lblTituloFinal;
        private System.Windows.Forms.Integration.ElementHost        hostFinal;
        private System.Windows.Forms.Panel                          pnlBottom;
        private System.Windows.Forms.Button                         btnResetOriginal;
        private System.Windows.Forms.Button                         btnResetFinal;
        private System.Windows.Forms.Label                          lblLeyendaExc;
        private System.Windows.Forms.Panel                          pnlExcColor;
        private System.Windows.Forms.Label                          lblLeyendaRem;
        private System.Windows.Forms.Panel                          pnlRemColor;
        private System.Windows.Forms.Label                          lblLeyendaH;
        private System.Windows.Forms.Panel                          pnlHColor;
    }
}
