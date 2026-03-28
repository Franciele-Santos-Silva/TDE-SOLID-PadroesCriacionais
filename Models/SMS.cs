using Interfaces;
using System;

namespace Models
{
    public class SMS : INotificacao
    {
        public void Enviar()
        {
            Console.WriteLine("SMS enviado");
        }
    }
}

