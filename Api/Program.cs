using Domain.Input;
using Domain.Output;
using Domain.WmsNotifications;
using Infrastructure.Publishers;
using Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ProductsService>();
builder.Services.AddSingleton<NotificationsService>();
builder.Services.AddSingleton<IProductsRepository, ProductsRepository>();
builder.Services.AddSingleton<IWms20Publisher, Wms20KafkaPublisher>();
builder.Services.AddSingleton<IWms13Publisher, Wms13KafkaPublisher>();
builder.Services.Configure<Wms20Configuration>(builder.Configuration.GetSection("Wms20Configuration"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
