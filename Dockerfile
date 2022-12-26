#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://*:8080

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Gie.Api/Gie.Api.csproj", "Gie.Api/"]
COPY ["Gie.Domain/Gie.Domain.csproj", "Gie.Domain/"]
COPY ["Gie.Features/Gie.Features.csproj", "Gie.Features/"]
COPY ["Gie.Ioc/Gie.Ioc.csproj", "Gie.Ioc/"]
COPY ["Gie.Application/Gie.Application.csproj", "Gie.Application/"]
COPY ["Gie.Data/Gie.Data.csproj", "Gie.Data/"]
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