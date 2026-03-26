/*
 * 5. Tienda de Computadoras (Composición)
 * Objetivo: Entender cómo los objetos se componen de otros objetos.
 * 
 * - Crea una clase Componente con Nombre y Precio.
 * - Crea una clase Computadora que tenga una List<Componente>.
 * - Agrega métodos a Computadora para AgregarComponente(Componente c) y MostrarResumen().
 * - MostrarResumen() debe listar todos los componentes y mostrar el precio total de la computadora.
 * - Reto: Implementa un límite de componentes (ej: máximo 2 memorias RAM) para practicar la lógica de validación dentro de la clase.
 */

using System;
using System.Collections.Generic;

namespace ejerciciosPOO.ejercicios
{
    public class Componente
    {
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
    }

    public class Computadora
    {
        private List<Componente> componentes = new List<Componente>();

        public void AgregarComponente(Componente c) => componentes.Add(c);

        public decimal CalcularPrecioTotal()
        {
            decimal total = 0;
            foreach (var c in componentes) total += c.Precio;
            return total;
        }

        public void MostrarResumen()
        {
            Console.WriteLine("Resumen de Computadora:");
            foreach (var c in componentes) Console.WriteLine($"- {c.Nombre}: ${c.Precio}");
            Console.WriteLine($"Precio Total: ${CalcularPrecioTotal()}");
        }
    }

    public static class EjemploTienda
    {
        public static void Ejecutar()
        {
            Console.WriteLine("--- EJERCICIO 5: TIENDA DE COMPUTADORAS ---");
            Computadora pc = new Computadora();
            pc.AgregarComponente(new Componente { Nombre = "Procesador i7", Precio = 300 });
            pc.AgregarComponente(new Componente { Nombre = "RAM 16GB", Precio = 80 });
            pc.AgregarComponente(new Componente { Nombre = "SSD 500GB", Precio = 60 });

            pc.MostrarResumen();
        }
    }
}
