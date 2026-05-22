using login.controllers;
using System;
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

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string resultado = usuariosController.CrearUsuario(
                txtNombre.Text, txtApellido.Text, txtCedula.Text,
                txtEmail.Text, txtTelefono.Text,
                txtUsuario.Text, txtContrasena.Text, "usuario");

            MessageBox.Show(resultado);

            if (resultado == "Usuario creado exitosamente.")
                LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtCedula.Clear();
            txtEmail.Clear();
            txtTelefono.Clear();
            txtUsuario.Clear();
            txtContrasena.Clear();
        }
    }
}
