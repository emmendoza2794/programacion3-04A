using System;

namespace datatime_y_string.ejercicios
{
    public static class EjemploDateTime
    {
        public static void Ejecutar()
        {
            Console.WriteLine("=== EJEMPLOS DE DATETIME ===");

            // A. Creación y Propiedades
            DateTime ahora = DateTime.Now;
            DateTime fechaEspecifica = new DateTime(2026, 3, 8, 14, 30, 0);

            Console.WriteLine($"Ahora: {ahora}");
            Console.WriteLine($"Año: {ahora.Year}, Mes: {ahora.Month}, Día: {ahora.Day}");
            Console.WriteLine($"Día de la semana: {ahora.DayOfWeek}");

            // B. Operaciones (Inmutabilidad)
            DateTime futuro = ahora.AddDays(10);
            DateTime pasado = ahora.AddMonths(-2);
            Console.WriteLine($"En 10 días será: {futuro.ToShortDateString()}");
            Console.WriteLine($"Hace 2 meses fue: {pasado.ToShortDateString()}");

            // C. Diferencias (TimeSpan)
            DateTime finAño = new DateTime(DateTime.Now.Year, 12, 31);
            TimeSpan faltan = finAño - ahora;
            Console.WriteLine($"Faltan {faltan.Days} días para fin de año.");

            // D. Formateo
            Console.WriteLine($"Formato corto: {ahora.ToShortDateString()}");
            Console.WriteLine($"Formato largo: {ahora.ToLongDateString()}");
            Console.WriteLine($"Formato personalizado (yyyy-MM-dd): {ahora.ToString("yyyy-MM-dd HH:mm:ss")}");

            // E. Parsing
            string entrada = "2026-05-20";
            if (DateTime.TryParse(entrada, out DateTime fechaConvertida))
            {
                Console.WriteLine($"Fecha convertida exitosamente: {fechaConvertida.ToLongDateString()}");
            }
            
            Console.WriteLine();
        }
    }
}
