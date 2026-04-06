namespace informacionPersonal_2
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombres = new System.Windows.Forms.TextBox();
            this.txtApellidos = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.btnValidar = new System.Windows.Forms.Button();
            this.lblValidadorNombres = new System.Windows.Forms.Label();
            this.lblValidadorApellidos = new System.Windows.Forms.Label();
            this.lblValidadorFecha = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbDesempleado = new System.Windows.Forms.RadioButton();
            this.rbEmpleado = new System.Windows.Forms.RadioButton();
            this.rbEstudiante = new System.Windows.Forms.RadioButton();
            this.lblOcupacion = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombres*";
            // 
            // txtNombres
            // 
            this.txtNombres.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombres.Location = new System.Drawing.Point(34, 80);
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.Size = new System.Drawing.Size(252, 30);
            this.txtNombres.TabIndex = 1;
            // 
            // txtApellidos
            // 
            this.txtApellidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellidos.Location = new System.Drawing.Point(353, 80);
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.Size = new System.Drawing.Size(252, 30);
            this.txtApellidos.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(348, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Apellidos*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(29, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(221, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fecha de nacimiento*";
            // 
            // dtFechaNacimiento
            // 
            this.dtFechaNacimiento.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFechaNacimiento.CustomFormat = "dd/MM/yyyy";
            this.dtFechaNacimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFechaNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFechaNacimiento.Location = new System.Drawing.Point(34, 227);
            this.dtFechaNacimiento.Name = "dtFechaNacimiento";
            this.dtFechaNacimiento.Size = new System.Drawing.Size(252, 30);
            this.dtFechaNacimiento.TabIndex = 5;
            this.dtFechaNacimiento.Value = new System.DateTime(2026, 1, 31, 0, 0, 0, 0);
            // 
            // btnValidar
            // 
            this.btnValidar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValidar.Location = new System.Drawing.Point(34, 372);
            this.btnValidar.Name = "btnValidar";
            this.btnValidar.Size = new System.Drawing.Size(186, 57);
            this.btnValidar.TabIndex = 6;
            this.btnValidar.Text = "Validar datos";
            this.btnValidar.UseVisualStyleBackColor = true;
            this.btnValidar.Click += new System.EventHandler(this.btnValidar_Click);
            // 
            // lblValidadorNombres
            // 
            this.lblValidadorNombres.AutoSize = true;
            this.lblValidadorNombres.ForeColor = System.Drawing.Color.Red;
            this.lblValidadorNombres.Location = new System.Drawing.Point(34, 122);
            this.lblValidadorNombres.Name = "lblValidadorNombres";
            this.lblValidadorNombres.Size = new System.Drawing.Size(158, 16);
            this.lblValidadorNombres.TabIndex = 7;
            this.lblValidadorNombres.Text = "Este campo es requerido";
            this.lblValidadorNombres.Visible = false;
            // 
            // lblValidadorApellidos
            // 
            this.lblValidadorApellidos.AutoSize = true;
            this.lblValidadorApellidos.ForeColor = System.Drawing.Color.Red;
            this.lblValidadorApellidos.Location = new System.Drawing.Point(350, 122);
            this.lblValidadorApellidos.Name = "lblValidadorApellidos";
            this.lblValidadorApellidos.Size = new System.Drawing.Size(158, 16);
            this.lblValidadorApellidos.TabIndex = 8;
            this.lblValidadorApellidos.Text = "Este campo es requerido";
            this.lblValidadorApellidos.Visible = false;
            // 
            // lblValidadorFecha
            // 
            this.lblValidadorFecha.AutoSize = true;
            this.lblValidadorFecha.ForeColor = System.Drawing.Color.Red;
            this.lblValidadorFecha.Location = new System.Drawing.Point(34, 272);
            this.lblValidadorFecha.Name = "lblValidadorFecha";
            this.lblValidadorFecha.Size = new System.Drawing.Size(158, 16);
            this.lblValidadorFecha.TabIndex = 9;
            this.lblValidadorFecha.Text = "Este campo es requerido";
            this.lblValidadorFecha.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbDesempleado);
            this.groupBox1.Controls.Add(this.rbEmpleado);
            this.groupBox1.Controls.Add(this.rbEstudiante);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(353, 185);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(252, 156);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ocupacion";
            // 
            // rbDesempleado
            // 
            this.rbDesempleado.AutoSize = true;
            this.rbDesempleado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDesempleado.Location = new System.Drawing.Point(6, 113);
            this.rbDesempleado.Name = "rbDesempleado";
            this.rbDesempleado.Size = new System.Drawing.Size(165, 29);
            this.rbDesempleado.TabIndex = 15;
            this.rbDesempleado.TabStop = true;
            this.rbDesempleado.Text = "Desempleado";
            this.rbDesempleado.UseVisualStyleBackColor = true;
            // 
            // rbEmpleado
            // 
            this.rbEmpleado.AutoSize = true;
            this.rbEmpleado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbEmpleado.Location = new System.Drawing.Point(6, 78);
            this.rbEmpleado.Name = "rbEmpleado";
            this.rbEmpleado.Size = new System.Drawing.Size(129, 29);
            this.rbEmpleado.TabIndex = 14;
            this.rbEmpleado.TabStop = true;
            this.rbEmpleado.Text = "Empleado";
            this.rbEmpleado.UseVisualStyleBackColor = true;
            // 
            // rbEstudiante
            // 
            this.rbEstudiante.AutoSize = true;
            this.rbEstudiante.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbEstudiante.Location = new System.Drawing.Point(6, 42);
            this.rbEstudiante.Name = "rbEstudiante";
            this.rbEstudiante.Size = new System.Drawing.Size(135, 29);
            this.rbEstudiante.TabIndex = 13;
            this.rbEstudiante.TabStop = true;
            this.rbEstudiante.Text = "Estudiante";
            this.rbEstudiante.UseVisualStyleBackColor = true;
            // 
            // lblOcupacion
            // 
            this.lblOcupacion.AutoSize = true;
            this.lblOcupacion.ForeColor = System.Drawing.Color.Red;
            this.lblOcupacion.Location = new System.Drawing.Point(351, 358);
            this.lblOcupacion.Name = "lblOcupacion";
            this.lblOcupacion.Size = new System.Drawing.Size(158, 16);
            this.lblOcupacion.TabIndex = 14;
            this.lblOcupacion.Text = "Este campo es requerido";
            this.lblOcupacion.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 554);
            this.Controls.Add(this.lblOcupacion);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblValidadorFecha);
            this.Controls.Add(this.lblValidadorApellidos);
            this.Controls.Add(this.lblValidadorNombres);
            this.Controls.Add(this.btnValidar);
            this.Controls.Add(this.dtFechaNacimiento);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtApellidos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNombres);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombres;
        private System.Windows.Forms.TextBox txtApellidos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtFechaNacimiento;
        private System.Windows.Forms.Button btnValidar;
        private System.Windows.Forms.Label lblValidadorNombres;
        private System.Windows.Forms.Label lblValidadorApellidos;
        private System.Windows.Forms.Label lblValidadorFecha;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbDesempleado;
        private System.Windows.Forms.RadioButton rbEmpleado;
        private System.Windows.Forms.RadioButton rbEstudiante;
        private System.Windows.Forms.Label lblOcupacion;
    }
}

