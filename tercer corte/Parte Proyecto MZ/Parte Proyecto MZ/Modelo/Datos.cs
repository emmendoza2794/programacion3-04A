using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parte_Proyecto_MZ.Modelo
{
    internal class Datos
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Datos(double x, double y, double z) 
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}
