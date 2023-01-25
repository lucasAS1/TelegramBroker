FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

RUN addgroup -S telegrambroker \
    && adduser -S telegrambroker -G telegrambroker

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TelegramBroker.Application.WebApi/TelegramBroker.Application.WebApi.csproj", "TelegramBroker.Application.WebApi/"]
RUN dotnet restore "TelegramBroker.Application.WebApi/TelegramBroker.Application.WebApi.csproj"
COPY ../ .
WORKDIR "/src/TelegramBroker.Application.WebApi"
RUN dotnet build "TelegramBroker.Application.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TelegramBroker.Application.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
USER telegrambroker
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TelegramBroker.Application.WebApi.dll"]
