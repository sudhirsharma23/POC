#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["FilesAPI/FilesAPI.csproj", "FilesAPI/"]
COPY ["CP.Core.User/CP.Core.User.csproj", "CP.Core.User/"]
COPY ["CP.DTO/CP.DTO.csproj", "CP.DTO/"]
COPY ["FA.Common/FA.Common.csproj", "FA.Common/"]
RUN dotnet restore "FilesAPI/FilesAPI.csproj"
COPY . .
WORKDIR "/src/FilesAPI"
RUN dotnet build "FilesAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FilesAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FilesAPI.dll"]