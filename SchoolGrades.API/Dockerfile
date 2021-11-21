FROM mcr.microsoft.com/dotnet/aspnet:3.1-bionic AS base
WORKDIR /app
COPY . .

CMD ASPNETCORE_URLS=http://*:$PORT dotnet SchoolGrades.API.dll