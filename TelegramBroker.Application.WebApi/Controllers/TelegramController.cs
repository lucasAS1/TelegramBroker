using System.Diagnostics.CodeAnalysis;
using TelegramBroker.Domain.Interfaces.Services.Telegram;
using Microsoft.AspNetCore.Mvc;
using TelegramBroker.Domain.Models.Requests;

namespace TelegramBroker.Application.WebApi.Controllers;

[ApiController]
[ExcludeFromCodeCoverage]
public class TelegramController : Controller
{
    private readonly ITelegramService _telegramService;

    public TelegramController(ITelegramService telegramService)
    {
        _telegramService = telegramService;
    }

    [HttpPost]
    [Route("SendMessage")]
    public async Task<IActionResult> SendMessage([FromQuery] string chatId, [FromQuery] string text)
    {
        var message = new MessageRequest()
        {
            Text = text,
            ChatId = chatId
        };

        var resposta = await _telegramService.SendMessageAsync(message);

        return new JsonResult(resposta);
    }
}