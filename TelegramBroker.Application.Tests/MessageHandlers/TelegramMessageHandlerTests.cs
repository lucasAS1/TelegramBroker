using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using ChatbotProject.Common.Domain.Models.Requests;
using Moq;
using RabbitMQ.Client.Core.DependencyInjection.Models;
using RabbitMQ.Client.Events;
using TelegramBroker.Application.WebApi.MessageHandlers;
using TelegramBroker.Domain.Interfaces.Services.Telegram;
using TelegramBroker.Domain.Models.Responses;
using Xunit;

namespace TelegramBroker.Application.Tests.MessageHandlers;

public class TelegramMessageHandlerTests
{
    private readonly Mock<ITelegramService> _telegramServiceMock;
    private readonly IFixture _fixture;

    public TelegramMessageHandlerTests()
    {
        _fixture = new Fixture();
        _telegramServiceMock = new Mock<ITelegramService>();
       
        _fixture.Customize(new AutoMoqCustomization(){ConfigureMembers = true});
    }
    
    private void ConfigureMocks()
    {
        _telegramServiceMock
            .Setup(x => x.SendMessageAsync(It.IsAny<MessageRequest>()))
            .ReturnsAsync(_fixture.Create<MessageResponse>());
    }
    
    
    [Fact]
    public async Task ShouldProperlyHandleMessageReceivingEvent()
    {
        ConfigureMocks();
        var argsMock = _fixture
            .Build<BasicDeliverEventArgs>()
            .With(x => x.Body, Encoding.ASCII.GetBytes("{\"Chat\":\"teste\",\"chatId\":\"1234364\"}"))
            .WithAutoProperties()
            .Create();
        
        var aut = new TelegramMessageHandler(_telegramServiceMock.Object);
        var messageHandlingContext = new MessageHandlingContext(argsMock, x => x.Exchange = "testexchange", false);
        
        await aut.Handle(messageHandlingContext, "test-route");
        Assert.Equal(messageHandlingContext.Message.Exchange, argsMock.Exchange);
    }
}