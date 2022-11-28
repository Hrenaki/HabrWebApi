using HabrWebApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", true, true);
builder.Services.AddRouting();
builder.Services.AddControllers();

builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IEnvironmentInfoService, EnvironmentInfoService>();

var app = builder.Build();
app.UseRouting();
app.MapControllers();

app.Run();