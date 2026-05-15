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
    public partial class LoginForm : Form
    {
        private UsuariosController usuariosController = new UsuariosController();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            var formRegistro = new RegistroForm();
            formRegistro.ShowDialog();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contrasena = txtContrasena.Text;

            string resultado = usuariosController.IniciarSesion(usuario, contrasena);
            
            if(resultado == "ok")
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(resultado);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var formUsuarios = new UsuariosForm();
            formUsuarios.ShowDialog();
        }
    }
}
