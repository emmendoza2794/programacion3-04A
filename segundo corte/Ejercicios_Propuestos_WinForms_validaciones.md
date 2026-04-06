# Ejercicios de Práctica: WinForms, Validación y Lógica

Este documento contiene tres ejercicios diseñados para practicar el desarrollo de interfaces gráficas en C# WinForms, enfocándose en la validación de datos, el uso de diversos controles y la implementación de lógica de negocio.

---

## Ejercicio 1: Sistema de Registro de Empleados
**Dificultad:** Intermedia  
**Enfoque:** Validaciones de formato (Regex) y cálculos básicos.

### Objetivo
Crear una interfaz para registrar empleados en una base de datos ficticia, asegurando que la información de contacto y financiera sea correcta.

### Controles Sugeridos
*   **TextBox:** `txtNombres`, `txtApellidos`, `txtEmail`, `txtIdentificacion`.
*   **NumericUpDown:** `numSueldoBase` (Mínimo: 1000, Máximo: 10000).
*   **ComboBox:** `cmbDepartamento` (Ventas, IT, Recursos Humanos, Contabilidad).
*   **Label:** `lblResultadoSueldo` (Para mostrar el sueldo neto).
*   **Button:** `btnRegistrar`, `btnLimpiar`.

### Reglas de Validación
1.  **Campos Obligatorios:** Todos los campos de texto deben estar llenos.
2.  **Formato de Email:** Validar que el texto en `txtEmail` contenga un `@` y un `.` (usar `System.Text.RegularExpressions`).
3.  **Identificación:** El campo `txtIdentificacion` debe contener exactamente 10 dígitos numéricos.
4.  **Lógica de Negocio:** Al presionar "Registrar", si los datos son válidos, calcular el **Sueldo Neto** restando un 10% de retención de impuestos al sueldo base. Mostrar el resultado en un Label con formato de moneda.

---

## Ejercicio 2: Gestión de Inventario de Productos
**Dificultad:** Intermedia+  
**Enfoque:** Estados de controles (`Enabled`), RadioButtons y validación cruzada.

### Objetivo
Desarrollar un formulario para la entrada de nuevos productos al inventario, con controles condicionales según el tipo de producto.

### Controles Sugeridos
*   **TextBox:** `txtCodigo` (Debe seguir el patrón "PROD-0000"), `txtNombreProducto`.
*   **ComboBox:** `cmbCategoria` (Electrónica, Alimentos, Ropa).
*   **NumericUpDown:** `numStockInicial`, `numStockMinimo`.
*   **GroupBox (IVA):** Contiene 3 `RadioButton`: `rbExento` (0%), `rbGeneral` (19%), `rbReducido` (5%).
*   **CheckBox:** `chkEsPerecedero`.
*   **DateTimePicker:** `dtpFechaVencimiento` (Debe estar deshabilitado por defecto).

### Reglas de Validación
1.  **Código de Producto:** Validar que el código comience con el prefijo "PROD-".
2.  **Validación Cruzada:** El `numStockInicial` no puede ser menor al `numStockMinimo`.
3.  **Lógica de Interfaz:** El `dtpFechaVencimiento` solo debe habilitarse (`Enabled = true`) si el `chkEsPerecedero` está marcado.
4.  **Selección de IVA:** Asegurarse de que al menos un `RadioButton` de IVA esté seleccionado antes de procesar.

---

## Ejercicio 3: Sistema de Reserva de Hotel
**Dificultad:** Avanzada  
**Enfoque:** Lógica de fechas, manipulación de colecciones y resúmenes de texto.

### Objetivo
Simular un sistema de reservas donde se calcule el costo total de la estancia basándose en fechas, número de personas y servicios adicionales.

### Controles Sugeridos
*   **TextBox:** `txtCliente`.
*   **DateTimePicker:** `dtpEntrada`, `dtpSalida`.
*   **NumericUpDown:** `numPersonas` (Rango 1 a 4).
*   **CheckedListBox:** `clbServicios` (Items: WiFi Premium, Desayuno Buffet, Estacionamiento, Spa).
*   **RichTextBox:** `rtbResumen` (Propiedad `ReadOnly = true`).
*   **Button:** `btnCalcularReserva`.

### Reglas de Validación
1.  **Validación de Fechas:** 
    *   La fecha de entrada no puede ser anterior a la fecha actual (`DateTime.Today`).
    *   La fecha de salida debe ser al menos un día posterior a la fecha de entrada.
2.  **Cálculo de Estancia:** Determinar el número de días totales de la estancia usando `TimeSpan`.
3.  **Lógica de Costos:**
    *   Costo base por noche: $50 USD.
    *   Costo por persona adicional: $15 USD (a partir de la segunda persona).
    *   Cada servicio seleccionado en el `CheckedListBox` suma $10 USD diarios al total.
4.  **Resultado Final:** Al validar, el `rtbResumen` debe mostrar un desglose:
    ```text
    --- RESUMEN DE RESERVA ---
    Cliente: [Nombre]
    Estancia: [Días] noches.
    Personas: [Cant]
    Servicios: [Lista de servicios marcados]
    --------------------------
    TOTAL A PAGAR: $[Monto]
    ```

---

### Tips para la Implementación
*   Usa el evento `Validating` de los controles para validaciones individuales.
*   Usa un `ErrorProvider` para mostrar iconos de advertencia junto a los campos con error.
* Recuerda limpiar los campos de error cada vez que se inicie una nueva validación.

validacion
