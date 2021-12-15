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
            step([$class: 'Mailer',
  notifyEveryUnstableBuild: true,
  recipients: emailextrecipients([culprits(), requestor()])])

        }
    }
}
