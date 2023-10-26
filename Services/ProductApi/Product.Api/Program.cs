using BuiseneesLayer;
using BuiseneesLayer.Abstracts;
using BuiseneesLayer.Contracts;
using Product.Api;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddSingleton<IBackGroundServiceProduct, BackGroundServiceProductController>();
builder.Services.AddHostedService<BackGroundServiceProduct>();
builder.Services.AddHostedService<BackGroundServiceBuyMail>();
builder.Services.AddHostedService<BackGroundServiceUpdateProduct>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//builder.Services.AddHostedService<BackGroundServiceProduct>();
//builder.Services.AddHostedService<BackGroundServiceBuyMail>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
