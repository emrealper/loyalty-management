# loyalty-management

The primary goal of this sample is to explain following software-architecture concepts and container-technologies like:  
  
* CQRS  
* Domain Driven Design (DDD)  
* Docker
* Docker-Compose

and methods and tools to manage persistance and its transactions like :
* PostgreSQL on docker
* Entity Framework Core for `Command operations`
* Dapper for `Query operations`


## How to set up and run the project
You can run the bellow command from the **/source/LoyaltyMemberManagement/API/** directory to build docker image for  `WebApi` 
```powershell
docker build -f "Dockerfile" -t membermanagementapi_image ..
```

after building docker image of Web Api you can run the below command from the **/setup/** directory to up postgresql enviroment by executing initialize.sql located in **/setup/sql/initialize.sql**

```powershell
docker-compose up
```


## Description:
This repo contains a sample application which simulates members and account operations journey of Loyalty Management. The api consists of the following parts.

* **Enrollment** - Contains 3 `POST` method to `create a new member`, `define account for existing member` and `adding bulk members`. 
* **Earn & Burn** - Contains 2 `PUT` method to `collect point to an account` and `redeemed point from an account`
* **Search & List** - Contains 2 `GET` method to `filter members based on filter criteria` and `list all members`


## Use Case

After up and running `docker-compose.yml`, please open the following url to access swagger ui locally: http://localhost:5000/swagger/index.html

![swagger](https://github.com/emrealper/loyalty-management/blob/main/media/swaggerui.png)

This reference app describes sample flow for using Loyalty Management Member API :
1. Initially import existing members
2. Enroll a new member
3. Enroll a new account for defined member
4. Collect points to an existing account
5. Redeem points from an existing account
6. Search members using a sample filter criteria
7. List all members

### 1. Initially import existing members
Sample request body from POST `/api/Member/MembersBulkCreate`

``` 
[
	{
		"Name": "Anakin Skywalker",
		"Address": "Landsberger Straße 110",
		"Accounts": 
		[
			{
				"Name": "Burger King",
				"Balance": 10,
				"Status": "ACTIVE"
			},
			{
				"Balance": 150,
				"Status": "INACTIVE",
				"Name": "Fitness First"
			}
		]
	},
	{
		"Name": "Darth Vader",
		"Address": "Landsberger Straße 112",
		"Accounts": 
		[
			{
				"Balance": 10,
				"Status": "ACTIVE",
				"Name": "Lufthansa"
			}
		]
	},
	{
		"Name": "Obi-Wan Kenobi",
		"Address": "Landsberger Straße 114",
		"Accounts": 
		[
			{
				"Balance": 0,
				"Status": "ACTIVE",
				"Name": "Lufthansa"
			},
			{
				"Balance": 17,
				"Status": "ACTIVE",
				"Name": "Fitness First"
			},
			{
				"Name": "Burger King",
				"Balance": 20,
				"Status": "ACTIVE"
			}
		]
	},
	{
		"Name": "Yoda",
		"Address": "Landsberger Straße 114",
		"Accounts": 
		[
			{
				"Balance": 10,
				"Status": "ACTIVE",
				"Name": "Lufthansa"
			}
		]
	}
]
```

After adding bulk member data; postgresql table will be as follows

![members](https://github.com/emrealper/loyalty-management/blob/main/media/members.png)

![memberaccounts](https://github.com/emrealper/loyalty-management/blob/main/media/memberaccounts.png)


### 2. Enroll a new member
Sample request body for POST `/api/Member/CreateMember`

```
{
  "name": "A. Emre Alper",
  "address": "Landsberger Straße 118"
}
```

### 3. Enroll a new account for defined member. Creates a new empty account (with zero balance) 
Sample request body for POST `/api/Member/CreateNewAccount`

```
{
  "memberId": 5,
  "memberAccount": {
    "name": "Tchibo"
  }
}
```

### 4. Collect points to an existing account
Sample request body for PUT `/api/Account/CollectPoint`

```
{
  "memberAccountId": 1,
  "point": 100
}
```

### 5. Redeem points from an existing account.
Sample request body for PUT `/api/Account/RedeemPoint`

```
{
  "memberAccountId": 1,
  "point": 100
}
```
Expected response if the account `balance is not enough`:

```
"Existing balance is not enough to redeem the point"
```

Expected response if the account is `INACTIVE`:

```
"Points cannot be redeemed from inactive account"
```

### 6. Search members using a sample filter criteria.
Sample request: GET /api/Search/20/INACTIVE

### 7. List all members.
Sample request: GET /api/Search/ListAll


## Unit Tests

You can see domain and application level unit test on Member.UnitTest project from **/source/Member.UnitTests/**

![unittests](https://github.com/emrealper/loyalty-management/blob/main/media/unittests.png)

## Log Monitoring

Error logs are able to monitor using centralized structured monitoring (Seq)

![seq](https://github.com/emrealper/loyalty-management/blob/main/media/seq.png)




## Author
- Name: **Emre Alper**
- Contact: **emrealper@gmail.com**
