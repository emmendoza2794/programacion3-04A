using biblioteca.Enums;
using biblioteca.Interfaces;
using System;

namespace biblioteca.Modelos
{
    public class Libro : MaterialBiblioteca, IPrestable
    {
        public int NumeroPaginas { get; set; }
        public string ISBN { get; set; }

        public Libro(int id, string titulo, string autor, int añoPublicacion, TipoCategoria categoria, 
                     int numeroPaginas, string isbn)
            : base(id, titulo, autor, añoPublicacion, categoria)
        {
            NumeroPaginas = numeroPaginas;
            ISBN = isbn;
        }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"Número de Páginas: {NumeroPaginas}");
            Console.WriteLine($"ISBN: {ISBN}");
            Console.WriteLine("Tipo: Libro");
        }

        public DateTime CalcularFechaDevolucion()
        {
            return DateTime.Now.AddDays(14); // 14 días para libros
        }

        public void GenerarComprobantePrestramo()
        {
            Console.WriteLine("=== COMPROBANTE DE PRÉSTAMO - LIBRO ===");
            Console.WriteLine($"Libro: {Titulo}");
            Console.WriteLine($"Autor: {Autor}");
            Console.WriteLine($"ISBN: {ISBN}");
            Console.WriteLine($"Fecha de Préstamo: {DateTime.Now:dd/MM/yyyy}");
            Console.WriteLine($"Fecha de Devolución: {CalcularFechaDevolucion():dd/MM/yyyy}");
            Console.WriteLine("======================================");
        }

        public decimal CalcularMultaPorRetraso(int diasRetraso)
        {
            return diasRetraso * 0.50m; // $0.50 por día de retraso
        }
    }
}