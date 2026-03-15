using Interfaces;
using Models;

namespace Factories{

    public class NotificacaoFactory
    {
        public static INotificacao Criar(string tipo)
        {
            switch (EmitTypeInformation.ToLower())
            {
                case "email":
                    return new Email();
                case "sms":
                    return SMS();
                case "whatsapp":
                    return new WhatsaApp();
                default:
                    throw new System.Exception("Tipo de notificação inválido");
            }
        }
    }
}