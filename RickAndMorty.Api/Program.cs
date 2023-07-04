using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RickAndMorty.Application.Services;
using RickAndMorty.Application.Services.Characters;
using RickAndMorty.Domain.Services;
using RickAndMorty.Infrastracture;
using RickAndMorty.Infrastracture.Data;
using RickAndMorty.Infrastracture.Wrapper;

var builder = WebApplication.CreateBuilder( args );
string connectionString = builder.Configuration.GetConnectionString( "Default" );

// Add services to the container.
builder.Services.AddLogging( logging =>
{
	logging.ClearProviders();
	logging.AddConsole();
} );
builder.Services.AddControllers();
builder.Services.AddAutoMapper( AppDomain.CurrentDomain.GetAssemblies() );
builder.Services.AddTransient<ICharacterService, CharacterService>();
builder.Services.AddTransient<IEpisodeService, EpisodeService>();
builder.Services.AddTransient<ICharacterGetter, CharacterGetter>();
builder.Services.AddTransient<IRestClientWrapper, RestClientWrapper>();
builder.Services.AddDbContext<RickAndMortyContext>( context => context.UseSqlServer( connectionString ) );
builder.Services.AddTransient<IDbConnection>( sp => new SqlConnection( connectionString ) );

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors( options =>
{
	options.AddPolicy( "AllowAllOrigins",
		builder =>
		{
			builder.AllowAnyOrigin()
				   .AllowAnyMethod()
				   .AllowAnyHeader();
		} );
} );

var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();

var logger = app.Services.GetRequiredService<ILogger<Program>>();
logger.LogInformation( "Application starting up..." );

// Configure the HTTP request pipeline.
if( app.Environment.IsDevelopment() )
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors( "AllowAllOrigins" );

app.UseAuthorization();

app.MapControllers();

app.Run();
