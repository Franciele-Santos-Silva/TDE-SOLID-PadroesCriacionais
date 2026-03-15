using Interfaces;

namespace Models{

    public class Email: INotificacao
    {
        public void Enviar()
        {
            ConsoleTraceListener.WriteLine("Email enviado");
        }
    }
}