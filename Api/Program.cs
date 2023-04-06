using Microsoft.EntityFrameworkCore;
using Application.Interfaces.Services;
using Application.Services;
using Domain.Models;
using Domain.Repositories.Interfaces.UnitOfWork;
using Domain.Repositories.Interfaces;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories;
using Infrastructure.Data.UnitOfWork;

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
builder.Services.AddScoped<ISubscriptionAppService, SubscriptionAppService>();

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
