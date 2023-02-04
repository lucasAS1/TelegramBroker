using Moq;
using RabbitMQ.Client.Core.DependencyInjection.Services.Interfaces;
using TelegramBroker.Domain.Facades.Telegram;
using Xunit;

namespace TelegramBroker.Application.Tests.Facades;

public class TelegramFacadesTests
{
    private readonly Mock<IProducingService> _queueService;

    public TelegramFacadesTests()
    {
        _queueService = new Mock<IProducingService>();
    }

    [Fact]
    public void ShouldSendMessageCorrectly()
    {
        var aut = new TelegramFacade(_queueService.Object);
        
        aut.SendMessage(new {});
    }
}