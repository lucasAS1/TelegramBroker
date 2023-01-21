using System.Diagnostics.CodeAnalysis;
using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Options;
using Polly;
using TelegramBroker.Domain.Models.Requests;
using TelegramBroker.Domain.Models.Responses;
using TelegramBroker.Domain.Models.Settings;
using TelegramBroker.Infrastructure.Interfaces.Agents;

namespace TelegramBroker.Infrastructure.Agents.Telegram;

[ExcludeFromCodeCoverage]
public class TelegramAgent : ITelegramAgent
{
    private readonly string _url;
    private readonly string _apiToken;

    public TelegramAgent(IOptions<ApiSettings> config)
    {
        var configValues = config.Value;
        
        _url = configValues.TelegramApiUrl;
        _apiToken = configValues.TelegramApiToken;
    }
    
    public async Task<MessageResponse> SendMessage(MessageRequest request)
    {
        var resposta = await Policy
            .Handle<FlurlHttpException>()
            .RetryAsync(3)
            .ExecuteAsync(() => _url
                .AppendPathSegment(_apiToken)
                .AppendPathSegment("sendMessage")
                .SetQueryParams($"chat_id={request.ChatId}",$"text={request.Text}")
                .GetJsonAsync<MessageResponse>()
            );

        return resposta;
    }
}