SignalR server2server example
=============================

This started out as a reproduction for a possible SignalR issue where
messages do not end up at the intended client.

But it now functions as a simple server 2 server example.

The issue has been fixed: dotnet/aspnetcore#48690 (workaround available, fixed in 7.0.7)


Run
---

Start the server:

```shell
dotnet run --project server
```

Then in another terminal start a client:

```shell
dotnet run --project client
```

For each client that connects, the server will notify all connected clients.


Framework
: .NET 8.0
