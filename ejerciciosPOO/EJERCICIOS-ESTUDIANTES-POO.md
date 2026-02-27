# Guía de Ejercicios: Clases y Métodos en C# — Programación III

Esta guía contiene 10 ejercicios enfocados en la creación de Clases, el uso de Propiedades y la implementación de Métodos de negocio que requieren interacción constante con el usuario.

---

## 1. Simulador de Cajero Automático (Clase Cuenta)
**Objetivo:** Crear una clase que gestione el dinero de un usuario.
- **Clase:** `CuentaBancaria`.
- **Propiedades:** `Titular` (string) y `Saldo` (decimal).
- **Métodos:** 
    - `ConsultarSaldo()`: Muestra el saldo actual.
    - `Depositar(decimal cantidad)`: Suma al saldo (validar que la cantidad sea positiva).
    - `Retirar(decimal cantidad)`: Resta al saldo (validar que tenga fondos suficientes).
- **Interacción:** El usuario debe ingresar su nombre al inicio y luego elegir opciones de un menú para depositar o retirar dinero repetidamente.

## 2. Control de Inventario (Clase Producto)
**Objetivo:** Gestionar la entrada y salida de mercancía.
- **Clase:** `Producto`.
- **Propiedades:** `Nombre`, `Codigo`, `Precio` y `CantidadStock`.
- **Métodos:**
    - `AgregarStock(int cantidad)`: Aumenta el inventario.
    - `VenderProducto(int cantidad)`: Disminuye el inventario y devuelve el total de la venta (Precio * Cantidad).
    - `MostrarInfo()`: Muestra todos los detalles del producto.
- **Interacción:** El usuario ingresa los datos de un producto y luego decide cuántas unidades "entran" al almacén y cuántas se "venden".

## 3. Calculadora de Calificaciones (Clase Estudiante)
**Objetivo:** Procesar las notas de un alumno.
- **Clase:** `Estudiante`.
- **Propiedades:** `Nombre`, `Materia` y una lista o arreglo de `Notas` (3 parciales).
- **Métodos:**
    - `CalcularPromedio()`: Devuelve el promedio de las 3 notas.
    - `EstadoFinal()`: Devuelve "Aprobado" si el promedio es >= 3.0 o "Reprobado" de lo contrario.
- **Interacción:** El usuario ingresa el nombre del estudiante, la materia y las 3 notas una por una. Al final, el programa muestra el promedio y el estado.

## 4. Gestión de Viajes (Clase Vehiculo)
**Objetivo:** Calcular el consumo de combustible de un auto.
- **Clase:** `Vehiculo`.
- **Propiedades:** `Modelo`, `CapacidadTanque` (litros) y `Rendimiento` (km por litro).
- **Métodos:**
    - `CalcularAutonomia()`: Devuelve cuántos km puede recorrer con el tanque lleno.
    - `NecesitaCombustible(double distancia)`: Devuelve `true` si la distancia ingresada supera la autonomía actual.
- **Interacción:** El usuario ingresa los datos técnicos de su auto y luego ingresa una distancia de viaje (ej: 500km). El programa le dice si llega o si se queda varado.

## 5. Sistema de Ticket de Cine (Clase SalaCine)
**Objetivo:** Controlar la venta de asientos para una película.
- **Clase:** `SalaCine`.
- **Propiedades:** `Pelicula`, `CapacidadMaxima`, `AsientosOcupados` y `PrecioEntrada`.
- **Métodos:**
    - `VerDisponibilidad()`: Indica cuántas sillas quedan libres.
    - `ComprarEntradas(int cantidad)`: Suma a los ocupados y devuelve el costo total (validar que no supere la capacidad).
- **Interacción:** El usuario ingresa la película y la capacidad de la sala. Luego, varias personas "compran" entradas hasta que la sala se llene.

## 6. Calculadora de Salario Neto (Clase Empleado)
**Objetivo:** Aplicar deducciones de ley a un sueldo bruto.
- **Clase:** `Empleado`.
- **Propiedades:** `Nombre`, `SalarioBruto`.
- **Métodos:**
    - `CalcularSalud()`: Devuelve el 4% del salario bruto.
    - `CalcularPension()`: Devuelve el 4% del salario bruto.
    - `ObtenerSalarioNeto()`: Devuelve el salario final restando salud y pensión.
- **Interacción:** El usuario ingresa su nombre y su sueldo mensual. El programa le muestra el desglose de cuánto se le quita y cuánto recibe en mano.

## 7. Registro de Salud (Clase Persona)
**Objetivo:** Calcular el Índice de Masa Corporal (IMC).
- **Clase:** `Persona`.
- **Propiedades:** `Nombre`, `Peso` (kg) y `Estatura` (metros).
- **Métodos:**
    - `CalcularIMC()`: Devuelve `Peso / (Estatura * Estatura)`.
    - `Diagnostico()`: Según el IMC, devuelve si está en "Peso Bajo", "Normal" u "Obesidad".
- **Interacción:** El usuario ingresa sus datos físicos y el programa le da su reporte de salud personalizado.

## 8. Generador de Facturas (Clase Factura)
**Objetivo:** Calcular el total de una compra con impuestos.
- **Clase:** `Factura`.
- **Propiedades:** `NombreCliente`, `Subtotal`.
- **Métodos:**
    - `CalcularIVA()`: Devuelve el 19% del subtotal.
    - `CalcularTotal()`: Suma subtotal + IVA.
    - `AplicarDescuento(decimal porcentaje)`: Resta un valor al total final.
- **Interacción:** El usuario ingresa el nombre del cliente y el valor de su compra. Luego, puede elegir ingresar un cupón de descuento (ej: 10%) para ver el nuevo total.

## 9. Cronómetro de Tareas (Clase Tarea)
**Objetivo:** Medir el tiempo dedicado a una actividad.
- **Clase:** `Tarea`.
- **Propiedades:** `Descripcion`, `TiempoEstimado` (minutos) y `TiempoReal`.
- **Métodos:**
    - `RegistrarAvance(int minutos)`: Suma tiempo al `TiempoReal`.
    - `DiferenciaTiempo()`: Devuelve si el usuario tardó más o menos de lo estimado.
- **Interacción:** El usuario describe su tarea y cuánto cree que tardará. Conforme trabaja, va ingresando "bloques" de tiempo hasta terminar.

## 10. Validador de Usuarios (Clase CuentaUsuario)
**Objetivo:** Simular un inicio de sesión básico.
- **Clase:** `CuentaUsuario`.
- **Propiedades:** `Username`, `Password`.
- **Métodos:**
    - `CambiarPassword(string nuevaPass)`: Actualiza la contraseña (validar que tenga al menos 8 caracteres).
    - `Login(string user, string pass)`: Devuelve `true` si coinciden con las propiedades.
- **Interacción:** El usuario crea su cuenta y luego el programa le pide "loguearse" pidiéndole los datos de nuevo por consola.

---

### Recomendaciones:
- En cada ejercicio, utiliza un **constructor** para inicializar los datos principales.
- Asegúrate de que los métodos realicen **validaciones** (ej: no permitir depósitos de $0 o menos).
- Usa `Console.WriteLine()` para que los resultados sean claros y fáciles de leer para el estudiante.
