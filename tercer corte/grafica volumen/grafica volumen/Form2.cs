using System;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using HelixToolkit.Wpf;

namespace grafica_volumen
{
    public partial class Form2 : Form
    {
        private readonly double[,] _alturas;
        private readonly double _h, _dx, _dy;
        private HelixViewport3D _viewport;
        private double _zMin, _zMax;

        public Form2(double[,] alturas, double h, double dx, double dy)
        {
            _alturas = alturas;
            _h = h;
            _dx = dx;
            _dy = dy;

            InitializeComponent();

            _viewport = new HelixViewport3D
            {
                Background = new LinearGradientBrush(
                    Color.FromRgb(30, 40, 60),
                    Color.FromRgb(10, 15, 25),
                    90),
                ShowCoordinateSystem = true,
                ShowViewCube = true
            };
            _viewport.Children.Add(new SunLight());
            _viewport.Children.Add(new ModelVisual3D
            {
                Content = new AmbientLight(Color.FromRgb(55, 55, 55))
            });
            host.Child = _viewport;

            BuildScene();
            ResetCamera();
        }

        private void btnReset_Click(object sender, EventArgs e) => ResetCamera();

        private void BuildScene()
        {
            int filas = _alturas.GetLength(0);
            int cols  = _alturas.GetLength(1);
            double xMax = (cols  - 1) * _dx;
            double yMax = (filas - 1) * _dy;

            double zMin = double.MaxValue, zMax = double.MinValue;
            for (int i = 0; i < filas; i++)
                for (int j = 0; j < cols; j++)
                {
                    if (_alturas[i, j] < zMin) zMin = _alturas[i, j];
                    if (_alturas[i, j] > zMax) zMax = _alturas[i, j];
                }
            _zMin = zMin;
            _zMax = zMax;
            double zBase = zMin - Math.Max(_dx, _dy) * 0.4;

            // 1. Superficie del terreno — un quad por celda con color según altura
            for (int i = 0; i < filas - 1; i++)
            {
                for (int j = 0; j < cols - 1; j++)
                {
                    double x0 = j * _dx,      x1 = (j + 1) * _dx;
                    double y0 = i * _dy,      y1 = (i + 1) * _dy;
                    double z00 = _alturas[i,     j    ];
                    double z10 = _alturas[i,     j + 1];
                    double z11 = _alturas[i + 1, j + 1];
                    double z01 = _alturas[i + 1, j    ];

                    var color = AlturaAColor((z00 + z10 + z11 + z01) / 4.0, zMin, zMax);
                    var mb = new MeshBuilder(false, false);
                    mb.AddTriangle(new Point3D(x0, y0, z00), new Point3D(x1, y0, z10), new Point3D(x1, y1, z11));
                    mb.AddTriangle(new Point3D(x0, y0, z00), new Point3D(x1, y1, z11), new Point3D(x0, y1, z01));
                    AddMesh(mb, new DiffuseMaterial(new SolidColorBrush(color)));
                }
            }

            // 2. Líneas de cuadrícula sobre el terreno
            var pts = new Point3DCollection();
            const double lift = 0.03;
            for (int i = 0; i < filas; i++)
                for (int j = 0; j < cols - 1; j++)
                {
                    pts.Add(new Point3D(j * _dx,       i * _dy, _alturas[i, j]     + lift));
                    pts.Add(new Point3D((j+1) * _dx,   i * _dy, _alturas[i, j + 1] + lift));
                }
            for (int j = 0; j < cols; j++)
                for (int i = 0; i < filas - 1; i++)
                {
                    pts.Add(new Point3D(j * _dx, i * _dy,       _alturas[i,     j] + lift));
                    pts.Add(new Point3D(j * _dx, (i+1) * _dy,   _alturas[i + 1, j] + lift));
                }
            _viewport.Children.Add(new LinesVisual3D
            {
                Color     = Colors.Black,
                Thickness = 1.2,
                Points    = pts
            });

            // 3. Paredes laterales
            var matPared = new DiffuseMaterial(new SolidColorBrush(Color.FromRgb(100, 80, 55)));

            // Norte (i=0)
            for (int j = 0; j < cols - 1; j++)
            {
                double x0 = j * _dx, x1 = (j+1) * _dx;
                var mb = new MeshBuilder(false, false);
                mb.AddTriangle(new Point3D(x0, 0, _alturas[0, j]),     new Point3D(x1, 0, _alturas[0, j+1]), new Point3D(x1, 0, zBase));
                mb.AddTriangle(new Point3D(x0, 0, _alturas[0, j]),     new Point3D(x1, 0, zBase),            new Point3D(x0, 0, zBase));
                AddMesh(mb, matPared);
            }
            // Sur (i=filas-1)
            for (int j = 0; j < cols - 1; j++)
            {
                double x0 = j * _dx, x1 = (j+1) * _dx, yS = (filas-1) * _dy;
                var mb = new MeshBuilder(false, false);
                mb.AddTriangle(new Point3D(x0, yS, _alturas[filas-1, j]),     new Point3D(x1, yS, zBase),                       new Point3D(x1, yS, _alturas[filas-1, j+1]));
                mb.AddTriangle(new Point3D(x0, yS, _alturas[filas-1, j]),     new Point3D(x0, yS, zBase),                       new Point3D(x1, yS, zBase));
                AddMesh(mb, matPared);
            }
            // Oeste (j=0)
            for (int i = 0; i < filas - 1; i++)
            {
                double y0 = i * _dy, y1 = (i+1) * _dy;
                var mb = new MeshBuilder(false, false);
                mb.AddTriangle(new Point3D(0, y0, _alturas[i, 0]),     new Point3D(0, y0, zBase),              new Point3D(0, y1, zBase));
                mb.AddTriangle(new Point3D(0, y0, _alturas[i, 0]),     new Point3D(0, y1, zBase),              new Point3D(0, y1, _alturas[i+1, 0]));
                AddMesh(mb, matPared);
            }
            // Este (j=cols-1)
            for (int i = 0; i < filas - 1; i++)
            {
                double y0 = i * _dy, y1 = (i+1) * _dy, xE = (cols-1) * _dx;
                var mb = new MeshBuilder(false, false);
                mb.AddTriangle(new Point3D(xE, y0, _alturas[i, cols-1]),     new Point3D(xE, y1, zBase),                     new Point3D(xE, y0, zBase));
                mb.AddTriangle(new Point3D(xE, y0, _alturas[i, cols-1]),     new Point3D(xE, y1, _alturas[i+1, cols-1]),     new Point3D(xE, y1, zBase));
                AddMesh(mb, matPared);
            }

            // 4. Base
            var meshBase = new MeshBuilder(false, false);
            meshBase.AddTriangle(new Point3D(0, 0, zBase),    new Point3D(xMax, yMax, zBase), new Point3D(xMax, 0,    zBase));
            meshBase.AddTriangle(new Point3D(0, 0, zBase),    new Point3D(0,    yMax, zBase), new Point3D(xMax, yMax, zBase));
            AddMesh(meshBase, new DiffuseMaterial(new SolidColorBrush(Color.FromRgb(55, 45, 30))));

            // 5. Plano de corte semitransparente (ambas caras)
            var meshPlano = new MeshBuilder(false, false);
            meshPlano.AddTriangle(new Point3D(0,    0,    _h), new Point3D(xMax, 0,    _h), new Point3D(xMax, yMax, _h));
            meshPlano.AddTriangle(new Point3D(0,    0,    _h), new Point3D(xMax, yMax, _h), new Point3D(0,    yMax, _h));
            meshPlano.AddTriangle(new Point3D(0,    0,    _h), new Point3D(xMax, yMax, _h), new Point3D(xMax, 0,    _h));
            meshPlano.AddTriangle(new Point3D(0,    0,    _h), new Point3D(0,    yMax, _h), new Point3D(xMax, yMax, _h));
            AddMesh(meshPlano, new DiffuseMaterial(new SolidColorBrush(Color.FromArgb(110, 240, 220, 80))));

            // 6. Borde del plano de corte (líneas)
            var borde = new Point3DCollection
            {
                new Point3D(0,    0,    _h), new Point3D(xMax, 0,    _h),
                new Point3D(xMax, 0,    _h), new Point3D(xMax, yMax, _h),
                new Point3D(xMax, yMax, _h), new Point3D(0,    yMax, _h),
                new Point3D(0,    yMax, _h), new Point3D(0,    0,    _h)
            };
            _viewport.Children.Add(new LinesVisual3D
            {
                Color     = Color.FromRgb(200, 180, 50),
                Thickness = 2,
                Points    = borde
            });
        }

        // Gradiente: verde oscuro → verde claro (bajo h) | naranja → rojo oscuro (sobre h)
        private Color AlturaAColor(double z, double zMin, double zMax)
        {
            double rango = zMax - zMin;
            if (rango < 0.001)
                return Color.FromRgb(150, 150, 150);

            double t  = Math.Max(0, Math.Min(1, (z  - zMin) / rango));
            double tH = Math.Max(0, Math.Min(1, (_h - zMin) / rango));

            if (t <= tH)
            {
                // Bajo h: verde oscuro (30,100,40) → verde claro (90,170,60)
                double s = tH > 0 ? t / tH : 1.0;
                return Color.FromRgb(
                    (byte)(30  + s * 60),
                    (byte)(100 + s * 70),
                    (byte)(40  + s * 20));
            }
            else
            {
                // Sobre h: naranja (230,120,0) → rojo oscuro (180,20,10)
                double s = tH < 1 ? (t - tH) / (1 - tH) : 1.0;
                return Color.FromRgb(
                    (byte)(230 - s * 50),
                    (byte)(120 - s * 100),
                    (byte)(s   * 10));
            }
        }

        private void AddMesh(MeshBuilder mb, Material mat)
        {
            var mesh = mb.ToMesh(true);
            if (mesh == null || mesh.Positions.Count == 0) return;
            var geo = new GeometryModel3D(mesh, mat) { BackMaterial = mat };
            _viewport.Children.Add(new ModelVisual3D { Content = geo });
        }

        private void ResetCamera()
        {
            int filas = _alturas.GetLength(0);
            int cols  = _alturas.GetLength(1);
            double cx      = (cols  - 1) * _dx / 2.0;
            double cy      = (filas - 1) * _dy / 2.0;
            double zCenter = (_zMin + _zMax) / 2.0;
            double dist    = Math.Max((cols - 1) * _dx, (filas - 1) * _dy) * 2.0 + 10;

            _viewport.Camera = new PerspectiveCamera
            {
                Position          = new Point3D(cx, cy - dist * 0.8, zCenter + dist * 0.7),
                LookDirection     = new Vector3D(0, dist * 0.8, -dist * 0.7),
                UpDirection       = new Vector3D(0, 0, 1),
                FieldOfView       = 50,
                NearPlaneDistance = 0.01,
                FarPlaneDistance  = 100000
            };
        }
    }
}
