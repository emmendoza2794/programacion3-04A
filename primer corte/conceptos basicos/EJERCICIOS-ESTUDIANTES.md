# Ejercicios para Estudiantes — Programación III

Esta guía contiene ejercicios prácticos para reforzar los conocimientos del **Módulo 1**. El objetivo es resolver problemas de la vida cotidiana utilizando lógica de programación.

---

## Tema 1: Sintaxis y Elementos Básicos
*Variables, tipos de datos, estructuras de control y entrada/salida.*

1.  **Perfil de Usuario Gamer:** Crea un programa que pida al usuario su *Nickname*, nivel de experiencia (1-100) y si tiene suscripción Premium (booleano). Al final, muestra un mensaje personalizado que le dé la bienvenida a su nivel correspondiente.
2.  **Calculadora de Propina Solidaria:** Pide el total de una cuenta en un restaurante. Pregunta qué porcentaje de propina desea dejar (10%, 15% o 20%). Si el total con propina supera los $100.000, muestra un mensaje agradeciendo su generosidad.
3.  **Control de Aforo en Eventos:** Una discoteca tiene un aforo máximo de 50 personas. Crea un programa que pregunte cuántas personas quieren entrar. Si hay cupo, dales la bienvenida; si no, indícales cuántas personas deben salir para que ellos puedan entrar.
4.  **Generador de Correos Corporativos:** Pide al usuario su nombre y apellido. El programa debe generar un correo con el formato `nombre.apellido@empresa.com` (todo en minúsculas).
5.  **Simulador de Semáforo Inteligente:** Pide al usuario que ingrese el color actual del semáforo (Verde, Amarillo, Rojo). Si es verde, imprime "Sigue adelante"; si es amarillo, "Prepárate para frenar"; y si es rojo, "¡Detente!".

---

## Tema 2: Programación Orientada a Objetos (POO) e Interfaces
*Clases, objetos, herencia, encapsulamiento y contratos.*

1.  **Sistema de Mascotas Virtuales:** Crea una clase base `Mascota` con un nombre y un método `HacerTruco()`. Crea clases derivadas como `Loro` (que repita una frase) y `Gato` (que amase pan). Usa una lista para que el usuario elija qué mascota quiere ver actuar.
2.  **Gestión de Inventario de Tienda:** Define una clase `Producto` con nombre, precio y stock. Crea un método que permita "vender" el producto, restando del stock y mostrando el total de la venta. Si no hay stock, debe avisar al usuario.
3.  **App de Streaming de Música:** Crea una interfaz `IReproductor` con métodos `Play()` y `Stop()`. Implementa esta interfaz en clases como `Cancion` y `Podcast`. El usuario debe poder "darle play" a cualquiera de los dos.
4.  **Sistema de Biblioteca:** Crea una clase `Libro` que tenga un estado (Disponible o Prestado). Crea un método `Prestar()` que cambie el estado solo si el libro está disponible.
5.  **Control de Vehículos Eléctricos:** Crea una clase `VehiculoElectrico` con un nivel de batería. Implementa un método `Viajar(int km)` que reste 1% de batería por cada kilómetro. Si la batería llega a 0, el coche debe avisar que necesita carga inmediata.

---

## Tema 3: Manejo de Archivos y Directorios
*Lectura, escritura y organización de información persistente.*

1.  **Diario Personal Secreto:** Crea un programa que pida al usuario escribir sus pensamientos del día y los guarde en un archivo llamado `diario.txt`. Cada vez que el usuario escriba algo nuevo, debe añadirse al final del archivo sin borrar lo anterior.
2.  **Generador de Facturas en Texto:** Crea un sistema que pida nombre del cliente y total de la compra. Debe generar un archivo `.txt` único con el nombre del cliente (ej: `factura_juan.txt`) con todos los detalles de la compra.
3.  **Organizador de Tareas (To-Do List):** Crea un programa que permita al usuario ingresar 3 tareas pendientes. Estas deben guardarse en un archivo. Al iniciar el programa, debe leer el archivo y mostrarle al usuario sus tareas pendientes.
4.  **Copia de Seguridad de Contactos:** Crea una carpeta llamada `Backup`. El programa debe pedir un nombre y un teléfono, y guardar esa información dentro de un archivo de texto en esa carpeta específica.
5.  **Lector de Configuración de App:** Crea un archivo `config.ini` manual con un color de fondo (ej: "Azul"). Haz que tu programa de consola lea ese archivo y, dependiendo del color escrito, cambie el color de la letra de la consola (`Console.ForegroundColor`).

---

### Notas para la entrega:
- Utiliza **PascalCase** para nombres de clases y métodos.
- Asegúrate de usar `try-catch` en los ejercicios de archivos para evitar que el programa se cierre por errores de ruta o permisos.
- Documenta tus métodos principales usando los comentarios XML (`///`).
