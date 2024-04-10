pipeline {
    agent any
    
    stages {
        stage('Checkout') {
            steps {
                echo 'Starting Checkout stage...'
                git url: 'https://github.com/aparnajoshi31/DotnetAppDevops.git', branch: 'master'
                echo 'Checkout stage completed.'
            }
        }

        stage('Check Content') {
            steps {
                echo 'Starting Check Content stage...'
                sh 'ls -l'
                echo 'Check Content stage completed.'
            }
        }
        
        stage('Build') {
            steps {
                echo 'Starting Build stage...'
                dir('DotnetPipelineApp') { // Replace 'path/to/project' with the actual path to your project
                    sh 'dotnet build'
                }
                echo 'Build stage completed.'
            }
        }
        
        stage('Test') {
            steps {
                echo 'Starting Test stage...'
                dir('DotnetPipelineApp') { // Replace 'path/to/project' with the actual path to your project
                    sh 'dotnet test'
                }
                echo 'Test stage completed.'
            }
        }
    }
}
