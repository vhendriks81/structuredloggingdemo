# A demo application to demonstrate structured logging using ASP.NET Core, Serilog and seq
Part of a dutch article: https://www.teamrockstars.nl/tech-burst/structured-logging-een-net-applicatie

To test this out yourself:
```powershell
git clone https://github.com/vhendriks81/structuredloggingdemo
```

Then you can run the application using docker-compose:
```powershell
cd structuredloggingdemo
docker-compose up
```

This will run seq which can be found at 'http://localhost:44380'. The web api can be found at: https://localhost:44314/swagger
