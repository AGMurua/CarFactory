using CarFactory.Repositories.Interfaces;
using CarFactory.Repositories;
using CarFactory.Services;
using CarFactory.Services.Interfaces;
using CarFactory.Helper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ISaleRepository, SaleRepository>();  
builder.Services.AddScoped<ISaleService, SaleService>();  

builder.Services.AddSingleton<ICarPriceProvider, CarPriceProvider>(); //Se agrega como singleton ya que no varia sus valores son estaticos

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
