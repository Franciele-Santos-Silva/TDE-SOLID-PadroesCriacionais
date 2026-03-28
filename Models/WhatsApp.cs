using Interfaces;
using System;

namespace Models
{
    public class WhatsApp : INotificacao
    {
        public void Enviar()
        {
            Console.WriteLine("Mensagem via WhatsApp enviada");
        }
    }
}

