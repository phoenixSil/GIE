FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS build-env
WORKDIR /app

COPY ["Gie.Api/Gie.Api.csproj", "Gie.Api/"]
RUN dotnet restore "Gie.Api/TEST.Api.csproj"

COPY . .
WORKDIR "/src/Gie.Api"
RUN dotnet build "Gie.Api.csproj" -c Release -o /app/build

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Gie.Api.dll"]