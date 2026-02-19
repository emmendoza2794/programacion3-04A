using System;

namespace conceptos_basicos.Ejemplos
{
    // Definición de una interfaz (Best Practice: empieza con I)
    public interface IVehiculo
    {
        void Mover();
    }

    // Clase base abstracta
    public abstract class Animal
    {
        public string Nombre { get; set; }
        public abstract void HacerSonido();
    }

    // Clase que hereda de Animal
    public class Perro : Animal
    {
        public override void HacerSonido()
        {
            Console.WriteLine($"{Nombre} dice: ¡Guau!");
        }
    }

    public class EjemploPOO
    {
        public static void Ejecutar()
        {
            Console.WriteLine("=== Ejemplo de POO e Interfaces ===");

            Perro miPerro = new Perro { Nombre = "Firulais" };
            miPerro.HacerSonido();

            // Ejemplo de tipos anónimos o var
            var fechaHoy = DateTime.Now;
            Console.WriteLine($"Hoy es: {fechaHoy:dd/MM/yyyy}");
            
            Console.WriteLine();
        }
    }
}
