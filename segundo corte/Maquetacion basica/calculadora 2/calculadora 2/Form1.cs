using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculadora_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSumar_Click(object sender, EventArgs e)
        {
            double num1 = Convert.ToDouble(txtNumero1.Text);
            double num2 = Convert.ToDouble(txtNomero2.Text);

            double resultado = num1 + num2;

            lblResultado.Text = resultado.ToString();
        }
    }
}
