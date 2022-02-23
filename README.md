# martian-robots-challenge
Software for the Mars mission. It process basic commands like R L F and without a limit in robots to send. At fisrt there are several validacions.
A picture is worth a thousand words:

![](api.gif)


![Alt Text](api.gif)

![](Documentation\api.gif)

![Alt Text](Documentation\api.gif)

This solution was made with .NetCore 3.1 with a domain driven architecture.
Also use the following NuGet packages:

| Package | Description |
| :---: | :---: | 
| NUnit | To implement the project unit testinf in Application.Test. | 
| EntityFrameworkCore | For accessing & storing the data in the SQLite database. |
| Swagger | To creating the WebApi documentation. | 
| AutoMapper | To map multiple objects easily. |
| Newtonsoft | Json Serialization |

The solution contains 6 projects:
- Application
- ConsoleUI
- Domain
- Infrasructure
- MartialRobotApi
- Application.Test

Test for the core logic using Nunit, you can find all the test cases in this projects that includes the happy path, insterested path and exceptional path.

For the persistence layer I use Entity framework for SQLite with the Code-First approach.
