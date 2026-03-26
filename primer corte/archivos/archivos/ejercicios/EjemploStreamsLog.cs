using System;
using System.IO;

namespace archivos.ejercicios
{
    public static class EjemploStreamsLog
    {
        public static void Ejecutar()
        {
            Console.WriteLine("\n--- 4. Lectura y Escritura con Streams ---");
            string ruta = "bitacora.txt";

            try
            {
                // ESCRITURA CON STREAM (Append mode)
                Console.WriteLine("[INFO] Escribiendo en bitácora...");
                using (StreamWriter sw = new StreamWriter(ruta, true))
                {
                    sw.WriteLine($"[LOG {DateTime.Now}] Evento registrado en la bitácora.");
                }
                Console.WriteLine("[SUCCESS] Bitácora actualizada.");

                // LECTURA CON STREAM
                Console.WriteLine("\n--- Lectura de Bitácora (StreamReader) ---");
                if (File.Exists(ruta))
                {
                    using (StreamReader sr = new StreamReader(ruta))
                    {
                        string linea;
                        while ((linea = sr.ReadLine()) != null)
                        {
                            Console.WriteLine(linea);
                        }
                    }
                }
                Console.WriteLine("--- Fin de la lectura ---");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] {ex.Message}");
            }
        }
    }
}
