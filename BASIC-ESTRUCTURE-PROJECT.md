# Estructura basica de un proyecto de consola en C# (.NET Framework)

Cuando creamos un proyecto de tipo **Aplicacion de consola** en Visual Studio con .NET Framework, se genera la siguiente estructura:

```
programacion3-04A/                    <-- Repositorio (raiz)
└── conceptos basicos/                <-- Carpeta de la solucion
    ├── conceptos basicos.slnx        <-- Archivo de solucion
    ├── .vs/                          <-- Carpeta interna de Visual Studio
    └── conceptos basicos/            <-- Carpeta del proyecto
        ├── conceptos basicos.csproj  <-- Archivo de proyecto
        ├── Program.cs                <-- Codigo principal (punto de entrada)
        ├── App.config                <-- Configuracion de la app
        ├── Properties/
        │   └── AssemblyInfo.cs       <-- Metadatos del ensamblado
        ├── bin/                      <-- Ejecutable compilado
        └── obj/                      <-- Archivos temporales de compilacion
```

## Descripcion de cada archivo

### 1. Archivo de solucion (`.slnx`)

Es el archivo "padre" que agrupa uno o mas proyectos. Cuando abres este archivo en Visual Studio, se carga toda la solucion con todos sus proyectos.

```xml
<Solution>
  <Project Path="conceptos basicos/conceptos basicos.csproj" />
</Solution>
```

Una solucion puede contener multiples proyectos (por ejemplo: un proyecto de consola, una libreria de clases y un proyecto de pruebas unitarias).

### 2. Carpeta `.vs/`

Carpeta que Visual Studio usa internamente para guardar configuracion del IDE: layout de ventanas, indices de busqueda, preferencias del usuario, etc.

**No se sube a git** porque es especifica de cada desarrollador.

### 3. Archivo de proyecto (`.csproj`)

Es el archivo mas importante del proyecto. Define:

- **Tipo de aplicacion**: `<OutputType>Exe</OutputType>` indica que es una app de consola (genera un `.exe`).
- **Framework objetivo**: `<TargetFrameworkVersion>v4.7.2</TargetFrameworkVersion>` indica que usa .NET Framework 4.7.2.
- **Referencias**: librerias del sistema que el proyecto necesita (System, System.Core, System.Linq, etc.).
- **Archivos a compilar**: lista de archivos `.cs` que forman parte del proyecto.
- **Configuraciones de compilacion**: Debug (para desarrollo, con simbolos de depuracion) y Release (para produccion, con optimizaciones).

### 4. `Program.cs` - Punto de entrada

Es el archivo principal y el **punto de entrada** de la aplicacion. Contiene el metodo `Main`, que es lo primero que se ejecuta cuando corres el programa.

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conceptos_basicos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Aqui va tu codigo
        }
    }
}
```

- **`using`**: importa namespaces (librerias) para poder usar sus clases.
- **`namespace`**: agrupa las clases del proyecto bajo un nombre logico.
- **`internal class Program`**: la clase principal. `internal` significa que solo es accesible dentro del mismo proyecto.
- **`static void Main(string[] args)`**: el metodo de entrada. `static` porque se ejecuta sin crear una instancia de la clase. `args` permite recibir argumentos desde la linea de comandos.

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
