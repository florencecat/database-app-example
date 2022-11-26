# 3-layer architecture + patterns "Unit of work" and "Repository"
This application demonstrates using of 3-layer architecture (Business Logic Layer, Data Access Layer and Presentation Layer).
It bases on .NET Framework 4.8 and uses EntityFramework for connection with simple DataBase.
Interaction between layers realized with Interfaces, it helps to ease dependencies.

Here is scheme about how layers are linked: PL <-> BLL <-> DAL