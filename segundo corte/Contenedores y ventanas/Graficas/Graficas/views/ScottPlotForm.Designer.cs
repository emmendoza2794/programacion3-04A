namespace Graficas
{
    partial class ScottPlotForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblColor = new System.Windows.Forms.Label();
            this.lblFuncion = new System.Windows.Forms.Label();
            this.cmbColormap = new System.Windows.Forms.ComboBox();
            this.cmbFuncion = new System.Windows.Forms.ComboBox();
            this.formsPlot1 = new ScottPlot.FormsPlot();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.lblColor);
            this.splitContainer1.Panel1.Controls.Add(this.lblFuncion);
            this.splitContainer1.Panel1.Controls.Add(this.cmbColormap);
            this.splitContainer1.Panel1.Controls.Add(this.cmbFuncion);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.formsPlot1);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 266;
            this.splitContainer1.TabIndex = 0;
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColor.Location = new System.Drawing.Point(27, 120);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(71, 25);
            this.lblColor.TabIndex = 3;
            this.lblColor.Text = "Color:";
            // 
            // lblFuncion
            // 
            this.lblFuncion.AutoSize = true;
            this.lblFuncion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFuncion.Location = new System.Drawing.Point(27, 26);
            this.lblFuncion.Name = "lblFuncion";
            this.lblFuncion.Size = new System.Drawing.Size(96, 25);
            this.lblFuncion.TabIndex = 2;
            this.lblFuncion.Text = "Función:";
            // 
            // cmbColormap
            // 
            this.cmbColormap.FormattingEnabled = true;
            this.cmbColormap.Location = new System.Drawing.Point(26, 148);
            this.cmbColormap.Name = "cmbColormap";
            this.cmbColormap.Size = new System.Drawing.Size(167, 24);
            this.cmbColormap.TabIndex = 1;
            // 
            // cmbFuncion
            // 
            this.cmbFuncion.FormattingEnabled = true;
            this.cmbFuncion.Location = new System.Drawing.Point(26, 57);
            this.cmbFuncion.Name = "cmbFuncion";
            this.cmbFuncion.Size = new System.Drawing.Size(167, 24);
            this.cmbFuncion.TabIndex = 0;
            // 
            // formsPlot1
            // 
            this.formsPlot1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formsPlot1.Location = new System.Drawing.Point(0, 0);
            this.formsPlot1.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.formsPlot1.Name = "formsPlot1";
            this.formsPlot1.Size = new System.Drawing.Size(530, 450);
            this.formsPlot1.TabIndex = 0;
            // 
            // ScottPlotForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "ScottPlotForm";
            this.Text = "ScottPlot";
            this.Load += new System.EventHandler(this.ScottPlotForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private ScottPlot.FormsPlot formsPlot1;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.Label lblFuncion;
        private System.Windows.Forms.ComboBox cmbColormap;
        private System.Windows.Forms.ComboBox cmbFuncion;
    }
}