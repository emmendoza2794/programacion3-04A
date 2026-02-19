using System;

namespace conceptos_basicos.Ejemplos
{
    /// <summary>
    /// Ejemplo de elementos sintácticos básicos en C#.
    /// </summary>
    public class EjemploSintaxis
    {
        public static void Ejecutar()
        {
            Console.WriteLine("=== Ejemplo de Sintaxis Básica ===");

            // Tipos de datos comunes
            int edad = 25;
            double precio = 19.99;
            string nombre = "Estudiante";
            bool esActivo = true;

            // Interpolación de cadenas (Best Practice)
            Console.WriteLine($"Nombre: {nombre}, Edad: {edad}, Precio: {precio:C}, Activo: {esActivo}");

            // Estructuras de control
            if (edad >= 18)
            {
                Console.WriteLine("Es mayor de edad.");
            }

            Console.WriteLine("Ciclo for:");
            for (int i = 1; i <= 3; i++)
            {
                Console.WriteLine($"  Iteración {i}");
            }
            
            Console.WriteLine();
        }
    }
}
