using Microsoft.AspNetCore.SignalR;

namespace Server;

public class SomeHub : Hub
{
    public static readonly List<string> connections = new();

    public SomeHub()
    {
        Console.WriteLine($"{DateTime.UtcNow.ToString("HH:mm:ss.fff")} New hub instance.");
    }

    public override async Task OnConnectedAsync()
    {
        connections.Add(Context.ConnectionId);
        Console.WriteLine($"{DateTime.UtcNow.ToString("HH:mm:ss.fff")} Client {Context.ConnectionId} connected (connection count: {connections.Count})");

        foreach (var connectionId in connections)
        {
            await Clients.Client(connectionId).SendAsync("Message", connectionId);
            Console.WriteLine($"{DateTime.UtcNow.ToString("HH:mm:ss.fff")} Sent message '{connectionId}' to {connectionId}.");
        }

        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        await base.OnDisconnectedAsync(exception);
        Console.WriteLine($"{DateTime.UtcNow} Client {Context.ConnectionId} disconnected.");
    }
}