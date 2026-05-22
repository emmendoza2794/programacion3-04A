using login.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace login.Respository
{
    internal class ClienteRepository
    {
        private static readonly string RUTA = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "db", "clientes.csv");

        public void Crear(ClienteModel cliente)
        {
            string directorio = Path.GetDirectoryName(RUTA);
            if (!Directory.Exists(directorio))
                Directory.CreateDirectory(directorio);

            string linea = $"{cliente.Nombre},{cliente.Apellido},{cliente.Cedula},{cliente.Email},{cliente.Telefono},{cliente.NumeroCliente},{cliente.FechaRegistro:yyyy-MM-dd}";
            File.AppendAllText(RUTA, linea + Environment.NewLine);
        }

        public List<ClienteModel> ObtenerTodos()
        {
            var clientes = new List<ClienteModel>();
            if (!File.Exists(RUTA)) return clientes;

            foreach (var linea in File.ReadAllLines(RUTA))
            {
                var d = linea.Split(',');
                if (d.Length == 7 && DateTime.TryParse(d[6], out DateTime fecha))
                    clientes.Add(new ClienteModel(d[0], d[1], d[2], d[3], d[4], d[5], fecha));
            }
            return clientes;
        }

        public ClienteModel ObtenerPorCedula(string cedula)
        {
            if (!File.Exists(RUTA)) return null;

            foreach (var linea in File.ReadAllLines(RUTA))
            {
                var d = linea.Split(',');
                if (d.Length == 7 && d[2] == cedula && DateTime.TryParse(d[6], out DateTime fecha))
                    return new ClienteModel(d[0], d[1], d[2], d[3], d[4], d[5], fecha);
            }
            return null;
        }

        public ClienteModel ObtenerPorNumeroCliente(string numeroCliente)
        {
            if (!File.Exists(RUTA)) return null;

            foreach (var linea in File.ReadAllLines(RUTA))
            {
                var d = linea.Split(',');
                if (d.Length == 7 && d[5] == numeroCliente && DateTime.TryParse(d[6], out DateTime fecha))
                    return new ClienteModel(d[0], d[1], d[2], d[3], d[4], d[5], fecha);
            }
            return null;
        }

        public void Actualizar(ClienteModel cliente)
        {
            if (!File.Exists(RUTA)) return;

            var lineas = File.ReadAllLines(RUTA).ToList();
            for (int i = 0; i < lineas.Count; i++)
            {
                var d = lineas[i].Split(',');
                if (d.Length == 7 && d[5] == cliente.NumeroCliente)
                {
                    lineas[i] = $"{cliente.Nombre},{cliente.Apellido},{cliente.Cedula},{cliente.Email},{cliente.Telefono},{cliente.NumeroCliente},{cliente.FechaRegistro:yyyy-MM-dd}";
                    break;
                }
            }
            File.WriteAllLines(RUTA, lineas);
        }

        public void Eliminar(string numeroCliente)
        {
            if (!File.Exists(RUTA)) return;

            var lineas = File.ReadAllLines(RUTA)
                .Where(l => { var d = l.Split(','); return !(d.Length == 7 && d[5] == numeroCliente); })
                .ToList();
            File.WriteAllLines(RUTA, lineas);
        }
    }
}
