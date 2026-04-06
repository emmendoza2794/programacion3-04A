using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculadora
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener los valores de los TextBox
                double numero1 = Convert.ToDouble(inpNumero1.Text);
                double numero2 = Convert.ToDouble(inpNumero2.Text);

                // Realizar la suma
                double resultado = numero1 + numero2;

                // Mostrar el resultado en el Label
                lblResultado.Text = resultado.ToString();
            }
            catch (FormatException)
            {
                // Manejo de error si los valores no son números válidos
                MessageBox.Show("Por favor, ingrese números válidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Manejo de cualquier otro error
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
