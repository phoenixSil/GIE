FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS build-env
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0
WORKDIR /src
COPY ["Gie.Api/Gie.Api.csproj", "Gie.Api/"]
RUN dotnet restore "Gie.Api/Gie.Api.csproj"

COPY "Gie.Api/" "Gie.Api/"
WORKDIR "/src/Gie.Api"
RUN dotnet publish "Gie.Api.csproj" -c Release -o out


WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Gie.Api.dll"]