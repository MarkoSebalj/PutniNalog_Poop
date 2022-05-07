#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["REST.API.PN/REST.API.PN.csproj", "REST.API.PN/"]
RUN dotnet restore "REST.API.PN/REST.API.PN.csproj"
COPY . .
WORKDIR "/src/REST.API.PN"
RUN dotnet build "REST.API.PN.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "REST.API.PN.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "REST.API.PN.dll"]