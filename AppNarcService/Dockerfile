#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

ENV Database=appnarc-dev
ENV DatabaseHost=192.168.1.136
ENV DatabasePort=27017

FROM mcr.microsoft.com/dotnet/sdk:5.0
WORKDIR /src
COPY ["AppNarcServer.csproj", ""]
RUN dotnet restore "./AppNarcServer.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "AppNarcServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AppNarcServer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AppNarcServer.dll"]