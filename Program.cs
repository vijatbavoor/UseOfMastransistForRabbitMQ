using MassTransit;
using RabbitMQ.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure MassTransit with RabbitMQ
builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });
        cfg.ConfigureEndpoints(context);
        cfg.ReceiveEndpoint("product-created-queue", e =>
        {
            e.Bind("product.created", x =>
            {
                x.ExchangeType = ExchangeType.Direct; // Ensure the exchange type matches
                x.RoutingKey = "product.created"; // Set the routing key for the receive endpoint
            });
        });
         cfg.ReceiveEndpoint("order-product-created-queue", e =>
        {
            e.Bind("product.created", x =>
            {
                x.ExchangeType = ExchangeType.Direct; // Ensure the exchange type matches
                x.RoutingKey = "product.created"; // Set the routing key for the receive endpoint
            });
        });
    });
    x.AddConsumer<ProductCreatedConsumer>(); //I can remove this line as the consumer is configured in the receive endpoint
    x.AddConsumer<OrderCreatedConsumer>();
});

builder.Services.AddScoped<IProductCreatedConsumer, ProductCreatedConsumer>();
builder.Services.AddScoped<IProductCreatePublisher, ProductCreatePublisher>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();