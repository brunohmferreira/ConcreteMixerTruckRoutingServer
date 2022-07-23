using ConcreteMixerTruckRoutingServer.Api.Startups;
using Microsoft.AspNetCore.Server.Kestrel.Core;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCustomCors();

builder.Services.AddMemoryCache();

builder.Services.AddCustomAutoMapper();

builder.Services.AddCustomMvc();

builder.Services.AddCustomSwagger();

builder.Services.AddCustomDI();

builder.Services.Configure<KestrelServerOptions>(options =>
{
    options.AllowSynchronousIO = true;
});

builder.Services.Configure<IISServerOptions>(options =>
{
    options.AllowSynchronousIO = true;
});

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.UseCustomCors(builder.Environment);

app.UseCustomException();

app.UseCustomSwagger();

app.UseCustomMvc();

app.Run();

