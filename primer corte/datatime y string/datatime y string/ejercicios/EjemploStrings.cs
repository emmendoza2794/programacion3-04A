using System;
using System.Text;

namespace datatime_y_string.ejercicios
{
    public static class EjemploStrings
    {
        public static void Ejecutar()
        {
            Console.WriteLine("=== EJEMPLOS DE MANIPULACIÓN DE CADENAS (STRINGS) ===");

            // A. Métodos de String
            string texto = "  C# es un lenguaje INCREÍBLE  ";
            Console.WriteLine($"Texto original: '{texto}'");

            string limpio = texto.Trim();
            Console.WriteLine($"Limpio (Trim): '{limpio}'");

            string lower = texto.ToLower();
            Console.WriteLine($"Minúsculas (ToLower): '{lower}'");

            string reemplazo = texto.Replace("INCREÍBLE", "potente");
            Console.WriteLine($"Reemplazo (Replace): '{reemplazo}'");

            bool contiene = texto.Contains("C#");
            Console.WriteLine($"¿Contiene 'C#'?: {contiene}");

            string[] palabras = texto.Trim().Split(' ');
            Console.WriteLine("Palabras divididas (Split):");
            foreach (string p in palabras)
            {
                Console.WriteLine($"- {p}");
            }

            // B. StringBuilder (Eficiencia)
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Lista de Notas de Alumnos:");
            for (int i = 1; i <= 5; i++)
            {
                sb.AppendLine($"Alumno {i} - Nota: {new Random().Next(10, 21)}");
            }
            string resultadoFinal = sb.ToString();
            Console.WriteLine("\nStringBuilder result:");
            Console.WriteLine(resultadoFinal);
        }
    }
}
