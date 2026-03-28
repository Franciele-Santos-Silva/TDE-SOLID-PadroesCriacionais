# Documentação Completa do Código - Sistema de Notificações (Factory Method + Singleton + SOLID)

## 📋 Visão Geral do Projeto
Este projeto em C# (.NET Console Application) demonstra **padrões de projeto Criacionais**:
- **Factory Method**: Criação flexível de objetos de notificação (SMS, Email, WhatsApp) sem acoplamento direto.
- **Singleton**: Configuração global do sistema (uma única instância).
- **Princípios SOLID**:
  - **S**: Responsabilidade única por classe (ex: Factory só cria).
  - **O**: Aberto para extensão (novo tipo? Adicione no enum e switch).
  - **L**: Substituição (qualquer INotificacao funciona).
  - **I**: Segregação (interfaces mínimas).
  - **D**: Inversão de dependência (service usa interfaces/factory).

**Estrutura de Pastas**:
```
TDE/
├── Interfaces/     # Contratos (DIP)
├── Models/         # Implementações concretas
├── Factories/      # Factory Method
├── Services/       # Orquestração
├── Singleton/      # Singleton
├── Program.cs      # Demo interativa
└── Csharp.csproj   # .NET project
```

**Fluxo Principal**:
1. `Program.cs` obtém Singleton config e cria `NotificacaoService`.
2. Usuário escolhe tipo → `EnviarNotificacao(tipo)`.
3. Service valida enum → Factory cria `INotificacao`.
4. Model executa `Enviar()` → Console output.

**Exemplo de Saída**:
```
🚀 SISTEMA DE NOTIFICAÇÕES - Factory Method + SOLID
📋 Sistema de Notificações - Versão: 1.0

📱 Selecione tipo de notificação:
1 - SMS
...
Escolha (0-3): 1
📤 Enviando SMS:
SMS enviado
```

## 🔍 Breakdown por Arquivo

### 1. Interfaces/INotificacao.cs
```csharp
namespace Interfaces
{
    public interface INotificacao
    {
        void Enviar();
    }
}
```
- **Propósito**: Contrato mínimo (ISP). Toda notificação deve ter método `Enviar()`.
- **Uso**: Dependency Inversion – clients usam interface, não concretos.
- **SOLID**: DIP, ISP.

### 2. Interfaces/INotificacaoService.cs
```csharp
using System;

namespace Interfaces
{
    public interface INotificacaoService
    {
        void EnviarNotificacao(string tipo);
    }
}
```
- **Propósito**: Orquestra envio por tipo string (usuário-friendly).
- **Uso**: Implementado por `NotificacaoService`.

### 3. Models/SMS.cs (similar para Email.cs, WhatsApp.cs)
```csharp
using Interfaces;
using System;

namespace Models
{
    public class SMS : INotificacao
    {
        public void Enviar()
        {
            Console.WriteLine("SMS enviado");
        }
    }
}
```
- **Propósito**: Concrete Product (LSP). `Email`: \"Email enviado\"; `WhatsApp`: \"Mensagem via WhatsApp enviada\".
- **Diferenças**: Apenas output customizado – fácil estender (ex: integrar APIs reais).
- **SOLID**: SRP (só envia SMS).

### 4. Factories/NotificacaoFactory.cs
```csharp
using System;
using Interfaces;
using Models;

namespace Factories
{
    public enum TipoNotificacao { SMS, Email, WhatsApp }

    public static class NotificacaoFactory
    {
        public static INotificacao CriarNotificacao(TipoNotificacao tipo)
        {
            switch (tipo)
            {
                case TipoNotificacao.SMS: return new SMS();
                case TipoNotificacao.Email: return new Email();
                case TipoNotificacao.WhatsApp: return new WhatsApp();
                default: throw new ArgumentException("Tipo de notificação inválido");
            }
        }
    }
}
```
- **Padrão**: **Factory Method** (static factory com switch enum).
- **Vantagens**: OCP (adicione enum/case), evita `new` espalhado, retorna interface.
- **Uso**: `CriarNotificacao(enum)` → INotificacao.

### 5. Services/NotificacaoService.cs
```csharp
using System;
using Interfaces;
using Factories;

namespace Services
{
    public class NotificacaoService : INotificacaoService
    {
        public void EnviarNotificacao(string tipo)
        {
            if (!Enum.TryParse<Factories.TipoNotificacao>(tipo, true, out var tipoEnum))
                throw new ArgumentException($"Tipo de notificação inválido: {tipo}");

            Interfaces.INotificacao notificacao = Factories.NotificacaoFactory.CriarNotificacao(tipoEnum);
            notificacao.Enviar();
        }
    }
}
```
- **Propósito**: Facade/Service layer. Valida string → enum → Factory → Envia.
- **SOLID**: SRP (envio), DIP (usa interfaces/factory).
- **Tratamento Erro**: TryParse + Exception.

### 6. Singleton/ConfiguracaoSistema.cs
```csharp
namespace Singleton
{
    public class ConfiguracaoSistema
    {
        private static ConfiguracaoSistema? instancia;
        public string NomeSistema { get; private set; } = "Sistema de Notificações";
        public string Versao { get; private set; } = "1.0";

        private ConfiguracaoSistema() { }

        public static ConfiguracaoSistema GetInstancia()
        {
            if (instancia == null) instancia = new ConfiguracaoSistema();
            return instancia;
        }
    }
}
```
- **Padrão**: **Singleton** lazy (thread-unsafe simple version).
- **Uso**: Global config sem new múltiplos.

### 7. Program.cs
```csharp
using System;
using Services;
using Singleton;

class Program
{
    static void Main(string[] args)
    {
        var config = ConfiguracaoSistema.GetInstancia();
        Console.WriteLine($"🚀 SISTEMA... {config.NomeSistema} - Versão: {config.Versao}");

        var servico = new NotificacaoService();
        // Loop menu interativo com switch...
    }
}
```
- **Entry Point**: Demo loop, usando Singleton + Service.

## 🎯 Padrões Detalhados
- **Factory Method**: Evita client saber concretos (`new SMS()`). Extensível: Novo tipo? Enum + case + model.
- **Singleton**: Garante 1 instância config. Melhorias: Lock para thread-safety.
- **Outros**: Open tabs sugerem Factory para Jutsus (Rasengan etc.) + WinForms UI.

## 🚀 Como Rodar
```bash
cd TDE
dotnet run
```

**Extensões Sugeridas**: JutsuFactory similar, logging, DI container (ex: Microsoft.Extensions.DependencyInjection).

Documento criado com base nos arquivos do projeto. Qualquer dúvida, expanda!

