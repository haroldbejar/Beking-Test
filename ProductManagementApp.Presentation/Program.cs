using MongoDB.Driver;
using Microsoft.Extensions.Options;
using ProductManagementApp.Application;
using ProductManagementApp.Infrastructure;
using ProductManagementApp.Infrastructure.Data;
using ProductManagementApp.Domain;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<ProductManagementAppDatabaseSettings>(
    builder.Configuration.GetSection(nameof(ProductManagementAppDatabaseSettings)));

builder.Services.AddSingleton<IProductManagementAppDatabaseSettings>( p =>
    p.GetRequiredService<IOptions<ProductManagementAppDatabaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(p =>
    new MongoClient(builder.Configuration.GetValue<string>("ProductManagementAppDatabaseSettings")));

builder.Services.AddMemoryCache();
builder.Services.AddAutoMapperConfig();
builder.Services.AddInfrastructure();
builder.Services.AddApplication();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(corsBuilder => corsBuilder.AllowAnyHeader().AllowAnyMethod().WithOrigins("*"));
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();


