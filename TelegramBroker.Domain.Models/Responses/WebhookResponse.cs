using System.Diagnostics.CodeAnalysis;

namespace TelegramBroker.Domain.Models.Responses;

[ExcludeFromCodeCoverage]
public class WebhookResponse
{
    public long update_id { get; set; }
    public Result message { get; set; }
}