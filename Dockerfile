# Use the base image with ASP.NET runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Install Docker inside the container
USER root
RUN apt-get update && \
    apt-get install -y apt-transport-https ca-certificates curl gnupg-agent software-properties-common && \
    curl -fsSL https://download.docker.com/linux/ubuntu/gpg | apt-key add - && \
    add-apt-repository "deb [arch=amd64] https://download.docker.com/linux/ubuntu $(lsb_release -cs) stable" && \
    apt-get update && \
    apt-get install -y docker-ce docker-ce-cli containerd.io

# Add Jenkins user and group with appropriate permissions
RUN groupadd -g 1001 jenkins && useradd -u 1001 -g 1001 -m -s /bin/bash jenkins && usermod -aG docker jenkins

# Switch back to the Jenkins user
USER jenkins

# Set the working directory and copy the project files
WORKDIR /src
COPY ["DotnetPipelineApp/DotnetPipelineApp.csproj", "DotnetPipelineApp/"]
RUN dotnet restore "DotnetPipelineApp/DotnetPipelineApp.csproj"
COPY . .

# Build and publish the application
WORKDIR "/src/."
RUN dotnet build "DotnetPipelineApp/DotnetPipelineApp.csproj" -c Release -o /app/build

# Set up the final stage for the container
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "DotnetPipelineApp.dll"]
