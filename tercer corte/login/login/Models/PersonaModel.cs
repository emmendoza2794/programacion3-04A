using System;

namespace login.models
{
    internal class PersonaModel
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cedula { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }

        public PersonaModel(string nombre, string apellido, string cedula, string email, string telefono)
        {
            Nombre = nombre;
            Apellido = apellido;
            Cedula = cedula;
            Email = email;
            Telefono = telefono;
        }
    }
}
