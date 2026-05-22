using login.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace login.Respository
{
    internal class UsuariosRepository
    {
        private static readonly string RUTA = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "db", "usuarios.csv");

        public void Crear(UsuariosModel usuario)
        {
            string directorio = Path.GetDirectoryName(RUTA);
            if (!Directory.Exists(directorio))
                Directory.CreateDirectory(directorio);

            string linea = $"{usuario.Nombre},{usuario.Apellido},{usuario.Cedula},{usuario.Email},{usuario.Telefono},{usuario.Usuario},{usuario.Password},{usuario.Rol}";
            File.AppendAllText(RUTA, linea + Environment.NewLine);
        }

        public List<UsuariosModel> ObtenerTodos()
        {
            var usuarios = new List<UsuariosModel>();
            if (!File.Exists(RUTA)) return usuarios;

            foreach (var linea in File.ReadAllLines(RUTA))
            {
                var d = linea.Split(',');
                if (d.Length == 8)
                    usuarios.Add(new UsuariosModel(d[0], d[1], d[2], d[3], d[4], d[5], d[6], d[7]));
            }
            return usuarios;
        }

        public UsuariosModel ObtenerPorUsuario(string usuario)
        {
            if (!File.Exists(RUTA)) return null;

            foreach (var linea in File.ReadAllLines(RUTA))
            {
                var d = linea.Split(',');
                if (d.Length == 8 && d[5] == usuario)
                    return new UsuariosModel(d[0], d[1], d[2], d[3], d[4], d[5], d[6], d[7]);
            }
            return null;
        }

        public void Actualizar(UsuariosModel usuario)
        {
            if (!File.Exists(RUTA)) return;

            var lineas = File.ReadAllLines(RUTA).ToList();
            for (int i = 0; i < lineas.Count; i++)
            {
                var d = lineas[i].Split(',');
                if (d.Length == 8 && d[5] == usuario.Usuario)
                {
                    lineas[i] = $"{usuario.Nombre},{usuario.Apellido},{usuario.Cedula},{usuario.Email},{usuario.Telefono},{usuario.Usuario},{usuario.Password},{usuario.Rol}";
                    break;
                }
            }
            File.WriteAllLines(RUTA, lineas);
        }

        public void Eliminar(string usuario)
        {
            if (!File.Exists(RUTA)) return;

            var lineas = File.ReadAllLines(RUTA)
                .Where(l => { var d = l.Split(','); return !(d.Length == 8 && d[5] == usuario); })
                .ToList();
            File.WriteAllLines(RUTA, lineas);
        }
    }
}
