using login.models;
using login.Respository;
using System;
using System.Collections.Generic;

namespace login.controllers
{
    internal class ClienteController
    {
        private ClienteRepository clienteRepository = new ClienteRepository();

        public string CrearCliente(string nombre, string apellido, string cedula, string email, string telefono, string numeroCliente)
        {
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) || string.IsNullOrEmpty(cedula) ||
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(telefono) || string.IsNullOrEmpty(numeroCliente))
                return "Por favor, complete todos los campos.";

            if (clienteRepository.ObtenerPorNumeroCliente(numeroCliente) != null)
                return "Ya existe un cliente con ese número.";

            if (clienteRepository.ObtenerPorCedula(cedula) != null)
                return "Ya existe un cliente con esa cédula.";

            var nuevo = new ClienteModel(nombre, apellido, cedula, email, telefono, numeroCliente, DateTime.Today);
            clienteRepository.Crear(nuevo);

            return "Cliente creado exitosamente.";
        }

        public List<string[]> ObtenerTodos()
        {
            var clientes = clienteRepository.ObtenerTodos();
            var resultado = new List<string[]>();
            foreach (var c in clientes)
                resultado.Add(new string[] { c.NumeroCliente, c.Nombre, c.Apellido, c.Cedula, c.Email, c.Telefono, c.FechaRegistro.ToString("yyyy-MM-dd") });
            return resultado;
        }

        public string ActualizarCliente(string nombre, string apellido, string cedula, string email, string telefono, string numeroCliente)
        {
            if (string.IsNullOrEmpty(numeroCliente))
                return "El número de cliente es requerido.";

            var existente = clienteRepository.ObtenerPorNumeroCliente(numeroCliente);
            if (existente == null)
                return "Cliente no encontrado.";

            existente.Nombre = nombre;
            existente.Apellido = apellido;
            existente.Cedula = cedula;
            existente.Email = email;
            existente.Telefono = telefono;
            clienteRepository.Actualizar(existente);

            return "Cliente actualizado exitosamente.";
        }

        public string EliminarCliente(string numeroCliente)
        {
            if (string.IsNullOrEmpty(numeroCliente))
                return "El número de cliente es requerido.";

            if (clienteRepository.ObtenerPorNumeroCliente(numeroCliente) == null)
                return "Cliente no encontrado.";

            clienteRepository.Eliminar(numeroCliente);
            return "Cliente eliminado exitosamente.";
        }
    }
}
