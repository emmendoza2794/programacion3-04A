using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_inventario.controllers
{
    public class Productos
    {
        public String Crear(int id, String descripcion, int precio)
        {
            models.Producto producto = new models.Producto();

            if (producto.Buscar(id) != null)
            {
                return "El producto con el id " + id + " ya existe.";
            }

            producto.Crear(id, descripcion, precio);

            return "ok";
        }

        public List<models.Producto> Listar()
        {
            models.Producto producto = new models.Producto();
            return producto.Listar();
        }

        public String Eliminar(int id)
        {
            models.Producto producto = new models.Producto();
            if (producto.Buscar(id) == null)
            {
                return "El producto con el id " + id + " no existe.";
            }
            producto.Eliminar(id);
            return "ok";
        }

        public String Actualizar(int id, String descripcion, int precio)
        {
            models.Producto producto = new models.Producto();
            if (producto.Buscar(id) == null)
            {
                return "El producto con el id " + id + " no existe.";
            }
            producto.Actualizar(id, descripcion, precio);
            return "ok";
        }

    }
}
