#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/MyAwardProgram.Api/MyAwardProgram.Api.csproj", "src/MyAwardProgram.Api/"]
RUN dotnet restore "src/MyAwardProgram.Api/MyAwardProgram.Api.csproj"
COPY . .
WORKDIR "/src/src/MyAwardProgram.Api"
RUN dotnet build "MyAwardProgram.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyAwardProgram.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyAwardProgram.Api.dll"]