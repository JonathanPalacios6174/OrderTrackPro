using Microsoft.EntityFrameworkCore;
using OrderTrackPro.Infrastructure.Repositorie;
using OrderTrackPro.Application.Services;
using OrderTrackPro.Application.Interfaces;
using OrderTrackPro.Infrastructure.Repository;
using OrderTrackPro.Infrastructure.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<NorthwindContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("OrderTrackProDB")));

builder.Services.AddTransient<IOrderInterfaceService, GetOrdersService>();

builder.Services.AddTransient<IOrderRepository, OrderRepository>();

    
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
