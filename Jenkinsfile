pipeline {
  agent any
  environment {
    APPNAME = "lab01"
    IMAGE = "lab01"
    VERSION ="v1"
    REGISTRY="julioest77"
    DOCKER_HUB_LOGIN = credentials('dockerhub-julioest77')
  }
  stages {
    stage('Build Image') {
      steps {
        sh "pwd"
        sh 'docker build -t $REGISTRY/$IMAGE:$VERSION .'
      }
    }
    stage('Docker push to Docker-hub') {
      steps {
        sh "docker login --username=$DOCKER_HUB_LOGIN_USR --password=$DOCKER_HUB_LOGIN_PSW"
        sh 'docker push $REGISTRY/$IMAGE:$VERSION'
      }
    }
  }
}
