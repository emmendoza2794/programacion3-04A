using System;

namespace login.models
{
    internal class MaterialModel
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        public string Unidad { get; set; }
        public decimal Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public DateTime FechaRegistro { get; set; }

        public MaterialModel(string codigo, string nombre, string descripcion, string tipo, string unidad, decimal cantidad, decimal precioUnitario, DateTime fechaRegistro)
        {
            Codigo = codigo;
            Nombre = nombre;
            Descripcion = descripcion;
            Tipo = tipo;
            Unidad = unidad;
            Cantidad = cantidad;
            PrecioUnitario = precioUnitario;
            FechaRegistro = fechaRegistro;
        }
    }
}
