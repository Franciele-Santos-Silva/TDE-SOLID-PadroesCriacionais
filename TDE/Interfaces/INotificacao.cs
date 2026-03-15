//define o contrato para notificações, toda notificação, email, sms, whatsApp precisa implementar enviar();D do SOLID usar

namespace Interfaces{   

    public interface INotificacao
    {
        public void Enviar();
    }

}