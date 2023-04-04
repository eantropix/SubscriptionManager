using Application.Interfaces.Services;
using Application.Services;
using Infrastructure.Data.Context;
using Domain.Repositories.Interfaces.UnitOfWork;
using Infrastructure.Data.Repositories;
using Infrastructure.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using SubscriptionManager.Domain.Models;
using SubscriptionManager.Domain.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>
    (options =>  
        options.UseSqlServer(builder.Configuration.GetConnectionString("default")),
        ServiceLifetime.Singleton
    );

builder.Services.AddScoped<IRepository<EventHistory>, EventHistoryRepository>();
builder.Services.AddScoped<IRepository<Status>, StatusRepository>();
builder.Services.AddScoped<IRepository<Subscription>, SubscriptionRepository>();
builder.Services.AddScoped<IRepository<User>, UserRepository>();

// App Services
builder.Services.AddScoped<IUserAppService, UserAppService>();
builder.Services.AddScoped<IStatusAppService, StatusAppService>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


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
