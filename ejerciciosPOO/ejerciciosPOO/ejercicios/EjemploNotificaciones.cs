/*
 * 3. Sistema de Notificaciones (Interfaces)
 * Objetivo: Utilizar contratos para desacoplar el código.
 * 
 * - Crea una interfaz INotificable with un método Enviar(string mensaje).
 * - Implementa la interfaz en tres clases: EmailNotificador, SmsNotificador y WhatsappNotificador. Cada una debe imprimir en consola un mensaje simulando el envío (ej: "Enviando Email: [mensaje]").
 * - Crea una clase ServicioAlCliente que tenga un método NotificarTodo(string msg, List<INotificable> medios).
 * - Reto: Haz que el usuario elija qué medios de notificación desea activar antes de enviar el mensaje.
 */

using System;
using System.Collections.Generic;

namespace ejerciciosPOO.ejercicios
{
    public interface INotificable
    {
        void Enviar(string mensaje);
    }

    public class EmailNotificador : INotificable
    {
        public void Enviar(string mensaje) => Console.WriteLine($"[Email] Enviando: {mensaje}");
    }

    public class SmsNotificador : INotificable
    {
        public void Enviar(string mensaje) => Console.WriteLine($"[SMS] Enviando: {mensaje}");
    }

    public class WhatsappNotificador : INotificable
    {
        public void Enviar(string mensaje) => Console.WriteLine($"[WhatsApp] Enviando: {mensaje}");
    }

    public static class EjemploNotificaciones
    {
        public static void Ejecutar()
        {
            Console.WriteLine("--- EJERCICIO 3: SISTEMA DE NOTIFICACIONES ---");
            List<INotificable> medios = new List<INotificable>
            {
                new EmailNotificador(),
                new WhatsappNotificador()
            };

            foreach (var medio in medios)
            {
                medio.Enviar("¡Su pedido ha sido enviado!");
            }
        }
    }
}
