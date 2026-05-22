using login.controllers;
using System;
using System.Windows.Forms;

namespace login
{
    public partial class UsuariosForm : Form
    {
        private UsuariosController usuariosController = new UsuariosController();

        public UsuariosForm()
        {
            InitializeComponent();
            ConfigurarColumnas();
            CargarUsuarios();
        }

        private void ConfigurarColumnas()
        {
            dgvUsuarios.AutoGenerateColumns = false;
            dgvUsuarios.Columns.Clear();
            dgvUsuarios.Columns.Add("Usuario",  "Usuario");
            dgvUsuarios.Columns.Add("Nombre",   "Nombre");
            dgvUsuarios.Columns.Add("Apellido", "Apellido");
            dgvUsuarios.Columns.Add("Cedula",   "Cédula");
            dgvUsuarios.Columns.Add("Email",    "Email");
            dgvUsuarios.Columns.Add("Telefono", "Teléfono");
            dgvUsuarios.Columns.Add("Rol",      "Rol");

            foreach (DataGridViewColumn col in dgvUsuarios.Columns)
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void CargarUsuarios()
        {
            dgvUsuarios.Rows.Clear();
            foreach (var fila in usuariosController.ObtenerTodos())
                dgvUsuarios.Rows.Add(fila);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            string resultado = usuariosController.ActualizarUsuario(
                txtUsuario.Text, txtNombre.Text, txtApellido.Text,
                txtCedula.Text, txtEmail.Text, txtTelefono.Text,
                cmbRol.Text, txtNuevaContrasena.Text);

            MessageBox.Show(resultado);
            CargarUsuarios();

            if (resultado == "Usuario actualizado exitosamente.")
                txtNuevaContrasena.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                MessageBox.Show("Seleccione un usuario de la tabla.");
                return;
            }

            var confirm = MessageBox.Show(
                $"¿Eliminar usuario '{txtUsuario.Text}'?",
                "Confirmar", MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {
                string resultado = usuariosController.EliminarUsuario(txtUsuario.Text);
                MessageBox.Show(resultado);
                CargarUsuarios();
                LimpiarCampos();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvUsuarios.Rows[e.RowIndex];
            txtUsuario.Text        = row.Cells["Usuario"].Value?.ToString();
            txtNombre.Text         = row.Cells["Nombre"].Value?.ToString();
            txtApellido.Text       = row.Cells["Apellido"].Value?.ToString();
            txtCedula.Text         = row.Cells["Cedula"].Value?.ToString();
            txtEmail.Text          = row.Cells["Email"].Value?.ToString();
            txtTelefono.Text       = row.Cells["Telefono"].Value?.ToString();
            cmbRol.Text            = row.Cells["Rol"].Value?.ToString();
            txtNuevaContrasena.Clear();
        }

        private void LimpiarCampos()
        {
            txtUsuario.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtCedula.Clear();
            txtEmail.Clear();
            txtTelefono.Clear();
            txtNuevaContrasena.Clear();
            cmbRol.SelectedIndex = -1;
        }
    }
}
