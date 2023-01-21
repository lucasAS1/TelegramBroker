using System.Diagnostics.CodeAnalysis;

namespace TelegramBroker.Domain.Models.Requests;

[ExcludeFromCodeCoverage]
public class MessageRequest
{
    public string ChatId { get; set; }
    public string Text { get; set; }
}