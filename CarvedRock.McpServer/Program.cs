using CarvedRock.McpServer;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddMcpServer()
    .WithHttpTransport()
     .WithToolsFromAssembly();

builder.Services.AddHttpClient("CarvedRockApi")
    .AddServiceDiscovery();

// builder.Services.AddCors(options =>
// {
//     options.AddPolicy("McpInspector", policy =>
//     {
//         policy
//             .WithOrigins("http://localhost:6274")
//             .AllowAnyHeader()
//             .AllowAnyMethod()
//             .AllowCredentials();
//     });
// });


var app = builder.Build();
// app.UseCors("McpInspector");
app.MapDefaultEndpoints();
app.MapMcp("/mcp");

app.Run();
