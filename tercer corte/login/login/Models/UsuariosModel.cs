using System;

namespace login.models
{
    internal class UsuariosModel : PersonaModel
    {
        public string Usuario { get; set; }
        public string Password { get; set; }
        public string Rol { get; set; }

        public UsuariosModel(string nombre, string apellido, string cedula, string email, string telefono, string usuario, string password, string rol)
            : base(nombre, apellido, cedula, email, telefono)
        {
            Usuario = usuario;
            Password = password;
            Rol = rol;
        }
    }
}
