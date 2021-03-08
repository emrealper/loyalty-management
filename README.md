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
```


## Description:
This repo contains a sample application which simulates members and account operations journey of Loyalty Management. The api consists of the following parts.

* **Enrollment** - Contains 3 `POST` method to `create a new member`, `define account for existing member` and `adding bulk members`. 
* **Earn & Burn** - Contains 2 `PUT` method to `collect point to an account` and `redeemed point from an account`
* **Search & List** - Contains 2 `GET` method to `filter members based on filter criteria` and `list all members`

