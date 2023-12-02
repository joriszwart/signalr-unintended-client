using Microsoft.AspNetCore.SignalR;

namespace Server;

public class SomeHub : Hub
{
    // Note that the hub is instantiated on a per-connection basis,
    // so a global connection list is needed.
    private static readonly List<string> Connections = new();

    public SomeHub()
    {
        Console.WriteLine($"{DateTime.UtcNow} New hub instance.");
    }

    public override async Task OnConnectedAsync()
    {
        Connections.Add(Context.ConnectionId);
        Console.WriteLine($"{DateTime.UtcNow} Client {Context.ConnectionId} connected (connection count: {Connections.Count})");

        foreach (var connectionId in Connections)
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