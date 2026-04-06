# Retos de Programación: WinForms y Validaciones Avanzadas

Estos retos están diseñados para poner a prueba tu capacidad de manejar múltiples controles, estados complejos y lógica de validación cruzada.

---

## Reto 1: Portal de Matrícula Universitaria (Complejo)
**Objetivo:** Crear un sistema que valide si un estudiante puede matricularse en un semestre académico.

### Interfaz Requerida:
*   **Datos Personales:** `TextBox` para Nombre, Apellido, Carnet (Formato: AA-0000) y Correo Institucional (debe terminar en `@universidad.edu`).
*   **Información Académica:** `ComboBox` para Carrera, `NumericUpDown` para Promedio Acumulado (0.0 a 5.0) y `NumericUpDown` para Créditos a Matricular (1 a 22).
*   **Beca:** `CheckBox` para "Aplica a Beca" y `GroupBox` con `RadioButtons` para Tipo de Beca (Socioeconómica, Deportiva, Excelencia).
*   **Resultados:** `RichTextBox` para el desglose de costos.

### Reglas de Validación:
1.  **Formato de Carnet:** Debe empezar con dos letras seguidas de un guion y cuatro números.
2.  **Validación de Créditos:**
    *   Si el Promedio es menor a 3.5, solo puede matricular máximo 12 créditos.
    *   Si el Promedio es mayor a 4.5, puede matricular hasta 22 créditos.
    *   En cualquier otro caso, el máximo es 18.
3.  **Lógica de Beca:** Si se marca "Aplica a Beca", es obligatorio seleccionar un tipo de beca. Si el promedio es < 4.0, la beca de "Excelencia" debe estar deshabilitada.
4.  **Cálculo:** Costo por crédito = $100. La beca aplica un descuento: Socioeconómica (20%), Deportiva (15%), Excelencia (50%).

---

## Reto 2: Sistema de Cotización de Seguros de Vida
**Objetivo:** Validar perfiles de riesgo y calcular una prima mensual basándose en múltiples factores de salud.

### Interfaz Requerida:
*   **Perfil:** `TextBox` Nombre, `NumericUpDown` Edad (18 a 99), `ComboBox` Género.
*   **Salud (GroupBox):** `NumericUpDown` Peso (kg), `NumericUpDown` Estatura (cm), `CheckBox` Fumador.
*   **Antecedentes:** `CheckedListBox` con opciones (Diabetes, Hipertensión, Enfermedades Cardiacas).
*   **Botón:** "Generar Cotización".

### Reglas de Validación:
1.  **Cálculo de IMC:** Validar que el IMC (Peso / Altura^2) esté en un rango razonable. Si el IMC es > 35 (Obesidad Clase II), mostrar una advertencia de "Recargo por Riesgo".
2.  **Restricción de Edad:** Si la persona tiene > 75 años, no puede contratar el seguro (mostrar mensaje de error).
3.  **Lógica de Fumador:** Si es fumador y tiene > 50 años, la prima base aumenta un 30%.
4.  **Validación de Antecedentes:** Si se marcan más de 2 enfermedades en el `CheckedListBox`, se debe pedir una "Aprobación Médica Especial" (usar un Label de advertencia).

---

## Reto 3: Procesador de Órdenes de Compra (E-commerce)
**Objetivo:** Simular la validación de un carrito de compras y datos de pago.

### Interfaz Requerida:
*   **Cliente:** `TextBox` Nombre, `TextBox` Dirección de Envío.
*   **Pago (GroupBox):** `TextBox` Número de Tarjeta (16 dígitos), `ComboBox` Tipo de Tarjeta (Visa, MasterCard), `DateTimePicker` Fecha Vencimiento.
*   **Carrito:** `NumericUpDown` Cantidad de Producto, `TextBox` Precio Unitario (Solo lectura).
*   **Botón:** "Confirmar Pedido".

### Reglas de Validación:
1.  **Validación de Tarjeta:** El número de tarjeta debe tener exactamente 16 dígitos. No puede contener letras.
2.  **Fecha de Vencimiento:** La tarjeta no debe estar vencida (la fecha seleccionada debe ser mayor al mes/año actual).
3.  **Dirección:** La dirección de envío debe tener al menos 20 caracteres para considerarse válida.
4.  **Confirmación Final:** Al confirmar, si todo es válido, deshabilitar todos los controles para evitar cambios y mostrar un mensaje de "Pedido Procesado Exitosamente" con un código de rastreo aleatorio.

---

### Tips de Senior
*   Implementa una función `LimpiarErrores()` que recorra el formulario.
*   Usa el método `.Focus()` para llevar al usuario al primer control que falló la validación.
*   Prueba casos "borde" (ej. justo 3.5 de promedio, o la fecha de hoy en la tarjeta).

validacion
