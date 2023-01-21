using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using ClassLibrary1TelegramBroker.Domain.Services.Telegram;
using FluentAssertions;
using Moq;
using TelegramBroker.Domain.Models.Requests;
using TelegramBroker.Domain.Models.Responses;
using TelegramBroker.Infrastructure.Interfaces.Agents;
using Xunit;

namespace TelegramBroker.Domain.Tests.Services;

public class TelegramServiceTests
{
    private readonly IFixture _fixture;
    private readonly Mock<ITelegramAgent> _telegramAgent;

    public TelegramServiceTests()
    {
        _fixture = new Fixture();
        _telegramAgent = new Mock<ITelegramAgent>();
        
        _fixture.Customize(new AutoMoqCustomization(){ConfigureMembers = true});
    }

    private void ConfigureMocks()
    {
        _telegramAgent
            .Setup(x => x.SendMessage(It.IsAny<MessageRequest>()))
            .ReturnsAsync(_fixture.Create<MessageResponse>());
    }
    
    [Fact]
    public async Task ShouldSendMessageCorrect()
    {
        var aut = new TelegramService(_telegramAgent.Object);
        ConfigureMocks();

        var result = await aut.SendMessageAsync(_fixture.Create<MessageRequest>());

        result.Should().BeOfType<MessageResponse>();
    }
}