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

* _Within `appsettings.Development.json`, add the following code:_

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

Note: `{id}` is a variable and it should be replaced with the id number of the company, station, or gas price you want to GET, PUT, or DELETE.


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

### Stations

```
GET https://localhost:5001/api/stations/
GET https://localhost:5001/api/stations/Random
GET https://localhost:5001/api/stations/{id}
GET https://localhost:5001/api/stations/{id}/gasprices
GET https://localhost:5001/api/stations/{id}/AveragePrice/{gasType}
POST https://localhost:5001/api/stations/
PUT https://localhost:5001/api/stations/{id}
DELETE https://localhost:5001/api/stations/{id}
```

### GasPrices

```
GET https://localhost:5001/api/gasprices/
GET https://localhost:5001/api/gasprices/Random
GET https://localhost:5001/api/gasprices/{id}
POST https://localhost:5001/api/gasprices/
PUT https://localhost:5001/api/gasprices/{id}
DELETE https://localhost:5001/api/gasprices/{id}
```


#### Optional Query String Parameters for GET Request

GET requests to `http://localhost:5000/api/companies/` can optionally include query strings to search or sort companies.

| Parameter   | Type        |  Required    | Description |
| ----------- | ----------- | -----------  | ----------- |
| name        | String      | not required | Returns companies with the matching name |
| sortOrder   | String      | not required | Returns companies sorted by sortOrder. The options are: "name" and "name_desc"|
| x-api-version  | String   | not required | Returns response matching API verison number |

GET requests to `http://localhost:5000/api/stations/` can optionally include query strings to search or sort stations.

| Parameter   | Type        |  Required    | Description |
| ----------- | ----------- | -----------  | ----------- |
| address        | String      | not required | Returns stations located in the search address |
| city        | String      | not required | Returns stations located in the search city |
| state       | String      | not required | Returns stations located in the search state |
| sortOrder   | String      | not required | Returns stations sorted by sortOrder. The options are: "state", "state_desc", "city", and "city_desc" |
| x-api-version  | String   | not required | Returns response matching API verison number |

GET requests to `http://localhost:5000/api/gasprices/` can optionally include query strings to search or sort gas prices.

| Parameter   | Type        |  Required    | Description |
| ----------- | ----------- | -----------  | ----------- |
| sortOrder   | String      | not required | Returns gas prices sorted by sortOrder. The options are: "unleaded", "unleaded_desc", "premium", "premium_desc", "diesel", and "diesel_desc" |
| x-api-version  | String   | not required | Returns response matching API verison number |


You can include multiple query strings by separating them with an `&`. For example:

```
GET https://localhost:5001/api/companies?name=Shell&sortOrder=name
```

#### Additional GET Requests

The `.../Random` request will return a random record of a model. For example:

```
GET https://localhost:5001/api/companies/Random
```

The following query will return all stations associated with a company:

```
GET https://localhost:5001/api/companies/{id}/Stations
```

The following query will return all gas prices associated with a station:

```
GET https://localhost:5001/api/stations/{id}/gasprices
```

The following query will return the average gas price for a certain gas type at a station. The gas type query options are "Unleaded", "Premium", and "Diesel".
```
GET https://localhost:5001/api/stations/{id}/AveragePrice/{gasType}
```


#### Additional Requirements for POST Request

When making a POST request, you need to include a **body**. Here's an example body in JSON for the Company endpoint:

```json
{
  "name": "string"
}
```
Here's an example body in JSON for the Station endpoint:
```json
{
  "address": "302 West Blvd.",
  "city": "Atlanta",
  "state": "GA",
  "companyId": 4
}
```

Here's an example body in JSON for the GasPrice endpoint:
```json
{
  "date": "2023-04-21T06:28:11.975Z",
  "diesel": 1.50,
  "unleaded": 2.00,
  "premium": 2.50,
  "stationId": 3
}
```

#### Additional Requirements for PUT Request

When making a PUT request, you need to include a **body** that includes the model's Id property. Here's an example body for the Company endpoint in JSON:

```json
{
  "companyId": 1,
  "name": "Shell"
}
```

And here's the PUT request we would send the previous body to:

```
https://localhost:5001/api/companies/1
```

Notice that the value of `companyId` needs to match the id number in the URL. In this example, they are both 1.

The following is an example of a PUT request for the Station endpoint in JSON:
```json
{
  "stationId": 3,
  "address": "132 East Street",
  "city": "Portland",
  "state": "OR",
  "companyId": 1
}
```

The following is an example of a PUT request for the GasStation endpoint in JSON:
```json
{
  "gasPriceId": 0,
  "date": "2023-04-21T06:27:01.202Z",
  "diesel": 4.90,
  "unleaded": 3.99,
  "premium": 4.99,
  "stationId": 2
}
```
Notice that the value of the model ID needs to match the id number in the URL.
## Known Bugs

* _API Versioning and CORS not tested_

## License

_MIT_

Copyright (c) _2023_ _Geoffrey Gao_