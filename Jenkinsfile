pipeline {
    agent any

    tools {
        dotnetsdk 'dotnet-sdk-8'  // must be defined in Jenkins global tools config
    }

    environment {
        DOTNET_CLI_TELEMETRY_OPTOUT = "1"
    }

    stages {
        stage('Restore') {
            steps {
                echo '🔄 Restoring dependencies, downloading or installing all dependencies required to run the project...'
                bat 'dotnet restore'
            }
        }

        stage('Build') {
            steps {
                echo '🔨 Building project ....'
                bat 'dotnet build --configuration Release'
            }
        }

        stage('Test') {
            steps {
                echo '🧪 Running tests...'
                bat 'dotnet test --no-build --verbosity normal'
            }
        }

        stage('Publish') {
            steps {
                echo '📦 Publishing artifacts...'
                bat 'dotnet publish --configuration Release --output ./publish'
            }
        }
    }

    post {
        success {
            echo '✅ Build Succeeded!'
        }
        failure {
            echo '❌ Build Failed. Check logs.'
        }
    }
}
