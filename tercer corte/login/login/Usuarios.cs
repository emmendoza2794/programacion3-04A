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
    public partial class Usuarios : Form
    {
        public Usuarios()
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

            if (string.IsNullOrEmpty(buscarUsuario) || string.IsNullOrEmpty(contrasenaNueva))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            String ruta = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "db", "usuarios.csv");

            if (System.IO.File.Exists(ruta))
            {
                var lineas = System.IO.File.ReadAllLines(ruta);
                bool usuarioEncontrado = false;
                for (int i = 0; i < lineas.Length; i++)
                {
                    var datos = lineas[i].Split(',');
                    if (datos.Length == 2 && datos[0] == buscarUsuario)
                    {
                        // Hash de la nueva contraseña
                        string hashNueva = BCrypt.Net.BCrypt.HashPassword(contrasenaNueva);
                        lineas[i] = $"{buscarUsuario},{hashNueva}";
                        usuarioEncontrado = true;
                        break;
                    }
                }

                if (usuarioEncontrado)
                {
                    System.IO.File.WriteAllLines(ruta, lineas);
                    MessageBox.Show("Contraseña actualizada exitosamente.");
                }
                else
                {
                    MessageBox.Show("Usuario no encontrado.");
                }
            }
            else
            {
                MessageBox.Show("No se encontró la base de datos de usuarios.");
            }
        }
    }
}
