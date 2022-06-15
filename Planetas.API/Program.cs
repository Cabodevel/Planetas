using Planetas.API.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ConfigureOptions.Configure(builder.Services, builder.Configuration);
ConfigureApplicationServices.Configure(builder.Services);
ConfigureInfranstructureServices.Configure(builder.Services);

builder.Services.AddAutoMapper(typeof(MappingProfile));

var corsPolicy = "AllowLocalHost";

builder.Services.AddCors(opt => opt.AddPolicy(corsPolicy, policy => 
{
    policy.AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod();
}));
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

app.UseCors(corsPolicy);

app.MapControllers();

app.Run();
