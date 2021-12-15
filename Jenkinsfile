pipeline {
    agent any
    triggers {
        githubPush()
    }
    stages {
    }
    post {
        always {
            emailext body: 'Test Message',
    recipientProviders: [developers(), requestor()],
    subject: 'Test Subject',
    to: 'benjamin.bappel@gmail.com'

        }
    }
}
