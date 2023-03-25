using TelegramBroker.Domain.Models.Responses;

namespace TelegramBroker.Domain.Interfaces.Facades;

public interface ITelegramFacade
{
    public void SendMessage(WebhookResponse message);
}