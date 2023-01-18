# BreweryAPI

## Running the App

 - On first startup, the app will build the database and relevant objects
   - To configure, check the section below about `Configuring the Database Connection`
 - Either use the Swagger UI to test the app, or point any alternative front ends to the locally hosted URL

## Configuring the Database Connection

 - Open appsettings.Development.json
 - Under the `ConnectionStrings` section, Edit the `BreweryAPI` value to use your Server (Default = `localhost\SQLEXPRESS`)
