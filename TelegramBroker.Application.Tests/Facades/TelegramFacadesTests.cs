using AutoFixture;
using AutoFixture.AutoMoq;
using ChatbotProject.Common.Domain.Models.Requests;
using Moq;
using RabbitMQ.Client.Core.DependencyInjection.Services.Interfaces;
using TelegramBroker.Domain.Facades.Telegram;
using TelegramBroker.Domain.Models.Responses;
using Xunit;

namespace TelegramBroker.Application.Tests.Facades;

public class TelegramFacadesTests
{
    private readonly Mock<IProducingService> _queueService;
    private readonly IFixture _fixture;

    public TelegramFacadesTests()
    {
        _queueService = new Mock<IProducingService>();
        _fixture = new Fixture();

        _fixture.Customize(new AutoMoqCustomization() { ConfigureMembers = true });
    }

    [Fact]
    public void ShouldSendMessageCorrectly()
    {
        var aut = new TelegramFacade(_queueService.Object);
        var webhookResponse = _fixture.Create<WebhookResponse>();
        
        aut.SendMessage(webhookResponse);
        _queueService.Verify(x => x.Send(It.IsAny<MessageRequest>(), It.IsAny<string>(),It.IsAny<string>()), Times.Once);
    }
}