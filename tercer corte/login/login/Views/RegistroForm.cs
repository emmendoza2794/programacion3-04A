using BCrypt.Net;
using login.controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login
{
    public partial class RegistroForm : Form
    {
        private UsuariosController usuariosController = new UsuariosController();
        public RegistroForm()
        {
            InitializeComponent();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            String usuario = txtUsuario.Text;
            String contrasena = txtContrasena.Text;

            string resultado = usuariosController.CrearUsuario(usuario, contrasena, "usuario");
            MessageBox.Show(resultado);
        }
    }
}
