using System;
using System.IO;
using System.Collections.Generic;

namespace archivos.ejercicios
{
    public class Estudiante
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public double Nota { get; set; }

        public string ToCSV() => $"{Id};{Nombre};{Nota}";
    }

    public static class EjemploCSV
    {
        public static void Ejecutar()
        {
            Console.WriteLine("\n--- 5. Manejo de Datos Estructurados (CSV) ---");
            string ruta = "estudiantes.csv";

            try
            {
                // SERIALIZACIÓN MANUAL (Guardar)
                Console.WriteLine("[INFO] Guardando un nuevo estudiante...");
                Estudiante est = new Estudiante { Id = "001", Nombre = "Juan", Nota = 4.5 };
                File.AppendAllText(ruta, est.ToCSV() + Environment.NewLine);
                Console.WriteLine($"[SUCCESS] Estudiante '{est.Nombre}' guardado en CSV.");

                Estudiante est2 = new Estudiante { Id = "002", Nombre = "Pedro", Nota = 4.0 };
                File.AppendAllText(ruta, est2.ToCSV() + Environment.NewLine);
                Console.WriteLine($"[SUCCESS] Estudiante '{est2.Nombre}' guardado en CSV.");

                Estudiante est3 = new Estudiante { Id = "003", Nombre = "Camilo", Nota = 2.5 };
                File.AppendAllText(ruta, est3.ToCSV() + Environment.NewLine);
                Console.WriteLine($"[SUCCESS] Estudiante '{est3.Nombre}' guardado en CSV.");

                // DESERIALIZACIÓN MANUAL (Recuperar)
                Console.WriteLine("\n--- Cargando Datos desde CSV ---");
                if (File.Exists(ruta))
                {
                    string[] lineas = File.ReadAllLines(ruta);
                    foreach (string linea in lineas)
                    {
                        string[] datos = linea.Split(';');
                        if (datos.Length == 3)
                        {
                            Estudiante e = new Estudiante
                            {
                                Id = datos[0],
                                Nombre = datos[1],
                                Nota = double.Parse(datos[2])
                            };
                            Console.WriteLine($"Cargado: [ID: {e.Id}] {e.Nombre} - Nota: {e.Nota}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("[WARNING] El archivo CSV aún no existe.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] {ex.Message}");
            }
        }
    }
}
