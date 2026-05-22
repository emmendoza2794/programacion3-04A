using login.models;
using login.Respository;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace login.controllers
{
    internal class ProductoController
    {
        private ProductoRepository productoRepository = new ProductoRepository();

        public string CrearProducto(string codigo, string nombre, string descripcion, string precio, string stock, string categoria)
        {
            if (string.IsNullOrEmpty(codigo) || string.IsNullOrEmpty(nombre) ||
                string.IsNullOrEmpty(precio) || string.IsNullOrEmpty(stock) || string.IsNullOrEmpty(categoria))
                return "Por favor, complete todos los campos obligatorios.";

            if (!decimal.TryParse(precio, NumberStyles.Any, CultureInfo.CurrentCulture, out decimal precioDecimal) || precioDecimal < 0)
                return "El precio debe ser un número válido mayor o igual a 0.";

            if (!int.TryParse(stock, out int stockInt) || stockInt < 0)
                return "El stock debe ser un número entero válido mayor o igual a 0.";

            if (productoRepository.ObtenerPorCodigo(codigo) != null)
                return "Ya existe un producto con ese código.";

            var nuevo = new ProductoModel(codigo, nombre, descripcion ?? "", precioDecimal, stockInt, categoria, DateTime.Today);
            productoRepository.Crear(nuevo);
            return "Producto creado exitosamente.";
        }

        public List<string[]> ObtenerTodos()
        {
            var productos = productoRepository.ObtenerTodos();
            var resultado = new List<string[]>();
            foreach (var p in productos)
                resultado.Add(new string[] { p.Codigo, p.Nombre, p.Descripcion, p.Precio.ToString("F2"), p.Stock.ToString(), p.Categoria, p.FechaRegistro.ToString("yyyy-MM-dd") });
            return resultado;
        }

        public string ActualizarProducto(string codigo, string nombre, string descripcion, string precio, string stock, string categoria)
        {
            if (string.IsNullOrEmpty(codigo))
                return "El código del producto es requerido.";

            var existente = productoRepository.ObtenerPorCodigo(codigo);
            if (existente == null)
                return "Producto no encontrado.";

            if (!decimal.TryParse(precio, NumberStyles.Any, CultureInfo.CurrentCulture, out decimal precioDecimal) || precioDecimal < 0)
                return "El precio debe ser un número válido mayor o igual a 0.";

            if (!int.TryParse(stock, out int stockInt) || stockInt < 0)
                return "El stock debe ser un número entero válido mayor o igual a 0.";

            existente.Nombre = nombre;
            existente.Descripcion = descripcion ?? "";
            existente.Precio = precioDecimal;
            existente.Stock = stockInt;
            existente.Categoria = categoria;
            productoRepository.Actualizar(existente);
            return "Producto actualizado exitosamente.";
        }

        public string EliminarProducto(string codigo)
        {
            if (string.IsNullOrEmpty(codigo))
                return "El código del producto es requerido.";

            if (productoRepository.ObtenerPorCodigo(codigo) == null)
                return "Producto no encontrado.";

            productoRepository.Eliminar(codigo);
            return "Producto eliminado exitosamente.";
        }
    }
}
