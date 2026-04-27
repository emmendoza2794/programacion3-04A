# Guía de instalación y configuración — ScottPlot
### Gráficas 2D en Windows Forms con .NET Framework

---

## ¿Qué es ScottPlot?

ScottPlot es una librería gratuita y de código abierto para crear gráficas interactivas en aplicaciones .NET. Es ideal para visualizar datos científicos, señales, estadísticas y series de tiempo. A diferencia de Helix Toolkit, ScottPlot trabaja en 2D pero con mucha más variedad de tipos de gráficas y con un control nativo que se arrastra directamente al formulario.

---

## Requisitos previos

| Requisito | Versión |
|---|---|
| Visual Studio | 2019 o superior |
| .NET Framework | 4.7.2 o superior |
| Tipo de proyecto | Windows Forms App (.NET Framework) |

---

## Paso 1 — Instalar ScottPlot desde NuGet

### Opción A — Consola del administrador de paquetes (recomendada)

Ir a **Herramientas → Administrador de paquetes NuGet → Consola del administrador de paquetes** y ejecutar:

```powershell
Install-Package ScottPlot.WinForms -Version 4.1.71
```

> ⚠️ **Importante:** usar siempre la versión **4.1.71**. Las versiones 5.x tienen una API diferente y no son compatibles con .NET Framework 4.7.2.

### Opción B — Interfaz gráfica de NuGet

1. Clic derecho sobre el proyecto → **Administrar paquetes NuGet**
2. Pestaña **Examinar**
3. Buscar `ScottPlot.WinForms`
4. En el panel derecho seleccionar la versión `4.1.71`
5. Clic en **Instalar**

---

## Paso 2 — Verificar la instalación

Después de instalar, abrir `Form1.cs` y escribir:

```csharp
using ScottPlot;
```

Si no aparece error rojo, la instalación fue exitosa.

---

## Paso 3 — Agregar el control FormsPlot al formulario

Una ventaja de ScottPlot es que el control `FormsPlot` aparece automáticamente en el **Cuadro de herramientas** después de instalar el paquete.

1. Abrir el diseñador del formulario
2. En el **Cuadro de herramientas** buscar `FormsPlot`
3. Arrastrarlo al formulario como cualquier control
4. Asignarle `Dock = Fill` para que ocupe todo el espacio disponible

> 💡 Si el control no aparece en el cuadro de herramientas, cerrar y volver a abrir Visual Studio.

---

## Paso 4 — Configurar el formulario con SplitContainer

Para tener controles y la gráfica en el mismo formulario se recomienda usar un `SplitContainer`:

```
Form1
└── SplitContainer (Dock = Fill)
    ├── Panel1 (controles, ancho ~200px)
    │   ├── Label "Tipo de gráfica:"
    │   ├── ComboBox (cmbGrafica)
    │   ├── Label "Color:"
    │   └── ComboBox (cmbColormap)
    └── Panel2 (gráfica)
        └── FormsPlot (formsPlot1, Dock = Fill)
```

### Controles sugeridos

| Control | Nombre | Configuración |
|---|---|---|
| `SplitContainer` | `splitContainer1` | `Dock = Fill` |
| `FormsPlot` | `formsPlot1` | `Dock = Fill` en Panel2 |
| `ComboBox` | `cmbGrafica` | En Panel1 |
| `ComboBox` | `cmbColormap` | En Panel1 |
| `Label` | — | Text = `"Tipo de gráfica:"` |
| `Label` | — | Text = `"Color:"` |

---

## Paso 5 — Código base del formulario

```csharp
using System;
using System.Windows.Forms;
using ScottPlot;

namespace MiProyecto
{
    public partial class Form1 : Form
    {
        private readonly Random _rng = new Random(42);

        public Form1()
        {
            InitializeComponent();
            this.Text = "Gráficas — ScottPlot";
            this.Size = new System.Drawing.Size(950, 700);

            // Llenar opciones de gráfica
            cmbGrafica.Items.AddRange(new string[]
            {
                "Señal sísmica",
                "Temperaturas mensuales",
                "Dispersión de grupos",
                "Poblaciones por país",
                "Señal con ruido"
            });
            cmbGrafica.SelectedIndex = 0;

            // Llenar opciones de color
            cmbColormap.Items.AddRange(new string[]
            {
                "Azul",
                "Rojo",
                "Verde",
                "Naranja"
            });
            cmbColormap.SelectedIndex = 0;

            // Conectar eventos
            cmbGrafica.SelectedIndexChanged  += (s, e) => ActualizarGrafica();
            cmbColormap.SelectedIndexChanged += (s, e) => ActualizarGrafica();

            ActualizarGrafica();
        }

        private System.Drawing.Color ObtenerColor()
        {
            switch (cmbColormap.SelectedIndex)
            {
                case 0: return System.Drawing.Color.DeepSkyBlue;
                case 1: return System.Drawing.Color.OrangeRed;
                case 2: return System.Drawing.Color.LimeGreen;
                case 3: return System.Drawing.Color.Orange;
                default: return System.Drawing.Color.DeepSkyBlue;
            }
        }

        private void ActualizarGrafica()
        {
            formsPlot1.Plot.Clear();
            formsPlot1.Plot.Style(ScottPlot.Style.Blue2);

            switch (cmbGrafica.SelectedIndex)
            {
                case 0: GraficaSismica();      break;
                case 1: GraficaTemperaturas(); break;
                case 2: GraficaDispersion();   break;
                case 3: GraficaPoblaciones();  break;
                case 4: GraficaOndaRuido();    break;
            }

            formsPlot1.Plot.Legend(true);
            formsPlot1.Refresh();
        }

        private void GraficaSismica()
        {
            int      ptos   = 500;
            double[] tiempo = new double[ptos];
            double[] señal  = new double[ptos];

            for (int i = 0; i < ptos; i++)
            {
                double t  = i * 0.1;
                tiempo[i] = t;

                señal[i] = (t > 15 && t < 25)
                    ? 5.0 * Math.Sin(t * 4) * Math.Exp(-0.15 * (t - 15)) : 0;

                señal[i] += (t > 30 && t < 38)
                    ? 2.5 * Math.Sin(t * 6) * Math.Exp(-0.2 * (t - 30)) : 0;

                señal[i] += (_rng.NextDouble() - 0.5) * 0.3;
            }

            var plot = formsPlot1.Plot.AddScatter(tiempo, señal,
                ObtenerColor(), label: "Amplitud");
            plot.LineWidth  = 1;
            plot.MarkerSize = 0;

            formsPlot1.Plot.AddHorizontalLine(0,
                System.Drawing.Color.White, 1, LineStyle.Dash);
            formsPlot1.Plot.Title("Señal Sísmica Simulada");
            formsPlot1.Plot.XLabel("Tiempo (s)");
            formsPlot1.Plot.YLabel("Amplitud");
        }

        private void GraficaTemperaturas()
        {
            string[] meses  = { "Ene","Feb","Mar","Abr","May","Jun",
                                 "Jul","Ago","Sep","Oct","Nov","Dic" };
            double[] medias = { 18,20,22,25,28,32,34,33,30,26,22,19 };

            var barras = formsPlot1.Plot.AddBar(medias);
            barras.Label           = "Temp. media (°C)";
            barras.FillColor       = ObtenerColor();
            barras.BorderLineWidth = 1.5f;

            formsPlot1.Plot.XTicks(
                new double[] { 0,1,2,3,4,5,6,7,8,9,10,11 },
                meses
            );
            formsPlot1.Plot.SetAxisLimits(yMin: 0, yMax: 40);
            formsPlot1.Plot.Title("Temperatura Media Mensual");
            formsPlot1.Plot.XLabel("Mes");
            formsPlot1.Plot.YLabel("°C");
        }

        private void GraficaDispersion()
        {
            int      n  = 150;
            double[] x1 = new double[n], y1 = new double[n];
            double[] x2 = new double[n], y2 = new double[n];

            for (int i = 0; i < n; i++)
            {
                x1[i] = 2 + (_rng.NextDouble() - 0.5) * 4;
                y1[i] = 3 + (_rng.NextDouble() - 0.5) * 4;
                x2[i] = 7 + (_rng.NextDouble() - 0.5) * 4;
                y2[i] = 8 + (_rng.NextDouble() - 0.5) * 4;
            }

            var gA = formsPlot1.Plot.AddScatter(x1, y1,
                System.Drawing.Color.DeepSkyBlue, label: "Grupo A");
            gA.LineWidth   = 0;
            gA.MarkerSize  = 6;
            gA.MarkerShape = MarkerShape.filledCircle;

            var gB = formsPlot1.Plot.AddScatter(x2, y2,
                System.Drawing.Color.OrangeRed, label: "Grupo B");
            gB.LineWidth   = 0;
            gB.MarkerSize  = 6;
            gB.MarkerShape = MarkerShape.filledSquare;

            formsPlot1.Plot.Title("Dispersión — Dos Grupos");
            formsPlot1.Plot.XLabel("Variable X");
            formsPlot1.Plot.YLabel("Variable Y");
        }

        private void GraficaPoblaciones()
        {
            double[] colombia  = { 50.0, 50.9, 51.5, 51.8, 52.2 };
            double[] venezuela = { 28.5, 28.2, 28.0, 27.8, 27.5 };
            double[] ecuador   = { 17.5, 17.8, 18.0, 18.2, 18.4 };
            double[] pos1      = { 0, 1, 2, 3, 4 };
            double[] pos2      = { 0.25, 1.25, 2.25, 3.25, 4.25 };
            double[] pos3      = { 0.50, 1.50, 2.50, 3.50, 4.50 };

            var b1 = formsPlot1.Plot.AddBar(colombia, pos1);
            b1.Label     = "Colombia";
            b1.FillColor = System.Drawing.Color.FromArgb(180, 255, 215, 0);
            b1.BarWidth  = 0.2;

            var b2 = formsPlot1.Plot.AddBar(venezuela, pos2);
            b2.Label     = "Venezuela";
            b2.FillColor = System.Drawing.Color.FromArgb(180, 100, 180, 255);
            b2.BarWidth  = 0.2;

            var b3 = formsPlot1.Plot.AddBar(ecuador, pos3);
            b3.Label     = "Ecuador";
            b3.FillColor = System.Drawing.Color.FromArgb(180, 100, 220, 100);
            b3.BarWidth  = 0.2;

            formsPlot1.Plot.XTicks(
                new double[] { 0.25,1.25,2.25,3.25,4.25 },
                new string[] { "2019","2020","2021","2022","2023" }
            );
            formsPlot1.Plot.SetAxisLimits(yMin: 0, yMax: 60);
            formsPlot1.Plot.Title("Población por País (millones)");
            formsPlot1.Plot.XLabel("Año");
            formsPlot1.Plot.YLabel("Millones");
        }

        private void GraficaOndaRuido()
        {
            int      ptos   = 300;
            double[] t      = new double[ptos];
            double[] limpia = new double[ptos];
            double[] ruido  = new double[ptos];

            for (int i = 0; i < ptos; i++)
            {
                t[i]      = i * 0.05;
                limpia[i] = Math.Sin(t[i] * 2) + 0.5 * Math.Sin(t[i] * 5);
                ruido[i]  = limpia[i] + (_rng.NextDouble() - 0.5) * 0.8;
            }

            var sRuido = formsPlot1.Plot.AddScatter(t, ruido,
                System.Drawing.Color.FromArgb(120, 100, 200, 255),
                label: "Con ruido");
            sRuido.LineWidth  = 0;
            sRuido.MarkerSize = 3;

            var sLimpia = formsPlot1.Plot.AddScatter(t, limpia,
                ObtenerColor(), label: "Original");
            sLimpia.LineWidth  = 2;
            sLimpia.MarkerSize = 0;

            formsPlot1.Plot.Title("Señal Senoidal — Original vs Con Ruido");
            formsPlot1.Plot.XLabel("Tiempo (s)");
            formsPlot1.Plot.YLabel("Amplitud");
        }
    }
}
```

---

## Interacción con la gráfica

ScottPlot incluye interactividad sin código adicional:

| Acción | Resultado |
|---|---|
| Clic izquierdo + arrastrar | Mover la vista (pan) |
| Rueda del mouse | Zoom acercar / alejar |
| Clic derecho | Menú contextual con opciones |
| Doble clic | Restablecer zoom automáticamente |
| `Ctrl` + clic derecho | Guardar imagen de la gráfica |

---

## Tipos de gráficas disponibles en ScottPlot 4.x

| Método | Tipo de gráfica |
|---|---|
| `AddScatter()` | Línea o dispersión de puntos |
| `AddBar()` | Barras verticales |
| `AddHeatmap()` | Mapa de calor 2D |
| `AddPie()` | Gráfica de pastel |
| `AddSignal()` | Señal de alta performance |
| `AddFunction()` | Función matemática continua |
| `AddErrorBar()` | Barras de error |
| `AddAnnotation()` | Anotaciones en el gráfico |
| `AddHorizontalLine()` | Línea horizontal de referencia |
| `AddVerticalLine()` | Línea vertical de referencia |

---

## Estilos disponibles

ScottPlot incluye estilos predefinidos que se aplican con una sola línea:

```csharp
formsPlot1.Plot.Style(ScottPlot.Style.Blue2);    // fondo oscuro azul
formsPlot1.Plot.Style(ScottPlot.Style.Dark1);    // fondo oscuro gris
formsPlot1.Plot.Style(ScottPlot.Style.Light1);   // fondo claro
formsPlot1.Plot.Style(ScottPlot.Style.Seaborn);  // estilo Seaborn
formsPlot1.Plot.Style(ScottPlot.Style.Default);  // estilo por defecto
```

---

## Errores comunes

### ❌ El control `FormsPlot` no aparece en el cuadro de herramientas
**Causa:** Visual Studio no recargó el cuadro de herramientas después de instalar.  
**Solución:** Cerrar y volver a abrir Visual Studio completamente.

---

### ❌ Error al instalar — versión no compatible
**Causa:** NuGet intenta instalar la versión 5.x que no es compatible con .NET Framework.  
**Solución:** Especificar explícitamente la versión `4.1.71` al instalar.

```powershell
Install-Package ScottPlot.WinForms -Version 4.1.71
```

---

### ❌ La gráfica no se actualiza al cambiar opciones
**Causa:** Falta llamar a `formsPlot1.Refresh()` al final de cada actualización.  
**Solución:** Siempre terminar con:

```csharp
formsPlot1.Plot.Legend(true);
formsPlot1.Refresh();
```

---

### ❌ Error de ruta de acceso muy larga al instalar
**Causa:** Windows tiene un límite de 260 caracteres en rutas de archivo y la carpeta del proyecto está muy anidada.  
**Solución:** Mover el proyecto a una ruta corta como `C:\Dev\MiProyecto\` o habilitar rutas largas ejecutando en PowerShell como administrador:

```powershell
New-ItemProperty -Path "HKLM:\SYSTEM\CurrentControlSet\Control\FileSystem" `
    -Name "LongPathsEnabled" -Value 1 -PropertyType DWORD -Force
```

---

## Referencias

- [Repositorio oficial de ScottPlot](https://github.com/ScottPlot/ScottPlot)
- [NuGet — ScottPlot.WinForms 4.1.71](https://www.nuget.org/packages/ScottPlot.WinForms/4.1.71)
- [Documentación oficial](https://scottplot.net/docs/)
- [Galería de ejemplos](https://scottplot.net/cookbook/4.1/)
