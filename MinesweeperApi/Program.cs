using Microsoft.EntityFrameworkCore;
using Minesweeper.Core.Interfaces;
using Minesweeper.Infrastructure.Services;
using MinesweeperApi.Models.Storage;
using MinesweeperApi.Servises;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();

//Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(option => {
    option.UseSqlServer(builder.Configuration.GetConnectionString("MsSqlConnection"));
}
);

builder.Services.AddTransient<IGameLogic, GameLogic>();
builder.Services.AddTransient<IGameHandler, GameHandler>();
builder.Services.AddTransient<IGameRepository, GameRepositoryMSSQL>();
builder.Services.AddTransient<IGameDTOMapper, GameDTOMapper>();
builder.Services.AddTransient<IGameDbEntityMapper, GameToGameDbEntityMapper>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});


var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//var dbcontext = app.Services.GetService(typeof(ApplicationDbContext));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.Run();
