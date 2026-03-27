namespace test_app
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
            this.btnClic = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblContador = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnClic
            // 
            this.btnClic.BackColor = System.Drawing.SystemColors.HighlightText;
            this.btnClic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClic.Font = new System.Drawing.Font("Microsoft YaHei", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClic.Location = new System.Drawing.Point(181, 178);
            this.btnClic.Name = "btnClic";
            this.btnClic.Size = new System.Drawing.Size(199, 71);
            this.btnClic.TabIndex = 0;
            this.btnClic.Text = "Clickeame!!";
            this.btnClic.UseVisualStyleBackColor = false;
            this.btnClic.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(194, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "Total clicks";
            // 
            // lblContador
            // 
            this.lblContador.AutoSize = true;
            this.lblContador.Font = new System.Drawing.Font("Microsoft YaHei", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContador.ForeColor = System.Drawing.Color.Red;
            this.lblContador.Location = new System.Drawing.Point(253, 92);
            this.lblContador.Name = "lblContador";
            this.lblContador.Size = new System.Drawing.Size(34, 37);
            this.lblContador.TabIndex = 2;
            this.lblContador.Text = "0";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(531, 357);
            this.Controls.Add(this.lblContador);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClic);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClic;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblContador;
    }
}

