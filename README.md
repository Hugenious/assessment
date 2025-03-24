Author : Eugene Classen
Description : Assessment readme.
Tools Used : All code has been written in Visual Studio 2022.
             .Net 8
             ASP.NET Core
             .NET Framework 4.8


1. Library Management System
   Library where books can be managed by adding, removing, searched and listed.
   The library management system has been created using two different solutions, Console App and Blazor, 
   both have unit testing.
   

   1.1: Blazor Web Application
	Run the application using F5 (debug mode) or CONTROL + F5 (without debugging). Once website is open
	click on the Library link where the library can be managed.
	
	Blazer version uses a LibraryService class that is registered as a singleton service. This allows
	only one instance of the class to exist throughout the application's lifetime.
	
	Unit testing (LibraryServiceTests) has been added for adding, removing and searching books.
	
	Book.cs class holds the properties for a book and a simple collection list is used to hold the
	collection.

   1.2: Console Application
	Run the application using F5 (debug mode) or CONTROL + F5 (without debugging). Output will be shown
	in a command window, where options can be selected to perform library actions.

	Unit testing (LibraryServiceTests) has been added for adding and removing books.

	Book.cs class holds the properties for a book and a simple collection list is used to hold the
	collection.

   Run the applications using F5 (debug mode) or CONTROL + F5 (without debugging).


2. Factorial Calculation
   Application to calculate the factorial of numbers using in an array and display results. Each factorial
   calculation is performed in its own thread.
 
   Open solution in Visual Studio. Press F5 to run application in debug mode or CONTROL + F5 for .
   Output will appear in cmd window.

   Run the application using F5 (debug mode) or CONTROL + F5 (without debugging).

3. Producer-Consumer Queue
   Producer first generate random numbers and add them to the queue. Once completed,
   the consumer will then consume randomly generated numbers and display the output in command window.

   Run the application using F5 (debug mode) or CONTROL + F5 (without debugging).


4. Customer Entity Management
   Application to manage customer entities that is stored in a SQL database (assessmentdb).

   Application is written using ASP.NET Core Web App using Razor pages and .Net 8.
   Application connects to an already available SQL server using user : AssessmentUser and password : TestP@ssw0rd!@#

   Created model Customer.cs
   Created and applied the migration using Add-Migration InitialCreate and Update-Database which created the customer 
   table on the assessmentdb datatbase.

   Crud pages will perform the related crud operation.   

   Run the application using F5 (debug mode) or CONTROL + F5 (without debugging). No need to change sql server details.

5. RESTful Product API
   RESTful api to manage product collection. Products can be created, read, updated and deleted.

   Application is written using .Net Core Web API and .Net 8.

   Class Product.cs has been created and ProductController handles CRUD operations.

   Following methods are available:
   Get all products (HttpGet) : http://localhost:5181/api/product
   Create new product (HttpPost) : http://localhost:5181/api/product
    {
      "productId": 0,
      "name": "Product new",
      "description": "A new product available",
      "price": 350
    }
   
   Get specific product (HttpGet {id}) : http://localhost:5181/api/product/1
   Update an existing product (HttpPut {id}) : http://localhost:5181/api/product/4
    {
      "productId": 0,
      "name": "Updated product",
      "description": "Product with a new name, description and price",
      "price": 50
    }

   Delete an existing product (HttpDelete {id}) : http://localhost:5181/api/product/2

   Testing can be done using Swagger, which loads automatically when project is ran, 
   or using Postman.
   
   Run the application using F5 (debug mode) or CONTROL + F5 (without debugging).


6. Public REST API (OpenWeatherMap API)
   This application connects to public API called OpenWeatherMap API which allows a user to enter a city and
   display the current weather information.

   Request is done using HttpRequest using an api key as authentication. Using an HttpWebResonse to retrieve 
   the response, we then read the Json string returned with StreamReader.

   The Json string is deserialized into a dynamic object which we can then use to display the current weather
   information.

   Run the application using F5 (debug mode) or CONTROL + F5 (without debugging).
