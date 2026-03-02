using System;
using SistemaNomina.Interfaces;
using SistemaNomina.Enums;

namespace SistemaNomina.Modelos
{
    /// <summary>
    /// CLASE DESARROLLADOR
    /// 
    /// HERENCIA (: Empleado) + IMPLEMENTACIÓN (: IPagable)
    /// - HEREDA: Obtiene propiedades y métodos de la clase Empleado
    /// - IMPLEMENTA: Cumple el contrato IPagable (debe tener CalcularSalarioNeto y GenerarRecibo)
    /// 
    /// Conceptos clave:
    /// - Especialización: Es un tipo específico de empleado
    /// - Polimorfismo: Puede ser tratado como Empleado o como IPagable
    /// - Encapsulación: Tiene sus propias propiedades específicas
    /// </summary>
    public class Desarrollador : Empleado, IPagable
    {
        #region Propiedades Específicas
        
        /// <summary>
        /// Lenguaje de programación principal que domina el desarrollador
        /// </summary>
        public string LenguajePrincipal { get; set; }
        
        /// <summary>
        /// Bono adicional por productividad en proyectos
        /// </summary>
        public decimal BonoProductividad { get; set; }
        
        #endregion

        #region Constructor
        
        /// <summary>
        /// Constructor del Desarrollador
        /// El constructor recibe los datos y los pasa al constructor de la clase base (Empleado) 
        /// usando ': base(id, nombre, sueldo)'.
        /// </summary>
        /// <param name="id">ID del desarrollador</param>
        /// <param name="nombre">Nombre del desarrollador</param>
        /// <param name="sueldo">Salario base</param>
        public Desarrollador(int id, string nombre, decimal sueldo) : base(id, nombre, sueldo) 
        {
            // Asignamos el departamento automáticamente
            Area = Departamento.IT;
        }
        
        #endregion

        #region Implementación de IPagable
        
        /// <summary>
        /// IMPLEMENTACIÓN ESPECÍFICA: Calcula salario = base + bono de productividad
        /// Cada tipo de empleado tiene SU PROPIA fórmula de cálculo
        /// </summary>
        /// <returns>Salario total del desarrollador</returns>
        public decimal CalcularSalarioNeto() => SalarioBase + BonoProductividad;

        /// <summary>
        /// IMPLEMENTACIÓN ESPECÍFICA: Genera recibo con formato para desarrolladores
        /// Muestra información relevante: nombre, lenguaje, total
        /// </summary>
        public void GenerarRecibo()
        {
            // Al usar ':C', C# lo formatea como moneda local automáticamente
            Console.WriteLine($"RECIBO DESARROLLADOR: {Nombre} | Lenguaje: {LenguajePrincipal} | Total: {CalcularSalarioNeto():C}");
        }
        
        #endregion
    }
}