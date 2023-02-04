using System.Diagnostics.CodeAnalysis;

namespace TelegramBroker.Domain.Models.Settings;

[ExcludeFromCodeCoverage]
public class ApiSettings
{
    public string TelegramApiToken { get; init; } = null!;
    public string TelegramApiUrl { get; init; } = null!;
    public RabbitMqSettings RabbitMqSettings { get; init; } = null!;
}