pipeline {
    agent any
	
	parameters
	{
	string (

 
			name : 'solution',

 
			defaultValue: 'nextgen-call-tracking-system-pumping-project.sln',

 
			description: 'Solution File'

 
            )
			
			
	string (

 
			name : 'Test',

 
			defaultValue: 'NCTS.Tests/NCTS.Tests.csproj',

 
			description: 'Test File'

 
			)

	}
	
    stages { 
        stage('Build') {
        	
        	steps{
        		echo '==================================Building======================================='
			bat 'dotnet restore nextgen-call-tracking-system-pumping-project.sln --source https://api.nuget.org/v3/index.json --source http://stage-packagegallery.tavisca.com/api/odata -v:q'
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
