using System;
using Services;
using Singleton;

class Program
{
    static void Main(string[] args)
    {
        var config = ConfiguracaoSistema.GetInstancia();
        Console.WriteLine("🚀 SISTEMA DE NOTIFICAÇÕES - Factory Method + SOLID");
        Console.WriteLine($"📋 {config.NomeSistema} - Versão: {config.Versao}");
        Console.WriteLine();

        var servico = new NotificacaoService();

        while (true)
        {
            Console.WriteLine("📱 Selecione tipo de notificação:");
            Console.WriteLine("1 - SMS");
            Console.WriteLine("2 - Email");
            Console.WriteLine("3 - WhatsApp");
            Console.WriteLine("0 - Sair");

            Console.Write("Escolha (0-3): ");
            string? opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Console.WriteLine("📤 Enviando SMS:");
                    servico.EnviarNotificacao("SMS");
                    break;
                case "2":
                    Console.WriteLine("📧 Enviando Email:");
                    servico.EnviarNotificacao("Email");
                    break;
                case "3":
                    Console.WriteLine("💬 Enviando WhatsApp:");
                    servico.EnviarNotificacao("WhatsApp");
                    break;
                case "0":
                    Console.WriteLine("👋 Até logo!");
                    return;
                default:
                    Console.WriteLine("❌ Opção inválida!");
                    break;
            }
            Console.WriteLine();
        }
    }
}
