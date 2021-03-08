# loyalty-management

The primary goal of this sample is to explain following software-architecture concepts and container-technologies like:  
  
* CQRS  
* Domain Driven Design (DDD)  
* Docker
* Docker-Compose

and methods and tools to store and manage persistance like :
* PostgreSQL
* Entity Framework Core for Command operations
* Dapper for Query operations


## How to set up and run the project
You can run the bellow command from the **/source/LoyaltyMemberManagement/API/** directory to build docker image for  `WebApi` 
```powershell
docker build -f "Dockerfile" -t membermanagementapi_image ..
```

after building docker image of Web Api you can run the below command from the **/setup/** directory to run postgresql enviroment and also run initialize.sql

```powershell
docker-compose up
