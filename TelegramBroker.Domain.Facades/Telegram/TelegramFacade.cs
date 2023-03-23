using ChatbotProject.Common.Domain.Models.Requests;
using RabbitMQ.Client.Core.DependencyInjection.Services.Interfaces;
using TelegramBroker.Domain.Interfaces.Facades;
using TelegramBroker.Domain.Models.Responses;

namespace TelegramBroker.Domain.Facades.Telegram;

public class TelegramFacade : ITelegramFacade
{
    private readonly IProducingService _queueService;

    public TelegramFacade(IProducingService queueService)
    {
        _queueService = queueService;
    }

    public void SendMessage(WebhookResponse message)
    {
        var messageRequest = new MessageRequest()
        {
            Text = message.message.text,
            ChatId = message.message.from.id.ToString()
        };
        
        _queueService.Send(messageRequest,"telegram-service","telegram-to-service");
    }
}