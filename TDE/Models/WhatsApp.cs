using Interfaces;

public class WhatsApp: INotificacao
{
    public void Enviar()
    {
        console.WriteLine("Mensagem enviada pelo WhatsApp");
    }
}

// OCP - Open/Closed Principle)