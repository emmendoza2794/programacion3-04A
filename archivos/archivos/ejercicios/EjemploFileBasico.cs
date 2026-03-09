using System;
using System.IO;

namespace archivos.ejercicios
{
    public static class EjemploFileBasico
    {
        public static void Ejecutar()
        {
            Console.WriteLine("\n--- 3. Operaciones Básicas con la Clase File ---");
            string ruta = "notas2.txt";

            try
            {
                // 1. Escribir texto (sobrescribe el archivo si existe)
                Console.WriteLine("[INFO] Escribiendo texto inicial...");
                File.WriteAllText(ruta, "Primera línea de texto 2.");

                // 2. Agregar texto al final (sin borrar lo anterior)
                Console.WriteLine("[INFO] Agregando nueva línea...");
                File.AppendAllText(ruta, "\nEsta es una nueva línea 2.");

                // 3. Verificar si el archivo existe
                if (File.Exists(ruta))
                {
                    Console.WriteLine("[SUCCESS] El archivo está listo para usarse.");

                    // 4. Leer todo el contenido como un solo string
                    Console.WriteLine("\n--- Contenido Completo (ReadAllText) ---");
                    string contenido = File.ReadAllText(ruta);
                    Console.WriteLine(contenido);

                    // 5. Leer el archivo y obtener un arreglo de líneas
                    Console.WriteLine("\n--- Lectura por Líneas (ReadAllLines) ---");
                    string[] lineas = File.ReadAllLines(ruta);
                    foreach (string l in lineas)
                    {
                        Console.WriteLine("Línea: " + l);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] {ex.Message}");
            }
        }
    }
}
