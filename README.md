# _National Park Api_

#### By _**Thomas Bakken**_

#### _An api for information about national parks in the USA._

## Technologies Used

* _.NET_
* _C#_
* _MySQL_
* _Entity Framework Core_
* _RESTful APIs_

## Description

_This application if a backend server for handling National Park API requests. The server takes the request body through the corresping route, handles a CRUD operation, and sends a response to the client._

## Setup/Installation Requirements

* _Install .NET SDK 6_
* _Install MySQL Server_
* _Clone the repository_
* _In the bash command line:_
  * _Navigate to the top-level directory_
  * _Navigate into the project directory with: $ cd NationalParksApi_
  * _Create `appsettings.json` with: $ touch appsettings.json_
    * _Open the file in a text editor and copy the following line_
      * _\{"ConnectionStrings": \{ "Logging": \{ "LogLevel": \{ "Default": "Information", "Microsoft.AspNetCore": "Warning" \} \}, "AllowedHosts": "*","DefaultConnection": "Server=localhost;Port=3306;database=\[DB_NAME\];uid=\[USERNAME\];pwd=\[PASSWORD\];" \} \}_
    * _Replace \[DB_NAME\] with a database name_
    * _Replace \[USERNAME\] with your MySQL username_
    * _Replace DB_NAME with your MySQL password_
  * _Create `appsettings.Development.json` with: $ touch appsettings.json_
    * _Open the file in a text editor and copy the following line_
      * _\{ "Logging": \{ "LogLevel": \{ "Default": "Information", "Microsoft": "Trace", "Microsoft.AspNetCore": "Information", "Microsoft.Hosting.Lifetime": "Information" \} \} \}_
  * _Enter command: $ dotnet restore_
  * _Initialize database with: $ dotnet ef database update_
  * _Run the server in development mode with: $ dotnet watch run
    * _Navigate to https://localhost:5001/swagger/index.html_
  * _Run the server with command: $ dotnet run_

## API Requests

1. Get Methods:
    * _Route: /NationalParks_
      * _Request: A page number corresponds to which 5 (a page) parks to send back.
      * _Response: A list of national parks occuring in the page's range.
    * _Route: /NationalParks/\{id\}_
      * _Request: The id of a national park.
      * _Response: The national park data.
    * _Route: /NationalParks/\{name\}_
      * _Request: The name of a national park.
      * _Response: The national park data.
2. Post Method:
    * _Route: /NationalParks/_
      * _Request: A new national park's data.
      * _Response: The national park with assigned primary key.
3. Put Method:
    * _Route: /NationalParks/\{id\}_
      * _Request: An national park's updated data.
      * _Response: Status code only.
4. Delete Method:
    * _Route: /NationalParks/\{id\}_
      * _Request: The id of a national park to delete.
      * _Response: Status code only.

## Known Bugs

* No client
* DateTime is not DateOnly


## License

_MIT_

Copyright (c) _8/8/2023_ _Thomas Bakken_