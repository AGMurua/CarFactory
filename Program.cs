using CarFactory.Repositories.Interfaces;
using CarFactory.Repositories;
using CarFactory.Services;
using CarFactory.Services.Interfaces;
using CarFactory.Helper;
using CarFactory.Helper.Mapping;
using CarFactory.Middleware;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
}); builder.Services.AddAutoMapper(typeof(SaleMap));
// Memory Cache
builder.Services.AddMemoryCache();

builder.Services.AddScoped<ISaleRepository, SaleRepository>();  
builder.Services.AddScoped<ISaleService, SaleService>();

//Se agrega como singleton ya que no varia sus valores son estaticos
builder.Services.AddSingleton<ICarPriceProvider, CarPriceProvider>(); 

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Custom Middleware
app.UseMiddleware<RequestMetricMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
