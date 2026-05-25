using MathNet.Numerics;
using MathNet.Numerics.Integration;
using Parte_Proyecto_MZ.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parte_Proyecto_MZ
{
    internal class ControladorDatos
    {
        public List<Datos> ListaDatos = new List<Datos>();
         public void AgregarDatos(double x, double y, double z)
        {
            Datos nuevoDato = new Datos(x, y, z);
            ListaDatos.Add(nuevoDato);
        }

        public double CalcularArea()
        {
            int n = ListaDatos.Count;
            if (n < 3)
            {
                return 0; 
            }

            double Area = 0;
            for (int i = 0; i < n; i++)
            {
                int j = (i + 1) % n;
                Area += ListaDatos[i].X * ListaDatos[j].Y;
                Area -= ListaDatos[j].X * ListaDatos[i].Y;
            }
            return Math.Abs(Area) / 2.0;
        }
        public double CalcularVolumen() 
        {
            if (ListaDatos.Count < 3)
            {
                return 0;
            }

            double xMin = ListaDatos.Min(p => p.X);
            double xMax = ListaDatos.Max(p => p.X);
            double yMin = ListaDatos.Min(p => p.Y);
            double yMax = ListaDatos.Max(p => p.Y);

            double volumen = GaussLegendreRule.Integrate(
                x => GaussLegendreRule.Integrate(
                    y => ObtenerZ(x, y),   // Z(x,y)
                    yMin, yMax, 64),        // integral en Y
                xMin, xMax, 64);            // integral en X

            return Math.Abs(volumen);
        }

        private double ObtenerZ(double x, double y)
        {
            double sumaPesos = 0;
            double sumaZPeso = 0;

            foreach (var p in ListaDatos)
            {
                double distancia = Math.Sqrt(
                    Math.Pow(x - p.X, 2) +
                    Math.Pow(y - p.Y, 2));

                // Si coincide exactamente con un punto conocido
                if (distancia < 1e-10) return p.Z;

                double peso = 1.0 / (distancia * distancia);
                sumaPesos += peso;
                sumaZPeso += peso * p.Z;
            }

            return sumaZPeso / sumaPesos;
        }
    }

}
