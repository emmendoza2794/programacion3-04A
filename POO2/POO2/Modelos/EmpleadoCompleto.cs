using System;
using SistemaNomina.Enums;

namespace SistemaNomina.Modelos
{
    /// <summary>
    /// CLASE ABSTRACTA: Una base que NO se puede instanciar directamente.
    /// Solo sirve para que otras clases (como Desarrollador o Gerente) hereden de ella.
    /// Representa la idea general de un "Empleado".
    /// 
    /// ¿Por qué abstracta?
    /// - No tiene sentido crear un "Empleado genérico"
    /// - Obliga a crear tipos específicos (Desarrollador, Gerente, etc.)
    /// - Define la estructura común para todos los empleados
    /// </summary>
    public abstract class Empleado
    {
        #region Propiedades
        
        /// <summary>
        /// Identificador único del empleado
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Nombre completo del empleado
        /// </summary>
        public string Nombre { get; set; }
        
        /// <summary>
        /// Salario base del empleado.
        /// El setter es 'protected' para que solo esta clase o sus hijas (herencia)
        /// puedan modificar el salario base directamente.
        /// </summary>
        public decimal SalarioBase { get; protected set; }
        
        /// <summary>
        /// Departamento donde trabaja el empleado
        /// </summary>
        public Departamento Area { get; set; }
        
        #endregion

        #region Constructor
        
        /// <summary>
        /// CONSTRUCTOR: Se ejecuta cuando creamos un nuevo objeto.
        /// Como la clase es abstracta, este constructor será llamado por las clases hijas (base).
        /// </summary>
        /// <param name="id">ID único del empleado</param>
        /// <param name="nombre">Nombre del empleado</param>
        /// <param name="baseSalarial">Salario base</param>
        public Empleado(int id, string nombre, decimal baseSalarial)
        {
            Id = id;
            Nombre = nombre;
            SalarioBase = baseSalarial;
        }
        
        #endregion

        #region Métodos
        
        /// <summary>
        /// MÉTODO VIRTUAL: Un método que tiene una lógica básica,
        /// pero que las clases que heredan PUEDEN "sobreescribir" (override)
        /// para cambiar su comportamiento si lo necesitan.
        /// </summary>
        public virtual void MostrarDatos()
        {
            Console.WriteLine($"[{Id}] {Nombre} - Depto: {Area}");
        }
        
        #endregion
    }
}