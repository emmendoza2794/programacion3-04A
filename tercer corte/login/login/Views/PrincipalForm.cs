using login.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            if(SessionService.Rol != "admin")
            {
                button5.Visible = false;
                button6.Visible = false;
            }
        }
    }
}
