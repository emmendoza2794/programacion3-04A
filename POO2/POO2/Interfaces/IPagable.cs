namespace SistemaNomina.Interfaces
{
    /// <summary>
    /// INTERFAZ: Es un "contrato" que define QUÉ debe hacer una clase, pero no CÓMO.
    /// Cualquier clase que implemente IPagable DEBE tener estos dos métodos.
    /// Esto permite tratar a diferentes objetos (Desarrollador, Gerente) de la misma forma.
    /// 
    /// ¿Por qué usar IPagable en lugar de Empleado?
    /// - FLEXIBILIDAD: Podemos agregar Contratistas, FreeLancers, etc.
    /// - POLIMORFISMO: Tratamos diferentes tipos como si fueran iguales
    /// - PRINCIPIO SOLID: Cada interfaz tiene una responsabilidad específica
    /// </summary>
    public interface IPagable
    {
        /// <summary>
        /// Método para calcular el sueldo final después de bonos, comisiones, etc.
        /// Cada clase implementa SU PROPIA lógica de cálculo.
        /// </summary>
        /// <returns>El salario total a pagar</returns>
        decimal CalcularSalarioNeto();
        
        /// <summary>
        /// Método para imprimir el recibo de pago en consola.
        /// Cada clase genera SU PROPIO formato de recibo.
        /// </summary>
        void GenerarRecibo();
    }
}