using login.models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace login.Respository
{
    internal class ProductoRepository
    {
        private static readonly string RUTA = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "db", "productos.csv");
        private const char SEP = '|';

        public void Crear(ProductoModel producto)
        {
            string directorio = Path.GetDirectoryName(RUTA);
            if (!Directory.Exists(directorio))
                Directory.CreateDirectory(directorio);

            string linea = string.Join(SEP.ToString(), producto.Codigo, producto.Nombre, producto.Descripcion,
                producto.Precio.ToString(CultureInfo.InvariantCulture), producto.Stock.ToString(),
                producto.Categoria, producto.FechaRegistro.ToString("yyyy-MM-dd"));
            File.AppendAllText(RUTA, linea + Environment.NewLine);
        }

        public List<ProductoModel> ObtenerTodos()
        {
            var productos = new List<ProductoModel>();
            if (!File.Exists(RUTA)) return productos;

            foreach (var linea in File.ReadAllLines(RUTA))
            {
                var d = linea.Split(SEP);
                if (d.Length == 7
                    && decimal.TryParse(d[3], NumberStyles.Any, CultureInfo.InvariantCulture, out decimal precio)
                    && int.TryParse(d[4], out int stock)
                    && DateTime.TryParse(d[6], out DateTime fecha))
                    productos.Add(new ProductoModel(d[0], d[1], d[2], precio, stock, d[5], fecha));
            }
            return productos;
        }

        public ProductoModel ObtenerPorCodigo(string codigo)
        {
            if (!File.Exists(RUTA)) return null;

            foreach (var linea in File.ReadAllLines(RUTA))
            {
                var d = linea.Split(SEP);
                if (d.Length == 7 && d[0] == codigo
                    && decimal.TryParse(d[3], NumberStyles.Any, CultureInfo.InvariantCulture, out decimal precio)
                    && int.TryParse(d[4], out int stock)
                    && DateTime.TryParse(d[6], out DateTime fecha))
                    return new ProductoModel(d[0], d[1], d[2], precio, stock, d[5], fecha);
            }
            return null;
        }

        public void Actualizar(ProductoModel producto)
        {
            if (!File.Exists(RUTA)) return;

            var lineas = File.ReadAllLines(RUTA).ToList();
            for (int i = 0; i < lineas.Count; i++)
            {
                var d = lineas[i].Split(SEP);
                if (d.Length == 7 && d[0] == producto.Codigo)
                {
                    lineas[i] = string.Join(SEP.ToString(), producto.Codigo, producto.Nombre, producto.Descripcion,
                        producto.Precio.ToString(CultureInfo.InvariantCulture), producto.Stock.ToString(),
                        producto.Categoria, producto.FechaRegistro.ToString("yyyy-MM-dd"));
                    break;
                }
            }
            File.WriteAllLines(RUTA, lineas);
        }

        public void Eliminar(string codigo)
        {
            if (!File.Exists(RUTA)) return;

            var lineas = File.ReadAllLines(RUTA)
                .Where(l => { var d = l.Split(SEP); return !(d.Length == 7 && d[0] == codigo); })
                .ToList();
            File.WriteAllLines(RUTA, lineas);
        }
    }
}
