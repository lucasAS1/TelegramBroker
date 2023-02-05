namespace TelegramBroker.Domain.Interfaces.Facades;

public interface ITelegramFacade
{
    public void SendMessage(object message);
}