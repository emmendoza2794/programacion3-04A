using app_inventario.views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app_inventario
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            var inventarioForm = new Inventario();
            inventarioForm.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            var inventarioForm = new Inventario();
            inventarioForm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var inventarioForm = new Inventario();
            inventarioForm.ShowDialog();
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Click(object sender, EventArgs e)
        {
            var paquetesForm = new Paquetes();
            paquetesForm.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            var paquetesForm = new Paquetes();
            paquetesForm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var paquetesForm = new Paquetes();
            paquetesForm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var paquetesForm = new Paquetes();
            paquetesForm.ShowDialog();
        }
    }
}
