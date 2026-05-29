using login.models;
using login.Respository;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace login.controllers
{
    internal class MaterialController
    {
        private MaterialRepository materialRepository = new MaterialRepository();

        public string CrearMaterial(string codigo, string nombre, string descripcion, string tipo, string unidad, string cantidad, string precioUnitario)
        {
            if (string.IsNullOrEmpty(codigo) || string.IsNullOrEmpty(nombre) ||
                string.IsNullOrEmpty(tipo) || string.IsNullOrEmpty(unidad) ||
                string.IsNullOrEmpty(cantidad) || string.IsNullOrEmpty(precioUnitario))
                return "Por favor, complete todos los campos obligatorios.";

            if (!decimal.TryParse(cantidad, NumberStyles.Any, CultureInfo.CurrentCulture, out decimal cantidadDecimal) || cantidadDecimal < 0)
                return "La cantidad debe ser un número válido mayor o igual a 0.";

            if (!decimal.TryParse(precioUnitario, NumberStyles.Any, CultureInfo.CurrentCulture, out decimal precioDecimal) || precioDecimal < 0)
                return "El precio unitario debe ser un número válido mayor o igual a 0.";

            if (materialRepository.ObtenerPorCodigo(codigo) != null)
                return "Ya existe un material con ese código.";

            var nuevo = new MaterialModel(codigo, nombre, descripcion ?? "", tipo, unidad, cantidadDecimal, precioDecimal, DateTime.Today);
            materialRepository.Crear(nuevo);
            return "Material creado exitosamente.";
        }

        public List<string[]> ObtenerTodos()
        {
            var materiales = materialRepository.ObtenerTodos();
            var resultado = new List<string[]>();
            foreach (var m in materiales)
                resultado.Add(new string[] { m.Codigo, m.Nombre, m.Descripcion, m.Tipo, m.Unidad, m.Cantidad.ToString("F2"), m.PrecioUnitario.ToString("F2"), m.FechaRegistro.ToString("yyyy-MM-dd") });
            return resultado;
        }

        public string ActualizarMaterial(string codigo, string nombre, string descripcion, string tipo, string unidad, string cantidad, string precioUnitario)
        {
            if (string.IsNullOrEmpty(codigo))
                return "El código del material es requerido.";

            var existente = materialRepository.ObtenerPorCodigo(codigo);
            if (existente == null)
                return "Material no encontrado.";

            if (!decimal.TryParse(cantidad, NumberStyles.Any, CultureInfo.CurrentCulture, out decimal cantidadDecimal) || cantidadDecimal < 0)
                return "La cantidad debe ser un número válido mayor o igual a 0.";

            if (!decimal.TryParse(precioUnitario, NumberStyles.Any, CultureInfo.CurrentCulture, out decimal precioDecimal) || precioDecimal < 0)
                return "El precio unitario debe ser un número válido mayor o igual a 0.";

            existente.Nombre = nombre;
            existente.Descripcion = descripcion ?? "";
            existente.Tipo = tipo;
            existente.Unidad = unidad;
            existente.Cantidad = cantidadDecimal;
            existente.PrecioUnitario = precioDecimal;
            materialRepository.Actualizar(existente);
            return "Material actualizado exitosamente.";
        }

        public string EliminarMaterial(string codigo)
        {
            if (string.IsNullOrEmpty(codigo))
                return "El código del material es requerido.";

            if (materialRepository.ObtenerPorCodigo(codigo) == null)
                return "Material no encontrado.";

            materialRepository.Eliminar(codigo);
            return "Material eliminado exitosamente.";
        }
    }
}
