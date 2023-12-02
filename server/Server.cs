using Server;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();
var app = builder.Build();

app.MapHub<SomeHub>("");

Console.WriteLine($"{DateTime.UtcNow.ToString("HH:mm:ss.fff")} Server started.");

app.Run();