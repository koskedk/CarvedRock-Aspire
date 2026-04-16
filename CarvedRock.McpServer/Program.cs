using CarvedRock.McpServer;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddMcpServer()
    .WithHttpTransport()
    .WithTools<CarvedRockTools>();

builder.Services.AddHttpClient("CarvedRockApi", client =>
    client.BaseAddress = new Uri("https://api")
);

builder.Services.AddCors(options =>
{
    options.AddPolicy("McpInspector", policy =>
    {
        policy
            .WithOrigins("http://localhost:6274")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});


var app = builder.Build();
app.UseCors("McpInspector");
app.MapDefaultEndpoints();
app.MapMcp("/mcp");

app.Run();
