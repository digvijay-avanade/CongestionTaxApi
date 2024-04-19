FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY ["congestiontaxapi.csproj", "/src"]
RUN dotnet restore "congestiontaxapi.csproj"
COPY . .

WORKDIR "/src"
RUN dotnet build "congestiontaxapi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "congestiontaxapi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "congestiontaxapi.dll"]