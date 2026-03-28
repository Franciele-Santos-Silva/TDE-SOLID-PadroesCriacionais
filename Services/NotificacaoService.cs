using System;
using Interfaces;
using Factories;

namespace Services
{
    public class NotificacaoService : INotificacaoService
    {
        public void EnviarNotificacao(string tipo)
        {
            if (!Enum.TryParse<Factories.TipoNotificacao>(tipo, true, out var tipoEnum))
            {
                throw new ArgumentException($"Tipo de notificação inválido: {tipo}");
            }

            Interfaces.INotificacao notificacao = Factories.NotificacaoFactory.CriarNotificacao(tipoEnum);

            notificacao.Enviar();
        }
    }
}

