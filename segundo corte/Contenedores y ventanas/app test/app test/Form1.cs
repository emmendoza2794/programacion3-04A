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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace app_test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Seleccionar archivo";
                dialog.Filter = "Todos los archivos|*.*";
                dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string ruta = dialog.FileName;
                    string contenido = File.ReadAllText(ruta);

                    richTextBox1.AppendText(contenido);
                    richTextBox1.AppendText(ruta);

                    CopiarImagen(ruta);

                }
                
            }
        }

        private void CopiarImagen(string rutaOrigen)
        {
            // Ruta base del ejecutable: bin/Debug/ o bin/Release/
            string carpetaDestino = Path.Combine(Application.StartupPath, "images");

            // Crear la carpeta si no existe
            if (!Directory.Exists(carpetaDestino))
                Directory.CreateDirectory(carpetaDestino);

            // Nombre del archivo original
            string nombreArchivo = Path.GetFileName(rutaOrigen);

            // Ruta final de destino
            string rutaDestino = Path.Combine(carpetaDestino, nombreArchivo);

            // Copiar (true = sobreescribir si ya existe)
            File.Copy(rutaOrigen, rutaDestino, true);

            richTextBox1.AppendText($"Imagen copiada a: {rutaDestino}");
        }
    }
}
