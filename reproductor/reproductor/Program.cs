//App de Streaming de Música: Crea una interfaz IReproductor 
//con métodos Play() y Stop(). Implementa esta interfaz en 
//clases como Cancion y Podcast. El usuario debe poder "darle play" a cualquiera de los dos.

using reproductor.Interfases;
using reproductor.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace reproductor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido al reproductor de música y podcasts!");

            List<IReproductor> PlayList = new List<IReproductor>();
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("============Menu===========");
                Console.WriteLine("1. Agregar canción");
                Console.WriteLine("2. Agregar podcast");
                Console.WriteLine("3. Reproducir todo");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.WriteLine("Nombre de la canción:");
                        string nombreCancion = Console.ReadLine();

                        Console.WriteLine("Artista:");
                        string artista = Console.ReadLine();

                        Console.WriteLine("Album:");
                        string album = Console.ReadLine();

                        PlayList.Add(new Cancion { Titulo = nombreCancion, Artista = artista, Album = album });

                        break;
                    case "2":
                        Console.WriteLine("Título del podcast:");
                        string tituloPodcast = Console.ReadLine();

                        Console.WriteLine("Creador:");
                        string creador = Console.ReadLine();

                        Console.WriteLine("Número de episodio:");
                        int episodio = int.Parse(Console.ReadLine());

                        PlayList.Add(new Podcast { Titulo = tituloPodcast, Creador = creador, Episodio = episodio });

                        break;
                    case "3":

                        Console.WriteLine("Reproduciendo playlist...");

                        foreach (var item in PlayList)
                        {
                            item.Play();
                        }

                        break;
                    case "4":
                        Console.WriteLine("Saliendo del reproductor. Deteniendo la play list...");

                        foreach (var item in PlayList)
                        {
                            item.Stop();
                        }

                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.");
                        break;
                }
            }

        }
    }
}
