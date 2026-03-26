using System;

namespace conceptos_basicos.Ejemplos
{
    public class EjemploSintaxisInput
    {
        public static void Ejecutar()
        {
            Console.WriteLine("=== Ejemplo de Sintaxis con Entrada de Datos ===");

            Console.Write("Ingrese su nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Ingrese su edad: ");
            string entradaEdad = Console.ReadLine();
            int edad;
            bool edadValida = int.TryParse(entradaEdad, out edad);

            if (edadValida)
            {
                Console.Write("Ingrese su precio favorito: ");
                string entradaPrecio = Console.ReadLine();
                double precio;
                bool precioValido = double.TryParse(entradaPrecio, out precio);

                if (precioValido)
                {
                    Console.WriteLine("\n[INFO] Hola " + nombre + ", tienes " + edad + " años.");
                    Console.WriteLine("Tu precio favorito es: " + precio.ToString("C"));
                    
                    if (edad >= 18)
                    {
                        Console.WriteLine("[INFO] Eres mayor de edad.");
                    }
                    else
                    {
                        Console.WriteLine("[INFO] Eres menor de edad.");
                    }
                }
                else
                {
                    Console.WriteLine("[ERROR] Precio inválido.");
                }
            }
            else
            {
                Console.WriteLine("[ERROR] Edad inválida.");
            }

            Console.WriteLine();
        }
    }
}
