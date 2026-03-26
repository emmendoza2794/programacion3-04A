using System;
using ejerciciosPOO.ejercicios;

namespace ejerciciosPOO
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
                Console.WriteLine("        EJERCICIOS DE POO");
                Console.WriteLine("==========================================");
                Console.WriteLine("1. Gestión de Nómina (Herencia)");
                Console.WriteLine("2. Simulador Bancario (Abstracción)");
                Console.WriteLine("3. Sistema de Notificaciones (Interfaces)");
                Console.WriteLine("4. Batalla RPG (Polimorfismo)");
                Console.WriteLine("5. Tienda de Computadoras (Composición)");
                Console.WriteLine("0. Salir");
                Console.WriteLine("------------------------------------------");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();

                Console.Clear();
                switch (opcion)
                {
                    case "1":
                        EjemploNomina.Ejecutar();
                        break;
                    case "2":
                        EjemploBanco.Ejecutar();
                        break;
                    case "3":
                        EjemploNotificaciones.Ejecutar();
                        break;
                    case "4":
                        EjemploRPG.Ejecutar();
                        break;
                    case "5":
                        EjemploTienda.Ejecutar();
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
