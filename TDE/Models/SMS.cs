using Interfaces;

public class SMS: INotificacao
{
    public void Enviar()
    {
        console.WriteLine("SMS enviado");
    }
}