var builder = WebApplication.CreateBuilder(args);

// Websites allowed to call this API from the browser (list is in appsettings.json)
var allowedOrigins = builder.Configuration
    .GetSection("AllowedOrigins")
    .Get<string[]>() ?? [];

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
        policy.WithOrigins(allowedOrigins)
              .AllowAnyHeader()
              .AllowAnyMethod());
});

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors();

app.MapGet("/", () => "My API is running");

app.MapGet("/api/hello", () => new
{
    message = "Hello from the .NET API on Render!",
    serverTime = DateTime.UtcNow
});

app.Run();