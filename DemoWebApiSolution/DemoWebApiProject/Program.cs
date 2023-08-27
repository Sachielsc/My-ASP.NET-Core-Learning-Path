using DemoWebApiProject.DbContexts;
using DemoWebApiProject.MockData;
using DemoWebApiProject.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// older way of logging
//builder.Logging.ClearProviders();
//builder.Logging.AddConsole();

// Set up Serilog here
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File(builder.Configuration["Etc:LogFileLocation"], rollingInterval: RollingInterval.Month)
    .CreateLogger();

// newer way of logging, using Serilog
builder.Host.UseSerilog();

// Add services to the container
// Demo: Formatters and Content negotiation
builder.Services.AddControllers().AddXmlDataContractSerializerFormatters();

builder.Services.AddEndpointsApiExplorer();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen();

#if DEBUG
builder.Services.AddTransient<IDummyCustomizedServices, DummyCustomizedServicesLocal>();
#else
builder.Services.AddTransient<IDummyCustomizedServices, DummyCustomizedServicesCloud>();
#endif

builder.Services.AddSingleton<GameProgressDataStore>();

builder.Services.AddDbContext<GameProgressContext>(dbContextOptions => dbContextOptions.UseSqlite(builder.Configuration["ConnectionStrings:GameProgressDBConnectionString"]));

builder.Services.AddScoped<IGameProgressRepository, GameProgressRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// This is the asp.net core 6 way:
//app.UseAuthorization();
//app.MapControllers();

// This is the asp.net core 5 way:
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
