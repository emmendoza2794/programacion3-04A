using System;
using SistemaNomina.Interfaces;
using SistemaNomina.Enums;

namespace SistemaNomina.Modelos
{
    /// <summary>
    /// CLASE GERENTE
    /// 
    /// HERENCIA (: Empleado) + IMPLEMENTACIÓN (: IPagable)
    /// Al igual que el Desarrollador, hereda de Empleado y cumple con IPagable.
    /// 
    /// Diferencias con Desarrollador:
    /// - Tiene ComisionLiderazgo en lugar de BonoProductividad
    /// - Trabaja en departamento de Ventas en lugar de IT
    /// - Formato de recibo diferente
    /// 
    /// Esto demuestra POLIMORFISMO: misma interfaz, comportamiento diferente
    /// </summary>
    public class Gerente : Empleado, IPagable
    {
        #region Propiedades Específicas
        
        /// <summary>
        /// Comisión adicional por liderazgo de equipos y gestión
        /// El gerente no tiene bono de productividad, tiene comisión de liderazgo
        /// </summary>
        public decimal ComisionLiderazgo { get; set; }
        
        #endregion

        #region Constructor
        
        /// <summary>
        /// Constructor del Gerente
        /// Recibe los datos base y los pasa al constructor padre
        /// </summary>
        /// <param name="id">ID del gerente</param>
        /// <param name="nombre">Nombre del gerente</param>
        /// <param name="sueldo">Salario base</param>
        public Gerente(int id, string nombre, decimal sueldo) : base(id, nombre, sueldo)
        {
            // Los gerentes trabajan en el departamento de Ventas
            Area = Departamento.Ventas;
        }
        
        #endregion

        #region Implementación de IPagable
        
        /// <summary>
        /// IMPLEMENTACIÓN ESPECÍFICA: Calcula salario = base + comisión de liderazgo
        /// Fórmula diferente a la del Desarrollador, pero misma interfaz
        /// </summary>
        /// <returns>Salario total del gerente</returns>
        public decimal CalcularSalarioNeto() => SalarioBase + ComisionLiderazgo;

        /// <summary>
        /// IMPLEMENTACIÓN ESPECÍFICA: Genera recibo con formato para gerentes
        /// Muestra información relevante: nombre, departamento, total
        /// </summary>
        public void GenerarRecibo()
        {
            Console.WriteLine($"RECIBO GERENCIA: {Nombre} | Depto: {Area} | Total: {CalcularSalarioNeto():C}");
        }
        
        #endregion
    }
}