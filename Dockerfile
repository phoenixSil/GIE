FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Gie.Api/Gie.Api.csproj", "Gie.Api/"]
RUN dotnet restore "Gie.Api/Gie.Api.csproj"
COPY . .
WORKDIR "/src/Gie.Api"
RUN dotnet build "Gie.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Gie.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Gie.Api.dll"]