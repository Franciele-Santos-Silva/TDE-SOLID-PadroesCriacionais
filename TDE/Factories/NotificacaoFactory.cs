using System;
using Interfaces;
using Models;

namespace Factories
{
    public enum TipoNotificacao
    {
        SMS,
        Email,
        WhatsApp
    }

    public static class NotificacaoFactory
    {
        public static INotificacao CriarNotificacao(TipoNotificacao tipo)
        {
            switch (tipo)
            {
                case TipoNotificacao.SMS:
                    return new SMS();
                case TipoNotificacao.Email:
                    return new Email();
                case TipoNotificacao.WhatsApp:
                    return new WhatsApp();
                default:
                    throw new ArgumentException("Tipo de notificação inválido");
            }
        }
    }
}