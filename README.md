# SocialMarket API

## Overview

SocialMarket is a web API and social media designed to fetch and display cryptocurrency data and build a new social media for cryptocurrency community. This project demonstrates the use of modern API development practices using .NET and integrates social media features for enhanced user engagement.

## Features

### Cryptocurrency Data
- Retrieve current cryptocurrency prices and market data.
- Fetch historical data for various cryptocurrencies.
- Get detailed information about specific coins.

### Social Media Integration
- Share your cryptocurrency idea updates on your own social media platform!
- Fetch and display trending cryptocurrencies from social media.
- Post user comments and discussions.
## Getting Started

Follow these steps to set up and run the CoinMarket API project on your local machine.

### Prerequisites

Make sure you have the following installed:
- [.NET SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or another compatible database
- [Git](https://git-scm.com/)



## Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/zaferavci1/SchoolProject.git
   cd SchoolProject

2. Set up the database:
-Create a new database in your SQL Server or another compatible database.
-Update the connection string in ['appsettings.json'](https://github.com/zaferavci1/SchoolProject/blob/main/Presentation/SchoolProject.API/appsettings.json)

3. Apply database migrations:
   ```bash
   cd SchoolProject/Infrastructure/SchoolProject.Persistence
   dotnet ef database update

4. Install dependencies.
   ```bash
   cd ../../Presentation/SchoolProject.API
   dotnet restore
   dotnet build 

5. Run the application.
   ```bash
   dotnet run

Your CoinMarket API should now be running locally. You can access it at https://localhost:5001 (or the port specified in your launchSettings.json).:

##Example Requests
You can use tools like Postman or curl to test the API endpoints. Here’s an example using curl:

Here is an Register request:
    ```bash
    
    curl -X POST https://localhost:5001/api/Auth/Register -H "Content-Type: application/json" -d '{
        "nickName": "myNickName",
        "name": "MyName",
        "surname": "MySurname",
        "mail": "example@gmail.com",
        "phoneNumber": "+30 380 4534342",
        "password": "ReallyStrongPassword1.!"
      }'

Here is an request for get your users:

    ```bash
  
       curl -X 'GET' \
      'https://localhost:7154/api/User/GetAll?Page=0&Size=10' \
      -H 'accept: */*'  \
      -H  "Authorization: Bearer your_jwt_token"

Make sure you Replace your_jwt_token with the actual JWT token you receive upon successful authentication.

## Contributing

1. Fork the repository.
2. Create a new branch (git checkout -b feature-branch).
3. Make your changes.
4. Commit your changes (git commit -am 'Add new feature').
5. Push to the branch (git push origin feature-branch).
6. Create a new Pull Request.
