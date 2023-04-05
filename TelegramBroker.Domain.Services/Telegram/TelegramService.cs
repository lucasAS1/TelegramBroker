using ChatbotProject.Common.Domain.Models.Requests;
using TelegramBroker.Domain.Interfaces.Services.Telegram;
using TelegramBroker.Domain.Models.Requests;
using TelegramBroker.Domain.Models.Responses;
using TelegramBroker.Infrastructure.Interfaces.Agents;

namespace TelegramBroker.Domain.Services.Telegram;

public class TelegramService : ITelegramService
{
    private readonly ITelegramAgent _telegramAgent;

    public TelegramService(ITelegramAgent telegramAgent)
    {
        _telegramAgent = telegramAgent;
    }

    public async Task<MessageResponse> SendMessageAsync(MessageRequest request)
    {
        var messageRequest = new TelegramMessageRequest(request);
        var response = await _telegramAgent.SendMessage(messageRequest);
        
        return response;
    }
}