using System;

namespace login.models
{
    internal class ProductoModel
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string Categoria { get; set; }
        public DateTime FechaRegistro { get; set; }

        public ProductoModel(string codigo, string nombre, string descripcion, decimal precio, int stock, string categoria, DateTime fechaRegistro)
        {
            Codigo = codigo;
            Nombre = nombre;
            Descripcion = descripcion;
            Precio = precio;
            Stock = stock;
            Categoria = categoria;
            FechaRegistro = fechaRegistro;
        }
    }
}
