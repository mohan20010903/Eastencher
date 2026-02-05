# Eastencher
## Database Setup
1. Update the connection string in `appsettings.json`
2. Then navigate to the folder that contains your .csproj file
3. Run the following commands in Command Prompt:
    dotnet ef database update
   
4. Or Open Visual Studio

Tools → NuGet Package Manager → Package Manager Console - run 
    Update-Database

The database will be created automatically using EF Core migrations.
