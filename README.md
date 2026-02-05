# Eastencher
## Task overview
1. Designed the Vendor Tracking page, which handles NCR (Non-Conformance Report)
2. It mainly focuses on creating and managing an NCR when there is a defect in the received parts from the vendor.

## Tech stack
1. .NET Core MVC
2. Front-end - HTML, CSS, Bootstrap, JQuery
3. Back-end - C#, Entity Framework core, LINQ
4. Database - Microsoft SQL Server
   
## Database Setup
1. Update the connection string in `appsettings.json.`
2. Then navigate to the folder that contains your .csproj file
3. Run the following commands in Command Prompt:
    dotnet ef database update
   
4. Or Open Visual Studio

Tools → NuGet Package Manager → Package Manager Console - run 
    Update-Database

The database will be created automatically using EF Core migrations.
