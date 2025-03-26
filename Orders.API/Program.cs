using Orders.API.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton<List<OrderModel>>(s=> new List<OrderModel>()
{
    new OrderModel { Id = 1, ClientName = "John Doe", Total = 150.75f },
    new OrderModel { Id = 2, ClientName = "Jane Smith", Total = 200.50f },
    new OrderModel { Id = 3, ClientName = "Alice Johnson", Total = 120.30f },
    new OrderModel { Id = 4, ClientName = "Bob Brown", Total = 99.99f },
    new OrderModel { Id = 5, ClientName = "Charlie White", Total = 310.45f },
    new OrderModel { Id = 6, ClientName = "David Black", Total = 500.00f },
    new OrderModel { Id = 7, ClientName = "Eve Green", Total = 75.80f },
    new OrderModel { Id = 8, ClientName = "Frank Blue", Total = 280.60f },
    new OrderModel { Id = 9, ClientName = "Grace Red", Total = 125.10f },
    new OrderModel { Id = 10, ClientName = "Hank Yellow", Total = 540.90f }
});
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
