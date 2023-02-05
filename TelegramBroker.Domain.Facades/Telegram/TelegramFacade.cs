using RabbitMQ.Client.Core.DependencyInjection.Services.Interfaces;
using TelegramBroker.Domain.Interfaces.Facades;

namespace TelegramBroker.Domain.Facades.Telegram;

public class TelegramFacade : ITelegramFacade
{
    private readonly IProducingService _queueService;

    public TelegramFacade(IProducingService queueService)
    {
        _queueService = queueService;
    }

    public void SendMessage(object message)
    {
        _queueService.Send(message,"telegram-service","telegram-to-service");
    }
}