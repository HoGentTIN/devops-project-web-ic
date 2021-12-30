pipeline {
    agent any
    triggers {
        githubPush()
    }
    stages {
        stage('configure'){
           steps{
               sh 'git stash'
               sh 'git pull'
            }
        }
        stage('Restore packages'){
           steps{
               sh 'dotnet restore ArtSquare/ArtSquare.sln'
            }
         }
        stage('Clean'){
           steps{
               sh 'dotnet clean ArtSquare/ArtSquare.sln --configuration Release'
            }
         }
        stage('Build'){
           steps{
               sh 'dotnet build ArtSquare/ArtSquare.sln --configuration Release --no-restore'
            }
         }
        stage('Publish'){
             steps{
               sh 'dotnet publish ArtSquare/Server/ArtSquare.Server.csproj --configuration Release --no-restore'
             }
        }
        stage('Fake Run'){
             steps{
               sh 'dotnet run --property:Configuration=Release --project=ArtSquare/Server'
             }
        }
    }
    post {
        always {
            script{
                emailext (body: '${DEFAULT_CONTENT}',
                          recipientProviders: [[$class: 'CulpritsRecipientProvider']],
                          subject: '${DEFAULT_SUBJECT}',
                          to: 'benjamin.bappel@student.hogent.be')
            }
        }
        
    }
}
