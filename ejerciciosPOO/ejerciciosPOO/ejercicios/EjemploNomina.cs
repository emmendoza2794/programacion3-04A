/*
 * 1. Sistema de Gestión de Nómina (Herencia y Polimorfismo)
 * Objetivo: Implementar una jerarquía de clases para calcular salarios.
 * 
 * - Crea una clase base Empleado con propiedades Nombre y SalarioBase.
 * - Define un método virtual CalcularSalario().
 * - Crea una clase Gerente que herede de Empleado y añada un BonoFijo. Sobrescribe CalcularSalario() para sumar el bono.
 * - Crea una clase Vendedor que herede de Empleado y añada Comision y VentasRealizadas. Sobrescribe CalcularSalario() para sumar la comisión por cada venta.
 * - Reto: En el Main, crea una lista de Empleado que contenga gerentes y vendedores, y recorre la lista imprimiendo el nombre y salario final de cada uno.
 */

using System;
using System.Collections.Generic;

namespace ejerciciosPOO.ejercicios
{
    public class Empleado
    {
        public string Nombre { get; set; }
        public decimal SalarioBase { get; set; }

        public virtual decimal CalcularSalario()
        {
            return SalarioBase;
        }
    }

    public class Gerente : Empleado
    {
        public decimal Bono { get; set; }

        public override decimal CalcularSalario()
        {
            return base.CalcularSalario() + Bono;
        }
    }

    public class Vendedor : Empleado
    {
        public decimal Comision { get; set; }
        public int Ventas { get; set; }

        public override decimal CalcularSalario()
        {
            return base.CalcularSalario() + (Comision * Ventas);
        }
    }

    public static class EjemploNomina
    {
        public static void Ejecutar()
        {
            Console.WriteLine("--- EJERCICIO 1: GESTIÓN DE NÓMINA ---");
            List<Empleado> empleados = new List<Empleado>
            {
                new Gerente { Nombre = "Ana Garcia", SalarioBase = 3000, Bono = 500 },
                new Vendedor { Nombre = "Juan Perez", SalarioBase = 1500, Comision = 50, Ventas = 10 },
                new Empleado { Nombre = "Luis Torres", SalarioBase = 1200 }
            };

            foreach (var emp in empleados)
            {
                Console.WriteLine($"Empleado: {emp.Nombre} | Salario Final: ${emp.CalcularSalario()}");
            }
        }
    }
}
