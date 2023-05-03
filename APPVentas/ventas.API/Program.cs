using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using ventas.application.Mappers;
using ventas.application.UseCases;
using ventas.application.UseCases.Interfaces;
using ventas.domain.ports.repositories;
using ventas.domain.ports.service;
using ventas.domain.ports.service.Interfaces;
using ventas.infrastructure.Adapters.Secondary;
using ventas.infrastructure.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var services = builder.Services;
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
services.AddDbContext<ProductContext>(options =>
{
	options.UseSqlServer(connectionString);
	//x.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

//services.AddDbContext<ProductContext>(options => options.UseSqlServer(connectionString));
//services.AddScoped<IDbConnection>(x => x.GetRequiredService<ProductContext>().Database.GetDbConnection());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddTransient<IProductService, ProductService>();
services.AddTransient<IProductRepository, ProductRepository>();
services.AddTransient<IProductService, ProductService>();
services.AddTransient<IProductUseCase, ProductUseCase>();
services.AddAutoMapper(typeof(ProductProfile));

services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/error");
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
