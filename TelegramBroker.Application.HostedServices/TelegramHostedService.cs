using TelegramBroker.Domain.Interfaces.Services.Telegram;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Core.DependencyInjection.Services.Interfaces;

namespace TelegramBroker.Application.HostedServices;

public class TelegramHostedService : IHostedService
{
    private readonly ITelegramService _telegramService;
    private readonly IProducingService _producingService;
    
    public TelegramHostedService(ITelegramService telegramService, IProducingService producingService)
    {
        _telegramService = telegramService;
        _producingService = producingService;

        _producingService.Connection.
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    private async Task SendMessage(object message)
    {
        
    }

    private async Task<object> ReceiveMessage()
    {
        throw new NotImplementedException();
    }
    
    public Task StopAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}