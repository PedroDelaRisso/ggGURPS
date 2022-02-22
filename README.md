<p align="center">placeholder title</p>
<h1 align="center"><b>ggGURPS</b></h1>
<p align="center">🚧 Work in progress.. 🚧</p>

Welcome to ggGURPS. A WIP web app to facilitate GURPS campaigns.

This is being done as a side personal passion project as a means to study the stack used on my job.


ggGURPS currently uses .NET 5 as the backend framework and Svelte for the frontend.


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
- [NodeJS](https://nodejs.org).
- An SQL Server. I use the Basic installation of [SQL Express](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads). If you want to use anything else, make sure to edit the connections strings in both ``appsettings.json`` and ``appsettings.Development.json``.
- Any means of managing the database. I use [SSMS](https://docs.microsoft.com/pt-br/sql/ssms/download-sql-server-management-studio-ssms?redirectedfrom=MSDN&view=sql-server-ver15).
- A code editor. I use [Visual Studio Code](https://code.visualstudio.com). Make sure to look for the C# extension and install it.
- Any terminal to run the commands. I use the terminal inside Visual Studio Code.

How to run the server:

Navigate to the ``server`` folder inside the repository.

There are two very important files: ``appsettings.json`` and ``appsettings.Development.json``.
Inside these files, take a look at the ``ConnectionStrings`` object and change its ``Default`` property to whatever you need it to be.

```bash
# you can press CTRL+' to open the terminal inside Visual Studio Code
# run this command to navigate to the server folder
cd server

# then execute these commands in this order:

# install EntityFramework for database management:
dotnet tool install --global dotnet-ef

# run the project:
dotnet run

# the database will be created automatically

# or you can add a watch in between "dotnet" and "run" so that whenever you save a .cs file, the project will run again and the web API page will reload.
dotnet watch run
```

How to run the client:

Navigate to the ``client`` folder. Inside it, go to ``src/models/Api.ts``. Inside this file scroll down to the ``constructor`` method and change the address of the API to yours. Default will be what's in there.
```bash
# open another terminal, you can use CTRL+SHIFT+' to do so and navigate to the client folder
cd client
```

Then execute the following commands:
```bash
# to install dependencies
npm install

# wait for the dependencies to be installed and then run:
npm run dev
```
And you should be all set!
