# Practical Task 2
"Continuous Integration with Jenkins" module: 

2.1 "I Can Win": 
- Install Jenkins.
- Create a task which will perform the following:
    - Clone the project.
    - Launch tests from the project in Java directory with the help of mvn test goal
- Set up build triggers so that the task is performed every 5 minutes

2.2 "Bring It On":
- Install Jenkins.
- Create the task which will perform the following:
    - Clone the project
    - Launch tests from the project in Java directory with the help of mvn test goal
- Set up build triggers:
    - Launch tests not later than 5 minutes after committing in git
    - Every workday at midnight
- Publish “Java\target\surefire-reports\com.github.vitalliuss.helloci.AppTest.txt” file as an artifact

2.3 "Hurt Me Plenty":
This task is based on Bring It On task.
- Change the server port for 8081
- Create a node and set up a server so that the job is performed on a slave-node only
- Set up Job Config History and thinBackup

2.4 "Hardcore":
This task is based on Hurt Me Plenty task:
- Create a user and give him permission to read-only mode for Jinkins jobs without the access to edit or change settings
- Create a parametrized job HelloUser which will ask for a user name as a parameter and output "Hello, username!" in the console
- Mesure unit tests code coverage with the help of the goal  mvn cobertura:cobertura and publish it on the job page as a graphic

2.5 "Nightmare!":
Perform all the previous tasks using node on Linux.

Was not able to complete the last part of 2.4 "Hardcore" since the task requires to use MVN Cobertura and an alternative for C# was not found.
The entire 2.5 "Nightmare!" is also not completed due to lack of information about compatible plugins for Linux version of Jenkins.
