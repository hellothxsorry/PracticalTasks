"Bring It On":
- Install Jenkins.
- Create the task which will perform the following:
  - Clone the project
  - Launch tests from the project in ~~Java directory with the help of mvn test goal~~ 
    .NET directory (since this is not Java course but .NET one) with the help of VSTest
- Set up build triggers:
  - Launch tests not later than 5 minutes after committing in git
  - Every workday at midnight
- Publish “Java\target\surefire-reports\com.github.vitalliuss.helloci.AppTest.txt” file as an artifact

![image](https://user-images.githubusercontent.com/50228202/189601843-3fc5eba7-c9a6-483a-bb2b-ac2e9d7b72ad.png)
<p align="center"><i>Creating a new job "Bring It On".</i></p>

![image](https://user-images.githubusercontent.com/50228202/189137805-c8d16985-619c-410b-9917-7bff0f80c27a.png)
<p align="center"><i>Adding a git repository to clone the project.</i></p>

![image](https://user-images.githubusercontent.com/50228202/189145825-e3ca32f7-e8e7-43f3-957c-4e4b1010b5bd.png)
<p align="center"><i>Restoring the NuGet package(s) references of the cloned project.</i></p>

![image](https://user-images.githubusercontent.com/50228202/189138901-73f3de45-b7a5-4001-9aa6-cb365dffbde3.png)
![image](https://user-images.githubusercontent.com/50228202/189138726-18036acd-c469-41b4-a7c1-cb273713fe1f.png)
<p align="center"><i>Choosing MSBuild in order to build the cloned project.</i></p>

![image](https://user-images.githubusercontent.com/50228202/189140900-321774f6-6cf5-4a1d-b75f-5367904cfd17.png)
![image](https://user-images.githubusercontent.com/50228202/189150414-ef8b3b5f-f29b-4fd4-88f2-a32b0d72f9a1.png)
<p align="center"><i>Launching test with VSTest once the projected is builded.</i></p>

![image](https://user-images.githubusercontent.com/50228202/189666095-50693efb-2424-49b8-8b40-97ce29172668.png)
<p align="center"><i>Check for SCM changes within every 4 minutes to launch tests not later than 5 minutes after git commit.</i></p>
<p align="center"><i>Might be more efficient with launching the tests by webhook trigger instead of checking SCM for changes every 1-4 minutes. However, it would require an access to repo's authorization token.</i></p>

![image](https://user-images.githubusercontent.com/50228202/189667593-d0c87b19-3e47-4fc3-b243-048d52b666d0.png)
<p align="center"><i>Launch tests every workday at midnight.</i></p>

![image](https://user-images.githubusercontent.com/50228202/189668732-9dac5c83-61e9-4f59-951e-5a68cba32edb.png)
![image](https://user-images.githubusercontent.com/50228202/189668853-19e5634d-7825-4542-b42b-0d6a6315aaa0.png)
<p align="center"><i>Archive the tests' results as an artifact.</i></p>
