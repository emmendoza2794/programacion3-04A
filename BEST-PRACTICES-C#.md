# Mejores Prácticas en C# — Guía de Estilo y Convenciones

Para mantener la consistencia y legibilidad en el código de **Programación III**, seguiremos las convenciones estándar de Microsoft para C#.

## 1. Convenciones de Nombres (Naming Conventions)

### PascalCase
Se usa para casi todo lo que es "público" o de alto nivel. Comienza con mayúscula y cada palabra nueva también.
- **Clases:** `public class UsuarioLoggeado`
- **Métodos:** `public void CalcularTotal()`
- **Propiedades:** `public string NombreUsuario { get; set; }`
- **Namespaces:** `namespace ProyectoConsola.GestionUsuarios`
- **Enumeraciones:** `public enum EstadoCivil`
- **Constantes:** `public const int MaximoIntentos = 3;` (A diferencia de otros lenguajes, en C# se prefiere PascalCase para constantes).

### camelCase
Se usa para elementos internos o locales. Comienza con minúscula.
- **Variables locales:** `string nombreCompleto = "";`
- **Parámetros de métodos:** `public void EnviarCorreo(string direccionDestino)`
- **Campos privados (con guion bajo):** `private int _contadorClick;`

### Interfaces
- Deben comenzar siempre con la letra **I** en mayúscula: `public interface IRepositorio`

---

## 2. Estructura y Formato de Código

### Llaves (Braces)
En C#, las llaves siempre van en una **línea nueva** (estilo Allman), no al final de la declaración.

```csharp
// CORRECTO
if (esValido)
{
    EjecutarAccion();
}

// EVITAR (Estilo Java/JS)
if (esValido) {
    EjecutarAccion();
}
```

### Espacios en blanco
- Usa un solo espacio entre operadores: `int suma = a + b;`
- Deja una línea en blanco entre métodos para mejorar la lectura.
- No uses espacios después de un paréntesis: `Calcular(a, b);` (Correcto) vs `Calcular( a, b );` (Evitar).

---

## 3. Uso de Tipos de Datos

### `var` vs Tipos Explícitos
- Usa `var` cuando el tipo sea evidente en el lado derecho:
  `var lista = new List<string>();`
- Usa el tipo explícito cuando no sea obvio:
  `int resultado = ObtenerValorMagico();`

### Strings
- Para concatenar muchas cadenas, usa `StringBuilder`.
- Para mensajes dinámicos simples, usa interpolación:
  `string mensaje = $"Hola {nombre}, bienvenido.";`

---

## 4. Comentarios y Documentación

- **Comentarios de una línea:** Úsalos para explicar el *porqué* de una lógica compleja, no el *qué* (el código debe ser auto-descriptivo).
- **Documentación XML:** Usa `///` encima de métodos públicos para generar ayuda contextual en el IDE.

```csharp
/// <summary>
/// Calcula el área de un círculo basado en su radio.
/// </summary>
/// <param name="radio">El radio del círculo.</param>
/// <returns>El área calculada.</returns>
public double CalcularArea(double radio)
{
    return Math.PI * Math.Pow(radio, 2);
}
```

---

## 5. Principios de Diseño y SOLID

El código de calidad debe ser fácil de mantener y escalar. Para lograr esto, aplicamos los principios **SOLID**:

### **S**ingle Responsibility (Responsabilidad Única)
Una clase debe tener **una sola razón para cambiar**. No mezcles lógica de base de datos con lógica de interfaz de usuario.
*Ejemplo:* No crees una clase `Empleado` que también se encargue de guardar los datos en la base de datos; crea una clase `Empleado` y otra `EmpleadoRepositorio`.

### **O**pen/Closed (Abierto/Cerrado)
Las clases deben estar **abiertas para la extensión, pero cerradas para la modificación**. Puedes agregar nuevas funcionalidades sin alterar el código existente.
*Ejemplo:* Usa interfaces o herencia para agregar nuevas formas de cálculo sin modificar el método principal.

### **L**iskov Substitution (Sustitución de Liskov)
Los objetos de una clase base deben poder ser reemplazados por objetos de sus clases derivadas sin alterar la integridad del programa.
*Ejemplo:* Si tienes una clase `Ave`, y una subclase `Pinguino`, no deberías tener un método `Volar()` en `Ave` que lance una excepción en `Pinguino`.

### **I**nterface Segregation (Segregación de Interfaces)
Es mejor tener muchas **interfaces específicas** que una sola interfaz general "gorda". Los clientes no deberían estar obligados a implementar métodos que no usan.
*Ejemplo:* En lugar de `IMultifuncional` con `Imprimir()`, `Escanear()` y `Fax()`, crea `IImpresora` e `IEscaner`.

### **D**ependency Inversion (Inversión de Dependencias)
Depende de **abstracciones (interfaces)**, no de clases concretas. Esto facilita las pruebas unitarias y el cambio de componentes.
*Ejemplo:* No instancies `LoggerService` directamente dentro de una clase; pásalo a través del constructor como una interfaz `ILogger`.

---

### Otros Principios Clave:
- **DRY (Don't Repeat Yourself):** Evita la duplicación de código. Si haces lo mismo en dos lugares, refactoriza a un método común.
- **KISS (Keep It Simple, Stupid):** No compliques la solución. El código más simple suele ser el mejor.
- **YAGNI (You Ain't Gonna Need It):** No agregues funcionalidades "por si acaso" en el futuro. Implementa solo lo que necesitas ahora.
