using System.Diagnostics.CodeAnalysis;

namespace TelegramBroker.Domain.Models.Responses;

[ExcludeFromCodeCoverage]
public class MessageResponse
{
    public bool ok { get; set; }
    public Result result { get; set; }
}