using System.Diagnostics.CodeAnalysis;

namespace TelegramBroker.Domain.Models.Requests;

[ExcludeFromCodeCoverage]
public class MessageRequest
{
    public string ChatId { get; init; } = null!;
    public string Text { get; init; } = null!;
}