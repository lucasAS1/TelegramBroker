using System.Diagnostics.CodeAnalysis;

namespace TelegramBroker.Domain.Models.Settings;

[ExcludeFromCodeCoverage]
public class RabbitMqSettings
{
    public string HostName { get; init; } = null!;
    public string Password { get; init; } = null!;
    public int Port { get; init; } = 0;
    public string UserName { get; init; } = null!;
}