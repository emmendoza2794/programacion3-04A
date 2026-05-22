using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace login.models
{
    internal class UsuariosModel
    {
        public String Usuario { get; set; }
        public String Password { get; set; }
        public String Rol { get; set; }

        public UsuariosModel(String usuario, String password, String rol)
        {
            Usuario = usuario;
            Password = password;
            Rol = rol;
        }
    }
}
