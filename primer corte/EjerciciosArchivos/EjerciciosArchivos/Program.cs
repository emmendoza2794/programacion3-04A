using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosArchivos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcion;
            do
            {

                Console.WriteLine("=== Mis Contactos ===");
                Console.WriteLine("1. Agregar Contacto");
                Console.WriteLine("2. Listar Contactos");

                Console.WriteLine("3. Salir");
                Console.Write("Seleccione una opción: ");

                

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            Console.WriteLine("\n=== Agregar contacto ===");

                            Console.Write("Nombre: ");
                            string nombre = Console.ReadLine();

                            Console.Write("Telefono: ");
                            string telefono = Console.ReadLine();

                            Console.Write("Email: ");
                            string email = Console.ReadLine();

                            var NuevoContacto = new Contacto(nombre, telefono, email);

                            NuevoContacto.Agregar();

                            break;
                        case 2:
                            Console.WriteLine("Listar Contactos");
                            
                            Contacto.Listar();

                            break;
                        case 3:
                            Console.WriteLine("Saliendo...");
                            break;
                        default:
                            Console.WriteLine("Opción no válida. Intente nuevamente.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Opción inválida. Intente nuevamente.");
                }

                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
                Console.Clear();

            } while (opcion != 3);
        }

    }
}
