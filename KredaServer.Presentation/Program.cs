using KredaServer.Presentation.Extensions;
using KredaServer.Presentation.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.AddHostConfig();

builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration)
    .AddSwagger()
    .AddPresentation();

var app = builder.Build();

app.UseWebSockets();

app.UseCors("AllowClient");

app.MapOpenApi();

app.MapControllers();

app.MapHub<WhiteboardSessionHub>("/whiteboard/{whiteboardId}");

app.Run();