using KredaServer.Presentation.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.AddHostConfig();

builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration)
    .AddSwagger()
    .AddPresentation();

var app = builder.Build();

app.MapOpenApi();

app.UseAuthorization();
app.MapControllers();

app.Run();
