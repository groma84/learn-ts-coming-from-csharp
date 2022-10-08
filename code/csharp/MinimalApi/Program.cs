var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

string? lastVal = null;

app.MapGet("/get", () => lastVal);
app.MapPost("/set", (Value val) => lastVal = val.Val);

app.Run("http://localhost:44444");

record Value(string Val);
