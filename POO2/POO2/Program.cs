using System;
using System.Collections.Generic;
using SistemaNomina.Modelos;
using SistemaNomina.Interfaces;
using SistemaNomina.Enums;

namespace POO2
{
    class Program
    {
        static void Main()
        {
            // POLIMORFISMO: Creamos una lista de IPagable.
            // Una interfaz nos permite meter objetos DIFERENTES (Desarrollador, Gerente)
            // en la MISMA lista, siempre y cuando todos "sepan" ser IPagable.
            List<IPagable> nomina = new List<IPagable>();
            bool continuar = true;

            Console.WriteLine("=== SISTEMA DE GESTIÓN DE NÓMINA ===");

            while (continuar)
            {
                Console.WriteLine("\nSeleccione el tipo de empleado a registrar:");
                Console.WriteLine("1. Desarrollador");
                Console.WriteLine("2. Gerente");
                Console.WriteLine("3. Procesar Nómina y Salir");
                Console.Write("Opción: ");
                
                string opcion = Console.ReadLine();

                if (opcion == "3")
                {
                    continuar = false;
                    continue;
                }

                // MANEJO DE EXCEPCIONES: 'try-catch' evita que el programa se cierre 
                // si el usuario comete un error al escribir (por ejemplo, letras en lugar de números).
                try
                {
                    Console.Write("ID: ");
                    int id = int.Parse(Console.ReadLine());

                    Console.Write("Nombre: ");
                    string nombre = Console.ReadLine();

                    Console.Write("Salario Base: ");
                    decimal salario = decimal.Parse(Console.ReadLine());

                    if (opcion == "1")
                    {
                        Console.Write("Lenguaje Principal: ");
                        string lenguaje = Console.ReadLine();
                        
                        Console.Write("Bono de Productividad: ");
                        decimal bono = decimal.Parse(Console.ReadLine());

                        // Agregamos un objeto de tipo Desarrollador a la lista de IPagable.
                        nomina.Add(new Desarrollador(id, nombre, salario)
                        {
                            LenguajePrincipal = lenguaje,
                            BonoProductividad = bono
                        });
                    }
                    else if (opcion == "2")
                    {
                        Console.Write("Comisión de Liderazgo: ");
                        decimal comision = decimal.Parse(Console.ReadLine());

                        // Agregamos un objeto de tipo Gerente a la lista de IPagable.
                        nomina.Add(new Gerente(id, nombre, salario)
                        {
                            ComisionLiderazgo = comision
                        });
                    }
                    else
                    {
                        Console.WriteLine("Opción no válida.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Ingrese un valor numérico válido.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error inesperado: {ex.Message}");
                }
            }

            Console.WriteLine("\n--- PROCESANDO NÓMINA MENSUAL ---");
            if (nomina.Count == 0)
            {
                Console.WriteLine("No hay empleados registrados.");
            }
            else
            {
                // Gracias al POLIMORFISMO, no nos importa si el 'item' es Desarrollador o Gerente.
                // Como es IPagable, SABEMOS que tiene el método GenerarRecibo().
                foreach (var item in nomina)
                {
                    // Mostramos los datos del empleado antes de generar el recibo
                    if (item is Empleado empleado)
                    {
                        empleado.MostrarDatos();
                    }
                    item.GenerarRecibo();
                    Console.WriteLine(); // Línea en blanco para separar empleados
                }
            }

            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
