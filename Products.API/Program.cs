using Products.API.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<List<ProductModel>>(s=> new List<ProductModel>()
{
    new ProductModel { Id = 1, Name = "Laptop", Price = 899.99f },
    new ProductModel { Id = 2, Name = "Smartphone", Price = 499.99f },
    new ProductModel { Id = 3, Name = "Headphones", Price = 199.99f },
    new ProductModel { Id = 4, Name = "Smartwatch", Price = 149.50f },
    new ProductModel { Id = 5, Name = "Tablet", Price = 329.99f },
    new ProductModel { Id = 6, Name = "Wireless Mouse", Price = 29.99f },
    new ProductModel { Id = 7, Name = "Keyboard", Price = 49.99f },
    new ProductModel { Id = 8, Name = "Monitor", Price = 179.99f },
    new ProductModel { Id = 9, Name = "Bluetooth Speaker", Price = 59.99f },
    new ProductModel { Id = 10, Name = "Camera", Price = 399.99f },
    new ProductModel { Id = 11, Name = "Router", Price = 89.99f },
    new ProductModel { Id = 12, Name = "External Hard Drive", Price = 129.99f },
    new ProductModel { Id = 13, Name = "Printer", Price = 89.00f },
    new ProductModel { Id = 14, Name = "Phone Case", Price = 19.99f },
    new ProductModel { Id = 15, Name = "Gaming Mouse", Price = 69.99f },
    new ProductModel { Id = 16, Name = "Graphics Card", Price = 499.00f },
    new ProductModel { Id = 17, Name = "USB Flash Drive", Price = 15.99f },
    new ProductModel { Id = 18, Name = "Webcam", Price = 89.99f },
    new ProductModel { Id = 19, Name = "VR Headset", Price = 349.99f },
    new ProductModel { Id = 20, Name = "Phone Charger", Price = 9.99f }
});

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
