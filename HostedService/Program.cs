using HostedService.Service;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHostedService<HostedWork>();
var app = builder.Build();

app.MapGet("/", () => "A running application with hosted service!");

app.Run();
