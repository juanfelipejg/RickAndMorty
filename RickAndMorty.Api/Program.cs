using RickAndMorty.Application.Services.Character;
using RickAndMorty.Domain.Services;
using RickAndMorty.Infrastracture;
using RickAndMorty.Infrastracture.Wrapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddTransient<ICharacterService, CharacterService>();
builder.Services.AddTransient<ICharacterGetter, CharacterGetter>();
builder.Services.AddTransient<IRestClientWrapper, RestClientWrapper>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



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
