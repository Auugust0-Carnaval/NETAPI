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

app.MapGet("/todoitems/complete", async (TodoDb db) =>
    await db.Todos.Where(t => t.IsComplete).ToListAsync());

app.MapGet("/todoitems/{id}", async (int id, TodoDb db) =>
await db.Todos.FindAsync(id)
is Todo todo
    ? Results.Ok(todo)
    : Results.NotFound("Não encontrado"));