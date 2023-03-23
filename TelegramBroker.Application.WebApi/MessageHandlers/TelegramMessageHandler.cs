using ChatbotProject.Common.Domain.Models.Requests;
using RabbitMQ.Client.Core.DependencyInjection.MessageHandlers;
using RabbitMQ.Client.Core.DependencyInjection.Models;
using TelegramBroker.Domain.Interfaces.Services.Telegram;
using static System.Text.Encoding;
using static Newtonsoft.Json.JsonConvert;

namespace TelegramBroker.Application.WebApi.MessageHandlers;

public class TelegramMessageHandler : IAsyncMessageHandler
{
    private readonly ITelegramService _telegramService;

    public TelegramMessageHandler(ITelegramService telegramService)
    {
        _telegramService = telegramService;
    }

    public async Task Handle(MessageHandlingContext context, string matchingRoute)
    {
        var message = UTF8.GetString(context.Message.Body.ToArray());
        var messageRequest = DeserializeObject<MessageRequest>(message);
        
        await _telegramService.SendMessageAsync(messageRequest);
    }
}