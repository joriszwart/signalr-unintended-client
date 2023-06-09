using Microsoft.AspNetCore.SignalR.Client;

var connection = new HubConnectionBuilder()
    .WithUrl("http://localhost:5000")
    .Build();

connection.On<string>("Message", (message) =>
{
    Console.WriteLine($"{DateTime.UtcNow.ToString("HH:mm:ss.fff")} Client {connection.ConnectionId} received message intended for client {message}.");
});

await connection.StartAsync();
Console.WriteLine($"{DateTime.UtcNow.ToString("HH:mm:ss.fff")} Client {connection.ConnectionId} started.");

Console.ReadLine();
