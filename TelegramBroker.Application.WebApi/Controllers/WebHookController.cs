using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc;
using TelegramBroker.Domain.Interfaces.Facades;
using TelegramBroker.Domain.Models.Responses;

namespace TelegramBroker.Application.WebApi.Controllers;

[ApiController]
[ExcludeFromCodeCoverage]
public class WebHookController : Controller
{
    private readonly ITelegramFacade _telegramFacade;

    public WebHookController(ITelegramFacade telegramFacade)
    {
        _telegramFacade = telegramFacade;
    }

    [HttpPost]
    [Route("ReceiveMessageFromTelegram")]
    public IActionResult ReceiveMessageFromTelegram([FromBody]WebhookResponse message)
    {
        _telegramFacade.SendMessage(message);

        return Ok();
    }
}