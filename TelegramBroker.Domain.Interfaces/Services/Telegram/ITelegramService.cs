using TelegramBroker.Domain.Models.Requests;
using TelegramBroker.Domain.Models.Responses;

namespace TelegramBroker.Domain.Interfaces.Services.Telegram;

public interface ITelegramService
{
    public Task<MessageResponse> SendMessageAsync(MessageRequest request);
}