using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using ClassLibrary1TelegramBroker.Domain.Interfaces.Services.Telegram;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TelegramBroker.Application.WebApi.Controllers;
using TelegramBroker.Domain.Models.Requests;
using TelegramBroker.Domain.Models.Responses;
using Xunit;

namespace TelegramBroker.Application.Tests;

public class TelegramControllerTests
{
    private readonly IFixture _fixture;
    private readonly Mock<ITelegramService> _telegramService;

    public TelegramControllerTests()
    {
        _fixture = new Fixture();
        _telegramService = new Mock<ITelegramService>();
        
        _fixture.Customize(new AutoMoqCustomization(){ConfigureMembers = true});
    }
    
    private void ConfigureMocks()
    {
        _telegramService
            .Setup(x => x.SendMessageAsync(It.IsAny<MessageRequest>()))
            .ReturnsAsync(_fixture.Create<MessageResponse>());
    }

    [Fact]
    public async Task ShouldSendMessageAsyncCorrectly()
    {
        var aut = new TelegramController(_telegramService.Object);
        ConfigureMocks();

        var result = await aut.SendMessage(_fixture.Create<string>(), _fixture.Create<string>());

        result.Should().BeOfType<JsonResult>();
    }
}