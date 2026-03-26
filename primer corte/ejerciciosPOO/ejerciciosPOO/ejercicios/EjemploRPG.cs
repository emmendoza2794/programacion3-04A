/*
 * 4. Juego de Batalla RPG (Abstracción y Polimorfismo)
 * Objetivo: Modelar personajes con comportamientos únicos.
 * 
 * - Crea una clase abstracta Personaje con Nombre, Vida y un método abstracto Atacar().
 * - Crea la clase Guerrero: Su ataque quita 20 de vida y tiene un mensaje de "Grito de guerra".
 * - Crea la clase Mago: Su ataque quita 15 de vida pero consume "Maná" (una nueva propiedad).
 * - Crea la clase Arquero: Tiene una probabilidad de "Crítico" que duplica el daño.
 * - Reto: Crea un método RecibirDanio(int cantidad) y haz que un personaje muera si su vida llega a 0.
 */

using System;

namespace ejerciciosPOO.ejercicios
{
    public abstract class Personaje
    {
        public string Nombre { get; set; }
        public int Vida { get; set; }

        public abstract void Atacar();

        public void RecibirDanio(int danio)
        {
            Vida -= danio;
            Console.WriteLine($"{Nombre} recibió {danio} de daño. Vida restante: {Vida}");
            if (Vida <= 0) Console.WriteLine($"{Nombre} ha muerto.");
        }
    }

    public class Guerrero : Personaje
    {
        public override void Atacar() => Console.WriteLine($"{Nombre} ataca con su espada (20 DMG)");
    }

    public class Mago : Personaje
    {
        public int Mana { get; set; }
        public override void Atacar() => Console.WriteLine($"{Nombre} lanza un hechizo (15 DMG)");
    }

    public static class EjemploRPG
    {
        public static void Ejecutar()
        {
            Console.WriteLine("--- EJERCICIO 4: BATALLA RPG ---");
            Guerrero conan = new Guerrero { Nombre = "Conan", Vida = 100 };
            Mago merlin = new Mago { Nombre = "Merlin", Vida = 80, Mana = 50 };

            conan.Atacar();
            merlin.RecibirDanio(20);

            merlin.Atacar();
            conan.RecibirDanio(15);
        }
    }
}
