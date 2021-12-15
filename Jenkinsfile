pipeline {
    agent any
    triggers {
        githubPush()
    }
    post {
        always {
step([$class: 'Mailer',
  notifyEveryUnstableBuild: true,
  recipients: emailextrecipients([culprits(), requestor()])])
        }
    }
}
