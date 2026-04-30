
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app


COPY . .


WORKDIR /app/Api


RUN dotnet restore
RUN dotnet publish -c Release -o out


FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build /app/Api/out .

ENV ASPNETCORE_URLS=http://+:8095
EXPOSE 8095

ENTRYPOINT ["dotnet", "Api.dll"]