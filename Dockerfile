# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS builder

WORKDIR /src

# Copy the project files
COPY . .

# Run dotnet restore
RUN dotnet restore

# Publish the application
RUN dotnet publish -c Release -o /app

# Run tests
RUN dotnet test --logger "trx;LogFileName=./aspnetapp.trx"

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0

# Set working directory
WORKDIR /app

# Copy build artifacts from the build stage
COPY --from=builder /app .

# Set the entry point
ENTRYPOINT ["dotnet", "aspnetapp.dll"]
