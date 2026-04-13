# Guía de Conceptos Clave - Semana 8: Programación III

**Tema:** Aplicaciones GUI con Windows Forms — Objetos Contenedores

Los **contenedores** son controles especiales cuyo propósito principal es **alojar y organizar otros controles** dentro de un formulario. Usarlos correctamente es lo que separa una interfaz caótica de una aplicación profesional y usable.

---

## 1. ¿Por qué usar Contenedores?

Sin contenedores, todos los controles de un `Form` son "hermanos" al mismo nivel: no hay jerarquía, ni agrupación visual, ni comportamiento de redimensionado coherente.

Con contenedores puedes:
- **Agrupar** controles relacionados semánticamente (ej. "Datos del Cliente").
- **Ocultar/mostrar** secciones enteras de la interfaz con una sola línea de código.
- **Lograr layouts responsivos** que se adapten cuando el usuario cambia el tamaño de la ventana.
- **Reutilizar** secciones de interfaz como `UserControl`.

---

## 2. GroupBox — Agrupación Visual con Título

El `GroupBox` dibuja un **borde con un título** alrededor de los controles que contiene. Es el contenedor más intuitivo: el usuario entiende de inmediato que los controles dentro están relacionados.

**Propiedades clave:**
- `Text`: El título que aparece en el borde superior.
- `Enabled`: Deshabilitar el `GroupBox` deshabilita **todos** sus controles hijos de golpe.

<div style="font-family: 'Segoe UI', sans-serif; background: #f0f0f0; padding: 20px; border-radius: 4px; max-width: 500px;">
  <p style="margin: 0 0 10px 0; font-size: 13px; color: #333; font-style: italic;">Vista previa — Formulario con GroupBox:</p>
  <div style="background: #f0f0f0; border: 1px solid #999; border-radius: 2px; padding: 8px;">
    <!-- Barra de título del form -->
    <div style="background: linear-gradient(to bottom, #4a90d9, #3070b8); color: white; padding: 4px 8px; font-size: 12px; border-radius: 2px 2px 0 0; display: flex; justify-content: space-between; margin: -8px -8px 8px -8px;">
      <span>FormRegistro</span>
      <span style="font-size: 10px;">─ □ ✕</span>
    </div>
    <!-- GroupBox: Datos Personales -->
    <fieldset style="border: 1px solid #777; border-radius: 3px; padding: 10px 12px; margin-bottom: 10px; background: #f5f5f5;">
      <legend style="font-size: 12px; color: #333; padding: 0 4px; font-weight: bold;">Datos Personales</legend>
      <div style="display: flex; align-items: center; margin-bottom: 6px; gap: 8px;">
        <label style="font-size: 12px; width: 80px; color: #333;">Nombre:</label>
        <input type="text" value="María García" style="font-size: 12px; border: 1px solid #999; border-radius: 2px; padding: 2px 5px; width: 160px; background: white;" readonly />
      </div>
      <div style="display: flex; align-items: center; gap: 8px;">
        <label style="font-size: 12px; width: 80px; color: #333;">Teléfono:</label>
        <input type="text" value="301 555 0120" style="font-size: 12px; border: 1px solid #999; border-radius: 2px; padding: 2px 5px; width: 160px; background: white;" readonly />
      </div>
    </fieldset>
    <!-- GroupBox: Preferencias -->
    <fieldset style="border: 1px solid #777; border-radius: 3px; padding: 10px 12px; margin-bottom: 10px; background: #f5f5f5;">
      <legend style="font-size: 12px; color: #333; padding: 0 4px; font-weight: bold;">Preferencias</legend>
      <div style="display: flex; gap: 16px;">
        <label style="font-size: 12px; display: flex; align-items: center; gap: 4px; color: #333;"><input type="radio" name="r" checked readonly /> Colombiano</label>
        <label style="font-size: 12px; display: flex; align-items: center; gap: 4px; color: #333;"><input type="radio" name="r" readonly /> Extranjero</label>
      </div>
    </fieldset>
    <!-- Botón -->
    <div style="text-align: right;">
      <button style="font-size: 12px; background: #e1e1e1; border: 1px solid #999; border-radius: 2px; padding: 4px 16px; cursor: default;">Guardar</button>
    </div>
  </div>
</div>

```csharp
// Deshabilitar todo el grupo con una sola instrucción
groupBoxDatosPersonales.Enabled = false;

// Cambiar el título dinámicamente
groupBoxDatosPersonales.Text = "Datos del Cliente #" + id;
```

---

## 3. Panel — Agrupación Invisible y Flexible

El `Panel` funciona igual que el `GroupBox` pero **sin borde ni título visibles**. Es el favorito para construir layouts dinámicos porque se puede mostrar, ocultar, reposicionar o cambiar de tamaño en tiempo de ejecución sin afectar la apariencia del resto del formulario.

**Propiedades clave:**
- `BorderStyle`: `None` (invisible), `FixedSingle` (línea simple), `Fixed3D` (aspecto hundido).
- `AutoScroll`: Habilita barras de desplazamiento automáticas si el contenido es más grande que el panel.
- `Dock` / `Anchor`: Esenciales para que el panel se expanda con el formulario.

<div style="font-family: 'Segoe UI', sans-serif; background: #f0f0f0; padding: 20px; border-radius: 4px; max-width: 520px;">
  <p style="margin: 0 0 10px 0; font-size: 13px; color: #333; font-style: italic;">Comparación Panel vs GroupBox:</p>
  <div style="display: flex; gap: 16px;">
    <!-- Sin Panel -->
    <div style="flex: 1;">
      <p style="font-size: 11px; text-align: center; color: #c00; margin: 0 0 4px 0; font-weight: bold;">Sin contenedores ✗</p>
      <div style="background: #f0f0f0; border: 1px solid #999; padding: 8px; border-radius: 2px; min-height: 100px; position: relative;">
        <div style="position: absolute; top: 10px; left: 8px; font-size: 11px; border: 1px solid #bbb; padding: 2px 5px; background: white; width: 90px;">TextBox</div>
        <div style="position: absolute; top: 35px; left: 50px; font-size: 11px; border: 1px solid #bbb; padding: 2px 5px; background: white; width: 70px;">TextBox</div>
        <div style="position: absolute; top: 60px; left: 20px; font-size: 11px; border: 1px solid #bbb; padding: 2px 5px; background: #e1e1e1; width: 60px; text-align:center;">Button</div>
        <div style="position: absolute; top: 15px; left: 120px; font-size: 11px; border: 1px solid #bbb; padding: 2px 5px; background: white; width: 55px;">TextBox</div>
        <div style="position: absolute; top: 55px; left: 110px; font-size: 11px; border: 1px solid #bbb; padding: 2px 5px; background: #e1e1e1; width: 60px; text-align:center;">Button</div>
      </div>
    </div>
    <!-- Con Panel -->
    <div style="flex: 1;">
      <p style="font-size: 11px; text-align: center; color: #060; margin: 0 0 4px 0; font-weight: bold;">Con Panel ✓</p>
      <div style="background: #f0f0f0; border: 1px solid #999; padding: 8px; border-radius: 2px; min-height: 100px;">
        <div style="border: 1px solid #bbb; padding: 6px; margin-bottom: 6px; background: #fafafa; border-radius: 2px;">
          <div style="font-size: 10px; color: #666; margin-bottom: 3px;">Panel A — Búsqueda</div>
          <div style="font-size: 11px; border: 1px solid #bbb; padding: 2px 5px; background: white; display: inline-block; margin-right: 4px;">TextBox</div>
          <div style="font-size: 11px; border: 1px solid #bbb; padding: 2px 5px; background: #e1e1e1; display: inline-block;">Buscar</div>
        </div>
        <div style="border: 1px solid #bbb; padding: 6px; background: #fafafa; border-radius: 2px;">
          <div style="font-size: 10px; color: #666; margin-bottom: 3px;">Panel B — Resultado</div>
          <div style="font-size: 11px; border: 1px solid #bbb; padding: 2px 5px; background: white; display: inline-block;">Label resultado</div>
        </div>
      </div>
    </div>
  </div>
</div>

```csharp
// Mostrar/ocultar una sección de la interfaz (ej. al presionar un CheckBox)
private void chkMostrarOpciones_CheckedChanged(object sender, EventArgs e)
{
    panelOpciones.Visible = chkMostrarOpciones.Checked;
}
```

---

## 4. TabControl — Organización en Pestañas

El `TabControl` es fundamental cuando tienes **mucha información** que no cabe en una sola pantalla. Contiene `TabPage`, que son los "paneles" dentro de cada pestaña.

**Propiedades clave:**
- `TabPages`: Colección de las pestañas (se administra desde el diseñador o por código).
- `SelectedIndex` / `SelectedTab`: Permite navegar a una pestaña específica por código.
- `Alignment`: Posición de las pestañas (`Top`, `Bottom`, `Left`, `Right`).

<div style="font-family: 'Segoe UI', sans-serif; background: #f0f0f0; padding: 20px; border-radius: 4px; max-width: 480px;">
  <p style="margin: 0 0 10px 0; font-size: 13px; color: #333; font-style: italic;">Vista previa — TabControl con 3 pestañas:</p>
  <div style="background: #f0f0f0; border: 1px solid #999; border-radius: 2px; padding: 8px;">
    <div style="background: linear-gradient(to bottom, #4a90d9, #3070b8); color: white; padding: 4px 8px; font-size: 12px; border-radius: 2px 2px 0 0; display: flex; justify-content: space-between; margin: -8px -8px 8px -8px;">
      <span>FormCliente</span>
      <span style="font-size: 10px;">─ □ ✕</span>
    </div>
    <!-- Tab headers -->
    <div style="display: flex; gap: 0; margin-bottom: -1px; position: relative; z-index: 1;">
      <div style="background: #f5f5f5; border: 1px solid #999; border-bottom: 1px solid #f5f5f5; padding: 4px 14px; font-size: 12px; border-radius: 3px 3px 0 0; color: #333; font-weight: bold;">Datos</div>
      <div style="background: #ddd; border: 1px solid #999; border-left: none; padding: 4px 14px; font-size: 12px; border-radius: 3px 3px 0 0; color: #666;">Pedidos</div>
      <div style="background: #ddd; border: 1px solid #999; border-left: none; padding: 4px 14px; font-size: 12px; border-radius: 3px 3px 0 0; color: #666;">Notas</div>
    </div>
    <!-- Tab content -->
    <div style="border: 1px solid #999; background: #f5f5f5; padding: 12px; border-radius: 0 3px 3px 3px;">
      <div style="display: flex; align-items: center; margin-bottom: 8px; gap: 8px;">
        <label style="font-size: 12px; width: 70px; color: #333;">Nombre:</label>
        <input type="text" value="Carlos Pérez" style="font-size: 12px; border: 1px solid #999; padding: 2px 5px; width: 160px; background: white;" readonly />
      </div>
      <div style="display: flex; align-items: center; margin-bottom: 8px; gap: 8px;">
        <label style="font-size: 12px; width: 70px; color: #333;">Email:</label>
        <input type="text" value="c.perez@mail.com" style="font-size: 12px; border: 1px solid #999; padding: 2px 5px; width: 160px; background: white;" readonly />
      </div>
      <div style="display: flex; align-items: center; gap: 8px;">
        <label style="font-size: 12px; width: 70px; color: #333;">Ciudad:</label>
        <select style="font-size: 12px; border: 1px solid #999; padding: 2px 5px; width: 165px; background: white;">
          <option>Valledupar</option>
        </select>
      </div>
    </div>
  </div>
</div>

```csharp
// Navegar a la segunda pestaña (índice 1) por código
tabControl1.SelectedIndex = 1;

// Agregar una nueva pestaña dinámicamente
TabPage nuevaPestana = new TabPage("Historial");
tabControl1.TabPages.Add(nuevaPestana);

// Deshabilitar una pestaña (el usuario la ve pero no puede hacer clic)
tabControl1.TabPages[2].Enabled = false;
```

---

## 5. SplitContainer — División Redimensionable

El `SplitContainer` divide el formulario en **dos paneles** (`Panel1` y `Panel2`) separados por una barra divisoria (`Splitter`) que el usuario puede arrastrar. Es muy común en aplicaciones tipo explorador (árbol a la izquierda, detalle a la derecha).

**Propiedades clave:**
- `Orientation`: `Vertical` (división izquierda/derecha) u `Horizontal` (arriba/abajo).
- `SplitterDistance`: Posición de la barra divisoria en píxeles.
- `FixedPanel`: Fija uno de los paneles para que no cambie de tamaño al redimensionar el form.
- `IsSplitterFixed`: Bloquea la barra para que el usuario no pueda moverla.

<div style="font-family: 'Segoe UI', sans-serif; background: #f0f0f0; padding: 20px; border-radius: 4px; max-width: 500px;">
  <p style="margin: 0 0 10px 0; font-size: 13px; color: #333; font-style: italic;">Vista previa — SplitContainer (Vertical):</p>
  <div style="background: #f0f0f0; border: 1px solid #999; border-radius: 2px; overflow: hidden;">
    <div style="background: linear-gradient(to bottom, #4a90d9, #3070b8); color: white; padding: 4px 8px; font-size: 12px; display: flex; justify-content: space-between;">
      <span>FormExplorador</span>
      <span style="font-size: 10px;">─ □ ✕</span>
    </div>
    <div style="display: flex; height: 130px;">
      <!-- Panel1 -->
      <div style="width: 38%; background: #fafafa; border-right: 4px solid #c0c0c0; padding: 6px; overflow: hidden;">
        <div style="font-size: 11px; font-weight: bold; color: #555; margin-bottom: 4px;">Panel1 — Árbol</div>
        <div style="font-size: 11px; color: #333; padding-left: 4px;">📁 Clientes</div>
        <div style="font-size: 11px; color: #333; padding-left: 16px; background: #cce4ff; border-radius: 2px;">📄 García, M.</div>
        <div style="font-size: 11px; color: #333; padding-left: 16px;">📄 Pérez, C.</div>
        <div style="font-size: 11px; color: #333; padding-left: 4px;">📁 Proveedores</div>
      </div>
      <!-- Splitter hint -->
      <div style="width: 4px; background: #c0c0c0; cursor: col-resize; display: flex; align-items: center; justify-content: center;">
        <div style="width: 2px; height: 20px; background: #888; border-radius: 1px;"></div>
      </div>
      <!-- Panel2 -->
      <div style="flex: 1; background: white; padding: 8px;">
        <div style="font-size: 11px; font-weight: bold; color: #555; margin-bottom: 6px;">Panel2 — Detalle</div>
        <div style="font-size: 11px; color: #333; margin-bottom: 3px;"><b>Nombre:</b> María García</div>
        <div style="font-size: 11px; color: #333; margin-bottom: 3px;"><b>Tel:</b> 301 555 0120</div>
        <div style="font-size: 11px; color: #333;"><b>Ciudad:</b> Valledupar</div>
      </div>
    </div>
  </div>
  <p style="font-size: 11px; color: #777; margin: 6px 0 0 0; text-align: center;">↔ La barra gris del centro es arrastrable por el usuario</p>
</div>

```csharp
// Posicionar la barra al 30% del ancho del form
splitContainer1.SplitterDistance = (int)(this.Width * 0.30);

// Fijar Panel1 para que no cambie de tamaño al maximizar el form
splitContainer1.FixedPanel = FixedPanel.Panel1;
```

---

## 6. FlowLayoutPanel — Flujo Automático

El `FlowLayoutPanel` organiza sus controles hijos automáticamente en **filas o columnas**, como si fueran palabras en un texto. Cuando un control no cabe en la fila actual, se pasa a la siguiente. Ideal para conjuntos de botones o etiquetas de tamaño variable.

**Propiedades clave:**
- `FlowDirection`: `LeftToRight`, `RightToLeft`, `TopDown`, `BottomUp`.
- `WrapContents`: Si es `true`, los controles saltan a la siguiente fila al no caber.

<div style="font-family: 'Segoe UI', sans-serif; background: #f0f0f0; padding: 20px; border-radius: 4px; max-width: 480px;">
  <p style="margin: 0 0 10px 0; font-size: 13px; color: #333; font-style: italic;">Vista previa — FlowLayoutPanel con botones de categorías:</p>
  <div style="background: #f0f0f0; border: 1px solid #999; border-radius: 2px; padding: 8px;">
    <div style="background: linear-gradient(to bottom, #4a90d9, #3070b8); color: white; padding: 4px 8px; font-size: 12px; border-radius: 2px 2px 0 0; display: flex; justify-content: space-between; margin: -8px -8px 8px -8px;">
      <span>FormCategorias</span>
      <span style="font-size: 10px;">─ □ ✕</span>
    </div>
    <div style="border: 1px dashed #aaa; padding: 6px; background: #f9f9f9; border-radius: 2px;">
      <div style="font-size: 10px; color: #888; margin-bottom: 4px;">FlowLayoutPanel (LeftToRight, WrapContents = true)</div>
      <div style="display: flex; flex-wrap: wrap; gap: 4px;">
        <button style="font-size: 11px; background: #e1e1e1; border: 1px solid #999; border-radius: 2px; padding: 3px 10px; cursor: default;">Electrónica</button>
        <button style="font-size: 11px; background: #e1e1e1; border: 1px solid #999; border-radius: 2px; padding: 3px 10px; cursor: default;">Ropa</button>
        <button style="font-size: 11px; background: #e1e1e1; border: 1px solid #999; border-radius: 2px; padding: 3px 10px; cursor: default;">Hogar</button>
        <button style="font-size: 11px; background: #e1e1e1; border: 1px solid #999; border-radius: 2px; padding: 3px 10px; cursor: default;">Deportes</button>
        <button style="font-size: 11px; background: #4a90d9; color: white; border: 1px solid #2a70b8; border-radius: 2px; padding: 3px 10px; cursor: default;">Juguetes ✓</button>
        <button style="font-size: 11px; background: #e1e1e1; border: 1px solid #999; border-radius: 2px; padding: 3px 10px; cursor: default;">Libros</button>
        <button style="font-size: 11px; background: #e1e1e1; border: 1px solid #999; border-radius: 2px; padding: 3px 10px; cursor: default;">Música</button>
        <button style="font-size: 11px; background: #e1e1e1; border: 1px solid #999; border-radius: 2px; padding: 3px 10px; cursor: default;">Arte</button>
      </div>
    </div>
  </div>
</div>

```csharp
// Agregar botones dinámicamente al FlowLayoutPanel
string[] categorias = { "Electrónica", "Ropa", "Hogar", "Deportes", "Libros" };

foreach (string categoria in categorias)
{
    Button btn = new Button();
    btn.Text = categoria;
    btn.AutoSize = true;
    btn.Click += (s, e) => FiltrarPorCategoria(((Button)s).Text);
    flowLayoutPanel1.Controls.Add(btn);
}
```

---

## 7. TableLayoutPanel — Grid de Precisión

El `TableLayoutPanel` organiza los controles en una **cuadrícula de filas y columnas** con tamaños configurables. Es el contenedor más potente para formularios de datos, ya que garantiza alineación perfecta sin importar el tamaño del texto de las etiquetas.

**Propiedades clave:**
- `ColumnCount` / `RowCount`: Número de columnas y filas.
- `ColumnStyles` / `RowStyles`: Define si cada columna/fila es de tamaño fijo (`Absolute`), porcentaje (`Percent`) o automático (`AutoSize`).
- `SetColumnSpan()` / `SetRowSpan()`: Permite que un control ocupe varias columnas o filas.

<div style="font-family: 'Segoe UI', sans-serif; background: #f0f0f0; padding: 20px; border-radius: 4px; max-width: 500px;">
  <p style="margin: 0 0 10px 0; font-size: 13px; color: #333; font-style: italic;">Vista previa — TableLayoutPanel como formulario de registro:</p>
  <div style="background: #f0f0f0; border: 1px solid #999; border-radius: 2px; padding: 8px;">
    <div style="background: linear-gradient(to bottom, #4a90d9, #3070b8); color: white; padding: 4px 8px; font-size: 12px; border-radius: 2px 2px 0 0; display: flex; justify-content: space-between; margin: -8px -8px 8px -8px;">
      <span>FormRegistro</span>
      <span style="font-size: 10px;">─ □ ✕</span>
    </div>
    <!-- TableLayoutPanel visual -->
    <div style="border: 1px dashed #aaa; background: #f9f9f9; border-radius: 2px; overflow: hidden;">
      <div style="font-size: 10px; color: #888; padding: 4px 6px; border-bottom: 1px dashed #aaa;">TableLayoutPanel (2 cols: 30% Label / 70% Control)</div>
      <!-- Filas -->
      <div style="display: flex; border-bottom: 1px solid #e8e8e8;">
        <div style="width: 30%; background: #eff4ff; padding: 5px 8px; font-size: 12px; color: #555; display: flex; align-items: center; border-right: 1px solid #e0e0e0;">Nombre:</div>
        <div style="flex: 1; padding: 4px 8px;"><input type="text" value="Ana Torres" style="width: 95%; font-size: 12px; border: 1px solid #999; padding: 2px 5px; background: white;" readonly /></div>
      </div>
      <div style="display: flex; border-bottom: 1px solid #e8e8e8;">
        <div style="width: 30%; background: #eff4ff; padding: 5px 8px; font-size: 12px; color: #555; display: flex; align-items: center; border-right: 1px solid #e0e0e0;">Apellido:</div>
        <div style="flex: 1; padding: 4px 8px;"><input type="text" value="Martínez" style="width: 95%; font-size: 12px; border: 1px solid #999; padding: 2px 5px; background: white;" readonly /></div>
      </div>
      <div style="display: flex; border-bottom: 1px solid #e8e8e8;">
        <div style="width: 30%; background: #eff4ff; padding: 5px 8px; font-size: 12px; color: #555; display: flex; align-items: center; border-right: 1px solid #e0e0e0;">Edad:</div>
        <div style="flex: 1; padding: 4px 8px;"><input type="number" value="28" style="width: 60px; font-size: 12px; border: 1px solid #999; padding: 2px 5px; background: white;" readonly /></div>
      </div>
      <!-- Fila con colspan (botón que ocupa todo el ancho) -->
      <div style="display: flex;">
        <div style="width: 100%; padding: 6px 8px; text-align: right; background: #f0f4ff;">
          <button style="font-size: 12px; background: #e1e1e1; border: 1px solid #999; border-radius: 2px; padding: 4px 12px; margin-right: 4px; cursor: default;">Cancelar</button>
          <button style="font-size: 12px; background: #4a90d9; color: white; border: 1px solid #2a70b8; border-radius: 2px; padding: 4px 16px; cursor: default;">Aceptar</button>
        </div>
      </div>
    </div>
  </div>
</div>

```csharp
// Hacer que el botón "Aceptar" ocupe las 2 columnas de la última fila
tableLayoutPanel1.SetColumnSpan(btnAceptar, 2);

// Cambiar el tamaño de la primera columna a 120px fijo
tableLayoutPanel1.ColumnStyles[0] = new ColumnStyle(SizeType.Absolute, 120F);

// La segunda columna ocupa el resto del espacio disponible
tableLayoutPanel1.ColumnStyles[1] = new ColumnStyle(SizeType.Percent, 100F);
```

---

## 8. Resumen Comparativo

<div style="font-family: 'Segoe UI', sans-serif; background: #f0f0f0; padding: 20px; border-radius: 4px;">
  <p style="margin: 0 0 10px 0; font-size: 13px; color: #333; font-style: italic;">¿Cuándo usar cada contenedor?</p>
  <table style="width: 100%; border-collapse: collapse; font-size: 12px; background: white; border: 1px solid #ddd;">
    <thead>
      <tr style="background: #4a90d9; color: white;">
        <th style="padding: 7px 10px; text-align: left; border: 1px solid #3070b8;">Contenedor</th>
        <th style="padding: 7px 10px; text-align: left; border: 1px solid #3070b8;">Borde visible</th>
        <th style="padding: 7px 10px; text-align: left; border: 1px solid #3070b8;">Uso principal</th>
      </tr>
    </thead>
    <tbody>
      <tr style="background: #f9f9f9;">
        <td style="padding: 6px 10px; border: 1px solid #ddd; font-weight: bold;">GroupBox</td>
        <td style="padding: 6px 10px; border: 1px solid #ddd;">Sí + título</td>
        <td style="padding: 6px 10px; border: 1px solid #ddd;">Agrupar controles relacionados semánticamente</td>
      </tr>
      <tr>
        <td style="padding: 6px 10px; border: 1px solid #ddd; font-weight: bold;">Panel</td>
        <td style="padding: 6px 10px; border: 1px solid #ddd;">Opcional</td>
        <td style="padding: 6px 10px; border: 1px solid #ddd;">Secciones dinámicas (mostrar/ocultar, scroll)</td>
      </tr>
      <tr style="background: #f9f9f9;">
        <td style="padding: 6px 10px; border: 1px solid #ddd; font-weight: bold;">TabControl</td>
        <td style="padding: 6px 10px; border: 1px solid #ddd;">Sí (pestañas)</td>
        <td style="padding: 6px 10px; border: 1px solid #ddd;">Dividir mucha información en secciones navegables</td>
      </tr>
      <tr>
        <td style="padding: 6px 10px; border: 1px solid #ddd; font-weight: bold;">SplitContainer</td>
        <td style="padding: 6px 10px; border: 1px solid #ddd;">Barra divisoria</td>
        <td style="padding: 6px 10px; border: 1px solid #ddd;">Layouts tipo explorador (árbol + detalle)</td>
      </tr>
      <tr style="background: #f9f9f9;">
        <td style="padding: 6px 10px; border: 1px solid #ddd; font-weight: bold;">FlowLayoutPanel</td>
        <td style="padding: 6px 10px; border: 1px solid #ddd;">No</td>
        <td style="padding: 6px 10px; border: 1px solid #ddd;">Controles de tamaño variable en flujo (botones, tags)</td>
      </tr>
      <tr>
        <td style="padding: 6px 10px; border: 1px solid #ddd; font-weight: bold;">TableLayoutPanel</td>
        <td style="padding: 6px 10px; border: 1px solid #ddd;">No</td>
        <td style="padding: 6px 10px; border: 1px solid #ddd;">Formularios de datos con alineación perfecta</td>
      </tr>
    </tbody>
  </table>
</div>

---

## 9. Ejemplo Integrador: Formulario de Registro de Producto

Este ejemplo combina `TabControl`, `GroupBox` y `TableLayoutPanel` en un formulario real:

```csharp
using System;
using System.Windows.Forms;

namespace TiendaApp
{
    public partial class FormProducto : Form
    {
        public FormProducto()
        {
            InitializeComponent();
        }

        // Al cargar el formulario, configuramos la interfaz
        private void FormProducto_Load(object sender, EventArgs e)
        {
            // Seleccionar la primera pestaña
            tabControlProducto.SelectedIndex = 0;

            // Rellenar el ComboBox de categorías dinámicamente
            string[] categorias = { "Electrónica", "Ropa", "Hogar", "Deportes" };
            cmbCategoria.Items.AddRange(categorias);
            cmbCategoria.SelectedIndex = 0;
        }

        // Botón Guardar en la pestaña "Datos Generales"
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreProducto.Text))
            {
                MessageBox.Show("El nombre del producto es obligatorio.",
                                "Validación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                txtNombreProducto.Focus();
                return;
            }

            if (numPrecio.Value <= 0)
            {
                MessageBox.Show("El precio debe ser mayor a cero.",
                                "Validación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                numPrecio.Focus();
                return;
            }

            // Si todo es válido, habilitar la pestaña de inventario
            tabPageInventario.Enabled = true;
            tabControlProducto.SelectedTab = tabPageInventario;
        }

        // Ocultar/mostrar el Panel de descuento al marcar el CheckBox
        private void chkAplicarDescuento_CheckedChanged(object sender, EventArgs e)
        {
            panelDescuento.Visible = chkAplicarDescuento.Checked;
        }
    }
}
```

---

## 10. Buenas Prácticas con Contenedores

1. **Anidar con moderación:** Un `Panel` dentro de un `GroupBox` dentro de un `TabPage` es razonable. Más de 3 niveles de anidación dificulta el mantenimiento.
2. **Dock + Anchor coordinados:** Usa `Dock = Fill` en el contenedor principal y `Anchor` en los controles hijos para que el layout se adapte al redimensionado.
3. **Habilitar/deshabilitar en lote:** Cuando quieras bloquear un conjunto de controles, ponlos en un `GroupBox` o `Panel` y cambia el `Enabled` del contenedor, no el de cada control individual.
4. **Controles invisibles ≠ datos nulos:** Cuando un `Panel` se oculta (`Visible = false`), sus controles siguen existiendo. Valida o limpia sus valores según la lógica de negocio.
5. **TabIndex coherente:** El orden de tabulación (`TAB`) debe seguir el flujo lógico del formulario, no el orden en que arrastraste los controles.

---

## 11. Recursos Adicionales

- **Diseñador Visual:** Arrastra un `TableLayoutPanel` al form y observa la cuadrícula que aparece en modo diseño.
- **Propiedad `Padding`:** Todos los contenedores tienen `Padding` para dar espacio interno entre el borde y sus controles hijos. Úsalo en lugar de márgenes manuales.
- **Enfoque Semanal:** Construir al menos un formulario que use `TabControl` con 2 pestañas y `TableLayoutPanel` para la alineación de etiquetas y campos.
