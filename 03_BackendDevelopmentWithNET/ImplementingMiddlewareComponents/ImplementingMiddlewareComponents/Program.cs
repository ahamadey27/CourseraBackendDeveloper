var builder = WebApplication.CreateBuilder(args);

// Add services for authentication and authorization
builder.Services.AddAuthentication("YourScheme")
    .AddCookie("YourScheme"); // Example: Using cookie-based authentication
builder.Services.AddAuthorization();

// Add HTTP logging service
builder.Services.AddHttpLogging();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/error");
}

// Add HTTP logging middleware
app.UseHttpLogging();

// Add authentication and authorization middleware
app.UseAuthentication();
app.UseAuthorization();

app.Use(async (context, next) =>
{
    // Capture the request start time
    var requestStartTime = DateTime.UtcNow;

    // Log the request path and start time
    Console.WriteLine($"Request path: {context.Request.Path}");
    Console.WriteLine($"Request start time: {requestStartTime:O}"); // ISO 8601 format

    // Call the next middleware in the pipeline
    await next.Invoke();

    // Log the response status code after the request has been processed
    Console.WriteLine($"Response status: {context.Response.StatusCode}");
});

app.MapGet("/", () => "Hello World!");

app.MapGet("/error", () => "An error occurred.");

app.Run();
