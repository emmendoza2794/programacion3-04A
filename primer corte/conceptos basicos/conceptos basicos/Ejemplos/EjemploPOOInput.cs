using System;

namespace conceptos_basicos.Ejemplos
{
    public class PerroPersonalizado : Animal
    {
        public string Raza { get; set; }

        public override void HacerSonido()
        {
            Console.WriteLine(Nombre + " (Raza: " + Raza + ") dice: ¡Guau, guau!");
        }
    }

    public class EjemploPOOInput
    {
        public static void Ejecutar()
        {
            Console.WriteLine("=== Ejemplo de POO con Entrada de Datos ===");

            PerroPersonalizado miPerro = new PerroPersonalizado();

            Console.Write("Ingrese el nombre de su perro: ");
            miPerro.Nombre = Console.ReadLine();

            Console.Write("Ingrese la raza de su perro: ");
            miPerro.Raza = Console.ReadLine();

            Console.WriteLine("\n[INFO] Datos del objeto perro:");
            miPerro.HacerSonido();

            Console.WriteLine();
        }
    }
}
