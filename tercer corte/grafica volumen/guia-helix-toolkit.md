# Guía de instalación y configuración — Helix Toolkit WPF
### Gráficas 3D en Windows Forms con .NET Framework

---

## Requisitos previos

| Requisito | Versión |
|---|---|
| Visual Studio | 2019 o superior |
| .NET Framework | 4.7.2 o superior |
| Tipo de proyecto | Windows Forms App (.NET Framework) |

---

## Paso 1 — Crear el proyecto

1. Abrir Visual Studio
2. **Crear un nuevo proyecto**
3. Seleccionar **Aplicación de Windows Forms (.NET Framework)**
4. Asignar un nombre al proyecto (ejemplo: `Graficas3D`)
5. Seleccionar **.NET Framework 4.7.2** como versión de destino
6. Clic en **Crear**

---

## Paso 2 — Instalar Helix Toolkit desde NuGet

### Opción A — Consola del administrador de paquetes (recomendada)

Ir a **Herramientas → Administrador de paquetes NuGet → Consola del administrador de paquetes** y ejecutar los siguientes comandos en orden:

```powershell
Install-Package HelixToolkit -Version 2.13.0
Install-Package HelixToolkit.Wpf -Version 2.13.0
```

> ⚠️ **Importante:** usar siempre la versión **2.13.0**. Las versiones 3.x no son compatibles con .NET Framework.

### Opción B — Interfaz gráfica de NuGet

1. Clic derecho sobre el proyecto en el **Explorador de soluciones**
2. Seleccionar **Administrar paquetes NuGet...**
3. Ir a la pestaña **Examinar**
4. Buscar `HelixToolkit.Wpf`
5. En el panel derecho, desplegar el menú **Versión** y seleccionar `2.13.0`
6. Clic en **Instalar**

---

## Paso 3 — Agregar referencias de WPF manualmente

Helix Toolkit usa WPF internamente, por lo que se deben agregar las referencias de ensamblado manualmente:

1. Clic derecho sobre **Referencias** en el Explorador de soluciones
2. Seleccionar **Agregar referencia...**
3. Ir a **Ensamblados → Framework**
4. Marcar los siguientes ensamblados:

```
✅ PresentationCore
✅ PresentationFramework
✅ WindowsBase
✅ WindowsFormsIntegration
```

5. Clic en **Aceptar**

> ⚠️ Si `WindowsFormsIntegration` no aparece en la lista, buscarlo manualmente en la pestaña **Examinar** en la ruta:
> `C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.7.2\`

---

## Paso 4 — Verificar la instalación

Abrir `Form1.cs` y escribir los siguientes `using`. Si no aparecen errores rojos, la instalación fue exitosa:

```csharp
using HelixToolkit.Wpf;
using System.Windows.Forms.Integration;
using System.Windows.Media;
using System.Windows.Media.Media3D;
```

---

## Paso 5 — Configurar el formulario

### 5.1 Diseño visual en el diseñador

Agregar los siguientes controles desde el **Cuadro de herramientas**:

| Control | Nombre | Propiedad |
|---|---|---|
| `SplitContainer` | (por defecto) | `Dock = Fill` |
| `ElementHost` | `elementHost1` | `Dock = Fill` (dentro del Panel2) |
| `TrackBar` | `trackResolucion` | Min=20, Max=100, Value=40 |
| `TrackBar` | `trackEscalaZ` | Min=1, Max=10, Value=4 |
| `Label` | `lblResolucion` | Text = `"Resolución: 40"` |
| `Label` | `lblEscalaZ` | Text = `"Escala Z: 4"` |
| `Button` | `btnReset` | Text = `"Reset Cámara"` |

> 💡 El `ElementHost` es el puente entre WinForms y WPF. Se encuentra en el Cuadro de herramientas. Si no aparece, hacer clic derecho en el cuadro de herramientas → **Elegir elementos** → buscar `ElementHost`.

### 5.2 Estructura recomendada del formulario

```
Form1
└── SplitContainer (Dock = Fill)
    ├── Panel1 (controles, ancho ~200px)
    │   ├── Label "Resolución"
    │   ├── TrackBar (trackResolucion)
    │   ├── Label "Escala Z"
    │   ├── TrackBar (trackEscalaZ)
    │   ├── Label (lblResolucion)
    │   ├── Label (lblEscalaZ)
    │   └── Button (btnReset)
    └── Panel2 (gráfica)
        └── ElementHost (elementHost1, Dock = Fill)
```

---

## Paso 6 — Código base del formulario

Reemplazar el contenido de `Form1.cs` con el siguiente código:

```csharp
using System;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using HelixToolkit.Wpf;

namespace Graficas3D
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
                Background           = Brushes.DarkSlateGray,
                ShowCoordinateSystem = false,
                ShowViewCube         = true
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
                Position          = new Point3D(0, -25, 20),
                LookDirection     = new Vector3D(0, 25, -20),
                UpDirection       = new Vector3D(0, 0, 1),
                FieldOfView       = 50,
                NearPlaneDistance = 0.1,
                FarPlaneDistance  = 1000
            };
        }

        private void ActualizarTerreno()
        {
            if (_terreno != null && _viewport.Children.Contains(_terreno))
                _viewport.Children.Remove(_terreno);

            int    res     = trackResolucion.Value;
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
                    double x0 = i * paso - 10,       x1 = (i + 1) * paso - 10;
                    double y0 = j * paso - 10,       y1 = (j + 1) * paso - 10;
                    double z00 = ((h[i,   j  ] - minH) / (maxH - minH)) * escalaZ;
                    double z10 = ((h[i+1, j  ] - minH) / (maxH - minH)) * escalaZ;
                    double z11 = ((h[i+1, j+1] - minH) / (maxH - minH)) * escalaZ;
                    double z01 = ((h[i,   j+1] - minH) / (maxH - minH)) * escalaZ;

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
```

---

## Interacción con la gráfica

Una vez ejecutada la aplicación, se puede interactuar con el terreno 3D usando el mouse:

| Acción | Resultado |
|---|---|
| Clic izquierdo + arrastrar | Rotar el terreno |
| Rueda del mouse | Zoom acercar / alejar |
| Clic derecho + arrastrar | Mover la vista (pan) |
| Botón **Reset Cámara** | Volver a la vista inicial |

---

## Errores comunes

### ❌ `No se pudo instalar el paquete HelixToolkit.Wpf 3.x`
**Causa:** NuGet intenta instalar la versión más reciente que no es compatible con .NET Framework.  
**Solución:** Especificar explícitamente la versión `2.13.0` al instalar.

---

### ❌ `using System.Windows.Forms.Integration` en rojo
**Causa:** Falta la referencia `WindowsFormsIntegration`.  
**Solución:** Agregar la referencia manualmente como se indica en el Paso 3.

---

### ❌ La gráfica aparece en negro
**Causa:** El viewport no tiene una fuente de luz configurada.  
**Solución:** Asegurarse de agregar `new SunLight()` a los hijos del viewport antes de cargar el terreno.

---

### ❌ Los controles no responden
**Causa:** Los eventos `ValueChanged` o `Click` no están conectados.  
**Solución:** Conectar los eventos en el constructor del formulario o hacer doble clic en el control desde el diseñador.

---

## Referencias

- [Repositorio oficial de Helix Toolkit](https://github.com/helix-toolkit/helix-toolkit)
- [NuGet — HelixToolkit.Wpf](https://www.nuget.org/packages/HelixToolkit.Wpf/2.13.0)
- [Documentación de WPF 3D](https://learn.microsoft.com/es-es/dotnet/desktop/wpf/graphics-multimedia/3-d-graphics-overview)
