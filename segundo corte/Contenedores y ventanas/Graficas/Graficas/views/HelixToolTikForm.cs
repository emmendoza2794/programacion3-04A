using System;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using HelixToolkit.Wpf;

namespace Graficas
{
    public partial class HelixToolTikForm : Form
    {
        private HelixViewport3D _viewport;
        private ModelVisual3D _superficie;

        public HelixToolTikForm()
        {
            InitializeComponent();
            this.Text = "Superficie 3D — Helix Toolkit";

            // Llenar el ComboBox con las opciones
            cmbGrafica.Items.AddRange(new string[]
            {
                "Terreno con montaña",
                "Sinc 2D  —  sin(r)/r",
                "Ondas  —  sin(x)*cos(y)",
                "Campana gaussiana"
            });
            cmbGrafica.SelectedIndex = 0;

            trackResolucion.ValueChanged += (s, e) => {
                lblResolucion.Text = $"Resolución: {trackResolucion.Value}";
                ActualizarSuperficie();
            };
            trackEscalaZ.ValueChanged += (s, e) => {
                lblEscalaZ.Text = $"Escala Z: {trackEscalaZ.Value}";
                ActualizarSuperficie();
            };
            cmbGrafica.SelectedIndexChanged += (s, e) => ActualizarSuperficie();

            CargarGrafica();
        }

        private void CargarGrafica()
        {
            _viewport = new HelixViewport3D
            {
                Background = Brushes.White,
                ShowCoordinateSystem = true,
                ShowViewCube = true
            };

            _viewport.Children.Add(new SunLight());
            ResetCamara();
            ActualizarSuperficie();

            elementHost1.Child = _viewport;
        }

        private void ResetCamara()
        {
            _viewport.Camera = new PerspectiveCamera
            {
                Position = new Point3D(30, -40, 30),
                LookDirection = new Vector3D(-30, 40, -30),
                UpDirection = new Vector3D(0, 0, 1),
                FieldOfView = 45,
                NearPlaneDistance = 0.1,
                FarPlaneDistance = 1000
            };
        }

        private void ActualizarSuperficie()
        {
            if (_superficie != null && _viewport.Children.Contains(_superficie))
                _viewport.Children.Remove(_superficie);

            int res = trackResolucion.Value;
            double escalaZ = trackEscalaZ.Value;

            double[,] h = GenerarAltura(res, cmbGrafica.SelectedIndex);
            _superficie = ConstruirSuperficie(h, res, escalaZ);
            _viewport.Children.Add(_superficie);
        }

        // -------------------------------------------------------
        // Genera el heightmap según la función seleccionada
        // -------------------------------------------------------
        private double[,] GenerarAltura(int res, int funcion)
        {
            var h = new double[res, res];

            for (int i = 0; i < res; i++)
            {
                for (int j = 0; j < res; j++)
                {
                    double x, y, dx, dy;

                    switch (funcion)
                    {
                        case 0: // Terreno con montaña
                            x = (double)i / res;
                            y = (double)j / res;
                            h[i, j] = Math.Sin(x * Math.PI * 3)
                                     * Math.Cos(y * Math.PI * 3);
                            dx = x - 0.5; dy = y - 0.5;
                            h[i, j] += 2.5 * Math.Exp(-(dx * dx + dy * dy) * 10);
                            break;

                        case 1: // Sinc 2D
                            x = (i - res / 2.0) / (res / 8.0);
                            y = (j - res / 2.0) / (res / 8.0);
                            double r = Math.Sqrt(x * x + y * y) + 0.001;
                            h[i, j] = Math.Sin(r) / r;
                            break;

                        case 2: // Ondas
                            x = (i - res / 2.0) / (res / 10.0);
                            y = (j - res / 2.0) / (res / 10.0);
                            h[i, j] = Math.Sin(x) * Math.Cos(y);
                            break;

                        case 3: // Campana gaussiana
                            x = (i - res / 2.0) / (res / 6.0);
                            y = (j - res / 2.0) / (res / 6.0);
                            h[i, j] = Math.Exp(-(x * x + y * y) / 2.0);
                            break;
                    }
                }
            }

            return h;
        }

        // -------------------------------------------------------
        // Construye la malla 3D con colormap Jet por altura
        // -------------------------------------------------------
        private ModelVisual3D ConstruirSuperficie(double[,] h, int res, double escalaZ)
        {
            double minH = double.MaxValue, maxH = double.MinValue;
            for (int i = 0; i < res; i++)
                for (int j = 0; j < res; j++)
                {
                    if (h[i, j] < minH) minH = h[i, j];
                    if (h[i, j] > maxH) maxH = h[i, j];
                }

            double paso = 20.0 / res;
            var grupo = new Model3DGroup();

            for (int i = 0; i < res - 1; i++)
            {
                for (int j = 0; j < res - 1; j++)
                {
                    double t00 = (h[i, j] - minH) / (maxH - minH);
                    double t10 = (h[i + 1, j] - minH) / (maxH - minH);
                    double t11 = (h[i + 1, j + 1] - minH) / (maxH - minH);
                    double t01 = (h[i, j + 1] - minH) / (maxH - minH);

                    var p00 = new Point3D(i * paso - 10, j * paso - 10, t00 * escalaZ);
                    var p10 = new Point3D((i + 1) * paso - 10, j * paso - 10, t10 * escalaZ);
                    var p11 = new Point3D((i + 1) * paso - 10, (j + 1) * paso - 10, t11 * escalaZ);
                    var p01 = new Point3D(i * paso - 10, (j + 1) * paso - 10, t01 * escalaZ);

                    double tProm = (t00 + t10 + t11 + t01) / 4.0;
                    Color color = ColorJet(tProm);
                    var mat = new DiffuseMaterial(new SolidColorBrush(color));

                    AgregarTriangulo(grupo, p00, p10, p11, mat);
                    AgregarTriangulo(grupo, p00, p11, p01, mat);
                }
            }

            var visual = new ModelVisual3D();
            visual.Content = grupo;
            return visual;
        }

        // -------------------------------------------------------
        // Colormap Jet: azul → cian → verde → amarillo → rojo
        // -------------------------------------------------------
        private Color ColorJet(double t)
        {
            t = Math.Max(0, Math.Min(1, t));
            double r, g, b;

            if (t < 0.125) { r = 0; g = 0; b = 0.5 + t * 4; }
            else if (t < 0.375) { r = 0; g = (t - 0.125) * 4; b = 1; }
            else if (t < 0.625) { r = (t - 0.375) * 4; g = 1; b = 1 - (t - 0.375) * 4; }
            else if (t < 0.875) { r = 1; g = 1 - (t - 0.625) * 4; b = 0; }
            else { r = 1 - (t - 0.875) * 4; g = 0; b = 0; }

            return Color.FromRgb((byte)(r * 255), (byte)(g * 255), (byte)(b * 255));
        }

        private void AgregarTriangulo(Model3DGroup grupo,
                                       Point3D p1, Point3D p2, Point3D p3,
                                       DiffuseMaterial mat)
        {
            var mesh = new MeshGeometry3D();
            mesh.Positions.Add(p1);
            mesh.Positions.Add(p2);
            mesh.Positions.Add(p3);
            mesh.TriangleIndices.Add(0);
            mesh.TriangleIndices.Add(1);
            mesh.TriangleIndices.Add(2);

            var normal = Vector3D.CrossProduct(p2 - p1, p3 - p1);
            normal.Normalize();
            mesh.Normals.Add(normal);
            mesh.Normals.Add(normal);
            mesh.Normals.Add(normal);

            var model = new GeometryModel3D(mesh, mat) { BackMaterial = mat };
            grupo.Children.Add(model);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarSuperficie();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetCamara();
        }
    }
}