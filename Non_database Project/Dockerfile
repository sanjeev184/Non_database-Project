#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Non_database Project/Non_database Project.csproj", "Non_database Project/"]
RUN dotnet restore "Non_database Project/Non_database Project.csproj"
COPY . .
WORKDIR "/src/Non_database Project"
RUN dotnet build "Non_database Project.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Non_database Project.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Non_database Project.dll"]