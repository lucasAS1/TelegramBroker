﻿using System.Diagnostics.CodeAnalysis;

namespace TelegramBroker.Domain.Models.Responses;

[ExcludeFromCodeCoverage]
public class Chat
{
    public int id { get; set; }
    public string first_name { get; set; }
    public string last_name { get; set; }
    public string username { get; set; }
    public string type { get; set; }
}