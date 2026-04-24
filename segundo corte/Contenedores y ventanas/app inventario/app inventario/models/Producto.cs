using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_inventario.models
{
    public class Producto
    {
        private const string RUTA = "../db/productos.csv";

        public int Id { get; set; }
        public String Descripcion { get; set; }
        public int Precio { get; set; }

        public Producto(int id, String descripcion, int precio)
        {
            Id = id;
            Descripcion = descripcion;
            Precio = precio;
        }

        public void CrearProducto(int id, String descripcion, int precio)
        {
            Id = id;
            Descripcion = descripcion;
            Precio = precio;

            String linea = $"{Id},{Descripcion},{Precio}";

            File.AppendAllText(RUTA, linea + Environment.NewLine);

        }

        public List<Producto> GetProductos()
        {

            List<Producto> productos = new List<Producto>();
            if (File.Exists(RUTA))
            {
                var lineas = File.ReadAllLines(RUTA);
                foreach (var linea in lineas)
                {
                    var datos = linea.Split(',');
                    if (datos.Length == 3)
                    {
                        int id = int.Parse(datos[0]);
                        String descripcion = datos[1];
                        int precio = int.Parse(datos[2]);
                        Producto producto = new Producto(id, descripcion, precio);
                        productos.Add(producto);
                    }
                }
            }
            return productos;

        }

        public void EliminarProducto(int id)
        {
            if (File.Exists(RUTA))
            {
                var lineas = File.ReadAllLines(RUTA);
                var lineasActualizadas = lineas.Where(linea => !linea.StartsWith(id.ToString())).ToArray();
                File.WriteAllLines(RUTA, lineasActualizadas);
            }
        }

        public void ActualizarProducto(int id, String descripcion, int precio)
        {
            if (File.Exists(RUTA))
            {
                var lineas = File.ReadAllLines(RUTA);
                for (int i = 0; i < lineas.Length; i++)
                {
                    var datos = lineas[i].Split(',');
                    if (datos.Length == 3 && int.Parse(datos[0]) == id)
                    {
                        lineas[i] = $"{id},{descripcion},{precio}";
                        break;
                    }
                }
                File.WriteAllLines(RUTA, lineas);
            }
        }
    }
}
