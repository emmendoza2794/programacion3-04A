# Estructura basica de un proyecto de consola en C# (.NET Framework)

Cuando creamos un proyecto de tipo **Aplicacion de consola** en Visual Studio con .NET Framework, se genera la siguiente estructura:

```
programacion3-04A/                    <-- Repositorio (raiz)
└── conceptos basicos/                <-- Carpeta de la solucion
    ├── conceptos basicos.slnx        <-- Archivo de solucion
    ├── .vs/                          <-- Carpeta interna de Visual Studio
    └── conceptos basicos/            <-- Carpeta del proyecto
        ├── conceptos basicos.csproj  <-- Archivo de proyecto
        ├── Program.cs                <-- Punto de entrada (Menú interactivo)
        ├── Ejemplos/                 <-- Carpeta con el codigo de cada tema
        │   ├── EjemploSintaxis.cs
        │   ├── EjemploArchivos.cs
        │   └── ...
        ├── App.config                <-- Configuracion de la app
        ├── Properties/
        │   └── AssemblyInfo.cs       <-- Metadatos del ensamblado
        ├── bin/                      <-- Ejecutable compilado
        └── obj/                      <-- Archivos temporales de compilacion
```

## Descripcion de cada archivo

### 1. Archivo de solucion (`.slnx`)
... (mantener igual) ...

### 4. `Program.cs` - Menú del Proyecto

En este proyecto específico, el `Program.cs` actúa como un **Menú Interactivo**. Su función principal es permitir al usuario elegir qué ejemplo del Módulo 1 desea ejecutar (Sintaxis, POO, Archivos, etc.).

Utiliza una estructura `while` y un `switch` para navegar entre las diferentes opciones disponibles en la carpeta `Ejemplos`.

### 5. Carpeta `Ejemplos/`

Esta carpeta contiene archivos `.cs` separados para cada concepto del curso. Esto permite que el código sea modular y más fácil de estudiar. Cada archivo tiene su propio namespace (ej. `conceptos_basicos.Ejemplos`) y un método público `Ejecutar()` que es llamado desde el menú principal.

```csharp
using System;

namespace conceptos_basicos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Aquí va tu código
        }
    }
}
```

#### Conceptos Clave:

- **`namespace` (Espacio de nombres):**
  Es una forma de organizar el código y evitar conflictos de nombres. Imaginalo como una "carpeta lógica" o un apellido para tus clases. Permite que dos clases tengan el mismo nombre siempre que estén en namespaces diferentes.

- **`internal class` vs `public class` (Modificadores de acceso):**
  - **`public`**: La clase es accesible desde cualquier otro proyecto que haga referencia a este. Es el nivel de acceso más permisivo.
  - **`internal`**: La clase solo es accesible dentro del mismo proyecto (ensamblado). Es el nivel por defecto en Visual Studio para las clases si no se especifica uno, ideal para ocultar lógica interna que no debe ser expuesta al exterior.

- **`static void`:**
  - **`static`**: Indica que el método pertenece a la **clase misma** y no a una instancia (objeto) de la clase. Esto permite que el sistema operativo llame al método `Main` sin tener que crear un objeto `Program` primero.
  - **`void`**: Indica que el método **no devuelve ningún valor** (no hay un `return` con datos al finalizar).

- **`Main(string[] args)`:**
  Es el nombre estándar del método de entrada. El parámetro `args` es un arreglo de cadenas que permite recibir información desde la línea de comandos al momento de iniciar la aplicación.

### 5. `App.config`

Archivo de configuracion en formato XML que indica que version del runtime de .NET soporta la aplicacion.

```xml
<configuration>
    <startup>
        <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.7.2" />
    </startup>
</configuration>
```

Tambien se puede usar para guardar cadenas de conexion a bases de datos, configuraciones personalizadas, etc.

### 6. `Properties/AssemblyInfo.cs`

Contiene metadatos del ensamblado que se incrustan en el `.exe` compilado:

- Titulo y descripcion del producto
- Version del ensamblado
- Copyright
- Configuracion de visibilidad COM

### 7. Carpetas `bin/` y `obj/`

- **`bin/`**: contiene el resultado de la compilacion (el `.exe` y sus dependencias). Dentro tiene subcarpetas `Debug/` y `Release/`.
- **`obj/`**: contiene archivos temporales e intermedios que el compilador genera durante el proceso de compilacion.

**Ninguna de las dos se sube a git** porque se regeneran cada vez que compilas.

## Flujo de compilacion

1. Visual Studio lee el `.csproj` para saber que archivos compilar y que referencias usar.
2. El compilador de C# (`csc`) compila todos los archivos `.cs` del proyecto.
3. Los archivos intermedios se guardan en `obj/`.
4. El ejecutable final (`.exe`) se genera en `bin/Debug/` o `bin/Release/` segun la configuracion.
5. Al ejecutar, el runtime de .NET lee `App.config` y arranca el metodo `Main` de `Program.cs`.
