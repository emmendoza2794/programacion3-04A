using System;
using System.Collections.Generic;
using biblioteca.Enums;
using biblioteca.Interfaces;
using biblioteca.Modelos;

namespace biblioteca
{
    internal class Program
    {
        private static List<IPrestable> materialesPrestables = new List<IPrestable>();
        private static int siguienteId = 1;

        static void Main(string[] args)
        {
            Console.WriteLine("=== SISTEMA DE BIBLIOTECA DIGITAL ===");

            // Agregar algunos materiales de ejemplo
            InicializarMaterialesEjemplo();

            int opcion;
            do
            {
                MostrarMenu();
                Console.Write("Seleccione una opción: ");

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    ProcesarOpcion(opcion);
                }
                else
                {
                    Console.WriteLine("Opción inválida. Intente nuevamente.");
                }

                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
                Console.Clear();

            } while (opcion != 6);
        }

        private static void MostrarMenu()
        {
            Console.WriteLine("\n=== MENÚ PRINCIPAL ===");
            Console.WriteLine("1. Agregar Libro");
            Console.WriteLine("2. Agregar Revista");
            Console.WriteLine("3. Agregar AudioLibro");
            Console.WriteLine("4. Mostrar todos los materiales");
            Console.WriteLine("5. Procesar préstamo");
            Console.WriteLine("6. Salir");
            Console.WriteLine("=====================");
        }

        private static void ProcesarOpcion(int opcion)
        {
            switch (opcion)
            {
                case 1:
                    AgregarLibro();
                    break;
                case 2:
                    AgregarRevista();
                    break;
                case 3:
                    AgregarAudioLibro();
                    break;
                case 4:
                    MostrarTodosMateriales();
                    break;
                case 5:
                    ProcesarPrestamo();
                    break;
                case 6:
                    Console.WriteLine("¡Gracias por usar el Sistema de Biblioteca Digital!");
                    break;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        }

        private static void AgregarLibro()
        {
            Console.WriteLine("\n=== AGREGAR LIBRO ===");
            Console.Write("Título: ");
            string titulo = Console.ReadLine();

            Console.Write("Autor: ");
            string autor = Console.ReadLine();

            Console.Write("Año de Publicación: ");
            int año = int.Parse(Console.ReadLine());

            Console.Write("Número de Páginas: ");
            int paginas = int.Parse(Console.ReadLine());

            Console.Write("ISBN: ");
            string isbn = Console.ReadLine();

            TipoCategoria categoria = SeleccionarCategoria();

            var libro = new Libro(siguienteId++, titulo, autor, año, categoria, paginas, isbn);
            materialesPrestables.Add(libro);

            Console.WriteLine("Libro agregado exitosamente!");
        }

        private static void AgregarRevista()
        {
            Console.WriteLine("\n=== AGREGAR REVISTA ===");
            Console.Write("Título: ");
            string titulo = Console.ReadLine();

            Console.Write("Autor: ");
            string autor = Console.ReadLine();

            Console.Write("Año de Publicación: ");
            int año = int.Parse(Console.ReadLine());

            Console.Write("Número de Edición: ");
            int edicion = int.Parse(Console.ReadLine());

            Console.Write("Periodicidad: ");
            string periodicidad = Console.ReadLine();

            TipoCategoria categoria = SeleccionarCategoria();

            var revista = new Revista(siguienteId++, titulo, autor, año, categoria, edicion, periodicidad);
            materialesPrestables.Add(revista);

            Console.WriteLine("Revista agregada exitosamente!");
        }

        private static void AgregarAudioLibro()
        {
            Console.WriteLine("\n=== AGREGAR AUDIOLIBRO ===");
            Console.Write("Título: ");
            string titulo = Console.ReadLine();

            Console.Write("Autor: ");
            string autor = Console.ReadLine();

            Console.Write("Año de Publicación: ");
            int año = int.Parse(Console.ReadLine());

            Console.Write("Duración en horas: ");
            int horas = int.Parse(Console.ReadLine());

            Console.Write("Duración en minutos: ");
            int minutos = int.Parse(Console.ReadLine());

            Console.Write("Narrador: ");
            string narrador = Console.ReadLine();

            TipoCategoria categoria = SeleccionarCategoria();

            var audioLibro = new AudioLibro(siguienteId++, titulo, autor, año, categoria, 
                                          new TimeSpan(horas, minutos, 0), narrador);
            materialesPrestables.Add(audioLibro);

            Console.WriteLine("AudioLibro agregado exitosamente!");
        }

        private static TipoCategoria SeleccionarCategoria()
        {
            Console.WriteLine("\nSeleccione una categoría:");
            var categorias = Enum.GetValues(typeof(TipoCategoria));

            for (int i = 0; i < categorias.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {categorias.GetValue(i)}");
            }

            Console.Write("Opción: ");
            int opcion = int.Parse(Console.ReadLine()) - 1;

            return (TipoCategoria)categorias.GetValue(opcion);
        }

        private static void MostrarTodosMateriales()
        {
            Console.WriteLine("\n=== MATERIALES DISPONIBLES ===");

            if (materialesPrestables.Count == 0)
            {
                Console.WriteLine("No hay materiales disponibles.");
                return;
            }

            for (int i = 0; i < materialesPrestables.Count; i++)
            {
                Console.WriteLine($"\n--- Material {i + 1} ---");
                if (materialesPrestables[i] is MaterialBiblioteca material)
                {
                    material.MostrarInformacion();
                }
            }
        }

        private static void ProcesarPrestamo()
        {
            Console.WriteLine("\n=== PROCESAR PRÉSTAMO ===");

            if (materialesPrestables.Count == 0)
            {
                Console.WriteLine("No hay materiales disponibles para préstamo.");
                return;
            }

            MostrarTodosMateriales();

            Console.Write("\nSeleccione el número del material a prestar: ");
            if (int.TryParse(Console.ReadLine(), out int seleccion) && 
                seleccion >= 1 && seleccion <= materialesPrestables.Count)
            {
                var materialSeleccionado = materialesPrestables[seleccion - 1];

                Console.WriteLine("\n");
                materialSeleccionado.GenerarComprobantePrestramo();

                // Simular cálculo de multa por retraso
                Console.Write("\n¿Desea simular días de retraso? (0 para no): ");
                if (int.TryParse(Console.ReadLine(), out int diasRetraso) && diasRetraso > 0)
                {
                    decimal multa = materialSeleccionado.CalcularMultaPorRetraso(diasRetraso);
                    Console.WriteLine($"Multa por {diasRetraso} días de retraso: ${multa:F2}");
                }
            }
            else
            {
                Console.WriteLine("Selección inválida.");
            }
        }

        private static void InicializarMaterialesEjemplo()
        {
            // Agregar algunos materiales de ejemplo
            var libro1 = new Libro(siguienteId++, "El Quijote", "Miguel de Cervantes", 1605, 
                                  TipoCategoria.Ficcion, 863, "978-84-376-0494-7");

            var revista1 = new Revista(siguienteId++, "National Geographic", "Varios", 2023, 
                                      TipoCategoria.Ciencia, 150, "Mensual");

            var audio1 = new AudioLibro(siguienteId++, "1984", "George Orwell", 1949, 
                                       TipoCategoria.Ficcion, new TimeSpan(11, 30, 0), "Simon Prebble");

            materialesPrestables.Add(libro1);
            materialesPrestables.Add(revista1);
            materialesPrestables.Add(audio1);
        }
    }
}
