using System;
using System.IO;

namespace archivos.ejercicios
{
    public static class EjemploDirectorioPath
    {
        public static void Ejecutar()
        {
            Console.WriteLine("\n--- 4. Clase Directory y Path ---");
            string carpeta = "MisArchivos";

            try
            {
                // Crear carpeta si no existe
                if (!Directory.Exists(carpeta))
                {
                    Directory.CreateDirectory(carpeta);
                    Console.WriteLine($"[INFO] Carpeta '{carpeta}' creada.");
                }

                // Combinar rutas de forma segura
                string nombreArchivo = "datos_seguros.txt";
                string rutaCompleta = Path.Combine(carpeta, nombreArchivo);
                Console.WriteLine($"[INFO] Ruta combinada: {rutaCompleta}");

                // Guardar un dato en la nueva ruta
                File.WriteAllText(rutaCompleta, "Este archivo está en una subcarpeta.");
                Console.WriteLine($"[SUCCESS] Archivo creado en: {Path.GetFullPath(rutaCompleta)}");

                // Listar contenido de la carpeta
                Console.WriteLine("\n--- Contenido de la carpeta ---");
                string[] archivos = Directory.GetFiles(carpeta);
                foreach (string archivo in archivos)
                {
                    Console.WriteLine($"- {Path.GetFileName(archivo)}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] {ex.Message}");
            }
        }
    }
}
