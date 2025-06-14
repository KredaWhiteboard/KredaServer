using System.Collections.Concurrent;
using Microsoft.AspNetCore.SignalR;

using KredaServer.Presentation.Utils;
using KredaServer.Application.Whiteboards;
using KredaServer.Presentation.Dtos;

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
        await getWhiteboardById.Execute(whiteboardId, cts.Token);

        await Groups.AddToGroupAsync(Context.ConnectionId, whiteboardIdParameter);
        connections.TryAdd(Context.ConnectionId, new ConnectionContext(whiteboardIdParameter, username!));

        await Clients.Group(whiteboardIdParameter).SendAsync("ReceiveUserConnected", new { Username = username });

        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? ex)
    {
        var connection = connections[Context.ConnectionId]
            ?? throw new Exception($"Connection context with id {Context.ConnectionId} not found"); // TODO: error to handle with logger

        await Groups.RemoveFromGroupAsync(Context.ConnectionId, connection.WhiteboardId);
        connections.Remove(Context.ConnectionId, out _);

        await Clients.Group(connection.WhiteboardId).SendAsync("ReceiveUserDisconnected", new { Username = connection.UserName });

        await base.OnDisconnectedAsync(ex);
    }

    public async Task SendUserAction(UserActionDto dto)
    {
        var connection = connections[Context.ConnectionId]
            ?? throw new Exception($"Connection context with id {Context.ConnectionId} not found"); // TODO: error to handle with logger

        await Clients.Group(connection.WhiteboardId).SendAsync(
            "ReceiveUserAction",
            new
            {
                Username = connection.UserName,
                dto.X,
                dto.Y,
                Tool = dto.Tool,
                dto.BrushSize,
                dto.R,
                dto.G,
                dto.B,
                dto.A
            }
        );
    }
}