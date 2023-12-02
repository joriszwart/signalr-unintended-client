using Microsoft.AspNetCore.SignalR;

namespace Server;

public class SomeHub : Hub
{
    private static readonly List<string> connections = new();

    public SomeHub()
    {
        Console.WriteLine($"{DateTime.UtcNow} New hub instance.");
    }

    public override async Task OnConnectedAsync()
    {
        connections.Add(Context.ConnectionId);
        Console.WriteLine($"{DateTime.UtcNow} Client {Context.ConnectionId} connected (connection count: {connections.Count})");

        foreach (var connectionId in connections)
        {
            await Clients.Client(connectionId).SendAsync("Message", connectionId);
            Console.WriteLine($"{DateTime.UtcNow} Sent message '{connectionId}' to {connectionId}.");
        }

        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        await base.OnDisconnectedAsync(exception);
        Console.WriteLine($"{DateTime.UtcNow} Client {Context.ConnectionId} disconnected.");
    }
}