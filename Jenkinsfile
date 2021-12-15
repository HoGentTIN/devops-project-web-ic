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
    }
    post {
        always {
            emailext body: developers(),
            recipientProviders: [developers(), requestor()],
            subject: 'Test Subject',
            to: 'benjamin.bappel@gmail.com'

        }
    }
}
