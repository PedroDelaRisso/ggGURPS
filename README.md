<p align="center">placeholder title</p>
<h1 align="center"><b>ggGURPS</b></h1>
<p align="center">🚧 Work in progress... 🚧</p>

Welcome to ggGURPS. A WIP web app to facilitate GURPS campaigns.

This is being done as a side personal passion project as a means to study the stack used on my job.

ggGURPS currently uses .NET 5 as the backend framework and the plan is to use VueJS with VueX as the frontend framework.

GURPS is an RPG system published by Steve Jackson Games. Its name means Generic Universal Role Playing System. It's a very complex and complete RPG system.

Planned features:
- The "game table"
    > Players and Game Masters should be able to see some "public actions" done by members of the party and some done by the GM, if they choose to. The GM should be able to roll for the players at will and see their results.

- Creation and customization of character sheets
    > Players and Game Masters should be able to create and customize character sheets. Players would only be able to create their character sheets if the GM allows. Player Character sheets would have a max amount of points determined by the GM.

- Automated dice rolling
    > Any Player and Game Master should be able to customize their own rolls for skills, attributes and damage dealt.

This list will be updated regularly as new ideas arrive.

How to develop (so far):
- [.NET 5 SDK](https://dotnet.microsoft.com).
- An SQL Server. I use the Basic installation of [SQL Express](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads). If you want to use anything else, make sure to edit the connections strings in both ``appsettings.json`` and ``appsettings.Development.json``.
- Any means of managing the database. I use [SSMS](https://docs.microsoft.com/pt-br/sql/ssms/download-sql-server-management-studio-ssms?redirectedfrom=MSDN&view=sql-server-ver15).
- A code editor. I use [Visual Studio Code](https://code.visualstudio.com). Make sure to look for the C# extension and install it.
- Any terminal to run the commands. I use the terminal inside Visual Studio Code.

How to run:
Navigate to the server folder inside the repository.
```bash
cd server
```
Then execute this command:
```bash
dotnet run
```
Or add a watch in between the words so that whenever you save a .cs file, the web API page will reload automatically.
```bash
dotnet watch run
```
And you should be all set!