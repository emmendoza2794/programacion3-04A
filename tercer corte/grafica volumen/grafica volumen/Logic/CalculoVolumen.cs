using System;

namespace grafica_volumen.Logic
{
    public enum MetodoCalculo
    {
        Cuadricula = 0,   // Suma de Riemann (esquina superior-izquierda por celda)
        Prismas    = 1,   // Método de Prismas (promedio max-por-esquina)
        Trapecio   = 2    // Regla del Trapecio 2D (pesos ¼ / ½ / 1 por nodo)
    }

    public static class CalculoVolumen
    {
        // alturas : matriz [filas, cols] de elevaciones del terreno
        // h       : altura del plano de corte (nivel de referencia)
        // dx, dy  : separación entre nodos en X e Y (mismas unidades que alturas)
        // metodo  : algoritmo de integración a usar
        public static double Calcular(double[,] alturas, double h, double dx, double dy,
                                      MetodoCalculo metodo)
        {
            switch (metodo)
            {
                case MetodoCalculo.Cuadricula: return Cuadricula(alturas, h, dx, dy);
                case MetodoCalculo.Prismas:    return Prismas(alturas, h, dx, dy);
                case MetodoCalculo.Trapecio:   return Trapecio(alturas, h, dx, dy);
                default: throw new ArgumentException("Método no reconocido.");
            }
        }

        // Método de Cuadrícula — Suma de Riemann (esquina superior-izquierda)
        // Para cada una de las (m-1)×(n-1) celdas reales, se usa el valor del nodo
        // superior-izquierdo z[i,j] como representante de toda la celda.
        // V = Σ_{celdas} max(z[i,j] − h, 0) × dx × dy
        private static double Cuadricula(double[,] z, double h, double dx, double dy)
        {
            int filas = z.GetLength(0), cols = z.GetLength(1);
            double v = 0;
            for (int i = 0; i < filas - 1; i++)
                for (int j = 0; j < cols - 1; j++)
                {
                    double d = z[i, j] - h;
                    if (d > 0) v += d * dx * dy;
                }
            return v;
        }

        // Método de Prismas
        // Aplica el corte max(z−h, 0) a cada esquina individualmente y promedia las 4.
        // V_celda = (max(d00,0) + max(d10,0) + max(d01,0) + max(d11,0)) / 4 × dx × dy
        // Nota: matemáticamente idéntico a la Regla del Trapecio 2D.
        private static double Prismas(double[,] z, double h, double dx, double dy)
        {
            int filas = z.GetLength(0), cols = z.GetLength(1);
            double v = 0;
            for (int i = 0; i < filas - 1; i++)
                for (int j = 0; j < cols - 1; j++)
                {
                    double d00 = Math.Max(z[i,     j    ] - h, 0);
                    double d10 = Math.Max(z[i,     j + 1] - h, 0);
                    double d01 = Math.Max(z[i + 1, j    ] - h, 0);
                    double d11 = Math.Max(z[i + 1, j + 1] - h, 0);
                    v += (d00 + d10 + d01 + d11) / 4.0 * dx * dy;
                }
            return v;
        }

        // Regla del Trapecio 2D (pesos por posición del nodo)
        // Pondera cada nodo según cuántas celdas comparte:
        //   esquinas (1 celda)  → w = 1/4
        //   bordes   (2 celdas) → w = 1/2
        //   interior (4 celdas) → w = 1
        // V = Σ_nodos w[i,j] × max(z[i,j] − h, 0) × dx × dy
        private static double Trapecio(double[,] z, double h, double dx, double dy)
        {
            int filas = z.GetLength(0), cols = z.GetLength(1);
            double v = 0;
            for (int i = 0; i < filas; i++)
                for (int j = 0; j < cols; j++)
                {
                    double d = z[i, j] - h;
                    if (d <= 0) continue;
                    bool bI = i == 0 || i == filas - 1;
                    bool bJ = j == 0 || j == cols - 1;
                    double w = (bI && bJ) ? 0.25 : (bI || bJ) ? 0.50 : 1.0;
                    v += w * d * dx * dy;
                }
            return v;
        }
    }
}
