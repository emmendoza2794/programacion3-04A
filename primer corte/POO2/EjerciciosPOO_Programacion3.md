# Ejercicios de Programación Orientada a Objetos - Programación 3

## 📚 Objetivos de Aprendizaje
- Implementar **interfaces** para definir contratos
- Usar **enums** para constantes con significado
- Crear **clases abstractas** como base común
- Aplicar **herencia** y **polimorfismo**
- Organizar código en una estructura clara

---

## 🎯 EJERCICIO 1: Sistema de Biblioteca Digital

### 📖 Descripción del Problema
Crear un sistema para gestionar una biblioteca digital que maneja diferentes tipos de materiales: **Libros**, **Revistas** y **AudioLibros**. Cada material tiene información común pero también características específicas.

### 🏗️ Estructura de Carpetas Requerida
```
BibliotecaDigital\
├── Enums\
│   └── TipoCategoria.cs        ← Ficcion, NoFiccion, Ciencia, Historia
├── Interfaces\
│   └── IPrestable.cs           ← ContratoPréstamo
├── Modelos\
│   ├── MaterialBiblioteca.cs   ← Clase abstracta base
│   ├── Libro.cs                ← Hereda de MaterialBiblioteca
│   ├── Revista.cs              ← Hereda de MaterialBiblioteca
│   └── AudioLibro.cs           ← Hereda de MaterialBiblioteca
└── Program.cs
```

### 📋 Especificaciones Técnicas

#### **ENUM a crear:**
```csharp
public enum TipoCategoria 
{ 
    Ficcion, NoFiccion, Ciencia, Historia, Tecnologia 
}
```

#### **INTERFAZ a crear:**
```csharp
public interface IPrestable
{
    DateTime CalcularFechaDevolucion();
    void GenerarComprobantePrestramo();
    decimal CalcularMultaPorRetraso(int diasRetraso);
}
```

#### **CLASE ABSTRACTA a crear:**
```csharp
public abstract class MaterialBiblioteca
{
    // Propiedades: Id, Titulo, Autor, AñoPublicacion, Categoria
    // Constructor protegido
    // Método virtual: MostrarInformacion()
}
```

#### **CLASES HIJAS a crear:**
- **Libro**: Propiedades adicionales → `int NumeroPaginas`, `string ISBN`
- **Revista**: Propiedades adicionales → `int NumeroEdicion`, `string Periodicidad`  
- **AudioLibro**: Propiedades adicionales → `TimeSpan Duracion`, `string Narrador`

#### **PROGRAMA PRINCIPAL:**
- Lista de `IPrestable`
- Menú para agregar materiales
- Procesar préstamos y mostrar comprobantes

---

## 🚗 EJERCICIO 2: Sistema de Concesionario de Vehículos

### 📖 Descripción del Problema
Desarrollar un sistema para un concesionario que vende **Autos**, **Motocicletas** y **Camiones**. Cada vehículo tiene características comunes pero precios y comisiones diferentes.

### 🏗️ Estructura de Carpetas Requerida
```
ConcesionarioVehiculos\
├── Enums\
│   ├── TipoCombustible.cs      ← Gasolina, Diesel, Electrico, Hibrido
│   └── EstadoVehiculo.cs       ← Nuevo, Usado, Seminuevo
├── Interfaces\
│   └── IVendible.cs            ← ContratoVenta
├── Modelos\
│   ├── Vehiculo.cs             ← Clase abstracta base
│   ├── Auto.cs                 ← Hereda de Vehiculo
│   ├── Motocicleta.cs          ← Hereda de Vehiculo
│   └── Camion.cs               ← Hereda de Vehiculo
└── Program.cs
```

### 📋 Especificaciones Técnicas

#### **ENUMS a crear:**
```csharp
public enum TipoCombustible { Gasolina, Diesel, Electrico, Hibrido }
public enum EstadoVehiculo { Nuevo, Usado, Seminuevo }
```

#### **INTERFAZ a crear:**
```csharp
public interface IVendible
{
    decimal CalcularPrecioFinal();
    void GenerarFacturaVenta();
    decimal CalcularComisionVendedor();
}
```

#### **CLASE ABSTRACTA a crear:**
```csharp
public abstract class Vehiculo
{
    // Propiedades: Id, Marca, Modelo, Año, PrecioBase, Combustible, Estado
    // Constructor protegido
    // Método virtual: MostrarEspecificaciones()
}
```

#### **CLASES HIJAS a crear:**
- **Auto**: Propiedades → `int NumeroPuertas`, `bool TieneAireAcondicionado`
- **Motocicleta**: Propiedades → `int Cilindraje`, `bool EsDeportiva`
- **Camion**: Propiedades → `decimal CapacidadCarga`, `int NumeroEjes`

#### **LÓGICA DE NEGOCIO:**
- **Auto**: Precio final = PrecioBase + (AireAcondicionado ? 2000 : 0)
- **Motocicleta**: Precio final = PrecioBase + (EsDeportiva ? Cilindraje * 10 : 0)
- **Camion**: Precio final = PrecioBase + (CapacidadCarga * 500)

---

## 🍕 EJERCICIO 3: Sistema de Restaurante y Cocina

### 📖 Descripción del Problema
Crear un sistema para un restaurante que maneja diferentes tipos de platos: **Entradas**, **PlatosPrincipales** y **Postres**. Cada tipo de plato tiene tiempos de preparación y costos diferentes.

### 🏗️ Estructura de Carpetas Requerida
```
SistemaRestaurante\
├── Enums\
│   ├── TipoComida.cs           ← Vegetariana, Vegana, Carnivora, Mariscos
│   ├── NivelDificultad.cs      ← Facil, Intermedio, Avanzado
│   └── EstadoOrden.cs          ← Pendiente, Preparando, Listo, Entregado
├── Interfaces\
│   └── IPreparable.cs          ← ContratoPreparacion
├── Modelos\
│   ├── Plato.cs                ← Clase abstracta base
│   ├── Entrada.cs              ← Hereda de Plato
│   ├── PlatoPrincipal.cs       ← Hereda de Plato
│   └── Postre.cs               ← Hereda de Plato
└── Program.cs
```

### 📋 Especificaciones Técnicas

#### **ENUMS a crear:**
```csharp
public enum TipoComida { Vegetariana, Vegana, Carnivora, Mariscos, Mixta }
public enum NivelDificultad { Facil, Intermedio, Avanzado }
public enum EstadoOrden { Pendiente, Preparando, Listo, Entregado }
```

#### **INTERFAZ a crear:**
```csharp
public interface IPreparable
{
    TimeSpan CalcularTiempoPreparacion();
    void GenerarOrdenCocina();
    decimal CalcularCostoTotal();
}
```

#### **CLASE ABSTRACTA a crear:**
```csharp
public abstract class Plato
{
    // Propiedades: Id, Nombre, Descripcion, PrecioBase, TipoComida, Dificultad
    // Constructor protegido
    // Método virtual: MostrarInformacionNutricional()
}
```

#### **CLASES HIJAS a crear:**
- **Entrada**: Propiedades → `bool EsFria`, `int Porciones`
- **PlatoPrincipal**: Propiedades → `string ProteinaPrincipal`, `bool IncluyeGuarnicion`
- **Postre**: Propiedades → `bool ContieneLactosa`, `int CaloriasPorPorcion`

#### **LÓGICA DE NEGOCIO:**
- **Entrada**: Tiempo = EsFria ? 10min : 20min
- **PlatoPrincipal**: Tiempo = 30min + (Dificultad * 15min)
- **Postre**: Tiempo = 25min + (ContieneLactosa ? 5min : 0)

---

## 📝 Instrucciones Generales para Todos los Ejercicios

### ✅ **Requisitos Obligatorios:**
1. **Usar `partial classes`** EN AL MENOS UNA clase (opcional para práctica)
2. **Implementar manejo de excepciones** en el programa principal
3. **Crear menús interactivos** para el usuario
4. **Aplicar polimorfismo** usando listas de interfaces
5. **Incluir comentarios explicativos** sobre cada concepto POO

### 🎯 **Criterios de Evaluación:**
- **Uso correcto de interfaces** (20%)
- **Implementación adecuada de enums** (15%)
- **Diseño de clases abstractas y herencia** (25%)
- **Aplicación de polimorfismo** (20%)
- **Organización del código y comentarios** (20%)

### 💡 **Consejos para Estudiantes:**
1. **Empezar por el enum** → Define las constantes primero
2. **Diseñar la interfaz** → Piensa en el "contrato" común
3. **Crear la clase abstracta** → Define la estructura base
4. **Implementar las clases hijas** → Especializa el comportamiento
5. **Probar con el programa principal** → Usa polimorfismo

---

## 🚀 **Reto Adicional (Opcional)**
Para estudiantes avanzados: Agregar **persistencia de datos** usando archivos JSON o texto para guardar y cargar la información entre ejecuciones del programa.

### 📚 **Conceptos POO Cubiertos:**
- ✅ **Abstracción** (clases abstractas)
- ✅ **Encapsulación** (propiedades y métodos)
- ✅ **Herencia** (clases base e hijas)
- ✅ **Polimorfismo** (interfaces y métodos virtuales)
- ✅ **Composición** (uso de enums y objetos)

¡Buena suerte! 🎓