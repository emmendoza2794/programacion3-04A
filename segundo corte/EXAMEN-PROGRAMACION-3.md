# Examen Parcial #1 — Programación 3 (Variante 1)
<small>**Estudiante:** __________________________________________________________________ **Grupo:** ________ **Fecha:** __________</small>
<br><small>**Temas:** Clases, Interfaces, Enums, Manejo de Archivos (CSV) y DateTime.</small>

<table style="width: 100%; border-collapse: collapse; font-size: 0.85em;">
<tr>
<td style="width: 50%; vertical-align: top; border-right: 1px solid #ccc; padding-right: 15px;">

### Ejercicio 1: Inventario "AutoPartes Express" (3.0 Puntos)
**Objetivo:** Gestionar el inventario de repuestos usando persistencia en CSV.

**¿Qué debes hacer?**
1. **Modelado:** Crea un `Enum` `Categoria` (Motor, Frenos, Suspensión) y una `Interface` `IGestionable` con los métodos para operaciones **CRUD** (Crear, Leer, Actualizar y Eliminar).
2. **Clase:** Implementa la clase `Repuesto` con propiedades para `Id` (int), `Nombre` (string), `Precio` (double) y `Categoria`.
3. **Archivos:** Implementa la persistencia en un archivo `inventario.csv`. Los datos deben cargarse al iniciar el programa y guardarse al realizar cambios.
4. **Menú:** Un menú interactivo que permita: **1. Crear, 2. Listar, 3. Modificar, 4. Eliminar**.

**Ejemplo de Consola:**
```text
1. Crear | 2. Listar | 3. Modificar | 4. Eliminar
>> Seleccione: 1
ID: 101 | Nombre: Pastillas | $45.50 | Frenos
[SUCCESS] Guardado en inventario.csv
```
**Nota Ejercicio 1: ______ / 3.0**
</td>
<td style="width: 50%; vertical-align: top; padding-left: 15px;">

### Ejercicio 2: Simulador de Crédito "TuBanco" (2.0 Puntos)
**Objetivo:** Calcular la tabla de amortización de un préstamo personal.

**¿Qué debes hacer?**
1. **Entrada:** Solicite al usuario el **monto del préstamo**, la **tasa de interés mensual (%)** y el **plazo en meses**.
2. **Cálculo:** Calcule la cuota mensual y desglose cuánto va a capital y cuánto a interés mes a mes.
3. **Salida:** Muestra una tabla con: **# Mes**, **Fecha de Pago** (incrementando un mes desde hoy con `DateTime`), **Abono a Capital**, **Interés** y **Saldo**.
4. **Resumen:** Al finalizar la tabla, muestre el **Total Pagado** y el **Total de Intereses** acumulados durante el crédito.

**Ejemplo de Consola:**
```text
Monto: $1000 | Interés: 2% | Meses: 12
--- TABLA DE PAGOS ---
Mes 1 | 19/04/2026 | Cap: $75.23 | Int: $20.00
...
Total Pagado: $1,134.72 | Intereses: $134.72
```
**Nota Ejercicio 2: ______ / 2.0**
</td>
</tr>
</table>

<small>
<b>Instrucciones:</b> 1. Use <code>Console.ReadLine()</code>. 2. Implemente la lógica de persistencia usando la clase <code>File</code>. 3. Comente su código.
<br><b>ADVERTENCIA:</b> Estudiante detectado hablando, consultando internet o usando IA tendrá un "bono extra" de <b>-0.5</b> en la nota definitiva.
</small>

```csharp
while(!aprobado) { 
  estudiar(); 
  practicar(); 
  if(error) depurar(); 
} // "La perseverancia es el algoritmo de la genialidad"
```
