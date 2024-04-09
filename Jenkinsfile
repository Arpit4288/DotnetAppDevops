pipeline {
    agent any

    stages {
        stage('Configure .NET SDK') {
            steps {
                script {
                    // Set the path to the dotnet executable
                    def dotnetPath = tool 'dotnet'
                    env.PATH = "${dotnetPath}:${env.PATH}"
                }
            }
        }
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
