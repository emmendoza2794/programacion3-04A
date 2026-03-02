using reproductor.Interfases;
using System;

namespace reproductor.Modelos
{
    public class Podcast: IReproductor
    {
        public string Titulo { get; set; }

        public string Creador { get; set; }

        public int Episodio { get; set; }

        public void Play()
        {
            Console.WriteLine($"Reproduciendo el podcast: {Titulo} de {Creador}, episodio {Episodio}");
        }

        public void Stop()
        {
            Console.WriteLine($"Deteniendo el podcast: {Titulo} de {Creador}, episodio {Episodio}");
        }


    }
}
