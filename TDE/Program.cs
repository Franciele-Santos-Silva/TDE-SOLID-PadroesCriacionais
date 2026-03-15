using System;
using Services;
using Singleton;

class Program{

    static void Main(string[] args){
    
        var config = ConfiguracaoSistema.GetInstancia();
        console.WriteLine($"Sistema: {config.NomeSistema} - Versão {config.Versao}\n");

        var service = new NotificacaoService();

        service.EnviarNotificacao("email");
        service.EnviarNotificacao("sms");
        service.EnviarNotificacao("whatsapp");
    }
}
