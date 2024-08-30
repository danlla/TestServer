using Microsoft.EntityFrameworkCore;
using Prometheus;
using TestServer;
using TestServer.Model;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<DataBaseContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("Postgre")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHealthChecks()
    .AddCheck<SampleHealthCheck>(nameof(SampleHealthCheck))
    .ForwardToPrometheus();

builder.Services.AddCors(policy => policy.AddPolicy("default", opt =>
{
    opt.AllowAnyHeader();
    opt.AllowCredentials();
    opt.AllowAnyMethod();
    opt.SetIsOriginAllowed(_ => true);
}));

var app = builder.Build();

app.MapGet("/", () => Results.Ok("server up"));

app.MapMetrics();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("default");
app.MapControllers();

Counters.TestCounter.Publish();

app.Run();
