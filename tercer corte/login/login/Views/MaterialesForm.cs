using login.controllers;
using System;
using System.Windows.Forms;

namespace login
{
    public partial class MaterialesForm : Form
    {
        private MaterialController materialController = new MaterialController();

        public MaterialesForm()
        {
            InitializeComponent();
            ConfigurarColumnas();
            CargarMateriales();
        }

        private void ConfigurarColumnas()
        {
            dgvMateriales.AutoGenerateColumns = false;
            dgvMateriales.Columns.Clear();
            dgvMateriales.Columns.Add("Codigo",         "Código");
            dgvMateriales.Columns.Add("Nombre",         "Nombre");
            dgvMateriales.Columns.Add("Descripcion",    "Descripción");
            dgvMateriales.Columns.Add("Tipo",           "Tipo");
            dgvMateriales.Columns.Add("Unidad",         "Unidad");
            dgvMateriales.Columns.Add("Cantidad",       "Cantidad");
            dgvMateriales.Columns.Add("PrecioUnitario", "Precio Unitario");
            dgvMateriales.Columns.Add("FechaRegistro",  "Fecha Registro");

            foreach (DataGridViewColumn col in dgvMateriales.Columns)
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void CargarMateriales()
        {
            dgvMateriales.Rows.Clear();
            foreach (var fila in materialController.ObtenerTodos())
                dgvMateriales.Rows.Add(fila);
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            string resultado = materialController.CrearMaterial(
                txtCodigo.Text, txtNombre.Text, txtDescripcion.Text,
                txtTipo.Text, txtUnidad.Text, txtCantidad.Text, txtPrecioUnitario.Text);

            MessageBox.Show(resultado);
            CargarMateriales();

            if (resultado == "Material creado exitosamente.")
                LimpiarCampos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            string resultado = materialController.ActualizarMaterial(
                txtCodigo.Text, txtNombre.Text, txtDescripcion.Text,
                txtTipo.Text, txtUnidad.Text, txtCantidad.Text, txtPrecioUnitario.Text);

            MessageBox.Show(resultado);
            CargarMateriales();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                MessageBox.Show("Seleccione un material de la tabla.");
                return;
            }

            var confirm = MessageBox.Show(
                $"¿Eliminar material {txtCodigo.Text}?",
                "Confirmar", MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {
                string resultado = materialController.EliminarMaterial(txtCodigo.Text);
                MessageBox.Show(resultado);
                CargarMateriales();
                LimpiarCampos();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void dgvMateriales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvMateriales.Rows[e.RowIndex];
            txtCodigo.Text         = row.Cells["Codigo"].Value?.ToString();
            txtNombre.Text         = row.Cells["Nombre"].Value?.ToString();
            txtDescripcion.Text    = row.Cells["Descripcion"].Value?.ToString();
            txtTipo.Text           = row.Cells["Tipo"].Value?.ToString();
            txtUnidad.Text         = row.Cells["Unidad"].Value?.ToString();
            txtCantidad.Text       = row.Cells["Cantidad"].Value?.ToString();
            txtPrecioUnitario.Text = row.Cells["PrecioUnitario"].Value?.ToString();
        }

        private void LimpiarCampos()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtTipo.Clear();
            txtUnidad.Clear();
            txtCantidad.Clear();
            txtPrecioUnitario.Clear();
        }
    }
}
