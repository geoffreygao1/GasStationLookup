# _Gas Station Lookup_

#### By _Geoffrey Gao_

#### _An application that helps to track Gas Station locations and prices_

## Technologies Used

* _C#_
* _ASP.Net Core MVC_
* _Entity Framework Core_
* _MySQL_

## Description

_This application contains an API framework that interacts with a SQL database to track gas station locations and gas prices. The API has full CRUD functionality for each model. The API also has additional functionality, such as querying, sorting, and random returns. The project demonstrates solid understanding of the new concepts from the Building an API coursework including MVC, SQL, and Entity Framework Core._


## How To Run This Project

### Install Tools

If you have not already, install the `dotnet-ef` tool by running the following command in your terminal:

```
dotnet tool install --global dotnet-ef --version 6.0.0
```

### Set Up and Run Project

* _Clone this repository_
* _Open your shell (e.g., Terminal or GitBash) and navigate into the "GasStationTrackerApi.Solution" production directory_
* _Within the production directory "GasStationLookupApi.Solution", create two new files: `appsettings.json` and `appsettings.Development.json`_
* _Within `appsettings.json`, put in the following code. Make sure to replacing the `uid` and `pwd` values in the MySQL database connection string with your own username and password for MySQL_

```JSON
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=gasstationlookup_api;uid=root;pwd=epicodus;"
  }
}
```

5. Within `appsettings.Development.json`, add the following code:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Trace",
      "Microsoft.AspNetCore": "Information",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  }
}
```

* _Create the database using the migrations in the GasStationLookup API project. Open your shell (e.g., Terminal or GitBash) to the production directory "GasStationLookupApi.Solution", and run `dotnet ef database update`._ 
* _In the terminal, run the program with `dotnet watch run` to start the project in development mode with a watcher_
* _If the application does not automatically launch, open the browser to [https://localhost:5001](https://localhost:5001)_

## Available Endpoints

### Companies

```
GET https://localhost:5001/api/companies/
GET https://localhost:5001/api/companies/Random
GET https://localhost:5001/api/companies/{id}
GET https://localhost:5001/api/companies/{id}/Stations
POST https://localhost:5001/api/companies/
PUT https://localhost:5001/api/companies/{id}
DELETE https://localhost:5001/api/companies/{id}
```

Note: `{id}` is a variable and it should be replaced with the id number of the animal you want to GET, PUT, or DELETE.

#### Optional Query String Parameters for GET Request

GET requests to `http://localhost:5000/api/companies/` can optionally include query strings to search or sort companies.

| Parameter   | Type        |  Required    | Description |
| ----------- | ----------- | -----------  | ----------- |
| species     | String      | not required | Returns animals with a matching species value |
| name        | String      | not required | Returns animals with a matching name value |
| minimumAge  | Number      | not required | Returns animals that have an age value that is greater than or equal to the specified minimumAge value |

The following query will return all animals with a species value of "Dinosaur":

```
GET http://localhost:5000/api/animals?species=dinosaur
```

The following query will return all animals with the name "Matilda":

```
GET http://localhost:5000/api/animals?name=matilda
```

The following query will return all animals with an age of 10 or older:

```
GET http://localhost:5000/api/animals?minimumAge=10
```

You can include multiple query strings by separating them with an `&`:

```
GET http://localhost:5000/api/animals?species=dinosaur&minimumAge=10
```

#### Additional Requirements for POST Request

When making a POST request to `http://localhost:5000/api/animals/`, you need to include a **body**. Here's an example body in JSON:

```json
{
  "species": "Tyrannosaurus Rex",
  "name": "Elizabeth",
  "age": 8
}
```

#### Additional Requirements for PUT Request

When making a PUT request to `http://localhost:5000/api/animals/{id}`, you need to include a **body** that includes the animal's `animalId` property. Here's an example body in JSON:

```json
{
  "animalId": 1,
  "species": "Tyrannosaurus Rex",
  "name": "Lizzy",
  "age": 9
}
```

And here's the PUT request we would send the previous body to:

```
http://localhost:5000/api/animals/1
```

Notice that the value of `animalId` needs to match the id number in the URL. In this example, they are both 1.

## Known Bugs

* _N/A_

## License

_MIT_

Copyright (c) _2023_ _Geoffrey Gao_