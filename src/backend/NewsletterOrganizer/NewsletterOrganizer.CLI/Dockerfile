FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["NewsletterOrganizer.CLI/NewsletterOrganizer.CLI.csproj", "NewsletterOrganizer.CLI/"]
RUN dotnet restore "NewsletterOrganizer.CLI/NewsletterOrganizer.CLI.csproj"
COPY . .
WORKDIR "/src/NewsletterOrganizer.CLI"
RUN dotnet build "NewsletterOrganizer.CLI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NewsletterOrganizer.CLI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NewsletterOrganizer.CLI.dll"]
