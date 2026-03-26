# Ejercicios de Programación Orientada a Objetos (POO) — Programación III

Esta guía contiene ejercicios avanzados de POO para fortalecer los conceptos de **Clases, Herencia, Polimorfismo, Encapsulamiento e Interfaces**.

---

## 1. Sistema de Gestión de Nómina (Herencia y Polimorfismo)
**Objetivo:** Implementar una jerarquía de clases para calcular salarios.

- Crea una clase base `Empleado` con propiedades `Nombre` y `SalarioBase`.
- Define un método virtual `CalcularSalario()`.
- Crea una clase `Gerente` que herede de `Empleado` y añada un `BonoFijo`. Sobrescribe `CalcularSalario()` para sumar el bono.
- Crea una clase `Vendedor` que herede de `Empleado` y añada `Comision` y `VentasRealizadas`. Sobrescribe `CalcularSalario()` para sumar la comisión por cada venta.
- **Reto:** En el `Main`, crea una lista de `Empleado` que contenga gerentes y vendedores, y recorre la lista imprimiendo el nombre y salario final de cada uno.

## 2. Simulador de Cuentas Bancarias (Encapsulamiento y Abstracción)
**Objetivo:** Proteger los datos sensibles y definir comportamientos base.

- Crea una clase abstracta `CuentaBancaria` con una propiedad `Saldo` (solo lectura desde fuera, modificable internamente) y un método abstracto `Retirar(decimal monto)`.
- Implementa `CuentaAhorros`: No permite sobregiros (el saldo no puede ser negativo).
- Implementa `CuentaCorriente`: Permite un sobregiro de hasta $500.
- **Reto:** Agrega un método `Depositar(decimal monto)` en la clase base y asegúrate de que no se puedan depositar valores negativos.

## 3. Sistema de Notificaciones (Interfaces)
**Objetivo:** Utilizar contratos para desacoplar el código.

- Crea una interfaz `INotificable` con un método `Enviar(string mensaje)`.
- Implementa la interfaz en tres clases: `EmailNotificador`, `SmsNotificador` y `WhatsappNotificador`. Cada una debe imprimir en consola un mensaje simulando el envío (ej: "Enviando Email: [mensaje]").
- Crea una clase `ServicioAlCliente` que tenga un método `NotificarTodo(string msg, List<INotificable> medios)`.
- **Reto:** Haz que el usuario elija qué medios de notificación desea activar antes de enviar el mensaje.

## 4. Juego de Batalla RPG (Abstracción y Polimorfismo)
**Objetivo:** Modelar personajes con comportamientos únicos.

- Crea una clase abstracta `Personaje` con `Nombre`, `Vida` y un método abstracto `Atacar()`.
- Crea la clase `Guerrero`: Su ataque quita 20 de vida y tiene un mensaje de "Grito de guerra".
- Crea la clase `Mago`: Su ataque quita 15 de vida pero consume "Maná" (una nueva propiedad).
- Crea la clase `Arquero`: Tiene una probabilidad de "Crítico" que duplica el daño.
- **Reto:** Crea un método `RecibirDanio(int cantidad)` y haz que un personaje muera si su vida llega a 0.

## 5. Tienda de Computadoras (Composición)
**Objetivo:** Entender cómo los objetos se componen de otros objetos.

- Crea una clase `Componente` con `Nombre` y `Precio`.
- Crea una clase `Computadora` que tenga una `List<Componente>`.
- Agrega métodos a `Computadora` para `AgregarComponente(Componente c)` y `MostrarResumen()`.
- `MostrarResumen()` debe listar todos los componentes y mostrar el precio total de la computadora.
- **Reto:** Implementa un límite de componentes (ej: máximo 2 memorias RAM) para practicar la lógica de validación dentro de la clase.

---

### Recomendaciones Técnicas:
1.  **Uso de `override` y `virtual`:** Recuerda que para sobrescribir un método, el padre debe marcarlo como `virtual` o `abstract`.
2.  **Propiedades Auto-implementadas:** Usa `public decimal Saldo { get; private set; }` para proteger el acceso.
3.  **Listas Genéricas:** Utiliza `System.Collections.Generic` para manejar grupos de objetos.
4.  **Constructores:** Asegúrate de inicializar las propiedades importantes al crear los objetos.
