using login.controllers;
using System;
using System.Windows.Forms;

namespace login
{
    public partial class ClientesForm : Form
    {
        private ClienteController clienteController = new ClienteController();

        public ClientesForm()
        {
            InitializeComponent();
            ConfigurarColumnas();
            CargarClientes();
        }

        private void ConfigurarColumnas()
        {
            dgvClientes.AutoGenerateColumns = false;
            dgvClientes.Columns.Clear();
            dgvClientes.Columns.Add("NumeroCliente", "N° Cliente");
            dgvClientes.Columns.Add("Nombre",        "Nombre");
            dgvClientes.Columns.Add("Apellido",      "Apellido");
            dgvClientes.Columns.Add("Cedula",        "Cédula");
            dgvClientes.Columns.Add("Email",         "Email");
            dgvClientes.Columns.Add("Telefono",      "Teléfono");
            dgvClientes.Columns.Add("FechaRegistro", "Fecha Registro");

            foreach (DataGridViewColumn col in dgvClientes.Columns)
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void CargarClientes()
        {
            dgvClientes.Rows.Clear();
            foreach (var fila in clienteController.ObtenerTodos())
                dgvClientes.Rows.Add(fila);
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            string resultado = clienteController.CrearCliente(
                txtNombre.Text, txtApellido.Text, txtCedula.Text,
                txtEmail.Text, txtTelefono.Text, txtNumeroCliente.Text);

            MessageBox.Show(resultado);
            CargarClientes();

            if (resultado == "Cliente creado exitosamente.")
                LimpiarCampos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            string resultado = clienteController.ActualizarCliente(
                txtNombre.Text, txtApellido.Text, txtCedula.Text,
                txtEmail.Text, txtTelefono.Text, txtNumeroCliente.Text);

            MessageBox.Show(resultado);
            CargarClientes();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNumeroCliente.Text))
            {
                MessageBox.Show("Seleccione un cliente de la tabla.");
                return;
            }

            var confirm = MessageBox.Show(
                $"¿Eliminar cliente {txtNumeroCliente.Text}?",
                "Confirmar", MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {
                string resultado = clienteController.EliminarCliente(txtNumeroCliente.Text);
                MessageBox.Show(resultado);
                CargarClientes();
                LimpiarCampos();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvClientes.Rows[e.RowIndex];
            txtNumeroCliente.Text = row.Cells["NumeroCliente"].Value?.ToString();
            txtNombre.Text        = row.Cells["Nombre"].Value?.ToString();
            txtApellido.Text      = row.Cells["Apellido"].Value?.ToString();
            txtCedula.Text        = row.Cells["Cedula"].Value?.ToString();
            txtEmail.Text         = row.Cells["Email"].Value?.ToString();
            txtTelefono.Text      = row.Cells["Telefono"].Value?.ToString();
        }

        private void LimpiarCampos()
        {
            txtNumeroCliente.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtCedula.Clear();
            txtEmail.Clear();
            txtTelefono.Clear();
        }
    }
}
