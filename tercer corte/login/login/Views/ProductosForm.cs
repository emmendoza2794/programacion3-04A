using login.controllers;
using System;
using System.Windows.Forms;

namespace login
{
    public partial class ProductosForm : Form
    {
        private ProductoController productoController = new ProductoController();

        public ProductosForm()
        {
            InitializeComponent();
            ConfigurarColumnas();
            CargarProductos();
        }

        private void ConfigurarColumnas()
        {
            dgvProductos.AutoGenerateColumns = false;
            dgvProductos.Columns.Clear();
            dgvProductos.Columns.Add("Codigo",        "Código");
            dgvProductos.Columns.Add("Nombre",        "Nombre");
            dgvProductos.Columns.Add("Descripcion",   "Descripción");
            dgvProductos.Columns.Add("Precio",        "Precio");
            dgvProductos.Columns.Add("Stock",         "Stock");
            dgvProductos.Columns.Add("Categoria",     "Categoría");
            dgvProductos.Columns.Add("FechaRegistro", "Fecha Registro");

            foreach (DataGridViewColumn col in dgvProductos.Columns)
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void CargarProductos()
        {
            dgvProductos.Rows.Clear();
            foreach (var fila in productoController.ObtenerTodos())
                dgvProductos.Rows.Add(fila);
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            string resultado = productoController.CrearProducto(
                txtCodigo.Text, txtNombre.Text, txtDescripcion.Text,
                txtPrecio.Text, txtStock.Text, txtCategoria.Text);

            MessageBox.Show(resultado);
            CargarProductos();

            if (resultado == "Producto creado exitosamente.")
                LimpiarCampos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            string resultado = productoController.ActualizarProducto(
                txtCodigo.Text, txtNombre.Text, txtDescripcion.Text,
                txtPrecio.Text, txtStock.Text, txtCategoria.Text);

            MessageBox.Show(resultado);
            CargarProductos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                MessageBox.Show("Seleccione un producto de la tabla.");
                return;
            }

            var confirm = MessageBox.Show(
                $"¿Eliminar producto {txtCodigo.Text}?",
                "Confirmar", MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {
                string resultado = productoController.EliminarProducto(txtCodigo.Text);
                MessageBox.Show(resultado);
                CargarProductos();
                LimpiarCampos();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvProductos.Rows[e.RowIndex];
            txtCodigo.Text      = row.Cells["Codigo"].Value?.ToString();
            txtNombre.Text      = row.Cells["Nombre"].Value?.ToString();
            txtDescripcion.Text = row.Cells["Descripcion"].Value?.ToString();
            txtPrecio.Text      = row.Cells["Precio"].Value?.ToString();
            txtStock.Text       = row.Cells["Stock"].Value?.ToString();
            txtCategoria.Text   = row.Cells["Categoria"].Value?.ToString();
        }

        private void LimpiarCampos()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
            txtCategoria.Clear();
        }
    }
}
