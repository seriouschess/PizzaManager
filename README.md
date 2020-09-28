# Pizza Manager

A CRUD application where users are able to store and update pizza information.

Made with Asp.NET Core 3.1 and Angular 9

# Relavant folders

- FRONTEND SOURCE

Clientapp/src/app/..

../home - Parent component for main frontend logic
../pizza-dashboard - Component which stores dashboard logic
../single-pizza-display - Contains logic for displaying and modifying a single pizza
../add-pizza - Form for addition of new pizzas

../api - contains auto generated api service client using openapi format,
          see Project Use section for documentation

- BACKEND SOURCE

Models - Database model data and db context

Dtos - Data Transfer Objects and automapper class

Controllers/PizzaController.cs - Main route logic

BusinessLogic - Database Init class and Database Query functionality


# Project Use

Startup Command, main project directory - dotnet run

Project can be found on: http://127.0.0.1:5000 while application is running

Open API documentation: http://127.0.0.1:5000/swagger

*Note: May have to startup twice on the first time to build Angular clear of warnings.
