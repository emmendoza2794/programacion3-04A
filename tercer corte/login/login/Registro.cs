using BCrypt.Net;
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
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
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

            // Hash de la contraseña
            string hash = BCrypt.Net.BCrypt.HashPassword(contrasena);

            // Aquí puedes guardar el usuario y el hash en tu base de datos
            String ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "db", "usuarios.csv");

            String linea = $"{usuario},{hash}";

            // Crear el directorio si no existe
            string directorio = Path.GetDirectoryName(ruta);
            if (!Directory.Exists(directorio))
            {
                Directory.CreateDirectory(directorio);
            }

            File.AppendAllText(ruta, linea + Environment.NewLine);
            MessageBox.Show("Registro exitoso.");
            this.Close();
        }
    }
}
