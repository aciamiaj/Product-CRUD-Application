# Product-CRUD-Application

Product CRUD Application is a web application built using ASP.NET Core. It utilizes a database to manage products and provides various endpoints for CRUD operations.

## Prerequisites
.NET 5.0 SDK or later
Microsoft SQL Server (Express edition or higher)

## Installation
Clone the repository or download the source code files.
Open the solution in Visual Studio or your preferred code editor.
Build the solution to restore the dependencies.
Run the database migrations to create the necessary tables. Open the Package Manager Console and run the following command:
Update-Database
Start the application using the debugging tools of your code editor or by running the following command in the terminal:
dotnet run

## Configuration
The application uses the appsettings.json file to store configuration settings. You can modify the file to change the default configuration, such as the database connection string and other application-specific settings.

## Usage
Once the application is running, you can access the available endpoints using a web browser or API testing tool. The following are the main endpoints provided:

GET /Products: Retrieves all products.
GET /Products/{id}: Retrieves a specific product by its ID.
POST /Products: Creates a new product.
PUT /Products/{id}: Updates an existing product.
DELETE /Products/{id}: Deletes a product.
Please refer to the API documentation or explore the code to get a complete understanding of the available endpoints and their functionalities.

## Contributing
Contributions to this project are welcome. If you find any issues or have suggestions for improvements, feel free to create a pull request or submit an issue in the repository.
