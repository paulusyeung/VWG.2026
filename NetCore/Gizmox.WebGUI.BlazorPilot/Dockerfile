FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Gizmox.WebGUI.BlazorPilot.csproj", "./"]
RUN dotnet restore "Gizmox.WebGUI.BlazorPilot.csproj"
COPY . .
RUN dotnet publish "Gizmox.WebGUI.BlazorPilot.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Gizmox.WebGUI.BlazorPilot.dll"]
