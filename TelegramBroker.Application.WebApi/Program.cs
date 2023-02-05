using Autofac;
using Autofac.Extensions.DependencyInjection;
using RabbitMQ.Client.Core.DependencyInjection;
using TelegramBroker.Application.WebApi.DI;
using TelegramBroker.Application.WebApi.MessageHandlers;
using TelegramBroker.Domain.Models.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Configuration
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables();
builder.Services.Configure<ApiSettings>(builder.Configuration.GetSection("Settings"));
builder.Services
    .AddRabbitMqServices(builder.Configuration.GetSection("Settings:RabbitMqSettings:RabbitMqConnection"))
    .AddConsumptionExchange("service-telegram", builder.Configuration.GetSection("Settings:RabbitMqSettings:ExchangeService"))
    .AddProductionExchange("telegram-service", builder.Configuration.GetSection("Settings:RabbitMqSettings:ExchangeTelegram"))
    .AddAsyncMessageHandlerSingleton<TelegramMessageHandler>("service-to-telegram");

builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new IocContainer()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();