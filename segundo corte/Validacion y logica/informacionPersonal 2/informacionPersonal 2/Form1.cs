using System;
using System.Windows.Forms;

namespace informacionPersonal_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            int delta = 18;

            if (txtNombres.Text == "")
            {
                lblValidadorNombres.Visible = true;
                lblValidadorNombres.Text = "El campo nombres es obligatorio";
            }
            else
            {
                lblValidadorNombres.Visible = false;
                lblValidadorNombres.Text = "";
            }

            if (txtApellidos.Text == "")
            {
                lblValidadorApellidos.Visible = true;
                lblValidadorApellidos.Text = "El campo apellidos es obligatorio";
            }
            else
            {
                lblValidadorApellidos.Visible = false;
                lblValidadorApellidos.Text = "";
            }

            if (dtFechaNacimiento.Value >= DateTime.Today.AddYears(-delta))
            {
                lblValidadorFecha.Visible = true;
                lblValidadorFecha.Text = "Debe tener más de " + delta + " años";
            }
            else
            {
                lblValidadorFecha.Visible = false;
                lblValidadorFecha.Text = "";
            }

            if (rbEstudiante.Checked != true )
            {
                lblOcupacion.Visible = true;
                lblOcupacion.Text = "Solo se aceptan estudiantes";
            }
            else
            {
                lblOcupacion.Visible = false;
                lblOcupacion.Text = "";
            }
        }
    }
}
