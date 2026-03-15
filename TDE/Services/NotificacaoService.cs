using Interfaces;
using Factories;

namespace Services{

    public class NotificacaoService{

        public void EnviarNotificacao(string tipo){
            
                INotificacao notificação = NotificacaoFactory.Criar(tipo);
                notificação.Enviar();
        }
    }
}