FROM mcr.microsoft.com/dotnet/sdk:3.1
COPY . /app
WORKDIR /app
RUN ["dotnet", "restore"]
RUN dotnet build -o out
EXPOSE 5001
ENTRYPOINT dotnet out/ProductsSystem.Auth.dll