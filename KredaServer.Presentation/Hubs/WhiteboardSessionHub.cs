using System.Collections.Concurrent;
using Microsoft.AspNetCore.SignalR;

using KredaServer.Presentation.Utils;
using KredaServer.Application.Whiteboards;

namespace KredaServer.Presentation.Hubs;

public class WhiteboardSessionHub(ConcurrentDictionary<string, ConnectionContext> connections, GetWhiteboardById getWhiteboardById) : Hub
{
    public override async Task OnConnectedAsync()
    {
        var context = Context.GetHttpContext();
        if (context is null) return;

        var whiteboardIdParameter = context.Request.RouteValues["whiteboardId"]?.ToString();
        var username = context.Request.Query["username"];

        if (
            string.IsNullOrEmpty(whiteboardIdParameter) ||
            string.IsNullOrEmpty(username) ||
            !Guid.TryParse(whiteboardIdParameter, out Guid whiteboardId)
        )
        {
            throw new Exception("Validation error.");
        }

        var cts = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        _ = await getWhiteboardById.Execute(whiteboardId, cts.Token)
            ?? throw new Exception($"Whiteboard with id {whiteboardIdParameter} not found.");

        await Groups.AddToGroupAsync(Context.ConnectionId, whiteboardIdParameter);
        await Clients.Group(whiteboardIdParameter).SendAsync("ReceiveMessage", "System", $"Connected {username}.");
        connections.TryAdd(Context.ConnectionId, new ConnectionContext(whiteboardIdParameter, username!));

        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? ex)
    {
        var connection = connections[Context.ConnectionId]
            ?? throw new Exception($"Connection context with id {Context.ConnectionId} not found"); // TODO: error to handle with logger

        await Clients.Group(connection.WhiteboardId).SendAsync("ReceiveMessage", "System", $"Disconnected {connection.UserName}."); // TODO: disconnect message
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, connection.WhiteboardId);
        connections.Remove(Context.ConnectionId, out _);

        await base.OnDisconnectedAsync(ex);
    }

    public async Task SendMessage(string user, string message)
    {
        var connection = connections[Context.ConnectionId]
            ?? throw new Exception($"Connection context with id {Context.ConnectionId} not found"); // TODO: error to handle with logger

        await Clients.Group(connection.WhiteboardId).SendAsync("ReceiveMessage", user, message);
    }
}