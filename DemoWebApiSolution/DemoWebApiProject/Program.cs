using DemoWebApiProject.MockData;
using DemoWebApiProject.Services;
using Serilog;

// Set up Serilog here
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs/gameprogresslog.txt", rollingInterval: RollingInterval.Month)
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);
// older way of logging
//builder.Logging.ClearProviders();
//builder.Logging.AddConsole();

// logging using Serilog
builder.Host.UseSerilog();

// Add services to the container
builder.Services.AddControllers().AddXmlDataContractSerializerFormatters(); // Demo: Formatters and Content negotiation

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#if DEBUG
builder.Services.AddTransient<IDummyCustomizedServices, DummyCustomizedServicesLocal>();
#else
builder.Services.AddTransient<IDummyCustomizedServices, DummyCustomizedServicesCloud>();
#endif

builder.Services.AddSingleton<GameProgressDataStore>();

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
