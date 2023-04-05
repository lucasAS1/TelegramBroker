using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace TelegramBroker.Domain.Models.Requests;

[ExcludeFromCodeCoverage]
public class ReplyMarkup
{
    [JsonPropertyName("one_time_keyboard")]
    public bool OneTimeKeyboard { get; set; } = true;
    
    [JsonPropertyName("keyboard")]
    public List<List<string>> Keyboard { get; set; }
}