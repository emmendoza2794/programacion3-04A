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
        private static readonly string RUTA = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "db", "usuarios.csv");

        public String Usuario { get; set; }
        public String Password { get; set; }
        public String Rol { get; set; }

        public UsuariosModel() { }

        public void Crear(UsuariosModel usuario)
        {
            string directorio = Path.GetDirectoryName(RUTA);
            if (!Directory.Exists(directorio))
            {
                Directory.CreateDirectory(directorio);
            }

            string linea = $"{usuario.Usuario},{usuario.Password},{usuario.Rol}";
            File.AppendAllText(RUTA, linea + Environment.NewLine);
        }

        public List<UsuariosModel> ObtenerTodos()
        {
            var usuarios = new List<UsuariosModel>();
            if (File.Exists(RUTA))
            {
                var lineas = File.ReadAllLines(RUTA);
                foreach (var linea in lineas)
                {
                    var datos = linea.Split(',');
                    if (datos.Length == 3)
                    {
                        usuarios.Add(new UsuariosModel
                        {
                            Usuario = datos[0],
                            Password = datos[1],
                            Rol = datos[2]
                        });
                    }
                }
            }
            return usuarios;
        }

        public UsuariosModel ObtenerPorUsuario(string usuario)
        {
            if (File.Exists(RUTA))
            {
                var lineas = File.ReadAllLines(RUTA);
                foreach (var linea in lineas)
                {
                    var datos = linea.Split(',');
                    if (datos.Length == 3 && datos[0] == usuario)
                    {
                        return new UsuariosModel
                        {
                            Usuario = datos[0],
                            Password = datos[1],
                            Rol = datos[2]
                        };
                    }
                }
            }
            return null;
        }

        public void Actualizar(UsuariosModel usuario)
        {
            if (File.Exists(RUTA))
            {
                var lineas = File.ReadAllLines(RUTA).ToList();
                for (int i = 0; i < lineas.Count; i++)
                {
                    var datos = lineas[i].Split(',');
                    if (datos.Length == 3 && datos[0] == usuario.Usuario)
                    {
                        lineas[i] = $"{usuario.Usuario},{usuario.Password},{usuario.Rol}";
                        break;
                    }
                }
                File.WriteAllLines(RUTA, lineas);
            }
        }
    }
}
