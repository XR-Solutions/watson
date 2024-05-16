# Watson
The Dutch Forensic Mixed Reality app

---

## Run your own environment

#### Spin up a local database
In development mode, the API tries to connect to a local database using some fake credentials. You can easilly set up a database locally by using docker. **Make sure you have docker installed!** If you have docker, you can run the command below.

```sh
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Fake-Development-Password1!" -e "MSSQL_PID=Evaluation" -p 14339:1433  --name watson-db --hostname watson-db -v watson-data-volume:/var/opt/mssql -d mcr.microsoft.com/mssql/server:2022-latest
```

This command pulls and runs the official Microsoft SQL Server image and runs this server in Express mode. The container name will be `watson-db` and only for Development we will simply make use of the `Master` Database. Your localhost port `14339` will be used to port forward to the sql server listening inside the docker container. If you have used this command, you do not have to manually set up a connection string in development mode.

#### Launch the backend in development
You will need to have the [dotnet cli](https://learn.microsoft.com/en-us/dotnet/core/tools/) installed and a valid [dotnet runtime environment](https://dotnet.microsoft.com/en-us/download). We reccomend installing [Visual Studio](https://code.visualstudio.com/download) if you have not already. Alternatively you can use [Rider](https://www.jetbrains.com/rider/).

You can simply launch the backend by changing directory into the backend folder

```sh
cd ./backend
```

You can launch the solution file by running `start Watson.sln`. This will launch your default IDE for dotnet solutions. From within your IDE you can simply run the solution. Alternatively you can make use of the dotnet cli and run the following command: `dotnet run --project .\src\Watson.Web`.

