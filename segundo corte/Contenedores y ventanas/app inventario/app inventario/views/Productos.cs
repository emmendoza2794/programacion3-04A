using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app_inventario.views
{
    public partial class Productos : Form
    {
        private controllers.Productos _controller = new controllers.Productos();

        public Productos()
        {
            InitializeComponent();
            Id.DataPropertyName = "Id";
            Descripcion.DataPropertyName = "Descripcion";
            Precio.DataPropertyName = "Precio";
            this.Load += Productos_Load;
        }

        private void Productos_Load(object sender, EventArgs e)
        {
            CargarProductos();
        }

        private void CargarProductos()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = _controller.Listar();
        }

        private void LimpiarCampos()
        {
            tbId.Text = "";
            tbDescripcion.Text = "";
            nudPrecio.Value = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = int.Parse(tbId.Text);
            string descripcion = tbDescripcion.Text;
            int precio = (int)nudPrecio.Value;

            string resultado = _controller.Crear(id, descripcion, precio);

            if (resultado == "ok")
            {
                CargarProductos();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show(resultado);
            }
        }


        private void label1_Click(object sender, EventArgs e) { }
        private void toolStripButton1_Click(object sender, EventArgs e) { }
        private void splitContainer2_Panel2_Paint(object sender, PaintEventArgs e) { }
        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e) { }
        private void splitContainer2_SplitterMoved(object sender, SplitterEventArgs e) { }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) { }

        private void button2_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
    }
}
