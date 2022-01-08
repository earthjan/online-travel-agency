# Online Travel Agency
## Configs
### Prerequisite
- #### Programs
    - [MySQL 8+ Community](https://dev.mysql.com/downloads/mysql/)
    - .NET Core SDK for .NET 5
- #### Database
    - Import the MySQL DB using these [schemas](https://github.com/earthjan/online-travel-agency/tree/main/MySQLSchemas).
    - For the connection string, add a system variable with the name *OTA* and value *server=*(your server name)*;database=ota;user=*(your username)*;password=*(your password)
- #### Others
    - Have an internet connection for program's packages getting from CDN, especially for Bootstrap.

## Usage
- After downloading this source code, navigate the code's folder via command prompt, and then  run the program using `dotnet run` command. After that, .NET presents links. 

    Choose one from there like the first link `localhost:5001`.

    Lastly, add this `/travel/landingpage` after the port, for example `localhost:5001/travel/landingpage`.

    You can now use the app.

## Minimum System Requirements
### Processor
- Intel(R) Core(TM) i3-5005U CPU @ 2.00GHz 2.00GHz
### RAM
- 4GB
### System type
- 64-bit OS, x64-based processor
