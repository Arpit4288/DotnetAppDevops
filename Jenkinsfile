pipeline {
    agent any

    stages {
        stage('Checkout') {
            steps {
                // Checkout source code from Git
                git url: 'https://github.com/aparnajoshi31/DotnetAppDevops.git'
            }
        }
        stage('Build') {
            steps {
                // Build the .NET project
                sh 'dotnet build DotnetPipelineApp.sln'
            }
        }
        stage('Test') {
            steps {
                // Run tests
                sh 'dotnet test DotnetPipelineApp.Tests/DotnetPipelineApp.Tests.csproj'
            }
        }
    }
}
