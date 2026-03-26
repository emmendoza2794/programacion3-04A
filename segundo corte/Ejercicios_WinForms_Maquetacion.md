# Guía de Ejercicios: Maquetación y Componentes en Windows Forms

**Objetivo:** Practicar el diseño de interfaces gráficas (GUI) utilizando los componentes del Toolbox de Visual Studio, enfocándose en la organización visual, el uso de contenedores y las propiedades de los controles.

---

## Ejercicio 1: Formulario de Perfil "Mi Cuenta"
**Concepto:** Aprender a agrupar información relacionada y usar controles de selección única.

### Requerimientos visuales:
1.  **Contenedor Principal:** Un `GroupBox` con el texto "Información Personal".
2.  **Entradas de Texto:** 
    *   `Labels` y `TextBoxes` para: Nombre, Apellido y Correo Electrónico.
    *   Un `MaskedTextBox` para el Teléfono (Formato: `(999) 000-0000`).
3.  **Selección de Género:** Un sub-contenedor (`Panel` o `GroupBox` pequeño) que contenga 3 `RadioButtons`: Masculino, Femenino, Otro.
4.  **Botón de Acción:** Un `Button` al final que diga "Guardar Cambios".

> **Reto de Maquetación:** Alinea todos los `Labels` a la izquierda y los `TextBoxes` a la derecha de forma simétrica.

---

## Ejercicio 2: Panel de Configuración con Pestañas
**Concepto:** Organizar interfaces complejas usando pestañas (`TabControl`).

### Requerimientos visuales:
1.  **Control Principal:** Un `TabControl` con dos pestañas (Tabs): "Apariencia" y "Notificaciones".
2.  **Pestaña Apariencia:**
    *   Un `Label` que diga "Tema del Sistema".
    *   Un `ComboBox` con las opciones: Claro, Oscuro, Azul Cobalto.
    *   Un `CheckBox` que diga "Activar animaciones de ventana".
3.  **Pestaña Notificaciones:**
    *   Tres `CheckBoxes`: "Recibir correos", "Alertas de escritorio", "Sonidos de sistema".
    *   Un `NumericUpDown` para configurar el "Volumen de alerta" (Rango 0-100).

---

## Ejercicio 3: Interfaz de Reproductor de Música
**Concepto:** Uso de imágenes, barras de progreso y posicionamiento (`Anchor`/`Dock`).

### Requerimientos visuales:
1.  **Imagen de Álbum:** Un `PictureBox` centrado (Propiedad `SizeMode = StretchImage`) con una imagen de ejemplo.
2.  **Información de Pista:** Dos `Labels` debajo de la imagen; uno en **Negrita** (Título) y otro en tamaño más pequeño (Artista).
3.  **Progreso:** Un `ProgressBar` que simule el avance de la canción (pon la propiedad `Value` en 45 para que se vea algo de progreso).
4.  **Controles:** Tres `Buttons` alineados horizontalmente con los textos: `<<`, `Play`, `>>`.

> **Reto de Maquetación:** Usa la propiedad `Anchor` en los botones para que siempre queden centrados si se estira la ventana.

---

## Ejercicio 4: Teclado de Calculadora (Grid Layout)
**Concepto:** Alineación precisa de múltiples botones.

### Requerimientos visuales:
1.  **Pantalla:** Un `TextBox` en la parte superior, con texto alineado a la derecha (`TextAlign = Right`), fuente grande (ej. 18pt) y que sea de solo lectura (`ReadOnly = true`).
2.  **Botones Numéricos:** 10 botones (0-9) organizados en una cuadrícula.
3.  **Operadores:** Botones para `+`, `-`, `*`, `/` y `=`.
4.  **Estilo:** Cambia el `BackColor` de los botones de números a un color claro y los de operaciones a un color más llamativo (ej. Naranja o Gris Oscuro).

---

## Ejercicio 5: Catálogo de Producto (E-commerce)
**Concepto:** Crear una "tarjeta" de producto con jerarquía visual.

### Requerimientos visuales:
1.  **Contenedor:** Un `Panel` con un borde visible (`BorderStyle = FixedSingle`).
2.  **Encabezado:** Un `Label` con el nombre del producto (ej: "Monitor Gamer 24\"") con fuente tamaño 14 y color azul.
3.  **Descripción:** Un `TextBox` multilínea (`Multiline = true`) con un texto descriptivo corto, sin bordes y bloqueado para que no se pueda escribir.
4.  **Precio:** Un `Label` que diga "$299.99" en color verde y fuente grande.
5.  **Compra:** 
    *   Un `NumericUpDown` para elegir la "Cantidad".
    *   Un `Button` con el texto "Añadir al carrito" y un color de fondo verde.

---

## Sugerencias para el estudiante:
*   **Propiedad Name:** Cambia el nombre de los controles importantes (ej: `btnGuardar`, `txtNombre`).
*   **Propiedad FlatStyle:** Prueba cambiarla en los botones para darles un aspecto más moderno.
*   **Propiedad Cursor:** Cambia el cursor a `Hand` cuando pases sobre los botones.
