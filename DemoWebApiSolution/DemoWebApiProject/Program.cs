using DemoWebApiProject.DbContexts;
using DemoWebApiProject.Repositories;
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

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#if DEBUG
builder.Services.AddTransient<IDummyCustomizedServices, DummyCustomizedServicesLocal>();
#else
builder.Services.AddTransient<IDummyCustomizedServices, DummyCustomizedServicesCloud>();
#endif

//builder.Services.AddSingleton<GameProgressDataStore>();

builder.Services.AddDbContext<GameProgressContext>(dbContextOptions => dbContextOptions.UseSqlite(builder.Configuration["ConnectionStrings:GameProgressDBConnectionString"]));

builder.Services.AddScoped<IGameProgressRepository, GameProgressRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.Use(async (context, next) =>
    {
        // Check if the request path is the root path '/'
        if (context.Request.Path == "/")
        {
            // Redirect to the Swagger URL
            context.Response.Redirect("/swagger/index.html");
            return;
        }

        // If it's not the root path, continue processing the request
        await next();
    });
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
