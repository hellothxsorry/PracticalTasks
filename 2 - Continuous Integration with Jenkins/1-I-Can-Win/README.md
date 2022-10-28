"I Can Win":
- Install Jenkins.
- Create a task which will perform the following:
  - Clone the project.  
  - Launch tests from the project in ~~Java directory with the help of mvn test goal~~ 
    .NET directory (since this is not Java course but .NET one) with the help of VSTest  
- Set up build triggers so that the task is performed every 5 minutes

![image](https://user-images.githubusercontent.com/50228202/189135282-f60b3ab5-55e7-43bb-b5c8-98d9b3d1dfcb.png)
<p align="center"><i>Creating a new job "I Can Win".</i></p>

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

![image](https://user-images.githubusercontent.com/50228202/189146219-4e75eba3-19a6-440e-b716-28beb38c3271.png)
<p align="center"><i>Setting up the build triggers to perform every 5 minutes.</i></p>

![image](https://user-images.githubusercontent.com/50228202/189150697-ed105c8d-acf3-4f05-91bc-0c008eaeab71.png)
![image](https://user-images.githubusercontent.com/50228202/189153848-a9f0da2a-e370-4a85-b664-e4187c024c43.png)
![image](https://user-images.githubusercontent.com/50228202/189154925-8ef96aa9-0d5b-44e0-835c-58fc32431f73.png)
<p align="center"><i>Tests' results.</i></p>

![image](https://user-images.githubusercontent.com/50228202/189153324-524d7ae8-aabd-4c9e-9e1f-88f18217d37c.png)
![image](https://user-images.githubusercontent.com/50228202/189153605-c4e470e1-4f97-444a-b4c5-def8dfaa50ae.png)
![image](https://user-images.githubusercontent.com/50228202/189153626-c3851e77-aeae-48f3-a68d-c4b972994b63.png)
<p align="center"><i>Performing every 5 minutes.</i></p>
