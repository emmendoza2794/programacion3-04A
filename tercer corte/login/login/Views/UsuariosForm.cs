using login.controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login
{
    public partial class UsuariosForm : Form
    {
        private UsuariosController usuariosController = new UsuariosController();
        public UsuariosForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCambiar_Click(object sender, EventArgs e)
        {
            String buscarUsuario = txtBuscarUsuario.Text;
            String contrasenaNueva = txtContrasenaNueva.Text;

            string resultado = usuariosController.CambiarContrasena(buscarUsuario, contrasenaNueva);
            MessageBox.Show(resultado);

        }
    }
}
