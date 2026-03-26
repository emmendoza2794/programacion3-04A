using System;
using conceptos_basicos.Ejemplos;

namespace conceptos_basicos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("==========================================");
                Console.WriteLine("     PROGRAMACIÓN III - GRUPO 04A");
                Console.WriteLine("        MENÚ DE EJEMPLOS - MÓDULO 1");
                Console.WriteLine("==========================================");
                Console.WriteLine("1. Sintaxis Básica (Variables, Ciclos)");
                Console.WriteLine("2. Sintaxis Interactiva (Uso de Console.ReadLine)");
                Console.WriteLine("3. POO e Interfaces (Clases, Herencia)");
                Console.WriteLine("4. POO con Entrada de Datos");
                Console.WriteLine("5. Manejo de Archivos (Clase File/Directory)");
                Console.WriteLine("6. Manejo de Archivos Interactivo");
                Console.WriteLine("0. Salir");
                Console.WriteLine("------------------------------------------");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();

                Console.Clear();
                switch (opcion)
                {
                    case "1":
                        EjemploSintaxis.Ejecutar();
                        break;
                    case "2":
                        EjemploSintaxisInput.Ejecutar();
                        break;
                    case "3":
                        EjemploPOO.Ejecutar();
                        break;
                    case "4":
                        EjemploPOOInput.Ejecutar();
                        break;
                    case "5":
                        EjemploArchivos.Ejecutar();
                        break;
                    case "6":
                        EjemploArchivosInput.Ejecutar();
                        break;
                    case "0":
                        Console.WriteLine("Saliendo del programa...");
                        salir = true;
                        continue;
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }

                if (!salir)
                {
                    Console.WriteLine("\nPresione cualquier tecla para volver al menú...");
                    Console.ReadKey();
                }
            }
        }
    }
}
