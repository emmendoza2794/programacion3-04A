# Guía de Conceptos Clave - Semana 4: Programación III

**Tema:** Manejo de Fechas, Archivos, Cadenas y Datos Estructurados en C#

En esta sesión aprenderemos a trabajar con elementos esenciales para el procesamiento de datos: fechas, manipulación avanzada de texto y la persistencia de información utilizando archivos de texto y formatos estructurados.

---

## 1. La Clase `DateTime`: Trabajando con el Tiempo
`DateTime` es una estructura fundamental para representar instantes de tiempo.

### A. Creación y Propiedades Principales
```csharp
DateTime ahora = DateTime.Now;        // Fecha y hora actual local
DateTime hoy = DateTime.Today;       // Solo la fecha (hora 00:00:00)
DateTime utc = DateTime.UtcNow;      // Fecha y hora en formato UTC

// Constructores (Año, Mes, Día, [Hora, Minuto, Segundo])
DateTime fecha = new DateTime(2026, 3, 8);
DateTime fechaHora = new DateTime(2026, 3, 8, 14, 30, 0);

// Acceso a componentes
int año = ahora.Year;
int mes = ahora.Month;
int dia = ahora.Day;
int hora = ahora.Hour;
DayOfWeek diaSemana = ahora.DayOfWeek; // Ejemplo: Sunday
```

### B. Operaciones de Modificación (Inmutabilidad)
Los métodos de `DateTime` no modifican la fecha original, devuelven una **nueva**.
```csharp
DateTime futuro = ahora.AddDays(10);
DateTime pasado = ahora.AddMonths(-2);
DateTime proximaHora = ahora.AddHours(1);
DateTime proximoAño = ahora.AddYears(1);
```

### C. Diferencias y Comparaciones
```csharp
DateTime fecha1 = new DateTime(2026, 12, 31);
DateTime fecha2 = DateTime.Now;

// TimeSpan: Representa un intervalo de tiempo
TimeSpan diferencia = fecha1 - fecha2;
Console.WriteLine($"Faltan {diferencia.Days} días para fin de año.");

// Comparaciones booleanas
bool esMayor = fecha1 > fecha2;
bool esMismoDia = fecha1.Date == fecha2.Date;
```

### D. Formateo y Conversión (ToString)
```csharp
Console.WriteLine(ahora.ToShortDateString()); // "08/03/2026"
Console.WriteLine(ahora.ToLongDateString());  // "domingo, 8 de marzo de 2026"
Console.WriteLine(ahora.ToString("yyyy-MM-dd HH:mm:ss")); // Formato personalizado
```

### E. Parsing (Convertir texto a DateTime)
```csharp
string entrada = "2026-05-20";
DateTime fechaConvertida = DateTime.Parse(entrada);

// TryParse: Forma segura de convertir (evita errores si el texto no es fecha)
if (DateTime.TryParse("30/02/2026", out DateTime resultado)) {
    // Código si la fecha es válida
}
```

---

## 2. Manejo de Cadenas (`String` y `StringBuilder`)
Las cadenas en C# son **inmutables** (cada cambio crea un nuevo objeto en memoria). Para concatenaciones masivas, usamos `StringBuilder`.

### Métodos de `String`
```csharp
string texto = "  C# es un lenguaje INCREÍBLE  ";

string limpio = texto.Trim(); // Quita espacios extremos
string lower = texto.ToLower(); // Todo a minúsculas
string reemplazo = texto.Replace("INCREÍBLE", "potente");
string[] palabras = texto.Split(' '); // Divide por espacios
bool contiene = texto.Contains("C#");
```

### Clase `StringBuilder` (Eficiencia)
```csharp
using System.Text;

StringBuilder sb = new StringBuilder();
sb.Append("Listado de Alumnos:");
for (int i = 0; i < 100; i++) {
    sb.AppendLine($"\nAlumno {i}");
}
string resultadoFinal = sb.ToString();
```

---

## 3. Manejo de Archivos de Texto (.txt)
La forma más sencilla de persistir datos es mediante archivos de texto plano. La clase `File` proporciona métodos estáticos para realizar operaciones rápidas.

### Operaciones Básicas con la Clase `File`
```csharp
string ruta = "notas.txt";

// 1. Escribir texto (sobrescribe el archivo si existe)
File.WriteAllText(ruta, "Primera línea de texto.");

// 2. Agregar texto al final (sin borrar lo anterior)
File.AppendAllText(ruta, "\nEsta es una nueva línea.");

// 3. Leer todo el contenido como un solo string
string contenido = File.ReadAllText(ruta);

// 4. Leer el archivo y obtener un arreglo de líneas
string[] lineas = File.ReadAllLines(ruta);
foreach (string l in lineas) {
    Console.WriteLine("Línea: " + l);
}

// 5. Verificar si el archivo existe
if (File.Exists(ruta)) {
    Console.WriteLine("El archivo está listo para usarse.");
}
```

---

## 4. Gestión Avanzada: Directorios y Streams (`System.IO`)

### Clase `Directory` y `Path`
```csharp
string carpeta = "MisArchivos";
if (!Directory.Exists(carpeta)) {
    Directory.CreateDirectory(carpeta);
}

// Combinar rutas de forma segura
string rutaCompleta = Path.Combine(carpeta, "datos.txt");
```

### Lectura y Escritura con Streams (`StreamReader` y `StreamWriter`)
Ideal para archivos grandes, ya que no cargan todo el archivo en memoria de una vez.

```csharp
// ESCRITURA CON STREAM
using (StreamWriter sw = new StreamWriter("bitacora.txt", true)) {
    sw.WriteLine($"[LOG {DateTime.Now}] Evento registrado.");
}

// LECTURA CON STREAM
using (StreamReader sr = new StreamReader("bitacora.txt")) {
    string linea;
    while ((linea = sr.ReadLine()) != null) {
        Console.WriteLine(linea);
    }
}
```

---

## 5. Datos Estructurados: Formato CSV (Comma-Separated Values)

El formato CSV usa un separador (comúnmente `;` o `,`) para organizar la información en "columnas", permitiendo guardar objetos de forma persistente.

### Serialización Manual (Guardar Objeto)
```csharp
public class Estudiante
{
    public string Id { get; set; }
    public string Nombre { get; set; }
    public double Nota { get; set; }

    public string ToCSV() => $"{Id};{Nombre};{Nota}";
}

// Para guardar:
Estudiante est = new Estudiante { Id = "001", Nombre = "Juan", Nota = 4.5 };
File.AppendAllText("estudiantes.csv", est.ToCSV() + Environment.NewLine);
```

### Deserialización Manual (Recuperar Objeto)
```csharp
if (File.Exists("estudiantes.csv"))
{
    string[] lineas = File.ReadAllLines("estudiantes.csv");
    foreach (string linea in lineas)
    {
        string[] datos = linea.Split(';');
        if (datos.Length == 3)
        {
            Estudiante e = new Estudiante {
                Id = datos[0],
                Nombre = datos[1],
                Nota = double.Parse(datos[2])
            };
            Console.WriteLine($"Cargado: {e.Nombre} - Nota: {e.Nota}");
        }
    }
}
```

---

## 6. Mejores Prácticas y Manejo de Errores
*   **Validación**: Siempre usa `File.Exists()` antes de intentar leer un archivo.
*   **Sentencia `using`**: Garantiza que el archivo se cierre y libere la memoria automáticamente.
*   **Separadores**: Evita que los datos contengan el delimitador elegido (como `;`) para no romper la estructura del CSV.

---

## 7. Bibliografía y Recursos
- **Documentación Microsoft**: `System.IO.File`, `System.IO.Directory`, `System.DateTime`.
- **Enfoque Semanal**: Aprender a persistir el estado de una aplicación en archivos planos para que los datos no se pierdan al cerrar el programa.
