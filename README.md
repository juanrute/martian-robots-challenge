# martian-robots-challenge
Software for the Mars mission. It processes basic commands like R L F and without a limit in robots to send. At fisrt there are several validacions.

This solution was made with .NetCore 3.1 with a domain-driven architecture.
Also, use the following NuGet packages:

| Package | Description |
| :---: | :---: | 
| NUnit | To implement the project unit testing in Application.Test. | 
| EntityFrameworkCore | For accessing & storing the data in the SQLite database. |
| Swagger | To create the WebApi documentation. | 
| AutoMapper | To map multiple objects easily. |
| Newtonsoft | Json Serialization |

A picture is worth a thousand words (But better with a gif):

WebAPi:
![Alt Text](api.gif)

Test Project:
![Alt Text](test.gif)

The solution contains 6 projects:
- Application
- ConsoleUI
- Domain
- Infrastructure
- MartialRobotApi
- Application.Test

The project Test for the core logic using Nunit, you can find all the test cases in this project that includes the happy path, interesting path and exceptional path. In the folder TestData I have prepared some files with a set of instructions with different examples 

For the persistence layer, I use Entity framework for SQLite with the Code-First approach.
