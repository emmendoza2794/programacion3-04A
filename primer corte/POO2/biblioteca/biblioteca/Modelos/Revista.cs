using biblioteca.Enums;
using biblioteca.Interfaces;
using System;

namespace biblioteca.Modelos
{
    public class Revista : MaterialBiblioteca, IPrestable
    {
        public int NumeroEdicion { get; set; }
        public string Periodicidad { get; set; }

        public Revista(int id, string titulo, string autor, int añoPublicacion, TipoCategoria categoria, 
                       int numeroEdicion, string periodicidad)
            : base(id, titulo, autor, añoPublicacion, categoria)
        {
            NumeroEdicion = numeroEdicion;
            Periodicidad = periodicidad;
        }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"Número de Edición: {NumeroEdicion}");
            Console.WriteLine($"Periodicidad: {Periodicidad}");
            Console.WriteLine("Tipo: Revista");
        }

        public DateTime CalcularFechaDevolucion()
        {
            return DateTime.Now.AddDays(7); // 7 días para revistas
        }

        public void GenerarComprobantePrestramo()
        {
            Console.WriteLine("=== COMPROBANTE DE PRÉSTAMO - REVISTA ===");
            Console.WriteLine($"Revista: {Titulo}");
            Console.WriteLine($"Autor: {Autor}");
            Console.WriteLine($"Edición: {NumeroEdicion}");
            Console.WriteLine($"Periodicidad: {Periodicidad}");
            Console.WriteLine($"Fecha de Préstamo: {DateTime.Now:dd/MM/yyyy}");
            Console.WriteLine($"Fecha de Devolución: {CalcularFechaDevolucion():dd/MM/yyyy}");
            Console.WriteLine("=========================================");
        }

        public decimal CalcularMultaPorRetraso(int diasRetraso)
        {
            return diasRetraso * 0.30m; // $0.30 por día de retraso
        }
    }
}