using API.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>();


var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/configuration/database", (IConfiguration configuration) =>
{

    return Results.Ok(configuration["database:connection"]);

}
);

app.Run();
