using System;
using System.IO;

namespace conceptos_basicos.Ejemplos
{
    public class EjemploArchivosInput
    {
        public static void Ejecutar()
        {
            Console.WriteLine("=== Ejemplo de Manejo de Archivos con Entrada de Datos ===");

            string nombreCarpeta = "MisArchivosDeEntrada";
            string rutaBase = AppDomain.CurrentDomain.BaseDirectory;
            string rutaCompletaCarpeta = Path.Combine(rutaBase, nombreCarpeta);

            try
            {
                if (!Directory.Exists(rutaCompletaCarpeta))
                {
                    Directory.CreateDirectory(rutaCompletaCarpeta);
                }

                Console.Write("Ingrese el nombre del archivo (ejemplo: datos.txt): ");
                string nombreArchivo = Console.ReadLine();
                string rutaCompletaArchivo = Path.Combine(rutaCompletaCarpeta, nombreArchivo);

                Console.WriteLine("Ingrese el contenido para el archivo:");
                string contenido = Console.ReadLine();

                File.WriteAllText(rutaCompletaArchivo, contenido);
                Console.WriteLine("\n[SUCCESS] Archivo creado con éxito.");
                Console.WriteLine("Ruta: " + rutaCompletaArchivo);

                Console.WriteLine("\n¿Desea leer el archivo creado? (S/N):");
                string respuesta = Console.ReadLine();
                
                if (respuesta != null && respuesta.ToUpper() == "S")
                {
                    string lectura = File.ReadAllText(rutaCompletaArchivo);
                    Console.WriteLine("--- Contenido del archivo ---");
                    Console.WriteLine(lectura);
                    Console.WriteLine("-----------------------------");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[ERROR] Ocurrió un problema: " + ex.Message);
            }

            Console.WriteLine();
        }
    }
}
