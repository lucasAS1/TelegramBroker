using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using ChatbotProject.Common.Domain.Models.Requests;

namespace TelegramBroker.Domain.Models.Requests;

[ExcludeFromCodeCoverage]
public class TelegramMessageRequest
{
    [JsonPropertyName("chat_id")] public string ChatId { get; }

    [JsonPropertyName("text")] public string Text { get; }

    [JsonPropertyName("reply_markup")] public ReplyMarkup ReplyMarkup { get; }

    public TelegramMessageRequest(MessageRequest messageRequest)
    {
        ChatId = messageRequest.ChatId;
        Text = messageRequest.Text;

        ReplyMarkup = new ReplyMarkup()
        {
            Keyboard = new List<List<string>>()
        };

        if (messageRequest.InteractiveMessage is not null)
            AddInteractiveMessage(messageRequest);
    }

    private void AddInteractiveMessage(MessageRequest messageRequest)
    {
        if (messageRequest.InteractiveMessage.Type == InteractiveMessageType.Button)
        {
            ReplyMarkup.Keyboard.Add(messageRequest.InteractiveMessage.Options);

            return;
        }

        foreach (var listOption in
                 messageRequest.InteractiveMessage.Options.Select(option => new List<string>() { option }))
        {
            ReplyMarkup.Keyboard.Add(listOption);
        }
    }
}