#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["smart_family_backend/smart_family_backend.csproj", "smart_family_backend/"]
RUN dotnet restore "smart_family_backend/smart_family_backend.csproj"
COPY . .
WORKDIR "/src/smart_family_backend"
RUN dotnet build "smart_family_backend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "smart_family_backend.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "smart_family_backend.dll"]