using System;
using datatime_y_string.ejercicios;

namespace datatime_y_string
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ejecución de ejemplos de DateTime
            EjemploDateTime.Ejecutar();

            // Separador visual
            Console.WriteLine(new string('-', 50));

            // Ejecución de ejemplos de Strings
            EjemploStrings.Ejecutar();

            // Mantener la consola abierta
            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
