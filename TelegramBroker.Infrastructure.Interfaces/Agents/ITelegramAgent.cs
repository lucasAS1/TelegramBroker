using ChatbotProject.Common.Domain.Models.Requests;
using TelegramBroker.Domain.Models.Requests;
using TelegramBroker.Domain.Models.Responses;

namespace TelegramBroker.Infrastructure.Interfaces.Agents;

public interface ITelegramAgent
{
    public Task<MessageResponse> SendMessage(TelegramMessageRequest request);
}