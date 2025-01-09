FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /CareVantageBackend
COPY ["CareVantageBackend/CareVantageBackend.csproj", "CareVantageBackend/"]
RUN dotnet restore "CareVantageBackend/CareVantageBackend.csproj"
COPY . .
WORKDIR /CareVantageBackend
RUN dotnet build "CareVantageBackend/CareVantageBackend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CareVantageBackend/CareVantageBackend.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CareVantageBackend.dll"]