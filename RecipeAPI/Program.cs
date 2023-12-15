using Microsoft.EntityFrameworkCore;
using NoteAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
String connectionstring = builder.Configuration.GetConnectionString("DBConn");

builder.Services.AddDbContext<NoteContext>(opt => opt.UseSqlServer(connectionstring));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
/*if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}*/

if (app.Environment.IsDevelopment())
{
    using (var scope = app.Services.CreateScope())
    {
        var noteContext = scope.ServiceProvider.GetRequiredService<NoteContext>();
        noteContext.Database.EnsureCreated();
        noteContext.Seed();
    }
}

app.UseAuthorization();

app.MapControllers();

app.Run();
