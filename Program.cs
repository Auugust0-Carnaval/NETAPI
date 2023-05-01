// var builder = WebApplication.CreateBuilder(args);
// var app = builder.Build();

// app.MapGet("/runtimes", () => "Hello word");

// app.Run();


// OBS: LaunchBrowser tanto no argumento do http e https difine o endpoint do host


using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

app.MapGet("/", () => Results.Ok("Projetinho basico em .NET"));

app.MapGet("/todoitems", async (TodoDb db) =>
   await db.Todos.ToListAsync());
