using login.models;
using login.Respository;
using login.Services;
using System;
using System.Collections.Generic;

namespace login.controllers
{
    internal class UsuariosController
    {
        private UsuariosRepository usuariosRepository = new UsuariosRepository();

        public List<string[]> ObtenerTodos()
        {
            var usuarios = usuariosRepository.ObtenerTodos();
            var resultado = new List<string[]>();
            foreach (var u in usuarios)
                resultado.Add(new string[] { u.Usuario, u.Nombre, u.Apellido, u.Cedula, u.Email, u.Telefono, u.Rol });
            return resultado;
        }

        public string IniciarSesion(string usuario, string contrasena)
        {
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasena))
                return "Por favor, complete todos los campos.";

            var usuarioEncontrado = usuariosRepository.ObtenerPorUsuario(usuario);

            if (usuarioEncontrado == null)
                return "Usuario no encontrado.";

            if (BCrypt.Net.BCrypt.Verify(contrasena, usuarioEncontrado.Password))
            {
                SessionService.Session(usuarioEncontrado.Usuario, usuarioEncontrado.Rol);
                return "ok";
            }

            return "Contraseña incorrecta.";
        }

        public string CrearUsuario(string nombre, string apellido, string cedula, string email, string telefono, string usuario, string contrasena, string rol)
        {
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) || string.IsNullOrEmpty(cedula) ||
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(telefono) ||
                string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasena) || string.IsNullOrEmpty(rol))
                return "Por favor, complete todos los campos.";

            if (usuariosRepository.ObtenerPorUsuario(usuario) != null)
                return "El usuario ya existe.";

            var nuevo = new UsuariosModel(nombre, apellido, cedula, email, telefono, usuario, BCrypt.Net.BCrypt.HashPassword(contrasena), rol);
            usuariosRepository.Crear(nuevo);

            return "Usuario creado exitosamente.";
        }

        public string ActualizarUsuario(string usuario, string nombre, string apellido, string cedula, string email, string telefono, string rol, string nuevaContrasena)
        {
            if (string.IsNullOrEmpty(usuario))
                return "Seleccione un usuario de la tabla.";

            var encontrado = usuariosRepository.ObtenerPorUsuario(usuario);
            if (encontrado == null)
                return "Usuario no encontrado.";

            encontrado.Nombre = nombre;
            encontrado.Apellido = apellido;
            encontrado.Cedula = cedula;
            encontrado.Email = email;
            encontrado.Telefono = telefono;
            encontrado.Rol = rol;

            if (!string.IsNullOrEmpty(nuevaContrasena))
                encontrado.Password = BCrypt.Net.BCrypt.HashPassword(nuevaContrasena);

            usuariosRepository.Actualizar(encontrado);
            return "Usuario actualizado exitosamente.";
        }

        public string EliminarUsuario(string usuario)
        {
            if (string.IsNullOrEmpty(usuario))
                return "Por favor, ingrese un usuario.";

            if (usuariosRepository.ObtenerPorUsuario(usuario) == null)
                return "Usuario no encontrado.";

            usuariosRepository.Eliminar(usuario);
            return "Usuario eliminado exitosamente.";
        }
    }
}
