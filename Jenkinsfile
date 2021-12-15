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
        stage('Deploy'){
             steps{
                 sh 'export BUILD_ID=dontKillMe'
                 sh 'JENKINS_NODE_COOKIE=dontKillMe'
               sh '''for pid in $(lsof -t -i:5000); do
                       kill -9 $pid
               done'''
               sh 'BUILD_ID=dontKillMe nohup dotnet run --property:Configuration=Release --project=ArtSquare/Server --urls="https://192.168.56.20:5000" > /dev/null 2>&1 &'
             }
        }
    }
}
