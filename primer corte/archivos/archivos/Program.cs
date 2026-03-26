using System;
using archivos.ejercicios;

namespace archivos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("==============================================");
                Console.WriteLine("   MENÚ DE MANEJO DE ARCHIVOS - GUÍA SEMANA 4 ");
                Console.WriteLine("==============================================");
                Console.WriteLine("1. Operaciones Básicas (Clase File)");
                Console.WriteLine("2. Directorios y Rutas (Directory y Path)");
                Console.WriteLine("3. Streams y Bitácora (StreamReader/Writer)");
                Console.WriteLine("4. Datos Estructurados (CSV)");
                Console.WriteLine("0. Salir");
                Console.WriteLine("----------------------------------------------");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        EjemploFileBasico.Ejecutar();
                        break;
                    case "2":
                        EjemploDirectorioPath.Ejecutar();
                        break;
                    case "3":
                        EjemploStreamsLog.Ejecutar();
                        break;
                    case "4":
                        EjemploCSV.Ejecutar();
                        break;
                    case "0":
                        salir = true;
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

                if (!salir)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }
    }
}
