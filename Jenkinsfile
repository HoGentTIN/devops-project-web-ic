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
            script{
                emailext (body: '${DEFAULT_CONTENT}',
                          recipientProviders: [[$class: 'CulpritsRecipientProvider']],
                          subject: '${DEFAULT_SUBJECT}',
                          to: 'benjamin.bappel@gmail.com')
            }
        }
        
    }
}
