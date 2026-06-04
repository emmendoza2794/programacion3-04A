using System;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using HelixToolkit.Wpf;

namespace grafica_volumen
{
    public partial class Form3 : Form
    {
        private readonly double[,] _alturas;
        private double _h, _dx, _dy;
        private HelixViewport3D _vpOriginal;
        private HelixViewport3D _vpFinal;
        private double _zMin, _zMax;

        private const int SUB = 3;

        public Form3(double[,] alturas, double h, double dx, double dy)
        {
            _alturas = alturas;
            _h  = h;
            _dx = dx;
            _dy = dy;

            InitializeComponent();

            _vpOriginal = new HelixViewport3D
            {
                Background           = new LinearGradientBrush(
                    Color.FromRgb(15, 22, 40), Color.FromRgb(5, 8, 18), 90),
                ShowCoordinateSystem = true,
                ShowViewCube         = true
            };
            hostOriginal.Child = _vpOriginal;

            _vpFinal = new HelixViewport3D
            {
                Background           = new LinearGradientBrush(
                    Color.FromRgb(15, 22, 40), Color.FromRgb(5, 8, 18), 90),
                ShowCoordinateSystem = true,
                ShowViewCube         = true
            };
            hostFinal.Child = _vpFinal;

            int filas = _alturas.GetLength(0);
            int cols  = _alturas.GetLength(1);
            _zMin = double.MaxValue;
            _zMax = double.MinValue;
            for (int i = 0; i < filas; i++)
                for (int j = 0; j < cols; j++)
                {
                    if (_alturas[i, j] < _zMin) _zMin = _alturas[i, j];
                    if (_alturas[i, j] > _zMax) _zMax = _alturas[i, j];
                }

            AddLights(_vpOriginal);
            AddLights(_vpFinal);

            BuildSceneOriginal();
            BuildSceneFinal();

            ResetCameraOriginal();
            ResetCameraFinal();
        }

        private void btnResetOriginal_Click(object sender, EventArgs e) => ResetCameraOriginal();
        private void btnResetFinal_Click(object sender, EventArgs e)    => ResetCameraFinal();

        // ── Luces ────────────────────────────────────────────────────────────────

        private static void AddLights(HelixViewport3D vp)
        {
            vp.Children.Add(new SunLight());
            vp.Children.Add(new ModelVisual3D
            {
                Content = new AmbientLight(Color.FromRgb(60, 60, 65))
            });
            vp.Children.Add(new ModelVisual3D
            {
                Content = new DirectionalLight(
                    Color.FromRgb(70, 80, 110),
                    new Vector3D(-1, -0.5, -0.8))
            });
        }

        // ── TERRENO ORIGINAL ─────────────────────────────────────────────────────

        private void BuildSceneOriginal()
        {
            int    filas  = _alturas.GetLength(0);
            int    cols   = _alturas.GetLength(1);
            double xMax   = (cols  - 1) * _dx;
            double yMax   = (filas - 1) * _dy;
            double rangoZ = Math.Max(_zMax - _zMin, 0.001);
            double zBase  = _zMin - rangoZ * 0.12;
            double lift   = rangoZ * 0.008 + 0.02;
            double rSfera = Math.Min(_dx, _dy) * 0.07;
            double offLbl = Math.Min(_dx, _dy) * 0.65;
            double zLbl   = zBase - rangoZ * 0.04;

            // 1. Superficie con gradiente calor
            for (int i = 0; i < filas - 1; i++)
            for (int j = 0; j < cols  - 1; j++)
            {
                double x0  = j * _dx,      x1  = (j + 1) * _dx;
                double y0  = i * _dy,      y1  = (i + 1) * _dy;
                double z00 = _alturas[i,     j    ];
                double z10 = _alturas[i,     j + 1];
                double z11 = _alturas[i + 1, j + 1];
                double z01 = _alturas[i + 1, j    ];

                for (int si = 0; si < SUB; si++)
                for (int sj = 0; sj < SUB; sj++)
                {
                    double u0 = (double)sj       / SUB;
                    double u1 = (double)(sj + 1) / SUB;
                    double v0 = (double)si        / SUB;
                    double v1 = (double)(si + 1)  / SUB;

                    var p00 = BLineal(x0,y0,x1,y1, z00,z10,z01,z11, u0,v0);
                    var p10 = BLineal(x0,y0,x1,y1, z00,z10,z01,z11, u1,v0);
                    var p11 = BLineal(x0,y0,x1,y1, z00,z10,z01,z11, u1,v1);
                    var p01 = BLineal(x0,y0,x1,y1, z00,z10,z01,z11, u0,v1);

                    double zAvg = (p00.Z + p10.Z + p11.Z + p01.Z) / 4.0;
                    var    col  = ColorCalor(zAvg, _zMin, _zMax);
                    var    mb   = new MeshBuilder(false, false);
                    mb.AddTriangle(p00, p10, p11);
                    mb.AddTriangle(p00, p11, p01);
                    AddMesh(_vpOriginal, mb, new DiffuseMaterial(new SolidColorBrush(col)));
                }
            }

            // 2. Cuadrícula
            var pts = new Point3DCollection();
            for (int i = 0; i < filas; i++)
            for (int j = 0; j < cols - 1; j++)
            {
                pts.Add(new Point3D( j      * _dx, i * _dy, _alturas[i, j    ] + lift));
                pts.Add(new Point3D((j + 1) * _dx, i * _dy, _alturas[i, j + 1] + lift));
            }
            for (int j = 0; j < cols; j++)
            for (int i = 0; i < filas - 1; i++)
            {
                pts.Add(new Point3D(j * _dx, i       * _dy, _alturas[i,     j] + lift));
                pts.Add(new Point3D(j * _dx, (i + 1) * _dy, _alturas[i + 1, j] + lift));
            }
            _vpOriginal.Children.Add(new LinesVisual3D
            {
                Color = Color.FromArgb(120, 255, 255, 255), Thickness = 1.0, Points = pts
            });

            // 3. Esferas en nodos
            var mbS = new MeshBuilder(false, false);
            for (int i = 0; i < filas; i++)
            for (int j = 0; j < cols;  j++)
                mbS.AddSphere(new Point3D(j * _dx, i * _dy, _alturas[i, j]), rSfera, 8, 6);
            AddMesh(_vpOriginal, mbS, new DiffuseMaterial(new SolidColorBrush(Colors.White)));

            // 4. Paredes + base
            AddParedes(_vpOriginal, filas, cols, _alturas, zBase,
                new DiffuseMaterial(new SolidColorBrush(Color.FromRgb(80, 65, 45))));
            AddFlatRect(_vpOriginal, 0, 0, xMax, yMax, zBase,
                new DiffuseMaterial(new SolidColorBrush(Color.FromRgb(50, 40, 25))));

            // 5. Etiquetas ejes
            for (int j = 0; j < cols; j++)
                _vpOriginal.Children.Add(new BillboardTextVisual3D
                {
                    Text = $"X{j+1} ({j*_dx:F0}m)", Position = new Point3D(j*_dx, -offLbl, zLbl),
                    FontSize = 10,
                    Foreground = new SolidColorBrush(Color.FromRgb(255, 140, 140)),
                    Background = new SolidColorBrush(Color.FromArgb(110, 40, 0, 0))
                });
            for (int i = 0; i < filas; i++)
                _vpOriginal.Children.Add(new BillboardTextVisual3D
                {
                    Text = $"Y{i+1} ({i*_dy:F0}m)", Position = new Point3D(-offLbl, i*_dy, zLbl),
                    FontSize = 10,
                    Foreground = new SolidColorBrush(Color.FromRgb(130, 230, 130)),
                    Background = new SolidColorBrush(Color.FromArgb(110, 0, 40, 0))
                });

            // 6. Referencia de cota h
            _vpOriginal.Children.Add(new BillboardTextVisual3D
            {
                Text = $"  h = {_h:F1} m  ",
                Position = new Point3D(xMax + offLbl, yMax / 2.0, _h),
                FontSize = 12,
                Foreground = new SolidColorBrush(Color.FromRgb(255, 230, 50)),
                Background = new SolidColorBrush(Color.FromArgb(140, 50, 40, 0))
            });
            _vpOriginal.Children.Add(new LinesVisual3D
            {
                Color = Color.FromArgb(100, 240, 210, 40), Thickness = 1.5,
                Points = new Point3DCollection
                {
                    new Point3D(0,    0,    _h), new Point3D(xMax, 0,    _h),
                    new Point3D(xMax, 0,    _h), new Point3D(xMax, yMax, _h),
                    new Point3D(xMax, yMax, _h), new Point3D(0,    yMax, _h),
                    new Point3D(0,    yMax, _h), new Point3D(0,    0,    _h)
                }
            });
        }

        // ── TERRENO FINAL — hoyo de excavación con terreno extendido ─────────────

        private void BuildSceneFinal()
        {
            int    filas  = _alturas.GetLength(0);
            int    cols   = _alturas.GetLength(1);
            double xMax   = (cols  - 1) * _dx;
            double yMax   = (filas - 1) * _dy;
            double rangoZ = Math.Max(_zMax - _zMin, 0.001);
            double zBase  = _zMin - rangoZ * 0.30;
            double lift   = rangoZ * 0.008 + 0.02;
            double offLbl = Math.Min(_dx, _dy) * 0.65;

            double extX    = xMax * 0.6;
            double extY    = yMax * 0.6;
            double xMinExt = -extX;
            double xMaxExt =  xMax + extX;
            double yMinExt = -extY;
            double yMaxExt =  yMax + extY;

            var matGround = new DiffuseMaterial(new SolidColorBrush(Color.FromRgb(195, 75, 15)));
            var matWall   = new DiffuseMaterial(new SolidColorBrush(Color.FromRgb(105, 68, 28)));
            var matBase   = new DiffuseMaterial(new SolidColorBrush(Color.FromRgb(48, 32, 12)));

            // ── 1. Terreno circundante extendido a nivel h (4 paneles planos) ──
            AddFlatRect(_vpFinal, xMinExt, yMinExt, 0,       yMaxExt, _h, matGround);
            AddFlatRect(_vpFinal, xMax,    yMinExt, xMaxExt, yMaxExt, _h, matGround);
            AddFlatRect(_vpFinal, 0,       yMinExt, xMax,    0,       _h, matGround);
            AddFlatRect(_vpFinal, 0,       yMax,    xMax,    yMaxExt, _h, matGround);

            // ── 2. Piso del hoyo: SOLO celdas con al menos una esquina bajo h ──
            // Celdas con todas las esquinas >= h están excavadas = VACÍO (no se dibuja nada)
            for (int i = 0; i < filas - 1; i++)
            for (int j = 0; j < cols  - 1; j++)
            {
                double zo00 = _alturas[i,     j    ];
                double zo10 = _alturas[i,     j + 1];
                double zo11 = _alturas[i + 1, j + 1];
                double zo01 = _alturas[i + 1, j    ];

                // Si las 4 esquinas están sobre h → material removido, hoyo vacío
                if (zo00 >= _h && zo10 >= _h && zo11 >= _h && zo01 >= _h)
                    continue;

                double x0 = j * _dx, x1 = (j + 1) * _dx;
                double y0 = i * _dy, y1 = (i + 1) * _dy;

                // Usar alturas originales capadas a h para mostrar el piso real
                double zf00 = Math.Min(zo00, _h);
                double zf10 = Math.Min(zo10, _h);
                double zf11 = Math.Min(zo11, _h);
                double zf01 = Math.Min(zo01, _h);

                for (int si = 0; si < SUB; si++)
                for (int sj = 0; sj < SUB; sj++)
                {
                    double u0 = (double)sj       / SUB, u1 = (double)(sj + 1) / SUB;
                    double v0 = (double)si        / SUB, v1 = (double)(si + 1) / SUB;

                    var p00 = BLineal(x0,y0,x1,y1, zf00,zf10,zf01,zf11, u0,v0);
                    var p10 = BLineal(x0,y0,x1,y1, zf00,zf10,zf01,zf11, u1,v0);
                    var p11 = BLineal(x0,y0,x1,y1, zf00,zf10,zf01,zf11, u1,v1);
                    var p01 = BLineal(x0,y0,x1,y1, zf00,zf10,zf01,zf11, u0,v1);

                    double zAvg = BLinealZ(zf00, zf10, zf01, zf11, (u0+u1)/2, (v0+v1)/2);
                    var    col  = ColorHoyo(zAvg);

                    var mb = new MeshBuilder(false, false);
                    mb.AddTriangle(p00, p10, p11);
                    mb.AddTriangle(p00, p11, p01);
                    AddMesh(_vpFinal, mb, new DiffuseMaterial(new SolidColorBrush(col)));
                }
            }

            // ── 3. Líneas del terreno (perfil real capado a h) ──
            var pts = new Point3DCollection();
            for (int i = 0; i < filas; i++)
            for (int j = 0; j < cols - 1; j++)
            {
                double za = Math.Min(_alturas[i, j    ], _h);
                double zb = Math.Min(_alturas[i, j + 1], _h);
                pts.Add(new Point3D( j      * _dx, i * _dy, za + lift));
                pts.Add(new Point3D((j + 1) * _dx, i * _dy, zb + lift));
            }
            for (int j = 0; j < cols; j++)
            for (int i = 0; i < filas - 1; i++)
            {
                double za = Math.Min(_alturas[i,     j], _h);
                double zb = Math.Min(_alturas[i + 1, j], _h);
                pts.Add(new Point3D(j * _dx, i       * _dy, za + lift));
                pts.Add(new Point3D(j * _dx, (i + 1) * _dy, zb + lift));
            }
            _vpFinal.Children.Add(new LinesVisual3D
            {
                Color = Color.FromArgb(200, 255, 255, 255), Thickness = 1.3, Points = pts
            });

            // ── 4. Paredes interiores del corte (borde del grid, h → zBase) ──
            for (int j = 0; j < cols - 1; j++)
            {
                double x0 = j * _dx, x1 = (j + 1) * _dx;
                AddFlatWall(_vpFinal, x0, 0,    x1, 0,    _h, zBase, matWall);
                AddFlatWall(_vpFinal, x0, yMax, x1, yMax, _h, zBase, matWall);
            }
            for (int i = 0; i < filas - 1; i++)
            {
                double y0 = i * _dy, y1 = (i + 1) * _dy;
                AddFlatWall(_vpFinal, 0,    y0, 0,    y1, _h, zBase, matWall);
                AddFlatWall(_vpFinal, xMax, y0, xMax, y1, _h, zBase, matWall);
            }

            // ── 5. Paredes exteriores del terreno extendido ──
            AddFlatWall(_vpFinal, xMinExt, yMinExt, xMaxExt, yMinExt, _h, zBase, matWall);
            AddFlatWall(_vpFinal, xMinExt, yMaxExt, xMaxExt, yMaxExt, _h, zBase, matWall);
            AddFlatWall(_vpFinal, xMinExt, yMinExt, xMinExt, yMaxExt, _h, zBase, matWall);
            AddFlatWall(_vpFinal, xMaxExt, yMinExt, xMaxExt, yMaxExt, _h, zBase, matWall);

            // ── 6. Base extendida ──
            AddFlatRect(_vpFinal, xMinExt, yMinExt, xMaxExt, yMaxExt, zBase, matBase);

            // ── 7. Borde dorado (perímetro de la excavación a nivel h) ──
            _vpFinal.Children.Add(new LinesVisual3D
            {
                Color = Color.FromRgb(240, 210, 40), Thickness = 3.0,
                Points = new Point3DCollection
                {
                    new Point3D(0,    0,    _h), new Point3D(xMax, 0,    _h),
                    new Point3D(xMax, 0,    _h), new Point3D(xMax, yMax, _h),
                    new Point3D(xMax, yMax, _h), new Point3D(0,    yMax, _h),
                    new Point3D(0,    yMax, _h), new Point3D(0,    0,    _h)
                }
            });

            // ── 8. Etiquetas ──
            double zLbl = zBase - rangoZ * 0.04;
            for (int j = 0; j < cols; j++)
                _vpFinal.Children.Add(new BillboardTextVisual3D
                {
                    Text = $"X{j+1}", Position = new Point3D(j*_dx, -offLbl, zLbl),
                    FontSize = 10,
                    Foreground = new SolidColorBrush(Color.FromRgb(255, 140, 140)),
                    Background = new SolidColorBrush(Color.FromArgb(110, 40, 0, 0))
                });
            for (int i = 0; i < filas; i++)
                _vpFinal.Children.Add(new BillboardTextVisual3D
                {
                    Text = $"Y{i+1}", Position = new Point3D(-offLbl, i*_dy, zLbl),
                    FontSize = 10,
                    Foreground = new SolidColorBrush(Color.FromRgb(130, 230, 130)),
                    Background = new SolidColorBrush(Color.FromArgb(110, 0, 40, 0))
                });
            _vpFinal.Children.Add(new BillboardTextVisual3D
            {
                Text = $"  h = {_h:F1} m  ",
                Position = new Point3D(xMaxExt + offLbl, yMax / 2.0, _h),
                FontSize = 13,
                Foreground = new SolidColorBrush(Color.FromRgb(255, 230, 50)),
                Background = new SolidColorBrush(Color.FromArgb(150, 50, 40, 0))
            });
        }

        // ── Helpers ──────────────────────────────────────────────────────────────

        private static Point3D BLineal(
            double x0, double y0, double x1, double y1,
            double z00, double z10, double z01, double z11,
            double u, double v)
        {
            return new Point3D(
                x0 + u * (x1 - x0),
                y0 + v * (y1 - y0),
                (1 - u) * (1 - v) * z00
              +       u * (1 - v) * z10
              + (1 - u) *       v * z01
              +       u *       v * z11);
        }

        private static double BLinealZ(
            double z00, double z10, double z01, double z11,
            double u, double v)
        {
            return (1 - u) * (1 - v) * z00
                 +       u * (1 - v) * z10
                 + (1 - u) *       v * z01
                 +       u *       v * z11;
        }

        // Gradiente calor: azul → cian → verde → amarillo → rojo
        private static Color ColorCalor(double z, double zMin, double zMax)
        {
            double rango = zMax - zMin;
            if (rango < 0.001) return Color.FromRgb(150, 150, 150);
            double t = Math.Max(0, Math.Min(1, (z - zMin) / rango));

            if (t < 0.25)
            {
                double s = t / 0.25;
                return Color.FromRgb((byte)(0), (byte)(s * 200), (byte)(200 - s * 50));
            }
            else if (t < 0.50)
            {
                double s = (t - 0.25) / 0.25;
                return Color.FromRgb((byte)(0), (byte)(200 + s * 55), (byte)(150 - s * 150));
            }
            else if (t < 0.75)
            {
                double s = (t - 0.50) / 0.25;
                return Color.FromRgb((byte)(s * 255), (byte)(255), (byte)(0));
            }
            else
            {
                double s = (t - 0.75) / 0.25;
                return Color.FromRgb((byte)(255), (byte)(255 - s * 220), (byte)(0));
            }
        }

        // Color del hoyo: naranja a nivel h (suelo), azul profundo en el fondo
        private Color ColorHoyo(double zF)
        {
            const double eps = 0.001;
            if (zF >= _h - eps)
                // Al nivel h: mismo tono que el terreno extendido
                return Color.FromRgb(195, 75, 15);

            // Profundidad bajo h: naranja → azul oscuro
            double prof = Math.Max(0, Math.Min(1,
                (_h - zF) / Math.Max(eps, _h - _zMin)));
            return Color.FromRgb(
                (byte)(195 - prof * 170),  // 195 → 25
                (byte)(75  - prof * 50),   // 75  → 25
                (byte)(15  + prof * 215)); // 15  → 230
        }

        // Rectángulo plano a altura z fija
        private static void AddFlatRect(HelixViewport3D vp,
            double x0, double y0, double x1, double y1, double z, Material mat)
        {
            var mb = new MeshBuilder(false, false);
            mb.AddTriangle(new Point3D(x0, y0, z), new Point3D(x1, y0, z), new Point3D(x1, y1, z));
            mb.AddTriangle(new Point3D(x0, y0, z), new Point3D(x1, y1, z), new Point3D(x0, y1, z));
            AddMesh(vp, mb, mat);
        }

        // Pared plana vertical desde zTop hasta zBot entre dos puntos XY
        private static void AddFlatWall(HelixViewport3D vp,
            double x0, double y0, double x1, double y1,
            double zTop, double zBot, Material mat)
        {
            var mb = new MeshBuilder(false, false);
            mb.AddTriangle(new Point3D(x0, y0, zTop),
                           new Point3D(x1, y1, zTop),
                           new Point3D(x1, y1, zBot));
            mb.AddTriangle(new Point3D(x0, y0, zTop),
                           new Point3D(x1, y1, zBot),
                           new Point3D(x0, y0, zBot));
            AddMesh(vp, mb, mat);
        }

        private void AddParedes(HelixViewport3D vp, int filas, int cols,
            double[,] z, double zBase, Material mat)
        {
            for (int j = 0; j < cols - 1; j++)   // Norte
            {
                double x0 = j * _dx, x1 = (j + 1) * _dx;
                var mb = new MeshBuilder(false, false);
                mb.AddTriangle(new Point3D(x0, 0, z[0, j]),
                               new Point3D(x1, 0, z[0, j + 1]),
                               new Point3D(x1, 0, zBase));
                mb.AddTriangle(new Point3D(x0, 0, z[0, j]),
                               new Point3D(x1, 0, zBase),
                               new Point3D(x0, 0, zBase));
                AddMesh(vp, mb, mat);
            }
            for (int j = 0; j < cols - 1; j++)   // Sur
            {
                double x0 = j * _dx, x1 = (j + 1) * _dx, yS = (filas - 1) * _dy;
                var mb = new MeshBuilder(false, false);
                mb.AddTriangle(new Point3D(x0, yS, z[filas-1, j    ]),
                               new Point3D(x1, yS, zBase),
                               new Point3D(x1, yS, z[filas-1, j + 1]));
                mb.AddTriangle(new Point3D(x0, yS, z[filas-1, j]),
                               new Point3D(x0, yS, zBase),
                               new Point3D(x1, yS, zBase));
                AddMesh(vp, mb, mat);
            }
            for (int i = 0; i < filas - 1; i++)  // Oeste
            {
                double y0 = i * _dy, y1 = (i + 1) * _dy;
                var mb = new MeshBuilder(false, false);
                mb.AddTriangle(new Point3D(0, y0, z[i,     0]),
                               new Point3D(0, y0, zBase),
                               new Point3D(0, y1, zBase));
                mb.AddTriangle(new Point3D(0, y0, z[i,     0]),
                               new Point3D(0, y1, zBase),
                               new Point3D(0, y1, z[i + 1, 0]));
                AddMesh(vp, mb, mat);
            }
            for (int i = 0; i < filas - 1; i++)  // Este
            {
                double y0 = i * _dy, y1 = (i + 1) * _dy, xE = (cols - 1) * _dx;
                var mb = new MeshBuilder(false, false);
                mb.AddTriangle(new Point3D(xE, y0, z[i,     cols-1]),
                               new Point3D(xE, y1, zBase),
                               new Point3D(xE, y0, zBase));
                mb.AddTriangle(new Point3D(xE, y0, z[i,     cols-1]),
                               new Point3D(xE, y1, z[i + 1, cols-1]),
                               new Point3D(xE, y1, zBase));
                AddMesh(vp, mb, mat);
            }
        }

        private static void AddMesh(HelixViewport3D vp, MeshBuilder mb, Material mat)
        {
            var mesh = mb.ToMesh(true);
            if (mesh == null || mesh.Positions.Count == 0) return;
            vp.Children.Add(new ModelVisual3D
            {
                Content = new GeometryModel3D(mesh, mat) { BackMaterial = mat }
            });
        }

        private void ResetCameraOriginal()
        {
            int    filas   = _alturas.GetLength(0);
            int    cols    = _alturas.GetLength(1);
            double cx      = (cols  - 1) * _dx / 2.0;
            double cy      = (filas - 1) * _dy / 2.0;
            double zCenter = (_zMin + _zMax) / 2.0;
            double diag    = Math.Sqrt(
                Math.Pow((cols  - 1) * _dx, 2) +
                Math.Pow((filas - 1) * _dy, 2));
            double dist = diag * 1.5 + 10;

            _vpOriginal.Camera = new PerspectiveCamera
            {
                Position          = new Point3D(cx - dist * 0.2, cy - dist * 0.85, zCenter + dist * 0.65),
                LookDirection     = new Vector3D(dist * 0.2, dist * 0.85, -(dist * 0.65 - (_zMax - zCenter) * 0.4)),
                UpDirection       = new Vector3D(0, 0, 1),
                FieldOfView       = 48,
                NearPlaneDistance = 0.01,
                FarPlaneDistance  = 100000
            };
        }

        private void ResetCameraFinal()
        {
            int    filas   = _alturas.GetLength(0);
            int    cols    = _alturas.GetLength(1);
            double xMax    = (cols  - 1) * _dx;
            double yMax    = (filas - 1) * _dy;
            // Centrar en el área total incluyendo la extensión (60 %)
            double extX    = xMax * 0.6;
            double extY    = yMax * 0.6;
            double cx      = xMax / 2.0;
            double cy      = yMax / 2.0;
            double zCenter = (_zMin + _h) / 2.0;
            double diagExt = Math.Sqrt(
                Math.Pow(xMax + 2 * extX, 2) +
                Math.Pow(yMax + 2 * extY, 2));
            double dist = diagExt * 1.3 + 10;

            _vpFinal.Camera = new PerspectiveCamera
            {
                Position          = new Point3D(cx - dist * 0.2, cy - dist * 0.85, zCenter + dist * 0.70),
                LookDirection     = new Vector3D(dist * 0.2, dist * 0.85, -(dist * 0.70 - (_h - zCenter) * 0.4)),
                UpDirection       = new Vector3D(0, 0, 1),
                FieldOfView       = 52,
                NearPlaneDistance = 0.01,
                FarPlaneDistance  = 100000
            };
        }
    }
}
