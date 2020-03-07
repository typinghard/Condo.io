FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["CondominioService/CondominioService.WebApp.MVC/CondominioService.WebApp.MVC.csproj", "CondominioService/CondominioService.WebApp.MVC/"]
RUN dotnet restore "CondominioService/CondominioService.WebApp.MVC/CondominioService.WebApp.MVC.csproj"
COPY . .
WORKDIR "/src/CondominioService/CondominioService.WebApp.MVC"
RUN dotnet build "CondominioService.WebApp.MVC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CondominioService.WebApp.MVC.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CondominioService.WebApp.MVC.dll"]