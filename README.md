# Problem Description
- Store weather forecast for a day.
- Retrieve the weather forecast for a week in a human readable way (like "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching").
- Forecasts cannot be in the past.
- Temperature cannot be more than +60 and cannot be less than -60 degrees.

# Build and Run
- To build the application "docker compose build"
- To run the application "docker compose up"
- Try the application at http://localhost:8080/swagger/

# Architecture and Tools
- Clean architecture - for project layering
- Domain driven design
- CQRS - Command and Query are separated in every layer. 
- MediatR - to separate command/query handling responsibilities
- Fluent Validation -  for validating command/query with MediatR pipeline
- Exception filter - to return correct exception to client
- Entity Framework Core - as ORM
- SQL server - as Database
- In memory SQL Lite - for integration testing
- Xunit - as test framework
- AutoFixture - for mocking data
- Fluent Assertions 
- MOQ library - mocking methods
- Builder pattern - to create mock for Domain entity
- Console logger - for logging

