using System;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using HelixToolkit.Wpf;

namespace graficas_2
{
    public partial class Form1 : Form
    {
        private HelixViewport3D _viewport;
        private ModelVisual3D _terreno;

        public Form1()
        {
            InitializeComponent();
            this.Text = "Terreno 3D";

            // Conectar eventos de los trackbars
            trackResolucion.ValueChanged += (s, e) => {
                lblResolucion.Text = $"Resolución: {trackResolucion.Value}";
                ActualizarTerreno();
            };
            trackEscalaZ.ValueChanged += (s, e) => {
                lblEscalaZ.Text = $"Escala Z: {trackEscalaZ.Value}";
                ActualizarTerreno();
            };

            CargarGrafica();
        }

        private void CargarGrafica()
        {
            _viewport = new HelixViewport3D
            {
                Background = Brushes.DarkSlateGray,
                ShowCoordinateSystem = false,
                ShowViewCube = true
            };

            _viewport.Children.Add(new SunLight());

            ResetCamara();
            ActualizarTerreno();

            elementHost1.Child = _viewport;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetCamara();
        }

        private void ResetCamara()
        {
            _viewport.Camera = new PerspectiveCamera
            {
                Position = new Point3D(0, -25, 20),
                LookDirection = new Vector3D(0, 25, -20),
                UpDirection = new Vector3D(0, 0, 1),
                FieldOfView = 50,
                NearPlaneDistance = 0.1,
                FarPlaneDistance = 1000
            };
        }

        private void ActualizarTerreno()
        {
            if (_terreno != null && _viewport.Children.Contains(_terreno))
                _viewport.Children.Remove(_terreno);

            int res = trackResolucion.Value;
            double escalaZ = trackEscalaZ.Value;

            _terreno = ConstruirTerreno(res, escalaZ);
            _viewport.Children.Add(_terreno);
        }

        private ModelVisual3D ConstruirTerreno(int res, double escalaZ)
        {
            var h = new double[res, res];

            for (int i = 0; i < res; i++)
                for (int j = 0; j < res; j++)
                {
                    double x = (double)i / res;
                    double y = (double)j / res;

                    h[i, j] = Math.Sin(x * Math.PI * 3) * Math.Cos(y * Math.PI * 3);

                    double dx = x - 0.5, dy = y - 0.5;
                    h[i, j] += 2.5 * Math.Exp(-(dx * dx + dy * dy) * 10);
                }

            double minH = double.MaxValue, maxH = double.MinValue;
            for (int i = 0; i < res; i++)
                for (int j = 0; j < res; j++)
                {
                    if (h[i, j] < minH) minH = h[i, j];
                    if (h[i, j] > maxH) maxH = h[i, j];
                }

            double paso = 20.0 / res;
            var mesh = new MeshBuilder(false, false);

            for (int i = 0; i < res - 1; i++)
            {
                for (int j = 0; j < res - 1; j++)
                {
                    double x0 = i * paso - 10, x1 = (i + 1) * paso - 10;
                    double y0 = j * paso - 10, y1 = (j + 1) * paso - 10;
                    double z00 = ((h[i, j] - minH) / (maxH - minH)) * escalaZ;
                    double z10 = ((h[i + 1, j] - minH) / (maxH - minH)) * escalaZ;
                    double z11 = ((h[i + 1, j + 1] - minH) / (maxH - minH)) * escalaZ;
                    double z01 = ((h[i, j + 1] - minH) / (maxH - minH)) * escalaZ;

                    mesh.AddTriangle(
                        new Point3D(x0, y0, z00),
                        new Point3D(x1, y0, z10),
                        new Point3D(x1, y1, z11));
                    mesh.AddTriangle(
                        new Point3D(x0, y0, z00),
                        new Point3D(x1, y1, z11),
                        new Point3D(x0, y1, z01));
                }
            }

            var material = new DiffuseMaterial(
                new SolidColorBrush(Color.FromRgb(80, 140, 60))
            );

            var geo = new GeometryModel3D(mesh.ToMesh(true), material);
            geo.BackMaterial = material;

            var visual = new ModelVisual3D();
            visual.Content = geo;
            return visual;
        }
    }
}
