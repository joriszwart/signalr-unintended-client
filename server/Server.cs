using Server;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();
var app = builder.Build();

app.MapHub<SomeHub>("");

Console.WriteLine($"{DateTime.UtcNow} Server started.");

app.Run();