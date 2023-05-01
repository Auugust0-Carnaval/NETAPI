var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/runtimes", () => "Hello word");

app.Run();


// OBS: LaunchBrowser tanto no argumento do http e https difine o endpoint do host

