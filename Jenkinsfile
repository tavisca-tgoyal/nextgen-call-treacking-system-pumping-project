pipeline {
    agent any
	
	parameters
	{
		string(default value: "nextgen-call-tracking-system-pumping-project.sln",description:'Solution File',name:'solution')
		string(default value:"NCTS.Tests/NCTS.Tests.scproj",description:'Test File',name:'Test')
	}
	
    stages { 
        stage('Build') {
        	
        	steps{
        		echo '==================================Building===================================='
        		bat 'dotnet build %solution% -p:Configuration=release -v:q'
        	}
        }
        stage('Test') {
        	
        	steps{
        		echo '================================Testing======================================='
        		bat 'dotnet test %test%'
        	}
        }
        stage('Publish') {
        	
        	steps{
        		echo '====================================Publishing==================================='
        		bat 'dotnet publish %solution% -c RELEASE -o Publish'
        	}
        }
		
		}
		}