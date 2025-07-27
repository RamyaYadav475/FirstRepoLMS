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
                echo '🧪 Running tests....'
                bat 'dotnet test --no-build --verbosity normal'
            }
        }

        stage('Publish') {
            steps {
                echo '📦 Publishing artifacts...'
                bat 'dotnet publish --configuration Release --output ./publish'
            }
        }

        // stage('Publish Artifacts') {
        //     steps {
        //         sh 'dotnet publish -c Release -o publish'
        //     }
        // }

        stage('Archive Build Output') {
            steps {
                archiveArtifacts artifacts: 'publish/**/*.*', fingerprint: true
            }
        }
    }

    post {
        success {
            echo '✅ Build & Artifact creation successful!'
        }
        failure {
            echo '❌ Build failed. Please check logs.'
        }
    }
}
