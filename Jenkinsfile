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
               success {
            script{ emailext (body: '${DEFAULT_CONTENT}',
                              recipientProviders: [[$class: 'CulpritsRecipientProvider']],
                              subject: '${DEFAULT_SUBJECT}',
                              to: 'benjamin.bappel@gmail.com')
            }
        }
        failure {
            script{ emailext (body: '${DEFAULT_CONTENT}',
                              recipientProviders: [[$class: 'CulpritsRecipientProvider']],
                              subject: '${DEFAULT_SUBJECT}',
                              to: 'benjamin.bappel@gmail.com')
            }
        }
        unstable {
            script{ emailext (body: '${DEFAULT_CONTENT}',
                              recipientProviders: [[$class: 'CulpritsRecipientProvider']],
                              subject: '${DEFAULT_SUBJECT}',
                              to: 'benjamin.bappel@gmail.com')
            }
        }
        changed {
            script{ emailext (body: '${DEFAULT_CONTENT}',
                              recipientProviders: [[$class: 'CulpritsRecipientProvider']],
                              subject: '${DEFAULT_SUBJECT}',
                              to: 'benjamin.bappel@gmail.com')
            }
        }
    }
}
