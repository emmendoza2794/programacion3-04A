using login.models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace login.Respository
{
    internal class MaterialRepository
    {
        private static readonly string RUTA = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "db", "materiales.csv");
        private const char SEP = '|';

        public void Crear(MaterialModel material)
        {
            string directorio = Path.GetDirectoryName(RUTA);
            if (!Directory.Exists(directorio))
                Directory.CreateDirectory(directorio);

            string linea = string.Join(SEP.ToString(), material.Codigo, material.Nombre, material.Descripcion,
                material.Tipo, material.Unidad,
                material.Cantidad.ToString(CultureInfo.InvariantCulture),
                material.PrecioUnitario.ToString(CultureInfo.InvariantCulture),
                material.FechaRegistro.ToString("yyyy-MM-dd"));
            File.AppendAllText(RUTA, linea + Environment.NewLine);
        }

        public List<MaterialModel> ObtenerTodos()
        {
            var materiales = new List<MaterialModel>();
            if (!File.Exists(RUTA)) return materiales;

            foreach (var linea in File.ReadAllLines(RUTA))
            {
                var d = linea.Split(SEP);
                if (d.Length == 8
                    && decimal.TryParse(d[5], NumberStyles.Any, CultureInfo.InvariantCulture, out decimal cantidad)
                    && decimal.TryParse(d[6], NumberStyles.Any, CultureInfo.InvariantCulture, out decimal precio)
                    && DateTime.TryParse(d[7], out DateTime fecha))
                    materiales.Add(new MaterialModel(d[0], d[1], d[2], d[3], d[4], cantidad, precio, fecha));
            }
            return materiales;
        }

        public MaterialModel ObtenerPorCodigo(string codigo)
        {
            if (!File.Exists(RUTA)) return null;

            foreach (var linea in File.ReadAllLines(RUTA))
            {
                var d = linea.Split(SEP);
                if (d.Length == 8 && d[0] == codigo
                    && decimal.TryParse(d[5], NumberStyles.Any, CultureInfo.InvariantCulture, out decimal cantidad)
                    && decimal.TryParse(d[6], NumberStyles.Any, CultureInfo.InvariantCulture, out decimal precio)
                    && DateTime.TryParse(d[7], out DateTime fecha))
                    return new MaterialModel(d[0], d[1], d[2], d[3], d[4], cantidad, precio, fecha);
            }
            return null;
        }

        public void Actualizar(MaterialModel material)
        {
            if (!File.Exists(RUTA)) return;

            var lineas = File.ReadAllLines(RUTA).ToList();
            for (int i = 0; i < lineas.Count; i++)
            {
                var d = lineas[i].Split(SEP);
                if (d.Length == 8 && d[0] == material.Codigo)
                {
                    lineas[i] = string.Join(SEP.ToString(), material.Codigo, material.Nombre, material.Descripcion,
                        material.Tipo, material.Unidad,
                        material.Cantidad.ToString(CultureInfo.InvariantCulture),
                        material.PrecioUnitario.ToString(CultureInfo.InvariantCulture),
                        material.FechaRegistro.ToString("yyyy-MM-dd"));
                    break;
                }
            }
            File.WriteAllLines(RUTA, lineas);
        }

        public void Eliminar(string codigo)
        {
            if (!File.Exists(RUTA)) return;

            var lineas = File.ReadAllLines(RUTA)
                .Where(l => { var d = l.Split(SEP); return !(d.Length == 8 && d[0] == codigo); })
                .ToList();
            File.WriteAllLines(RUTA, lineas);
        }
    }
}
