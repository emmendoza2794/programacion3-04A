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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            var formRegistro = new Registro();
            formRegistro.ShowDialog();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            String usuario = txtUsuario.Text;
            String contrasena = txtContrasena.Text;

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasena))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            String ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "db", "usuarios.csv");

            bool usuarioEncontrado = false;

            if (File.Exists(ruta))
            {
                var lineas = File.ReadAllLines(ruta);
                foreach (var linea in lineas)
                {
                    var datos = linea.Split(',');
                    if (datos.Length == 2 && datos[0] == usuario)
                    {
                        string hash = datos[1];
                        if (BCrypt.Net.BCrypt.Verify(contrasena, hash))
                        {
                            MessageBox.Show("Inicio de sesión exitoso.");
                        }
                        else
                        {
                            MessageBox.Show("Contraseña incorrecta.");
                        }
                        usuarioEncontrado = true;
                        return;
                    }
                }

                if(usuarioEncontrado == false)
                {
                    MessageBox.Show("Usuario no encontrado.");
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var formUsuarios = new Usuarios();
            formUsuarios.ShowDialog();
        }
    }
}
