using Planetas.API.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ConfigureOptions.Configure(builder.Services, builder.Configuration);
ConfigureApplicationServices.Configure(builder.Services);
ConfigureInfranstructureServices.Configure(builder.Services);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
