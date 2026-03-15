using Interfaces;

public class Email: INotificacao
{
    public void Enviar()
    {
        ConsoleTraceListener.WriteLine("Email enviado");
    }
}