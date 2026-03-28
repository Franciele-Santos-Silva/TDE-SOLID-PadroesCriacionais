# Explicação das Pastas do Projeto TDE

Este projeto em C# demonstra padrões de design **Criacionais** (Factory Method e Singleton) aplicados a um sistema de notificações. Abaixo, explicação detalhada de cada pasta principal:

## 📁 **Factories/**
Contém a classe `NotificacaoFactory.cs`, que implementa o padrão **Factory Method**. 
- Responsável por criar instâncias de diferentes tipos de notificações (`SMS`, `Email`, `WhatsApp`) com base em um enum `TipoNotificacao`.
- Evita acoplamento direto entre cliente e classes concretas de notificação.

## 📁 **Interfaces/**
Define a interface `INotificacao.cs`.
- Contrato comum para todas as implementações de notificação.
- Método `Enviar()` deve ser implementado por todas as classes concretas.

## 📁 **Models/**
Classes concretas que implementam `INotificacao`:
- `Email.cs`: Simula envio de email.
- `SMS.cs`: Simula envio de SMS.
- `WhatsApp.cs`: Simula envio via WhatsApp.
- Cada uma imprime uma mensagem específica ao chamar `Enviar()`.

## 📁 **Services/**
Classe `NotificacaoService.cs` que orquestra o envio:
- Recebe o tipo de notificação como string.
- Usa `NotificacaoFactory` para criar a instância correta.
- Chama `Enviar()` na notificação criada.

## 📁 **Singleton/**
Implementação do padrão **Singleton** em `ConfiguracaoSistema.cs`:
- Garante uma única instância de configuração do sistema.
- Propriedades: `NomeSistema` e `Versao`.
- Usado no `Program.cs` para exibir informações iniciais.

## 🏠 **Raiz do Projeto**
- `Program.cs`: Ponto de entrada. Instancia config singleton, cria service e testa todos os tipos de notificação.
- `Csharp.csproj` / `Csharp.sln`: Arquivos de projeto .NET 8.0.

## Pastas de Build (Ignorar)
- `bin/` e `obj/`: Geradas automaticamente pelo .NET durante compilação/execução.

## Como Executar
```
dotnet run
```
Saída demonstra Factory + Singleton funcionando.

Este estrutura segue princípios **SOLID** (especialmente Dependency Inversion e Open/Closed).
