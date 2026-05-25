using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathNet.Numerics.Integration;

namespace Parte_Proyecto_MZ
{
    public partial class Form1 : Form
    {
        private ControladorDatos controladorDatos = new ControladorDatos();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            double x = double.Parse(TxtX.Text);
            double y = double.Parse(TxtY.Text);
            double z = double.Parse(TxtZ.Text);

            controladorDatos.AgregarDatos(x, y, z);
            ActualizarGrid();

            TxtX.Clear();
            TxtY.Clear();
            TxtZ.Clear();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            double area = controladorDatos.CalcularArea();
            double volumen = controladorDatos.CalcularVolumen();
            TxtVolumen.Text = volumen.ToString();
            TxtArea.Text = area.ToString();
        }

        private void ActualizarGrid() 
        { 
            dgvXYZ.DataSource = null;
            dgvXYZ.DataSource = controladorDatos.ListaDatos;
        }

        private void btnLimpiarXYZ_Click(object sender, EventArgs e)
        {
            TxtX.Clear();
            TxtY.Clear();
            TxtZ.Clear();
        }

        private void btnLimpiardgv_Click(object sender, EventArgs e)
        {
            controladorDatos.ListaDatos.Clear();
            ActualizarGrid();
        }
    }
}
