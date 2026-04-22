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
    public partial class Inventario : Form
    {
        public Inventario()
        {
            InitializeComponent();
        }

        private void dgvInventario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Limpiar el DataGridView antes de cargar nuevos datos
            dgvInventario.Rows.Clear();

            // Cargar 3 productos de ejemplo
            dgvInventario.Rows.Add("001", "Laptop Dell", "Electrónicos", "$899.99");
            dgvInventario.Rows.Add("002", "Mouse Inalámbrico", "Accesorios", "$25.50");
            dgvInventario.Rows.Add("003", "Teclado Mecánico", "Accesorios", "$89.90");

            // Mensaje informativo al usuario
            MessageBox.Show("Se han cargado 3 productos de ejemplo al inventario.", "Datos Cargados", 
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
