FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

COPY ["Gie.Api/Gie.Api.csproj", "Gie.Api/"]
RUN dotnet restore

COPY ["Gie.Api/Gie.Api.csproj", "Gie.Api/"]
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT [ "dotnet", "Gie.Api.dll"]