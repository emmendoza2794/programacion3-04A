# Ejercicios Prácticos - Manejo de Archivos (Semana 4)

Estos ejercicios están diseñados para practicar la persistencia de datos en C# utilizando la consola para capturar información del usuario.

---

## Ejercicio 1: Diario Personal con Bitácora (Clase File y DateTime)

**Objetivo:** Crear un programa que permita al usuario escribir una entrada en su "diario" y guardarla automáticamente con la fecha y hora actual.

**Instrucciones:**
1.  Solicita al usuario que ingrese su nombre al iniciar.
2.  Pide al usuario que escriba un pensamiento o actividad del día por teclado.
3.  Guarda el texto en un archivo llamado `diario.txt`.
4.  **Regla de oro:** No debes sobrescribir lo anterior. Usa `File.AppendAllText`.
5.  El formato de cada línea en el archivo debe ser: `[FECHA Y HORA] - USUARIO: MENSAJE`.

**Reto extra:** Al iniciar el programa, muestra las últimas 3 líneas guardadas en el diario antes de pedir una nueva entrada.

---

## Ejercicio 2: Gestor de Contactos Simple (Formato CSV)

**Objetivo:** Aplicar el concepto de datos estructurados para guardar una pequeña agenda de contactos.

**Instrucciones:**
1.  Crea una clase `Contacto` con las propiedades: `Nombre`, `Telefono` y `Correo`.
2.  Solicita estos tres datos al usuario por teclado.
3.  Implementa un método `ToCSV()` en la clase que devuelva los datos separados por punto y coma (`;`).
4.  Guarda el contacto en un archivo `contactos.csv`.
5.  **Validación:** Antes de guardar, usa `String.Trim()` y `String.ToLower()` para normalizar el correo electrónico.
6.  Al finalizar, pregunta al usuario si desea "Listar contactos". Si dice que sí, lee el archivo, haz un `Split(';')` y muestra los datos en una tabla limpia en la consola.

---

## Ejercicio 3: Creador de Estructura de Proyectos (Directory y Path)

**Objetivo:** Automatizar la creación de carpetas y archivos iniciales para un proyecto imaginario.

**Instrucciones:**
1.  Solicita al usuario el "Nombre del Proyecto".
2.  Crea una carpeta principal con ese nombre usando `Directory.CreateDirectory`.
3.  Dentro de esa carpeta, crea tres subcarpetas: `documentos`, `imagenes` y `codigo`.
4.  Pide al usuario que ingrese una breve descripción del proyecto.
5.  Crea un archivo llamado `readme.txt` dentro de la subcarpeta `documentos` (usa `Path.Combine` para la ruta) y guarda la descripción allí.
6.  Muestra en consola la ruta absoluta donde se creó el proyecto usando `Path.GetFullPath`.

---

### Tips para el éxito:
-   Usa bloques `try-catch` para manejar posibles errores de acceso a disco.
-   Recuerda incluir `using System.IO;` al inicio de tus archivos.
-   Usa `Environment.NewLine` para asegurar que los saltos de línea funcionen en cualquier sistema operativo.
