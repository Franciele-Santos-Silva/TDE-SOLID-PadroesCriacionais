using Interfaces;
using Factories;

public class NotificacaoService{

    public void EnviarNotificacao(string tipo){
        
            INotificacao notificação = NotificacaoFactory.Criar(tipo);
            notificação.Enviar();
    }
}