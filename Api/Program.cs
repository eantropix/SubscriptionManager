using Microsoft.EntityFrameworkCore;
using Application.Interfaces.Services;
using Application.Services;
using Domain.Models;
using Domain.Repositories.Interfaces.UnitOfWork;
using Domain.Repositories.Interfaces;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories;
using Infrastructure.Data.UnitOfWork;
using RabbitMQ.Client;
using Application.Services.Consumers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>
    (options =>  
        options.UseSqlServer(builder.Configuration.GetConnectionString("database")),
        ServiceLifetime.Singleton
    );

builder.Services.AddSingleton<IConnectionFactory>((service) => new ConnectionFactory {
    HostName = builder.Configuration["RabbitMQ:host"],
    Port = int.Parse(builder.Configuration["RabbitMQ:port"]),
    UserName = builder.Configuration["RabbitMQ:username"],
    Password = builder.Configuration["RabbitMQ:password"]
});

builder.Services.AddHostedService<StatusConsumerAppService>();
builder.Services.AddHostedService<SubscriptionConsumerAppService>();
builder.Services.AddHostedService<UserConsumerAppService>();


builder.Services.AddScoped<IRepository<EventHistory>, EventHistoryRepository>();
builder.Services.AddScoped<IRepository<Status>, StatusRepository>();
builder.Services.AddScoped<IRepository<Subscription>, SubscriptionRepository>();
builder.Services.AddScoped<IRepository<User>, UserRepository>();

builder.Services.AddScoped<Publisher>();

// App Services
builder.Services.AddScoped<IUserAppService, UserAppService>();
builder.Services.AddScoped<IStatusAppService, StatusAppService>();
builder.Services.AddScoped<ISubscriptionAppService, SubscriptionAppService>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


var app = builder.Build();

//using (var scope = app.Services.CreateScope()) 
//{
//    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
//    db.Database.Migrate();
//}

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment()) {
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
