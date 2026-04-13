using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace validadorRegistro
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            bool isValid = true;

            if (txtCorreo.Text == "")
            {
                lblCorreo.Visible = true;
                lblCorreo.Text = "El campo correo es obligatorio";
                isValid = false;
            }
            else
            {
                lblCorreo.Visible = false;
            }

            if (txtCorreo.Text != txtValidarCorreo.Text)
            {
                lblValidarCorreo.Visible = true;
                lblValidarCorreo.Text = "Los correos no coinciden";
                isValid = false;
            }
            else
            {
                lblValidarCorreo.Visible = false;
            }

            if (txtNombres.Text == "")
            {
                lblNombres.Visible = true;
                lblNombres.Text = "El campo nombres es obligatorio";
                isValid = false;
            }
            else
            {
                lblNombres.Visible = false;
            }

            if (!rbMasculino.Checked && !rbFemenino.Checked)
            {
                lblGenero.Visible = true;
                lblGenero.Text = "Debe seleccionar un género";
                isValid = false;
            }
            else
            {
                lblGenero.Visible = false;
            }

            if (isValid)
            {
                if (rbMasculino.Checked) {
                    lblRegistroExitoso.Visible = true;
                    lblRegistroExitoso.Text = "Registro exitoso para el señor " + txtNombres.Text;
                } else
                {
                    lblRegistroExitoso.Visible = true;
                    lblRegistroExitoso.Text = "Registro exitoso para la señora " + txtNombres.Text;
                }
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
