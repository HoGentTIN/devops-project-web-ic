pipeline {
    agent any
    triggers {
        githubPush()
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
