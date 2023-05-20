# Minimal Book Api
A Minimal .Net 7 Web Api for Books

This is just a fun random .Net Web Api tutorial I found online that I decided to play around with and add database support to. Probably some more changes coming sometime in the future.

# Clone it

Open your favorite terminal application and `cd` to the directory you want to place it in.
<br><br>
Then run this command:
```
git clone https://github.com/Glowstudent777/MinimalBookApi.git
```

# To build and run the project

## To Build
To build the project `cd` into the cloned directory and do
```
dotnet build
```

## The Database
I use a free (PlanetScale)[https://planetscale.com/] database for testing, other mysql databases might work.
In the `MinimalBookApi` folder of the project is a file called `appsettings.json` open it and fill in the mysql server details
```json
  "ConnectionStrings": {
    "Default": "Server=;Database=;user=;password=;SslMode=VerifyFull;"
  },
```

## To Run
You should be in the directory already and have built it so just do
```
dotnet run --project MinimalBookApi
```

## The web console thingamajig
.Net Web Apis have a Swagger UI in development mode located at `http://localhost:5298/swagger`.
