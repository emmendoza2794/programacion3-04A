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
    public partial class Paquetes : Form
    {
        public Paquetes()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgvPaquetes.Rows.Clear();

            dgvPaquetes.Rows.Add("PKG001", "Paquete de Oficina", "Bucaramanga", "Aguachica", "20/04/2026");
            dgvPaquetes.Rows.Add("PKG002", "Caja delicada", "Bogota", "Aguachica", "20/04/2026");
            dgvPaquetes.Rows.Add("PKG003", "Sobre con documentos", "Cali", "Aguachica", "20/04/2026");
            dgvPaquetes.Rows.Add("PKG004", "Paquete de Oficina", "Cartagena", "Aguachica", "20/04/2026");
        }
    }
}
