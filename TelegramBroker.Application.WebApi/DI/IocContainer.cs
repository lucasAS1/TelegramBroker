using TelegramBroker.Domain.Facades.Telegram;
using System.Diagnostics.CodeAnalysis;
using Autofac;
using RabbitMQ.Client.Core.DependencyInjection.Services;
using TelegramBroker.Domain.Interfaces.Facades;
using TelegramBroker.Domain.Interfaces.Services.Telegram;
using TelegramBroker.Domain.Services.Telegram;
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
    }

    private static void ConfigureInfrastructureLayer(ContainerBuilder builder)
    {
        builder.RegisterType<TelegramAgent>().As<ITelegramAgent>();
    }
    
    private static void ConfigureDomainLayer(ContainerBuilder builder)
    {
        builder.RegisterType<TelegramService>().As<ITelegramService>();
        builder.RegisterType<TelegramFacade>().As<ITelegramFacade>();
    }

    private static void ConfigureApplicationLayer(ContainerBuilder builder)
    {
        builder.RegisterType<IHostedService>().As<ConsumingService>();
    }
}