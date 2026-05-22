using System;

namespace login.models
{
    internal class ClienteModel : PersonaModel
    {
        public string NumeroCliente { get; set; }
        public DateTime FechaRegistro { get; set; }

        public ClienteModel(string nombre, string apellido, string cedula, string email, string telefono, string numeroCliente, DateTime fechaRegistro)
            : base(nombre, apellido, cedula, email, telefono)
        {
            NumeroCliente = numeroCliente;
            FechaRegistro = fechaRegistro;
        }
    }
}
