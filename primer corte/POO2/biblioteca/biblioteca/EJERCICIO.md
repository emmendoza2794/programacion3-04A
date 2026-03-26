# EJERCICIO 1: Sistema de Biblioteca Digital

## 📖 Descripción del Problema
Crear un sistema para gestionar una biblioteca digital que maneja diferentes tipos de materiales: Libros, Revistas y AudioLibros. Cada material tiene información común pero también características específicas.

## 🏗️ Estructura de Carpetas Requerida
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

## 📋 Especificaciones Técnicas

### ENUM a crear:
```csharp
public enum TipoCategoria 
{ 
    Ficcion, NoFiccion, Ciencia, Historia, Tecnologia 
}
```

### INTERFAZ a crear:
```csharp
public interface IPrestable
{
    DateTime CalcularFechaDevolucion();
    void GenerarComprobantePrestramo();
    decimal CalcularMultaPorRetraso(int diasRetraso);
}
```

### CLASE ABSTRACTA a crear:
```csharp
public abstract class MaterialBiblioteca
{
    // Propiedades: Id, Titulo, Autor, AñoPublicacion, Categoria
    // Constructor protegido
    // Método virtual: MostrarInformacion()
}
```

### CLASES HIJAS a crear:
- **Libro**: Propiedades adicionales → int NumeroPaginas, string ISBN
- **Revista**: Propiedades adicionales → int NumeroEdicion, string Periodicidad
- **AudioLibro**: Propiedades adicionales → TimeSpan Duracion, string Narrador

### PROGRAMA PRINCIPAL:
- Lista de IPrestable
- Menú para agregar materiales
- Procesar préstamos y mostrar comprobantes

## 🎯 Objetivos de Aprendizaje
- Implementar herencia y polimorfismo
- Uso de clases abstractas e interfaces
- Gestión de colecciones
- Implementación de menús interactivos
- Manejo de enums

## ✅ Criterios de Evaluación
- [ ] Estructura de carpetas correcta
- [ ] Implementación de enum TipoCategoria
- [ ] Interfaz IPrestable con todos los métodos
- [ ] Clase abstracta MaterialBiblioteca
- [ ] Tres clases hijas implementadas correctamente
- [ ] Programa principal funcional con menú
- [ ] Uso correcto de herencia y polimorfismo