using System;
using System.IO;

namespace conceptos_basicos.Ejemplos
{
    public class EjemploArchivos
    {
        public static void Ejecutar()
        {
            Console.WriteLine("=== Ejemplo de Manejo de Archivos y Directorios ===");

            // Definimos una carpeta específica para las pruebas
            string nombreCarpeta = "MisArchivosDePrueba";
            string nombreArchivo = "mensaje_estudiante.txt";

            // Combinamos para obtener la ruta completa (Best Practice: usar Path.Combine)
            string rutaCompletaCarpeta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, nombreCarpeta);
            string rutaCompletaArchivo = Path.Combine(rutaCompletaCarpeta, nombreArchivo);

            string contenido = "Este es un mensaje guardado desde C#.\n" +
                              $"Fecha de creación: {DateTime.Now}\n" +
                              "Este archivo se encuentra en la carpeta del proyecto.";

            try
            {
                // 1. Manejo de Directorios: Crear la carpeta si no existe
                if (!Directory.Exists(rutaCompletaCarpeta))
                {
                    Directory.CreateDirectory(rutaCompletaCarpeta);
                    Console.WriteLine($"[INFO] Carpeta creada en: {rutaCompletaCarpeta}");
                }

                // 2. Manejo de Archivos: Escribir el contenido
                File.WriteAllText(rutaCompletaArchivo, contenido);
                Console.WriteLine($"[SUCCESS] Archivo '{nombreArchivo}' creado con éxito.");
                Console.WriteLine($"[UBICACIÓN] {rutaCompletaArchivo}");

                // 3. Lectura para verificar
                Console.WriteLine("\n--- Leyendo el contenido del archivo ---");
                string lectura = File.ReadAllText(rutaCompletaArchivo);
                Console.WriteLine(lectura);
                Console.WriteLine("---------------------------------------");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Ocurrió un problema: {ex.Message}");
            }

            Console.WriteLine();
        }
    }
}
