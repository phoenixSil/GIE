using Gie.Api.Datas;
using Gie.Api.Extensions;
using MsCommun.Extensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Configuration Serilog
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);


Log.Information("GIE Demmarre demarre ");
builder.Host.UseSerilog((ctx, lc) => lc.WriteTo.Console().ReadFrom.Configuration(ctx.Configuration));

//Add services to the container.

builder.Services.AddSqlServerDbConfiguration<EtudiantDbContext>(builder.Configuration);
builder.Services.ConfigureApplicationServices();
builder.Services.ConfigureControllerServices();
builder.Services.ConfigurePersistenceServices(builder.Configuration);
builder.Services.AddConfigurationMassTransitWithRabbitMQ(builder.Configuration);

// Add services to the container.

builder.Services.AddControllers();
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
