FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ShopLand.Api/ShopLand.Api.csproj", "ShopLand.Api/"]
COPY ["ShopLand.Application/ShopLand.Application.csproj", "ShopLand.Application/"]
COPY ["ShopLand.Domain/ShopLand.Domain.csproj", "ShopLand.Domain/"]
COPY ["Share/ShopLand.Share.Abstract/ShopLand.Share.Abstract.csproj", "Share/ShopLand.Share.Abstract/"]
COPY ["Share/ShopLand.Share/ShopLand.Share.csproj", "Share/ShopLand.Share/"]
COPY ["ShopLand.Infrastructure/ShopLand.Infrastructure.csproj", "ShopLand.Infrastructure/"]
RUN dotnet restore "./ShopLand.Api/ShopLand.Api.csproj"
COPY . .
WORKDIR "/src/ShopLand.Api"
RUN dotnet build "./ShopLand.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ShopLand.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ShopLand.Api.dll"]