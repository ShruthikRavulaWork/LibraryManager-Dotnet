using LibraryManager.Models;
using LibraryManager.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<LibraryConfig>(builder.Configuration.GetSection("LibraryConfig"));

builder.Services.AddSingleton<ILibraryService, LibraryService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
