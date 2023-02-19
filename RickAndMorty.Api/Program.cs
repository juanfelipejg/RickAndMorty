using Microsoft.EntityFrameworkCore;
using RickAndMorty.Application.Services;
using RickAndMorty.Application.Services.Character;
using RickAndMorty.Domain.Services;
using RickAndMorty.Infrastracture;
using RickAndMorty.Infrastracture.Data;
using RickAndMorty.Infrastracture.Wrapper;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Default");

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddTransient<ICharacterService, CharacterService>();
builder.Services.AddTransient<IEpisodeService, EpisodeService>();
builder.Services.AddTransient<ICharacterGetter, CharacterGetter>();
builder.Services.AddTransient<IRestClientWrapper, RestClientWrapper>();
builder.Services.AddDbContext<RickAndMortyContext>( context => context.UseMySql( connectionString, ServerVersion.AutoDetect( connectionString )) );
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("corsapp");

app.UseAuthorization();

app.MapControllers();

app.Run();