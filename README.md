# ArriveLogistics
Arrive Logistics .NET developer programming prompt: Mars Rover tracking

The coding exercise is implemented in .NET ASP.NET Core Web API and SQLite for data persistence.  The db (ArriveLogistics.db) has 2 tables: MarsRovers and CompassDirections_Lookup.  CompassDirections is a lookup table for the MarsRovers.FacingDirection column.

MarsRovers is seeded with 4 rovers: A1, B2, C333333333, and D444444444.  The first rover has been moved, and the last 3 are still at their initial location (0,0 facing North).

Inside the solution, there is also an IntegrationTests/Postman folder which contains 4 Postman test requests to run against the web service.



