using System.Diagnostics.CodeAnalysis;

namespace TelegramBroker.Domain.Models.Settings;

[ExcludeFromCodeCoverage]
public class ApiSettings
{
    public string TelegramApiToken { get; set; }
    public string TelegramApiUrl { get; set; }
}