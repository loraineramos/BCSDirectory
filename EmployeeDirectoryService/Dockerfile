FROM microsoft/aspnetcore:2.0-nanoserver-1709 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0-nanoserver-1709 AS build
WORKDIR /src
COPY EmployeeDirectoryService/EmployeeDirectoryService.csproj EmployeeDirectoryService/
RUN dotnet restore EmployeeDirectoryService/EmployeeDirectoryService.csproj
COPY . .
WORKDIR /src/EmployeeDirectoryService
RUN dotnet build EmployeeDirectoryService.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish EmployeeDirectoryService.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "EmployeeDirectoryService.dll"]
