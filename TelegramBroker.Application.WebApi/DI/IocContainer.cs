using System.Diagnostics.CodeAnalysis;
using Autofac;
using ClassLibrary1TelegramBroker.Domain.Interfaces.Services.Telegram;
using ClassLibrary1TelegramBroker.Domain.Services.Telegram;
using TelegramBroker.Infrastructure.Agents.Telegram;
using TelegramBroker.Infrastructure.Interfaces.Agents;

namespace TelegramBroker.Application.WebApi.DI;

[ExcludeFromCodeCoverage]
public class IocContainer : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        ConfigureInfrastructureLayer(builder);
        ConfigureDomainLayer(builder);
        ConfigureApplicationLayer(builder);
    }

    private static void ConfigureInfrastructureLayer(ContainerBuilder builder)
    {
        builder.RegisterType<TelegramAgent>().As<ITelegramAgent>();
    }
    
    private static void ConfigureDomainLayer(ContainerBuilder builder)
    {
        builder.RegisterType<TelegramService>().As<ITelegramService>();
    }
    
    private static void ConfigureApplicationLayer(ContainerBuilder builder)
    {
        
    }
}