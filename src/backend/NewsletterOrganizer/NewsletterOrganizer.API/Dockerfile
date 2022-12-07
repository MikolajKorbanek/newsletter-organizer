FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["NewsletterOrganizer.API/NewsletterOrganizer.API.csproj", "NewsletterOrganizer.API/"]
RUN dotnet restore "NewsletterOrganizer.API/NewsletterOrganizer.API.csproj"
COPY . .
WORKDIR "/src/NewsletterOrganizer.API"
RUN dotnet build "NewsletterOrganizer.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NewsletterOrganizer.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NewsletterOrganizer.API.dll"]
