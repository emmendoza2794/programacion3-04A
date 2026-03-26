# Guía de Conceptos Clave - Semana 7: Programación III

**Tema:** Introducción a Aplicaciones con Interfaz Gráfica de Usuario (GUI) con Windows Forms (.NET Framework)

En esta sesión realizamos la transición más importante del curso: pasamos de interactuar con una terminal de texto (Consola) a crear aplicaciones visuales e interactivas utilizando el modelo de **Windows Forms**.

---

## 1. Consola vs. Windows Forms: El Cambio de Paradigma

Hasta ahora, hemos trabajado con aplicaciones de consola donde el flujo es lineal. Es fundamental entender las diferencias antes de empezar a diseñar:

| Característica | Aplicación de Consola | Aplicación Windows Forms (GUI) |
| :--- | :--- | :--- |
| **Interacción** | Basada en texto (teclado). | Basada en elementos visuales (ratón y teclado). |
| **Flujo de Ejecución** | Lineal y secuencial (Inicio -> Fin). | **Orientado a Eventos** (El programa espera acciones). |
| **Entrada de Datos** | `Console.ReadLine()` (Pausa el programa). | `TextBox`, `ComboBox`, `CheckBox` (No pausa el flujo). |
| **Salida de Datos** | `Console.WriteLine()` (Texto plano). | `Label`, `MessageBox`, `PictureBox`, etc. |
| **Estado del Programa** | Se pierde al terminar el método `Main`. | Se mantiene mientras la ventana (Form) esté abierta. |

---

## 2. Programación Orientada a Eventos
En Windows Forms, el código no se ejecuta solo porque "le toca el turno", sino porque **ocurre algo**. Ese "algo" es un **Evento**.

- **El Evento:** Un clic, pasar el ratón, escribir en un cuadro de texto.
- **El Manejador (Handler):** El método en C# que se dispara automáticamente cuando ocurre el evento.

---

## 3. Anatomía y Diseño de la Interfaz (Layout)
Diseñar una GUI requiere pensar en cómo se comportan los controles dentro de la ventana (`Form`).

### Propiedades de Posicionamiento:
- **Anchor (Ancla):** Permite que un control se mueva o estire proporcionalmente cuando el usuario cambia el tamaño de la ventana.
- **Dock (Acoplamiento):** "Pega" un control a un borde (superior, inferior, lateral) u ocupa todo el espacio disponible (`Fill`).
- **TabIndex:** Define el orden lógico en que se mueve el cursor al presionar la tecla `TAB`.

---

## 4. Catálogo de Componentes Esenciales (Toolbox)

### A. Entrada de Datos (Captura de información)
*   **TextBox:** Entrada de texto libre.
*   **MaskedTextBox:** Para datos con formato estricto (ej. Cédulas, Teléfonos).
*   **NumericUpDown:** Para números (evita que el usuario escriba letras por error).
*   **DateTimePicker:** Para seleccionar fechas desde un calendario visual.

### B. Selección y Opciones
*   **ComboBox:** Lista desplegable de opciones.
*   **RadioButton:** Selección única entre varias opciones excluyentes.
*   **CheckBox:** Para marcar opciones independientes (Sí/No).
*   **ListBox:** Muestra una lista de elementos donde se pueden seleccionar uno o varios.

### C. Visualización y Mensajes
*   **Label:** Texto informativo no editable.
*   **PictureBox:** Para mostrar imágenes y gráficos.
*   **ProgressBar:** Barra de carga para procesos largos.
*   **MessageBox:** Ventana emergente para avisos o confirmaciones.

---

## 5. Contenedores: Organizando la Interfaz
Para que una interfaz no sea un caos de botones sueltos, usamos contenedores:
1.  **GroupBox:** Agrupa controles relacionados con un borde y un título (ej. "Datos del Cliente").
2.  **Panel:** Agrupa controles sin borde visible; ideal para organizar secciones que se deben ocultar o mostrar juntas.
3.  **TabControl:** Crea pestañas (como en un navegador) para organizar mucha información en poco espacio.

---

## 6. Composición de un Proyecto .NET Framework
Cuando creas un proyecto de Windows Forms, Visual Studio genera automáticamente una estructura de archivos que trabajan en conjunto:

### Archivos Principales:
1.  **Program.cs:** Es el punto de entrada de la aplicación. Contiene el método `Main` y la instrucción `Application.Run(new Form1())` que inicia la ventana principal.
2.  **Form1.cs (Code-Behind):** Aquí es donde escribes la lógica del negocio en C# (manejo de botones, cálculos, etc.).
3.  **Form1.Designer.cs:** Este archivo es gestionado por Visual Studio. Contiene el código C# que define la posición, el tamaño y las propiedades de los controles que arrastras en el diseñador visual. **No se recomienda editarlo manualmente.**
4.  **Form1.resx:** Archivo de recursos XML donde se guardan imágenes, iconos o textos traducidos que utiliza el formulario.
5.  **App.config:** Archivo de configuración XML. Se usa para guardar parámetros globales como cadenas de conexión a bases de datos o configuraciones de usuario.
6.  **Properties/:** Carpeta que contiene `AssemblyInfo.cs` (metadatos del proyecto) y archivos de configuración de recursos y ajustes predeterminados.

---

## 7. Ejemplo de Código: Formulario de Bienvenida

A continuación, vemos cómo se conecta el código manual con la estructura del proyecto.

### Archivo: `Form1.cs`
Este código representa la lógica que escribimos para responder a la interacción:

```csharp
using System;
using System.Windows.Forms;

namespace MiPrimeraApp
{
    // partial permite que la clase esté dividida entre este archivo y el Designer.cs
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent(); // Método en Designer.cs que crea los controles visuales
        }

        // Evento Click del botón
        private void btnSaludar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNombre.Text))
            {
                string mensaje = "¡Hola " + txtNombre.Text + "! Bienvenido a Windows Forms.";
                MessageBox.Show(mensaje, "Saludo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Por favor, escribe tu nombre.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
```

### Archivo: `Program.cs`
Es el "motor" que arranca la interfaz gráfica:

```csharp
using System;
using System.Windows.Forms;

namespace MiPrimeraApp
{
    static class Program
    {
        [STAThread] // Indica que el modelo de hilos es de un solo subproceso (requerido por Windows)
        static void Main()
        {
            Application.EnableVisualStyles(); // Activa el estilo visual moderno
            Application.SetCompatibleTextRenderingDefault(false);
            
            // Lanza el formulario inicial en pantalla
            Application.Run(new Form1()); 
        }
    }
}
```

---

## 8. Buenas Prácticas de Desarrollo
1.  **Nombres Claros:** No dejes los nombres por defecto (`button1`). Usa prefijos: `btnAceptar`, `txtNombre`, `lblResultado`.
2.  **Validación Previa:** Comprueba que los campos obligatorios no estén vacíos antes de procesar.
3.  **Interfaz Limpia:** Usa los contenedores (`GroupBox`) para que el usuario entienda qué datos están relacionados.

---

## 9. Recursos Adicionales
- **Visual Studio Toolbox:** Tómate un tiempo para arrastrar cada control y explorar sus propiedades (F4).
- **Enfoque Semanal:** Dominar la creación de formularios que capturen datos de forma segura y visualmente organizada.
