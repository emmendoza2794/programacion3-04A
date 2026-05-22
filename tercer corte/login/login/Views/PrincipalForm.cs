using login.Services;
using System;
using System.Windows.Forms;

namespace login.views
{
    public partial class PrincipalForm : Form
    {
        public PrincipalForm()
        {
            InitializeComponent();
        }

        private void PrincipalForm_Load(object sender, EventArgs e)
        {
            txtBienvenida.Text = $"Bienvenido, {SessionService.Usuario}";
            txtRol.Text = SessionService.Rol;

            if (SessionService.Rol != "admin")
            {
                button5.Visible = false;
                button6.Visible = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var formClientes = new ClientesForm();
            formClientes.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var formUsuarios = new UsuariosForm();
            formUsuarios.ShowDialog();
        }
    }
}
