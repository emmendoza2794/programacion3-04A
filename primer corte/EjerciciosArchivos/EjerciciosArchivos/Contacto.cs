using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosArchivos
{

    internal class Contacto
    {
        public List<Contacto> listaContactos = new List<Contacto>();

        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        private static string ruta = "contactos.txt";

        private const char Separador = ';';

        public Contacto(string nombre, string telefono, string email)
        {
            Nombre = nombre;
            Telefono = telefono;
            Email = email;
        }

        public void Agregar()
        {

            using (StreamWriter sw = new StreamWriter(ruta, true))
            {
                string linea = $"{Nombre}{Separador}{Telefono}{Separador}{Email}";
                sw.WriteLine(linea);
            }
        }

        public static void Listar()
        {
            if (File.Exists(ruta))
            {
                using (StreamReader sr = new StreamReader(ruta))
                {
                    string linea;
                    while ((linea = sr.ReadLine()) != null)
                    {
                        string[] datos = linea.Split(Separador);
                        if (datos.Length == 3)
                        {
                            Console.WriteLine($"Nombre: {datos[0]}, Teléfono: {datos[1]}, Email: {datos[2]}");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("No hay contactos registrados.");
            }
        }

        public void CargarContactos()
        {
            listaContactos.Clear();

            if (File.Exists(ruta))
            {
                using (StreamReader sr = new StreamReader(ruta))
                {
                    string linea;
                    while ((linea = sr.ReadLine()) != null)
                    {
                        string[] datos = linea.Split(Separador);
                        if (datos.Length == 3)
                        {
                            var contacto = new Contacto(datos[0], datos[1], datos[2]);
                            listaContactos.Add(contacto);
                        }
                    }
                }
                Console.WriteLine("Lista cargada con exito!!");
            }
        }

        public void EliminarContacto(string nombre)
        {
            CargarContactos();

            var contactoAEliminar = listaContactos.FirstOrDefault(c => c.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));

            if (contactoAEliminar != null)
            {
                listaContactos.Remove(contactoAEliminar);

                // Reescribir el archivo con la lista actualizada
                using (StreamWriter sw = new StreamWriter(ruta, false))
                {
                    foreach (var contacto in listaContactos)
                    {
                        string linea = $"{contacto.Nombre}{Separador}{contacto.Telefono}{Separador}{contacto.Email}";
                        sw.WriteLine(linea);
                    }
                }
                Console.WriteLine("Contacto eliminado con éxito.");
            }
            else
            {
                Console.WriteLine("No se encontró el contacto.");
            }
        }
    }
}
