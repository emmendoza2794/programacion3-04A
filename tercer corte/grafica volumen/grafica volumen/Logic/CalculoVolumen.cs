using System;

namespace grafica_volumen.Logic
{
    public enum MetodoCalculo
    {
        Cuadricula = 0,   // Suma de Riemann (esquina superior-izquierda por celda)
        Prismas    = 1,   // Método de Prismas (promedio max-por-esquina)
        Trapecio   = 2,   // Regla del Trapecio 2D (pesos ¼ / ½ / 1 por nodo)
        Simpson    = 3    // Regla de Simpson 2D (cuadratura compuesta orden 4)
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
                case MetodoCalculo.Simpson:    return Simpson(alturas, h, dx, dy);
                default: throw new ArgumentException("Método no reconocido.");
            }
        }

        // =====================================================================
        // MÉTODO DE CUADRÍCULA — Suma de Riemann
        // =====================================================================
        // IDEA MATEMÁTICA
        //   El volumen real del sólido sobre el plano h es la integral doble:
        //
        //     V = ∬_R  max( z(x,y) − h, 0 )  dx dy
        //
        //   donde R es la región rectangular del terreno.
        //
        // CÓMO SE APROXIMA LA INTEGRAL
        //   Se divide R en (m−1)×(n−1) rectángulos de área dx·dy.
        //   En cada rectángulo se evalúa la función z en UN solo punto:
        //   la esquina superior-izquierda z[i,j].
        //   La integral sobre ese rectángulo se aproxima como:
        //
        //     ∬_{celda} f dx dy  ≈  f(x_i, y_j) · dx · dy
        //
        //   Esto es la definición clásica de la Suma de Riemann:
        //   reemplazar el área bajo la curva por un rectángulo de altura fija.
        //
        // DÓNDE OCURRE LA INTEGRAL EN EL CÓDIGO
        //   - El doble for (i, j) recorre todas las celdas → representa Σ_{i,j}
        //     que en el límite (dx,dy→0) converge a la integral doble ∬.
        //   - La línea  v += d * dx * dy  es el término de cada rectángulo:
        //     altura d = z[i,j]−h  ×  ancho dx  ×  profundidad dy.
        //   - Al sumar todos los rectángulos se obtiene la aproximación de ∬.
        //
        // ERROR
        //   El error es O(dx) + O(dy): converge lento porque usa un solo punto
        //   por celda y no captura la variación de z dentro de ella.
        // =====================================================================
        private static double Cuadricula(double[,] z, double h, double dx, double dy)
        {
            int filas = z.GetLength(0), cols = z.GetLength(1);
            double v = 0;

            for (int i = 0; i < filas - 1; i++)
                for (int j = 0; j < cols - 1; j++)
                {
                    double d = z[i, j] - h;

                    // INTEGRAL: aporte del rectángulo (i,j) a la suma de Riemann.
                    // Aproxima  ∬_{celda} max(z−h, 0) dx dy  ≈  max(d, 0) · dx · dy
                    if (d > 0) v += d * dx * dy;
                }

            // v contiene la suma de Riemann completa ≈ ∬_R max(z−h,0) dx dy
            return v;
        }

        // =====================================================================
        // MÉTODO DE PRISMAS
        // =====================================================================
        // IDEA MATEMÁTICA
        //   Igual que Cuadrícula, se busca aproximar:
        //
        //     V = ∬_R  max( z(x,y) − h, 0 )  dx dy
        //
        // CÓMO SE APROXIMA LA INTEGRAL
        //   En vez de usar solo una esquina, se evalúa z en las CUATRO esquinas
        //   del rectángulo y se promedia. Esto equivale a suponer que z varía
        //   linealmente dentro de la celda (plano bilineal), y calcular el
        //   volumen del prisma que resulta de cortar ese plano con h.
        //
        //   La integral sobre una celda con esquinas d₀₀, d₁₀, d₀₁, d₁₁ es:
        //
        //     ∬_{celda} max(z−h,0) dx dy  ≈  (max(d₀₀,0) + max(d₁₀,0)
        //                                    + max(d₀₁,0) + max(d₁₁,0)) / 4 · dx·dy
        //
        //   El /4 es el promedio de los cuatro vértices — es exacto cuando z
        //   es bilineal sobre la celda.
        //
        // DÓNDE OCURRE LA INTEGRAL EN EL CÓDIGO
        //   - El doble for recorre las (m−1)×(n−1) celdas → es la Σ discreta
        //     que aproxima la integral doble ∬.
        //   - Las líneas d00..d11 calculan la contribución de cada esquina.
        //   - La línea  v += (d00+d10+d01+d11)/4 * dx*dy  es el término
        //     de integración por celda: promedio de alturas × área.
        //
        // EQUIVALENCIA
        //   Este método produce exactamente el mismo resultado que Trapecio 2D
        //   porque ambos asignan a cada nodo un peso proporcional al número
        //   de celdas que comparte (ver método Trapecio).
        // =====================================================================
        private static double Prismas(double[,] z, double h, double dx, double dy)
        {
            int filas = z.GetLength(0), cols = z.GetLength(1);
            double v = 0;

            for (int i = 0; i < filas - 1; i++)
                for (int j = 0; j < cols - 1; j++)
                {
                    // Altura sobre h en cada esquina de la celda (0 si está bajo h)
                    double d00 = Math.Max(z[i,     j    ] - h, 0);
                    double d10 = Math.Max(z[i,     j + 1] - h, 0);
                    double d01 = Math.Max(z[i + 1, j    ] - h, 0);
                    double d11 = Math.Max(z[i + 1, j + 1] - h, 0);

                    // INTEGRAL: promedio de las 4 esquinas × área de la celda.
                    // Aproxima  ∬_{celda} max(z−h,0) dx dy  suponiendo z bilineal.
                    // El promedio /4 es la cuadratura del trapecio aplicada en 2D.
                    v += (d00 + d10 + d01 + d11) / 4.0 * dx * dy;
                }

            // v ≈ ∬_R max(z−h,0) dx dy  con la aproximación bilineal por celda
            return v;
        }

        // =====================================================================
        // REGLA DEL TRAPECIO 2D
        // =====================================================================
        // IDEA MATEMÁTICA
        //   Sigue buscando:  V = ∬_R max(z(x,y) − h, 0) dx dy
        //
        //   La Regla del Trapecio 1D aproxima ∫f dx ≈ (f₀+f₁)/2 · h.
        //   Aplicada en 2 dimensiones de forma compuesta, cada nodo recibe
        //   un peso w según cuántas celdas comparte:
        //
        //     Esquina  (comparte 1 celda)  → w = 1/4
        //     Borde    (comparte 2 celdas) → w = 1/2
        //     Interior (comparte 4 celdas) → w = 1
        //
        //   La integral completa queda:
        //
        //     V ≈ Σ_{i,j}  w(i,j) · max(z[i,j]−h, 0) · dx · dy
        //
        //   Esto es equivalente a aplicar la regla del trapecio 1D primero en
        //   la dirección X y luego en la dirección Y (o viceversa).
        //
        // DÓNDE OCURRE LA INTEGRAL EN EL CÓDIGO
        //   - El doble for recorre TODOS los nodos (no solo las celdas),
        //     que es la forma en que la regla del trapecio 2D opera globalmente.
        //   - La línea  bool bI / bJ  determina si el nodo está en borde o interior,
        //     lo que define su peso w: esto es la ponderación de la cuadratura.
        //   - La línea  double w = ...  asigna 0.25 / 0.50 / 1.0
        //     según la posición → son los COEFICIENTES DE INTEGRACIÓN.
        //   - La línea  v += w * d * dx * dy  acumula la contribución ponderada
        //     de cada nodo a la integral doble ∬.
        //
        // ERROR
        //   O(dx²) + O(dy²): converge más rápido que Riemann porque cada nodo
        //   pondera el aporte de sus celdas vecinas en lugar de ignorarlas.
        // =====================================================================
        private static double Trapecio(double[,] z, double h, double dx, double dy)
        {
            int filas = z.GetLength(0), cols = z.GetLength(1);
            double v = 0;

            for (int i = 0; i < filas; i++)
                for (int j = 0; j < cols; j++)
                {
                    double d = z[i, j] - h;
                    if (d <= 0) continue;

                    // Detectar si el nodo está en borde o en el interior de la malla
                    bool bI = i == 0 || i == filas - 1;
                    bool bJ = j == 0 || j == cols - 1;

                    // COEFICIENTES DE INTEGRACIÓN de la Regla del Trapecio 2D.
                    // Provienen del producto tensorial de la regla 1D en X e Y:
                    //   w_i · w_j, donde w_extremo = 1/2 y w_interior = 1  (1D).
                    //   En 2D: esquina=(1/2)(1/2)=1/4, borde=(1/2)·1=1/2, interior=1·1=1.
                    double w = (bI && bJ) ? 0.25 : (bI || bJ) ? 0.50 : 1.0;

                    // INTEGRAL: aporte ponderado del nodo (i,j) a la integral doble.
                    // Cada término  w·d·dx·dy  es la cuota que este nodo aporta a
                    // la aproximación de  ∬_R max(z−h,0) dx dy.
                    v += w * d * dx * dy;
                }

            // v ≈ ∬_R max(z−h,0) dx dy  por la Regla del Trapecio compuesta 2D
            return v;
        }

        // =====================================================================
        // REGLA DE SIMPSON COMPUESTA 2D
        // =====================================================================
        // IDEA MATEMÁTICA
        //   Mismo objetivo:  V = ∬_R max(z(x,y) − h, 0) dx dy
        //
        //   La Regla de Simpson 1D ajusta un polinomio de grado 2 (parábola)
        //   a cada tripleta de puntos consecutivos y calcula el área exacta
        //   bajo esa parábola. Para n+1 nodos equiespaciados (n par):
        //
        //     ∫f dx  ≈  (dx/3) · [f₀ + 4f₁ + 2f₂ + 4f₃ + ... + 4f_{n-1} + f_n]
        //
        //   Aplicada en 2D de forma compuesta (primero en X, luego en Y):
        //
        //     V ≈ (dx/3)·(dy/3) · Σᵢ Σⱼ wᵢ · wⱼ · max(z[i,j]−h, 0)
        //       = (dx·dy/9)     · Σᵢ Σⱼ wᵢ · wⱼ · max(z[i,j]−h, 0)
        //
        //   donde wₖ sigue el patrón:  1, 4, 2, 4, 2, ..., 4, 1
        //   (extremos=1, impares=4, pares interiores=2).
        //
        // DÓNDE OCURRE LA INTEGRAL EN EL CÓDIGO
        //   - El doble for (i, j) recorre todos los nodos activos →
        //     es la doble suma  Σᵢ Σⱼ  que aproxima ∬.
        //   - La llamada  SimpsonPeso(i, ni)  devuelve wᵢ: el COEFICIENTE DE
        //     CUADRATURA de Simpson para ese nodo en la dirección i.
        //     Es aquí donde se aplica la integración por parábolas.
        //   - La línea  v += wi * SimpsonPeso(j,nj) * d  acumula wᵢ·wⱼ·f(i,j),
        //     el término de la suma que aproxima la integral doble.
        //   - La línea  return v * dx * dy / 9.0  multiplica por el factor de
        //     escala (dx/3)·(dy/3): convierte la suma adimensional en volumen.
        //
        // POR QUÉ ES MÁS PRECISO QUE EL TRAPECIO
        //   El Trapecio interpola z con segmentos lineales dentro de cada celda
        //   → error O(h²).
        //   Simpson interpola con parábolas dentro de cada par de celdas
        //   → error O(h⁴): con la misma malla da un resultado mucho más cercano
        //   al valor exacto de la integral cuando z es suave.
        // =====================================================================
        private static double Simpson(double[,] z, double h, double dx, double dy)
        {
            int filas = z.GetLength(0), cols = z.GetLength(1);

            // Simpson requiere al menos 3 nodos en cada dirección
            if (filas < 3 || cols < 3)
                throw new ArgumentException(
                    "Simpson 2D requiere mínimo 3×3 nodos. Aumenta filas y columnas.");

            // Ajustar a número impar de nodos (número par de intervalos).
            // Simpson necesita poder agrupar puntos de 3 en 3 (dos intervalos por grupo).
            int ni = filas % 2 == 1 ? filas : filas - 1;
            int nj = cols  % 2 == 1 ? cols  : cols  - 1;

            double v = 0;

            for (int i = 0; i < ni; i++)
            {
                // COEFICIENTE DE INTEGRACIÓN en la dirección i (peso de Simpson 1D).
                // Viene de integrar la parábola que pasa por los puntos i-1, i, i+1.
                double wi = SimpsonPeso(i, ni);

                for (int j = 0; j < nj; j++)
                {
                    double d = z[i, j] - h;
                    if (d > 0)
                        // INTEGRAL: suma ponderada wᵢ·wⱼ·f(i,j).
                        // wᵢ·wⱼ es el coeficiente 2D de Simpson (producto tensorial).
                        // Cada término contribuye a aproximar ∬_R max(z−h,0) dx dy.
                        v += wi * SimpsonPeso(j, nj) * d;
                }
            }

            // FACTOR DE ESCALA de la cuadratura: (dx/3)·(dy/3) = dx·dy/9.
            // Convierte la suma adimensional en la integral doble con unidades de volumen.
            return v * dx * dy / 9.0;
        }

        // Devuelve el coeficiente de cuadratura de Simpson para el nodo k
        // dentro de una grilla de n nodos (n impar, n-1 intervalos par).
        // Patrón: extremos=1, posiciones impares=4, posiciones pares interiores=2.
        // Origen: integración exacta de la parábola de Lagrange en cada subintervalo.
        private static double SimpsonPeso(int k, int n)
        {
            if (k == 0 || k == n - 1) return 1.0;
            return k % 2 == 1 ? 4.0 : 2.0;
        }
    }
}
