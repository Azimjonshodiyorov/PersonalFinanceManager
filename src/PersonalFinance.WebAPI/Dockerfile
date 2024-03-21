FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/PersonalFinance.WebAPI/PersonalFinance.WebAPI.csproj", "src/PersonalFinance.WebAPI/"]
COPY ["src/PersonalFinance.Application/PersonalFinance.Application.csproj", "src/PersonalFinance.Application/"]
COPY ["src/PersonalFinance.Infrastructure/PersonalFinance.Infrastructure.csproj", "src/PersonalFinance.Infrastructure/"]
COPY ["src/PersonalFinance.Domain/PersonalFinance.Domain.csproj", "src/PersonalFinance.Domain/"]
RUN dotnet restore "src/PersonalFinance.WebAPI/PersonalFinance.WebAPI.csproj"
COPY . .
WORKDIR "/src/src/PersonalFinance.WebAPI"
RUN dotnet build "PersonalFinance.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "PersonalFinance.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PersonalFinance.WebAPI.dll"]
