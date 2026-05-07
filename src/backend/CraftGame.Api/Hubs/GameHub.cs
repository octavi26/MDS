using Microsoft.AspNetCore.SignalR;

namespace CraftGame.Api.Hubs;

public sealed class GameHub : Hub
{
    public Task Ping()
    {
        return Clients.Caller.SendAsync("pong", new { status = "ok" });
    }
}
