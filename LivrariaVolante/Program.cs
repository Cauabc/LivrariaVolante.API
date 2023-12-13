using LivrariaVolante.Data;
using LivrariaVolante.Interfaces;
using LivrariaVolante.Profile;
using LivrariaVolante.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<LibraryDataContext>(o =>
    o.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddTransient<IAutorRepository, AutorRepository>();
builder.Services.AddTransient<ILivroRepository, LivroRepository>();
builder.Services.AddAutoMapper(typeof(ProfileMapper));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
