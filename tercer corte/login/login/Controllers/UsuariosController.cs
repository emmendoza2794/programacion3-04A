using login.models;
using login.Respository;
using login.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace login.controllers
{
    internal class UsuariosController
    {
        private UsuariosRepository usuariosRepository = new UsuariosRepository();
        public string IniciarSesion(string usuario, string contrasena)
        {
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasena))
            {
                return "Por favor, complete todos los campos.";
            }

            var usuarioEncontrado = usuariosRepository.ObtenerPorUsuario(usuario);

            if (usuarioEncontrado == null)
            {
                return "Usuario no encontrado.";
            }

            if (BCrypt.Net.BCrypt.Verify(contrasena, usuarioEncontrado.Password))
            {
                SessionService.Session(usuarioEncontrado.Usuario, usuarioEncontrado.Rol);
                return "ok";
            }
            else
            {
                return "Contraseña incorrecta.";
            }
        }

        public string CrearUsuario(string usuario, string contrasena, string rol)
        {
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasena) || string.IsNullOrEmpty(rol))
            {
                return "Por favor, complete todos los campos.";
            }

            var usuarioExistente = usuariosRepository.ObtenerPorUsuario(usuario);
            if (usuarioExistente != null)
            {
                return "El usuario ya existe.";
            }

            UsuariosModel usuarioNuevo = new UsuariosModel(usuario, BCrypt.Net.BCrypt.HashPassword(contrasena), rol);

            usuariosRepository.Crear(usuarioNuevo);

            return "Usuario creado exitosamente.";
        }

        public string CambiarContrasena(string usuario, string contrasenaNueva)
        {
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasenaNueva))
            {
                return "Por favor, complete todos los campos.";
            }

            var usuarioEncontrado = usuariosRepository.ObtenerPorUsuario(usuario);

            if (usuarioEncontrado == null)
            {
                return "Usuario no encontrado.";
            }

            usuarioEncontrado.Password = BCrypt.Net.BCrypt.HashPassword(contrasenaNueva);
            usuariosRepository.Actualizar(usuarioEncontrado);

            return "Contraseña actualizada exitosamente.";
        }
    }
}
