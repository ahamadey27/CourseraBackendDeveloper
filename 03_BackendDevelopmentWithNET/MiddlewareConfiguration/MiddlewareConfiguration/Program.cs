var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpLogging((o) => { });
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.UseHttpLogging();

app.Run();
