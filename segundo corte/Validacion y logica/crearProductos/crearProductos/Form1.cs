using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace crearProductos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que los campos no estén vacíos
                if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtCodigo.Text))
                {
                    MessageBox.Show("Por favor complete todos los campos de texto.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Nombre del archivo CSV
                string nombreArchivo = "productos.csv";
                string rutaArchivo = Path.Combine(Application.StartupPath, nombreArchivo);

                // Si el archivo no existe, crear el encabezado
                if (!File.Exists(rutaArchivo))
                {
                    File.WriteAllText(rutaArchivo, "Codigo,Nombre,Costo,Cantidad" + Environment.NewLine, Encoding.UTF8);
                }

                // Agregar la información del producto
                string linea = $"{txtCodigo.Text},{txtNombre.Text},{numCosto.Value},{numCantidad.Value}" + Environment.NewLine;
                File.AppendAllText(rutaArchivo, linea, Encoding.UTF8);

                MessageBox.Show($"Producto guardado exitosamente en {nombreArchivo}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar los campos después de guardar
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtCodigo.Clear();
            numCosto.Value = 0;
            numCantidad.Value = 0;
        }

        private void btnCargarProductos_Click(object sender, EventArgs e)
        {
            try
            {
                // Nombre del archivo CSV
                string nombreArchivo = "productos.csv";
                string rutaArchivo = Path.Combine(Application.StartupPath, nombreArchivo);

                // Verificar si el archivo existe
                if (!File.Exists(rutaArchivo))
                {
                    MessageBox.Show("No se encontró el archivo de productos.", "Archivo no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Limpiar la lista antes de cargar
                listProductos.Items.Clear();

                // Leer todas las líneas del archivo
                string[] lineas = File.ReadAllLines(rutaArchivo, Encoding.UTF8);

                // Procesar cada línea (saltar la primera línea que son los encabezados)
                for (int i = 1; i < lineas.Length; i++)
                {
                    if (!string.IsNullOrWhiteSpace(lineas[i]))
                    {
                        string[] campos = lineas[i].Split(',');
                        if (campos.Length >= 4)
                        {
                            string codigo = campos[0].Trim();
                            string nombre = campos[1].Trim();
                            string costo = campos[2].Trim();
                            string cantidad = campos[3].Trim();

                            // Concatenar toda la información del producto
                            string productoCompleto = $"[{codigo}] {nombre} - Costo: ${costo} - Cantidad: {cantidad}";
                            listProductos.Items.Add(productoCompleto);
                        }
                    }
                }

                MessageBox.Show($"Se cargaron {listProductos.Items.Count} productos.", "Carga exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
